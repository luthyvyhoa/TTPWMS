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
using UI.Helper;

namespace UI.StockTake
{
    public partial class frm_ST_ReasonLostLocation : frmBaseForm
    {
        public frm_ST_ReasonLostLocation()
        {
            InitializeComponent();

            this.lkeEmployee.Properties.DataSource = AppSetting.EmployessList;
            this.lkeEmployee.Properties.DisplayMember = "VietnamName";
            this.lkeEmployee.Properties.ValueMember = "EmployeeID";
        }

        /// <summary>
        /// Get current employeeID selected
        /// </summary>
        public int EmployeeID { get; private set; }

        /// <summary>
        /// Get reasons
        /// </summary>
        public string Reasons { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.lkeEmployee.EditValue == null)
            {
                this.lkeEmployee.Focus();
                this.lkeEmployee.ShowPopup();
                return;
            }

            if (string.IsNullOrEmpty(this.mmReasons.Text))
            {
                this.lkeEmployee.Focus();
                return;
            }

            this.EmployeeID = Convert.ToInt32(this.lkeEmployee.EditValue);
            this.Reasons = this.mmReasons.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
