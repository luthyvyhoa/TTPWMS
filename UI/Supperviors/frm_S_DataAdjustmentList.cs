using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Supperviors
{
    public partial class frm_S_DataAdjustmentList : frmBaseForm
    {
        public frm_S_DataAdjustmentList()
        {
            InitializeComponent();
            this.LoadDataList();
        }

        private void LoadDataList()
        {
            this.grdDataAdjustments.DataSource = FileProcess.LoadTable("Select * from DataAdjustments");
        }
    }
}
