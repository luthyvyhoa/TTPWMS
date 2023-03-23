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

namespace UI.Management
{
    public partial class frm_M_SDT_CompactDatabase : Common.Controls.frmBaseForm
    {
        public frm_M_SDT_CompactDatabase()
        {
            InitializeComponent();
            this.dtRecommendDate.EditValue = DateTime.Now.AddDays(-10);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompact_Click(object sender, EventArgs e)
        {
            DataProcess<object> da = new DataProcess<object>();
            int result = da.ExecuteNoQuery("STDelete_CompactDatabase @varReportDate = {0}", this.dtRecommendDate.DateTime);
            if(result != -2)
            {
                XtraMessageBox.Show("Process complete !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Process failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
