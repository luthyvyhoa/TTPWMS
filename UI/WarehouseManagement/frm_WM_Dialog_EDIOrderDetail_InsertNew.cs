using DA;
using DevExpress.XtraEditors;
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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_EDIOrderDetail_InsertNew : Form
    {
        public int varEDIOrderDetailID;
        private DateTime currentDate;
        private int qty = 0;
        private int eidDetailID = 0;
        private string proNumber = string.Empty;
        private string proName = string.Empty;
        private int CustomerID=0;
        private string CustomerRef = string.Empty;
        public frm_WM_Dialog_EDIOrderDetail_InsertNew(string ProductNumber, string ProductName, DateTime CurrentExpDate, int requiredQuantity, int EDIOrderDetailID,int CustomerID,string cusRef)
        {
            InitializeComponent();
            // Set params
            this.proNumber = ProductNumber;
            this.proName = ProductName;
            this.currentDate = CurrentExpDate;
            this.qty = requiredQuantity;
            this.eidDetailID = EDIOrderDetailID;
            this.CustomerID = CustomerID;
            this.CustomerRef = cusRef;
            // binding value on gui
            this.textProductNumber.Text = ProductNumber;
            this.textProductName.Text = ProductName;
            this.textExpiryDate.EditValue = CurrentExpDate;
            this.textOldQuantity.EditValue = requiredQuantity;
            this.txtReference.EditValue = CustomerRef;
            varEDIOrderDetailID = EDIOrderDetailID;
            LoadCustomer();
            InitLkeChangProduct();
        }
        private void LoadCustomer()
        {
            DataProcess<Customers> cus = new DataProcess<Customers>();
            int cusType = Convert.ToInt32(cus.Select(n => n.CustomerID == this.CustomerID).FirstOrDefault().CustomerDispatchType);
            if (this.CustomerID==1022 || cusType==8)
            {
                txtReference.ReadOnly = false;
                textExpiryDate.ReadOnly = true;
            }
            else
            {
                textExpiryDate.ReadOnly = false;
                txtReference.ReadOnly = true;
            }
        }

        private void btnInsertNewRecord_Click(object sender, EventArgs e)
        {
            if(txtReference.Text=="")
            {
                if (this.textQuantity.EditValue == null)
                {
                    MessageBox.Show("Please input Quantity!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textQuantity.Focus();
                    return;
                }

                int newQty = Convert.ToInt32(this.textQuantity.EditValue);
                if (newQty < this.qty && newQty > 0)
                {

                    DataProcess<object> ParameterDA = new DataProcess<object>();
                    int result = -2;
                    if(CheckProductNumber())
                    {
                        result = ParameterDA.ExecuteNoQuery("STEDI_OrderDetailBreakNew @EDI_OrderDetailID = {0}, @ExpDate = {1}, @Quantity = {2},@ProductNumber={3},@ProductName={4}",
                       varEDIOrderDetailID, this.textExpiryDate.EditValue, newQty,lke_ChangeProduct.EditValue,lke_ChangeProduct.Text);
                    }
                    else
                    {
                        result = ParameterDA.ExecuteNoQuery("STEDI_OrderDetailBreakNew @EDI_OrderDetailID = {0}, @ExpDate = {1}, @Quantity = {2},@ProductNumber={3},@ProductName={4}",
                      varEDIOrderDetailID, this.textExpiryDate.EditValue, newQty, textProductNumber.EditValue, textProductName.EditValue);
                    }
                   
                    if (result > 0)
                        this.Close();
                    else
                        XtraMessageBox.Show("Error, Can not break EDI Order Details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Quantity is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (this.textQuantity.EditValue == null)
                {
                    MessageBox.Show("Please input Quantity!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.textQuantity.Focus();
                    return;
                }
                if (this.txtReference.EditValue == null)
                {
                    MessageBox.Show("Please input Reference!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtReference.Focus();
                    return;
                }
                int newQty = Convert.ToInt32(this.textQuantity.EditValue);
                if (newQty < this.qty && newQty > 0)
                {
                    DataProcess<object> ParameterDA = new DataProcess<object>();
                    int result = -2;
                    if (CheckProductNumber())
                    {
                        result = ParameterDA.ExecuteNoQuery("STEDI_OrderDetailBreakNew @EDI_OrderDetailID = {0}, @ExpDate = {1}, @Quantity = {2},@Reference={3},@ProductNumber={4},@ProductName={5}",
                        varEDIOrderDetailID, null, newQty, txtReference.Text, lke_ChangeProduct.EditValue, lke_ChangeProduct.Text);
                    }
                    else
                    {
                        result = ParameterDA.ExecuteNoQuery("STEDI_OrderDetailBreakNew @EDI_OrderDetailID = {0}, @ExpDate = {1}, @Quantity = {2},@Reference={3},@ProductNumber={4},@ProductName={5}",
                                              varEDIOrderDetailID, null, newQty, txtReference.Text, textProductNumber.EditValue, textProductName.EditValue);
                    }
                    if (result > 0)
                        this.Close();
                    else
                        XtraMessageBox.Show("Error, Can not break EDI Order Details !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Quantity is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
        }

        private void textQuantity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (Convert.ToInt32(e.NewValue) >= Convert.ToInt32(this.textOldQuantity.EditValue))
            //{
            //    XtraMessageBox.Show("Quantity is not correct !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    e.Cancel = true;
            //}
        }

        private void InitLkeChangProduct()
        {
            DataTable dt = FileProcess.LoadTable("SELECT tmpProductRemains.*,right(ProductNumber,len(ProductNumber)-4) as ProductNumber, right(ProductNumber,len(ProductNumber)-4)+ '|' + tmpProductRemainName as ProductRemainName FROM dbo.tmpProductRemains JOIN dbo.Products ON tmpProductRemains.tmpProductRemainID=Products.ProductID WHERE len(Products.ProductNumber)>4 and Products.CustomerID = " + this.CustomerID);
            lke_ChangeProduct.Properties.DataSource = dt;
            lke_ChangeProduct.Properties.DisplayMember = "ProductRemainName";
            lke_ChangeProduct.Properties.ValueMember = "ProductNumber";
        }
        private bool CheckProductNumber()
        {
            if(lke_ChangeProduct.EditValue!=null|| !lke_ChangeProduct.Text.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
