using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common.Controls;
using UI.Helper;
using DA;
using UI.MasterSystemSetup;
using UI.ReportFile;
using DevExpress.XtraReports.UI;
using DA.Stock;
using System.IO;
using UI.WarehouseManagement;

namespace UI.ReportForm
{
    public partial class frm_WR_StockByLocationReport : frmBaseForm
    {
        private List<STStockByLocationReport> _listStockByLocationReport;

        public frm_WR_StockByLocationReport()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._listStockByLocationReport = new List<STStockByLocationReport>();
            this.dLocationDate.DateTime = DateTime.Now;
        }
        private bool UpdateSQL()
        {
            this._listStockByLocationReport.Clear();
            StringBuilder strCondition = new StringBuilder();
            if (grvProducts.SelectedRowsCount == 0)
            {
                if (lkeCustomerNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Please select customer !", "TPWMS");
                    return false;
                }

                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                strCondition.Append("(SELECT ProductID FROM Products WHERE CustomerID=" + selectedCustomerID + ")");
            }
            else
            {
                strCondition.Append("1");
                int[] selectedRows = grvProducts.GetSelectedRows();
                foreach (int selectedRow in selectedRows)
                {
                    STStockOnHandByLotListProducts_Result row = (STStockOnHandByLotListProducts_Result)grvProducts.GetRow(selectedRow);
                    strCondition.Append(",");
                    strCondition.Append(row.ProductID);
                }
                strCondition.Insert(0, "(");
                strCondition.Append(")");
            }
            DataProcess<STStockByLocationReport> stStockByLocationReportDA = new DataProcess<STStockByLocationReport>();
            this._listStockByLocationReport = stStockByLocationReportDA.Executing("STStockByLocationReport @varCondition={0}", strCondition.ToString()).ToList();
            //this._listStockByLocationReport= 
            return true;
        }

        private void UpdateSQL_W()
        {
            this._listStockByLocationReport.Clear();
            StringBuilder strCondition = new StringBuilder();
            if (grvProducts.SelectedRowsCount == 0)
            {
                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                strCondition.Append("(SELECT ProductID FROM Products WHERE CustomerID=" + selectedCustomerID + ")");
            }
            else
            {
                strCondition.Append("1");
                int[] selectedRows = grvProducts.GetSelectedRows();
                foreach (int selectedRow in selectedRows)
                {
                    STStockOnHandByLotListProducts_Result row = (STStockOnHandByLotListProducts_Result)grvProducts.GetRow(selectedRow);
                    strCondition.Append(",");
                    strCondition.Append(row.ProductID);
                }
                strCondition.Insert(0, "(");
                strCondition.Append(")");
            }
            DataProcess<STStockByLocationReport> stStockByLocationReportDA = new DataProcess<STStockByLocationReport>();
            this._listStockByLocationReport = stStockByLocationReportDA.Executing("STStockByLocationReport @varCondition={0},@Flag=0", strCondition.ToString()).ToList();
        }

        private void frm_WR_StockByLocationReport_Load(object sender, EventArgs e)
        {
            lkeCustomerNumber.Properties.DataSource = AppSetting.CustomerList;
            int lkeCustomerNumberRows = ((IList<Customers>)lkeCustomerNumber.Properties.DataSource).Count;
            if (lkeCustomerNumberRows > 20)
                lkeCustomerNumber.Properties.DropDownRows = 20;
            else
                lkeCustomerNumber.Properties.DropDownRows = lkeCustomerNumberRows;
            lkeCustomerNumber.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerNumber.Properties.ValueMember = "CustomerID";

            //điều chỉnh giá trị mặc định cho txtDate trước để ko dính sự kiện EditValueChanged
            dLocationDate.EditValue = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        }

        #region Events


        private void frm_WR_StockByLocationReport_Shown(object sender, EventArgs e)
        {
            lkeCustomerNumber.Focus();
            lkeCustomerNumber.ShowPopup();
        }

        private void btnGoToCustomer_Click(object sender, EventArgs e)
        {

        }

        private void rgChooseOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgChooseOption.SelectedIndex == 1)
                lciCustomerRef.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                lciCustomerRef.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void btnDeepThree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            if (selectedCustomerID <= 0)
            {
                MessageBox.Show("Please enter Customer !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lkeCustomerNumber.Focus();
                lkeCustomerNumber.ShowPopup();
            }
            else
            {
                DataProcess<STStockByLocationDeep3Report_Result> stStockByLocationDeep3ReportDA = new DataProcess<STStockByLocationDeep3Report_Result>();
                List<STStockByLocationDeep3Report_Result> stStockByLocationDeep3ReportList = stStockByLocationDeep3ReportDA.Executing("STStockByLocationDeep3Report @CustomerID={0}", selectedCustomerID).ToList();

                if (stStockByLocationDeep3ReportList.Count <= 0)
                {
                    XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rptStockByLocationDeep3 rpt = new rptStockByLocationDeep3();
                    rpt.DataSource = stStockByLocationDeep3ReportList;
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                    printTool.ShowPreviewDialog();
                }
            }
        }

        private void btnLowHigh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            var stStockByLocationDeep3ReportList = FileProcess.LoadTable("STStockByLocationReportLowHigh @CustomerID = " + selectedCustomerID);

            if (stStockByLocationDeep3ReportList.Rows.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rptStockByLocationLowHigh rpt = new rptStockByLocationLowHigh();
                rpt.DataSource = stStockByLocationDeep3ReportList;
                CreateLowHighField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
        }

        private void btnByLocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Call UpdateSQL
            var isContinue = UpdateSQL();

            if (!isContinue)
            {
                return;
            }

            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.GetColumnValue("CustomerID"));
            string selectedCustomerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
            if (selectedCustomerType.Equals("Pcs"))
            {
                rptStockByLocationLocationDetails_pcs rpt = new rptStockByLocationLocationDetails_pcs();
                rpt.DataSource = this._listStockByLocationReport.OrderByDescending(p => p.ProductName);
                CreateLocationDetailsPcsField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
                printTool.ShowPreviewDialog();
            }
            else
            {
                rptStockByLocationLocation rpt = new rptStockByLocationLocation();
                this._listStockByLocationReport.OrderBy(p => p.LocationNumber);
                rpt.DataSource = _listStockByLocationReport;
                CreateLocationLocationField(rpt);
                var abc = _listStockByLocationReport.Select(s => new { s.LocationNumber }).Distinct().ToList();

                rpt.xrDcount.Text = abc.Count.ToString();
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
                printTool.ShowPreviewDialog();
            }
        }

        private void btnReplenishment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            if (selectedCustomerID > 0)
            {
                //DataProcess<STStockByLocationReplenishmentReport_Result> stStockByLocationReplenishmentReportDA = new DataProcess<STStockByLocationReplenishmentReport_Result>();
                //List<STStockByLocationReplenishmentReport_Result> stStockByLocationReplenishmentReportList = stStockByLocationReplenishmentReportDA.Executing("STStockByLocationReplenishmentReport @CustomerID={0}", selectedCustomerID).ToList();
                DataTable dataSource = FileProcess.LoadTable("STStockByLocationReplenishmentReport @CustomerID = " + selectedCustomerID);
                if (dataSource != null || dataSource.Rows.Count != 0)
                {
                    rptStockByLocationReplenishment rpt = new rptStockByLocationReplenishment();
                    rpt.DataSource = dataSource;
                    CreateReplenishment(rpt);
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    MessageBox.Show("Store Procedure 'STStockByLocationReplenishmentReport' is failed when executing\nPlease, check again !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("CustomerID can't not found\nPlease, Choosing Customer is first", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnLocationDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var isContinue = UpdateSQL();
            if (!isContinue)
            {
                return;
            }

            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.GetColumnValue("CustomerID"));
            string selectedCustomerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
            if (selectedCustomerType.Equals("Pcs"))
            {
                rptStockByLocationLocation_pcs rpt = new rptStockByLocationLocation_pcs();
                rpt.DataSource = this._listStockByLocationReport;
                CreateLocationLocationPcsField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
                printTool.ShowPreviewDialog();
            }
            else
            {
                if (rgChooseOption.SelectedIndex == 0)
                {
                    rptStockByLocationLocationDetails rpt = new rptStockByLocationLocationDetails();
                    rpt.lblafterpick.Visible = true;
                    rpt.lblTotalDetails.Visible = true;
                    rpt.lblQtyLocationDetailsReport.Visible = true;
                    rpt.DataSource = this._listStockByLocationReport;
                    CreateLocationDetailsField(rpt);
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    //DoCmd.OpenReport "rptStockByLocationLocationDetails", acViewPreview, , "[CustomerRef] LIKE '" & Me.textCustomerRef & "'"
                    rptStockByLocationLocationDetails rpt = new rptStockByLocationLocationDetails();
                    CreateLocationDetailsField(rpt);
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt, customerID);
                    printTool.ShowPreviewDialog();
                }
            }
        }

        private void btnByUnitsWeight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateSQL_W();

            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int customerID = Convert.ToInt32(this.lkeCustomerNumber.GetColumnValue("CustomerID"));
            //Call UpdateSQL_W
            rptStockByLocationLocationDetailWeightInners rpt1 = new rptStockByLocationLocationDetailWeightInners();
            rpt1.DataSource = this._listStockByLocationReport;
            CreateLocationDetailWeightInners(rpt1);
            ReportPrintToolWMS printTool1 = new ReportPrintToolWMS(rpt1, customerID);
            printTool1.ShowPreview();

            rptStockByLocationLocationDetailWeightInners_ByProduct rpt2 = new rptStockByLocationLocationDetailWeightInners_ByProduct();
            rpt2.DataSource = this._listStockByLocationReport;
            CreateLocationDetailWeightInners(rpt2);
            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2, customerID);
            printTool2.ShowPreview();
        }

        private void btnDetailsHideQty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var isContinue = UpdateSQL();
            if (!isContinue)
            {
                return;
            }
            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedCustomerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
            if (selectedCustomerType.Equals("Pcs"))
            {
                rptStockByLocationLocation_pcs rpt = new rptStockByLocationLocation_pcs();
                rpt.DataSource = this._listStockByLocationReport;
                CreateLocationLocationPcsField(rpt);
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
            else
            {
                if (rgChooseOption.SelectedIndex == 0)
                {
                    rptStockByLocationLocationDetails rpt = new rptStockByLocationLocationDetails();
                    rpt.lblafterpick.Visible = false;
                    rpt.lblTotalDetails.Visible = false;
                    rpt.lblQtyLocationDetailsReport.Visible = false;
                    rpt.DataSource = this._listStockByLocationReport;
                    CreateLocationDetailsField(rpt);
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    //DoCmd.OpenReport "rptStockByLocationLocationDetails", acViewPreview, , "[CustomerRef] LIKE '" & Me.textCustomerRef & "'"
                    rptStockByLocationLocationDetails rpt = new rptStockByLocationLocationDetails();
                    rpt.DataSource = this._listStockByLocationReport;
                    CreateLocationDetailsField(rpt);
                    ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                    printTool.ShowPreviewDialog();
                }
            }
        }

        private void btnViewData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            if (selectedCustomerID > 0)
            {
                DataTable dataSource = FileProcess.LoadTable("STStockByLocationReportByHeight @CustomerID = " + selectedCustomerID);
                if (dataSource != null && dataSource.Rows.Count != 0)
                {
                    DevExpress.XtraGrid.GridControl grdTemplate = new DevExpress.XtraGrid.GridControl();
                    grdTemplate.DataSource = dataSource;
                    WMSGridView tempGrvHistoryByDate = new WMSGridView();
                    grdTemplate.ViewCollection.Add(tempGrvHistoryByDate);
                    grdTemplate.BindingContext = new BindingContext();
                    grdTemplate.ForceInitialize();
                    string fileName = this.txtCustomerName.Text;
                    string exportFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + ".xls";//saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    grdTemplate.ExportToXls(exportFilePath);
                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //    }
                    //}

                }
                else
                {
                    MessageBox.Show("Data not found", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Please choose customer is first", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnViewByProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var isContinue = UpdateSQL();
            if (!isContinue)
            {
                return;
            }
            //Call UpdateSQL
            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rptStockByLocationProduct rpt = new rptStockByLocationProduct();
            rpt.xrLabel6.Text = this.dLocationDate.Text;
            rpt.DataSource = this._listStockByLocationReport;
            CreateLocationByProduct(rpt);
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.ShowPreviewDialog();
        }

        private void btnLabelAllRemain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            DataProcess<STLabelAllRemainByCustomer_Result> stLabelAllRemainByCustomerDA = new DataProcess<STLabelAllRemainByCustomer_Result>();
            IEnumerable<STLabelAllRemainByCustomer_Result> stLabelAllRemainByCustomerList = stLabelAllRemainByCustomerDA.Executing("STLabelAllRemainByCustomer @varCustomerID={0}", selectedCustomerID);
            rptLabelA4Short_Barcode rpt = new rptLabelA4Short_Barcode();
            //var dataSource = FileProcess.LoadTable("STLabelAllRemainByCustomer @varCustomerID=" + selectedCustomerID);
            rpt.DataSource = stLabelAllRemainByCustomerList;
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            rpt.Parameters["parameter1"].Value = 3;
            rpt.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }

        private void btnProductDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var isContinue = UpdateSQL();
            if (!isContinue)
            {
                return;
            }
            if (this._listStockByLocationReport.Count <= 0)
            {
                XtraMessageBox.Show("No data to print!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rgChooseOption.SelectedIndex == 0)
            {
                rptStockByLocationDetails rpt = new rptStockByLocationDetails();
                rpt.DataSource = this._listStockByLocationReport;
                CreateLocationDetails(rpt);
                rpt.groupHeaderLocationNumber.GroupFields.Add(new GroupField("LocationNumber"));
                //rpt.xrLabel38.DataBindings.Add("Text", rpt.DataSource, "LocationNumber");
                rpt.lblSumQty.DataBindings.Add("Text", rpt.DataSource, "Qty");
                rpt.lblSumAfterPicking.DataBindings.Add("Text", rpt.DataSource, "AfterDPQuantity");
                rpt.lblSumWeighing.DataBindings.Add("Text", rpt.DataSource, "mulWeight");
                rpt.lblTotalWeigh.DataBindings.Add("Text", rpt.DataSource, "mulWeight");
                rpt.lblTotalQty.DataBindings.Add("Text", rpt.DataSource, "Qty");
                rpt.lblTotalAfterPacking.DataBindings.Add("Text", rpt.DataSource, "AfterDPQuantity");

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
            else
            {
                //DoCmd.OpenReport "rptStockByLocationDetails", acViewPreview, , "[CustomerRef] LIKE '" & Me.textCustomerRef & "'"
                rptStockByLocationDetails rpt = new rptStockByLocationDetails(this.txtCustomerRef.Text);
                rpt.DataSource = this._listStockByLocationReport;
                CreateLocationDetails(rpt);
                rpt.groupHeaderLocationNumber.GroupFields.Add(new GroupField("LocationNumber"));
                rpt.lblSumQty.DataBindings.Add("Text", rpt.DataSource, "Qty");
                rpt.lblSumAfterPicking.DataBindings.Add("Text", rpt.DataSource, "AfterDPQuantity");
                rpt.lblSumWeighing.DataBindings.Add("Text", rpt.DataSource, "mulWeight");
                rpt.lblTotalWeigh.DataBindings.Add("Text", rpt.DataSource, "mulWeight");
                rpt.lblTotalQty.DataBindings.Add("Text", rpt.DataSource, "Qty");
                rpt.lblTotalAfterPacking.DataBindings.Add("Text", rpt.DataSource, "AfterDPQuantity");

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
        }

        private void btnGrossWeight_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IEnumerable<STStockByLocationGrossWeightReport_Result> stStockByLocationGrossWeightReportList;
            string roomID = XtraInputBox.Show("Please input Room:\nAll: All Rooms.", "WMS-2022", "ALL");
            if (roomID != null)
            {
                if (lkeCustomerNumber.EditValue == null || lkeCustomerNumber.EditValue.Equals(""))
                {
                    DataProcess<STStockByLocationGrossWeightReport_Result> stStockByLocationGrossWeightReportDA = new DataProcess<STStockByLocationGrossWeightReport_Result>();
                    stStockByLocationGrossWeightReportList = stStockByLocationGrossWeightReportDA.Executing("STStockByLocationGrossWeightReport @RoomID={0}", roomID);
                }
                else
                {
                    int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                    DataProcess<STStockByLocationGrossWeightReport_Result> stStockByLocationGrossWeightReportDA = new DataProcess<STStockByLocationGrossWeightReport_Result>();
                    stStockByLocationGrossWeightReportList = stStockByLocationGrossWeightReportDA.Executing("STStockByLocationGrossWeightReport @RoomID={0},@CustomerID={1}", roomID, selectedCustomerID);
                }
                rptStockByLocationGrossWeightReport rpt = new rptStockByLocationGrossWeightReport();
                rpt.DataSource = stStockByLocationGrossWeightReportList;
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
        }

        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            Customers selectedCustomer = AppSetting.CustomerList.Where(c => c.CustomerID == selectedCustomerID).SingleOrDefault();
            if (selectedCustomer != null)
            {
                frm_MSS_Customers frm = MasterSystemSetup.frm_MSS_Customers.Instance;
                frm.CurrentCustomers = selectedCustomer;
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                frm.Show();
            }
            else
            {
                string message = string.Format("Customer can not found with CustomerID {0}", selectedCustomerID);
                MessageBox.Show(message, "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region Calculated Fields for Report
        private void CreateLocationDetailsPcsField(XtraReport report)
        {
            CalculatedField divInners = new CalculatedField();
            divInners.DataSource = report.DataSource;
            divInners.DataMember = report.DataMember;
            divInners.DisplayName = "divInners";
            divInners.Name = "divInners";
            divInners.Expression = "[AfterDPQuantity] / [Inners]";

            report.CalculatedFields.Add(divInners);

            CalculatedField modInners = new CalculatedField();
            modInners.DataSource = report.DataSource;
            modInners.DataMember = report.DataMember;
            modInners.DisplayName = "modInners";
            modInners.Name = "modInners";
            modInners.Expression = "[AfterDPQuantity] % [Inners]";

            report.CalculatedFields.Add(modInners);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumInners = new CalculatedField();
            sumInners.DataSource = report.DataSource;
            sumInners.DataMember = report.DataMember;
            sumInners.DisplayName = "sumInners";
            sumInners.Name = "sumInners";
            sumInners.Expression = "Sum([Qty] / [Inners])";

            report.CalculatedFields.Add(sumInners);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationDetailsField(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = report.DataSource;
            sumAfter.DataMember = report.DataMember;
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Name = "sumAfter";
            sumAfter.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationDetailWeightInners(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumUnit = new CalculatedField();
            sumUnit.DataSource = report.DataSource;
            sumUnit.DataMember = report.DataMember;
            sumUnit.DisplayName = "sumUnit";
            sumUnit.Name = "sumUnit";
            sumUnit.Expression = "Sum([UnitQuantity])";

            report.CalculatedFields.Add(sumUnit);

            CalculatedField sumWeight = new CalculatedField();
            sumWeight.DataSource = report.DataSource;
            sumWeight.DataMember = report.DataMember;
            sumWeight.DisplayName = "sumWeight";
            sumWeight.Name = "sumWeight";
            sumWeight.Expression = "Sum([PalletWeight])";

            report.CalculatedFields.Add(sumWeight);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateReplenishment(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationLocationField(XtraReport report)
        {

            CalculatedField sumNetWeight = new CalculatedField();
            sumNetWeight.DataSource = report.DataSource;
            sumNetWeight.DataMember = report.DataMember;
            sumNetWeight.DisplayName = "sumNetWeight";
            sumNetWeight.Name = "sumNetWeight";
            sumNetWeight.Expression = "Sum([NetWeight])";

            report.CalculatedFields.Add(sumNetWeight);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = report.DataSource;
            sumAfter.DataMember = report.DataMember;
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Name = "sumAfter";
            sumAfter.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField sumTotalGross = new CalculatedField();
            sumTotalGross.DataSource = report.DataSource;
            sumTotalGross.DataMember = report.DataMember;
            sumTotalGross.DisplayName = "sumTotalGross";
            sumTotalGross.Name = "sumTotalGross";
            sumTotalGross.Expression = "Sum([TotalGrossWeight])";

            report.CalculatedFields.Add(sumTotalGross);

            CalculatedField sumGross = new CalculatedField();
            sumGross.DataSource = report.DataSource;
            sumGross.DataMember = report.DataMember;
            sumGross.DisplayName = "sumGross";
            sumGross.Name = "sumGross";
            sumGross.Expression = "Sum([GrossWeight])";

            report.CalculatedFields.Add(sumGross);


            ////List<STStockByLocationReport> source = new List<STStockByLocationReport>();
            ////source = report.DataSource as List<STStockByLocationReport>;
            ////source.Distinct();
            //CalculatedField countLocation = new CalculatedField();
            //countLocation.DataSource = report.DataSource;
            //countLocation.DataMember = report.DataMember;
            //countLocation.DisplayName = "countLocation";
            //countLocation.Name = "countLocation";
            //countLocation.Expression = "Count()";

            //report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationLocationPcsField(XtraReport report)
        {
            CalculatedField divInners = new CalculatedField();
            divInners.DataSource = report.DataSource;
            divInners.DataMember = report.DataMember;
            divInners.DisplayName = "divInners";
            divInners.Name = "divInners";
            divInners.Expression = "[Qty] / [Inners]";

            report.CalculatedFields.Add(divInners);

            CalculatedField modInners = new CalculatedField();
            modInners.DataSource = report.DataSource;
            modInners.DataMember = report.DataMember;
            modInners.DisplayName = "modInners";
            modInners.Name = "modInners";
            modInners.Expression = "[Qty] % [Inners]";

            report.CalculatedFields.Add(modInners);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField sumInners = new CalculatedField();
            sumInners.DataSource = report.DataSource;
            sumInners.DataMember = report.DataMember;
            sumInners.DisplayName = "sumInners";
            sumInners.Name = "sumInners";
            sumInners.Expression = "Sum([Qty] / [Inners])";

            report.CalculatedFields.Add(sumInners);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLocationByProduct(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);
        }

        private void CreateLowHighField(XtraReport report)
        {
            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);

            CalculatedField isVery = new CalculatedField();
            isVery.DataSource = report.DataSource;
            isVery.DataMember = report.DataMember;
            isVery.DisplayName = "isVery";
            isVery.Name = "isVery";
            isVery.Expression = "Iif([VeryLowHigh] == true, 'VERY', '')";

            report.CalculatedFields.Add(isVery);

            CalculatedField isLow = new CalculatedField();
            isLow.DataSource = report.DataSource;
            isLow.DataMember = report.DataMember;
            isLow.DisplayName = "isLow";
            isLow.Name = "isLow";
            isLow.Expression = "Iif([Low] == true, 'LOW', 'HIGH')";

            report.CalculatedFields.Add(isLow);

            CalculatedField convertLow = new CalculatedField();
            convertLow.DataSource = report.DataSource;
            convertLow.DataMember = report.DataMember;
            convertLow.DisplayName = "convertLow";
            convertLow.Name = "convertLow";
            convertLow.Expression = "Iif([Low] == true, '-1', '0')";

            report.CalculatedFields.Add(convertLow);

            CalculatedField convertVery = new CalculatedField();
            convertVery.DataSource = report.DataSource;
            convertVery.DataMember = report.DataMember;
            convertVery.DisplayName = "convertVery";
            convertVery.Name = "convertVery";
            convertVery.Expression = "Iif([VeryLowHigh] == true, '-1', '0')";

            report.CalculatedFields.Add(convertVery);
        }

        private void CreateLocationDetails(XtraReport report)
        {
            CalculatedField sumAfter = new CalculatedField();
            sumAfter.DataSource = report.DataSource;
            sumAfter.DataMember = report.DataMember;
            sumAfter.DisplayName = "sumAfter";
            sumAfter.Name = "sumAfter";
            sumAfter.Expression = "Sum([AfterDPQuantity])";

            report.CalculatedFields.Add(sumAfter);

            CalculatedField sumQty = new CalculatedField();
            sumQty.DataSource = report.DataSource;
            sumQty.DataMember = report.DataMember;
            sumQty.DisplayName = "sumQty";
            sumQty.Name = "sumQty";
            sumQty.Expression = "Sum([Qty])";

            report.CalculatedFields.Add(sumQty);

            CalculatedField countLocation = new CalculatedField();
            countLocation.DataSource = report.DataSource;
            countLocation.DataMember = report.DataMember;
            countLocation.DisplayName = "countLocation";
            countLocation.Name = "countLocation";
            countLocation.Expression = "Count()";

            report.CalculatedFields.Add(countLocation);

            CalculatedField mulWeight = new CalculatedField();
            mulWeight.DataSource = report.DataSource;
            mulWeight.DataMember = report.DataMember;
            mulWeight.DisplayName = "mulWeight";
            mulWeight.Name = "mulWeight";

            mulWeight.Expression = "[NetWeight]";
            //mulWeight.Expression = "[WeightPerPackage] * [Qty]";

            report.CalculatedFields.Add(mulWeight);
        }
        #endregion

        private void lkeCustomerNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

                DataProcess<STStockOnHandByLotListProducts_Result> stStockOnHandByLotListProductsDA = new DataProcess<STStockOnHandByLotListProducts_Result>();
                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                grcProducts.DataSource = stStockOnHandByLotListProductsDA.Executing("STStockOnHandByLotListProducts @varCustomerID={0}", selectedCustomerID);

                grvProducts.ClearSelection();
            }
        }

        private void lkeCustomerNumber_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeCustomerNumber.EditValue = e.Value;
            txtCustomerName.EditValue = lkeCustomerNumber.GetColumnValue("CustomerName").ToString();

            DataProcess<STStockOnHandByLotListProducts_Result> stStockOnHandByLotListProductsDA = new DataProcess<STStockOnHandByLotListProducts_Result>();
            int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
            grcProducts.DataSource = stStockOnHandByLotListProductsDA.Executing("STStockOnHandByLotListProducts @varCustomerID={0}", selectedCustomerID);

            grvProducts.ClearSelection();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {

                if (this.lkeCustomerNumber.EditValue == null) return;
                var date = this.dLocationDate.DateTime;
                int selectedCustomerID = Convert.ToInt32(lkeCustomerNumber.GetColumnValue("CustomerID"));
                DataProcess<STStockByLocationReportHistoryBydate_Result> stStockByLocationReportHistoryBydateDA = new DataProcess<STStockByLocationReportHistoryBydate_Result>();
                List<STStockByLocationReportHistoryBydate_Result> stStockByLocationReportHistoryBydateList = stStockByLocationReportHistoryBydateDA.Executing("STStockByLocationReportHistoryBydate @CustomerID={0},@ReportDate={1}", selectedCustomerID, dLocationDate.DateTime).ToList();

                //Export stStockByLocationReportHistoryBydateList đến file excel
                string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = pathSaveFile + "\\" + "HistoryBydate_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xlsx";
                urcTempLocationReportSource source = new urcTempLocationReportSource();
                source.grdDataSource.DataSource = stStockByLocationReportHistoryBydateList;
                //DevExpress.XtraGrid.GridControl tempGrcHistoryByDate = new DevExpress.XtraGrid.GridControl();
                //tempGrcHistoryByDate.DataSource = stStockByLocationReportHistoryBydateList;
                //WMSGridView tempGrvHistoryByDate = new WMSGridView();
                //tempGrvHistoryByDate.Columns.AddField("CustomerNumber");
                //tempGrvHistoryByDate.Columns.AddField("LocationNumber");
                //tempGrvHistoryByDate.Columns.AddField("CustomerName");
                //tempGrvHistoryByDate.Columns.AddField("ProductionDate");
                //tempGrvHistoryByDate.Columns.AddField("ReceivingOrderDate");
                //tempGrvHistoryByDate.Columns.AddField("ReceivingOrderNumber");
                //tempGrvHistoryByDate.Columns.AddField("ProductName");
                //tempGrvHistoryByDate.Columns.AddField("ProductGroupDescription");
                //tempGrvHistoryByDate.Columns.AddField("ID");
                //tempGrvHistoryByDate.Columns.AddField("Qty");
                //tempGrvHistoryByDate.Columns.AddField("CurrentQuantity");
                //tempGrvHistoryByDate.Columns.AddField("CustomerRef");
                //tempGrvHistoryByDate.Columns.AddField("Deep");
                //tempGrvHistoryByDate.Columns.AddField("PalletID");
                //tempGrvHistoryByDate.Columns.AddField("UseByDate");
                //tempGrvHistoryByDate.Columns.AddField("RoomID");
                //tempGrvHistoryByDate.Columns.AddField("LocationType");
                //tempGrvHistoryByDate.Columns.AddField("DateID");
                //tempGrvHistoryByDate.Columns.AddField("CustomerID");
                //tempGrcHistoryByDate.ViewCollection.Add(tempGrvHistoryByDate);
                //tempGrcHistoryByDate.BindingContext = new BindingContext();
                //tempGrcHistoryByDate.ForceInitialize();
                source.grvDataSource.ExportToXlsx(fileName);
                //tempGrvHistoryByDate.ExportToXlsx(fileName);
                System.Diagnostics.Process.Start(fileName);
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the btnViewKGR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void btnViewKGR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (lkeCustomerNumber.EditValue == null)
            {
                XtraMessageBox.Show("Please select customer !", "TPWMS");
                return;
            }
            string selectedCustomerType = lkeCustomerNumber.GetColumnValue("CustomerType").ToString();
            if (string.Equals(selectedCustomerType, CustomerTypeEnum.RANDOM_WEIGHT, StringComparison.OrdinalIgnoreCase)) // Customer is RandomWeight
            {
                rptStockByLocationLocationDetailsKGR rpt = new rptStockByLocationLocationDetailsKGR();

                
                rpt.DataSource = FileProcess.LoadTable("STStockByLocationReportKGR " + lkeCustomerNumber.EditValue); ;

                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
                printTool.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("The customer type is not RANDOM WEIGHT !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void checkShowAllInOutProducts_Properties_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowAllInOutProducts.Checked)
            {
                if (dLocationDate.EditValue.ToString() == DateTime.Today.ToString())
                {
                    this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockTakeByRequestAllData " + AppSetting.StoreID + ", 'ALL'," + this.lkeCustomerNumber.EditValue);
                }
                else
                {
                    this.grcInOutAllProducts.DataSource = FileProcess.LoadTable("STStockTakeByRequestAllDataHistory " + AppSetting.StoreID + ", 'ALL'," + this.lkeCustomerNumber.EditValue + ",'" + this.dLocationDate.EditValue + "'");
                }
                    
            }
            else
            {
                this.grcInOutAllProducts.DataSource = null;
            }

        }

        private void rpe_PalletID_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvStockByLocationDetails.FocusedRowHandle;
            int customerID = Convert.ToInt32(grvStockByLocationDetails.GetRowCellValue(handleIndex, "CustomerID").ToString());
            int productID = Convert.ToInt32(grvStockByLocationDetails.GetRowCellValue(handleIndex, "ProductID").ToString());
            frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, productID);
            form.Show();
        }

        private void rpe_ProductID_Click(object sender, EventArgs e)
        {
            frm_MSS_Products frm = frm_MSS_Products.Instance;
            frm.ProductIDLookup = Convert.ToInt32(this.grvStockByLocationDetails.GetFocusedRowCellValue("ProductID"));
            frm.ShowInTaskbar = false;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            frm.BringToFront();
            frm.Show();
        }

        private void rpe_ROID_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvStockByLocationDetails.FocusedRowHandle;
            int ReceivingOrderID = Convert.ToInt32(grvStockByLocationDetails.GetRowCellValue(handleIndex, "ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
            form.ReceivingOrderIDFind = ReceivingOrderID;
            form.Show();
        }
    }
}