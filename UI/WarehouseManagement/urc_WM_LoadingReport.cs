using DA;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_LoadingReport : UserControl
    {
        int dispatchingOrderID = 0;
        private BindingList<LoadingReportDetail> bindingList = null;
        private DataProcess<LoadingReportDetail> loadingDetailDA = new DataProcess<LoadingReportDetail>();
        private DataProcess<ST_WMS_LoadingReportByDispatchingID_Result> dataProcess = new DataProcess<ST_WMS_LoadingReportByDispatchingID_Result>();
        private ST_WMS_LoadingReportByDispatchingID_Result currentLoading = null;
        public urc_WM_LoadingReport(int dispatchingOrderID)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.dispatchingOrderID = dispatchingOrderID;
            this.InitEvents();
            this.LoadCustomer();
            this.InitData(dispatchingOrderID);
        }

        public void InitData(int dispatchingOrderID)
        {
            DataProcess<LoadingReports> loadingReportDA = new DataProcess<LoadingReports>();
            int isExist = loadingReportDA.Select(l => l.DispatchingOrderID == dispatchingOrderID).Count();
            if (isExist <= 0)
            {
                int resultAddNew = loadingReportDA.ExecuteNoQuery("STLoadingReportInsert @DispatchingOrderID={0},@UserName={1}", dispatchingOrderID, AppSetting.CurrentUser.LoginName);
            }
            var datasource = this.dataProcess.Executing("ST_WMS_LoadingReportByDispatchingID @DispatchingOrderID={0}", dispatchingOrderID);
            this.currentLoading = datasource.FirstOrDefault();
            this.BindingData();
            this.LoadProductByCustomer();
            this.LoadDetails();
            this.ValidateConfirmedData();
        }

        private void InitEvents()
        {
            this.lkeCustomers.CloseUp += LkeCustomers_CloseUp;
            this.lkeCustomers.EditValueChanged += LkeCustomers_EditValueChanged;
            this.rpi_lke_Products.CloseUp += Rpi_lke_Products_CloseUp;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnView.Click += BtnView_Click;
            this.btnViewDetail.Click += BtnViewDetail_Click;
            this.grvLoadingReport.CellValueChanged += GrvLoadingReport_CellValueChanged;
            this.mmRemark.EditValueChanged += MmRemark_EditValueChanged;
            this.dStart.EditValueChanged += DStart_EditValueChanged;
            this.dStop.EditValueChanged += DStop_EditValueChanged;
            this.txtSealNo.TextChanged += TxtSealNo_TextChanged;
        }

        private void TxtSealNo_TextChanged(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            DataProcess<LoadingReports> reportDA = new DataProcess<LoadingReports>();
            var currentLoading = reportDA.Select(r => r.LoadingReportID == this.currentLoading.LoadingReportID).FirstOrDefault();
            currentLoading.SealNumber = this.txtSealNo.Text;
            reportDA.Update(currentLoading);
        }

        private void DStop_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentLoading == null || this.dStop.EditValue == null) return;
            DataProcess<LoadingReports> reportDA = new DataProcess<LoadingReports>();
            var currentLoading = reportDA.Select(r => r.LoadingReportID == this.currentLoading.LoadingReportID).FirstOrDefault();
            currentLoading.EndTime = Convert.ToDateTime(this.dStop.EditValue);
            reportDA.Update(currentLoading);
        }

        private void DStart_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentLoading == null || this.dStart.EditValue == null) return;
            DataProcess<LoadingReports> reportDA = new DataProcess<LoadingReports>();
            var currentLoading = reportDA.Select(r => r.LoadingReportID == this.currentLoading.LoadingReportID).FirstOrDefault();
            currentLoading.StartTime = Convert.ToDateTime(this.dStart.EditValue);
            reportDA.Update(currentLoading);
        }

        private void MmRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            DataProcess<LoadingReports> reportDA = new DataProcess<LoadingReports>();
            var currentLoading = reportDA.Select(r => r.LoadingReportID == this.currentLoading.LoadingReportID).FirstOrDefault();
            currentLoading.SpecialRequirement = this.mmRemark.Text;
            reportDA.Update(currentLoading);
        }

        private void GrvLoadingReport_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int loadingDetailID = Convert.ToInt32(this.grvLoadingReport.GetFocusedRowCellValue("LoadingReportDetailID"));
            switch (e.Column.FieldName)
            {
                case "Quantity":
                    if (loadingDetailID <= 0)
                    {
                        var newReportDetail = this.bindingList[e.RowHandle];
                        newReportDetail.LoadingReportID = this.currentLoading.LoadingReportID;
                        this.loadingDetailDA.Insert(newReportDetail);
                        if (this.bindingList.Where(l => l.LoadingReportID <= 0).Count() <= 0)
                        {
                            this.bindingList.AddNew();
                        }
                    }
                    else
                    {
                        var currentLoadingDetail = this.bindingList.Where(l => l.LoadingReportDetailID == loadingDetailID).FirstOrDefault();
                        this.loadingDetailDA.Update(currentLoadingDetail);
                    }
                    break;
                default:
                    if (loadingDetailID > 0)
                    {
                        var currentLoadingDetail = this.bindingList.Where(l => l.LoadingReportDetailID == loadingDetailID).FirstOrDefault();
                        this.loadingDetailDA.Update(currentLoadingDetail);
                        this.LoadDetails();
                        this.grvLoadingReport.FocusedRowHandle = e.RowHandle;
                    }
                    break;
            }
        }

        private void Rpi_lke_Products_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            int productID = Convert.ToInt32(e.Value);
            var product = AppSetting.ProductList.Where(p => p.ProductID == productID).FirstOrDefault();
            if (product == null) return;
            this.bindingList[this.grvLoadingReport.FocusedRowHandle].ProductID = product.ProductID;
            this.bindingList[this.grvLoadingReport.FocusedRowHandle].ProductName = product.ProductName;
            this.bindingList[this.grvLoadingReport.FocusedRowHandle].ProductNumber = product.ProductNumber;
        }

        private void LkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeCustomers.EditValue == null) return;
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomers.GetColumnValue("CustomerName"));
        }

        private void ValidateConfirmedData()
        {
            if (this.currentLoading != null && Convert.ToBoolean(this.currentLoading.Confirmed))
            {
                // Has confirmed
                this.SetActiveControls(true);
            }
            else
            {
                // Not confirm
                this.SetActiveControls(false);
            }
        }

        private void SetActiveControls(bool isActive)
        {
            this.grvLoadingReport.OptionsBehavior.ReadOnly = isActive;
            this.grvLoadingReport.OptionsBehavior.Editable = !isActive;
            this.btnConfirm.Enabled = !isActive;
            this.btnDelete.Enabled = !isActive;
        }


        private void BtnViewDetail_Click(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            rptLoadingReportDetails rpt = new rptLoadingReportDetails(this.currentLoading.DispatchingOrderID)
            {
                PaperKind = System.Drawing.Printing.PaperKind.A4
            };
            var dataSource = FileProcess.LoadTable("STLoadingReports " + this.currentLoading.DispatchingOrderID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreview();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            rptLoadingReports rpt = new rptLoadingReports(this.currentLoading.DispatchingOrderID);
            DataProcess<STLoadingReports_Result> process = new DataProcess<STLoadingReports_Result>();
            var dataSource = FileProcess.LoadTable("STLoadingReports @DispatchingOrderID=" + this.currentLoading.DispatchingOrderID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreview();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.grvLoadingReport.RowCount <= 0) return;
            this.dataProcess.ExecuteNoQuery("DELETE FROM LoadingReportDetails WHERE LoadingReportID = " + this.currentLoading.LoadingReportID);
            this.dataProcess.ExecuteNoQuery("DELETE FROM LoadingReports WHERE LoadingReportID = " + this.currentLoading.LoadingReportID);
            this.LoadDetails();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            DataProcess<LoadingReports> reportDA = new DataProcess<LoadingReports>();
            var currentLoading = reportDA.Select(r => r.LoadingReportID == this.currentLoading.LoadingReportID).FirstOrDefault();
            currentLoading.Confirmed = true;
            currentLoading.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            currentLoading.ConfirmedTime = DateTime.Now;
            reportDA.Update(currentLoading);
            this.currentLoading.Confirmed = true;
            this.currentLoading.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            this.currentLoading.ConfirmedTime = DateTime.Now;

            this.ValidateConfirmedData();
        }

        private void LkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeCustomers.EditValue = e.Value;
        }

        private void LoadDetails()
        {
            if (this.currentLoading == null) return;
            DataProcess<LoadingReportDetail> process = new DataProcess<LoadingReportDetail>();
            var datasource = process.Select(l => l.LoadingReportID == this.currentLoading.LoadingReportID).ToList();
            this.bindingList = new BindingList<LoadingReportDetail>(datasource);
            this.bindingList.AddNew();
            this.grdLoadingReport.DataSource = this.bindingList;
        }

        private void LoadProductByCustomer()
        {
            if (this.currentLoading == null) return;
            this.rpi_lke_Products.DataSource = FileProcess.LoadTable("STLoadingReportProductID " + this.currentLoading.CustomerID);
            this.rpi_lke_Products.DisplayMember = "ProductNumber";
            this.rpi_lke_Products.ValueMember = "ProductID";
        }

        private void LoadCustomer()
        {
            this.lkeCustomers.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.Properties.ValueMember = "CustomerID";
        }
        private void BindingData()
        {
            if (this.currentLoading == null) return;
            this.txtReportID.Text = Convert.ToString(this.currentLoading.LoadingReportID);
            this.lkeCustomers.EditValue = this.currentLoading.CustomerID;
            this.txtCustomerName.Text = this.currentLoading.CustomerName;
            this.dLoadingDate.EditValue = this.currentLoading.LoadingReportDate;
            this.txtWMSID.Text = Convert.ToString(this.currentLoading.DispatchingOrderID);
            this.txtContNo.Text = this.currentLoading.VehicleNumber;
            this.txtSealNo.Text = this.currentLoading.SealNumber;
            this.txtCreatedBy.Text = this.currentLoading.CreatedBy;
            this.dCreatedTime.EditValue = this.currentLoading.CreatedTime;
            this.dStart.EditValue = this.currentLoading.StartTime;
            this.dStop.EditValue = this.currentLoading.EndTime;
            this.mmRemark.Text = this.currentLoading.SpecialRequirement;
            this.txtConfirmed.Text = this.currentLoading.ConfirmedBy;
            this.dConfirmTime.EditValue = this.currentLoading.ConfirmedTime;
        }

        private void grvLoadingReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            var dlConfirm = MessageBox.Show("Are you sure to delete this record?", "TWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlConfirm.Equals(DialogResult.No)) return;
            int loadingDetailID = Convert.ToInt32(this.grvLoadingReport.GetFocusedRowCellValue("LoadingReportDetailID"));
            DataProcess<LoadingReportDetail> da = new DataProcess<LoadingReportDetail>();
            da.ExecuteNoQuery("Delete LoadingReportDetails Where LoadingReportDetailID=" + loadingDetailID);
            this.LoadDetails();
        }

        private void txtReportID_DoubleClick(object sender, EventArgs e)
        {
            rptLabelLoadingDetails rptTem = new rptLabelLoadingDetails();
            int loadingReportID = Convert.ToInt32(txtReportID.Text);
            var DPNoteDetail = new object();
            DPNoteDetail = FileProcess.LoadTable("STLabelClientByLoadingID @LoadingReportID=" + loadingReportID);
            rptTem.DataSource = DPNoteDetail;
            ReportPrintToolWMS printToolMM = new ReportPrintToolWMS(rptTem);
            printToolMM.AutoShowParametersPanel = false;
            printToolMM.ShowPreview();
        }

        private void btnViewDetail30_Click(object sender, EventArgs e)
        {
            if (this.currentLoading == null) return;
            rptLoadingReportDetails30 rpt = new rptLoadingReportDetails30(this.currentLoading.DispatchingOrderID)
            {
                PaperKind = System.Drawing.Printing.PaperKind.A4
            };
            var dataSource = FileProcess.LoadTable("STLoadingReports " + this.currentLoading.DispatchingOrderID);
            rpt.DataSource = dataSource;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreview();
        }
    }
}
