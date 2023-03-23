using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;

namespace UI.Supperviors
{
    public partial class frm_S_PCO_Dialog_EmployeeInOutIncorrect : Common.Controls.frmBaseForm
    {
        private DataProcess<STGate_EmployeeInOutIncorrect_Result> _employeeInOutDA;

        public frm_S_PCO_Dialog_EmployeeInOutIncorrect()
        {
            InitializeComponent();
            this._employeeInOutDA = new DataProcess<STGate_EmployeeInOutIncorrect_Result>();
        }

        private void frm_S_PCO_Dialog_EmployeeInOutIncorrect_Load(object sender, EventArgs e)
        {
            LoadData();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_hpl_EmployeeID.DoubleClick += rpi_hpl_EmployeeID_DoubleClick;
            this.rpi_btn_AdjustTime.Click += Rpi_btn_AdjustTime_Click;
        }

        private void LoadData()
        {
            this.grdEmployeeInOut.DataSource = this._employeeInOutDA.Executing("STGate_EmployeeInOutIncorrect");
        }

        private void Rpi_btn_AdjustTime_Click(object sender, EventArgs e)
        {
            STGate_EmployeeInOutIncorrect_Result row = this.grvEmployeeInOut.GetFocusedRow() as STGate_EmployeeInOutIncorrect_Result;

            frm_S_PCO_Dialog_EmployeeInOutIncorrectAdjust frm = new frm_S_PCO_Dialog_EmployeeInOutIncorrectAdjust(row);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void rpi_hpl_EmployeeID_DoubleClick(object sender, EventArgs e)
        {
            //Open frm PayrollViewByEmployee
            int employeeID = Convert.ToInt32(this.grvEmployeeInOut.GetFocusedRowCellValue("EmployeeID"));

            frm_S_PCO_Dialog_PayrollViewByEmployee frm = new frm_S_PCO_Dialog_PayrollViewByEmployee(employeeID);
            frm.Show();
        }
    }
}
