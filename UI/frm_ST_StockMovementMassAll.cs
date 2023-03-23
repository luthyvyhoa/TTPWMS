using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using DevExpress.XtraEditors;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using UI.WarehouseManagement;

namespace UI.StockTake
{
    public partial class frm_ST_StockMovementMassAll : Common.Controls.frmBaseForm
    {
        private static readonly string fileName = "RoomMovementMass.txt";
        DataProcess<Pallets> pallet = new DataProcess<Pallets>();
        BindingList<ST_WMS_StockMovementMassAll_Result> listStMassAll = null;
        DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
        DataProcess<ST_WMS_StockMovementMassAll_Result> stockMovementMassAllDA = new DataProcess<ST_WMS_StockMovementMassAll_Result>();
        ST_WMS_StockMovementMassAll_Result currentMassAll = null;
        int receivingOrderDetailID = 0;
        int numberEmp;
        int totalRow = 0;
        int newtotalRow = 0;
        bool toggleConfirmed = false;

        public frm_ST_StockMovementMassAll()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //string roomSelectedID = Common.Process.DataTransfer.ReadFileName(fileName);
            //if (!string.IsNullOrEmpty(roomSelectedID))
            //{
            //    int idRoomSelected = Convert.ToInt32(roomSelectedID);
            //    this.lookupEditRooms.EditValue = idRoomSelected;
            //}

            //this.textEditHigh.Visible = false;
            //this.textEditTo.Visible = false;
            this.labelControlUser.Text = AppSetting.CurrentUser.LoginName;
            // visibleDriverLabeller(false);
            daViewFrom.Text = DateTime.Now.AddDays(-14).ToShortDateString();
            daTo.Text = DateTime.Now.ToShortDateString();

            initSTMassRemark();
            initRooms();
            initCustomer();
            setevent();
            InitEvent();
            // initEmployees(lookupEditFinishDriver);
            //initEmployees(lookupEditPickDriver);
            //initEmployees(lookupEditLabeller);
        }

        private void setevent()
        {
            this.repositoryItemButtonEditF.Click += repositoryItemButtonEditF_Click;
            this.repositoryItemButtonEditA.Click += repositoryItemButtonEditA_Click;
            this.repositoryItemButtonEditP.Click += repositoryItemButtonEditP_Click;
            this.repositoryItemLookUpEditFAP.EditValueChanged += repositoryItemLookUpEditFAP_EditValueChanged;
            this.repositoryItemTextEditPallet.Click += repositoryItemTextEditPallet_Click;
            bindingNavigatorMassAll.PositionChanged += BindingNavigatorMassAll_PositionChanged;
        }

        void repositoryItemTextEditPallet_Click(object sender, EventArgs e)
        {
            DataProcess<STDispatchingLocationAtDispatch_Result> STDispatchingLocationAtDispatch = new DataProcess<STDispatchingLocationAtDispatch_Result>();

            object value = this.gridViewStockMovementMass.GetFocusedRowCellValue(this.gridViewStockMovementMass.Columns["Remark"]);
            if (value != null)
            {
                string oldPalletID = value.ToString();
                oldPalletID = oldPalletID.Substring(oldPalletID.Length - 7);
                this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.gridControlLocationInfo_Details.DataSource = STDispatchingLocationAtDispatch.Executing("STDispatchingLocationAtDispatch @DispatchingLocationID ={0}, @PalletID={1}", 0, Convert.ToInt32(oldPalletID));
            }

        }

        void repositoryItemLookUpEditFAP_EditValueChanged(object sender, EventArgs e)
        {
            var controlLke = (LookUpEdit)sender;
            var valueSelected = controlLke.Text;
            this.gridViewStockMovementMass.SetFocusedRowCellValue("Label", valueSelected);
            this.gridViewStockMovementMass.SetFocusedRowCellValue("LocationID", controlLke.EditValue);

            //pallet.Update(listpallet.Where(x => x.IsModified == true).ToArray());
            int palletID = Convert.ToInt32(this.gridViewStockMovementMass.GetFocusedRowCellValue("PalletID"));
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            var currentpallet = palletDA.Select(b => b.PalletID == palletID).FirstOrDefault();
            currentpallet.LocationID = Convert.ToInt32(controlLke.EditValue);
            currentpallet.Label = controlLke.Text;
            palletDA.Update(currentpallet);

        }

        void repositoryItemButtonEditP_Click(object sender, EventArgs e)
        {
            int rowHandle = this.gridViewStockMovementMass.FocusedRowHandle;
            if (rowHandle <= 0) return;
            int preIndex = rowHandle - 1;
            string lable = Convert.ToString(this.gridViewStockMovementMass.GetRowCellValue(preIndex, "Label"));
            int locationID = Convert.ToInt32(this.gridViewStockMovementMass.GetRowCellValue(preIndex, "LocationID"));
            this.gridViewStockMovementMass.SetFocusedRowCellValue("Label", lable);
            this.gridViewStockMovementMass.SetFocusedRowCellValue("LocationID", locationID);

            int palletID = Convert.ToInt32(this.gridViewStockMovementMass.GetFocusedRowCellValue("PalletID"));
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            var currentpallet = palletDA.Select(b => b.PalletID == palletID).FirstOrDefault();
            currentpallet.LocationID = locationID;
            currentpallet.Label = lable;
            palletDA.Update(currentpallet);
        }

        void repositoryItemButtonEditA_Click(object sender, EventArgs e)
        {
            if (lookupEditRooms.EditValue == null)
                return;
            if (currentMassAll.StockMovementMassConfirm == false)
            {
                //DataProcess<STPalletAllocationAll_Result> STPalletAllocationAllDA = new DataProcess<STPalletAllocationAll_Result>();
                //var STPalletAllocationAll = STPalletAllocationAllDA.Executing("STPalletAllocationAll @varHomeRoom1=" + lookupEditRooms.Text + ", @varHomeRoom2=" + lookupEditRooms.Text + ",@varStoreID=" + AppSetting.CurrentUser.StoreID);

                var dataSource = FileProcess.LoadTable("STPalletAllocationAll @varHomeRoom1=" + lookupEditRooms.Text + ", @varHomeRoom2=" + lookupEditRooms.Text + ",@varStoreID=" + AppSetting.CurrentUser.StoreID);

                //repositoryItemLookUpEditFAP.DataSource = STPalletAllocationAll;
                repositoryItemLookUpEditFAP.DataSource = dataSource;

                repositoryItemLookUpEditFAP.ValueMember = "LocationID";
                repositoryItemLookUpEditFAP.DisplayMember = "LocationNumber";
                
                repositoryItemLookUpEditFAP.Columns["Z"].Visible = false;//
                repositoryItemLookUpEditFAP.Columns["X"].Visible = true;//
                repositoryItemLookUpEditFAP.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEditFAP.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                gridColumnFAP.OptionsColumn.AllowFocus = true;
                gridViewStockMovementMass.FocusedColumn = gridColumnFAP;
                gridViewStockMovementMass.PostEditor();
                repositoryItemLookUpEditFAP.ImmediatePopup = true;
                gridViewStockMovementMass.ShowEditor();
                ((LookUpEdit)gridViewStockMovementMass.ActiveEditor).ShowPopup();
            }
        }

        void repositoryItemButtonEditF_Click(object sender, EventArgs e)
        {
            if (lookupEditRooms.EditValue == null)
                return;
            if (currentMassAll.StockMovementMassConfirm == false)
            {
                DataProcess<STPalletAllocationFree_Result> STPalletAllocationFree = new DataProcess<STPalletAllocationFree_Result>();
                List<STPalletAllocationFree_Result> STPalletAllocationFree_Result = new List<DA.STPalletAllocationFree_Result>();
                STPalletAllocationFree_Result = STPalletAllocationFree.Executing("STPalletAllocationFree @HomeRoom1={0}, @HomeRoom2={1},@varStoreID={2}", lookupEditRooms.Text, lookupEditRooms.Text, AppSetting.CurrentUser.StoreID).ToList();
                repositoryItemLookUpEditFAP.DataSource = STPalletAllocationFree_Result;
                repositoryItemLookUpEditFAP.ValueMember = "LocationID";
                repositoryItemLookUpEditFAP.DisplayMember = "LocationNumber";
                repositoryItemLookUpEditFAP.Columns["X"].Visible = true;
                repositoryItemLookUpEditFAP.Columns["Z"].Visible = false;
                repositoryItemLookUpEditFAP.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repositoryItemLookUpEditFAP.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                //repositoryItemLookUpEditFAP.BestFitRowCount
                gridColumnFAP.OptionsColumn.AllowFocus = true;
                gridViewStockMovementMass.FocusedColumn = gridColumnFAP;
                gridViewStockMovementMass.PostEditor();
                repositoryItemLookUpEditFAP.ImmediatePopup = true;
                gridViewStockMovementMass.ShowEditor();
                ((LookUpEdit)gridViewStockMovementMass.ActiveEditor).ShowPopup();
            }

        }
        private void visibleDriverLabeller(bool visible)
        {
            this.layoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void InitEvent()
        {
            // daViewFrom.EditValueChanged += daViewFrom_EditValueChanged;


        }

        private void SetActiveControl()
        {
            if (toggleConfirmed == true)
            {
                simpleButtonAllocate.Enabled = false;
                simpleButtonClearDelete.Enabled = false;
                simpleButtonProcess.Enabled = false;
                lookupEditCustomer.Enabled = false;
                simpleButtonConfirm.Enabled = false;
                simpleButtonConfirm.Text="UnConfirm";

                simpleButtonOnFloor.Enabled = false;
                textEditAisle.Enabled = false;
                lookupEditRooms.Enabled = false;
                radioGroup1.Enabled = false;
                radioGroup2.Enabled = false;
                simpleButtonDecalAdvice.Enabled = false;
                simpleButtonAdvice.Enabled = false;
                simpleButtonLabellA4.Enabled = true;
                lookupEditSelectBy.Enabled = false;
                lookupEditValue.Enabled = false;
                memoEditMassInformation.Enabled = false;
                checkEditMain.Enabled = false;
            }
            else
            {
                simpleButtonAllocate.Enabled = true;
                simpleButtonClearDelete.Enabled = true;
                simpleButtonProcess.Enabled = true;
                lookupEditCustomer.Enabled = true;
                simpleButtonConfirm.Enabled = true;
                simpleButtonConfirm.Text = "Confirm";

                simpleButtonOnFloor.Enabled = true;
                textEditAisle.Enabled = true;
                lookupEditRooms.Enabled = true;
                radioGroup1.Enabled = true;
                radioGroup2.Enabled = true;
                simpleButtonDecalAdvice.Enabled = true;
                simpleButtonAdvice.Enabled = true;
                simpleButtonLabellA4.Enabled = true;
                lookupEditSelectBy.Enabled = true;
                lookupEditValue.Enabled = true;
                memoEditMassInformation.Enabled = true;
                checkEditMain.Enabled = true;
            }
            if (gridViewStockMovementMass.RowCount > 0)
            {
                simpleButtonProcess.Enabled = false;
                lookupEditCustomer.Enabled = false;
                lookupEditSelectBy.Enabled = false;
                lookupEditValue.Enabled = false;
                memoEditMassInformation.Enabled = false;
            }
            else
            {
                simpleButtonProcess.Enabled = true;
                lookupEditCustomer.Enabled = true;
                lookupEditSelectBy.Enabled = true;
                lookupEditValue.Enabled = true;
                memoEditMassInformation.Enabled = true;
            }
        }

        void daViewFrom_EditValueChanged(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(daViewFrom.EditValue);
            DateTime toDate = Convert.ToDateTime(daTo.EditValue);
            TimeSpan valueD = fromDate.Subtract(toDate);
            if (fromDate > toDate)
            {
                daViewFrom.EditValue = daTo.EditValue;
            }
            else if (valueD.Days > 60)
            {
                fromDate = toDate.AddDays(-60);
            }
            var requeryStockMassAll = FileProcess.LoadTable("ST_WMS_StockMovementMassFromDateToDate @FromDate=" + daViewFrom.ToString() + ", @ToDate=" + daTo.ToString() + "");

        }

        private void frm_ST_StockMovementMassAll_Load(object sender, EventArgs e)
        {
            loadStockMovementMassAll();

        }

        private void loadStockMovementMassAll()
        {
            DateTime compareDate = stockMovementMassAllDA.GetDate().AddDays(-32);
            List<ST_WMS_StockMovementMassAll_Result> tem = (List<ST_WMS_StockMovementMassAll_Result>)stockMovementMassAllDA.Executing("ST_WMS_StockMovementMassAll");
            listStMassAll = new BindingList<ST_WMS_StockMovementMassAll_Result>(tem.OrderBy(t => t.StockMovementMassID).ToList());
            totalRow = listStMassAll.Count;
            this.bindingNavigatorMassAll.DataSource = listStMassAll;
            //int position = stockMovementMassAll.Count - 1;
            //dataNavigatorStockMassAll.Position = position;

            labelControlMassDate.DataBindings.Add("Text", bindingNavigatorMassAll.DataSource, "StockMovementMassDate", true, DataSourceUpdateMode.Never, DateTime.Now);
            labelControlMassNumber.DataBindings.Add("Text", bindingNavigatorMassAll.DataSource, "StockMovementMassNumber", true, DataSourceUpdateMode.Never, "");
            labelControlCustomerName.DataBindings.Add("Text", bindingNavigatorMassAll.DataSource, "CustomerName", true, DataSourceUpdateMode.Never, "");
            labelControlUser.DataBindings.Add("Text", bindingNavigatorMassAll.DataSource, "UserID", true, DataSourceUpdateMode.Never, "");
            memoEditMassInformation.DataBindings.Add("Text", bindingNavigatorMassAll.DataSource, "StockMovementMassInformation", true, DataSourceUpdateMode.Never, "");
            textEditStart.DataBindings.Add("EditValue", bindingNavigatorMassAll.DataSource, "StartTime", true, DataSourceUpdateMode.Never, DateTime.Now);
            textEditEnd.DataBindings.Add("EditValue", bindingNavigatorMassAll.DataSource, "EndTime", true, DataSourceUpdateMode.Never, DateTime.Now);
            lookupEditRooms.EditValue = "H";
            radioGroup1.SelectedIndex = 3;
            radioGroup2.SelectedIndex = 3;
            this.bindingNavigatorMassAll.Position = this.listStMassAll.Count - 1;
            if (currentMassAll == null)
            {
                currentMassAll = new ST_WMS_StockMovementMassAll_Result();
            }
            lookupEditSelectBy.EditValue = currentMassAll.StockMovementMassRemark;
            lookupEditCustomer.EditValue = currentMassAll.CustomerID;
            this.LoadPalletInfoByRODetailsID();
            if (gridViewStockMovementMass.RowCount > 0)
            {
                simpleButtonProcess.Enabled = false;
            }
            this.Height = 800;

            toggleConfirmed = currentMassAll.StockMovementMassConfirm;
            this.SetActiveControl();
        }

        private void BindingNavigatorMassAll_PositionChanged(object sender, EventArgs e)
        {
            if (this.bindingNavigatorMassAll.Position < 0) return;
            currentMassAll = (ST_WMS_StockMovementMassAll_Result)this.listStMassAll[this.bindingNavigatorMassAll.Position];
            if (currentMassAll.StockMovementMassID == 0)
                return;
            int massID = currentMassAll.StockMovementMassID;
            currentMassAll = listStMassAll.Where(q => q.StockMovementMassID == massID).FirstOrDefault();
            if (currentMassAll != null)
            {
                receivingOrderDetailID = Convert.ToInt32(currentMassAll.ReceivingOrderDetailID);
                toggleConfirmed = currentMassAll.StockMovementMassConfirm;
            }
            this.textEditEnd.EditValue = currentMassAll.EndTime;

            this.lookupEditCustomer.EditValue = currentMassAll.CustomerID;
            this.LoadPalletInfoByRODetailsID();

            // Set active control
            this.SetActiveControl();

            if ((int)lookupEditCustomer.EditValue == 15)
            {
                this.layoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lookupEditSelectBy.EditValue = "By Aisle";
            }
            else
            {
                //this.layoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //this.layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (gridViewStockMovementMass.DataRowCount > 0)
                simpleButtonProcess.Enabled = false;

            loadEmployees();
        }

        private void initSTMassRemark()
        {
            var tableMassRemark = new System.Data.DataTable();
            tableMassRemark.Columns.Add("StockMovementMassRemark");
            // Other row "By Aisle";"By Product";"RO";"Many Product"
            var nRow = tableMassRemark.NewRow();
            nRow["StockMovementMassRemark"] = "By Aisle";
            var tRow = tableMassRemark.NewRow();
            tRow["StockMovementMassRemark"] = "By Product";
            var hRow = tableMassRemark.NewRow();
            hRow["StockMovementMassRemark"] = "RO";
            var cRow = tableMassRemark.NewRow();
            cRow["StockMovementMassRemark"] = "Many Product";
            // Add row
            tableMassRemark.Rows.Add(nRow);
            tableMassRemark.Rows.Add(tRow);
            tableMassRemark.Rows.Add(hRow);
            tableMassRemark.Rows.Add(cRow);

            lookupEditSelectBy.Properties.DataSource = tableMassRemark;
            lookupEditSelectBy.Properties.ValueMember = "StockMovementMassRemark";
            lookupEditSelectBy.Properties.DisplayMember = "StockMovementMassRemark";
            lookupEditSelectBy.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void initRooms()
        {
            DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
            lookupEditRooms.Properties.DataSource = roomDA.Select(r => r.StoreID == AppSetting.StoreID);
            lookupEditRooms.Properties.ValueMember = "RoomID";
            lookupEditRooms.Properties.DisplayMember = "RoomID";
            lookupEditRooms.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void initCustomer()
        {
            lookupEditCustomer.Properties.DataSource = AppSetting.CustomerList;
            lookupEditCustomer.Properties.ValueMember = "CustomerID";
            lookupEditCustomer.Properties.DisplayMember = "CustomerNumber";
        }

        private void initEmployees(LookUpEdit lookupEdit)
        {
            List<Employees> employActive = AppSetting.EmployessList.Where(e => e.Active == true && e.Status == 1).OrderBy(e => e.FullName).ToList();
            lookupEdit.Properties.DataSource = employActive;
            lookupEdit.Properties.ValueMember = "EmployeeID";
            lookupEdit.Properties.DisplayMember = "FullName";
        }

        private void checkEditMain_CheckedChanged(object sender, EventArgs e)
        {
            lookupEditCustomer.Focus();
            lookupEditCustomer.ShowPopup();
        }
        private void loadEmployees()
        {
            decimal totalPalletWeight = 0;
            decimal totalOriginal = 0;
            decimal count = 0;
            if (gridViewStockMovementMass.RowCount > 1)
            {
                this.xtraTabPageEmployees.PageVisible = true;
                this.xtraTabPageEmployees.Controls.Clear();
                count = Convert.ToDecimal(this.gridColumnDestination.SummaryItem.SummaryValue);
                totalOriginal = Convert.ToDecimal(this.gridColumnOriginalQuantity.SummaryItem.SummaryValue);
                totalPalletWeight = Convert.ToDecimal(this.gridColumnPalletWeight.SummaryItem.SummaryValue);
                urc_WM_EmployeeInfo urcEmployee = new urc_WM_EmployeeInfo(this.labelControlMassNumber.Text, count, totalPalletWeight, totalOriginal, "");
                numberEmp = urcEmployee.countEmp;
                urcEmployee.hideLayoutControl();
                urcEmployee.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
                urcEmployee.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0);
                urcEmployee.Parent = this.xtraTabPageEmployees;
            }
        }

        private void labelControlEmployees_Click(object sender, EventArgs e)
        {
            if (this.layoutControlItem5.Visibility.Equals(DevExpress.XtraLayout.Utils.LayoutVisibility.Never))
            {
                this.Height = 1046;
                this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                loadEmployees();
                xtraTabControl1.SelectedTabPage = xtraTabPageEmployees;
            }
            else
            {
                this.Height = 800;
                this.layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void simpleButtonClearDelete_Click(object sender, EventArgs e)
        {
            if (labelControlUser.Text != AppSetting.CurrentUser.LoginName)
            {
                MessageBox.Show("You can not process order created by other user !");
                return;
            }
            int massID = 0;
            int result = 0;
            if (gridViewStockMovementMass.RowCount == 0)
            {
                if (MessageBox.Show("Are you sure to delete this mass movements ?", "TPWMS", MessageBoxButtons.YesNo) == DialogResult.No) return;
                bindingNavigatorMassAll.DataSource = listStMassAll;
                massID = Convert.ToInt32(listStMassAll.Where(q => q.StockMovementMassID == currentMassAll.StockMovementMassID).FirstOrDefault().StockMovementMassID);
                int resultDel = stockMovementMassAllDA.ExecuteNoQuery("Delete from StockMovementMass where StockMovementMassID=" + massID);
                this.listStMassAll.Remove(this.currentMassAll);
                currentMassAll = (ST_WMS_StockMovementMassAll_Result)this.listStMassAll[bindingNavigatorMassAll.Position];
                this.LoadPalletInfoByRODetailsID();
                totalRow = listStMassAll.Count;
                if(resultDel>0)
                {
                    MessageBox.Show("Delete Success", "TPWMS", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Delete Error", "TPWMS", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to clear this mass movements ?", "TPWMS", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                massID = currentMassAll.StockMovementMassID;
                DataProcess<object> clearDelete = new DataProcess<object>();
                listStMassAll = new BindingList<ST_WMS_StockMovementMassAll_Result>((List<ST_WMS_StockMovementMassAll_Result>)stockMovementMassAllDA.Executing("ST_WMS_StockMovementMassAll"));
                ST_WMS_StockMovementMassAll_Result currentNull = (ST_WMS_StockMovementMassAll_Result)listStMassAll.Where(l => l.StockMovementMassID == massID).FirstOrDefault();
                receivingOrderDetailID = Convert.ToInt32(listStMassAll.Where(l => l.StockMovementMassID == massID).FirstOrDefault().ReceivingOrderDetailID);
                if (receivingOrderDetailID != 0)
                {
                    result = clearDelete.ExecuteNoQuery("STStockMovementMassClearOrder @ReceivingOrderDetailID={0}, @StockMovementMassID={1}", (int)receivingOrderDetailID, (int)currentMassAll.StockMovementMassID);
                    this.LoadPalletInfoByRODetailsID();
                    simpleButtonProcess.Enabled = true;
                }
                else
                {
                    gridControlStockMovementMass.DataSource = null;
                }
            }

        }

        private void lookupEditSelectBy_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookupEditSelectBy.EditValue == null || lookupEditCustomer.EditValue == null) return;
            switch (lookupEditSelectBy.EditValue.ToString())
            {
                case "By Aisle":
                    lookupEditValue.Properties.DataSource = roomDA.Select(r => r.StoreID == AppSetting.StoreID);
                    lookupEditValue.Properties.Columns["RoomID"].Visible = true;

                    lookupEditValue.Properties.Columns["Product"].Visible = false;
                    lookupEditValue.Properties.Columns["Name"].Visible = false;
                    lookupEditValue.Properties.Columns["WeightPerPackage"].Visible = false;
                    lookupEditValue.Properties.Columns["Discontinue"].Visible = false;
                    lookupEditValue.Properties.Columns["CustomerID"].Visible = false;
                    lookupEditValue.Properties.Columns["ReceivingOrderNumber"].Visible = false;
                    lookupEditValue.Properties.Columns["ReceivingOrderDate"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyNow"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyOriginal"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyPallets"].Visible = false;
                    lookupEditValue.Properties.ValueMember = "RoomID";
                    lookupEditValue.Properties.DisplayMember = "RoomID";
                    memoEditMassInformation.Text = "";
                    lookupEditValue.Focus();
                    lookupEditValue.ShowPopup();
                    break;
                case "RO":
                    DataProcess<STStockMovementMassOrderList_Result> STStockMovementMassOrderList = new DataProcess<STStockMovementMassOrderList_Result>();
                    lookupEditValue.Properties.DataSource = STStockMovementMassOrderList.Executing("STStockMovementMassOrderList @CustomerID={0}", (int)lookupEditCustomer.EditValue);
                    lookupEditValue.Properties.Columns["RoomID"].Visible = false;
                    lookupEditValue.Properties.Columns["Product"].Visible = false;
                    lookupEditValue.Properties.Columns["Name"].Visible = false;
                    lookupEditValue.Properties.Columns["WeightPerPackage"].Visible = false;
                    lookupEditValue.Properties.Columns["Discontinue"].Visible = false;
                    lookupEditValue.Properties.Columns["CustomerID"].Visible = false;

                    lookupEditValue.Properties.Columns["ReceivingOrderNumber"].Visible = true;
                    lookupEditValue.Properties.Columns["ReceivingOrderDate"].Visible = true;
                    lookupEditValue.Properties.Columns["QtyNow"].Visible = true;
                    lookupEditValue.Properties.Columns["QtyOriginal"].Visible = true;
                    lookupEditValue.Properties.Columns["QtyPallets"].Visible = true;

                    lookupEditValue.Properties.ValueMember = "ReceivingOrderNumber";
                    lookupEditValue.Properties.DisplayMember = "ReceivingOrderNumber";
                    lookupEditValue.Focus();
                    lookupEditValue.ShowPopup();
                    break;
                case "By Product":
                case "Many Product":
                    var customerID = (int)lookupEditCustomer.EditValue;
                    DataProcess<STComboProductID_Result> STComboProductID = new DataProcess<STComboProductID_Result>();
                    DataProcess<tmpProductRemains> productRemainsDataAccess = new DataProcess<tmpProductRemains>();
                    var listProductRemains = (List<tmpProductRemains>)productRemainsDataAccess.Executing("SELECT tmpProductRemains.* FROM tmpProductRemains WHERE tmpProductRemains.tmpCustomerID = {0}", customerID);
                    var allProduct = STComboProductID.Executing("STComboProductID @CustomerID={0}", customerID);
                    var remainProducts = new List<STComboProductID_Result>();

                    // Filter product has remain quantity
                    foreach (var product in listProductRemains)
                    {
                        var prd = allProduct.FirstOrDefault(p => p.ProductID == product.tmpProductRemainID);
                        if (prd != null)
                        {
                            remainProducts.Add(prd);
                        }
                    }

                    lookupEditValue.Properties.DataSource = remainProducts.OrderBy(p => p.ProductNumber).ToList();
                    lookupEditValue.Properties.Columns["RoomID"].Visible = false;
                    lookupEditValue.Properties.Columns["ReceivingOrderNumber"].Visible = false;
                    lookupEditValue.Properties.Columns["ReceivingOrderDate"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyNow"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyOriginal"].Visible = false;
                    lookupEditValue.Properties.Columns["QtyPallets"].Visible = false;

                    lookupEditValue.Properties.Columns["Product"].Visible = true;
                    lookupEditValue.Properties.Columns["Name"].Visible = true;
                    lookupEditValue.Properties.Columns["WeightPerPackage"].Visible = true;
                    lookupEditValue.Properties.Columns["Discontinue"].Visible = true;
                    lookupEditValue.Properties.Columns["CustomerID"].Visible = true;

                    lookupEditValue.Properties.ValueMember = "Product";
                    lookupEditValue.Properties.DisplayMember = "Product";
                    lookupEditValue.Focus();
                    lookupEditValue.ShowPopup();
                    break;
                default:
                    break;
            }
        }

        private void simpleButtonProcess_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (labelControlUser.Text != AppSetting.CurrentUser.LoginName)
            {
                MessageBox.Show("You can not process order created by other user !");
                return;
            }
            if (memoEditMassInformation.Text == "")
                return;
            if (gridViewStockMovementMass.RowCount > 0)
            {
                simpleButtonClearDelete.Focus();
                simpleButtonProcess.Enabled = false;
                return;
            }
            if (lookupEditValue.EditValue == null)
                return;
            DataProcess<StockMovementMass> stockMovementMassDA = new DataProcess<StockMovementMass>();
            int receivingOrderID = 0;
            int customerID = Convert.ToInt32(lookupEditCustomer.GetColumnValue("CustomerID").ToString());
            if (lookupEditSelectBy.Text == "RO")
                receivingOrderID = Convert.ToInt32(lookupEditValue.GetColumnValue("ReceivingOrderID").ToString());
            int massID = 0;
            StockMovementMass newStock = new StockMovementMass();
            if (totalRow <= newtotalRow)
            {
                newStock.StockMovementMassDate = DateTime.Now;
                newStock.StartTime = DateTime.Now;
                newStock.UserID = AppSetting.CurrentUser.LoginName;

                newStock.ReceivingOrderID = receivingOrderID;
                newStock.CustomerID = customerID;
                newStock.StockMovementMassRemark = lookupEditSelectBy.Text;
                newStock.StockMovementMassConfirm = false;
                newStock.EmployeeID = AppSetting.CurrentUser.EmployeeID;
                newStock.StockMovementMassInformation = this.memoEditMassInformation.Text;
                newStock.StockMovementMassNumber = this.labelControlMassNumber.Text;
                newStock.IsPrinted = false;
                newStock.Ts = new byte[1];
                stockMovementMassDA.Insert(newStock);
                massID = newStock.StockMovementMassID;
            }
            else
            {
                receivingOrderDetailID = Convert.ToInt32(currentMassAll.ReceivingOrderDetailID);
                massID = currentMassAll.StockMovementMassID;
            }
            // New StockMovementMass to insert new row in datable

            switch (lookupEditSelectBy.Text)
            {
                case "RO":
                    if (lookupEditValue.EditValue != null)
                    {
                        int qtypallet = Convert.ToInt32(lookupEditValue.GetColumnValue("QtyPallets").ToString());
                        result = stockMovementMassDA.ExecuteNoQuery("STStockMovementMassProcessOrder @QtyPallet={0},@ReceivingOrderID={1},@UserName={2},@StockMovementMassID={3}", qtypallet, receivingOrderID, AppSetting.CurrentUser.LoginName, (int)massID);
                        listStMassAll = new BindingList<ST_WMS_StockMovementMassAll_Result>((List<ST_WMS_StockMovementMassAll_Result>)stockMovementMassAllDA.Executing("ST_WMS_StockMovementMassAll").OrderBy(l => l.StockMovementMassID).ToList());
                        if (massID != 0)
                            receivingOrderDetailID = Convert.ToInt32(listStMassAll.Where(l => l.StockMovementMassID == massID).FirstOrDefault().ReceivingOrderDetailID);
                    }
                    break;
                case "By Aisle":
                    if (lookupEditValue.EditValue != null)
                    {
                        if (checkEditMain.Checked == true)
                        {
                            result = stockMovementMassDA.ExecuteNoQuery("STStockMovementMassProcessManyAisle_Main @CustomerID={0},@AisleList={1},@UserName={2},@StockMovementMassID={3},@LocationHigh={4}, @LocationHighTo={5}",
                                customerID, memoEditMassInformation.Text, AppSetting.CurrentUser.LoginName, massID, Int32.Parse(this.textEditHigh.Text), Int32.Parse(this.textEditTo.Text));
                        }
                        else
                        {
                            result = stockMovementMassDA.ExecuteNoQuery("STStockMovementMassProcessManyAisle  @CustomerID={0}, @AisleList={1},@UserName={2},@StockMovementMassID={3},@LocationHigh={4}, @LocationHighTo={5}",
                                customerID, memoEditMassInformation.Text, AppSetting.CurrentUser.LoginName, massID, Convert.ToInt32(this.textEditHigh.EditValue), Convert.ToInt32(this.textEditTo.EditValue));
                            if (result < 0)
                            {
                                MessageBox.Show("Can't Process StockMovementMass", "WMS-20147", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        listStMassAll = new BindingList<ST_WMS_StockMovementMassAll_Result>((List<ST_WMS_StockMovementMassAll_Result>)stockMovementMassAllDA.Executing("ST_WMS_StockMovementMassAll").OrderBy(l => l.StockMovementMassID).ToList());
                    }
                    break;
                case "By Product":
                case "Many Product":
                    if (lookupEditValue.EditValue != null)
                    {
                        int productID = Convert.ToInt32(lookupEditValue.GetColumnValue("ProductID").ToString());

                        result = stockMovementMassDA.ExecuteNoQuery("STStockMovementMassProcessProduct @CustomerID={0},@ProductID={1},@UserName={2},@StockMovementMassID={3}",
                            customerID, productID, AppSetting.CurrentUser.LoginName, massID);
                        listStMassAll = new BindingList<ST_WMS_StockMovementMassAll_Result>((List<ST_WMS_StockMovementMassAll_Result>)stockMovementMassAllDA.Executing("ST_WMS_StockMovementMassAll").OrderBy(l => l.StockMovementMassID).ToList());
                    }
                    break;
            }
            bindingNavigatorMassAll.DataSource = listStMassAll;
            this.bindingNavigatorMassAll.Position = this.listStMassAll.Count - 1;
            if (gridViewStockMovementMass.RowCount > 0)
            {
                simpleButtonProcess.Enabled = false;
            }
        }
        private string CalculateAisle(LookUpEdit lookupEdit)
        {
            DataProcess<Aisles> aisleDA = new DataProcess<Aisles>();
            Aisles[] arrayAisle;
            string productID = lookupEdit.GetColumnValue("RoomID").ToString();
            arrayAisle = aisleDA.Select(a => a.RoomID == productID && a.StoreID == AppSetting.StoreID).ToArray();
            string stRoomID = "";
            foreach (var item in arrayAisle)
            {
                stRoomID += item.Aisle.ToString() + ",";
            }
            if (stRoomID != "")
                stRoomID = stRoomID.Substring(0, stRoomID.Length - 1);
            return stRoomID;

        }
        private void lookupEditValue_EditValueChanged(object sender, EventArgs e)
        {
            switch (lookupEditSelectBy.Text)
            {

                case "By Aisle":
                    if (lookupEditValue.EditValue != null)
                    {
                        memoEditMassInformation.Text = CalculateAisle(lookupEditValue);
                        textEditHigh.EditValue =0;
                        textEditTo.EditValue = 0;
                    }
                    break;
                case "RO":
                    if (lookupEditValue.EditValue != null)
                    {
                        memoEditMassInformation.Text = lookupEditValue.Text;
                    }
                    break;
                case "By Product":
                case "Many Product":
                    if (lookupEditValue.EditValue != null)
                    {
                        string product = lookupEditValue.GetColumnValue("Product").ToString();
                        string name = lookupEditValue.GetColumnValue("Name").ToString();
                        memoEditMassInformation.Text = product + name;
                    }
                    break;

            }
        }

        private void dataNavigatorStockMassAll_PositionChanged(object sender, EventArgs e)
        {

        }

        private void lookupEditRooms_EditValueChanged(object sender, EventArgs e)
        {
            //string id = Convert.ToString(this.lookupEditRooms.EditValue);
            //Common.Process.DataTransfer.WriteFileName(fileName, id);
            textEditAisle.Text = CalculateAisle(lookupEditRooms);
        }

        private void simpleButtonOnFloor_Click(object sender, EventArgs e)
        {
            if (gridViewStockMovementMass.RowCount > 0)
            {
                int result = 0;
                if (receivingOrderDetailID > 0)
                {
                    DataProcess<object> aisle = new DataProcess<object>();
                    result = aisle.ExecuteNoQuery("STPalletsAllocationFloor @varReceivingOrderDetailID={0},@HomeRoom1={1},@StoreID={2}", receivingOrderDetailID, lookupEditRooms.EditValue.ToString(), AppSetting.StoreID);
                }
                this.LoadPalletInfoByRODetailsID();
            }
        }

        private void simpleButtonAllocate_Click(object sender, EventArgs e)
        {
            var newradio1 = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Tag;
            var newradio2 = radioGroup2.Properties.Items[radioGroup2.SelectedIndex].Tag;
            if (gridViewStockMovementMass.RowCount > 0)
            {
                int result = 0;
                if (receivingOrderDetailID > 0)
                {
                    DataProcess<object> aisle = new DataProcess<object>();
                    result = aisle.ExecuteNoQuery("STPalletsAllocation @varReceivingOrderDetailID={0},@varLowHigh={1},@varFirstTop={2},@varCondition={3},@varJoinSmallPallet={4}", receivingOrderDetailID, Convert.ToInt32(newradio1), Convert.ToInt32(newradio2), "(" + textEditAisle.Text + ")", 0);
                }
            }
        }

        private void simpleButtonConfirm_Click(object sender, EventArgs e)
        {
            if (numberEmp < 1)
            {
                MessageBox.Show(" Please enter forklift driver/ labeller/ pallet truck !");
                return;
            }
            if (gridViewStockMovementMass.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to update the mass movement plan ?", "OK ?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataProcess<StockMovementMass> obj = new DataProcess<StockMovementMass>();
                    obj.ExecuteNoQuery("STStockMovementMassConfirmOrder @ReceivingOrderDetailID={0}, @User={1},@StockMovementMassNumber={2}", currentMassAll.ReceivingOrderDetailID, AppSetting.CurrentUser.LoginName, currentMassAll.StockMovementMassNumber);
                    var currentMassInfo = obj.Select(m => m.StockMovementMassID == currentMassAll.StockMovementMassID).FirstOrDefault();
                    currentMassAll.UserID = AppSetting.CurrentUser.LoginName;
                    currentMassAll.StockMovementMassConfirm = true;
                    if (currentMassInfo != null)
                    {
                        currentMassInfo.CustomerID = currentMassAll.CustomerID;
                        currentMassInfo.EmployeeID = currentMassAll.EmployeeID;
                        currentMassInfo.EmployeeID2 = currentMassAll.EmployeeID2;
                        currentMassInfo.EmployeeID3 = currentMassAll.EmployeeID3;
                        currentMassInfo.EndTime = currentMassAll.EndTime;
                        currentMassInfo.ReceivingOrderDetailID = currentMassAll.ReceivingOrderDetailID;
                        currentMassInfo.ReceivingOrderID = currentMassAll.ReceivingOrderID;
                        currentMassInfo.StartTime = currentMassAll.StartTime;
                        currentMassInfo.StockMovementMassConfirm = currentMassAll.StockMovementMassConfirm;
                        currentMassInfo.StockMovementMassDate = currentMassAll.StockMovementMassDate;
                        currentMassInfo.StockMovementMassID = currentMassAll.StockMovementMassID;
                        currentMassInfo.StockMovementMassInformation = currentMassAll.StockMovementMassInformation;
                        currentMassInfo.StockMovementMassNumber = currentMassAll.StockMovementMassNumber;
                        currentMassInfo.StockMovementMassRemark = currentMassAll.StockMovementMassRemark;
                        currentMassInfo.UserID = currentMassAll.UserID;
                        currentMassInfo.StockMovementMassNumber = currentMassAll.StockMovementMassNumber;
                    }

                    var stockMovementMassAl = obj.Update(currentMassInfo);
                    simpleButtonDecalAdvice.Focus();
                    this.labelControlUser.Text = AppSetting.CurrentUser.LoginName;
                }
            }

            //if (toggleConfirmed)
            //{


            //}

        }

        private void simpleButtonAdvice_Click(object sender, EventArgs e)
        {
            printAdvice(true);
        }
        private void printAdvice(bool isPreview)
        {
           // labelControlMassNumber.Text
            rptStockMovementMassAdvice rptMassAdvice = new rptStockMovementMassAdvice();
            DataTable vardata = FileProcess.LoadTable("STStockMovementMassAdvice @ReceivingOrderDetailID=" + currentMassAll.ReceivingOrderDetailID);
            int movementMassID = Convert.ToInt32(Convert.ToString(labelControlMassNumber.Text).Substring(3));
            var massMovement= "MM" + String.Format("{0:D9}", movementMassID); 
            if (vardata != null)
            {
                GroupHeaderBand ghBand = new GroupHeaderBand();
                rptMassAdvice.Bands.Add(ghBand);
                GroupField groupField = new GroupField("OldLabel");
                ghBand.GroupFields.Add(groupField);

                rptMassAdvice.DataSource = vardata;
                rptMassAdvice.RequestParameters = false;
                rptMassAdvice.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptMassAdvice.Parameters["bcMovementMassNumber"].Value = massMovement;
                rptMassAdvice.countItem.Text = vardata.Rows.Count.ToString();
                rptMassAdvice.SumTotal.Text = vardata.Compute("Sum(Total)", string.Empty).ToString();
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptMassAdvice);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }
            }
        }

        private void simpleButtonDecalAdvice_Click(object sender, EventArgs e)
        {
            printDecalLabel(true);
        }
        private void printDecalLabel(bool isPreview)
        {

            rptLabelDecal rptDecalLabel = new rptLabelDecal();
            var vardata = FileProcess.LoadTable("STStockMovementMassAdvice @ReceivingOrderDetailID=" + currentMassAll.ReceivingOrderDetailID);
            if (vardata != null)
            {
                rptDecalLabel.DataSource = vardata;
                rptDecalLabel.RequestParameters = false;
                // rptDecalLabel.bcPalletID.Text = vardata.Rows[0]["PalletID_Barcode"].ToString();
                rptDecalLabel.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptDecalLabel.xrLabelRO.Text = "RO" + currentMassAll.ReceivingOrderDetailID.ToString();
                rptDecalLabel.Parameters["parameter1"].Value = 4;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptDecalLabel);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }
            }


        }

        private void simpleButtonLabellA4_Click(object sender, EventArgs e)
        {
            printLabelA4(true);
        }

        private void printLabelA4(bool isPreview)
        {
            rptLabelA4Short_Barcode rptLabelA4Short_Barcode = new rptLabelA4Short_Barcode();
            DataTable vardata = FileProcess.LoadTable("STStockMovementMassAdvice @ReceivingOrderDetailID=" + currentMassAll.ReceivingOrderDetailID);
            if (vardata != null)
            {
                rptLabelA4Short_Barcode.DataSource = vardata;
                rptLabelA4Short_Barcode.RequestParameters = false;
                rptLabelA4Short_Barcode.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
                rptLabelA4Short_Barcode.Parameters["parameter1"].Value = 3;
                //  rptLabelA4Short_Barcode.bcPalletID.Text = "*" + vardata.Rows[0]["PalletID_Barcode"].ToString() + "*";
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptLabelA4Short_Barcode);
                printTool.AutoShowParametersPanel = false;
                if (isPreview)
                {
                    printTool.ShowPreview();
                }
                else
                {
                    printTool.Print();
                }

            }

        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            var newMassInfo = new ST_WMS_StockMovementMassAll_Result();
            newMassInfo.UserID = AppSetting.CurrentUser.LoginName;
            newMassInfo.StockMovementMassDate = DateTime.Now;
            newMassInfo.StartTime = DateTime.Now;
            this.listStMassAll.Add(newMassInfo);

            lookupEditCustomer.Enabled = true;
            lookupEditSelectBy.Enabled = true;
            lookupEditValue.Enabled = true;
            memoEditMassInformation.Enabled = true;
            simpleButtonProcess.Enabled = true;
            this.lookupEditSelectBy.EditValue = null;
            currentMassAll = (ST_WMS_StockMovementMassAll_Result)this.listStMassAll[bindingNavigatorMassAll.Position];
            currentMassAll.StockMovementMassID = listStMassAll.Max(r => r.StockMovementMassID) + 1;
            currentMassAll.StockMovementMassDate = Convert.ToDateTime(labelControlMassDate.Text);
            currentMassAll.StartTime = Convert.ToDateTime(textEditStart.DateTime);
            newtotalRow = this.listStMassAll.Count;
            gridControlStockMovementMass.DataSource = null;
            lookupEditSelectBy.Text = "";
            lookupEditValue.Text = "";
            bindingNavigatorMassAll.DataSource = this.listStMassAll;
            bindingNavigatorMassAll.Position = this.listStMassAll.Count - 1;
            this.gridViewStockMovementMass.RefreshData();
            this.lookupEditCustomer.Focus();
            this.lookupEditCustomer.ShowPopup();
        }

        private void labelControlCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void lookupEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookupEditCustomer.EditValue == null || Convert.ToInt32(this.lookupEditCustomer.EditValue) == 0) return;
            var customerName = FileProcess.LoadTable("select CustomerName from customers where customerid=" + Convert.ToInt32(this.lookupEditCustomer.EditValue)).Rows[0]["CustomerName"];
            labelControlCustomerName.Text = Convert.ToString(customerName);

        }

        private void gridViewStockMovementMass_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gridViewStockMovementMass.SetRowCellValue(e.RowHandle, "IsModified", 1);
        }

        private void xtraTabPageEmployees_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            labelControlUser.Text = AppSetting.CurrentUser.LoginName;
            labelControlMassDate.Text = DateTime.Now.ToShortDateString();
            textEditStart.Text = DateTime.Now.ToString();
            lookupEditCustomer.Enabled = true;
            lookupEditSelectBy.Enabled = true;
            lookupEditValue.Enabled = true;
            memoEditMassInformation.Enabled = true;
            simpleButtonProcess.Enabled = true;
            this.lookupEditSelectBy.EditValue = null;
            this.simpleButtonProcess.Enabled = true;
            this.bindingNavigatorMassAll.Position = listStMassAll.Count - 1;
            this.textEditStart.Text = DateTime.Now.ToString();
            this.gridControlStockMovementMass.DataSource = null;
            this.gridViewStockMovementMass.RefreshData();
            this.lookupEditCustomer.Focus();
            this.lookupEditCustomer.ShowPopup();

        }

        private void gridViewStockMovementMass_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.gridViewStockMovementMass.FocusedRowHandle < 0) return;
            if (this.gridViewStockMovementMass.SelectedRowsCount <= 0) return;
            var dl = MessageBox.Show("Do you want to delete this record?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.No)) return;
            foreach (int index in gridViewStockMovementMass.GetSelectedRows())
            {
                int palletID = Convert.ToInt32(this.gridViewStockMovementMass.GetRowCellValue(index, "PalletID"));
                int resultDelete = this.stockMovementMassAllDA.ExecuteNoQuery("Delete Pallets Where PalletID=" +
                    palletID);
            }

            this.LoadPalletInfoByRODetailsID();
        }

        private void LoadPalletInfoByRODetailsID()
        {
            gridControlStockMovementMass.DataSource = FileProcess.LoadTable("ST_WMS_LoadStockMovementMassDetails " + receivingOrderDetailID);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            bindingNavigatorAddNewItem1_Click(sender, e);
        }

        private void lookupEditCustomer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lookupEditSelectBy.ShowPopup();
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            bindingNavigatorAddNewItem1_Click(sender, e);
        }

        private void hle_PalletID_Click(object sender, EventArgs e)
        {

            //frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.gridViewlLocationInfo_Details.GetFocusedRowCellValue("RealPalletID")), 0, true);
            int realPalletID = Convert.ToInt32(this.gridViewStockMovementMass.GetFocusedRowCellValue("RealPalletID"));
            frm_WM_Dialog_LocationDetail frm = new frm_WM_Dialog_LocationDetail(realPalletID, 0, true);
            frm.Show();
            frm.BringToFront();
        }

        private void frm_ST_StockMovementMassAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.Modal)
                {
                    return;
                }

                FormCollection openforms = Application.OpenForms;
                bool isOpen = false;
                foreach (Form frms in openforms)
                {
                    if (frms.Name == "frmScanInput")
                    {
                        frms.BringToFront();
                        isOpen = true;
                    }

                }
                if (!isOpen)
                {
                    UI.Helper.frmScanInput inputDialog = new frmScanInput();
                    inputDialog.Show();
                    inputDialog.BringToFront();
                }
            }
        }
    }
}
