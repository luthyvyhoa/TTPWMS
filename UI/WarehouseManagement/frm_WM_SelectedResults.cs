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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_SelectedResults : frmBaseForm
    {
        private IList<STContainerCheckingHistories_Result> dataSource = null;
        public frm_WM_SelectedResults()
        {
            InitializeComponent();
        }

        public void setData(IList<STContainerCheckingHistories_Result> DataSource)
        {
            dataSource = DataSource;
            grdHistories.DataSource = dataSource;
        }
    }
}
