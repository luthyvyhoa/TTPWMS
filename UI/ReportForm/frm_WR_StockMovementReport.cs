using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Common.Controls;
using Common.Process;
using DA;
using UI.Helper;
using UI.MasterSystemSetup;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_StockMovementReport : frmBaseForm
    {
        private List<STComboProductIDList_Result> _listProducts;
        private DataProcess<STComboProductIDList_Result> _productDA;
        private DataProcess<STStockOnHandByLotListProducts_Result> _remainProductDA = null;
        private rptStockMovement _smReport;
        private int customerID = 0;


        public frm_WR_StockMovementReport(int customerID = 0)
        {
            InitializeComponent();
            this.customerID = customerID;
            this.IsFixHeightScreen = false;
            this._listProducts = new List<STComboProductIDList_Result>();
            this._productDA = new DataProcess<STComboProductIDList_Result>();
            this._remainProductDA = new DataProcess<STStockOnHandByLotListProducts_Result>();
            SetEvents();
        }

        private void frm_WR_StockMovementReport_Load(object sender, EventArgs e)
        {
            Wait.Start(this);
            InitCustomer();

            this.dtToDate.EditValue = DateTime.Now;
            this.dtFromDate.EditValue = DateTime.Now;
            Wait.Close();
        }

        private void SetEvents()
        {
            this.lkeCustomer.EditValueChanged += lkeCustomer_EditValueChanged;
            this.lkeCustomer.Click += LkeCustomer_Click;
            this.btnClose.Click += btnClose_Click;
            this.btnEmail.Click += btnEmail_Click;
            this.btnView.Click += btnView_Click;
            this.btnProductMain.Click += btnProductMain_Click;
            this.btnAverage.Click += btnAverage_Click;
            this.chkWithProduct.CheckedChanged += chkWithProduct_CheckedChanged;
        }

        private void LkeCustomer_Click(object sender, EventArgs e)
        {
            this.lkeCustomer.SelectAll();
        }

        void chkWithProduct_CheckedChanged(object sender, EventArgs e)
        {
            int customerID = (int)this.lkeCustomer.EditValue;
            if (customerID == 0) return;
            if (this.chkWithProduct.Checked == true)
            {
                // view Remain Product
                var dataSource = _remainProductDA.Executing("STStockOnHandByLotListProducts @varCustomerID={0}", customerID);

                grvProduct.Columns["Product_ID"].Visible = true;
                grvProduct.Columns["Product_ID"].Width = 90;
                grvProduct.Columns["Product_ID"].VisibleIndex = 0;

                grvProduct.Columns["ProductName"].Visible = true;
                grvProduct.Columns["ProductName"].Width = 420;
                grvProduct.Columns["ProductName"].VisibleIndex = 1;

                grvProduct.Columns["Product"].Visible = false;
                grvProduct.Columns["Name"].Visible = false;
                this.grdProduct.DataSource = dataSource;
            }
            else
            {
                // view all product
                grvProduct.Columns["Product"].Visible = true;
                grvProduct.Columns["Product"].VisibleIndex = 0;
                grvProduct.Columns["Name"].Visible = true;
                grvProduct.Columns["Name"].VisibleIndex = 1;
                grvProduct.Columns["Product_ID"].Visible = false;
                grvProduct.Columns["ProductName"].Visible = false;
                var dataSource = _productDA.Executing("STComboProductIDList @CustomerID={0}", customerID);
                this.grdProduct.DataSource = dataSource;
            }
            this.grvProduct.ClearSelection();
        }

        private void InitCustomer()
        {
            this.lkeCustomer.Properties.DataSource = AppSetting.CustomerList.Where(c => c.CustomerDiscontinued == false);
            this.lkeCustomer.Properties.ValueMember = "CustomerID";
            this.lkeCustomer.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomer.EditValue = this.customerID;
        }

        #region  Events
        private void lkeCustomer_EditValueChanged(object sender, EventArgs e)
        {
            this.txtCustomerName.Text = Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerName"));
            this._listProducts = this._productDA.Executing("STComboProductIDList @CustomerID = {0}", Convert.ToInt32(this.lkeCustomer.EditValue)).ToList();
            this.grdProduct.DataSource = this._listProducts;
            this.grvProduct.ClearSelection();
            this.lkeCustomer.SelectAll();
            if (Convert.ToString(this.lkeCustomer.GetColumnValue("CustomerType")).ToUpper().Equals(CustomerTypeEnum.RANDOM_WEIGHT.ToUpper()))
            {
                this.chkWeightOnly.Checked = true;
            }
            else
            {
                this.chkWeightOnly.Checked = false;
            }
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault();
            if (customer != null)
            {
                frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                frmCustomer.CurrentCustomers = customer;
                frmCustomer.WindowState = FormWindowState.Normal;
                frmCustomer.BringToFront();
                frmCustomer.Show();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string condition = "";
            bool isSelected = true;

            if (this.grvProduct.SelectedRowsCount <= 0)
            {
                isSelected = false;
            }
            else
            {
                //Print report of selected products
                isSelected = true;
                condition = GetSelectedProductID();
            }

            if (isSelected)
            {
                if (this.chkWeightOnly.Checked)
                {
                    var data = FileProcess.LoadTable(" STStockMovementReportSelectedProducts @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "' , @varCondition='" + condition + "'");
                    OpenWeightInnerReport(data);
                }
                else
                {
                    var data = FileProcess.LoadTable(" STStockMovementReportSelectedProducts @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "' ,  @varCondition='" + condition + "' , @ByWeight=" + 0);
                    OpenStockMovementReport(data);
                }
            }
            else
            {
                DataProcess<STStockMovementReport1Customer_Result> stockMovementDA = new DataProcess<STStockMovementReport1Customer_Result>();

                if (this.chkWeightOnly.Checked)
                {
                    var data = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "', @ByWeight=" + 1);
                    OpenWeightInnerReport(data);
                }
                else
                {
                    var data = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "', @ByWeight=" + 0);
                    OpenStockMovementReport(data);
                }
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault().Email;

            if (String.IsNullOrEmpty(email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.SmartTextWrap = true;
                DialogResult result = XtraMessageBox.Show("Send report to the address : " + email + " ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this._smReport == null)
                    {
                        this.UpdateReportData();
                    }

                    SendMail(email, this._smReport, "SCS VN Report - Stock On Hand - " + this.txtCustomerName.Text);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnProductMain_Click(object sender, EventArgs e)
        {
            if (this.chkWeightOnly.Checked)
            {
                XtraMessageBox.Show("Not support this report yet!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DataProcess<STStockMovementReport1CustomerProductMain_Result> productMainDA = new DataProcess<STStockMovementReport1CustomerProductMain_Result>();
                    List<STStockMovementReport1CustomerProductMain_Result> listProductMain = productMainDA.Executing("STStockMovementReport1CustomerProductMain @varFromDate = {0}, @varTodate = {1}, @varCustomerID = {2}, @ByWeight = {3}", this.dtFromDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss"), this.dtToDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss"), Convert.ToInt32(this.lkeCustomer.EditValue), 0).ToList();
                    OpenStockMovementReport(null, listProductMain);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomer.EditValue);

            DataProcess<ST_WMS_LoadStockOnHandAverageByCustomer_Result> averageDA = new DataProcess<ST_WMS_LoadStockOnHandAverageByCustomer_Result>();
            List<ST_WMS_LoadStockOnHandAverageByCustomer_Result> listReportData = averageDA.Executing("ST_WMS_LoadStockOnHandAverageByCustomer @CustomerID = {0}, @varFromDate = {1}, @varTodate = {2}", Convert.ToInt32(this.lkeCustomer.EditValue), this.dtFromDate.DateTime.ToString("yyyy-MM-dd"), this.dtToDate.DateTime.ToString("yyyy-MM-dd")).ToList();

            if (listReportData.Count > 0)
            {
                rptStockOnHandAverageByCustomer report = new rptStockOnHandAverageByCustomer(this.dtFromDate.DateTime, this.dtToDate.DateTime);
                report.DataSource = listReportData;
                CreateAverageField(report);
                ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
                tool.ShowPreview();
            }
            else
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        private string GetSelectedProductID()
        {
            string listProductID = "(1, ";
            int[] rowHandles = this.grvProduct.GetSelectedRows();

            for (int i = 0; i < rowHandles.Count(); i++)
            {
                if (i == rowHandles.Count() - 1)
                {
                    listProductID = listProductID + this.grvProduct.GetRowCellValue(rowHandles[i], "ProductID") + ")";
                }
                else
                {
                    listProductID = listProductID + this.grvProduct.GetRowCellValue(rowHandles[i], "ProductID") + ", ";
                }
            }

            return listProductID;
        }

        private void OpenStockMovementReport(DataTable dataSource = null, List<STStockMovementReport1CustomerProductMain_Result> productMainSource = null)
        {
            if (this.lkeCustomer.EditValue == null)
            {
                return;
            }

            int customerID = Convert.ToInt32(this.lkeCustomer.EditValue);
            var customerType = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID)?.CustomerType;
            if (dataSource == null)
            {

                dataSource = new DataTable();
            }

            if (dataSource.Rows.Count < 1 && productMainSource == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraReport report;
            if (string.Equals(customerType, CustomerTypeEnum.RANDOM_WEIGHT))
            {
                report = new rptStockMovementKGR();
                ((rptStockMovementKGR)report).xrFromDate.Text = "From date : " + Convert.ToDateTime(this.dtFromDate.EditValue).ToString("dd/MM/yyyy");
                ((rptStockMovementKGR)report).xrToDate.Text = "To date : " + Convert.ToDateTime(this.dtToDate.EditValue).ToString("dd/MM/yyyy");
            }
            else
            {
                report = new rptStockMovement();
                ((rptStockMovement)report).xrFromDate.Text = "From date : " + Convert.ToDateTime(this.dtFromDate.EditValue).ToString("dd/MM/yyyy");
                ((rptStockMovement)report).xrToDate.Text = "To date : " + Convert.ToDateTime(this.dtToDate.EditValue).ToString("dd/MM/yyyy");
            }

            if (dataSource.Rows.Count >= 1)
            {
                report.DataSource = dataSource;
            }
            else
            {
                report.DataSource = productMainSource;
            }

            ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
            tool.ShowPreview();
        }

        private void OpenWeightInnerReport(DataTable dataSource = null)
        {
            if (this.lkeCustomer.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomer.EditValue);

            if (dataSource.Rows.Count == 0 || dataSource == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            rptStockMovementWeightInners report = new rptStockMovementWeightInners();
            report.DataSource = dataSource;
            CreateCalculateField(report);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
            tool.ShowPreview();
        }

        private void UpdateReportData()
        {
            this._smReport = new rptStockMovement();
            string condition = "";
            bool isSelected = true;

            if (this.grvProduct.SelectedRowsCount <= 0)
            {
                isSelected = false;
            }
            else
            {
                isSelected = true;
                condition = GetSelectedProductID();
            }

            if (isSelected)
            {
                var data = FileProcess.LoadTable(" STStockMovementReportByProducts @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "' ,  @varCondition='" + condition + "' , @ByWeight=" + 0);
                this._smReport.DataSource = data;
            }
            else
            {
                var data = FileProcess.LoadTable("STStockMovementReport1Customer @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd hh:mm:ss") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "', @ByWeight=" + 0);
                //DataProcess<STStockMovementReport1Customer_Result> stockMovementDA = new DataProcess<STStockMovementReport1Customer_Result>();
                //var data = stockMovementDA.Executing("STStockMovementReport1Customer @varFromDate = {0} @varTodate = {1} @varCustomerID = {2} @byWeight = {3}", this.dtFromDate.DateTime, this.dtToDate.DateTime, Convert.ToInt32(this.lkeCustomer.EditValue), 0).ToList();
                this._smReport.DataSource = data;
            }
        }

        private void CreateCalculateField(rptStockMovementWeightInners report)
        {
            CalculatedField sumBeginC = new CalculatedField();

            sumBeginC.DataSource = report.DataSource;
            sumBeginC.DataMember = report.DataMember;
            sumBeginC.Name = "sumBeginC";
            sumBeginC.DisplayName = "sumBeginC";
            sumBeginC.Expression = "Sum([BeginC])";

            report.CalculatedFields.Add(sumBeginC);

            CalculatedField sumInC = new CalculatedField();

            sumInC.DataSource = report.DataSource;
            sumInC.DataMember = report.DataMember;
            sumInC.Name = "sumInC";
            sumInC.DisplayName = "sumInC";
            sumInC.Expression = "Sum([InC])";

            report.CalculatedFields.Add(sumInC);

            CalculatedField sumOutC = new CalculatedField();

            sumOutC.DataSource = report.DataSource;
            sumOutC.DataMember = report.DataMember;
            sumOutC.Name = "sumOutC";
            sumOutC.DisplayName = "sumOutC";
            sumOutC.Expression = "Sum([OutC])";

            report.CalculatedFields.Add(sumOutC);

            CalculatedField sumCloseC = new CalculatedField();

            sumCloseC.DataSource = report.DataSource;
            sumCloseC.DataMember = report.DataMember;
            sumCloseC.Name = "sumClosingC";
            sumCloseC.DisplayName = "sumClosingC";
            sumCloseC.Expression = "Sum([CloseC])";

            report.CalculatedFields.Add(sumCloseC);

            CalculatedField sumBeginUnify = new CalculatedField();

            sumBeginUnify.DataSource = report.DataSource;
            sumBeginUnify.DataMember = report.DataMember;
            sumBeginUnify.Name = "sumBeginUnify";
            sumBeginUnify.DisplayName = "sumBeginUnify";
            sumBeginUnify.Expression = "Sum([Begin_Unify])";

            report.CalculatedFields.Add(sumBeginUnify);

            CalculatedField sumInUnify = new CalculatedField();

            sumInUnify.DataSource = report.DataSource;
            sumInUnify.DataMember = report.DataMember;
            sumInUnify.Name = "sumInUnify";
            sumInUnify.DisplayName = "sumInUnify";
            sumInUnify.Expression = "Sum([In_Unify])";

            report.CalculatedFields.Add(sumInUnify);

            CalculatedField sumOutUnify = new CalculatedField();

            sumOutUnify.DataSource = report.DataSource;
            sumOutUnify.DataMember = report.DataMember;
            sumOutUnify.Name = "sumOutUnify";
            sumOutUnify.DisplayName = "sumOutUnify";
            sumOutUnify.Expression = "Sum([Out_Unify])";

            report.CalculatedFields.Add(sumOutUnify);

            CalculatedField sumClosingUnifyKgs = new CalculatedField();

            sumClosingUnifyKgs.DataSource = report.DataSource;
            sumClosingUnifyKgs.DataMember = report.DataMember;
            sumClosingUnifyKgs.Name = "sumClosingUnifyKgs";
            sumClosingUnifyKgs.DisplayName = "sumClosingUnifyKgs";
            sumClosingUnifyKgs.Expression = "Sum(Iif([Packages]== 'UN', 0, [Closing_Unify]))";

            report.CalculatedFields.Add(sumClosingUnifyKgs);

            CalculatedField sumClosingUnifyUn = new CalculatedField();

            sumClosingUnifyUn.DataSource = report.DataSource;
            sumClosingUnifyUn.DataMember = report.DataMember;
            sumClosingUnifyUn.Name = "sumClosingUnifyUn";
            sumClosingUnifyUn.DisplayName = "sumClosingUnifyUn";
            sumClosingUnifyUn.Expression = "Sum(Iif([Packages]== 'UN', [Closing_Unify], 0))";

            report.CalculatedFields.Add(sumClosingUnifyUn);
        }

        private void CreateAverageField(rptStockOnHandAverageByCustomer report)
        {
            CalculatedField avgPallets = new CalculatedField();

            avgPallets.DataSource = report.DataSource;
            avgPallets.DataMember = report.DataMember;
            avgPallets.Name = "avgPallets";
            avgPallets.DisplayName = "avgPallets";
            avgPallets.Expression = "Avg([Pallets])";

            report.CalculatedFields.Add(avgPallets);

            CalculatedField avgLow = new CalculatedField();

            avgLow.DataSource = report.DataSource;
            avgLow.DataMember = report.DataMember;
            avgLow.Name = "avgLow";
            avgLow.DisplayName = "avgLow";
            avgLow.Expression = "Avg([PalletLow])";

            report.CalculatedFields.Add(avgLow);

            CalculatedField avgVLow = new CalculatedField();

            avgVLow.DataSource = report.DataSource;
            avgVLow.DataMember = report.DataMember;
            avgVLow.Name = "avgVLow";
            avgVLow.DisplayName = "avgVLow";
            avgVLow.Expression = "Avg([PalletVeryLow])";

            report.CalculatedFields.Add(avgVLow);

            CalculatedField avgHigh = new CalculatedField();

            avgHigh.DataSource = report.DataSource;
            avgHigh.DataMember = report.DataMember;
            avgHigh.Name = "avgHigh";
            avgHigh.DisplayName = "avgHigh";
            avgHigh.Expression = "Avg([PalletHight])";

            report.CalculatedFields.Add(avgHigh);

            CalculatedField avgVHigh = new CalculatedField();

            avgVHigh.DataSource = report.DataSource;
            avgVHigh.DataMember = report.DataMember;
            avgVHigh.Name = "avgVHigh";
            avgVHigh.DisplayName = "avgVHigh";
            avgVHigh.Expression = "Avg([PalletVeryHigh])";

            report.CalculatedFields.Add(avgVHigh);

            CalculatedField avgWeight = new CalculatedField();

            avgWeight.DataSource = report.DataSource;
            avgWeight.DataMember = report.DataMember;
            avgWeight.Name = "avgWeight";
            avgWeight.DisplayName = "avgWeight";
            avgWeight.Expression = "Avg([Weight])";

            report.CalculatedFields.Add(avgWeight);

            CalculatedField standard = new CalculatedField();

            standard.DataSource = report.DataSource;
            standard.DataMember = report.DataMember;
            standard.Name = "standard";
            standard.DisplayName = "standard";
            standard.Expression = "[PalletLow]+[PalletVeryLow]*0.75+[PalletHigh]*1.25+[PalletVeryHigh]*1.75";

            report.CalculatedFields.Add(standard);

            CalculatedField Weight_Plt = new CalculatedField();

            Weight_Plt.DataSource = report.DataSource;
            Weight_Plt.DataMember = report.DataMember;
            Weight_Plt.Name = "Weight_Plt";
            Weight_Plt.DisplayName = "Weight_Plt";
            Weight_Plt.Expression = "[Weight]/([PalletLow]+[PalletVeryLow]*0.75+[PalletHigh]*1.25+[PalletVeryHigh]*1.75)";

            report.CalculatedFields.Add(Weight_Plt);

            CalculatedField avgStandard = new CalculatedField();

            avgStandard.DataSource = report.DataSource;
            avgStandard.DataMember = report.DataMember;
            avgStandard.Name = "avgStandard";
            avgStandard.DisplayName = "avgStandard";
            avgStandard.Expression = "Avg([standard])";

            report.CalculatedFields.Add(avgStandard);

            CalculatedField avgWeight_Plt = new CalculatedField();

            avgWeight_Plt.DataSource = report.DataSource;
            avgWeight_Plt.DataMember = report.DataMember;
            avgWeight_Plt.Name = "avgWeight_Plt";
            avgWeight_Plt.DisplayName = "avgWeight_Plt";
            avgWeight_Plt.Expression = "Avg([Weight_Plt])";

            report.CalculatedFields.Add(avgWeight_Plt);
        }

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        private void SendMail(string toEmail, rptStockMovement report, string subject, int formatType = 0)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {
                    if (formatType == 0)
                    {
                        report.ExportToRtf(mem);
                        fileExtension = "rtf";
                    }
                    else
                    {
                        report.ExportToXlsx(mem);
                        fileExtension = "xlsx";
                    }

                    mem.Seek(0, SeekOrigin.Begin);
                    Attachment att = new Attachment(mem, "Stock Report From SCS VN." + fileExtension, "application/" + fileExtension);
                    Common.Process.DataTransfer.SendMail(toEmail, subject, boby, att);
                }

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lkeCustomer.EditValue)).FirstOrDefault();
            if (customer != null)
            {
                frm_MSS_Customers frmCustomer = MasterSystemSetup.frm_MSS_Customers.Instance;
                frmCustomer.CurrentCustomers = customer;
                frmCustomer.WindowState = FormWindowState.Normal;
                frmCustomer.BringToFront();
                frmCustomer.Show();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnViewKGR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnViewKGR_Click(object sender, EventArgs e)
        {
            var data = FileProcess.LoadTable("WebStockMovementReport1CustomerWeightInner @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd")
                + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "'");
            OpenStockMovementReport(data);
        }

        private void checkShowAllInOutProducts_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowAllInOutProducts.Checked)
            {
                this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockMovementInOutAllProducts @FromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @Todate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID=" + Convert.ToInt32(this.lkeCustomer.EditValue));
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportSettings.DefaultExportType = ExportType.DataAware;
            var options = new XlsxExportOptionsEx();
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            sfd.Filter = "Excel 97-2003 (*.xls)|*.xls|Excel 07-2010 (*.xlsx)|*.xlsx";

            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.grcInOutAllProducts.ExportToXlsx(sfd.FileName, options);
                try
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void rpi_hle_OrderID_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvInOutAllProducts.GetFocusedRowCellValue("OrderNumber"));
            var orderType = orderNumber.Split('-');
            int orderID = Convert.ToInt32(orderType[1]);
            switch (orderType[0])
            {
                case "RO":
                    frm_WM_ReceivingOrders receivingOrder = frm_WM_ReceivingOrders.Instance;
                    receivingOrder.ReceivingOrderIDFind = orderID;
                    receivingOrder.Show();
                    receivingOrder.WindowState = FormWindowState.Maximized;
                    receivingOrder.BringToFront();
                    break;
                case "DO":
                    // Display disptching order
                    frm_WM_DispatchingOrders dispatchingOrder = frm_WM_DispatchingOrders.GetInstance(orderID);
                    if (dispatchingOrder.Visible)
                    {
                        dispatchingOrder.ReloadData();
                    }
                    dispatchingOrder.Show();
                    dispatchingOrder.WindowState = FormWindowState.Maximized;
                    dispatchingOrder.BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void chkMainCustomer_CheckedChanged(object sender, EventArgs e)
        {
            //int customerID = (int)this.lkeCustomer.EditValue;
            //if (customerID == 0) return;
            if (this.chkMainCustomer.Checked)
            {
                this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockMovementInOutAllProducts @FromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @Todate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @CustomerID=" + Convert.ToInt32(this.lkeCustomer.EditValue) + " , @CheckMain = 1");
                grvInOutAllProducts.Columns["CustomerID"].Visible = true;
                grvInOutAllProducts.Columns["CustomerID"].Width = 80;
                grvInOutAllProducts.Columns["CustomerID"].VisibleIndex = 0;
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;
                grvInOutAllProducts.Columns["CustomerID"].Visible = false;
            }
        }

        private void btnLotNo_Click(object sender, EventArgs e)
        {
            string condition = "";
            bool isSelected = true;

            if (this.grvProduct.SelectedRowsCount <= 0)
            {
                isSelected = false;
            }
            else
            {
                //Print report of selected products
                isSelected = true;
                condition = GetSelectedProductID();
            }

            if (isSelected)
            {
                if (this.chkWeightOnly.Checked)
                {
                    var data = FileProcess.LoadTable(" STStockMovementReportSelectedProductsLotNo @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "' , @varCondition='" + condition + "'");
                    OpenWeightInnerReportLotNo(data);
                }
                else
                {
                    var data = FileProcess.LoadTable(" STStockMovementReportSelectedProductsLotNo @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                                + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "' ,  @varCondition='" + condition + "' , @ByWeight=" + 0);
                    OpenStockMovementReportLotNo(data);
                }
            }
            else
            {
                if (this.chkWeightOnly.Checked)
                {
                    var data = FileProcess.LoadTable("STStockMovementReport1CustomerLotNo @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "', @ByWeight=" + 1);
                    OpenWeightInnerReportLotNo(data);
                }
                else
                {
                    var data = FileProcess.LoadTable("STStockMovementReport1CustomerLotNo @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd") + "', @varTodate='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "', @varCustomerID='" + Convert.ToInt32(this.lkeCustomer.EditValue) + "', @ByWeight=" + 0);
                    OpenStockMovementReportLotNo(data);
                }
            }
        }

        private void OpenWeightInnerReportLotNo(DataTable dataSource = null)
        {
            if (this.lkeCustomer.EditValue == null) return;
            int customerID = Convert.ToInt32(this.lkeCustomer.EditValue);

            if (dataSource.Rows.Count == 0 || dataSource == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            rptStockMovementWeightInnersLotNo report = new rptStockMovementWeightInnersLotNo();
            report.DataSource = dataSource;
            CreateCalculateFieldLotNo(report);
            ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
            tool.ShowPreview();
        }

        private void OpenStockMovementReportLotNo(DataTable dataSource = null, List<STStockMovementReport1CustomerProductMain_Result> productMainSource = null)
        {
            if (this.lkeCustomer.EditValue == null)
            {
                return;
            }

            int customerID = Convert.ToInt32(this.lkeCustomer.EditValue);
            var customerType = AppSetting.CustomerList.FirstOrDefault(c => c.CustomerID == customerID)?.CustomerType;
            if (dataSource == null)
            {

                dataSource = new DataTable();
            }

            if (dataSource.Rows.Count < 1 && productMainSource == null)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XtraReport report;
            if (string.Equals(customerType, CustomerTypeEnum.RANDOM_WEIGHT))
            {
                report = new rptStockMovementKGRLotNo();
                ((rptStockMovementKGRLotNo)report).xrFromDate.Text = "From date : " + Convert.ToDateTime(this.dtFromDate.EditValue).ToString("dd/MM/yyyy");
                ((rptStockMovementKGRLotNo)report).xrToDate.Text = "To date : " + Convert.ToDateTime(this.dtToDate.EditValue).ToString("dd/MM/yyyy");
            }
            else
            {
                report = new rptStockMovementLotNo();
                ((rptStockMovementLotNo)report).xrFromDate.Text = "From date : " + Convert.ToDateTime(this.dtFromDate.EditValue).ToString("dd/MM/yyyy");
                ((rptStockMovementLotNo)report).xrToDate.Text = "To date : " + Convert.ToDateTime(this.dtToDate.EditValue).ToString("dd/MM/yyyy");
            }

            if (dataSource.Rows.Count >= 1)
            {
                report.DataSource = dataSource;
            }
            else
            {
                report.DataSource = productMainSource;
            }
            ReportPrintToolWMS tool = new ReportPrintToolWMS(report, customerID);
            tool.ShowPreview();
        }

        private void CreateCalculateFieldLotNo(XtraReport report)
        {
            CalculatedField sumBeginC = new CalculatedField();

            sumBeginC.DataSource = report.DataSource;
            sumBeginC.DataMember = report.DataMember;
            sumBeginC.Name = "sumBeginC";
            sumBeginC.DisplayName = "sumBeginC";
            sumBeginC.Expression = "Sum([BeginC])";

            report.CalculatedFields.Add(sumBeginC);

            CalculatedField sumInC = new CalculatedField();

            sumInC.DataSource = report.DataSource;
            sumInC.DataMember = report.DataMember;
            sumInC.Name = "sumInC";
            sumInC.DisplayName = "sumInC";
            sumInC.Expression = "Sum([InC])";

            report.CalculatedFields.Add(sumInC);

            CalculatedField sumOutC = new CalculatedField();

            sumOutC.DataSource = report.DataSource;
            sumOutC.DataMember = report.DataMember;
            sumOutC.Name = "sumOutC";
            sumOutC.DisplayName = "sumOutC";
            sumOutC.Expression = "Sum([OutC])";

            report.CalculatedFields.Add(sumOutC);

            CalculatedField sumCloseC = new CalculatedField();

            sumCloseC.DataSource = report.DataSource;
            sumCloseC.DataMember = report.DataMember;
            sumCloseC.Name = "sumClosingC";
            sumCloseC.DisplayName = "sumClosingC";
            sumCloseC.Expression = "Sum([CloseC])";

            report.CalculatedFields.Add(sumCloseC);

            CalculatedField sumBeginUnify = new CalculatedField();

            sumBeginUnify.DataSource = report.DataSource;
            sumBeginUnify.DataMember = report.DataMember;
            sumBeginUnify.Name = "sumBeginUnify";
            sumBeginUnify.DisplayName = "sumBeginUnify";
            sumBeginUnify.Expression = "Sum([Begin_Unify])";

            report.CalculatedFields.Add(sumBeginUnify);

            CalculatedField sumInUnify = new CalculatedField();

            sumInUnify.DataSource = report.DataSource;
            sumInUnify.DataMember = report.DataMember;
            sumInUnify.Name = "sumInUnify";
            sumInUnify.DisplayName = "sumInUnify";
            sumInUnify.Expression = "Sum([In_Unify])";

            report.CalculatedFields.Add(sumInUnify);

            CalculatedField sumOutUnify = new CalculatedField();

            sumOutUnify.DataSource = report.DataSource;
            sumOutUnify.DataMember = report.DataMember;
            sumOutUnify.Name = "sumOutUnify";
            sumOutUnify.DisplayName = "sumOutUnify";
            sumOutUnify.Expression = "Sum([Out_Unify])";

            report.CalculatedFields.Add(sumOutUnify);

            CalculatedField sumClosingUnifyKgs = new CalculatedField();

            sumClosingUnifyKgs.DataSource = report.DataSource;
            sumClosingUnifyKgs.DataMember = report.DataMember;
            sumClosingUnifyKgs.Name = "sumClosingUnifyKgs";
            sumClosingUnifyKgs.DisplayName = "sumClosingUnifyKgs";
            sumClosingUnifyKgs.Expression = "Sum(Iif([Packages]== 'UN', 0, [Closing_Unify]))";

            report.CalculatedFields.Add(sumClosingUnifyKgs);

            CalculatedField sumClosingUnifyUn = new CalculatedField();

            sumClosingUnifyUn.DataSource = report.DataSource;
            sumClosingUnifyUn.DataMember = report.DataMember;
            sumClosingUnifyUn.Name = "sumClosingUnifyUn";
            sumClosingUnifyUn.DisplayName = "sumClosingUnifyUn";
            sumClosingUnifyUn.Expression = "Sum(Iif([Packages]== 'UN', [Closing_Unify], 0))";

            report.CalculatedFields.Add(sumClosingUnifyUn);
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STStockMovementReport1CustomerDetails  @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                + "',@varTodate ='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "',@varCustomerID =" + this.lkeCustomer.EditValue);
            if (dataSource == null || dataSource.Rows.Count < 0)
            {
                MessageBox.Show("No data export", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "StockMovementDetailReport_" + DateTime.Now.ToString("dd_MM_yy HH mm") + ".xlsx";
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = dataSource;
            grvReport.PopulateColumns();
            grvReport.ExportToXlsx(fileName);
            System.Diagnostics.Process.Start(fileName);
        }

        private void btnViewDetailGroupRO_Click(object sender, EventArgs e)
        {
            if (this.lkeCustomer.EditValue == null) return;
            var dataSource = FileProcess.LoadTable("STStockMovementReport1CustomerGroupByRO  @varFromDate='" + this.dtFromDate.DateTime.ToString("yyyy-MM-dd")
                + "',@varTodate ='" + this.dtToDate.DateTime.ToString("yyyy-MM-dd") + "',@varCustomerID =" + this.lkeCustomer.EditValue);
            if (dataSource == null || dataSource.Rows.Count < 0)
            {
                MessageBox.Show("No data export", "TWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "StockMovementDetailReportViewByRO_" + DateTime.Now.ToString("dd_MM_yy HH mm") + ".xlsx";
            DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
            grdReport.MainView = grvReport;
            grdReport.ForceInitialize();
            grdReport.BindingContext = new BindingContext();
            grdReport.DataSource = dataSource;
            grvReport.PopulateColumns();
            grvReport.ExportToXlsx(fileName);
            System.Diagnostics.Process.Start(fileName);
        }
    }
}
