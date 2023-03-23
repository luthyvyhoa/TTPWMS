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
using UI.Helper;
using UI.MasterSystemSetup;
using UI.StockTake;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Label : frmBaseForm
    {      

        public frm_WM_Label()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;            
        }

        private void frm_WM_Find_Load(object sender, EventArgs e)        {
            
            SetEvents();
        }

        private void SetEvents()
        {
            
        }         

    }
}
