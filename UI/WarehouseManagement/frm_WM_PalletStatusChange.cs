using Common.Controls;
using DA;
using DA.Management;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;
using UI.WarehouseManagement;

namespace UI.Management
{
    public partial class frm_WM_PalletStatusChange : frmBaseForm
    {
        private int PalletStatusChangeOrderFind = -1;
        private List<PalletStatusChanges> PalletStatusChangeList;
        //private PalletStatu palletSatus;
        private PalletStatusChanges currentPalletStatusChange;
        private PalletStatusChanges saveCurrentPalletStatusChange;
        //private List<PalletStatusChangeDetails> PalletStatusChangeDetailList;
        private urc_WM_OtherService otherService = null;
        DataProcess<Customers> daCustomer = new DataProcess<Customers>();
        private bool isCreateNew = false;
        private IDictionary<Control, bool> validateList = new Dictionary<Control, bool>();
        private int customerID;

        public frm_WM_PalletStatusChange()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Init();
            initChangeAllTo();
        }

        public int PalletStatusChangeIDFind
        {
            get { return PalletStatusChangeOrderFind; }
            set
            {
                PalletStatusChangeOrderFind = value;
                this.Init();
            }
        }
        private void Init()
        {
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int customerCount = AppSetting.CustomerList.Count();
            if (customerCount > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = customerCount;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";

            rpe_lke_NewStatus.DataSource = FileProcess.LoadTable("SELECT PalletStatus, CAST(PalletStatus AS varchar(2)) + ' | ' + PalletStatusDescription + '-' + PalletStatusDescriptionVietnam AS PalletStatusDescription, IsHold FROM PalletStatus");
            rpe_lke_NewStatus.DropDownRows = 17;
            rpe_lke_NewStatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            rpe_lke_NewStatus.DisplayMember = "PalletStatusDescription";
            rpe_lke_NewStatus.ValueMember = "PalletStatus";


            DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();

            try
            {
                this.PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
                dtngPalletStatusChange.DataSource = PalletStatusChangeList;

                int position = PalletStatusChangeList.Count - 1;
                if (this.PalletStatusChangeOrderFind > 0)
                {
                    for (int i = 0; i < PalletStatusChangeList.Count; i++)
                    {
                        if (PalletStatusChangeList.ElementAt(i).PalletStatusChangeID == PalletStatusChangeOrderFind)
                        {
                            position = i;
                            break;
                        }

                    }
                }


                if (dtngPalletStatusChange.Position == position)
                {
                    currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                    saveCurrentPalletStatusChange = currentPalletStatusChange;
                    UpdateControlsBy(currentPalletStatusChange);
                    UpdateControlStatus();
                }
                else
                {
                    dtngPalletStatusChange.Position = position;
                }
                this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails " + this.PalletStatusChangeList.ElementAt(position).PalletStatusChangeID);
            }
            catch
            {

            }
            if (txtPalletStatusChangeRecordNumber.Text == "SC-New*")
            {
                isCreateNew = true;
            }

            try
            {
                customerID = currentPalletStatusChange.CustomerID;
            }
            catch
            {

            }


        }

        private void initChangeAllTo()
        {
            //DataProcess<PalletStatu> v_da = new DataProcess<PalletStatu>();
            //IList<PalletStatu> v_List = v_da.Select().OrderBy(c => c.PalletStatus).ToList();
            DataTable v_List = FileProcess.LoadTable("STPalletStatusByCustomerList " + this.customerID);

            lke_NewPalletStatus.Properties.DataSource = v_List;
            //lke_NewPalletStatus.Properties.DropDownRows = v_List.Count;
            lke_NewPalletStatus.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lke_NewPalletStatus.Properties.DisplayMember = "PalletStatusDescription";
            lke_NewPalletStatus.Properties.ValueMember = "PalletStatus";

            this.layoutControlChangeAllTo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;


        }

        private void loadCustomerList()
        {
            //this.grcChoosePallet.DataSource = FileProcess.LoadTable("ST_WMS_PalletStatusChangeByRequestTreeListProducts " + this.lkeCustomerNumber.EditValue);

            if (lkeCustomerNumber.EditValue != null && lkeCustomerNumber.GetColumnValue("CustomerName") != null
                && lkeCustomerNumber.GetColumnValue("CustomerID") != null)
            {
                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();
            }

            textPCCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            dePalletStatusChangeDate.EditValue = DateTime.Now;

            if (isCreateNew)
            {
                PalletStatusChanges newPC = new PalletStatusChanges()
                {
                    PalletStatusChangeID = 0,
                    PalletStatusChangeDate = dePalletStatusChangeDate.DateTime,
                    CustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID")),
                    CreatedBy = textPCCreatedBy.EditValue.ToString(),
                };
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("INSERT INTO PalletStatusChanges (PalletStatusChangeDate, CreatedTime, CreatedBy, CustomerID)" +
                    " VALUES ('{0}', getdate() , '{1}', {2})",
                    newPC.PalletStatusChangeDate.ToString("yyyy-MM-dd"),
                    AppSetting.CurrentUser.LoginName,
                    newPC.CustomerID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);

                //int resultInsert = PalletStatusChangeDA.Insert(newPC);
                if (resultInsert > 0)
                {
                    isCreateNew = false;

                    //Loại lại dữ liệu cho form
                    PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();

                    dtngPalletStatusChange.DataSource = PalletStatusChangeList;
                    //dtngPalletStatusChange.Position = PalletStatusChangeList.Count - 1 ;
                    if (dtngPalletStatusChange.Position == PalletStatusChangeList.Count - 1)
                    {
                        currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                        saveCurrentPalletStatusChange = currentPalletStatusChange;
                        UpdateControlsBy(currentPalletStatusChange);
                        UpdateControlStatus();
                    }
                    else
                    {
                        dtngPalletStatusChange.Position = PalletStatusChangeList.Count - 1;
                    }
                    MessageBox.Show("Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Creating new product checking is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("Update PalletStatusChanges Set PalletStatusChangeDate = '{0}', CustomerID = {1}," +
                    " PalletStatusChangeRemark = N'{2}' " +
                    " Where PalletStatusChangeID = {3}",
                    dePalletStatusChangeDate.DateTime.ToString("yyyy-MM-dd"),
                    Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID")),
                    this.meRemark.Text.ToString(),
                    currentPalletStatusChange.PalletStatusChangeID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);
                PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
                int savePosition = dtngPalletStatusChange.Position;
                dtngPalletStatusChange.DataSource = PalletStatusChangeList;
                dtngPalletStatusChange.Position = savePosition;
            }
        }

        private void lkeCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            //loadCustomerList();
        }

        private void dtngPalletStatusChange_PositionChanged(object sender, EventArgs e)
        {
            currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
            saveCurrentPalletStatusChange = currentPalletStatusChange;
            UpdateControlsBy(currentPalletStatusChange);
            UpdateControlStatus();
            otherService = null;
        }

        private void UpdateControlsBy(PalletStatusChanges yourcurrentPalletStatusChange)
        {
            currentPalletStatusChange = yourcurrentPalletStatusChange;

            txtPalletStatusChangeRecordNumber.EditValue = currentPalletStatusChange.PalletStatusChangeNumber;


            Customers selectedCustomer = ((List<Customers>)lkeCustomerNumber.Properties.DataSource).Where(c => c.CustomerID == currentPalletStatusChange.CustomerID).SingleOrDefault();
            if (selectedCustomer != null)
            {
                lkeCustomerNumber.EditValue = selectedCustomer.CustomerID;
                txtCustomerName.EditValue = selectedCustomer.CustomerName;
            }
            else
            {
                lkeCustomerNumber.EditValue = "";
            }

            txt_AuthorisedBy.EditValue = currentPalletStatusChange.AuthorisedBy;
            textPCCreatedBy.EditValue = currentPalletStatusChange.CreatedBy;
            textPCCreatedTime.EditValue = currentPalletStatusChange.CreatedTime;
            this.meRemark.EditValue = currentPalletStatusChange.PalletStatusChangeRemark;
            this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails "
                + this.currentPalletStatusChange.PalletStatusChangeID);
            txtConfirmedBy.EditValue = currentPalletStatusChange.ConfirmedBy;
            txtConfirmedTime.EditValue = currentPalletStatusChange.ConfirmedTime;
            dePalletStatusChangeDate.EditValue = currentPalletStatusChange.PalletStatusChangeDate;
            textRequestedBatchNumber.EditValue = currentPalletStatusChange.RequestedBatchNumber;
            textRequestedUsedByDate.EditValue = currentPalletStatusChange.RequestedUsedByDate;
            textCustomerOrderNumber.EditValue = currentPalletStatusChange.CustomerOrderNumber;
            textRequestFromLoc.EditValue = currentPalletStatusChange.RequestedOldStatus;
            textRequestToLoc.EditValue = currentPalletStatusChange.RequestedNewStatus;
            textEDIMessageSentTime.EditValue = currentPalletStatusChange.EDIMessageSentTime;
            textRequestedProductNumber.EditValue = currentPalletStatusChange.RequestedProductNumber;
            textRequestedProductName.EditValue = currentPalletStatusChange.RequestedProductName;
            textRequestedQuantity.EditValue = currentPalletStatusChange.RequestedQuantity;


            if (currentPalletStatusChange.ConfirmedBy == null)
                this.btn_Confirm_PalletStatusChange.Enabled = true;
            else
                this.btn_Confirm_PalletStatusChange.Enabled = false;
            UpdateControlStatus();

        }

        private void UpdateControlStatus()
        {

            if (btn_Confirm_PalletStatusChange.Enabled == true)
            {
                lkeCustomerNumber.Enabled = true;
                txtCustomerName.Enabled = true;
                dePalletStatusChangeDate.Enabled = true;
                btn_AddNewPallets.Enabled = true;
                btn_Confirm_PalletStatusChange.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                btn_Confirm_PalletStatusChange.Appearance.Options.UseBackColor = true;
                this.grvPalletStatusChange.OptionsBehavior.ReadOnly = false;
                this.rpe_lke_NewStatus.ReadOnly = false;
                this.lke_NewPalletStatus.Enabled = true;
            }
            else
            {
                lkeCustomerNumber.Enabled = false;
                txtCustomerName.Enabled = false;
                dePalletStatusChangeDate.Enabled = false;
                btn_AddNewPallets.Enabled = false;
                btn_Confirm_PalletStatusChange.Appearance.BackColor = Color.DarkGray;
                btn_Confirm_PalletStatusChange.Appearance.Options.UseBackColor = true;
                this.grvPalletStatusChange.OptionsBehavior.ReadOnly = true;
                this.rpe_lke_NewStatus.ReadOnly = true;
                this.lke_NewPalletStatus.Enabled = false;
            }

            if (this.grvPalletStatusChange.DataRowCount > 0)
                this.lkeCustomerNumber.Enabled = false;


        }


        private void dtngPalletStatusChange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngPalletStatusChange.Position = dtngPalletStatusChange.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngPalletStatusChange.Position = dtngPalletStatusChange.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngPalletStatusChange.Position = 0;
            else if (e.KeyData == Keys.Down)
                dtngPalletStatusChange.Position = ((IList<PalletStatusChanges>)dtngPalletStatusChange.DataSource).Count - 1;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            rptPalletStatusChangeNote rpt = new rptPalletStatusChangeNote();
            rpt.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeNote " + this.currentPalletStatusChange.PalletStatusChangeID);
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_M_PalletStatusChangeByRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (this.txtPalletStatusChangeRecordNumber.Text.ToString().Equals("SC-New*"))
                {
                    return;
                }
                else
                {
                    frm_WM_Attachments.Instance.OrderNumber = this.txtPalletStatusChangeRecordNumber.Text;
                    frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
                    if (!frm_WM_Attachments.Instance.Enabled) return;
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.F12)
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
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (this.txtPalletStatusChangeRecordNumber.Text.ToString().Equals("SC-New*"))
            {
                return base.ProcessDialogKey(keyData);
            }
            else
            {
                string CustomerNumber = txtPalletStatusChangeRecordNumber.Text;
                Int16 CustomerID = Convert.ToInt16(this.lkeCustomerNumber.EditValue);
                if (keyData == Keys.F3)
                {
                    frm_WM_Attachments.Instance.OrderNumber = CustomerNumber;
                    frm_WM_Attachments.Instance.CustomerID = CustomerID;
                    if (frm_WM_Attachments.Instance.Enabled) frm_WM_Attachments.Instance.ShowDialog();
                    this.Init();
                }
                return base.ProcessDialogKey(keyData);
            }
        }


        private void grvPalletStatusChange_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals("PalletStatusChangeDetailRemark") || e.Column.FieldName.Equals("NewStatus"))
            {
                string strRemark = Convert.ToString(this.grvPalletStatusChange.GetRowCellValue(e.RowHandle, "PalletStatusChangeDetailRemark"));
                string strNewStatus = this.grvPalletStatusChange.GetRowCellValue(e.RowHandle, "NewStatus").ToString();
                string strPCDID = this.grvPalletStatusChange.GetRowCellValue(e.RowHandle, "PalletStatusChangeDetailID").ToString();
                DataProcess<object> dataProcess = new DataProcess<object>();
                string strSQL = "Update PalletStatusChangeDetails set PalletStatusChangeDetailRemark = N'" + strRemark + "', NewStatus = " + strNewStatus + " where PalletStatusChangeDetailID = " + strPCDID;
                dataProcess.ExecuteNoQuery(strSQL);
            }
        }



        private void BtnWmNewPC_Click(object sender, EventArgs e)
        {
            txtPalletStatusChangeRecordNumber.EditValue = null;
            txtCustomerName.EditValue = null;
            dePalletStatusChangeDate.EditValue = DateTime.Now;
            textPCCreatedBy.EditValue = AppSetting.CurrentUser.LoginName;
            meRemark.EditValue = "";
            textPCCreatedTime.EditValue = DateTime.Now;
            txtConfirmedBy.EditValue = "";
            txtConfirmedTime.EditValue = "";

            grdPalletStatusChange.DataSource = null;
            grvPalletStatusChange.RefreshData();
            lkeCustomerNumber.Enabled = true;
            txtCustomerName.Enabled = true;
            dePalletStatusChangeDate.Enabled = true;
            isCreateNew = true;
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void frm_M_PalletStatusChangeByRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentPalletStatusChange != null)
            {
                this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails "
                                + this.currentPalletStatusChange.PalletStatusChangeID);
            }

        }

        private void btn_Confirm_PalletStatusChange_Click(object sender, EventArgs e)
        {
            DataProcess<object> dataProcess = new DataProcess<object>();
            //dataProcess.ExecuteNoQuery("Update PalletStatusChanges Set ConfirmedBy ='" + AppSetting.CurrentUser.LoginName + "', " +
            //    "ConfirmedTime = GETDATE() Where PalletStatusChangeID= "+currentPalletStatusChange.PalletStatusChangeID);
            // Validate confirm status
            var tableCheck = FileProcess.LoadTable("EXEC STCheckPalletStatusChangeConfirm " + currentPalletStatusChange.PalletStatusChangeID + ",'" + AppSetting.CurrentUser.LoginName + "'," + this.checkNotSendEDI.Checked);
            if (tableCheck != null || tableCheck.Rows.Count > 0)
            {
                int count = Convert.ToInt32(tableCheck.Rows[0]["PalletCount"]);
                if(count>1)
                {
                    MessageBox.Show("There are more old Customer Status!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //EXECUTE the Pallet Status Change for all the Pallets included in the Order
            dataProcess.ExecuteNoQuery("EXEC STPalletStatusChangeConfirm " + currentPalletStatusChange.PalletStatusChangeID + ",'" + AppSetting.CurrentUser.LoginName + "'," + this.checkNotSendEDI.Checked);


            reloadDataListPC(dtngPalletStatusChange.Position);
        }

        private void btn_UpdatePC_Click(object sender, EventArgs e)
        {
            if (isCreateNew)
            {
                PalletStatusChanges newPC = new PalletStatusChanges()
                {
                    PalletStatusChangeID = 0,
                    PalletStatusChangeDate = dePalletStatusChangeDate.DateTime,
                    CustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID")),
                    CreatedBy = textPCCreatedBy.EditValue.ToString(),
                };
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("INSERT INTO PalletStatusChanges (PalletStatusChangeDate, CreatedTime, CreatedBy, CustomerID)" +
                    " VALUES ('{0}', getdate() , '{1}', {2})",
                    newPC.PalletStatusChangeDate.ToString("yyyy-MM-dd"),
                    AppSetting.CurrentUser.LoginName,
                    newPC.CustomerID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);

                //int resultInsert = PalletStatusChangeDA.Insert(newPC);
                if (resultInsert > 0)
                {
                    isCreateNew = false;

                    //Loại lại dữ liệu cho form
                    PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();

                    dtngPalletStatusChange.DataSource = PalletStatusChangeList;
                    //dtngPalletStatusChange.Position = PalletStatusChangeList.Count - 1;
                    if (dtngPalletStatusChange.Position == PalletStatusChangeList.Count - 1)
                    {
                        currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                        saveCurrentPalletStatusChange = currentPalletStatusChange;
                        UpdateControlsBy(currentPalletStatusChange);
                        UpdateControlStatus();
                    }
                    else
                    {
                        dtngPalletStatusChange.Position = PalletStatusChangeList.Count - 1;
                    }
                    MessageBox.Show("Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Creating new product checking is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("Update PalletStatusChanges Set PalletStatusChangeDate = '{0}', CustomerID = {1}," +
                    " PalletStatusChangeRemark = N'{2}' " +
                    " Where PalletStatusChangeID = {3}",
                    dePalletStatusChangeDate.DateTime.ToString("yyyy-MM-dd"),
                    Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID")),
                    this.meRemark.Text.ToString(),
                    currentPalletStatusChange.PalletStatusChangeID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);
                PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
                int savePosition = dtngPalletStatusChange.Position;
                dtngPalletStatusChange.DataSource = PalletStatusChangeList;
                dtngPalletStatusChange.Position = savePosition;
                MessageBox.Show("Data updated Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            reloadDataListPC(dtngPalletStatusChange.Position);
        }

        public void reloadDataListPC(int position)
        {
            DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
            //DateTime comparedTimeValue = DateTime.Now.AddDays(-31);
            PalletStatusChangeList = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.* FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeDate > GETDATE() - 31 and StoreID= "
                                        + (int)AppSetting.CurrentUser.StoreID).ToList();
            //PalletStatusChangesDA.Update(PalletStatusChangeList);
            dtngPalletStatusChange.DataSource = PalletStatusChangeList;
            //dtngPalletStatusChange.Position = position;
            if (position > -1)
            {
                if (dtngPalletStatusChange.Position == position)
                {
                    currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                    saveCurrentPalletStatusChange = currentPalletStatusChange;
                    UpdateControlsBy(currentPalletStatusChange);
                    UpdateControlStatus();
                }
                else
                {
                    dtngPalletStatusChange.Position = position;
                }
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.grvPalletStatusChange.DataRowCount > 0)
            {
                XtraMessageBox.Show("Please Delete all Pallets !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dl = MessageBox.Show("Are you sure to delete this order?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                if (currentPalletStatusChange != null)
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    dataProcess.ExecuteNoQuery("DELETE FROM PalletStatusChanges WHERE PalletStatusChangeID = " + currentPalletStatusChange.PalletStatusChangeID);
                }


                if (this.PalletStatusChangeList.Count > 0)
                {
                    if (this.PalletStatusChangeList.Count == 1)
                    {
                        isCreateNew = true;
                    }
                    reloadDataListPC(PalletStatusChangeList.Count - 2);
                }
                else
                {

                }
            }
        }

        private void grvPalletStatusChange_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    bool isDelete = false;
            //    //int result = -1;
            //    int[] selectRows = this.grvPalletStatusChange.GetSelectedRows();
            //    if (selectRows.Count() <= 0) return;

            //    if (XtraMessageBox.Show("Are you sure to delete pallets ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }

            //    DataProcess<object> dataProcess = new DataProcess<object>();
            //    for (int i = 0; i < selectRows.Count(); ++i)
            //    {
            //        int id = Convert.ToInt32(this.grvPalletStatusChange.GetRowCellValue(selectRows[i], "PalletStatusChangeDetailID"));
            //        dataProcess.ExecuteNoQuery("DELETE FROM PalletStatusChangeDetails WHERE PalletStatusChangeDetailID = " + id);
            //        isDelete = true;

            //    }

            //    if (isDelete)
            //    {
            //        this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_PalletStatusChangeByRequestDetails "
            //            + this.currentPalletStatusChange.PalletStatusChangeID);
            //        grvPalletStatusChange.RefreshData();
            //    }
            //}
        }

        private void meRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (currentPalletStatusChange != null)
            {
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("Update PalletStatusChanges Set  PalletStatusChangeRemark = N'{0}' " +
                    " Where PalletStatusChangeID = {1}",
                    this.meRemark.Text.ToString(),
                    currentPalletStatusChange.PalletStatusChangeID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);
                var datasource = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeID = "
                                        + currentPalletStatusChange.PalletStatusChangeID).ToList();
                if (datasource.Count > 0)
                {
                    currentPalletStatusChange = datasource.ElementAt(0);
                }

            }

        }

        private void btn_AddNewPallets_Click(object sender, EventArgs e)
        {

            //Sử dụng chung form frm_M_ProductCheckingByRequestDetail, tuy nhiên sẽ phải truyển vào OrderType để khi Insert thì vào trong bảng PalletStatusChangeDetails
            // OK ạ
            if (this.textCustomerOrderNumber.Text.Length > 0)
            {
                frm_M_ProductCheckingByRequestDetail frm = new frm_M_ProductCheckingByRequestDetail(currentPalletStatusChange.CustomerID, currentPalletStatusChange.PalletStatusChangeID, 1,
                    textCustomerOrderNumber.Text, textRequestFromLoc.Text, textRequestedBatchNumber.Text, textRequestedProductNumber.Text, textRequestedUsedByDate.Text, textRequestedQuantity.Text
                    , textRequestToLoc.Text);
                frm.FormClosing += new FormClosingEventHandler(this.frm_M_PalletStatusChangeByRequest_FormClosing);
                frm.ShowDialog();
            }
            else
            {
                frm_M_ProductCheckingByRequestDetail frm = new frm_M_ProductCheckingByRequestDetail(currentPalletStatusChange.CustomerID, currentPalletStatusChange.PalletStatusChangeID, 1);
                frm.FormClosing += new FormClosingEventHandler(this.frm_M_PalletStatusChangeByRequest_FormClosing);
                frm.ShowDialog();
            }

            //frm.ShowDialog();

            //frm_M_ProductCheckingByRequestDetail frm = new frm_M_ProductCheckingByRequestDetail(Convert.ToInt32(this.lkeCustomerNumber.EditValue), this.currentProductChecking.ProductCheckingID);

        }

        private void grdPalletStatusChange_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                bool isDelete = false;
                //int result = -1;
                if (this.currentPalletStatusChange.ConfirmedBy != null)
                {
                    MessageBox.Show("Can not Delete Confirmed Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int[] selectRows = this.grvPalletStatusChange.GetSelectedRows();
                if (selectRows.Count() <= 0) return;

                if (XtraMessageBox.Show("Are you sure to delete pallets ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                DataProcess<object> dataProcess = new DataProcess<object>();
                for (int i = 0; i < selectRows.Count(); ++i)
                {
                    int id = Convert.ToInt32(this.grvPalletStatusChange.GetRowCellValue(selectRows[i], "PalletStatusChangeDetailID"));
                    dataProcess.ExecuteNoQuery("DELETE FROM PalletStatusChangeDetails WHERE PalletStatusChangeDetailID = " + id);
                    isDelete = true;
                }

                if (isDelete)
                {
                    this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails "
                        + this.currentPalletStatusChange.PalletStatusChangeID);
                    grvPalletStatusChange.RefreshData();
                }
            }
        }

        private void dePalletStatusChangeDate_EditValueChanged(object sender, EventArgs e)
        {
            if (currentPalletStatusChange != null)
            {
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("Update PalletStatusChanges Set  PalletStatusChangeDate = '{0}' " +
                    " Where PalletStatusChangeID = {1}",
                    dePalletStatusChangeDate.DateTime.ToString("yyyy-MM-dd"),
                    currentPalletStatusChange.PalletStatusChangeID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);
                var datasource = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeID = "
                                        + currentPalletStatusChange.PalletStatusChangeID).ToList();
                if (datasource.Count > 0)
                {
                    currentPalletStatusChange = datasource.ElementAt(0);
                }

            }

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (currentPalletStatusChange != null)
            {
                DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();
                string sql = String.Format("Update PalletStatusChanges Set  AuthorisedBy = N'{0}' " +
                    " Where PalletStatusChangeID = {1}",
                    txt_AuthorisedBy.Text.ToString(),
                    currentPalletStatusChange.PalletStatusChangeID
                    );
                int resultInsert = PalletStatusChangeDA.ExecuteNoQuery(sql);
                var datasource = PalletStatusChangeDA.Executing("SELECT PalletStatusChanges.*,StoreID FROM dbo.PalletStatusChanges Left JOIN Customers ON PalletStatusChanges.CustomerID=Customers.CustomerID WHERE PalletStatusChangeID = "
                                        + currentPalletStatusChange.PalletStatusChangeID).ToList();
                if (datasource.Count > 0)
                {
                    currentPalletStatusChange = datasource.ElementAt(0);
                }

            }


        }

        private void lkeCustomerNumber_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            loadCustomerList();
            this.customerID = currentPalletStatusChange.CustomerID;
            initChangeAllTo();
        }

        private void rpe_hle_ProductID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(this.grvPalletStatusChange.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.MasterSystemSetup.frm_MSS_Products frm = MasterSystemSetup.frm_MSS_Products.Instance;
            frm.ProductIDLookup = v_ProductID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void rpe_hle_PalletID_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(this.lkeCustomerNumber.EditValue);
            }
            catch { }

            try
            {
                v_ProductID = Convert.ToInt32(this.grvPalletStatusChange.GetFocusedRowCellValue("ProductID"));
            }
            catch { }

            UI.WarehouseManagement.frm_WM_PalletInfo frm = new UI.WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show(this);
        }

        private void rpe_hle_ReceivingOrderID_Click(object sender, EventArgs e)
        {
            int v_ReceivingOrderID = 0;

            try
            {
                v_ReceivingOrderID = Convert.ToInt32(this.grvPalletStatusChange.GetFocusedRowCellValue("ReceivingOrderID"));
            }
            catch { }

            WarehouseManagement.frm_WM_ReceivingOrders frm = frm_WM_ReceivingOrders.Instance;
            frm.ReceivingOrderIDFind = v_ReceivingOrderID;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.Show();
        }

        private void btn_PrintLabels_Click(object sender, EventArgs e)
        {
            DataProcess<STLabel1RO_Result> multilabel = new DataProcess<STLabel1RO_Result>();
            rptLabelA4Short_Barcode lb = new rptLabelA4Short_Barcode();
            lb.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            lb.Parameters["parameter1"].Value = 3;
            lb.DataSource = multilabel.Executing("STLabelPalletStatusChange @PalletStatusChangeID={0}", currentPalletStatusChange.PalletStatusChangeID);
            lb.RequestParameters = false;

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btn_PrintList_Click(object sender, EventArgs e)
        {
            rptProductCheckingByPalletStatusChange rpt = new rptProductCheckingByPalletStatusChange();
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rpt.DataSource = FileProcess.LoadTable("ST_WMS_PalletStatusChangePrintReport " + this.currentPalletStatusChange.PalletStatusChangeID);
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void dockPanelService_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            string orderNumber = this.txtPalletStatusChangeRecordNumber.Text;
            if (this.otherService == null)
            {
                this.otherService = new urc_WM_OtherService(orderNumber);
                this.otherService.Parent = this.dockPanelService;
            }
            else
            {
                this.otherService.InitData(orderNumber);
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            var newPSC = FileProcess.LoadTable("STPalletStatusChangeDuplicate " + this.currentPalletStatusChange.PalletStatusChangeID + ",'" + AppSetting.CurrentUser.LoginName + "'");
            if (newPSC != null)
            {
                //int nPSID = Convert.ToInt32(newPSC.Rows[0]["NewPalletStatusChangeID"]);
                Init();

            }
            else
                MessageBox.Show("Error Duplicating New Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lke_NewPalletStatus_EditValueChanged(object sender, EventArgs e)
        {
            var newPSC = FileProcess.LoadTable("STPalletStatusChangeUpdateAll " + this.currentPalletStatusChange.PalletStatusChangeID + "," + this.lke_NewPalletStatus.EditValue + ",'" + AppSetting.CurrentUser.LoginName + "'");
            if (newPSC != null)
            {
                //int nPSID = Convert.ToInt32(newPSC.Rows[0]["NewPalletStatusChangeID"]);
                Init();

            }
            else
                MessageBox.Show("Error Edit New Pallet Status!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExportDO_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Export DO ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string cellValues = "";
            int[] selectedRows = this.grvPalletStatusChange.GetSelectedRows();
            foreach (int rowHandle in selectedRows)
            {
                if (rowHandle >= 0)
                {
                    if (cellValues.Length > 0)
                        cellValues = cellValues + " , " + grvPalletStatusChange.GetRowCellValue(rowHandle, "PalletStatusChangeDetailID").ToString();
                    else
                        cellValues = grvPalletStatusChange.GetRowCellValue(rowHandle, "PalletStatusChangeDetailID").ToString();
                }
            }

            if (cellValues == "") return;

            int DO_ID = 0;
            using (var context = new SwireDBEntities())
            {
                using (var connection = context.Database.Connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "STPalletStatusChangeExportDO";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramstrPalletStatusChangeID = new SqlParameter("@strPalletStatusChangeID", SqlDbType.VarChar, 5000);
                        paramstrPalletStatusChangeID.Value = cellValues;
                        command.Parameters.Add(paramstrPalletStatusChangeID);

                        SqlParameter paramCurrentUSer = new SqlParameter("@CurrentUSer", SqlDbType.VarChar, 50);
                        paramCurrentUSer.Value = AppSetting.CurrentUser.LoginName.ToString();
                        command.Parameters.Add(paramCurrentUSer);

                        SqlParameter varDispatchingOrderID = new SqlParameter("@varDispatchingOrderID", SqlDbType.Int);
                        varDispatchingOrderID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(varDispatchingOrderID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        DO_ID = Convert.ToInt32(command.Parameters["@varDispatchingOrderID"].Value);
                        connection.Close();
                    }
                }

            }
            if (DO_ID != 0)
            {
                frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(DO_ID);
                if (dispatchingOrder.Visible)
                {
                    dispatchingOrder.ReloadData();
                }
                dispatchingOrder.Show();
                dispatchingOrder.WindowState = FormWindowState.Maximized;
                dispatchingOrder.BringToFront();
            }
            else
                MessageBox.Show("Export DO is failed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textFindByPalletID_EditValueChanged(object sender, EventArgs e)
        {
            // code here to find the PSC for the palletID User wants to find
            DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();

            try
            {
                this.PalletStatusChangeList = PalletStatusChangeDA.Executing("STPalletStatusChangeFindPalletID " + AppSetting.StoreID + "," + this.textFindByPalletID.EditValue).ToList();
                dtngPalletStatusChange.DataSource = PalletStatusChangeList;

                int position = PalletStatusChangeList.Count - 1;
                if (this.PalletStatusChangeOrderFind > 0)
                {
                    for (int i = 0; i < PalletStatusChangeList.Count; i++)
                    {
                        if (PalletStatusChangeList.ElementAt(i).PalletStatusChangeID == PalletStatusChangeOrderFind)
                        {
                            position = i;
                            break;
                        }

                    }
                }


                if (dtngPalletStatusChange.Position == position)
                {
                    currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                    saveCurrentPalletStatusChange = currentPalletStatusChange;
                    UpdateControlsBy(currentPalletStatusChange);
                    UpdateControlStatus();
                }
                else
                {
                    dtngPalletStatusChange.Position = position;
                }
                this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails " + this.PalletStatusChangeList.ElementAt(position).PalletStatusChangeID);
            }
            catch
            {

            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // code here to find the PSC for the palletID User wants to find
            DataProcess<PalletStatusChanges> PalletStatusChangeDA = new DataProcess<PalletStatusChanges>();

            try
            {
                this.PalletStatusChangeList = PalletStatusChangeDA.Executing("STPalletStatusChangeFindPalletID " + AppSetting.StoreID + "," + this.textFindByPalletID.EditValue).ToList();
                dtngPalletStatusChange.DataSource = PalletStatusChangeList;

                int position = PalletStatusChangeList.Count - 1;
                if (this.PalletStatusChangeOrderFind > 0)
                {
                    for (int i = 0; i < PalletStatusChangeList.Count; i++)
                    {
                        if (PalletStatusChangeList.ElementAt(i).PalletStatusChangeID == PalletStatusChangeOrderFind)
                        {
                            position = i;
                            break;
                        }

                    }
                }


                if (dtngPalletStatusChange.Position == position)
                {
                    currentPalletStatusChange = PalletStatusChangeList.ElementAt(dtngPalletStatusChange.Position);
                    saveCurrentPalletStatusChange = currentPalletStatusChange;
                    UpdateControlsBy(currentPalletStatusChange);
                    UpdateControlStatus();
                }
                else
                {
                    dtngPalletStatusChange.Position = position;
                }
                this.grdPalletStatusChange.DataSource = FileProcess.LoadTable("ST_WMS_LoadPalletStatusChangeDetails " + this.PalletStatusChangeList.ElementAt(position).PalletStatusChangeID);
            }
            catch
            {

            }
        }
    }
}
