using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_DataAdjustments : frmBaseForm
    {
        private string vType = "";
        public frm_S_DataAdjustments()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Load employee list
            this.LoadEmployeeList();

            // Init data
            this.InitData();

            // Load order type
            this.LoadOrderTypeList();
        }

        private void InitData()
        {
            this.dRequestDate.DateTime = DateTime.Now;
            this.txtCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.txtCreatedTime.Text = DateTime.Now.ToShortDateString();
        }

        private void InitEvents()
        {
            this.lkeDataAdjustmentField.CloseUp += LkeDataAdjustmentField_CloseUp;
            this.lkeOrderType.CloseUp += LkeOrderType_CloseUp;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnViewList.Click += BtnViewList_Click;
            this.txtReferenceID.KeyDown += TxtReferenceID_KeyDown;
        }

        private void TxtReferenceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            if (string.IsNullOrEmpty(this.txtReferenceID.Text))
            {
                this.txtReferenceID.Focus();
            }
            this.GetCurrentValue();

            this.lkeDataAdjustmentField.Focus();
        }

        private void LkeOrderType_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.txtNewData.Text = string.Empty;
            this.txtReferenceID.Text = string.Empty;
            this.textOldData.Text = string.Empty;

            this.LoadFieldsByOrder(Convert.ToString(e.Value));
        }

        private void BtnViewList_Click(object sender, EventArgs e)
        {
            frm_S_DataAdjustmentList frmList = new frm_S_DataAdjustmentList();
            frmList.Show();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtReferenceID.Text))
            {
                MessageBox.Show(" Please input reference ID !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtReferenceID.Focus();
                return;
            }

            if (this.lkeDataAdjustmentField.EditValue == null)
            {
                MessageBox.Show(" Please input field want change !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lkeDataAdjustmentField.Focus();
                return;
            }

            if (this.lkeEmployees.EditValue == null)
            {
                MessageBox.Show(" Please input employee required want change !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lkeEmployees.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.mmReasons.Text))
            {
                MessageBox.Show(" Please input reason required want change !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lkeEmployees.Focus();
                return;
            }

            string newValue = this.txtNewData.Text;
            int ajustmentID = Convert.ToInt32(lkeDataAdjustmentField.GetColumnValue("DataAdjustmentFieldID"));
            int referenceID = Convert.ToInt32(this.txtReferenceID.Text);
            string orderType = Convert.ToString(this.lkeOrderType.EditValue);
            bool hasBilled = this.CheckOrderHasBilled(orderType, referenceID);
            if (hasBilled)
            {
                MessageBox.Show("Current [" + orderType + "] has run billed or incorrect, please re-check it !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataProcess<object> confirmDA = new DataProcess<object>();
            int result = confirmDA.ExecuteNoQuery("STDataAdjustmentConfirmed @DataAdjustmentFieldID={0},@ReferenceID={1},@NewValue={2},@CreateBy={3},@EmployeeIDRequire={4},@Reason={5}",
                   ajustmentID, referenceID, newValue, AppSetting.CurrentUser.LoginName, lkeEmployees.EditValue, this.mmReasons.Text);
            if (result > 0)
            {
                this.ClearData();
            }
        }

        private void ClearData()
        {
            this.lkeOrderType.EditValue = null;
            this.lkeDataAdjustmentField.EditValue = null;
            this.txtReferenceID.EditValue = 0;
            this.textOldData.Text = string.Empty;
            this.lkeEmployees.EditValue = null;
            this.lblEmployeeName.Text = string.Empty;
            this.mmReasons.Text = string.Empty;
            this.txtNewData.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtNewData.Text = string.Empty;
        }

        /// <summary>
        /// VT_INT=>  dành cho kiêu int, bit,smallInt... liên quan đến int
        /// VT_DATE => dữ liệu kiểu ngày
        /// VT_DATETIME => dữ liệu ngày có giờ
        /// VT_STRING => dữ liệu text bình thường
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LkeDataAdjustmentField_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeDataAdjustmentField.EditValue = e.Value;
            string valueType = Convert.ToString(lkeDataAdjustmentField.GetColumnValue("ValueType"));
            this.txtNewData.Text = string.Empty;
            this.vType = valueType;
            switch (valueType)
            {
                case "VT_INT":
                    this.txtNewData.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.txtNewData.Properties.Mask.EditMask = "f3";
                    this.txtNewData.Properties.Mask.UseMaskAsDisplayFormat = true;
                    break;
                case "VT_DATE":
                    this.txtNewData.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                    this.txtNewData.Properties.Mask.EditMask = "yyyy-MM-dd";
                    this.txtNewData.Properties.Mask.UseMaskAsDisplayFormat = true;
                    this.txtNewData.Properties.Mask.IgnoreMaskBlank = true;
                    break;
                case "VT_DATETIME":
                    this.txtNewData.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                    this.txtNewData.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
                    this.txtNewData.Properties.Mask.UseMaskAsDisplayFormat = true;
                    this.txtNewData.Properties.Mask.IgnoreMaskBlank = true;
                    break;
                case "VT_STRING":
                    this.txtNewData.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                    this.txtNewData.Properties.Mask.EditMask = "";
                    this.txtNewData.Properties.Mask.UseMaskAsDisplayFormat = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checking current order has created billing
        /// If this order not yet created billing then return false else true
        /// </summary>
        /// <param name="orderType">string</param>
        /// <param name="orderID">int</param>
        /// <returns>bool</returns>
        private bool CheckOrderHasBilled(string orderType, int orderID)
        {
            bool hasBilled = false;
            switch (orderType)
            {
                case "RO":
                    DataProcess<ReceivingOrders> roDA = new DataProcess<ReceivingOrders>();
                    var currentRo = roDA.Select(r => r.ReceivingOrderID == orderID).FirstOrDefault();
                    if (currentRo == null) hasBilled = true;
                    else
                        hasBilled = currentRo.Status;
                    break;
                case "DO":
                    DataProcess<DispatchingOrders> doDA = new DataProcess<DispatchingOrders>();
                    var currentDo = doDA.Select(r => r.DispatchingOrderID == orderID).FirstOrDefault();
                    if (currentDo == null) hasBilled = true;
                    else
                        hasBilled = currentDo.Status;
                    break;
                default:
                    break;
            }

            return hasBilled;
        }

        private void LoadOrderTypeList()
        {
            this.lkeOrderType.Properties.DataSource = FileProcess.LoadTable("Select distinct OrderType from DataAdjustmentFields where Active = 1");
            this.lkeOrderType.Properties.ValueMember = "OrderType";
            this.lkeOrderType.Properties.DisplayMember = "OrderType";
        }

        private void LoadEmployeeList()
        {
            this.lkeEmployees.Properties.DataSource = AppSetting.EmployessList;
            this.lkeEmployees.Properties.ValueMember = "EmployeeID";
            this.lkeEmployees.Properties.DisplayMember = "EmployeeID";
        }

        private void LoadFieldsByOrder(string orderType)
        {
            this.lkeDataAdjustmentField.Properties.DataSource = FileProcess.LoadTable("select DataAdjustmentFieldID,TableName,FieldName,FieldLookup,ValueType from DataAdjustmentFields Where Active = 1 and OrderType='" + orderType + "'");
            this.lkeDataAdjustmentField.Properties.ValueMember = "FieldName";
            this.lkeDataAdjustmentField.Properties.DisplayMember = "FieldName";
        }

        private void GetCurrentValue()
        {
            if (string.IsNullOrEmpty(this.txtReferenceID.Text))
            {
                MessageBox.Show(" Please input reference ID !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtReferenceID.Focus();
                return;
            }

            if (this.lkeDataAdjustmentField.EditValue == null)
            {
                MessageBox.Show(" Please input field want change !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lkeDataAdjustmentField.Focus();
                return;
            }

            string tableName = Convert.ToString(lkeDataAdjustmentField.GetColumnValue("TableName"));
            string fieldName = Convert.ToString(lkeDataAdjustmentField.EditValue);
            string fieldLookUp = Convert.ToString(lkeDataAdjustmentField.GetColumnValue("FieldLookup"));
            int orderID = Convert.ToInt32(this.txtReferenceID.EditValue);
            var data = FileProcess.LoadTable("Select top 1 " + fieldName + " from " + tableName + " where " + fieldLookUp + " = " + orderID);
            if (data != null && data.Rows.Count > 0)
            {
                this.textOldData.EditValue = data.Rows[0][fieldName];
            }
            else
            {
                this.textOldData.Text = string.Empty;
            }
        }

        private void frm_S_DataAdjustments_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void lkeEmployees_EditValueChanged(object sender, EventArgs e)
        {
            string vietNamName = Convert.ToString(this.lkeEmployees.GetColumnValue("VietnamName"));
            this.lblEmployeeName.Text = vietNamName;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.lkeOrderType.EditValue == null) return;
            string orderType = Convert.ToString(this.lkeOrderType.EditValue);
            try
            {
                switch (orderType)
                {
                    case "RO":
                        int receivingOrderID = Convert.ToInt32(this.txtReferenceID.Text);
                        frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                        receivingOrder.ReceivingOrderIDFind = receivingOrderID;
                        receivingOrder.Show();
                        receivingOrder.WindowState = FormWindowState.Maximized;
                        receivingOrder.BringToFront();
                        break;
                    case "DO":
                        // Display disptching order
                        int doID = Convert.ToInt32(this.txtReferenceID.Text);
                        frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(doID);
                        if (dispatchingOrder.Visible)
                        {
                            dispatchingOrder.ReloadData();
                        }
                        dispatchingOrder.Show();
                        dispatchingOrder.WindowState = FormWindowState.Maximized;
                        dispatchingOrder.BringToFront();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order ID is invalid", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
