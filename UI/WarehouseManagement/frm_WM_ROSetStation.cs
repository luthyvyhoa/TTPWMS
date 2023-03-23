using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
using DA.Warehouse;
using DevExpress.XtraEditors;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_WM_ROSetStation : frmBaseForm
    {
        public List<int> lstPalletId = new List<int>();
        public List<STVSPalletAllocation_Result> listLocation;
        public string receivingOrderNumber;
        public frm_WM_ROSetStation()
        {
            InitializeComponent();

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            this.LoadStation();
        }

        private void LoadStation()
        {
            DataTable dtStation = FileProcess.LoadTable("SELECT * FROM dbo.Station order by Station");
            this.lke_MSS_StationList.Properties.DataSource = dtStation;
            this.lke_MSS_StationList.Properties.ValueMember = "Station";
            this.lke_MSS_StationList.Properties.DisplayMember = "Station";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lke_MSS_StationList.EditValue == null)
            {
                MessageBox.Show("Station is invalid, please re-check it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (XtraMessageBox.Show("Are you sure to set Station pallets ?", "TPWMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            var lstLocation = this.listLocation.Where(x => x.X == this.lke_MSS_StationList.EditValue.ToString()).ToList();
            DataProcess<STLabel1Label_Result> label = new DataProcess<STLabel1Label_Result>();
            foreach (int palletId in lstPalletId)
            {
                var location = lstLocation.FirstOrDefault();

                SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand("ST_WMS_CreateLocationStations", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ReceivingOrderNumber = cmd.Parameters.Add("@ReceivingOrderNumber", SqlDbType.NVarChar);
                ReceivingOrderNumber.Value = this.receivingOrderNumber;

                SqlParameter PalletID = cmd.Parameters.Add("@PalletID", SqlDbType.Int);
                PalletID.Value = palletId;

                SqlParameter LocationID = cmd.Parameters.Add("@LocationID", SqlDbType.Int);
                LocationID.Value = location.LocationID;

                SqlParameter LocationNumber = cmd.Parameters.Add("@LocationNumber", SqlDbType.NVarChar);
                LocationNumber.Value = location.LocationNumber;

                conn.Open();
                cmd.ExecuteNonQuery();

                lstLocation.Remove(location);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lke_MSS_StationList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_MSS_StationList.EditValue == null) return;
            var lstLocation = this.listLocation.Where(x => x.X == this.lke_MSS_StationList.EditValue.ToString()).ToList();
            if (lstLocation.Count() == 0)
            {
                MessageBox.Show("Station is not Location, please re-check it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lke_MSS_StationList.EditValue = null;
                return;
            }
        }
    }
}
