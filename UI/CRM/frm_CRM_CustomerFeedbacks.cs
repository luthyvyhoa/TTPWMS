using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.WarehouseManagement;

namespace UI.CRM
{
    public partial class frm_CRM_CustomerFeedbacks : Common.Controls.frmBaseForm
    {
        private DataTable _tbFeedbacks;

        public frm_CRM_CustomerFeedbacks()
        {
            InitializeComponent();
            this._tbFeedbacks = new DataTable();
        }

        private void frm_CRM_CustomerFeedbacks_Load(object sender, EventArgs e)
        {
            this._tbFeedbacks = FileProcess.LoadTable("SELECT Feedbacks.FeedbackID, Feedbacks.FeedbackDate, Feedbacks.UserName, Feedbacks.IPClient, Feedbacks.FeedbackDescription, Feedbacks.ResponsedDescription, Feedbacks.ResponsedBy, Feedbacks.ResponsedTime, Feedbacks.CustomerID, Customers.CustomerNumber, Customers.CustomerName, Feedbacks.Status " +
                                                                 "FROM Feedbacks INNER JOIN Customers ON Feedbacks.CustomerID = Customers.CustomerID " +
                                                                 "ORDER BY Feedbacks.FeedbackID DESC;");
            InitCustomers();
            InitStatus();
            LoadFeedbacks();
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnNew.Click += BtnNew_Click;
            this.btnClose.Click += BtnClose_Click;
            this.chkAll.CheckedChanged += ChkAll_CheckedChanged;
            this.chkCustomer.CheckedChanged += ChkCustomer_CheckedChanged;
            this.grvFeedbacks.CellValueChanged += GrvFeedbacks_CellValueChanged;
            this.rpi_dt_ResponsedTime.EditValueChanging += Rpi_dt_ResponsedTime_EditValueChanging;
        }

        private void Rpi_dt_ResponsedTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(Convert.ToDateTime(e.NewValue) < DateTime.Now.AddDays(-1) || Convert.ToDateTime(e.NewValue) > DateTime.Now.AddDays(30))
            {
                XtraMessageBox.Show("Ngay khong hop le !!!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void GrvFeedbacks_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> feedbackDA = new DataProcess<object>();
            int result = -2;

            switch(e.Column.FieldName)
            {
                case "ResponsedTime":
                    {
                        result = feedbackDA.ExecuteNoQuery("Update Feedbacks Set ResponsedTime = {0} Where FeedbackID = {1}", Convert.ToDateTime(e.Value), Convert.ToInt32(this.grvFeedbacks.GetRowCellValue(e.RowHandle, "FeedbackID")));
                        break;
                    }
                case "FeedbackDescription":
                    {
                        result = feedbackDA.ExecuteNoQuery("Update Feedbacks Set FeedbackDescription = {0} Where FeedbackID = {1}", Convert.ToString(e.Value), Convert.ToInt32(this.grvFeedbacks.GetRowCellValue(e.RowHandle, "FeedbackID")));
                        break;
                    }
                case "ResponsedDescription":
                    {
                        result = feedbackDA.ExecuteNoQuery("Update Feedbacks Set ResponsedDescription = {0} Where FeedbackID = {1}", Convert.ToString(e.Value), Convert.ToInt32(this.grvFeedbacks.GetRowCellValue(e.RowHandle, "FeedbackID")));
                        break;
                    }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry();
            frm.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkCustomer.Checked)
            {
                this.chkAll.Checked = false;
                this.lkeCustomers.ReadOnly = false;
                this.lkeCustomers.Focus();
                this.lkeCustomers.ShowPopup();
            }
            else
            {
                this.lkeCustomers.ReadOnly = true;
            }
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkAll.Checked)
            {
                this.chkCustomer.Checked = false;
            }
        }
        #region Load Data
        private void InitStatus()
        {
            
        }

        private void InitCustomers()
        {
            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("SELECT Gate_Companies.CompanyID, Gate_Companies.CompanyNumber, Gate_Companies.CompanyName " +
                                                                            "FROM Gate_Companies " +
                                                                            "ORDER BY Gate_Companies.CompanyName; ");
            this.lkeCustomers.Properties.ValueMember = "CompanyID";
            this.lkeCustomers.Properties.DisplayMember = "CompanyName";
        }

        private void LoadFeedbacks()
        {
            this.grdFeedbacks.DataSource = this._tbFeedbacks;
        }
        #endregion

        private void grdFeedbacks_Click(object sender, EventArgs e)
        {

        }
    }
}
