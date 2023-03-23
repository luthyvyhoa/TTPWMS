using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using System;
using DA;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_DOLocations : UserControl
    {

        private DataProcess<STPalletInformationByProduct_Result> _dpPalletInfo;
        private DataProcess<STDispatchingLocationAtDispatch_Result> _dpAtDispatch;
        private DispatchingProducts _dp;
        private int _selectedLocationID;
        private urc_WM_DOLocations()
        {
            InitializeComponent();
        }

        public urc_WM_DOLocations(DispatchingProducts dp)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._dpPalletInfo = new DataProcess<STPalletInformationByProduct_Result>();
            this._dpAtDispatch = new DataProcess<STDispatchingLocationAtDispatch_Result>();
            this._dp = dp;
        }

        private void urc_WM_DOLocations_Load(object sender, System.EventArgs e)
        {
            LoadPalletInformation();
        }

        #region Load Data

        private void LoadPalletInformation()
        {
            this.grdDPPalletInfo.DataSource = this._dpPalletInfo.Executing("STPalletInformationByProduct @ProductID = {0}", this._dp.ProductID);
        }

    
        #endregion

        public void LocationIDChanged(int dispatchingLocationID)
        {
            this._selectedLocationID = dispatchingLocationID;
        }

        public void ReloadData()
        {
            LoadPalletInformation();
        }
    }
}
