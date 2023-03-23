using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DA;
using Common.Process;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_ChangeProductPalletInfo :Common.Controls.frmBaseForm
    {
        int m_CustomerID = 0;
        int m_ProductID = 0;
        decimal m_WeightPerPackage = 0;

        public frm_WM_Dialog_ChangeProductPalletInfo()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_WM_Dialog_ChangeProductPalletInfo(int i_CustomerID, int i_ProductID, decimal i_WeightPerPackage)
        {
            InitializeComponent();

            this.m_WeightPerPackage = i_WeightPerPackage;
            this.m_CustomerID = i_CustomerID;
            this.m_ProductID = i_ProductID;

            SetEvent();
        }

        void Frm_WM_Dialog_ChangeProductPalletInfo_Load(object sender, EventArgs e)
        {
            LoadData2lookUpEdit_ProductID();
            lookUpEdit_ProductID.Focus();
            //lookUpEdit_ProductID.ShowPopup();
        }

        void SetEvent()
        {
            this.Load += Frm_WM_Dialog_ChangeProductPalletInfo_Load;

            btn_Cancel.Click += Btn_Cancel_Click;
            btn_Change.Click += Btn_Change_Click;

            lookUpEdit_ProductID.EditValueChanged += LookUpEdit_ProductID_EditValueChanged;
        }

        void LookUpEdit_ProductID_EditValueChanged(object sender, EventArgs e)
        {
            int v_proID = 0;
            try
            {
                v_proID = Convert.ToInt32(lookUpEdit_ProductID.EditValue);
                string proName = lookUpEdit_ProductID.Properties.GetDataSourceValue("ProductName", lookUpEdit_ProductID.ItemIndex).ToString();
                textEdit_ProductNameNew.Text = proName;
            }
            catch
            {
                Wait.Close();
                textEdit_ProductNameNew.Text = "";
            }
            Wait.Close();
        }

        void Btn_Change_Click(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            try
            {
                v_ProductID = Convert.ToInt32(lookUpEdit_ProductID.EditValue);
            }
            catch { }

            if (this.m_ProductID <= 0)
            {
                XtraMessageBox.Show("Please enter the product !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (v_ProductID <= 0)
            {
                XtraMessageBox.Show("Please enter product to change !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (XtraMessageBox.Show("This operation will change and after that delete this product. Are you sure you want to continue?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();

                    int result = da.STProductDeleteAndChange(this.m_ProductID, v_ProductID, UI.Helper.AppSetting.CurrentUser.LoginName);

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData2lookUpEdit_ProductID()
        {
            try
            {
                Wait.Start(this);

                List<ST_WMS_ProductsListForChangProduct_Result> listProduct = (new DataProcess<DA.ST_WMS_ProductsListForChangProduct_Result>()).Executing("ST_WMS_ProductsListForChangProduct @CustomerID={0},@ProductIDOld={1},@WeightPerPackage ={2}", this.m_CustomerID, this.m_ProductID, this.m_WeightPerPackage).ToList();
               
                if (listProduct.Count > 0)
                {
                    ST_WMS_ProductsListForChangProduct_Result proOld = listProduct.First(p => p.ProductID == this.m_ProductID);
                    textEdit_ProductNumberOld.Text = proOld.Product;
                    textEdit_ProductNameOld.Text = proOld.ProductName;

                    listProduct = listProduct.Where(p => p.ProductID != this.m_ProductID).ToList();
                    if (listProduct.Count > 0)
                    {
                        lookUpEdit_ProductID.Properties.DataSource = listProduct;
                    }
                    else
                    {
                        lookUpEdit_ProductID.Properties.DataSource = null;
                    }
                }
            }
            catch
            {
                DialogResult = DialogResult.Cancel;
                Wait.Close();
            }
            finally
            {
                Wait.Close();
            }
        }

       
    }
}