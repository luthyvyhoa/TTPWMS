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
    public partial class frm_WM_GatePropertyRemainByCustomer : frmBaseForm
    {
        private DataProcess<STPropertyRemainByCustomer_Result> dataProcess;
        public frm_WM_GatePropertyRemainByCustomer()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            dataProcess = new DataProcess<STPropertyRemainByCustomer_Result>();
            IList<STPropertyRemainByCustomer_Result> list = this.dataProcess.Executing("STPropertyRemainByCustomer").ToList();
            grdRemainByCustomer.DataSource = list;
        }
    }
}
