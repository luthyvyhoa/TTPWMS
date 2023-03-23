using System.Windows.Forms;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.Helper;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using DA.Warehouse;
using System.Data;
using System.Drawing;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_DispatchingCartons : UserControl
    {
        /// <summary>
        /// Dispatching product id selected
        /// </summary>
        private int dispatchingProductID = -1;
        private float totalWeightPerpackage = 0;
        private IList<ST_WMS_LoadDispatchingCartons_Result> listDataModify = null;
        private bool isLocation = false;
        private DispatchingProducts dp = null;
        private int doDetailID = 0;
        private int disOrderID = 0;



        public delegate void ActiveParentControls(bool obj, EventArgs e);
        public event ActiveParentControls reLoadParentControls;

        public void setEvent(object sender, EventArgs e)
        {
            bool active = Convert.ToBoolean(sender);
            this.SetDisableEditCarton(active);
        }
        private void SetDisableEditCarton(bool active)
        {
            grd_WM_DispatchingCartons.Enabled = active;
            btnCreateCartons.Enabled = active;
            btnDelete.Enabled = active;
            btnImport.Enabled = active;
            btnUpdate.Enabled = active;
            btn_WM_AddOneCarton.Enabled = active;
            setColorButton();

        }
        private void setColorButton()
        {
            btnUpdate.Appearance.BackColor = (btnUpdate.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning : Color.Gray;
            btnImport.Appearance.BackColor = (btnImport.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary : Color.Gray;
            btnCreateCartons.Appearance.BackColor = (btnCreateCartons.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary : Color.Gray;
            btnDelete.Appearance.BackColor = (btnDelete.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger : Color.Gray;
            btn_WM_AddOneCarton.Appearance.BackColor = (btn_WM_AddOneCarton.Enabled) ? DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary : Color.Gray;

        }

        public urc_WM_DispatchingCartons()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dispatchingProductID">int</param>
        public urc_WM_DispatchingCartons(DispatchingProducts disProduct, int dispatchingProductID, float totalWeightPerpackage, bool isLocation = false, int doDetailID = 0,int disOrderID=0)
        {
            // Init controls to designer
            InitializeComponent();

            // Init member
            this.listDataModify = new List<ST_WMS_LoadDispatchingCartons_Result>();

            // Get arguments value
            this.dp = disProduct;
            this.dispatchingProductID = dispatchingProductID;
            this.totalWeightPerpackage = totalWeightPerpackage;
            this.isLocation = isLocation;

            // Init data
            this.InitData(disProduct, this.dispatchingProductID, this.totalWeightPerpackage, this.isLocation, doDetailID, disOrderID);
        }

        /// <summary>
        /// Declare refresh dispatching product event
        /// </summary>
        public event EventHandler RefreshDispatchingProductEvent = null;

        /// <summary>
        /// Declare event raise event active parent controls when gird is edit
        /// </summary>
        public event EventHandler SetActiveParentControlsEvent = null;

        /// <summary>
        /// Init data to load form
        /// </summary>
        public void InitData(DispatchingProducts disProduct, int dispatchingProductID, float totalWeightPerpackage, bool isLocation = false, int doDetailID = 0, int disOrderID =0)
        {

            // Get arguments value
            this.dp = disProduct;
            this.dispatchingProductID = dispatchingProductID;
            this.totalWeightPerpackage = totalWeightPerpackage;
            this.isLocation = isLocation;
            this.doDetailID = doDetailID;
            this.disOrderID = disOrderID;
            DataProcess<ST_WMS_LoadDispatchingCartons_Result> dispatchingCartonDA = new DataProcess<ST_WMS_LoadDispatchingCartons_Result>();
            if (!this.isLocation)
            {
                this.grd_WM_DispatchingCartons.DataSource = dispatchingCartonDA.Executing("ST_WMS_LoadDispatchingCartons @DispatchingProductID={0}", this.doDetailID);
            }
            else
            {
                this.grd_WM_DispatchingCartons.DataSource = dispatchingCartonDA.Executing("ST_WMS_DispatchingCartonByLocationID @DispatchingLocationID={0}", this.dispatchingProductID);
            }

        }

        /// <summary>
        /// Raise event to parent form update data
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRefreshDispatchingProduct(EventArgs e)
        {

            EventHandler handler = this.RefreshDispatchingProductEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raise event to parent form to set activce controls on parent form
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSetActiceParentControls(bool isActive, EventArgs e)
        {

            EventHandler handler = this.SetActiveParentControlsEvent;
            if (handler != null)
            {
                handler(isActive, e);
            }
        }

        /// <summary>
        /// Delete current pallet selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (this.grv_WM_DispatchingCartons.SelectedRowsCount <= 0) return;
            DialogResult dl = XtraMessageBox.Show("Do you want to delete these records ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.Yes))
            {
                // Declare object to process interactive with DB
                DataProcess<object> deleteDispatchingCartonDA = new DataProcess<object>();

                // Get list dispatching carton will deleted and update status deleted=true
                foreach (int index in this.grv_WM_DispatchingCartons.GetSelectedRows())
                {
                    // Get dispatching carton ID of current selected row
                    var dispatchingCartonSelected = (ST_WMS_LoadDispatchingCartons_Result)this.grv_WM_DispatchingCartons.GetRow(index);

                    // Update status deleted= true
                    deleteDispatchingCartonDA.ExecuteNoQuery("Update DispatchingCartons set CheckDelete=1 where DispatchingCartonID=" + dispatchingCartonSelected.DispatchingCartonID);
                }

                // Delete list dispatching carton has status deleted=true
                int result = deleteDispatchingCartonDA.ExecuteNoQuery("STDispatchingCartonCheckUpdate @DispatchingProductID={0},@CheckDelete={1},@Flag={2}",
                    this.dp.DispatchingProductID, null, 1);

                // Reload data
                this.InitData(this.dp, this.dispatchingProductID, this.totalWeightPerpackage, this.isLocation);
            }
        }

        /// <summary>
        /// Update dispatching cartons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public decimal sumWeight = 0;
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (this.grv_WM_DispatchingCartons.RowCount < 0) return;
            DataProcess<object> dispatchingProductDA = new DataProcess<object>();
            float totalWeight = 0;
            if (!this.isLocation)
            {
                var source = (IList<ST_WMS_LoadDispatchingCartons_Result>)this.grd_WM_DispatchingCartons.DataSource;// lỗi
                totalWeight = (float)source.Sum(v => v.CartonWeight);
            }
            //else
            //{
            //    // var source = (IList<ST_WMS_DispatchingCartonByLocationID_Result>)this.grd_WM_DispatchingCartons.DataSource;
            //    var source = (IList<ST_WMS_LoadDispatchingCartons_Result>)this.grd_WM_DispatchingCartons.DataSource;
            //    totalWeight = (float)source.Sum(v => v.CartonWeight);
            //}


            foreach (var dispatchingCarton in this.listDataModify)
            {
                // Update status delected= true
                dispatchingProductDA.ExecuteNoQuery("Update DispatchingCartons set CartonWeight="
                    + dispatchingCarton.CartonWeight + " ,PalletCartonID= " + dispatchingCarton.PalletCartonID
                    + " ,DispatchingRemark='" + dispatchingCarton.DispatchingRemark + "' where DispatchingCartonID=" + dispatchingCarton.DispatchingCartonID);
            }
            int result = dispatchingProductDA.ExecuteNoQuery("STDispatchingCartonWeightUpdate @DispatchingProductID={0}", this.dispatchingProductID);
            DataProcess<ST_WMS_LoadDispatchingCartons_Result> dispatchingCartonDA = new DataProcess<ST_WMS_LoadDispatchingCartons_Result>();

            var dataSource = dispatchingCartonDA.Executing("ST_WMS_DispatchingCartonByLocationID @DispatchingLocationID={0}", this.dispatchingProductID);
            if (!this.isLocation)
                dispatchingCartonDA.ExecuteNoQuery("Update DispatchingOrderDetails set PalletWeight={0} where DispatchingOrderDetailID={1}", totalWeight, this.doDetailID);

            // Raise event to parent form update dispatching data
            this.OnRefreshDispatchingProduct(e);
            this.OnSetActiceParentControls(true, e);
        }


        private void grv_WM_DispatchingCartons_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;



            // Get dispatching carton ID of current selected row
            var dispatchingCartonSelected = (ST_WMS_LoadDispatchingCartons_Result)this.grv_WM_DispatchingCartons.GetRow(e.RowHandle);
            var oldDispatchingSelected = listDataModify.FirstOrDefault(d => d.DispatchingCartonID == dispatchingCartonSelected.DispatchingCartonID);
            if (oldDispatchingSelected != null) this.listDataModify.Remove(oldDispatchingSelected);
            this.listDataModify.Add(dispatchingCartonSelected);

        }



        private void btnImport_Click(object sender, EventArgs e)
        {
            frm_WM_ImportCartonWeight frmImport = new frm_WM_ImportCartonWeight("DO", dp.DispatchingProductID);
            frmImport.ShowDialog();
            this.InitData(this.dp, this.dispatchingProductID, this.totalWeightPerpackage, this.isLocation);
        }

        private void btnCreateCartons_Click(object sender, EventArgs e)
        {
            IList<string> customerTypeList = new List<string> { CustomerTypeEnum.RANDOM_WEIGHT };
            DataProcess<DispatchingOrders> doDA = new DataProcess<DispatchingOrders>();
            var customerID = doDA.Select(d => d.DispatchingOrderID == this.dp.DispatchingOrderID).FirstOrDefault().CustomerID;
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault();
            if (!customerTypeList.Contains(currentCustomer.CustomerType)) return;

            // Just only product has "Weight Required" then must display carton form
            var currentPro = AppSetting.ProductList.Where(p => p.ProductID == this.dp.ProductID).FirstOrDefault();
            if (currentPro == null || currentPro.IsWeightingRequire == null || !Convert.ToBoolean(currentPro.IsWeightingRequire)) return;
            bool isCreate = false;

            if (this.dp.TotalPackages > 100)
            {
                var dl = XtraMessageBox.Show("Quantity > 100ctns. Do you want to create?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl.Equals(DialogResult.Yes))
                {
                    isCreate = true;
                }
            }
            else
            {
                isCreate = true;
            }

            // Just only total weight perpackage<100 and total weight perpackage is allow by user then must process this code bellow
            if (!isCreate) return;

            // Insert dispatching carton into DB
            DataProcess<object> dispatchingCartonDA = new DataProcess<object>();

            var confirmMsg = MessageBox.Show("Do you want to create new dispatching cartons ID?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmMsg.Equals(DialogResult.Yes))
            {
                int result = dispatchingCartonDA.ExecuteNoQuery("STDispatchingCartonWeightInsert @DispatchingProductID={0},@CreatedBy={1}", this.dp.DispatchingProductID, AppSetting.CurrentUser.LoginName);
                if (result > 0) // Raise event to parent form update dispatching data
                    this.InitData(this.dp, this.dispatchingProductID, this.totalWeightPerpackage, this.isLocation);
            }
        }
        public BindingList<DispatchingOrderDetails> GetSourceGrid()
        {
            BindingList<DispatchingOrderDetails> _listDODetailsCarton = new BindingList<DispatchingOrderDetails>();
            DispatchingOrderDetailsDA _doDetailsCarton = new DispatchingOrderDetailsDA();
            _listDODetailsCarton = new BindingList<DispatchingOrderDetails>(_doDetailsCarton.Select(x => x.DispatchingLocationID == this.dispatchingProductID).ToList());
            return _listDODetailsCarton;
        }
        public decimal GetWeight()
        {
            return sumWeight;
        }

        private void grd_WM_DispatchingCartons_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grv_WM_DispatchingCartons.FocusedColumn.FieldName == "CartonWeight")
                {
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                    SendKeys.Send("{Tab}");
                }

            }
        }

        private void grv_WM_DispatchingCartons_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            // Raise event to parent form update dispatching data
            this.OnSetActiceParentControls(false, e);
        }

        private void btn_WM_AddOneCarton_Click(object sender, EventArgs e)
        {
            
             
            DataProcess<Object> DA = new DataProcess<object>();
            if (this.doDetailID == null|| this.doDetailID==0) {
                MessageBox.Show("Select Detail !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
           // var t = DA.Executing("SELECT * FROM DispatchingLocations WHERE DispatchingLocationID="+this.)
            if (this.grv_WM_DispatchingCartons.RowCount >= this.disOrderID)
            {
                MessageBox.Show("Can't add carton !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
             int result = DA.ExecuteNoQuery("INSERT INTO DispatchingCartons(CartonWeight,CreatedBy,DispatchingOrderDetailID) VALUES(0,'" + AppSetting.CurrentUser.LoginName + "'," + this.doDetailID + ")");
            // this.grd_WM_DispatchingCartons.DataSource = FileProcess.LoadTable("ST_WMS_LoadDispatchingCartons @DispatchingProductID=" + this.doDetailID);
            // var x = this.grv_WM_DispatchingCartons.RowCount;
            // this.InitData(this.dp, this.dispatchingProductID, this.totalWeightPerpackage, this.isLocation);
            DataProcess<ST_WMS_LoadDispatchingCartons_Result> dispatchingCartonDA = new DataProcess<ST_WMS_LoadDispatchingCartons_Result>();
            this.grd_WM_DispatchingCartons.DataSource = dispatchingCartonDA.Executing("ST_WMS_LoadDispatchingCartons @DispatchingProductID={0}", this.doDetailID);
          
           
            
        }
    }
}
