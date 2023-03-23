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
    public partial class frm_S_SJTHS_Dialog_EmployeeWorkingEditing : Common.Controls.frmBaseForm
    {
        private string _orderNumber;

        public string OrderNumberFind
        {
            get
            {
                return this._orderNumber;
            }
            set
            {
                this._orderNumber = value;
            }
        }

        public frm_S_SJTHS_Dialog_EmployeeWorkingEditing()
        {
            InitializeComponent();
        }

        private void frm_S_SJTHS_Dialog_EmployeeWorkingEditing_Load(object sender, EventArgs e)
        {
            this.grdEW.DataSource = FileProcess.LoadTable("SELECT EmployeeWorkings.*, Employees.VietnamName " +
                                                          "FROM EmployeeWorkings INNER JOIN Employees ON EmployeeWorkings.EmployeeID = Employees.EmployeeID " +
                                                          "WHERE(((EmployeeWorkings.Remark) = 'Boc xep')) AND EmployeeWorkings.OrderNumber = '"+this._orderNumber+"'");
        }
    }
}
