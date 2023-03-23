using DA;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_DispatchingDetailProduct : UserControl
    {
        private int dispatchingLocationID;
        public urc_WM_DispatchingDetailProduct(int dispatchingLocationID)
        {
            InitializeComponent();
            this.dispatchingLocationID = dispatchingLocationID;
            this.Dock = DockStyle.Fill;
            this.LoadDispatchingLocationAtDispatch();
        }

        private void LoadDispatchingLocationAtDispatch()
        {
            DataProcess<STDispatchingLocationAtDispatch_Result> _dpAtDispatch = new DataProcess<STDispatchingLocationAtDispatch_Result>();
            this.grdDPLocationDetails.DataSource = _dpAtDispatch.Executing("STDispatchingLocationAtDispatch @DispatchingLocationID = {0}", this.dispatchingLocationID);
        }
    }
}
