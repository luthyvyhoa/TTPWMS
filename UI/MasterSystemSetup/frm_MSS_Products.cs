using Common.Process;
using DA;
using DevExpress.CodeParser;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using UI.APIs;
using UI.Helper;
using UI.WarehouseManagement;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Products : Common.Controls.frmBaseForm
    {
        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_MSS_Products));
        ST_WMS_LoadRecordProductData_Result m_LoadRecordProductData;
        private Products productSelected = null;
        private int productID = 0;
        private bool isFormLoad = false;
        private bool isAddNew = false;
        private bool isEditing = false;
        private BindingList<ProductPackage> bdPackage = null;
        private BindingList<ProductMeasure> bdProductMeasure = null;
        private int customerID = 0;
        private static readonly frm_MSS_Products instance = new frm_MSS_Products();

        class CActionForm
        {
            public static int Navigation = 1;
            public static int New = 2;
            public static int Delete = 3;
            public static int Edit = 4;
            public static int Save = 5;
            public static int LoadForm = 6;
            public static int Copy = 7;
            public static int Cancel = 8;
        }

        class CActionRecord
        {
            public static int p_TypeLoadForm = 1;
            public static int p_TypeLoadProductID = 2;
            public static int p_TypeLoadFirst = 3;
            public static int p_TypeLoadNext = 4;
            public static int p_TypeLoadLast = 5;
            public static int p_TypeLoadPre = 6;
            public static int p_TypeLoadIndex = 7;
            public static int p_TypeLoadDelete = 8;
        }

        DA.Products obj_Product;

        int m_customerMainID = 0;
        int m_ProductID = 0;
        int m_Old_ProductID = 0;

        protected frm_MSS_Products()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.lke_WM_Products.Font = new Font(lke_WM_Products.Font, FontStyle.Bold);
            this.lookUpEdit_CustomerID.Font = new Font(lookUpEdit_CustomerID.Font, FontStyle.Bold);
            this.txtEdit_CustomerName.Font = new Font(txtEdit_CustomerName.Font, FontStyle.Bold);
            this.txtEdit_InitialLabel.Font = new Font(txtEdit_InitialLabel.Font, FontStyle.Bold);
            this.txtEdit_ProductNumber.Font = new Font(txtEdit_ProductNumber.Font, FontStyle.Bold);
            this.txtProductID.Font = new Font(txtProductID.Font, FontStyle.Bold);
            this.m_ProductID = productID;

            SetEvent();
        }

        /// <summary>
        /// Get or set ProductID to lookup product info
        /// </summary>
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
            }
        }

        /// <summary>
        /// Get or set ProductID to lookup product info
        /// </summary>
        public int ProductIDLookup
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
                this.obj_Product = AppSetting.ProductList.Where(p => p.ProductID == this.productID).FirstOrDefault();
                this.GetObjectInfo();
            }
        }

        /// <summary>
        /// Get products form instance
        /// </summary>
        public static frm_MSS_Products Instance
        {
            get
            {
                return instance;
            }
        }


        void Frm_MSS_Products_Load(object sender, EventArgs e)
        {
            this.isFormLoad = true;
            this.m_ProductID = this.productID;
            this.productSelected = this.m_ProductID != 0 ? AppSetting.ProductList.Where(p => p.ProductID == m_ProductID).FirstOrDefault() : null;
            LoadData2LookUpEdit_Customers();
            LoadData2LookUpEdit_ProductCategory();
            LoadData2lookUpEdit_HomeRoom1();
            LoadData2lookUpEdit_HomeRoom2();
            LoadData2lookUpEdit_Packages();
            LoadData2lookUpEdit_WAREHOUSE_NO();
            LoadData2lookUpEdit_PickingLocation();
            this.LoadProductMain();

            if (m_ProductID > 0)
            {
                LoadRecordProducts(CActionRecord.p_TypeLoadProductID, 0, m_ProductID);

                SetEnableButton(CActionForm.LoadForm);
            }
            else
            {
                AddNewRecord();
            }

            // Load product image list
            this.LoadProductImages();
            this.LoadProductPackage();
        }

        private void LoadProductPackage()
        {
            DataProcess<ProductPackage> packageDA = new DataProcess<ProductPackage>();
            if (this.obj_Product == null || this.obj_Product.ProductID < 0)
            {
                var dataSource = new List<ProductPackage>() { new ProductPackage() };

                this.bdPackage = new BindingList<ProductPackage>(dataSource);
                this.AddNewPackage();
                this.grcProductPackages.DataSource = this.bdPackage;
            }
            else
            {
                var dataSource = packageDA.Executing("STProductPackages @ProductID={0}", this.obj_Product.ProductID).ToList();
                this.bdPackage = new BindingList<ProductPackage>(dataSource);
                this.AddNewPackage();
                this.grcProductPackages.DataSource = this.bdPackage;
            }


        }
        private void LoadPackageType(bool isUnit)
        {
            DataProcess<QCMaster> dataProcess = new DataProcess<QCMaster>();
            IList<QCMaster> dataSource = null;
            //if (isUnit) dataSource = dataProcess.Select(m => m.Value1==1 || m.Value2==1).ToList();
            //else
            //    dataSource = dataProcess.Select(m => m.Value1 >1 || m.Value2>1).ToList();
            dataSource = dataProcess.Select().ToList();
            this.lke_PackageTypes.Properties.DataSource = dataSource;
            this.lke_PackageTypes.Properties.DisplayMember = "PackageName";
            this.lke_PackageTypes.Properties.ValueMember = "PackageTypeID";
        }

        private void LoadProductMain()
        {
            if (this.productSelected == null) return;
            this.lke_WM_Products.Properties.DataSource = FileProcess.LoadTable("STComboProductID " + this.productSelected.CustomerID);
            this.lke_WM_Products.Properties.DisplayMember = "ProductNumber";
            this.lke_WM_Products.Properties.ValueMember = "ProductID";
        }
        void SetEvent()
        {
            this.Load += Frm_MSS_Products_Load;

            //btnCopy.Click += btnCopy_Click;
            //btnDelete.Click += btnDelete_Click;
            //btnEdit_Click += btnEdit_Click;
            //btnNew.Click += btnNew_Click;
            //btnSave.ItemClick += btnSave_ItemClick;
            //btnCancel.Click += btnCancel_Click;

            // btnPalletInfo.Click += btnPalletInfo_Click;
            //btnProductList.Click += btnProductList_Click;
            // btnUpdateOrder.Click += Btn_P_UpdateOrder_Click;

            //btnClose.Click += Btn_P_Close_Click;

            radGroup_PickingMethod.EditValueChanged += Rad_GroupPickingMethod_EditValueChanged;
            lookUpEdit_CustomerID.EditValueChanged += LookUp_CustomerID_EditValueChanged;
            this.lookUpEdit_CustomerID.CloseUp += LookUpEdit_CustomerID_CloseUp;
            //txtEdit_ProductName.EditValueChanged += TxtEdit_ProductName_EditValueChanged;
        }

        private void LookUpEdit_CustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e == null) return;
            int currentProductID = Convert.ToInt32(txtProductID.Text);
            if (currentProductID > 0)
            {
                var dl = XtraMessageBox.Show("Bạn đang đổi mã khách hàng của sản phẩm đã có\nBạn có chắc chắn việc này ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No))
                {
                    e.AcceptValue = false;
                    return;
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                string productID = "PR-" + this.txtProductID.Text;
                frm_WM_Attachments.Instance.OrderNumber = productID;
                frm_WM_Attachments.Instance.CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        void Rad_GroupPickingMethod_EditValueChanged(object sender, EventArgs e)
        {
            bool v_Value = false;

            try
            {
                v_Value = Convert.ToBoolean(radGroup_PickingMethod.EditValue);
            }
            catch { }

            if (v_Value == true)
            {
                layoutControlItemPickingLocation.Enabled = lookUpEdit_PickingLocation.Enabled = true;
            }
            else
            {
                layoutControlItemPickingLocation.Enabled = lookUpEdit_PickingLocation.Enabled = false;
                lookUpEdit_PickingLocation.EditValue = 0;
            }
        }
        void LookUp_CustomerID_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                m_customerMainID = 0;
                int v_CustomerID = 0;

                try
                {
                    v_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
                    if (v_CustomerID > 0)
                        m_customerMainID = Convert.ToInt32(UI.Helper.AppSetting.CustomerList.Where(a => a.CustomerID == v_CustomerID).FirstOrDefault().CustomerMainID);
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                }
                if (m_customerMainID > 0)
                {
                    LoadData2LookUpEdit_CustomerProductGroups(m_customerMainID);

                    DA.Customers v_obj_Customer = (new DataProcess<Customers>()).Select(c => c.CustomerID == v_CustomerID).FirstOrDefault();

                    try
                    {
                        txtEdit_InitialLabel.Text = v_obj_Customer.CustomerNumber.Substring(0, 4);
                        txtEdit_CustomerName.Text = v_obj_Customer.CustomerName;
                    }
                    catch (Exception ex)
                    {
                        log.Error("==> Error is unexpected");
                        log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                m_customerMainID = 0;
            }
        }

        void BdNavigator_MoveFirstItem_Click(object sender, EventArgs e)
        {
            LoadRecordProducts(CActionRecord.p_TypeLoadFirst, 0, obj_Product.ProductID);
        }

        void btnNew_Click(object sender, ItemClickEventArgs e)
        {

        }
        void btnEdit_Click(object sender, ItemClickEventArgs e)
        {
            SetEnableButton(CActionForm.Edit);

            if (this.obj_Product == null) return;
            m_Old_ProductID = obj_Product.ProductID;
        }
        void btnDelete_Click(object sender, ItemClickEventArgs e)
        {

        }
        void btnCopy_Click(object sender, ItemClickEventArgs e)
        {

        }
        void Btn_P_UpdateOrder_ItemClick(object sender, ItemClickEventArgs e)
        {


        }


        private void InitValidationRules()
        {
            ConditionValidationRule notEmpty_lookUpEdit_CustomerID = new ConditionValidationRule();
            notEmpty_lookUpEdit_CustomerID.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_lookUpEdit_CustomerID.ErrorText = "Customer please !";

            ConditionValidationRule notEmpty_txtEdit_ProductNumber = new ConditionValidationRule();
            notEmpty_txtEdit_ProductNumber.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_txtEdit_ProductNumber.ErrorText = "Product ID please !";

            ConditionValidationRule notEmpty_txtEdit_ProductName = new ConditionValidationRule();
            notEmpty_txtEdit_ProductName.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_txtEdit_ProductName.ErrorText = "Product Name please !";

            ConditionValidationRule notEmpty_lookUpEdit_Packages = new ConditionValidationRule();
            notEmpty_lookUpEdit_Packages.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_lookUpEdit_Packages.ErrorText = "Package please !";

            ConditionValidationRule notEmpty_lookUpEdit_CustomerProductGroups = new ConditionValidationRule();
            notEmpty_lookUpEdit_CustomerProductGroups.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_lookUpEdit_CustomerProductGroups.ErrorText = "Product Category is not correct !";

            ConditionValidationRule notEmpty_lookUpEdit_HomeRoom1 = new ConditionValidationRule();
            notEmpty_lookUpEdit_HomeRoom1.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_lookUpEdit_HomeRoom1.ErrorText = "Home room 1 please !";

            ConditionValidationRule notEmpty_lookUpEdit_HomeRoom2 = new ConditionValidationRule();
            notEmpty_lookUpEdit_HomeRoom2.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmpty_lookUpEdit_HomeRoom2.ErrorText = "Home room 2 please !";

            ConditionValidationRule notEquals_spinEdit_TemperatureRequire = new ConditionValidationRule();
            notEquals_spinEdit_TemperatureRequire.ConditionOperator = ConditionOperator.NotEquals;
            notEquals_spinEdit_TemperatureRequire.Value1 = 0;
            notEquals_spinEdit_TemperatureRequire.ErrorText = "Temperature please !";
            //notEquals_spinEdit_TemperatureRequire.ErrorType = ErrorType.Information;

            ConditionValidationRule notEquals_spinEdit_PackagesPerPallet = new ConditionValidationRule();
            notEquals_spinEdit_PackagesPerPallet.ConditionOperator = ConditionOperator.LessOrEqual;
            notEquals_spinEdit_PackagesPerPallet.Value1 = 0;
            notEquals_spinEdit_PackagesPerPallet.ErrorText = "Number of Packages per Pallet cannot be below Zero !";
            //notEquals_spinEdit_PackagesPerPallet.ErrorType = ErrorType.Information;

            ConditionValidationRule notEquals_spinEdit_WeightPerPackage = new ConditionValidationRule();
            notEquals_spinEdit_PackagesPerPallet.ConditionOperator = ConditionOperator.Less;
            notEquals_spinEdit_PackagesPerPallet.Value1 = 2000;
            notEquals_spinEdit_PackagesPerPallet.ErrorText = "Weight of package cannot be greater than 2 tons. Please re-enter !";
            //notEquals_spinEdit_PackagesPerPallet.ErrorType = ErrorType.Information;

            dxValidationProvider.SetValidationRule(lookUpEdit_CustomerID, notEmpty_lookUpEdit_CustomerID);
            dxValidationProvider.SetValidationRule(txtEdit_ProductNumber, notEmpty_txtEdit_ProductNumber);
            dxValidationProvider.SetValidationRule(txtEdit_ProductName, notEmpty_txtEdit_ProductName);
            dxValidationProvider.SetValidationRule(lookUpEdit_Packages, notEmpty_lookUpEdit_Packages);
            dxValidationProvider.SetValidationRule(lookUpEdit_CustomerProductGroups, notEmpty_lookUpEdit_CustomerProductGroups);
            dxValidationProvider.SetValidationRule(spinEdit_TemperatureRequire, notEquals_spinEdit_TemperatureRequire);
            dxValidationProvider.SetValidationRule(spinEdit_PackagesPerPallet, notEquals_spinEdit_PackagesPerPallet);
            dxValidationProvider.SetValidationRule(spinEdit_WeightPerPackage, notEquals_spinEdit_WeightPerPackage);
            dxValidationProvider.SetValidationRule(lookUpEdit_HomeRoom1, notEmpty_lookUpEdit_HomeRoom1);
            dxValidationProvider.SetValidationRule(lookUpEdit_HomeRoom2, notEmpty_lookUpEdit_HomeRoom2);
        }
        private bool ValidateInputData()
        {
            bool v_ret = true;

            if (!this.dxValidationProvider.Validate()) { return false; }
            if (string.IsNullOrEmpty(Convert.ToString(lookUpEdit_CustomerID.EditValue)))
            {
                XtraMessageBox.Show("Customer please !", "WMS");
                lookUpEdit_CustomerID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEdit_ProductNumber.Text))
            {
                XtraMessageBox.Show("Product ID please !", "WMS");
                txtEdit_ProductNumber.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEdit_ProductName.Text))
            {
                XtraMessageBox.Show("Product Name please !", "WMS");
                txtEdit_ProductName.Focus();
                return false;
            }
            else if (spinEdit_TemperatureRequire.Value == 0)
            {
                XtraMessageBox.Show("Temperature please !", "WMS");
                spinEdit_TemperatureRequire.Focus();
                return false;
            }
            else if (spinEdit_PackagesPerPallet.Value == 0)
            {
                XtraMessageBox.Show("Package per pallet please !", "WMS");
                spinEdit_PackagesPerPallet.Focus();
                return false;
            }
            else if (spinEdit_WeightPerPackage.Value > 2000)
            {
                XtraMessageBox.Show("ERROR: Weight of package cannot be greater than 2 tons. Please re-enter !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                spinEdit_WeightPerPackage.Focus();
                return false;
            }
            else if (spinEdit_PackagesPerPallet.Value <= 0)
            {
                XtraMessageBox.Show("Number of Packages per Pallet cannot be below Zero", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                spinEdit_PackagesPerPallet.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEdit_ProductNumber.Text))
            {
                XtraMessageBox.Show("Product ID is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEdit_ProductNumber.Focus();
                return false;
            }
            else if (lookUpEdit_CustomerProductGroups.EditValue == null)
            {
                XtraMessageBox.Show("Product category is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lookUpEdit_CustomerProductGroups.Focus();
                return false;
            }
            else if ((LocationsHome)lookUpEdit_HomeRoom1.GetSelectedDataRow() == null)
            {
                XtraMessageBox.Show("Location Home 1 is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lookUpEdit_HomeRoom1.Focus();
                return false;

            }
            else if ((LocationsHome)lookUpEdit_HomeRoom2.GetSelectedDataRow() == null)
            {
                XtraMessageBox.Show("Location Home 2 is not correct !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lookUpEdit_HomeRoom2.Focus();
                return false;
            }
            return v_ret;

        }

        void AddNewRecord()
        {
            if (obj_Product != null)
            {
                m_Old_ProductID = obj_Product.ProductID;
            }
            this.isAddNew = true;
            obj_Product = new DA.Products();
            this.obj_Product.CreatedTime = DateTime.Now;
            this.obj_Product.CreatedBy = AppSetting.CurrentUser.LoginName;
            this.obj_Product.CustomerID = this.customerID;
            GetObjectInfo();

            SetEnableButton(CActionForm.New);

            lookUpEdit_CustomerID.Focus();
            lookUpEdit_CustomerID.ShowPopup();
        }
        void LoadRecordProducts(int i_TypeLoad, int i_Index, int i_ProductID)
        {
            IList<DA.ST_WMS_LoadRecordProductData_Result> result = (new DataProcess<ST_WMS_LoadRecordProductData_Result>()).Executing("ST_WMS_LoadRecordProductData  @TypeLoad = {0},@Index = {1},@ProductID ={2}", i_TypeLoad, i_Index, i_ProductID).ToList();
            m_LoadRecordProductData = result[0];
            if (this.m_LoadRecordProductData != null) this.Text = this.m_LoadRecordProductData.ProductNumber + " - " + this.m_LoadRecordProductData.ProductName;

            obj_Product = new Products();

            obj_Product.ProductID = Convert.ToInt32(m_LoadRecordProductData.ProductID);

            this.txtProductID.Text = Convert.ToString(obj_Product.ProductID);


            try
            {
                txtEdit_ProductName.EditValue = obj_Product.ProductName = m_LoadRecordProductData.ProductName;
            }
            catch
            {
                txtEdit_ProductName.EditValue = obj_Product.ProductName = string.Empty;
            }
            txtSubCode.EditValue = obj_Product.SubCode = m_LoadRecordProductData.SubCode;

            try
            {
                txtEdit_InitialLabel.EditValue = obj_Product.ProductNumber = Convert.ToString(m_LoadRecordProductData.ProductNumber).Substring(0, 4);
                txtEdit_ProductNumber.EditValue = obj_Product.ProductNumber = Convert.ToString(m_LoadRecordProductData.ProductNumber).Substring(4);
            }
            catch
            {
                txtEdit_InitialLabel.EditValue = obj_Product.ProductNumber = string.Empty;
                txtEdit_ProductNumber.EditValue = obj_Product.ProductNumber = string.Empty;
            }

            this.txtBoxSize.Text = m_LoadRecordProductData.SizeBox;
            txtEdit_ProductNameVN.EditValue = obj_Product.ProductNameVN = m_LoadRecordProductData.ProductNameVN;
            txtEdit_Remark.EditValue = obj_Product.Remark = m_LoadRecordProductData.Remark;
            txtEdit_GTIN.EditValue = obj_Product.GTIN;//= m_LoadRecordProductData.GTIN;
            lookUpEdit_CustomerID.EditValue = obj_Product.CustomerID = Convert.ToInt32(m_LoadRecordProductData.CustomerID);

            txtEdit_Origin.EditValue = obj_Product.Origin = m_LoadRecordProductData.Origin;
            lookUpEdit_ProductCategoryID.EditValue = obj_Product.ProductCategoryID = m_LoadRecordProductData.ProductCategoryID;
            lookUpEdit_HomeRoom1.EditValue = obj_Product.HomeRoom1 = m_LoadRecordProductData.HomeRoom1;
            lookUpEdit_HomeRoom2.EditValue = obj_Product.HomeRoom2 = m_LoadRecordProductData.HomeRoom2;

            txtEdit_CustomerName.EditValue = m_LoadRecordProductData.CustomerName;


            try
            {
                radGroup_PickingMethod.EditValue = obj_Product.PickingMethod = Convert.ToBoolean(m_LoadRecordProductData.PickingMethod);
            }
            catch { }


            try
            {
                chkEdit_IsAllowLocationChange.Checked = Convert.ToBoolean(m_LoadRecordProductData.IsAllowLocationChange);
                obj_Product.IsAllowLocationChange = Convert.ToBoolean(m_LoadRecordProductData.IsAllowLocationChange);
            }
            catch
            {
                chkEdit_IsAllowLocationChange.Checked = false;
                obj_Product.IsAllowLocationChange = false;
            }

            try
            {
                chkEdit_IsWeightingRequire.Checked = Convert.ToBoolean(m_LoadRecordProductData.IsWeightingRequire);
                obj_Product.IsWeightingRequire = Convert.ToBoolean(m_LoadRecordProductData.IsWeightingRequire);
            }
            catch
            {
                chkEdit_IsWeightingRequire.Checked = false;
                obj_Product.IsWeightingRequire = false;
            }
            try
            {
                chkEdit_Discontinue.Checked = Convert.ToBoolean(m_LoadRecordProductData.Discontinue);
                obj_Product.Discontinue = Convert.ToBoolean(m_LoadRecordProductData.Discontinue);
            }
            catch
            {
                chkEdit_Discontinue.Checked = false;
                obj_Product.Discontinue = false;
            }

            try
            {
                spinEdit_CBM.Value = Convert.ToInt32(m_LoadRecordProductData.CBM);
                obj_Product.CBM = Convert.ToInt32(m_LoadRecordProductData.CBM);
            }
            catch
            {
                spinEdit_CBM.Value = 0;
                obj_Product.CBM = 0;
            }

            try
            {
                spinEdit_Inners.Value = Convert.ToDecimal(m_LoadRecordProductData.Inners);
                obj_Product.Inners = m_LoadRecordProductData.Inners;
            }
            catch
            {
                spinEdit_Inners.Value = 0;
                obj_Product.Inners = 0;
            }
            try
            {
                spPcs.Value = Convert.ToInt32(m_LoadRecordProductData.Pcs);
                obj_Product.Pcs = Convert.ToInt16(m_LoadRecordProductData.Pcs);
            }
            catch
            {
                spPcs.Value = 0;
                obj_Product.Pcs = 0;
            }


            try
            {
                txtEdit_CreatedBy.EditValue = obj_Product.CreatedBy = m_LoadRecordProductData.CreatedBy;
            }
            catch
            {
                txtEdit_CreatedBy.EditValue = string.Empty;
                obj_Product.CreatedBy = string.Empty;
            }

            try
            {
                dateEdit_CreatedTime.EditValue = obj_Product.CreatedTime = m_LoadRecordProductData.CreatedTime;
            }
            catch
            {
                dateEdit_CreatedTime.EditValue = string.Empty;
                obj_Product.CreatedTime = m_LoadRecordProductData.CreatedTime;
            }

            try
            {
                spinEdit_TemperatureRequire.Value = Convert.ToDecimal(m_LoadRecordProductData.TemperatureRequire);
                obj_Product.TemperatureRequire = (float)m_LoadRecordProductData.TemperatureRequire;
            }
            catch
            {
                spinEdit_TemperatureRequire.Value = 0;
                obj_Product.TemperatureRequire = 0;
            }

            this.lke_PackageTypes.EditValue = m_LoadRecordProductData.QuyCach;

            //this.spinEdit_CartonUnitConversion.EditValue = m_LoadRecordProductData.Pcs;
            this.lke_WM_Products.EditValue = m_LoadRecordProductData.ProductMainID;
            this.spinEdit_SafetyStock.EditValue = m_LoadRecordProductData.SafetyStock;
            this.spinEdit_SelfLifeDays.EditValue = m_LoadRecordProductData.SelfLifeDays;


            try
            {
                spinEdit_WarningDaysBeforeExpiry.Value = Convert.ToDecimal(m_LoadRecordProductData.WarningDaysBeforeExpiry);
                obj_Product.WarningDaysBeforeExpiry = (short)m_LoadRecordProductData.WarningDaysBeforeExpiry;
            }
            catch
            {
                spinEdit_WarningDaysBeforeExpiry.Value = 0;
                obj_Product.WarningDaysBeforeExpiry = 0;
            }

            try
            {
                spinEdit_WeightPerPackage.Value = Convert.ToDecimal(m_LoadRecordProductData.WeightPerPackage);
            }
            catch
            {
                spinEdit_WeightPerPackage.Value = 0;
                obj_Product.WeightPerPackage = 0;
            }
            this.spinEdit_Net.EditValue = m_LoadRecordProductData.Net;
            this.chkEdit_IsGetNet.EditValue = m_LoadRecordProductData.IsNet;

            try
            {
                spinEdit_GrossWeightPerPackage.Value = Convert.ToDecimal(m_LoadRecordProductData.GrossWeightPerPackage);
                obj_Product.GrossWeightPerPackage = Convert.ToDecimal(m_LoadRecordProductData.GrossWeightPerPackage);
            }
            catch
            {
                spinEdit_GrossWeightPerPackage.Value = 0;
                obj_Product.GrossWeightPerPackage = 0;
            }

            try
            {
                spinEdit_PackagesPerPallet.Value = Convert.ToDecimal(m_LoadRecordProductData.PackagesPerPallet);
                obj_Product.PackagesPerPallet = (short)m_LoadRecordProductData.PackagesPerPallet;
            }
            catch
            {
                spinEdit_PackagesPerPallet.Value = 0;
                obj_Product.PackagesPerPallet = 0;
            }

            try
            {
                spinEdit_PackagesPerPallet2.Value = Convert.ToDecimal(m_LoadRecordProductData.PackagesPerPallet2);
                obj_Product.PackagesPerPallet2 = (short)m_LoadRecordProductData.PackagesPerPallet2;
            }
            catch
            {
                spinEdit_PackagesPerPallet2.Value = 0;
            }

            if (m_LoadRecordProductData.Packages != null)
                lookUpEdit_Packages.EditValue = m_LoadRecordProductData.Packages;
            else
                lookUpEdit_Packages.EditValue = 0;
            this.txtERP.Text = m_LoadRecordProductData.ERPUnit;
            if (m_LoadRecordProductData.Pcs != null)
                spPcs.Value = Convert.ToInt32(m_LoadRecordProductData.Pcs);
            else
                spPcs.Value = 0;
        }
        void SetEnableButton(int i_ActionControlForm)
        {
            #region LoadForm

            if (i_ActionControlForm.Equals(CActionForm.LoadForm))
            {
                if (obj_Product.ProductID > 0)
                {
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = true;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnEdit.Text = "Edit";
                    isEditing = false;
                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    if (Convert.ToBoolean(this.chkEdit_Discontinue.EditValue))
                    {
                        this.labelControlStopStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                        this.btnStop.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
                        this.btnStop.Text = "Reuse Product";

                    }
                    else
                    {
                        this.labelControlStopStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                        this.btnStop.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                        this.btnStop.Text = "Stop Product";
                    }


                    SetEnableDisableControl(false);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);
                }
            }
            #endregion LoadForm

            #region AddNew

            else if (i_ActionControlForm.Equals(CActionForm.New))
            {
                if (obj_Product.ProductID <= 0)
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;

                    //
                    //btnEdit.Enabled = false;
                    btnEdit.Enabled = true;
                    btnEdit.Text = "Save";
                    isEditing = true;
                    //
                    btnNew.Enabled = false;
                    btnCancel.Enabled = true;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;


                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(true);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    //btnSave.Enabled = false;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    btnPalletInfo.Enabled = false;
                    btnProductList.Enabled = false;
                    btnUpdateOrder.Enabled = false;

                    SetEnableDisableControl(false);

                    XtraMessageBox.Show("Lỗi hệ thống");
                }

            }

            #endregion AddNew

            #region Edit

            else if (i_ActionControlForm.Equals(CActionForm.Edit))
            {
                if (obj_Product.ProductID > 0)
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = false;
                    btnEdit.Text = "Save";
                    this.isEditing = true;
                    ////btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(true);

                    // Validate UserApplication
                    this.CheckRoleUser();
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    btnEdit.Text = "Edit";
                    //btnSave.Enabled = false;
                    //btnCancel.Hide();
                    this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    btnPalletInfo.Enabled = false;
                    btnProductList.Enabled = false;
                    btnUpdateOrder.Enabled = false;

                    SetEnableDisableControl(false);

                    XtraMessageBox.Show("Lỗi hệ thống.");
                }

            }
            #endregion Edit

            #region Delete

            else if (i_ActionControlForm.Equals(CActionForm.Delete))
            {
                if (obj_Product.ProductID > 0)
                {
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = true;
                    //btnSave.Enabled = true;
                    this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    //btnSave.Enabled = true;
                    btnCancel.Enabled = true;

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);
                }
            }
            #endregion Delete

            #region Save

            else if (i_ActionControlForm.Equals(CActionForm.Save))
            {
                if (obj_Product.ProductID > 0)
                {
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = true;
                    //btnSave.Enabled = true;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnEdit.Text = "Edit";

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    if (Convert.ToBoolean(this.chkEdit_Discontinue.EditValue))
                    {
                        this.labelControlStopStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                        this.btnStop.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
                        this.btnStop.Text = "Reuse Product";

                    }
                    else
                    {
                        this.labelControlStopStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                        this.btnStop.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                        this.btnStop.Text = "Stop Product";
                    }

                    SetEnableDisableControl(false);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    //btnSave.Enabled = false;
                    btnCancel.Hide();
                    btnEdit.Text = "Save";
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);

                    XtraMessageBox.Show("Lỗi hệ thống.", "WMS");
                }
            }
            #endregion Save

            #region Copy

            else if (i_ActionControlForm.Equals(CActionForm.Copy))
            {
                if (obj_Product.ProductID <= 0)
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    //
                    //btnEdit.Enabled = false;
                    btnEdit.Enabled = true;
                    isEditing = true;
                    //

                    btnNew.Enabled = false;
                    //btnSave.Enabled = true;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnEdit.Text = "Save";
                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(true);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    //btnSave.Enabled = false;
                    layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);

                    XtraMessageBox.Show("Lỗi hệ thống.", "WMS");
                }
            }
            #endregion Copy

            #region Cancel

            else if (i_ActionControlForm.Equals(CActionForm.Cancel))
            {
                if (obj_Product.ProductID > 0)
                {
                    btnCopy.Enabled = true;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnNew.Enabled = true;
                    //btnSave.Enabled = true;
                    this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnEdit.Text = "Edit";
                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);
                }
                else
                {
                    btnCopy.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnNew.Enabled = false;
                    //btnSave.Enabled = true;
                    this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnEdit.Text = "Save";
                    btnPalletInfo.Enabled = true;
                    btnProductList.Enabled = true;
                    btnUpdateOrder.Enabled = true;

                    SetEnableDisableControl(false);
                }
            }
            #endregion Cancel

            #region Other

            else
            {
                btnCopy.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnNew.Enabled = false;
                //btnSave.Enabled = true;
                layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                btnPalletInfo.Enabled = true;
                btnProductList.Enabled = true;
                btnUpdateOrder.Enabled = true;

                SetEnableDisableControl(false);
            }

            #endregion Other
        }

        private void CheckRoleUser()
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return;
            }
            int userApplicationID = Convert.ToInt32(isExistApplication.Rows[0]["UserApplicationId"]);
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of accounting , if user is accounting then not allow change weight
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=4");
            if (departmentRole == null || departmentRole.Count() <= 0) return;
            DateTime proCreatedDate = this.dateEdit_CreatedTime.DateTime;
            TimeSpan interval = DateTime.Now.Subtract(proCreatedDate);
            // this product has created recently then allow edit it
            if (interval.Days <= 7) return;
            if (interval.Days > 30)
            {
                // Product has creaded more than 30 days then can not change weight value
                this.spinEdit_WeightPerPackage.ReadOnly = true;
                this.spinEdit_Net.ReadOnly = true;
                this.chkEdit_IsGetNet.ReadOnly = true;
                this.spinEdit_GrossWeightPerPackage.ReadOnly = true;
                return;
            }
            foreach (var row in departmentRole)
            {
                int level = Convert.ToInt32(row["LevelDepartment"]);
                if (level > 2)
                {
                    //this.curre
                    return;
                }
            }
            // Account has level less more than or equal is User in Operation department then can not change weight value
            this.spinEdit_WeightPerPackage.ReadOnly = true;
            this.spinEdit_Net.ReadOnly = true;
            this.chkEdit_IsGetNet.ReadOnly = true;
            this.spinEdit_GrossWeightPerPackage.ReadOnly = true;
        }
        void SetEnableDisableControl(bool enable)
        {
            enable = !enable;
            lookUpEdit_CustomerID.ReadOnly = enable;
            txtEdit_ProductNumber.ReadOnly = enable;
            txtSubCode.ReadOnly = enable;
            txtEdit_ProductName.ReadOnly = enable;
            txtEdit_ProductNameVN.ReadOnly = enable;
            this.txtBoxSize.ReadOnly = enable;

            lookUpEdit_ProductCategoryID.ReadOnly = enable;
            lookUpEdit_WAREHOUSE_NO.ReadOnly = enable;
            txtERP.ReadOnly = enable;
            txtEdit_Origin.ReadOnly = enable;
            spinEdit_TemperatureRequire.ReadOnly = enable;
            this.lke_PackageTypes.ReadOnly = enable;
            //this.spinEdit_CartonUnitConversion.ReadOnly = enable;
            this.lke_WM_Products.ReadOnly = enable;
            this.spinEdit_SafetyStock.ReadOnly = enable;
            this.spinEdit_SelfLifeDays.ReadOnly = enable;
            spinEdit_WarningDaysBeforeExpiry.ReadOnly = enable;
            //spinEdit_WeightPerPackage.ReadOnly = enable;
            this.spinEdit_Net.ReadOnly = enable;
            this.chkEdit_IsGetNet.ReadOnly = enable;
            this.spinEdit_GrossWeightPerPackage.ReadOnly = enable;
            lookUpEdit_Packages.ReadOnly = enable;
            spinEdit_PackagesPerPallet.ReadOnly = enable;
            spinEdit_PackagesPerPallet2.ReadOnly = enable;
            spinEdit_Inners.ReadOnly = enable;
            spPcs.ReadOnly = enable;
            lookUpEdit_CustomerProductGroups.ReadOnly = enable;
            spinEdit_CBM.ReadOnly = enable;
            chkEdit_IsAllowLocationChange.ReadOnly = enable;
            chkEdit_IsWeightingRequire.ReadOnly = enable;
            lookUpEdit_HomeRoom1.ReadOnly = enable;
            lookUpEdit_HomeRoom2.ReadOnly = enable;
            radGroup_PickingMethod.ReadOnly = enable;
            lookUpEdit_PickingLocation.ReadOnly = enable;
            txtEdit_Remark.ReadOnly = enable;
            txtEdit_GTIN.ReadOnly = enable;
            chkEdit_Discontinue.ReadOnly = enable;
        }

        #region LoadData
        void LoadData2lookUpEdit_Packages()
        {
            DataTable v_dt = new DataTable();

            v_dt.Columns.Add("ID", typeof(int));
            v_dt.Columns.Add("Code", typeof(string));
            v_dt.Columns.Add("Name", typeof(string));

            DataRow v_drow = v_dt.NewRow();
            v_drow["ID"] = 1;
            v_drow["Code"] = "Ctns";
            v_drow["Name"] = "Ctns";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 2;
            v_drow["Code"] = "KGR";
            v_drow["Name"] = "KGR";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 3;
            v_drow["Code"] = "UN";
            v_drow["Name"] = "UN";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 4;
            v_drow["Code"] = CustomerTypeEnum.PCS;
            v_drow["Name"] = CustomerTypeEnum.PCS;
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 5;
            v_drow["Code"] = "Plts";
            v_drow["Name"] = "Plts";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 6;
            v_drow["Code"] = "Lit";
            v_drow["Name"] = "Lit";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 7;
            v_drow["Code"] = "Bun";
            v_drow["Name"] = "Bun";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 8;
            v_drow["Code"] = "KGX";
            v_drow["Name"] = "KGX";
            v_dt.Rows.Add(v_drow);

            lookUpEdit_Packages.Properties.DataSource = v_dt;
            lookUpEdit_Packages.Properties.DropDownRows = v_dt.Rows.Count;
            this.rpi_lke_PackagesList.DataSource = v_dt;

            //lookUpEdit_Packages.EditValue = v_dt.Rows[0]["Code"];

            lookUpEdit_Packages.Properties.DisplayMember = "Code";
            lookUpEdit_Packages.Properties.ValueMember = "Code";
            if (this.productSelected != null)
            {
                lookUpEdit_Packages.EditValue = this.productSelected.Packages;
            }
        }
        void LoadData2lookUpEdit_HomeRoom1()
        {
            DataProcess<LocationsHome> obj_LocationsHomeDA = new DataProcess<LocationsHome>();
            List<LocationsHome> List_LocationsHome = obj_LocationsHomeDA.Select(l => l.StoreID == AppSetting.StoreID).ToList();
            lookUpEdit_HomeRoom1.Properties.DataSource = List_LocationsHome;
            lookUpEdit_HomeRoom1.Properties.DisplayMember = "RoomID";
            lookUpEdit_HomeRoom1.Properties.ValueMember = "LocationID";
            lookUpEdit_HomeRoom1.Properties.DropDownRows = List_LocationsHome.Count;
            if (List_LocationsHome.Count >= 20)
            {
                lookUpEdit_HomeRoom1.Properties.DropDownRows = 20;
            }
            if (this.productSelected != null)
            {
                lookUpEdit_HomeRoom1.EditValue = this.productSelected.HomeLocation1;
            }
        }
        void LoadData2lookUpEdit_HomeRoom2()
        {
            DataProcess<LocationsHome> obj_LocationsHomeDA = new DataProcess<LocationsHome>();
            List<LocationsHome> List_LocationsHome = obj_LocationsHomeDA.Select(l => l.StoreID == AppSetting.StoreID).ToList();
            lookUpEdit_HomeRoom2.Properties.DataSource = List_LocationsHome;
            lookUpEdit_HomeRoom2.Properties.DisplayMember = "RoomID";
            lookUpEdit_HomeRoom2.Properties.ValueMember = "LocationID";
            lookUpEdit_HomeRoom2.Properties.DropDownRows = List_LocationsHome.Count;
            if (List_LocationsHome.Count >= 20)
            {
                lookUpEdit_HomeRoom2.Properties.DropDownRows = 20;
            }
            if (this.productSelected != null)
            {
                lookUpEdit_HomeRoom2.EditValue = this.productSelected.HomeLocation2;
            }
        }
        void LoadData2lookUpEdit_WAREHOUSE_NO()
        {
            DataTable v_dt = new DataTable();

            v_dt.Columns.Add("ID", typeof(int));
            v_dt.Columns.Add("Code", typeof(string));
            v_dt.Columns.Add("Name", typeof(string));

            DataRow v_drow = v_dt.NewRow();
            v_drow["ID"] = 85;
            v_drow["Code"] = "85";
            v_drow["Name"] = "85";
            v_dt.Rows.Add(v_drow);

            v_drow = v_dt.NewRow();
            v_drow["ID"] = 86;
            v_drow["Code"] = "86";
            v_drow["Name"] = "86";
            v_dt.Rows.Add(v_drow);

            lookUpEdit_WAREHOUSE_NO.Properties.DataSource = v_dt;
            lookUpEdit_WAREHOUSE_NO.Properties.DropDownRows = v_dt.Rows.Count;

            //lookUpEdit_WAREHOUSE_NO.EditValue = v_dt.Rows[0]["Code"];

            lookUpEdit_WAREHOUSE_NO.Properties.ValueMember = "ID";
            lookUpEdit_WAREHOUSE_NO.Properties.DisplayMember = "Code";
            if (this.productSelected != null)
            {
                lookUpEdit_WAREHOUSE_NO.EditValue = this.productSelected.WAREHOUSE_NO;
            }
        }

        private void LoadProductImages()
        {
            DataProcess<STAttachmentView_Result> attachmentDA = new DataProcess<STAttachmentView_Result>();
            IEnumerable<STAttachmentView_Result> dataSource = null;
            this.imgSld_Products.Images.Clear();

            string productID = "PR-" + this.txtProductID.Text;
            dataSource = attachmentDA.Executing("STAttachmentView @OrderNumber = {0}", productID);
            if (dataSource == null || dataSource.Count() <= 0) return;

            // Add image into slider datasource
            string path = ConfigurationManager.AppSettings["PathPasteFile"];
            string attachmentFile = string.Empty;
            foreach (var attach in dataSource)
            {
                attachmentFile = path + "\\" + attach.AttachmentFile;
                if (!File.Exists(attachmentFile)) continue;

                string fileExtension = Path.GetExtension(attachmentFile);
                switch (fileExtension.ToUpper())
                {
                    //Image
                    case ".JPG":
                    case ".PNG":
                    case ".JPEG":
                    case ".GIF":
                    case ".ICO":
                        this.imgSld_Products.Images.Add(Image.FromFile(attachmentFile));
                        break;
                    default:
                        break;
                }
            }
        }

        void LoadData2lookUpEdit_PickingLocation()
        {
            DataProcess<STComboLocationIDPicking_Result> v_Da = new DataProcess<STComboLocationIDPicking_Result>();
            var listPickingLocation = v_Da.Executing("STComboLocationIDPicking").ToList();
            lookUpEdit_PickingLocation.Properties.DataSource = listPickingLocation;
            lookUpEdit_PickingLocation.Properties.ValueMember = "LocationID";
            lookUpEdit_PickingLocation.Properties.DisplayMember = "Z";
            lookUpEdit_PickingLocation.Properties.DropDownRows = listPickingLocation.Count;
            if (listPickingLocation.Count >= 20)
            {
                lookUpEdit_PickingLocation.Properties.DropDownRows = 20;
            }
            if (this.productSelected != null)
            {
                lookUpEdit_PickingLocation.EditValue = this.productSelected.PickingLocation;
            }
        }
        void LoadData2LookUpEdit_ProductCategory()
        {
            DataProcess<ProductCategories> obj_ProductCategoriesDA = new DataProcess<ProductCategories>();
            List<ProductCategories> ListProductCategories = obj_ProductCategoriesDA.Select().ToList();

            lookUpEdit_ProductCategoryID.Properties.DataSource = ListProductCategories;
            lookUpEdit_ProductCategoryID.Properties.DisplayMember = "ProductCategoryDescription";
            lookUpEdit_ProductCategoryID.Properties.ValueMember = "ProductCategoryID";
            if (ListProductCategories.Count >= 20)
            {
                lookUpEdit_ProductCategoryID.Properties.DropDownRows = 20;
            }
            else
            {
                lookUpEdit_ProductCategoryID.Properties.DropDownRows = ListProductCategories.Count;
            }
            if (this.productSelected != null)
            {
                lookUpEdit_ProductCategoryID.EditValue = Convert.ToByte(this.productSelected.ProductCategoryID);
            }
        }
        void LoadData2LookUpEdit_CustomerProductGroups(int customerID)
        {
            DataProcess<CustomerProductGroups> obj_CustomerProductGroupsDA = new DataProcess<CustomerProductGroups>();
            List<CustomerProductGroups> List_CustomerProductGroups = obj_CustomerProductGroupsDA.Select(c => c.CustomerID == customerID).ToList();

            lookUpEdit_CustomerProductGroups.Properties.DataSource = List_CustomerProductGroups;

            //lookUpEdit_CustomerProductGroups.EditValue = List_CustomerProductGroups[0].ProductGroupID;

            lookUpEdit_CustomerProductGroups.Properties.DisplayMember = "ProductGroupDescription";
            lookUpEdit_CustomerProductGroups.Properties.ValueMember = "ProductGroupID";
            if (this.productSelected != null)
            {
                lookUpEdit_CustomerProductGroups.EditValue = this.productSelected.ProductCategory;
            }

            if (this.isAddNew)
            {
                if (List_CustomerProductGroups.Count > 0)
                {
                    lookUpEdit_CustomerProductGroups.EditValue = List_CustomerProductGroups[0].ProductGroupID;
                    this.obj_Product.ProductCategory = List_CustomerProductGroups[0].ProductGroupID;
                    if (this.productSelected != null)
                        this.productSelected.ProductCategory = List_CustomerProductGroups[0].ProductGroupID;
                }
            }
        }

        #endregion LoadData

        void LoadData2LookUpEdit_Customers()
        {
            try
            {
                Wait.Start(this);
                Common.Process.RefreshData.Refresh(this.lookUpEdit_CustomerID, () =>
                {
                    lookUpEdit_CustomerID.Properties.DataSource = UI.Helper.AppSetting.CustomerList;
                    lookUpEdit_CustomerID.Properties.DropDownRows = 20;
                    lookUpEdit_CustomerID.Properties.DisplayMember = "CustomerNumber";
                    lookUpEdit_CustomerID.Properties.ValueMember = "CustomerID";
                    if (this.productSelected != null)
                    {
                        lookUpEdit_CustomerID.EditValue = this.productSelected.CustomerID;
                    }
                });

                Common.Process.RefreshData.Refresh(this.txtEdit_CustomerName, () =>
                {
                    txtEdit_CustomerName.Text = ((IEnumerable<Customers>)lookUpEdit_CustomerID.Properties.DataSource).FirstOrDefault().CustomerName;
                });

            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                Wait.Close();
                MessageBox.Show(ex.Message, "Error is unexpected");
            }
            finally
            {
                Wait.Close();
            }
        }

        void GetObjectInfo()
        {
            if (obj_Product.ProductNumber != null)
            {
                txtEdit_InitialLabel.Text = obj_Product.ProductNumber.Substring(0, 4);
                txtEdit_ProductNumber.Text = obj_Product.ProductNumber.Substring(4);
            }
            else
            {
                txtEdit_InitialLabel.Text = string.Empty;
                txtEdit_ProductNumber.Text = string.Empty;
            }

            if (obj_Product.ProductName != null)
                txtEdit_ProductName.Text = obj_Product.ProductName;
            else
                txtEdit_ProductName.Text = string.Empty;

            this.txtSubCode.EditValue = obj_Product.SubCode;

            if (obj_Product.ProductNameVN != null)
                txtEdit_ProductNameVN.Text = obj_Product.ProductNameVN;
            else
                txtEdit_ProductNameVN.Text = string.Empty;

            this.txtBoxSize.Text = obj_Product.SizeBox;
            this.txtProductID.Text = Convert.ToString(obj_Product.ProductID);

            if (obj_Product.ProductCategoryID != null)
                lookUpEdit_ProductCategoryID.EditValue = obj_Product.ProductCategoryID;
            else
                lookUpEdit_ProductCategoryID.EditValue = 0;

            if (obj_Product.Origin != null)
                txtEdit_Origin.Text = obj_Product.Origin;
            else
                txtEdit_Origin.Text = string.Empty;

            if (obj_Product.TemperatureRequire != null)
                spinEdit_TemperatureRequire.Value = Convert.ToInt32(obj_Product.TemperatureRequire);
            else
                spinEdit_TemperatureRequire.EditValue = null;
            this.lke_PackageTypes.EditValue = obj_Product.QuyCach;
            //this.spinEdit_CartonUnitConversion.EditValue = obj_Product.Pcs;
            this.lke_WM_Products.EditValue = obj_Product.ProductMainID;
            this.spinEdit_SafetyStock.EditValue = obj_Product.SafetyStock;
            this.spinEdit_SelfLifeDays.EditValue = obj_Product.SelfLifeDays;

            if (obj_Product.WarningDaysBeforeExpiry != null)
                spinEdit_WarningDaysBeforeExpiry.Value = Convert.ToInt32(obj_Product.WarningDaysBeforeExpiry);
            else
                spinEdit_WarningDaysBeforeExpiry.Value = 0;

            if (obj_Product.WeightPerPackage != null)
                spinEdit_WeightPerPackage.Value = (decimal)obj_Product.WeightPerPackage;
            else
                spinEdit_WeightPerPackage.EditValue = null;

            this.spinEdit_Net.EditValue = obj_Product.Net;
            this.chkEdit_IsGetNet.EditValue = obj_Product.IsNet;

            if (obj_Product.GrossWeightPerPackage != null)
                spinEdit_GrossWeightPerPackage.Value = (decimal)obj_Product.GrossWeightPerPackage;
            else
                spinEdit_GrossWeightPerPackage.Value = 0;

            if (obj_Product.Packages != null)
                lookUpEdit_Packages.EditValue = obj_Product.Packages;
            else
                lookUpEdit_Packages.EditValue = 0;

            if (obj_Product.PackagesPerPallet != null)
                spinEdit_PackagesPerPallet.Value = Convert.ToInt32(obj_Product.PackagesPerPallet);
            else
                spinEdit_PackagesPerPallet.Value = 0;


            if (obj_Product.PackagesPerPallet2 != null)
                spinEdit_PackagesPerPallet2.Value = Convert.ToInt32(obj_Product.PackagesPerPallet2);
            else
                spinEdit_PackagesPerPallet2.Value = 0;

            if (obj_Product.Inners != null)
                spinEdit_Inners.Value = Convert.ToInt32(obj_Product.Inners);
            else
                spinEdit_Inners.Value = 0;

            if (obj_Product.Pcs != null)
                spPcs.Value = Convert.ToInt32(obj_Product.Pcs);
            else
                spPcs.Value = 0;

            lookUpEdit_CustomerProductGroups.EditValue = obj_Product.ProductCategory;

            if (obj_Product.CBM != null)
                spinEdit_CBM.Value = Convert.ToInt32(obj_Product.CBM);
            else
                spinEdit_CBM.Value = 0;

            if (obj_Product.IsAllowLocationChange != null)
                chkEdit_IsAllowLocationChange.Checked = (bool)obj_Product.IsAllowLocationChange;
            else
                chkEdit_IsAllowLocationChange.Checked = false;

            if (obj_Product.IsWeightingRequire != null)
                chkEdit_IsWeightingRequire.Checked = (bool)obj_Product.IsWeightingRequire;
            else
                chkEdit_IsWeightingRequire.Checked = false;

            lookUpEdit_HomeRoom1.EditValue = obj_Product.HomeLocation1;
            lookUpEdit_HomeRoom2.EditValue = obj_Product.HomeLocation2;

            if (obj_Product.PickingMethod != null)
                radGroup_PickingMethod.EditValue = (bool)obj_Product.PickingMethod;


            if (obj_Product.PickingLocation != null)
                lookUpEdit_PickingLocation.EditValue = obj_Product.PickingLocation;
            else
                lookUpEdit_PickingLocation.EditValue = 0;

            if (obj_Product.Remark != null)
                txtEdit_Remark.Text = obj_Product.Remark;
            else
                txtEdit_Remark.Text = string.Empty;

            if (obj_Product.GTIN != null)
                txtEdit_GTIN.Text = obj_Product.GTIN;
            else
                txtEdit_GTIN.Text = string.Empty;

            if (obj_Product.CreatedBy != null)
                txtEdit_CreatedBy.Text = obj_Product.CreatedBy;
            else
                txtEdit_CreatedBy.Text = string.Empty;

            if (obj_Product.CreatedTime != null)
                dateEdit_CreatedTime.EditValue = obj_Product.CreatedTime;
            else
                dateEdit_CreatedTime.EditValue = string.Empty;

            lookUpEdit_CustomerID.EditValue = obj_Product.CustomerID;
            this.txtERP.Text = obj_Product.ERPUnit;

            // Load he so quy doi
            this.LoadProductMeasure();

            //Default value is active
            spinEdit_Net.Enabled = true;
            btnAddPackageType.Enabled = true;
            spinEdit_GrossWeightPerPackage.Enabled = true;
            spinEdit_PackagesPerPallet.Enabled = true;
            spinEdit_PackagesPerPallet2.Enabled = true;

            //Kiểm tra active sizebox, net,gross value khi đã có nhập xuất
            var dataRo = FileProcess.LoadTable("SP_CheckProductHasRecived @ProductID=" + this.obj_Product.ProductID);
            if(dataRo!=null && dataRo.Rows.Count>0)
            {
                var hasReceivedPro = Convert.ToInt32(dataRo.Rows[0]["HasExist"]);
                if(hasReceivedPro>0)
                {
                    spinEdit_Net.Enabled = false;
                    btnAddPackageType.Enabled = false;
                    spinEdit_GrossWeightPerPackage.Enabled = false;
                    spinEdit_PackagesPerPallet.Enabled = false;
                    spinEdit_PackagesPerPallet2.Enabled = false;
                }
            }
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void LoadProductMeasure()
        {
            if (this.obj_Product == null) return;
            DataProcess<DVTQuyCach> dataProcess1 = new DataProcess<DVTQuyCach>();
            this.rpi_lke_DVT.DataSource = dataProcess1.Select();
            this.rpi_lke_DVT.ValueMember = "DVTID";
            this.rpi_lke_DVT.DisplayMember = "TenDVT";

            DataProcess<ProductMeasure> dataProcess = new DataProcess<ProductMeasure>();
            var datasource = dataProcess.Select(pr => pr.ProductID == this.obj_Product.ProductID).ToList();
            if (dataProcess == null)
            {
                bdProductMeasure = new BindingList<ProductMeasure>();
            }
            else
            {
                bdProductMeasure = new BindingList<ProductMeasure>(datasource);
            }
            if (this.bdProductMeasure.Count(p => p.ProductMeasureID <= 0) <= 0)
            {
                this.bdProductMeasure.Add(new ProductMeasure());
                this.grvHeSoQuyDoi.RefreshData();
            }
            this.grdHeSoQuyDoi.DataSource = bdProductMeasure;

        }
        void SetObjectInfo()
        {
            obj_Product.CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            obj_Product.ProductNumber = txtEdit_InitialLabel.Text.Trim() + txtEdit_ProductNumber.Text.Trim();
            obj_Product.ProductNameVN = txtEdit_ProductNameVN.Text;
            obj_Product.SizeBox = this.txtBoxSize.Text;
            obj_Product.SubCode = this.txtSubCode.Text;
            obj_Product.ProductName = txtEdit_ProductName.Text.Trim();
            if (lookUpEdit_ProductCategoryID.EditValue != null)
            {
                obj_Product.ProductCategoryID = Convert.ToByte(lookUpEdit_ProductCategoryID.EditValue);
            }

            obj_Product.Origin = txtEdit_Origin.Text.Trim();
            obj_Product.TemperatureRequire = Convert.ToInt32(spinEdit_TemperatureRequire.Value);
            if (this.lke_PackageTypes.EditValue != null)
                obj_Product.QuyCach = Convert.ToInt32(this.lke_PackageTypes.EditValue);
            obj_Product.WarningDaysBeforeExpiry = Convert.ToInt16(spinEdit_WarningDaysBeforeExpiry.Value);
            obj_Product.WeightPerPackage = Convert.ToDecimal(spinEdit_WeightPerPackage.Value);
            obj_Product.IsNet = this.chkEdit_IsGetNet.Checked;
            if (this.spinEdit_Net.EditValue != null)
                obj_Product.Net = Convert.ToDecimal(this.spinEdit_Net.EditValue);
            obj_Product.GrossWeightPerPackage = Convert.ToDecimal(spinEdit_GrossWeightPerPackage.Value);
            //if (this.spinEdit_CartonUnitConversion.EditValue != null) obj_Product.Pcs = short.Parse(this.spinEdit_CartonUnitConversion.EditValue.ToString());
            if (this.lke_WM_Products.EditValue != null) obj_Product.ProductMainID = Convert.ToInt32(this.lke_WM_Products.EditValue);
            if (this.spinEdit_SafetyStock.EditValue != null) obj_Product.SafetyStock = Int32.Parse(this.spinEdit_SafetyStock.EditValue.ToString());
            if (this.spinEdit_SelfLifeDays.EditValue != null) obj_Product.SelfLifeDays = Int32.Parse(this.spinEdit_SelfLifeDays.EditValue.ToString());
            if (lookUpEdit_Packages.EditValue != null)
            {
                obj_Product.Packages = lookUpEdit_Packages.EditValue.ToString();
            }

            if (lookUpEdit_WAREHOUSE_NO.EditValue != null)
            {
                obj_Product.WAREHOUSE_NO = Convert.ToInt32(lookUpEdit_WAREHOUSE_NO.EditValue);
            }

            obj_Product.PackagesPerPallet = Convert.ToInt16(spinEdit_PackagesPerPallet.Value);
            obj_Product.PackagesPerPallet2 = Convert.ToInt16(spinEdit_PackagesPerPallet2.Value);
            obj_Product.Inners = Convert.ToInt16(spinEdit_Inners.Value);
            obj_Product.Pcs = Convert.ToInt16(spPcs.Value);

            if (lookUpEdit_CustomerProductGroups.EditValue != null)
            {
                obj_Product.ProductCategory = Convert.ToInt32(lookUpEdit_CustomerProductGroups.EditValue);
            }


            obj_Product.CBM = Convert.ToInt32(spinEdit_CBM.Value);
            obj_Product.IsAllowLocationChange = chkEdit_IsAllowLocationChange.Checked;
            obj_Product.IsWeightingRequire = chkEdit_IsWeightingRequire.Checked;

            try
            {
                if (lookUpEdit_HomeRoom1.EditValue != null)
                {
                    LocationsHome locationSelected = (LocationsHome)lookUpEdit_HomeRoom1.GetSelectedDataRow();
                    obj_Product.HomeLocation1 = locationSelected.LocationID;
                    obj_Product.HomeRoom1 = locationSelected.RoomID;
                }

                if (lookUpEdit_HomeRoom2.EditValue != null)
                {
                    LocationsHome locationSelected = (LocationsHome)lookUpEdit_HomeRoom2.GetSelectedDataRow();
                    obj_Product.HomeLocation2 = locationSelected.LocationID;
                    obj_Product.HomeRoom2 = locationSelected.RoomID;
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            obj_Product.PickingMethod = Convert.ToBoolean(radGroup_PickingMethod.EditValue);

            if (lookUpEdit_PickingLocation.EditValue != null && Convert.ToInt32(lookUpEdit_PickingLocation.EditValue) != 0)
            {
                obj_Product.PickingLocation = Convert.ToInt32(lookUpEdit_PickingLocation.EditValue);
            }
            else
            {
                obj_Product.PickingLocation = 0;
            }

            obj_Product.Discontinue = chkEdit_Discontinue.Checked;

            obj_Product.Remark = "update by: " + AppSetting.CurrentUser.LoginName.ToString() + "~" + DateTime.Now.ToString();
            obj_Product.CreatedBy = txtEdit_CreatedBy.Text;
            obj_Product.ERPUnit = this.txtERP.Text;

            //try
            //{
            //    obj_Product.CreatedTime = Convert.ToDateTime(dateEdit_CreatedTime.EditValue);
            //}
            //catch
            //{
            //    obj_Product.CreatedTime = DateTime.Now;
            //}
        }

        /// <summary>
        /// Copy product
        /// </summary>
        private void CopyProduct()
        {
            obj_Product.CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            obj_Product.ProductNumber = txtEdit_InitialLabel.Text.Trim() + txtEdit_ProductNumber.Text.Trim();
            obj_Product.ProductNameVN = txtEdit_ProductNameVN.Text;
            obj_Product.SizeBox = this.txtBoxSize.Text;
            obj_Product.SubCode = txtSubCode.Text;
            obj_Product.ProductName = txtEdit_ProductName.Text.Trim();
            if (lookUpEdit_ProductCategoryID.EditValue != null)
            {
                obj_Product.ProductCategoryID = Convert.ToByte(lookUpEdit_ProductCategoryID.EditValue);
            }

            obj_Product.Origin = txtEdit_Origin.Text.Trim();
            obj_Product.TemperatureRequire = Convert.ToInt32(spinEdit_TemperatureRequire.Value);
            if (this.lke_PackageTypes.EditValue != null)
                obj_Product.QuyCach = Convert.ToInt32(this.lke_PackageTypes.EditValue);
            //if (this.spinEdit_CartonUnitConversion.EditValue != null) obj_Product.Pcs = short.Parse(this.spinEdit_CartonUnitConversion.EditValue.ToString());
            if (this.lke_WM_Products.EditValue != null) obj_Product.ProductMainID = Convert.ToInt32(this.lke_WM_Products.EditValue);
            if (this.spinEdit_SafetyStock.EditValue != null) obj_Product.SafetyStock = Convert.ToInt32(this.spinEdit_SafetyStock.EditValue);
            if (this.spinEdit_SelfLifeDays.EditValue != null) obj_Product.SelfLifeDays = Convert.ToInt32(this.spinEdit_SelfLifeDays.EditValue);
            obj_Product.WarningDaysBeforeExpiry = 1;
            obj_Product.WeightPerPackage = 1;
            obj_Product.GrossWeightPerPackage = null;
            if (lookUpEdit_Packages.EditValue != null)
            {
                obj_Product.Packages = lookUpEdit_Packages.EditValue.ToString();
            }

            if (lookUpEdit_WAREHOUSE_NO.EditValue != null)
            {
                obj_Product.WAREHOUSE_NO = Convert.ToInt32(lookUpEdit_WAREHOUSE_NO.EditValue);
            }

            obj_Product.PackagesPerPallet = 50;
            obj_Product.PackagesPerPallet2 = 50;
            obj_Product.Inners = 1;
            obj_Product.Pcs = 1;

            //if (lookUpEdit_CustomerProductGroups.EditValue != null)
            //{
            //    obj_Product.ProductCategoryID = 20;
            //}
            obj_Product.ProductCategoryID = 20;

            obj_Product.CBM = 1;
            obj_Product.IsAllowLocationChange = chkEdit_IsAllowLocationChange.Checked;
            obj_Product.IsWeightingRequire = chkEdit_IsWeightingRequire.Checked;

            try
            {
                if (lookUpEdit_HomeRoom1.EditValue != null)
                {
                    obj_Product.HomeLocation1 = Convert.ToInt32(lookUpEdit_HomeRoom1.EditValue);
                }

                if (lookUpEdit_HomeRoom2.EditValue != null)
                {
                    obj_Product.HomeLocation2 = Convert.ToInt32(lookUpEdit_HomeRoom2.EditValue);
                }
            }
            catch (Exception ex)
            {
                log.Error("==> Error is unexpected");
                log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);
            }

            if (lookUpEdit_HomeRoom1.EditValue != null)
            {
                obj_Product.HomeRoom1 = lookUpEdit_HomeRoom1.EditValue.ToString().Substring(0, 1);
            }

            if (lookUpEdit_HomeRoom2.EditValue != null)
            {
                obj_Product.HomeRoom2 = lookUpEdit_HomeRoom2.EditValue.ToString().Substring(0, 1);
            }

            obj_Product.PickingMethod = false;
            obj_Product.PickingLocation = null;

            //if (lookUpEdit_PickingLocation.EditValue != null && Convert.ToInt32(lookUpEdit_PickingLocation.EditValue) != 0)
            //{
            //    obj_Product.PickingLocation = Convert.ToInt32(lookUpEdit_PickingLocation.EditValue);
            //}
            //else
            //{
            //    obj_Product.PickingLocation = 0;
            //}

            obj_Product.Discontinue = chkEdit_Discontinue.Checked;

            obj_Product.Remark = txtEdit_Remark.Text.Trim();
            obj_Product.GTIN = txtEdit_GTIN.Text;
            obj_Product.CreatedBy = AppSetting.CurrentUser.LoginName;
            obj_Product.CreatedTime = DateTime.Now;

            //try
            //{
            //    obj_Product.CreatedTime = Convert.ToDateTime(dateEdit_CreatedTime.EditValue);
            //}
            //catch
            //{
            //    obj_Product.CreatedTime = DateTime.Now;
            //}
        }

        private void frm_MSS_Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void frm_MSS_Products_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.isFormLoad = false;
                return;
            }
            if (this.isFormLoad) return;
            Frm_MSS_Products_Load(sender, e);
        }

        private void btn_P_StopProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataProcess<Products> productDA = new DataProcess<Products>();
            this.productSelected.Discontinue = true;
            productDA.Update(this.productSelected);
            SetEnableButton(CActionForm.Save);
        }

        private void imgSld_Products_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.isAddNew = true;
            m_Old_ProductID = obj_Product.ProductID;

            obj_Product = new Products();

            //SetObjectInfo();
            CopyProduct();

            obj_Product.ProductID = 0;
            obj_Product.ProductName = obj_Product.ProductName + " - COPY";
            obj_Product.ProductNumber = obj_Product.ProductNumber.Substring(0, 4);

            GetObjectInfo();

            SetEnableButton(CActionForm.Copy);

            txtEdit_ProductNumber.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("WARNING: Are you sure you want to delete this record ? ", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int varProductID = obj_Product.ProductID;

                    DA.Master.ProductDA da = new DA.Master.ProductDA();
                    ObjectParameter vardelete = new ObjectParameter("varDeleted", 1);
                    int result = da.DeleteProduct(varProductID, vardelete);

                    if (Convert.ToInt16(vardelete.Value) == 0)
                    {
                        XtraMessageBox.Show("ERROR: This product is busy, can not be removed !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Convert.ToInt16(vardelete.Value) != 1)
                    {
                        XtraMessageBox.Show("ERROR: Cannot delete this product.", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SetEnableButton(CActionForm.Delete);
                        this.AddNewRecord();
                    }
                }
                catch (Exception ex)
                {
                    log.Error("==> Error is unexpected");
                    log.ErrorFormat("Error is unexpected message=[{0}],\n InnerException=[{1}],\n StackTrace=[{2}]", ex.Message, ex.InnerException, ex.StackTrace);

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (isEditing)
            {
                //=============== if the state is editing, then perform the save function

                if (!ValidateInputData()) return;

                int v_Ret = 0;

                SetObjectInfo();

                DA.DataProcess<DA.Products> pc = new DA.DataProcess<DA.Products>();

                //obj_Product.CreatedTime = DateTime.Now;

                if (obj_Product.ProductID <= 0)
                {
                    v_Ret = pc.Insert(obj_Product);
                    // Product new, add it into data local
                    ((IList<Products>)AppSetting.ProductList).Add(obj_Product);
                }
                else
                {
                    v_Ret = pc.Update(obj_Product);
                }

                // Call API to post 
                APIProcess api = new APIProcess();
                string url = ConfigurationManager.AppSettings["ItemMasterData_Navi"];
                if (!string.IsNullOrEmpty(url))
                    api.Post(url, "");

                if (v_Ret > 0)
                {
                    LoadRecordProducts(CActionRecord.p_TypeLoadProductID, 0, obj_Product.ProductID);
                    SetEnableButton(CActionForm.Save);
                    this.isEditing = false;
                }
                else
                {
                    XtraMessageBox.Show("Error ! Can not update !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (isAddNew)
                {
                    Common.Process.RefreshData.OnReloadData(new ReceivingOrderDetails(), e);
                }
                this.isAddNew = false;

            }
            else
            {
                SetEnableButton(CActionForm.Edit);

                if (this.obj_Product == null) return;
                m_Old_ProductID = obj_Product.ProductID;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.isAddNew = false;
            LoadRecordProducts(CActionRecord.p_TypeLoadProductID, 0, m_Old_ProductID);

            SetEnableButton(CActionForm.Cancel);
        }

        private void btnPalletInfo_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);

            WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(Convert.ToInt32(m_LoadRecordProductData.CustomerID), Convert.ToInt32(m_LoadRecordProductData.ProductID));
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.isAddNew = false;
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            frm_MSS_Dialog_UpdateRODO frm = new frm_MSS_Dialog_UpdateRODO(m_LoadRecordProductData);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            frm_MSS_Dialog_Products_simple frm = new frm_MSS_Dialog_Products_simple(Convert.ToInt32(m_LoadRecordProductData.CustomerID), Convert.ToInt32(m_LoadRecordProductData.CustomerMainID));
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show(this);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DataProcess<Products> productDA = new DataProcess<Products>();
            if (this.btnStop.Text.Equals("Reuse Product"))
            {
                // Re-use
                this.productSelected.Discontinue = false;
            }
            else
            {
                // Stop
                this.productSelected.Discontinue = true;
            }

            productDA.Update(this.productSelected);
            SetEnableButton(CActionForm.Save);
        }

        private void lookUpEdit_Packages_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null) return;
            if (this.lookUpEdit_CustomerID.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue);
            var currentCus = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            var newType = Convert.ToString(e.NewValue);
            if (newType != "KGR") return;
            if (!currentCus.CustomerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT)) e.Cancel = true;

        }

        private void btnShowERPUOMList_Click(object sender, EventArgs e)
        {
            this.layoutControlItemPackageList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.LoadProductPackage();
        }

        private void grvProductPackage_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int productPackageID = Convert.ToInt32(this.grvProductPackage.GetFocusedRowCellValue("ProductPackageID"));
            var currentPackage = this.bdPackage.Where(p => p.ProductPackageID == productPackageID).FirstOrDefault();
            DataProcess<ProductPackage> packageDA = new DataProcess<ProductPackage>();
            //switch (e.Column.FieldName)
            //{
            //    case "Packages": currentPackage.Packages = Convert.ToString(e.Value); break;
            //    case "Pcs":
            //        currentPackage.Pcs = Convert.ToInt32(e.Value); break;
            //    case "CBM":
            //        currentPackage.CBM = Convert.ToDecimal(e.Value); break;
            //    case "Remark":
            //        currentPackage.Remark = Convert.ToString(e.Value); break;
            //}
            if (currentPackage.ProductPackageID <= 0)
            {
                packageDA.Insert(currentPackage);
                this.AddNewPackage();
            }
            else
            {
                packageDA.Update(currentPackage);
            }
        }

        private void AddNewPackage()
        {
            var currentPackage = new ProductPackage();
            currentPackage.CreateBy = AppSetting.CurrentUser.LoginName;
            currentPackage.CreateTime = DateTime.Now;
            currentPackage.ProductID = this.obj_Product.ProductID;
            this.bdPackage.Add(currentPackage);
        }

        private void frm_MSS_Products_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAddPackageType_Click(object sender, EventArgs e)
        {
            frm_MSS_PackageTypeDifinitions frm = new frm_MSS_PackageTypeDifinitions();
            frm.ShowDialog();
            this.LoadProductMeasure();
        }

        private void lke_PackageTypes_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grvHeSoQuyDoi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (this.obj_Product == null) return;
            if (e.RowHandle < 0) return;
            DataProcess<ProductMeasure> dataProcess = new DataProcess<ProductMeasure>();
            var currentProMeasureInfo = (ProductMeasure)this.grvHeSoQuyDoi.GetRow(e.RowHandle);
            if (currentProMeasureInfo != null && currentProMeasureInfo.ProductMeasureID > 0)
            {
                //Update
                dataProcess.Update(currentProMeasureInfo);
            }
            else
            {
                //Insert
                currentProMeasureInfo.ProductID = this.obj_Product.ProductID;
                dataProcess.Insert(currentProMeasureInfo);
                this.grvHeSoQuyDoi.SetFocusedRowCellValue("ProductMeasureID", currentProMeasureInfo.ProductMeasureID);
                if (this.bdProductMeasure.Count(p => p.ProductMeasureID <= 0) <= 0)
                {
                    this.bdProductMeasure.Add(new ProductMeasure());
                    this.grvHeSoQuyDoi.RefreshData();
                }
            }

            // Update Net
            this.UpdateNetByMeasure();
        }

        private void UpdateNetByMeasure()
        {
            if (lke_PackageTypes.EditValue != null && grvHeSoQuyDoi.RowCount > 0)
            {
                DataProcess<QCMaster> dataProcess = new DataProcess<QCMaster>();
                var masters = dataProcess.Select();

                // lay thong tin package type dang chon
                var packageTypeID = Convert.ToInt32(this.lke_PackageTypes.EditValue);
                var currenQCMaster = masters.Where(m => m.PackageTypeID == packageTypeID).FirstOrDefault();
                if (currenQCMaster == null) return;

                // lay thong tin HSQD theo packagetype
                var currentHs = this.bdProductMeasure.Where(p => p.MeasureID == currenQCMaster.MeasureID).FirstOrDefault();
                if (currentHs != null)
                {
                    var netValue = currenQCMaster.Value1 * currenQCMaster.Value2 * currentHs.HS;
                    this.spinEdit_Net.EditValue = netValue;
                }
            }
        }

        private void lke_PackageTypes_EditValueChanged_1(object sender, EventArgs e)
        {
            this.UpdateNetByMeasure();
        }

        private void lookUpEdit_Packages_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEdit_Packages.EditValue == null) return;
            var currentUnit = Convert.ToString(this.lookUpEdit_Packages.EditValue);
            bool isUnit = false;
            if (currentUnit == "UN") isUnit = true;
            this.LoadPackageType(isUnit);
        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            int productPackageID = Convert.ToInt32(this.grvProductPackage.GetFocusedRowCellValue("ProductPackageID"));
            DataProcess<ProductPackage> palletCaton = new DataProcess<ProductPackage>();
            palletCaton.ExecuteNoQuery("Delete ProductPackages Where ProductPackageID = " + productPackageID);
            this.LoadProductPackage();
        }

        private void chkEdit_IsGetNet_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEdit_IsGetNet.IsModified) return;
            if (this.chkEdit_IsGetNet.Checked)
                this.spinEdit_WeightPerPackage.Value = this.spinEdit_Net.Value;
            //else
            //    this.spinEdit_WeightPerPackage.Value = this.spinEdit_GrossWeightPerPackage.Value;
        }

        private void spinEdit_Net_EditValueChanged(object sender, EventArgs e)
        {
            this.chkEdit_IsGetNet.Checked = true;
            this.spinEdit_WeightPerPackage.Value = this.spinEdit_Net.Value;
        }

        private void rpi_lke_DVT_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (LookUpEdit)sender;
            if (lke == null || lke.EditValue == null) return;
            int maDVT=Convert.ToInt32(lke.EditValue);
            var giatri = lke.GetColumnValue("GiaTri");
            this.grvHeSoQuyDoi.SetRowCellValue(this.grvHeSoQuyDoi.FocusedRowHandle, "HS", giatri);
        }
    }
}
