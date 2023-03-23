using Common.Process;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using Common.Process;

namespace UI.Management
{
    public partial class frm_M_SDT_ReportToCustomer : Common.Controls.frmBaseForm
    {
        private byte _sendMode;

        public frm_M_SDT_ReportToCustomer()
        {
            InitializeComponent();
            this._sendMode = 1;
        }

        private void frm_M_SDT_ReportToCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetEvents();
        }

        private void SetEvents()
        {
            this.chkAll.EditValueChanging += CheckedChanging;
            this.chkAll.CheckedChanged += CheckedChanged;
            this.chkFax.EditValueChanging += CheckedChanging;
            this.chkFax.CheckedChanged += CheckedChanged;
            this.chkEmail.EditValueChanging += CheckedChanging;
            this.chkEmail.CheckedChanged += CheckedChanged;
            this.chkOperated.CheckedChanged += ChkOperated_CheckedChanged;
            this.btnOpen.Click += BtnOpen_Click;
            this.btnActive.Click += BtnActive_Click;
            this.btnSentReport.Click += BtnSentReport_Click;
            this.btnSelected.Click += BtnSelected_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void CheckedChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if(!Convert.ToBoolean(e.NewValue))
            {
                if(this._sendMode == Convert.ToByte(edit.Tag))
                {
                    e.Cancel = true;
                }
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;

            if(edit.Checked)
            {
                byte prevMode = this._sendMode;
                this._sendMode = Convert.ToByte(edit.Tag);
                UncheckPreviousOption(prevMode);
            }
        }

        private void ChkOperated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOperated.Checked)
            {
                DateTime fromDate = DateTime.Now.AddDays(-30);
                DateTime toDate = DateTime.Now;
                this.grdCustomers.DataSource = FileProcess.LoadTable("ST_WMS_LoadActiveCustomers @From = '" + fromDate.ToString("yyyy-MM-dd") + "', @To = '" + toDate.ToString("yyyy-MM-dd") + "'");
                this.grvCustomers.ClearSelection();
            }
            else
            {
                LoadCustomers();
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
        }

        private void BtnActive_Click(object sender, EventArgs e)
        {
            this.grdCustomers.DataSource = FileProcess.LoadTable("STCustomersActive");
            this.grvCustomers.ClearSelection();
        }

        private void BtnSentReport_Click(object sender, EventArgs e)
        {
            try
            {
                Wait.Start(this);
                DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = FileProcess.LoadTable("Select * From ReportToCustomer");
                grvReport.PopulateColumns();

                // Export data to excel file
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "ReportSent_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

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

        private void BtnSelected_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.txtFile.Text))
            {
                XtraMessageBox.Show("No file to send, Can Not Send !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(this.grvCustomers.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Please select the Customer !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(XtraMessageBox.Show("Are you sure to send this report to the selected customers ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch(this._sendMode)
                {
                    case 1:
                        {
                            SendEmail();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            SendEmail();                            
                            break;
                        }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCustomers()
        {
            this.grdCustomers.DataSource = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false).OrderBy(c => c.CustomerNumber);
            this.grvCustomers.ClearSelection();
        }

        private void UncheckPreviousOption(byte prevOption)
        {
            switch(prevOption)
            {
                case 1:
                    {
                        this.chkAll.Checked = false;
                        break;
                    }
                case 2:
                    {
                        this.chkFax.Checked = false;
                        break;
                    }
                case 3:
                    {
                        this.chkEmail.Checked = false;
                        break;
                    }
            }
        }

        private void SendEmail()
        {
            int[] selectedRows = this.grvCustomers.GetSelectedRows();

            foreach(int rowHandle in selectedRows)
            {
                string email = Convert.ToString(this.grvCustomers.GetRowCellValue(rowHandle, "Email"));

                if(!String.IsNullOrEmpty(email))
                {
                    string sendObject = this.txtFile.Text;
                    string body= "Please find the attached report";
                    string customerName = Convert.ToString(this.grvCustomers.GetRowCellValue(rowHandle, "CustomerName"));
                    string sendBy = AppSetting.CurrentUser.LoginName;
                    string sendAddress = Convert.ToString(this.grvCustomers.GetRowCellValue(rowHandle, "Address"));
                    DateTime sendTime = DateTime.Now;
                    DataTransfer.SendMail("", "Automatic Report from Kỷ Nguyên Mới", body, sendObject);
                    InsertToSentReport(sendObject, customerName, sendTime, sendBy, sendAddress);
                }
            }
        }

        private void InsertToSentReport(string sendObject, string customerName, DateTime sendTime, string sendBy, string sendAddress)
        {
            DataProcess<ReportToCustomer> sentReportDA = new DataProcess<ReportToCustomer>();
            ReportToCustomer item = new ReportToCustomer();
            item.SendObject = sendObject;
            item.CustomerName = customerName;
            item.SentTime = sendTime;
            item.SentBy = sendBy;
            item.SendAddress = sendAddress;

            int result = sentReportDA.Insert(item);
        }

        private void btnSentReport_Click_1(object sender, EventArgs e)
        {

        }
    }
}
