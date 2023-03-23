using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_EmployeeInfo : UserControl
    {
        private DataProcess<EmployeeWorkings> employeeWorkingDA = new DataProcess<EmployeeWorkings>();
        private BindingList<STEmployeeWorkingView_Result> listEmployeeWorking = new BindingList<STEmployeeWorkingView_Result>();
        private string orderNumber = string.Empty;
        private bool _isNew;
        private bool _isInitEmployee;
        private bool _isPercentageUpdated;
        private bool _isQuantityUpdated;
        private decimal _totalPallets;
        private decimal _totalWeight;
        private decimal _totalCartons;
        private decimal _totalWeightDB;
        private int percenPalletCheck = 0;
        private int percenPalletPuted = 0;
        public int countEmp
        {
            get
            {
                return this.grvEmployeeWorking.RowCount;
            }
        }

        public urc_WM_EmployeeInfo(string receivingOrderNumberSelected, decimal totalPallets, decimal totalWeight, decimal totalCartons)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            // Get receivingOrder ID
            this.orderNumber = receivingOrderNumberSelected;

            this._isNew = false;
            this._isInitEmployee = true;
            this._isPercentageUpdated = false;
            this._isQuantityUpdated = false;
            this._totalPallets = totalPallets;
            this._totalWeight = totalWeight;
            this._totalCartons = totalCartons;



            // Set Init data
            this.InitData();

            //this.SetEditable(false);
            // Set Event form controls
            this.SetEvents();

            this.SetFocus();

            // Set fill on parrent control
            //this.Dock = DockStyle.Fill;
        }
        public urc_WM_EmployeeInfo(string receivingOrderNumberSelected, decimal totalPallets, decimal totalWeight, decimal totalCartons, string strnull)
        {
            InitializeComponent();

            // Get receivingOrder ID
            this.orderNumber = receivingOrderNumberSelected;

            this._isNew = false;
            this._isInitEmployee = true;
            this._isPercentageUpdated = false;
            this._isQuantityUpdated = false;
            this._totalPallets = totalPallets;
            this._totalWeightDB = totalWeight;
            this._totalCartons = totalCartons;


            // Set Init data
            this.InitData();

            // Set Event form controls
            this.SetEvents();

            this.SetFocus();

            this.LoadPalletCheck();
        }

        private void LoadPalletCheck()
        {
            var sourceCheck = FileProcess.LoadTable("STLoadPalletCheckingByHandheld @OrderNumber='" + this.orderNumber + "'");
            this.percenPalletCheck = Convert.ToInt32(sourceCheck.Rows[0]["PercenPalletCheck"]);
            this.percenPalletPuted = Convert.ToInt32(sourceCheck.Rows[0]["PercenPalletPuted"]);
        }


        /// <summary>
        /// Init data to display on form
        /// </summary>
        private void InitData()
        {
            InitCategory();
            InitEmployeeID();
            this.LoadRemarkSource();
            LoadEmployeeWorking(this.orderNumber);
        }
        public void hideLayoutControl()
        {
            this.layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void SetEvents()
        {
            this.rpi_lke_EmployeeID.EditValueChanged += rpi_lke_EmployeeID_EditValueChanged;
            this.lkeCategory.EditValueChanged += lkeCategory_EditValueChanged;
            this.grvEmployeeWorking.CellValueChanged += grvEmployeeWorking_CellValueChanged;
            this.grvEmployeeWorking.InitNewRow += grvEmployeeWorking_InitNewRow;
            this.grvEmployeeWorking.ShowingEditor += grvEmployeeWorking_ShowingEditor;
            this.grvEmployeeWorking.FocusedRowChanged += grvEmployeeWorking_FocusedRowChanged;
            this.grvEmployeeWorking.KeyPress += grvEmployeeWorking_KeyPress;
            this.grvEmployeeWorking.KeyDown += grvEmployeeWorking_KeyDown;
            this.grvEmployeeWorking.RowCellStyle += GrvEmployeeWorking_RowCellStyle;
            this.grvEmployeeWorking.FocusedColumnChanged += grvEmployeeWorking_FocusedColumnChanged;
            this.rpi_lke_EmployeeID.Enter += rpi_lke_EmployeeID_Enter;
        }

        private void GrvEmployeeWorking_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            string remark = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(e.RowHandle, "Remark"));
            if (remark.Trim().ToUpper().Equals("GSK")) e.Appearance.BackColor = Color.LightGreen;
        }

        private void LoadRemarkSource()
        {
            var listRemarkSource = new List<string> { "Boc xep", "Tai xe", "Kiem hang", "Pallet", "Komatsu", "Picker", "Delivery" };
            this.rpi_cbx_Remark.Items.AddRange(listRemarkSource);
        }

        public void LoadEmployeeWorking(string orderNumber)
        {
            this.orderNumber = orderNumber;
            this.LoadPalletCheck();
            listEmployeeWorking.Clear();
            DataProcess<STEmployeeWorkingView_Result> ewData = new DataProcess<STEmployeeWorkingView_Result>();
            listEmployeeWorking = new BindingList<STEmployeeWorkingView_Result>(ewData.Executing("STEmployeeWorkingView @OrderNumber = {0}", this.orderNumber).ToList());
            this.grdEmployeeWorking.DataSource = listEmployeeWorking;
            this.grvEmployeeWorking.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            this.grvEmployeeWorking.RefreshData();
        }

        private void InitCategory()
        {
            DataProcess<STComboOrderCategories_Result> categoryData = new DataProcess<STComboOrderCategories_Result>();
            this.lkeCategory.Properties.DataSource = categoryData.Executing("STComboOrderCategories");
            this.lkeCategory.Properties.ValueMember = "OrderCategoryNumber";
            this.lkeCategory.Properties.DisplayMember = "OrderCategoryNumber";
        }

        private void InitEmployeeID()
        {
            this.rpi_lke_EmployeeID.DataSource = AppSetting.EmployessList.Where(e => e.Active == true && e.StoreID == AppSetting.StoreID
            && (e.PositionID == 13 || e.PositionID == 9 || e.PositionID == 11 || e.PositionID == 12 || e.PositionID == 13 || e.PositionID == 14));
            this.rpi_lke_EmployeeID.ValueMember = "EmployeeID";
            this.rpi_lke_EmployeeID.DisplayMember = "EmployeeID";
        }

        private void lkeCategory_EditValueChanged(object sender, EventArgs e)
        {
            this.txtCatagoryDescription.Text = lkeCategory.GetColumnValue("DescriptionVietnam").ToString();
        }

        private void rpi_lke_EmployeeID_EditValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32((sender as DevExpress.XtraEditors.LookUpEdit).EditValue);
            this.grvEmployeeWorking.PostEditor();
        }

        private void grvEmployeeWorking_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            switch (e.Column.FieldName)
            {
                case "EmployeeID":
                    {
                        try
                        {
                            int employeeID = Convert.ToInt32(e.Value);

                            if (employeeID <= 0)
                            {
                                return;
                            }
                            string remark = "";
                            int percentage = 100;

                            SetPosition(employeeID, ref remark);
                            //List<EmployeeWorkings> result = this.employeeWorkingDA.Select(ew => (ew.EmployeeID == employeeID && ew.OrderNumber.Equals(this.orderNumber) && ew.Remark.Equals(remark))).ToList();
                            //if (result.Count > 0)
                            //{
                            //    XtraMessageBox.Show("This ID was entered, please check again !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}

                            this._isInitEmployee = true;

                            Employees employee = AppSetting.EmployessList.Where(i => i.EmployeeID == employeeID).FirstOrDefault();

                            string fullName = employee.LastName + " " + employee.FirstName;
                            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["EmployeeName"], fullName);
                            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["Remark"], remark);
                            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["Percentage"], percentage);
                            this.AllocatePercentForWorker();
                            this.UpdateQuantity(remark, e.RowHandle);
                            this._isNew = true;
                            this._isInitEmployee = false;
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                case "Percentage":
                    {
                        if (!this._isInitEmployee)
                        {
                            this._isPercentageUpdated = true;
                            if (!this._isQuantityUpdated)
                            {
                                int percentage = Convert.ToInt32(e.Value);
                                PercentageChanged(percentage, e.RowHandle);
                            }
                            this._isPercentageUpdated = false;
                        }
                        break;
                    }
                case "ProductionQuantity":
                    {
                        if (!this._isInitEmployee)
                        {
                            this._isQuantityUpdated = true;
                            if (!this._isPercentageUpdated)
                            {
                                decimal quantity = Convert.ToDecimal(e.Value);
                                QuantityChanged(quantity, e.RowHandle);
                            }
                            this._isQuantityUpdated = false;
                        }
                        break;
                    }
            }
        }

        private void AllocatePercentForWorker()
        {
            this.LoadPalletCheck();
            int totalBocXep = this.listEmployeeWorking.Count(e => e.Remark == "Boc xep");

            foreach (var item in this.listEmployeeWorking)
            {
                if (item.Remark == "Boc xep")
                {
                    int percent = 100 / totalBocXep;
                    item.Percentage = percent;
                    item.ProductionQuantity = (float)this._totalWeight / totalBocXep;
                }
                else if (item.Remark == "Kiem hang")
                {
                    item.Percentage = 0;
                    item.ProductionQuantity = 0;

                    if (this.GetTotalChecker() > 0)
                    {
                        item.Percentage = this.percenPalletCheck / this.GetTotalChecker();
                        item.ProductionQuantity = Convert.ToInt32(((this.percenPalletCheck * this._totalCartons) / 100) / this.GetTotalChecker());
                    }
                }
                else if (item.Remark == "Tai xe" || item.Remark == "Komatsu")
                {
                    item.Percentage = 0;
                    item.ProductionQuantity = 0;
                    if (this.GetTotalTaiXe() > 0)
                    {
                        item.Percentage = this.percenPalletPuted / this.GetTotalTaiXe();
                        item.ProductionQuantity = Convert.ToInt32(((this.percenPalletCheck * this._totalCartons) / 100) / this.GetTotalTaiXe());
                    }
                }
            }
            this.grvEmployeeWorking.RefreshData();
        }

        private void grvEmployeeWorking_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            switch (e.FocusedColumn.FieldName)
            {
                case "Percentage":
                    {
                        if (this.grvEmployeeWorking.GetFocusedRowCellValue("EmployeeID") == null || (int)this.grvEmployeeWorking.GetFocusedRowCellValue("EmployeeID") <= 0)
                        {
                            if (_isNew)
                            {
                                XtraMessageBox.Show("Please enter employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.grvEmployeeWorking.FocusedColumn = e.PrevFocusedColumn;
                                this.grvEmployeeWorking.ShowEditor();
                            }
                        }
                        else
                        {
                            this.grcProductionQuantity.OptionsColumn.AllowFocus = true;
                            this.grcRemark.OptionsColumn.AllowFocus = true;
                        }
                        break;
                    }

                case "EmployeeID":
                    {
                        this.grvEmployeeWorking.ShowEditor();
                        //(this.grvEmployeeWorking.ActiveEditor as LookUpEdit).ShowPopup();
                        break;
                    }
            }
        }

        private void grvEmployeeWorking_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            this.grvEmployeeWorking.FocusedRowHandle = e.RowHandle;
            this.grvEmployeeWorking.FocusedColumn = this.grvEmployeeWorking.Columns["EmployeeID"];
            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["TotalCartons"], this._totalCartons);
            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["TotalWeight"], 0);
            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["TotalPallets"], this._totalPallets);
            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["OrderNumber"], this.orderNumber);
            this.grvEmployeeWorking.SetRowCellValue(e.RowHandle, this.grvEmployeeWorking.Columns["ProductionQuantity"], 0);
            //this.grvEmployeeWorking.ShowEditor();
            //SetEditable(true);
        }

        private void grvEmployeeWorking_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
            {
                this.grcProductionQuantity.OptionsColumn.AllowFocus = false;
                this.grcEmployeeName.OptionsColumn.AllowFocus = false;
                this.grcRemark.OptionsColumn.AllowFocus = false;
            }
            else
            {
                this.grcProductionQuantity.OptionsColumn.AllowFocus = true;
                this.grcEmployeeName.OptionsColumn.AllowFocus = true;
                this.grcRemark.OptionsColumn.AllowFocus = true;
            }

            if (this._isNew)
            {
                //int id, string remark, int percentage, string orderNumber, float totalWeight, 
                //short totalPallets, string createdBy, int totalCartons, float productionQuantityActual
                this._isNew = false;
                int rowhandle = this.grvEmployeeWorking.GetRowHandle(this.listEmployeeWorking.Count - 1);
                int employeeID = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["EmployeeID"]));
                string remark = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["Remark"]));
                int percentage = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["Percentage"]));
                string orderNumber = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["OrderNumber"]));
                string createdBy = AppSetting.CurrentUser.LoginName;
                int totalCartons = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["TotalCartons"]));
                decimal productionQty = Convert.ToDecimal(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["ProductionQuantity"]));
                if (remark.Equals("Boc xep") && percentage > 500)
                {
                    return;
                }
                int totalBocXep = this.listEmployeeWorking.Count(em => em.Remark == "Boc xep");
                decimal weightEm = this._totalWeight;
                if (remark == "Boc xep") weightEm = this._totalWeight / totalBocXep;
                if (remark == "Kiem hang") weightEm = this._totalCartons / totalBocXep;
                //if(remark=="Tai xe")


                SaveEmployeeWorking(employeeID, remark, percentage, orderNumber, weightEm, this._totalPallets, createdBy, this._totalCartons, (float)productionQty);
                LoadEmployeeWorking(this.orderNumber);
                int percenUpdate = 100;
                decimal weightUpdate = this._totalWeight;
                foreach (var item in listEmployeeWorking)
                {
                    switch (item.Remark)
                    {
                        case "Boc xep":
                            percenUpdate = 100 / totalBocXep;
                            weightUpdate = this._totalWeight / totalBocXep;
                            break;
                        case "Kiem hang":
                            percenUpdate = percenPalletCheck / this.GetTotalChecker();
                            weightUpdate = ((percenPalletCheck * this._totalCartons) / 100) / this.GetTotalChecker();
                            break;
                        case "Tai xe":
                            percenUpdate = percenPalletPuted / this.GetTotalTaiXe();
                            weightUpdate = ((percenPalletPuted * this._totalPallets) / 100) / this.GetTotalTaiXe();
                            break;
                    }
                    employeeWorkingDA = new DataProcess<EmployeeWorkings>();
                    int result = employeeWorkingDA.ExecuteNoQuery("Update EmployeeWorkings Set Percentage={0},ProductionQuantity={1} Where EmployeeWorkingID={2}",
                        percenUpdate, weightUpdate, item.EmployeeWorkingID);
                }
                LoadEmployeeWorking(this.orderNumber);
            }
        }

        private int GetTotalChecker()
        {
            return this.listEmployeeWorking.Count(em => em.Remark == "Kiem hang");
        }

        private int GetTotalTaiXe()
        {
            return this.listEmployeeWorking.Count(em => em.Remark == "Tai xe" || em.Remark == "Komatsu");
        }
        private void grvEmployeeWorking_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void grvEmployeeWorking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.DeleteEmployeeWorking();
            }
        }

        private void rpi_lke_EmployeeID_Enter(object sender, EventArgs e)
        {
            this.grvEmployeeWorking.ShowEditor();
        }

        private void grvEmployeeWorking_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.grvEmployeeWorking.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
            {
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void SetPosition(int employeeID, ref string remark)
        {
            int positionID = AppSetting.EmployessList.Where(e => e.EmployeeID == employeeID).FirstOrDefault().PositionID;
            int managementLevel = AppSetting.EmployessList.Where(e => e.EmployeeID == employeeID).FirstOrDefault().ManagementLevel;

            if (managementLevel <= 30)
            {
                remark = "Supervisor";
                return;
            }

            if (managementLevel <= 42)
            {
                if (positionID == 60)
                {
                    remark = "Komatsu";
                    return;
                }
                else
                {
                    remark = "Tai xe";
                    return;
                }
            }


            if (managementLevel < 50)
            {
                remark = "Kiem hang";
                return;
            }

            if (managementLevel == 50)
            {
                remark = "Pallet";
                return;
            }

            if (managementLevel > 50)
            {
                remark = "Boc xep";
                return;
            }
        }

        /// <summary>
        /// Save employee working
        /// </summary>
        private void SaveEmployeeWorking(int id, string remark, int percentage, string orderNumber,
            decimal totalWeight, decimal totalPallets, string createdBy, decimal totalCartons, float productionQuantityActual)
        {
            try
            {
                employeeWorkingDA = new DataProcess<EmployeeWorkings>();
                int result = employeeWorkingDA.ExecuteNoQuery("STEmployeeWorkingInsert @EmployeeID={0},@Remark={1},@Percentage={2},@OrderNumber={3},@TotalWeight={4}," +
                    "@TotalPallets={5},@CreatedBy={6},@TotalCartons={7},@ProductionQuantityActual={8}",
                    id, remark, percentage, orderNumber, totalWeight, totalPallets, createdBy, totalCartons, productionQuantityActual);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEditable(bool isEditable)
        {
            this.grcEmployeeID.OptionsColumn.AllowEdit = isEditable;
            this.grcEmployeeName.OptionsColumn.AllowEdit = isEditable;
            this.grcPercentage.OptionsColumn.AllowEdit = isEditable;
            this.grcProductionQuantity.OptionsColumn.AllowEdit = isEditable;
            this.grcRemark.OptionsColumn.AllowEdit = isEditable;
        }

        public void SetFocus()
        {
            this.grvEmployeeWorking.Focus();
            this.grvEmployeeWorking.FocusedRowHandle = this.grvEmployeeWorking.GetRowHandle(this.grvEmployeeWorking.RowCount - 1);
            this.grvEmployeeWorking.FocusedColumn = this.grvEmployeeWorking.Columns["EmployeeID"];
            this.grvEmployeeWorking.ShowEditor();
            if (this.grvEmployeeWorking.ActiveEditor != null)
            {
                (this.grvEmployeeWorking.ActiveEditor as LookUpEdit).ShowPopup();
            }
        }

        private void DeleteEmployeeWorking()
        {
            try
            {
                int id = Convert.ToInt32(this.grvEmployeeWorking.GetFocusedRowCellValue("EmployeeWorkingID"));
                int result = this.employeeWorkingDA.ExecuteNoQuery("STEmployeeWorkingDelete @EmployeeWorkingID = {0}", id);
                LoadEmployeeWorking(this.orderNumber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuantity(string remark, int rowHandle)
        {
            decimal productQuantity = 0;
            int percentage = 100;

            if (remark.Equals("Kiem hang"))
            {
                productQuantity = percentage * this._totalCartons / 100;
                this.grvEmployeeWorking.SetRowCellValue(rowHandle, "ProductionQuantity", productQuantity);
            }
            else
            {
                if (remark.Equals("Komatsu") || remark.Equals("Tai xe"))
                {
                    productQuantity = percentage * this._totalPallets / 100;
                    this.grvEmployeeWorking.SetRowCellValue(rowHandle, "ProductionQuantity", productQuantity);
                }
                else
                {
                    if (remark.Equals("Picker"))
                    {
                        this.grvEmployeeWorking.SetRowCellValue(rowHandle, "Percentage", 0);
                        this.grvEmployeeWorking.SetRowCellValue(rowHandle, "ProductionQuantity", productQuantity);
                        this.grvEmployeeWorking.FocusedColumn = this.grcProductionQuantity;
                    }
                }
            }
        }
        private bool isPercentage500 = false;
        private void PercentageChanged(int percentage, int rowHandle)
        {
            decimal quantity = Convert.ToDecimal(this.grvEmployeeWorking.GetRowCellValue(rowHandle, "ProductionQuantity"));
            string remark = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowHandle, "Remark"));

            if (remark.Equals("Boc xep"))
            {
                if (percentage > 500)
                {
                    isPercentage500 = true;
                    MessageBox.Show("Error Percentage > 500", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grvEmployeeWorking.Focus();

                }
            }


            if (remark.Equals("Kiem hang") || remark.Equals("Picker"))
            {
                quantity = (this.percenPalletCheck * this._totalCartons / 100) / this.GetTotalChecker();
            }
            else
            {
                if (remark.Equals("Komatsu") || remark.Equals("Tai xe"))
                {
                    quantity = (this.percenPalletPuted * this._totalPallets / 100) / this.GetTotalTaiXe();
                }
            }
            this.grvEmployeeWorking.SetRowCellValue(rowHandle, "ProductionQuantity", quantity);
        }

        private void QuantityChanged(decimal quantity, int rowHandle)
        {
            string remark = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowHandle, "Remark"));
            int percentage = 0;

            if (remark.Equals("Kiem hang"))
            {
                percentage = this.percenPalletCheck / this.GetTotalChecker();
            }
            else
            {
                if (remark.Equals("Pallet") || remark.Equals("Komatsu") || remark.Equals("Tai xe"))
                {
                    percentage = this.percenPalletPuted / this.GetTotalTaiXe();
                }
                else
                {
                    if (remark.Equals("Picker"))
                    {
                        percentage = (int)Math.Round(quantity * 100 / this._totalCartons);
                    }
                }
            }
            this.grvEmployeeWorking.SetRowCellValue(rowHandle, "Percentage", percentage);
        }

        public void UpdateParameter(decimal totalCartons, decimal totalPallets, decimal totalWeight)
        {
            this._totalCartons = totalCartons;
            this._totalWeight = totalWeight;
            this._totalPallets = totalPallets;
        }

        private void rpi_lke_EmployeeID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int employeeID = Convert.ToInt32(e.Value);
            if (employeeID <= 0) return;
            string remark = "";
            SetPosition(employeeID, ref remark);
            List<EmployeeWorkings> result = this.employeeWorkingDA.Select(ew => (ew.EmployeeID == employeeID && ew.OrderNumber.Equals(this.orderNumber) && ew.Remark.Equals(remark))).ToList();
            if (result.Count > 0)
            {
                XtraMessageBox.Show("This ID was entered, please check again !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_addAllDO_Click(object sender, EventArgs e)
        {
            if (this.orderNumber.Substring(0, 2).Equals("TW"))
            {

                for (int i = 0; i < this.listEmployeeWorking.Count; i++)
                {
                    int rowhandle = this.grvEmployeeWorking.GetRowHandle(i);
                    int employeeID = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["EmployeeID"]));
                    string remark = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["Remark"]));
                    int percentage = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["Percentage"]));
                    string orderNumber = Convert.ToString(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["OrderNumber"]));
                    string createdBy = AppSetting.CurrentUser.LoginName;
                    int totalCartons = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["TotalCartons"]));
                    decimal productionQty = Convert.ToDecimal(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["ProductionQuantity"]));
                    //if (remark.Equals("Boc xep") && percentage > 500)
                    //{
                    //    return;
                    //}

                    ////////////////////////////////////////
                    try
                    {
                        int id = Convert.ToInt32(this.grvEmployeeWorking.GetRowCellValue(rowhandle, this.grvEmployeeWorking.Columns["EmployeeWorkingID"])); //GetFocusedRowCellValue("EmployeeWorkingID"));
                        int result = this.employeeWorkingDA.ExecuteNoQuery("STEmployeeWorkingDelete @EmployeeWorkingID = {0}", id);
                        //LoadEmployeeWorking(this.orderNumber);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int totalBocXep = this.listEmployeeWorking.Count(em => em.Remark == "Boc xep");
                    decimal weightEm = this._totalWeight;
                    if (remark == "Boc xep") weightEm = this._totalWeight / totalBocXep;

                    SaveEmployeeWorking(employeeID, remark, percentage, orderNumber, weightEm, this._totalPallets, createdBy, this._totalCartons, (float)productionQty);
                    int percenUpdate = 100;
                    decimal weightUpdate = this._totalWeight;
                    foreach (var item in listEmployeeWorking)
                    {
                        switch (item.Remark)
                        {
                            case "Boc xep":
                                percenUpdate = 100 / totalBocXep;
                                weightUpdate = this._totalWeight / totalBocXep;
                                break;
                            case "Kiem hang":
                                percenUpdate = percenPalletCheck / this.GetTotalChecker();
                                weightUpdate = ((percenPalletCheck * this._totalCartons) / 100) / this.GetTotalChecker();
                                break;
                            case "Tai xe":
                                percenUpdate = percenPalletPuted / this.GetTotalTaiXe();
                                weightUpdate = ((percenPalletPuted * this._totalPallets) / 100) / this.GetTotalTaiXe();
                                break;
                        }
                        employeeWorkingDA = new DataProcess<EmployeeWorkings>();
                        int result = employeeWorkingDA.ExecuteNoQuery("Update EmployeeWorkings Set Percentage={0},ProductionQuantity={1} Where EmployeeWorkingID={2}",
                            percenUpdate, weightUpdate, item.EmployeeWorkingID);
                    }
                }



                LoadEmployeeWorking(this.orderNumber);
            }
        }


    }
}
