using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.MasterSystemSetup;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindEmployee : UserControl
    {
        public urc_WM_FindEmployee()
        {
            InitializeComponent();
        }

        public void Find()
        {
            if(String.IsNullOrEmpty(this.txtFirstName.Text) && String.IsNullOrEmpty(this.txtLastName.Text))
            {
                XtraMessageBox.Show("Please enter condition to find !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(String.IsNullOrEmpty(this.txtFirstName.Text))
                {
                    frm_MSS_EmployeesList frmEmployeeList = new frm_MSS_EmployeesList(this.txtLastName.Text);
                    frmEmployeeList.Show();
                }
                else
                {
                    if(String.IsNullOrEmpty(this.txtLastName.Text))
                    {
                        frm_MSS_EmployeesList frmEmployeeList = new frm_MSS_EmployeesList(this.txtFirstName.Text);
                        frmEmployeeList.Show();
                    }
                    else
                    {
                        frm_MSS_EmployeesList frmEmployeeList = new frm_MSS_EmployeesList(this.txtLastName.Text + " " + this.txtFirstName.Text);
                        frmEmployeeList.Show();
                    }
                }
            }
        }
    }
}
