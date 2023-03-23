using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System;
using Common.Controls;
using UI.Helper;
using DA;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using System.Drawing;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_PalletListSyncNavi : frmBaseForm
    {
        public frm_MSS_PalletListSyncNavi()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_MSS_PalletListSyncNavi_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void btn_SyncNavi_Click(object sender, EventArgs e)
        {

        }

        private void btn_CancelSync_Click(object sender, EventArgs e)
        {

        }
    }
}
