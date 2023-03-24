using Common.Controls;
using DA;
using System.Collections.Generic;
using System.Linq;
using System;
using Common.Process;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using UI.Helper;
using UI.APIs;
using System.Configuration;
using System.Drawing;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Dialog_Products_simple : frmBaseForm
    {
        int m_CustomerID = 0;
        int m_CustomerMainID = 0;

        int m_StoreID = 1;
        private Timer timerNetWork = new Timer();
        private bool sleeptime = false;

        class CActionForm
        {
            public static int LoadForm = 1;
            public static int Update = 2;
            public static int Edit = 4;
            public static int Cancel = 5;
        }

        public frm_MSS_Dialog_Products_simple()
        {
            InitializeComponent();

            SetEvent();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            lookUpEdit_CustomerID.Properties.DataSource = AppSetting.CustomerList.Where(a => a.CustomerDiscontinued == false);
            lookUpEdit_CustomerID.EditValue = m_CustomerID;
        }
        public frm_MSS_Dialog_Products_simple(int i_CustomerID)
        {
            InitializeComponent();

            this.m_CustomerID = i_CustomerID;

            SetEvent();
        }
        public frm_MSS_Dialog_Products_simple(int i_CustomerID, int i_CustomerMainID)
        {
            InitializeComponent();

            this.m_CustomerID = i_CustomerID;

            this.m_CustomerMainID = i_CustomerMainID;

            SetEvent();
        }
        void Frm_MSS_Dialog_Products_simple_Load(object sender, EventArgs e)
        {
            this.timerNetWork.Interval = 500;
            this.timerNetWork.Tick += TimerNetWork_Tick;
            this.timerNetWork.Start();

            LoadData2LookUpEdit_Customers();

            int v_Discontinue = 2;

            try
            {
                v_Discontinue = Convert.ToInt32(radioGroup_Discontinue.EditValue);
            }
            catch { }

            loadData2GridControl(v_Discontinue);

            SetEditGridControl(false);

            SetEnableButton(CActionForm.LoadForm);
        }

        private void TimerNetWork_Tick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                //Image imgDisplay = null;
                //if (NetworkHelper.IsConnectedToInternet())
                //    imgDisplay = Properties.Resources.On;
                //else
                //    imgDisplay = Properties.Resources.Off;

                //if (this.sleeptime)
                //    this.picNetWork.Image = imgDisplay;
                //else
                //    this.picNetWork.Image = Properties.Resources.Empty;
                //this.sleeptime = !sleeptime;
            });
        }

        void SetEvent()
        {
            this.Load += Frm_MSS_Dialog_Products_simple_Load;

            btn_Cancel.Click += Btn_Cancel_Click;
            btn_Edit.Click += Btn_Edit_Click;
            btn_Update.Click += Btn_Update_Click;
            btn_New.Click += Btn_New_Click;
            btn_Close.Click += Btn_Close_Click;

            lookUpEdit_CustomerID.EditValueChanged += LookUpEdit_CustomerID_EditValueChanged;
            this.rpi_hpl_PalletInfo.Click += RepositoryItemButtonEdit_PalletInfor_DoubleClick;
            repositoryItemHyperLinkEdit_ProductID.Click += RepositoryItemHyperLinkEdit_ProductID_DoubleClick;
            hyperLinkEdit_CustomerName.Click += HyperLinkEdit_CustomerName_DoubleClick;

            radioGroup_Discontinue.EditValueChanged += RadioGroup_Discontinue_EditValueChanged;
        }

        void RadioGroup_Discontinue_EditValueChanged(object sender, EventArgs e)
        {
            int v_Discontinue = 2;

            try
            {
                v_Discontinue = Convert.ToInt32(radioGroup_Discontinue.Enabled);
            }
            catch { }

            loadData2GridControl(v_Discontinue);
        }
        void LookUpEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            int v_CDiscontinue = 2;
            try
            {
                v_CDiscontinue = Convert.ToInt32(radioGroup_Discontinue.EditValue);
            }
            catch { }

            try
            {
                m_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            }
            catch { }

            try
            {
                hyperLinkEdit_CustomerName.EditValue = lookUpEdit_CustomerID.GetColumnValue("CustomerName");
            }
            catch { }
            this.LoadProductCategory();
            loadData2GridControl(v_CDiscontinue);
        }

        void HyperLinkEdit_CustomerName_DoubleClick(object sender, EventArgs e)
        {
            if (lookUpEdit_CustomerID.EditValue == null) return;
            int m_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            var currentCus = UI.Helper.AppSetting.CustomerList.Where(c => c.CustomerID == m_CustomerID).FirstOrDefault();
            MasterSystemSetup.frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
            frm.CurrentCustomers = currentCus;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Show();
        }
        void RepositoryItemHyperLinkEdit_ProductID_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            try
            {
                v_ProductID = Convert.ToInt32(this.grView_Product.GetRowCellValue(this.grView_Product.FocusedRowHandle, "ProductID"));
            }
            catch { }

            MasterSystemSetup.frm_MSS_Products frm = frm_MSS_Products.Instance;
            frm.ProductIDLookup = v_ProductID;
            frm.ShowInTaskbar = false;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.BringToFront();
            frm.Show();
        }
        void RepositoryItemButtonEdit_PalletInfor_DoubleClick(object sender, EventArgs e)
        {
            int v_ProductID = 0;
            int v_CustomerID = 0;

            try
            {
                v_ProductID = Convert.ToInt32(this.grView_Product.GetRowCellValue(this.grView_Product.FocusedRowHandle, "ProductID"));
            }
            catch { }

            try
            {
                v_CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            }
            catch { }

            WarehouseManagement.frm_WM_PalletInfo frm = new WarehouseManagement.frm_WM_PalletInfo(v_CustomerID, v_ProductID);
            frm.ShowInTaskbar = false;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.Show();
        }

        void Btn_Update_Click(object sender, EventArgs e)
        {
            var listSourceUpdate = (IList<ST_WMS_LoadListProductByCustomer_Result>)this.grControl_Product.DataSource;
            DataProcess<Products> obj_ProductDA = new DataProcess<Products>();

            IList<Products> listProduct;

            int v_Discontinue = 2;
            try
            {
                v_Discontinue = Convert.ToInt32(radioGroup_Discontinue.EditValue);
            }
            catch { }

            if (v_Discontinue == 2)
            {
                listProduct = obj_ProductDA.Select(c => c.CustomerID == m_CustomerID).ToList();
            }
            else if (v_Discontinue == 0)
            {
                listProduct = obj_ProductDA.Select(c => c.CustomerID == m_CustomerID && c.Discontinue == false).ToList();
            }
            else if (v_Discontinue == 1)
            {
                listProduct = obj_ProductDA.Select(c => c.CustomerID == m_CustomerID && c.Discontinue == true).ToList();
            }
            else
            {
                listProduct = obj_ProductDA.Select(c => c.CustomerID == m_CustomerID).ToList();
            }


            foreach (var item in listProduct)
            {
                var productObj = (ST_WMS_LoadListProductByCustomer_Result)listSourceUpdate.Where(c => c.ProductID == item.ProductID).FirstOrDefault();

                item.ProductNumber = productObj.ProductNumber;
                item.ProductName = productObj.ProductName;
                item.Packages = productObj.Packages;
                item.Discontinue = productObj.Discontinue;
                item.WeightPerPackage = productObj.WeightPerPackage;
                item.GrossWeightPerPackage = productObj.GrossWeightPerPackage;
                item.Inners = productObj.Inners;
                item.PackagesPerPallet = productObj.PackagesPerPallet;
                item.PackagesPerPallet2 = productObj.PackagesPerPallet2;
                item.WarningDaysBeforeExpiry = productObj.WarningDaysBeforeExpiry;
                item.Pcs = productObj.pcs;
                item.ERPUnit = productObj.ERPUnit;
                item.SafetyStock = productObj.SafetyStock;
                item.SelfLifeDays = productObj.SelfLifeDays;
                item.ProductCategory = productObj.ProductCategory;
                item.TemperatureRequire = productObj.TemperatureRequire;
                item.Net = productObj.Net;
            }

            obj_ProductDA.Update(listProduct.ToArray());

            SetEditGridControl(false);

            SetEnableButton(CActionForm.Update);
        }
        void Btn_Edit_Click(object sender, EventArgs e)
        {
            SetEditGridControl(true);

            SetEnableButton(CActionForm.Edit);
        }
        void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Btn_Cancel_Click(object sender, EventArgs e)
        {
            SetEnableButton(CActionForm.Cancel);
        }
        void Btn_New_Click(object sender, EventArgs e)
        {
            UI.MasterSystemSetup.frm_MSS_Products frm = frm_MSS_Products.Instance;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.CustomerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            frm.Show();
        }

        void SetEnableButton(int i_ActionControlForm)
        {
            #region LoadForm

            if (i_ActionControlForm.Equals(CActionForm.LoadForm))
            {
                btn_Cancel.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Update.Enabled = false;
                btn_New.Enabled = true;
            }
            #endregion LoadForm

            #region Edit

            else if (i_ActionControlForm.Equals(CActionForm.Edit))
            {
                btn_Cancel.Enabled = true;
                btn_Edit.Enabled = false;
                btn_Update.Enabled = true;
                btn_New.Enabled = false;
            }

            #endregion Edit

            #region Update

            else if (i_ActionControlForm.Equals(CActionForm.Update))
            {
                btn_Cancel.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Update.Enabled = false;
                btn_New.Enabled = true;

            }
            #endregion Update

            #region Cancel

            else if (i_ActionControlForm.Equals(CActionForm.Cancel))
            {
                btn_Cancel.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Update.Enabled = false;
                btn_New.Enabled = true;
            }

            #endregion Cancel

            #region Other

            else
            {
                btn_Cancel.Enabled = false;
                btn_Edit.Enabled = false;
                btn_Update.Enabled = false;
                btn_New.Enabled = false;
            }

            #endregion Other
        }
        void SetEditGridControl(bool i_Bool)
        {
            this.grView_Product.Columns["ProductNumber"].OptionsColumn.AllowEdit = true;
            this.grView_Product.Columns["ProductName"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["Packages"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["Discontinue"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["WeightPerPackage"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["GrossWeightPerPackage"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["Inners"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["PackagesPerPallet"].OptionsColumn.AllowEdit = true;
            this.grView_Product.Columns["PackagesPerPallet2"].OptionsColumn.AllowEdit = true;
            this.grView_Product.Columns["WarningDaysBeforeExpiry"].OptionsColumn.AllowEdit = i_Bool;
            this.grView_Product.Columns["ERPUnit"].OptionsColumn.AllowEdit = i_Bool;
            this.colCategory.OptionsColumn.AllowEdit = i_Bool;
        }
        void LoadData2LookUpEdit_Customers()
        {
            //DataProcess<Customers> obj_CustomersDA = new DataProcess<Customers>();
            //List<Customers> ListCustomer = obj_CustomersDA.Select(c => c.CustomerMainID == m_CustomerMainID ).ToList();
            //lookUpEdit_CustomerID.Properties.DataSource = ListCustomer;
            //lookUpEdit_CustomerID.EditValue = m_CustomerID;

            if (m_CustomerID > 0)
            {
                try
                {
                    Wait.Start(this);
                    Common.Process.RefreshData.Refresh(this.lookUpEdit_CustomerID, () =>
                    {
                        lookUpEdit_CustomerID.Properties.DataSource = UI.Helper.AppSetting.CustomerList;
                    });

                    lookUpEdit_CustomerID.EditValue = m_CustomerID;

                    Common.Process.RefreshData.Refresh(this.hyperLinkEdit_CustomerName, () =>
                    {
                        try
                        {
                            hyperLinkEdit_CustomerName.Text = ((IEnumerable<Customers>)lookUpEdit_CustomerID.Properties.DataSource).Where(c => c.CustomerID == m_CustomerID).FirstOrDefault().CustomerName;
                        }
                        catch { }
                    });
                }
                catch (Exception ex)
                {
                    Wait.Close();
                    XtraMessageBox.Show(ex.Message, "Error is unexpected");
                }
                finally
                {
                    Wait.Close();
                }
            }

        }
        void loadData2GridControl(int i_Discontinue)
        {
            DataProcess<Products> obj_ProductDA = new DataProcess<Products>();
            int v_Discontinue = 2;
            try
            {
                v_Discontinue = Convert.ToInt32(radioGroup_Discontinue.EditValue);
            }
            catch { }

            if (v_Discontinue < 3)
            {
                grControl_Product.DataSource = (new DataProcess<ST_WMS_LoadListProductByCustomer_Result>()).Executing("ST_WMS_LoadListProductByCustomer @CustomerID = {0},@Discontinue = {1}", m_CustomerID, v_Discontinue);
            }
            else
            {
                grControl_Product.DataSource = (new DataProcess<ST_WMS_LoadListProductByCustomer_Result>()).Executing("ST_WMS_LoadListNewProductByCustomer @CustomerID = {0},@Discontinue = {1}", m_CustomerID, v_Discontinue);
            }

        }

        #region Code OLD

        //private void Grv_MSS_ServicesDefinition_ShownEditor(object sender, EventArgs e)
        //{
        //    this.grView_Product.ActiveEditor.MouseUp += ActiveEditor_MouseUp;
        //}

        //private void ActiveEditor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    this.grView_Product.SetFocusedRowCellValue("IsModified", 1);
        //    var scopeData = this.grView_Product.GetRowCellValue(this.grView_Product.FocusedRowHandle, "ScopeOfWork");
        //}

        //private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.grView_Product.OptionsBehavior.ReadOnly = false;
        //}

        #endregion Code OLD

        private void grView_Product_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch (this.grView_Product.FocusedColumn.FieldName)
            {
                case "Packages":
                case "ERPUnit":
                case "pcs":
                    string value = Convert.ToString(e.Value);
                    if (string.IsNullOrEmpty(value))
                    {
                        e.Valid = false;
                        e.ErrorText = "Value is not null or empty";
                    }
                    break;
            }
        }

        private void LoadProductCategory()
        {

            if (this.lookUpEdit_CustomerID.EditValue == null) return;
            if (Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue) == 0) return;
            int customerID = Convert.ToInt32(this.lookUpEdit_CustomerID.EditValue);
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            DataProcess<CustomerProductGroups> obj_CustomerProductGroupsDA = new DataProcess<CustomerProductGroups>();
            List<CustomerProductGroups> List_CustomerProductGroups = obj_CustomerProductGroupsDA.Select(c => c.CustomerID == currentCustomer.CustomerMainID).ToList();

            this.rpi_lke_ProductCategory.DataSource = List_CustomerProductGroups;
            this.rpi_lke_ProductCategory.DisplayMember = "ProductGroupDescription";
            this.rpi_lke_ProductCategory.ValueMember = "ProductGroupID";
        }

        private void grView_Product_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            bool isSyncNavi = Convert.ToBoolean(this.grView_Product.GetRowCellValue(e.RowHandle, "HasSyncNavi"));
            if (isSyncNavi) e.Appearance.BackColor = System.Drawing.Color.LightGreen;
        }

        private void btnSyncNavi_Click(object sender, EventArgs e)
        {
            if (lookUpEdit_CustomerID.EditValue == null) return;
            if (!NetworkHelper.IsConnectedToInternet())
            {
                MessageBox.Show("Không thể kết nối với Warenavi ! vui lòng kiểm tra đường truyền !", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerID = Convert.ToInt32(lookUpEdit_CustomerID.EditValue);
            DataProcess<Customers> dataProcess = new DataProcess<Customers>();
            int result = dataProcess.ExecuteNoQuery("SPSyncItemMasterToNavi @StoreID={0},@CustomerID={1}", AppSetting.StoreID, customerID);

            // Call API to post 
            APIProcess api = new APIProcess();
            string url = ConfigurationManager.AppSettings["ItemMasterData_Navi"];
            if (!string.IsNullOrEmpty(url))
                api.Post(url, "");

            int v_Discontinue = 2;
            try
            {
                v_Discontinue = Convert.ToInt32(radioGroup_Discontinue.EditValue);
            }
            catch { }

            // reload data
            loadData2GridControl(v_Discontinue);
        }
    }
}
