using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;
using UI.WarehouseManagement;

namespace UI.Supperviors
{
    public partial class frm_S_SJTHS_EmployeeWorkingCheck : Common.Controls.frmBaseForm
    {
        private DataTable _tbEW;
        private int employeeID = 0;
        private string suppervisorDate = string.Empty;

        public frm_S_SJTHS_EmployeeWorkingCheck(int employeeID = 0, string suppervisorDate = "")
        {
            InitializeComponent();
            this.dtFrom.EditValue = DateTime.Now.AddDays(-7);
            this.dtTo.EditValue = DateTime.Now;
            this.employeeID = employeeID;
            this.suppervisorDate = suppervisorDate;
            this.grvEmployeeWorking.OptionsBehavior.ReadOnly = true;
            this.grvROCheck.OptionsBehavior.ReadOnly = true;
            this.grvDOCheck.OptionsBehavior.ReadOnly = true;
            this._tbEW = new DataTable();
        }

        private void frm_S_SJTHS_EmployeeWorkingCheck_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            if (this.employeeID > 0)
            {
                this._tbEW = FileProcess.LoadTable("STEmployeeWorkingViewByDate @EmployeeID = " + this.employeeID + ", @ReportDate = '" + this.suppervisorDate + "'");
            }
            else
            {
                this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = null");
            }

            LoadEW();
            SetEvents();
            Wait.Close();
        }

        private void SetEvents()
        {
            this.rpi_hpl_Sum.DoubleClick += Rpi_hpl_Sum_DoubleClick;
            this.rpi_hpl_EWOrder.Click += Rpi_hpl_EWOrder_Click;
            this.rpi_btn_ToOrder.Click += Rpi_btn_ToOrder_Click;
            this.rpi_btn_ToRO.Click += Rpi_btn_ToRO_Click;
            this.rpi_btn_ToDO.Click += Rpi_btn_ToDO_Click;
            this.rdgFilter.EditValueChanged += RdgFilter_EditValueChanged;
            this.btnRO.CheckedChanged += BtnRO_CheckedChanged;
            this.btnDO.CheckedChanged += BtnDO_CheckedChanged;
            this.btnReport.Click += BtnReport_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void Rpi_hpl_Sum_DoubleClick(object sender, EventArgs e)
        {
            DateTime orderDate = Convert.ToDateTime(this.grvEmployeeWorking.GetFocusedRowCellValue("OrderDate"));

            if (orderDate > DateTime.Now.AddDays(-26))
            {
                //Open frmEmployeeWorkingEditing
                frm_S_SJTHS_Dialog_EmployeeWorkingEditing frm = new frm_S_SJTHS_Dialog_EmployeeWorkingEditing();
                frm.OrderNumberFind = Convert.ToString(this.grvEmployeeWorking.GetFocusedRowCellValue("OrderNumber"));
                frm.Show();
            }
        }

        private void Rpi_hpl_EWOrder_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvEmployeeWorking.GetFocusedRowCellValue("OrderNumber"));
            int orderID = Convert.ToInt32(orderNumber.Substring(3));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void Rpi_btn_ToOrder_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvEmployeeWorking.GetFocusedRowCellValue("OrderNumber"));
            int orderID = Convert.ToInt32(orderNumber.Substring(3));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void Rpi_btn_ToRO_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvROCheck.GetFocusedRowCellValue("OrderID"));

            frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
            frm_WM_ReceivingOrders.Instance.Show();
        }

        private void Rpi_btn_ToDO_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(this.grvDOCheck.GetFocusedRowCellValue("OrderID"));

            var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
            if (frmDispatching.Visible)
            {
                frmDispatching.ReloadData();
            }
            frmDispatching.Show();
        }

        private void RdgFilter_EditValueChanged(object sender, EventArgs e)
        {
            Wait.Start(this);
            byte filterMode = Convert.ToByte(this.rdgFilter.EditValue);

            switch (filterMode)
            {
                case 0:
                    {
                        this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = null");
                        break;
                    }
                case 1:
                    {
                        this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 1");
                        break;
                    }
                case 2:
                    {
                        this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 2");
                        break;
                    }
                case 3:
                    {
                        this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 3");
                        break;
                    }
                case 4:
                    {
                        this._tbEW = FileProcess.LoadTable("STEmployeeWorkingCheckPercent @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @Flag = 4");
                        break;
                    }
            }

            LoadEW();
            Wait.Close();
        }

        private void BtnRO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnRO.Checked)
            {
                this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (this.grdROCheck.DataSource == null)
                {
                    LoadRO();
                }
            }
            else
            {
                this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void BtnDO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnDO.Checked)
            {
                this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (this.grdDOCheck.DataSource == null)
                {
                    LoadDO();
                }
            }
            else
            {
                this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                GridControl grdReport = new GridControl();
                GridView grvReport = new GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = this._tbEW;
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "EmployeeWorkingInvalidPercent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

                grvReport.ExportToXlsx(fileName);

                System.Diagnostics.Process.Start(fileName);
                Wait.Close();
            }
            catch (Exception ex)
            {
                Wait.Close();
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadEW()
        {
            this.grdEmployeeWorking.DataSource = this._tbEW;
        }

        private void LoadRO()
        {
            this.grdROCheck.DataSource = FileProcess.LoadTable("STEmployeeWorkingInvalidRO");
        }

        private void LoadDO()
        {
            this.grdROCheck.DataSource = FileProcess.LoadTable("STEmployeeWorkingInvalidDO");
        }
    }
}
