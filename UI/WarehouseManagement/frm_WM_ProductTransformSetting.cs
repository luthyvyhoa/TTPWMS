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
    public partial class frm_WM_ProductTransformSetting : Form
    {
        BindingList<ProductTransformation> transFormBD = null;
        DataProcess<ProductTransformation> transFormDA = new DataProcess<ProductTransformation>();
        public frm_WM_ProductTransformSetting()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Load customer
            this.LoadCustomer();

            // Load all product transform
            this.LoadAllProductTransformation();
        }

        private void LoadAllProductTransformation()
        {
            bool hasAdd = false;
            DataProcess<ProductTransformation> productTransform = new DataProcess<ProductTransformation>();
            this.transFormBD = new BindingList<ProductTransformation>(productTransform.Select().ToList());
            if(this.transFormBD.Count==1)
            {
                this.transFormBD.Add(this.transFormBD[0]);
                hasAdd = true;
            }
            this.dataNavigatorProductTransformations.DataSource = this.transFormBD;
            this.dataNavigatorProductTransformations.Position = this.transFormBD.Count() - 1;
            if (hasAdd) this.transFormBD.RemoveAt(0);
        }

        private void LoadProducts(int customerID)
        {
            DataProcess<STComboProductTrans_Result> dataProcess = new DataProcess<STComboProductTrans_Result>();
            var dataSource = dataProcess.Executing("STComboProductTrans @CustomerID={0}", customerID);
            this.lke_FininshProductID1.Properties.DataSource = dataSource;
            this.lke_FininshProductID1.Properties.ValueMember = "ProductID";
            this.lke_FininshProductID1.Properties.DisplayMember = "ProductNumber";

            this.lke_FininshProductID2.Properties.DataSource = dataSource;
            this.lke_FininshProductID2.Properties.ValueMember = "ProductID";
            this.lke_FininshProductID2.Properties.DisplayMember = "ProductNumber";

            this.lke_FininshProductID3.Properties.DataSource = dataSource;
            this.lke_FininshProductID3.Properties.ValueMember = "ProductID";
            this.lke_FininshProductID3.Properties.DisplayMember = "ProductNumber";

            this.lke_SourceProductID1.Properties.DataSource = dataSource;
            this.lke_SourceProductID1.Properties.ValueMember = "ProductID";
            this.lke_SourceProductID1.Properties.DisplayMember = "ProductNumber";

            this.lke_SourceProductID2.Properties.DataSource = dataSource;
            this.lke_SourceProductID2.Properties.ValueMember = "ProductID";
            this.lke_SourceProductID2.Properties.DisplayMember = "ProductNumber";

            this.lke_SourceProductID3.Properties.DataSource = dataSource;
            this.lke_SourceProductID3.Properties.ValueMember = "ProductID";
            this.lke_SourceProductID3.Properties.DisplayMember = "ProductNumber";
        }

        private void InitEvents()
        {
            this.lookUpEditCustomerID.CloseUp += LookUpEditCustomerID_CloseUp;
            this.lookUpEditCustomerID.EditValueChanged += LookUpEditCustomerID_EditValueChanged;

            this.lke_SourceProductID1.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_SourceProductID2.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_SourceProductID3.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_FininshProductID1.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_FininshProductID2.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_FininshProductID3.EditValueChanged += Lke_SourceProductID1_EditValueChanged;
            this.lke_SourceProductID1.CloseUp += Lke_SourceProductID1_CloseUp;
            this.lke_SourceProductID2.CloseUp += Lke_SourceProductID1_CloseUp;
            this.lke_SourceProductID3.CloseUp += Lke_SourceProductID1_CloseUp;
            this.lke_FininshProductID1.CloseUp += Lke_SourceProductID1_CloseUp;
            this.lke_FininshProductID2.CloseUp += Lke_SourceProductID1_CloseUp;
            this.lke_FininshProductID3.CloseUp += Lke_SourceProductID1_CloseUp;

            this.dataNavigatorProductTransformations.PositionChanged += DataNavigatorProductTransformations_PositionChanged;
            this.btnNew.Click += BtnNew_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnConfirmProcess.Click += BtnConfirmProcess_Click;
        }

        private void BtnConfirmProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEditTransformFormula.Text))
            {
                MessageBox.Show("Transform formula is required !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductTransformation currentTransForm = null;
            if (dataNavigatorProductTransformations.Position < 0)
            {
                currentTransForm = new ProductTransformation();
            }
            else
            {
                currentTransForm = this.transFormBD[dataNavigatorProductTransformations.Position];
            }

            currentTransForm.CustomerID = (int)(this.lookUpEditCustomerID.EditValue);
            currentTransForm.TransformationFormula = this.textEditTransformFormula.Text;
            currentTransForm.ProductTransformationRemark = this.mmTransformRemark.Text;
            if (this.lke_SourceProductID1.EditValue != null) currentTransForm.SourceProduct1ID = (int)this.lke_SourceProductID1.EditValue;
            if (this.lke_SourceProductID2.EditValue != null) currentTransForm.SourceProduct1ID = (int)this.lke_SourceProductID2.EditValue;
            if (this.lke_SourceProductID3.EditValue != null) currentTransForm.SourceProduct1ID = (int)this.lke_SourceProductID3.EditValue;
            if (this.lke_FininshProductID1.EditValue != null) currentTransForm.FinishProduct1ID = (int)this.lke_FininshProductID1.EditValue;
            if (this.lke_FininshProductID1.EditValue != null) currentTransForm.FinishProduct2ID = (int)this.lke_FininshProductID1.EditValue;
            if (this.lke_FininshProductID1.EditValue != null) currentTransForm.FinishProduct3ID = (int)this.lke_FininshProductID1.EditValue;
            currentTransForm.SourceProduct1Qty = Convert.ToInt32(this.textEdit_SourceProductWeight1.EditValue);
            currentTransForm.SourceProduct1Qty = Convert.ToInt32(this.textEdit_SourceProductWeight2.EditValue);
            currentTransForm.SourceProduct2Qty = Convert.ToInt32(this.textEdit_SourceProductWeight3.EditValue);
            currentTransForm.FinishProduct1Qty = Convert.ToInt32(this.textEdit_FinishProductWeight1.EditValue);
            currentTransForm.FinishProduct1Qty = Convert.ToInt32(this.textEdit_FinishProductWeight2.EditValue);
            currentTransForm.FinishProduct1Qty = Convert.ToInt32(this.textEdit_FinishProductWeight3.EditValue);
            currentTransForm.TransformationType = 0;

            if (currentTransForm != null && currentTransForm.ProductTransformationID > 0)
            {
                this.transFormDA.Update(currentTransForm);
            }
            else
            {
                currentTransForm.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentTransForm.CreatedTime = DateTime.Now;
                transFormDA.Insert(currentTransForm);
                this.LoadAllProductTransformation();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void ClearData()
        {
            this.textEditProductTransformationID.Text = string.Empty;
            this.textEditTransformFormula.Text = string.Empty;
            this.mmTransformRemark.Text = string.Empty;
            this.lookUpEditCustomerID.EditValue = null;
            this.lke_SourceProductID1.EditValue = null;
            this.lke_SourceProductID2.EditValue = null;
            this.lke_SourceProductID3.EditValue = null;
            this.lke_FininshProductID1.EditValue = null;
            this.lke_FininshProductID2.EditValue = null;
            this.lke_FininshProductID3.EditValue = null;
            this.textEdit_SourceProductWeight1.EditValue = string.Empty;
            this.textEdit_SourceProductWeight2.EditValue = string.Empty;
            this.textEdit_SourceProductWeight3.EditValue = string.Empty;
            this.textEdit_FinishProductWeight1.EditValue = string.Empty;
            this.textEdit_FinishProductWeight1.EditValue = string.Empty;
            this.textEdit_FinishProductWeight1.EditValue = string.Empty;
            this.textEditReceivingCreatedBy.Text = AppSetting.CurrentUser.LoginName;
            this.textEditReceivingCreatedTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.transFormBD.AddNew();
            this.dataNavigatorProductTransformations.Position = this.transFormBD.Count - 1;
            this.lookUpEditCustomerID.Focus();
            this.lookUpEditCustomerID.ShowPopup();
        }

        private void Lke_SourceProductID1_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (LookUpEdit)sender;
            var customerSelected = (STComboProductTrans_Result)lke.GetSelectedDataRow();
            if (customerSelected == null) return;
            switch (lke.Name)
            {
                case "lke_SourceProductID1":
                    this.textEdit_SourceProductName1.Text = customerSelected.ProductName;
                    this.textEdit_SourceProductWeight1.EditValue = customerSelected.WeightPerPackage;
                    break;
                case "lke_SourceProductID2":
                    this.textEdit_SourceProductName2.Text = customerSelected.ProductName;
                    this.textEdit_SourceProductWeight2.EditValue = customerSelected.WeightPerPackage;
                    break;
                case "lke_SourceProductID3":
                    this.textEdit_SourceProductName3.Text = customerSelected.ProductName;
                    this.textEdit_SourceProductWeight3.EditValue = customerSelected.WeightPerPackage;
                    break;
                case "lke_FininshProductID1":
                    this.textEdit_FinishProductName1.Text = customerSelected.ProductName;
                    this.textEdit_FinishProductWeight1.EditValue = customerSelected.WeightPerPackage;
                    break;
                case "lke_FininshProductID2":
                    this.textEdit_FinishProductName2.Text = customerSelected.ProductName;
                    this.textEdit_FinishProductWeight2.EditValue = customerSelected.WeightPerPackage;
                    break;
                case "lke_FininshProductID3":
                    this.textEdit_FinishProductName3.Text = customerSelected.ProductName;
                    this.textEdit_FinishProductWeight3.EditValue = customerSelected.WeightPerPackage;
                    break;
            }
        }

        private void LookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            string customerName = Convert.ToString(this.lookUpEditCustomerID.GetColumnValue("CustomerName"));
            this.textEditCustomerName.Text = customerName;

            // Load all product
            this.LoadProducts((int)this.lookUpEditCustomerID.EditValue);
        }

        private void Lke_SourceProductID1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            var lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;

        }

        private void DataNavigatorProductTransformations_PositionChanged(object sender, EventArgs e)
        {
            var currentTransform = this.transFormBD[dataNavigatorProductTransformations.Position];
            if (currentTransform == null) return;

            this.lookUpEditCustomerID.EditValue = currentTransform.CustomerID;

            // Binding list
            this.BindingData(currentTransform);
        }

        private void LookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lookUpEditCustomerID.EditValue = e.Value;
        }

        private void LoadCustomer()
        {
            this.lookUpEditCustomerID.Properties.DataSource = AppSetting.CustomerList;
            this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
        }

        private void BindingData(ProductTransformation protrans)
        {
            this.textEditProductTransformationID.Text = Convert.ToString(protrans.ProductTransformationID);
            this.textEditTransformFormula.Text = protrans.TransformationFormula;
            this.mmTransformRemark.Text = protrans.ProductTransformationRemark;
            this.lookUpEditCustomerID.EditValue = protrans.CustomerID;
            this.lke_SourceProductID1.EditValue = protrans.SourceProduct1ID;
            this.lke_SourceProductID2.EditValue = protrans.SourceProduct2ID;
            this.lke_SourceProductID3.EditValue = protrans.SourceProduct3ID;
            this.lke_FininshProductID1.EditValue = protrans.FinishProduct1ID;
            this.lke_FininshProductID2.EditValue = protrans.FinishProduct2ID;
            this.lke_FininshProductID3.EditValue = protrans.FinishProduct3ID;
            this.textEdit_SourceProductWeight1.EditValue = protrans.SourceProduct1Qty;
            this.textEdit_SourceProductWeight2.EditValue = protrans.SourceProduct2Qty;
            this.textEdit_SourceProductWeight3.EditValue = protrans.SourceProduct3Qty;
            this.textEdit_FinishProductWeight1.EditValue = protrans.FinishProduct1Qty;
            this.textEdit_FinishProductWeight1.EditValue = protrans.FinishProduct2Qty;
            this.textEdit_FinishProductWeight1.EditValue = protrans.FinishProduct3Qty;
            this.textEditReceivingCreatedBy.Text = protrans.CreatedBy;
            this.textEditReceivingCreatedTime.Text = protrans.CreatedTime.ToString("dd/MM/yyyy");
        }
    }
}
