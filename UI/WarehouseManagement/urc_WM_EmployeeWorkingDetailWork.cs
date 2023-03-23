using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_EmployeeWorkingDetailWork : UserControl
    {
        private int _employeeID;
        private DateTime _orderDate;

        public urc_WM_EmployeeWorkingDetailWork(int employeeID, DateTime orderDate)
        {
            InitializeComponent();
            this._employeeID = employeeID;
            this._orderDate = orderDate;
        }

        private void urc_WM_EmployeeWorkingDetailWork_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataProcess<STEmployeeWorkingDetailOverTimes_Result> ewDA = new DataProcess<STEmployeeWorkingDetailOverTimes_Result>();

            this.grdWEDetail.DataSource = ewDA.Executing("STEmployeeWorkingDetailOverTimes @EmployeeID = {0}, @OrderDate = {1}", this._employeeID, this._orderDate);
        }

        public void RefreshData(int employeeID, DateTime orderDate)
        {
            this._employeeID = employeeID;
            this._orderDate = orderDate;
            LoadData();
        }
    }
}
