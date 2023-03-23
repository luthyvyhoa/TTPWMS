using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_OtherJobTheSameTime : frmBaseForm
    {
        private int mhlWorkID = 0;
        public frm_WM_OtherJobTheSameTime(int mhlWorkID)
        {
            InitializeComponent();
            this.mhlWorkID = mhlWorkID;
            this.InitData(this.mhlWorkID);
        }

        public void InitData(int mhlWorkID)
        {
            this.mhlWorkID = mhlWorkID;
            DataProcess<STMHLWorkTheSameTime_Result> mhlWorkTheSametimeDA = new DataProcess<STMHLWorkTheSameTime_Result>();
            this.grdOtherJobTheSameTime.DataSource = mhlWorkTheSametimeDA.Executing(" STMHLWorkTheSameTime @MHLWorkID={0}", this.mhlWorkID);
        }

        private void frm_WM_OtherJobTheSameTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
