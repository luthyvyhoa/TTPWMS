using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Text;
using System.Linq;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DispatchingLocationSelect : frmBaseForm
    {
        private int productID = -1;
        private string customerType = string.Empty;
        private int dispatchingOrderID = -1;
        private decimal weightPerPackage = 0;
        private string dispatchingOrderNumber = string.Empty;
        private bool isShowDetail = false;

        public frm_WM_DispatchingLocationSelect(int productSelected, string customertype, int dispatchingOrderID, decimal weightPerPackage, string dispatchingOrderNumber)
        {
            // Init controls to designer
            InitializeComponent();

            // Set params
            this.productID = productSelected;
            this.customerType = customertype;
            this.dispatchingOrderID = dispatchingOrderID;
            this.weightPerPackage = weightPerPackage;
            this.dispatchingOrderNumber = dispatchingOrderNumber;

            // Set param to init data
            this.LoadLocationData();
        }

        /// <summary>
        /// Get state user has selected products
        /// </summary>
        public bool IsShowDetail
        {
            get
            {
                return this.isShowDetail;
            }
        }

        /// <summary>
        /// Detected user has selected value
        /// </summary>
        public bool HasSelectedValue { get; private set; } = false;


        private void LoadLocationData()
        {
            DataProcess<STDispatchingProductSelectLocation_Order_Result> locationDA = new DataProcess<STDispatchingProductSelectLocation_Order_Result>();
            this.grd_WM_LocationData.DataSource = locationDA.Executing("STDispatchingProductSelectLocation_Order @ProductID={0}", this.productID);
        }

        private void btn_WM_Cancel_Click(object sender, System.EventArgs e)
        {
            this.isShowDetail = false;
            this.Close();
        }

        private void btn_WM_Selected_Click(object sender, System.EventArgs e)
        {
            if (this.grv_WM_LocationData.SelectedRowsCount <= 0)
            {
                MessageBox.Show("Please select locations !");
                return;
            }

            // Get all palletID selected
            int count = 0;
            int quantitySelected = 0;
            StringBuilder palletIDList = new StringBuilder();
            palletIDList.Append("(");
            foreach (int palletID in this.grv_WM_LocationData.GetSelectedRows())
            {
                var dispatchingLocation = (STDispatchingProductSelectLocation_Order_Result)grv_WM_LocationData.GetRow(palletID);
                palletIDList.Append(dispatchingLocation.PalletID);
                quantitySelected += (int)dispatchingLocation.Qty;
                if (count < grv_WM_LocationData.GetSelectedRows().Count() - 1)
                {
                    palletIDList.Append(",");
                    count++;
                }
            }
            palletIDList.Append(")");

            // Confirm to select
            DialogResult dl = MessageBox.Show("Do you want to dispatch " + quantitySelected + " ctns?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl.Equals(DialogResult.No)) return;

            // Insert location selected
            this.isShowDetail = true;
            DataProcess<object> dispatchingLocationDA = new DataProcess<object>();
            if (this.customerType.Equals(CustomerTypeEnum.RANDOM_WEIGHT))
            {

                dispatchingLocationDA.ExecuteNoQuery("STDispatchingProductInsertByLocationRandomWeight " +
                    " @varDispatchingOrderID={0}," +
                    " @varProductID={1}," +
                    " @varPickingQuantity={2}," +
                    " @varWeightPerPackage={3}," +
                    " @varDispatchingOrderNumer={4}," +
                    " @varCondition={5}," +
                    " @UserID={6}",
                    this.dispatchingOrderID,
                    this.productID,
                    short.Parse(this.txt_WM_MaxQuantity.Text),
                    this.weightPerPackage,
                    this.dispatchingOrderNumber,
                    palletIDList.ToString(),
                    AppSetting.CurrentUser.LoginName);
            }
            else
            {
                dispatchingLocationDA.ExecuteNoQuery("STDispatchingProductInsertByLocation_New " +
                    " @varDispatchingOrderID={0}," +
                    " @varProductID={1}," +
                    " @varPickingQuantity={2}," +
                    " @varWeightPerPackage={3}," +
                    " @varDispatchingOrderNumer={4}," +
                    " @varCondition={5}," +
                    " @UserID={6}",
                    this.dispatchingOrderID,
                    this.productID,
                    short.Parse(this.txt_WM_MaxQuantity.Text),
                    this.weightPerPackage,
                    this.dispatchingOrderNumber,
                    palletIDList.ToString(),
                    AppSetting.CurrentUser.LoginName);
            }
            this.HasSelectedValue = true;
            this.Close();
        }

        private void grv_WM_LocationData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (this.grv_WM_LocationData.SelectedRowsCount <= 0) return;
            int totalQty = 0;
            STDispatchingProductSelectLocation_Order_Result currentObj = null;
            foreach (int rowIndex in this.grv_WM_LocationData.GetSelectedRows())
            {
                currentObj = (STDispatchingProductSelectLocation_Order_Result)this.grv_WM_LocationData.GetRow(rowIndex);
                totalQty += currentObj.Qty;
            }

            this.txt_WM_MaxQuantity.Text = totalQty.ToString();
        }
    }
}
