using System;
using System.Windows.Forms;
using DA;
using System.Linq;
using UI.ReportForm;
using System.Drawing;
using UI.Helper;
using DevExpress.XtraEditors;
using System.Data;
using System.Collections.Generic;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using System.ComponentModel;
using DevExpress.DataProcessing;

namespace UI.CRM
{
    public partial class urc_CRM_DiscountInfo : UserControl
    {
        private int customerID = 0;
        private int contractID = 0;
        private DiscountCooperations _currentDiscountCooperations = new DiscountCooperations();
        private List<int> _lstDicountDelete = new List<int>();
        private DataProcess<Discounts> _DiscountDA = new DataProcess<Discounts>();
        private BindingList<Discounts> bindingList = null;
        private DataProcess<DiscountCooperations> _DiscountCooperationsDA = new DataProcess<DiscountCooperations>();
        public urc_CRM_DiscountInfo(int customerID, int contractID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.customerID = customerID;
            this.contractID = contractID;
            InitStatus();
            InitDiscountInfo(this.customerID, this.contractID);
        }

        public void InitDiscountInfo(int customerID, int contractID)
        {
            var dataSource = this._DiscountDA.Select(x => x.CustomerID == customerID && x.ContractID == contractID).ToList();
            this.bindingList = new BindingList<Discounts>(dataSource.ToList());
            this.grd_DiscountData.DataSource = this.bindingList;
            var dc = this._DiscountCooperationsDA.Select(x => x.CustomerID == customerID && x.ContractID == contractID);
            if (dc.Count() > 0)
            {
                this._currentDiscountCooperations = dc.FirstOrDefault();
                this.ceCHK.Checked = Convert.ToBoolean(this._currentDiscountCooperations.CooperationTime);
                this.txtInputMonth.Text = this._currentDiscountCooperations.Month.ToString();
                this.txtInputPercent.Text = this._currentDiscountCooperations.DiscountValue.ToString();
            }
            else
            {
                this.ceCHK.Checked = false;
            }
        }

        private void rpi_lke_Measure_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            var lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;
            var measureInfo = (ServicesDefinitionMeasures)lke.GetSelectedDataRow();
            if (measureInfo == null) return;
            this.grv_DiscountData.SetRowCellValue(this.grv_DiscountData.FocusedRowHandle, "MeasureVietnam", measureInfo.ServicesDefinitionMeasureVN);
        }

        private void ceCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ceCHK.Checked)
            {
                txtInputMonth.Enabled = true;
                txtInputPercent.Enabled = true;
            }
            else
            {
                txtInputMonth.Enabled = false;
                txtInputPercent.Enabled = false;
                txtInputMonth.EditValue = 0;
                txtInputPercent.EditValue = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (var obj in this.bindingList)
            {
                if (obj.Status == "New" && obj.DiscountID > 0)
                {
                    obj.ConfirmBy = AppSetting.CurrentUser.LoginName;
                    obj.ConfirmTime = DateTime.Now;
                    obj.Status = "Confirm";
                    _DiscountDA.Update(obj);
                }
            }
            InitDiscountInfo(this.customerID, this.contractID);
        }

        private void urc_CRM_DiscountInfo_Load(object sender, EventArgs e)
        {
            // Declare DataAccess to DB
            DataProcess<ServicesDefinitionMeasures> meaSureDA = new DataProcess<ServicesDefinitionMeasures>();

            // Load datasource for measure
            this.rpi_lke_Measure.DataSource = meaSureDA.Executing("SELECT ServicesDefinitionMeasures.ServicesDefinitionMeasureID, ServicesDefinitionMeasures.ServicesDefinitionMeasureVN FROM ServicesDefinitionMeasures");
            this.rpi_lke_Measure.DisplayMember = "ServicesDefinitionMeasureID";
            this.rpi_lke_Measure.ValueMember = "ServicesDefinitionMeasureID";
        }

        private void InitStatus()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("Status", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["Status"] = "New";

            DataRow row2 = source.NewRow();
            row2["Status"] = "Confirm";

            source.Rows.Add(row1);
            source.Rows.Add(row2);

            this.rpi_lke_Status.DataSource = source;
            this.rpi_lke_Status.ValueMember = "Status";
            this.rpi_lke_Status.DisplayMember = "Status";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.AddNewDiscount();
            this.grv_DiscountData.FocusedRowHandle = this.grv_DiscountData.RowCount - 1;
            this.grv_DiscountData.FocusedColumn = this.gridColumn1;
            this.grv_DiscountData.ShowEditor();
        }

        private void AddNewDiscount()
        {
            Discounts newDiscount = new Discounts();
            newDiscount.CustomerID = this.customerID;
            newDiscount.ContractID = this.contractID;
            newDiscount.CreatedBy = AppSetting.CurrentUser.LoginName;
            newDiscount.CreatedTime = DateTime.Now;
            newDiscount.Status = "New";
            this.bindingList.Add(newDiscount);
        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            int discountID = Convert.ToInt32(this.grv_DiscountData.GetFocusedRowCellValue("DiscountID"));
            if(discountID > 0) this._lstDicountDelete.Add(discountID);
            this.grv_DiscountData.DeleteSelectedRows();
        }

        private void grv_DiscountData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0 || e.Value == null) return;
            this.bindingList[e.RowHandle].IsModified = true;
            switch (e.Column.FieldName)
            {
                case "DiscountNumber":
                    var IsExists = this.bindingList.Where(x => x.DiscountNumber == e.Value.ToString()).Count();
                    if (IsExists > 1)
                    {
                        this.grv_DiscountData.SetFocusedRowCellValue("DiscountNumber", null);
                        XtraMessageBox.Show("Discount Number is Exists");
                    }
                    break;
                case "FromValue":
                    if (this.grv_DiscountData.GetFocusedRowCellValue("ToValue") != null)
                    {
                        var toValue = Convert.ToDecimal(this.grv_DiscountData.GetFocusedRowCellValue("ToValue"));
                        if(toValue < Convert.ToDecimal(e.Value))
                        {
                            this.grv_DiscountData.SetFocusedRowCellValue("FromValue", null);
                            XtraMessageBox.Show("From value must be less than or equal to Value!");
                        }
                    }
                    break;
                case "ToValue":
                    if (this.grv_DiscountData.GetFocusedRowCellValue("FromValue") != null)
                    {
                        var fromValue = Convert.ToDecimal(this.grv_DiscountData.GetFocusedRowCellValue("FromValue"));
                        if (fromValue > Convert.ToDecimal(e.Value))
                        {
                            this.grv_DiscountData.SetFocusedRowCellValue("ToValue", null);
                            XtraMessageBox.Show("To value must be greater than or equal from Value!");
                        }
                    }
                    break;
                case "FromDate":
                    if (this.grv_DiscountData.GetFocusedRowCellValue("ToDate") != null)
                    {
                        var toValue = Convert.ToDateTime(this.grv_DiscountData.GetFocusedRowCellValue("ToDate"));
                        if (toValue < Convert.ToDateTime(e.Value))
                        {
                            this.grv_DiscountData.SetFocusedRowCellValue("FromDate", null);
                            XtraMessageBox.Show("From date must be less than or equal to date!");
                        }
                    }
                    break;
                case "ToDate":
                    if (this.grv_DiscountData.GetFocusedRowCellValue("FromDate") != null)
                    {
                        var fromValue = Convert.ToDateTime(this.grv_DiscountData.GetFocusedRowCellValue("FromDate"));
                        if (fromValue > Convert.ToDateTime(e.Value))
                        {
                            this.grv_DiscountData.SetFocusedRowCellValue("ToDate", null);
                            XtraMessageBox.Show("To date must be greater than or equal from date!");
                        }
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var obj in this.bindingList)
            {
                if (string.IsNullOrEmpty(obj.DiscountNumber))
                {
                    XtraMessageBox.Show("MCK is Required!");
                    return;
                }
                if (obj.DiscountID > 0 && obj.IsModified)
                {
                    obj.UpdateBy = AppSetting.CurrentUser.LoginName;
                    obj.UpdateTime = DateTime.Now;
                    _DiscountDA.Update(obj);
                }
                else if (obj.DiscountID <= 0)
                {
                    _DiscountDA.Insert(obj);
                }
            }
            foreach (var obj in _lstDicountDelete)
            {
                _DiscountDA.Delete(this._DiscountDA.Select(x => x.DiscountID == obj).FirstOrDefault());
                _lstDicountDelete.Remove(obj);
                if (_lstDicountDelete.Count <= 0) break;
                
            }
            if (this._currentDiscountCooperations.ID > 0)
            {
                this._currentDiscountCooperations.CooperationTime = this.ceCHK.Checked;
                this._currentDiscountCooperations.Month = Convert.ToInt32(this.txtInputMonth.Text);
                this._currentDiscountCooperations.DiscountValue = Convert.ToDecimal(this.txtInputPercent.Text.Replace('.',','));
                this._currentDiscountCooperations.UpdateBy = AppSetting.CurrentUser.LoginName;
                this._currentDiscountCooperations.UpdateTime = DateTime.Now;
                this._DiscountCooperationsDA.Update(this._currentDiscountCooperations);
            }
            else
            {
                DiscountCooperations dc = new DiscountCooperations();
                dc.CustomerID = this.customerID;
                dc.ContractID = this.contractID;
                dc.CooperationTime = this.ceCHK.Checked;
                dc.Month = Convert.ToInt32(this.txtInputMonth.Text);
                dc.DiscountValue = Convert.ToDecimal(this.txtInputPercent.Text.Replace('.', ','));
                dc.CreatedBy = AppSetting.CurrentUser.LoginName;
                dc.CreatedTime = DateTime.Now;
                this._DiscountCooperationsDA.Insert(dc);
            }
        }

        private void grv_DiscountData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.grv_DiscountData.GetFocusedRowCellValue("ConfirmBy") != null)
            {
                this.grv_DiscountData.Columns["DiscountNumber"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["Description"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["Measure"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["FromValue"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["ToValue"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["Persent"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["FromDate"].OptionsColumn.ReadOnly = true;
                this.grv_DiscountData.Columns["ToDate"].OptionsColumn.ReadOnly = true;
            }
            else
            {
                this.grv_DiscountData.Columns["DiscountNumber"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["Description"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["Measure"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["FromValue"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["ToValue"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["Persent"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["FromDate"].OptionsColumn.ReadOnly = false;
                this.grv_DiscountData.Columns["ToDate"].OptionsColumn.ReadOnly = false;
            }
        }
    }
}
