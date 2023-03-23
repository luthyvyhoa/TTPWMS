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
    public partial class frm_WM_InputCheckingDate : Form
    {
        public string MyString { get; set; }

        public frm_WM_InputCheckingDate()
        {
            InitializeComponent();
            daDate.Text = DateTime.Now.Date.ToShortDateString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(daDate.Text!="")
                MyString = Convert.ToDateTime(daDate.EditValue).ToString();
            this.Close();
        }
    }
}
