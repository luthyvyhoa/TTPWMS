using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using UI.Helper;
using DA;
using UI.WarehouseManagement;
using DevExpress.XtraEditors;
using System.IO;
using System.Net.Mail;
using DevExpress.Export;
using System.Data.SqlClient;
namespace UI.StockTake
{

    public partial class frm_ST_StockTakeByRequestAllData : Form
    {
        private DataProcess<Rooms> RR = new DataProcess<Rooms>();
        public frm_ST_StockTakeByRequestAllData()
        {

            InitializeComponent();

            String SelectedRoom = "SELECT RoomID FROM Rooms WHERE StoreID = " + AppSetting.StoreID.ToString() + " UNION SELECT 'ALL' AS roomID";
            
            this.lke_RoomID.Properties.DataSource = FileProcess.LoadTable(SelectedRoom);
            this.dateEditReportDate.EditValue = DateTime.Today;
            this.lke_Customer.Properties.DataSource = FileProcess.LoadTable("STcomboCustomerIDAll " + AppSetting.StoreID);
            this.lke_Customer.Properties.ValueMember = "CustomerID";
            this.lke_Customer.Properties.DisplayMember = "CustomerNumber";
            this.lke_Customer.EditValue = 0;
            this.lke_RoomID.EditValue = "ALL";
            //this.dateEditReportDate.EditValue = DateTime.Now.AddDays(-0);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.grcStockTakeAllData.ShowPrintPreview();
        }

        private void lke_RoomID_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
        }

        private void lke_RoomID_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void rp_hle_PalletInfo_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvStockTakeAllDataTabelView.FocusedRowHandle;
            int customerID = Convert.ToInt32(grvStockTakeAllDataTabelView.GetRowCellValue(handleIndex, "CustomerID").ToString());
            int productID = Convert.ToInt32(grvStockTakeAllDataTabelView.GetRowCellValue(handleIndex, "ProductID").ToString());
            frm_WM_PalletInfo form = new frm_WM_PalletInfo(customerID, productID);
            form.Show();
        }

        private void rp_hle_ReceivingOrderID_Click(object sender, EventArgs e)
        {
            int handleIndex = this.grvStockTakeAllDataTabelView.FocusedRowHandle;
            int ReceivingOrderID = Convert.ToInt32(grvStockTakeAllDataTabelView.GetRowCellValue(handleIndex, "ReceivingOrderID").ToString());
            frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
            form.ReceivingOrderIDFind = ReceivingOrderID;
            form.Show();
        }

        private void rp_hle_ProductID_Click(object sender, EventArgs e)
        {
            //int handleIndex = this.grvStockTakeAllDataTabelView.FocusedRowHandle;
            //int ReceivingOrderID = Convert.ToInt32(grvStockTakeAllDataTabelView.GetRowCellValue(handleIndex, "ProductID").ToString());
            //frm_WM_ReceivingOrders form = frm_WM_ReceivingOrders.Instance;
            //form.ReceivingOrderIDFind = ReceivingOrderID;
            //form.Show();
        }

        private void lke_Customer_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            txtCustomerName.Text = Convert.ToString(lke_Customer.Properties.GetDataSourceValue("CustomerName", lke_Customer.ItemIndex));

        }

        private void dateEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        private void UpdateAllStockGrid()
        {
            int CustomerID = Convert.ToInt32(lke_Customer.EditValue);
            String RoomID = lke_RoomID.EditValue.ToString();
            DateTime ReportDate = Convert.ToDateTime(dateEditReportDate.EditValue.ToString());
            int isKGR = 0;
            isKGR = Convert.ToInt16(this.checkKGR.EditValue);
            Common.Process.Wait.Start(this);
            //var result = 0;
            if (dateEditReportDate.EditValue.ToString() == DateTime.Today.ToString())
            {
                grcStockTakeAllData.DataSource = FileProcess.LoadTable("STStockTakeByRequestAllData " +AppSetting.StoreID +", '" +RoomID+ "',"+ CustomerID+"," + isKGR);
            }
            else
            {
                string qry = "STStockTakeByRequestAllDataHistory " + AppSetting.StoreID + ", '" + RoomID + "'," + CustomerID + ", '" + ReportDate.ToString("yyyy MMM dd") + "'";
                //XtraMessageBox.Show(qry);
                grcStockTakeAllData.DataSource = FileProcess.LoadTable(qry);
            }
            if (isKGR == 1)
            {
                this.grvStockTakeAllDataTabelView.Columns[41].Visible = true;
                this.grvStockTakeAllDataTabelView.Columns[40].Visible = true;
                this.grvStockTakeAllDataTabelView.Columns[37].Visible = true;
                this.grvStockTakeAllDataTabelView.Columns[38].Visible = true;
                this.grvStockTakeAllDataTabelView.Columns[39].Visible = true;
            }
            else
            {
                this.grvStockTakeAllDataTabelView.Columns[41].Visible = false;
                this.grvStockTakeAllDataTabelView.Columns[40].Visible = false;
                this.grvStockTakeAllDataTabelView.Columns[37].Visible = false;
                this.grvStockTakeAllDataTabelView.Columns[38].Visible = false;
                this.grvStockTakeAllDataTabelView.Columns[39].Visible = false;
            }




            Common.Process.Wait.Close();
        }

        private void dateEditReportDate_EditValueChanged(object sender, EventArgs e)
        {
            if (this.dateEditReportDate.EditValue.ToString() != DateTime.Today.ToString())
                this.checkKGR.Visible = false;
            else
                this.checkKGR.Visible = true;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            UpdateAllStockGrid();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (this.lke_Customer.EditValue == null) return;
            string email = AppSetting.CustomerList.Where(c => c.CustomerID == Convert.ToInt32(this.lke_Customer.EditValue)).FirstOrDefault().Email;

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

                        SendMailExcel(email, this.grvStockTakeAllDataTabelView, "SCS VN Report - Stock by Location | " + this.dateEditReportDate.EditValue.ToString() + " | " + this.txtCustomerName.Text) ;
 
                }
            }
        }
        private void SendMailExcel(string toEmail, DevExpress.XtraGrid.Views.Grid.GridView grv, string subject)
        {
            try
            {
                string fileExtension = "rtf";
                string boby = "Stock Report From SCS VN";
                using (MemoryStream mem = new MemoryStream())
                {

                    grv.ExportToXlsx(mem);
                    fileExtension = "xlsx";
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

        private void lke_Customer_Properties_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lke_Customer.EditValue = e.Value;
            if (this.lke_Customer.EditValue == null)
            {
                this.txtCustomerName.Text = string.Empty;
                return;
            }

            this.txtCustomerName.Text = Convert.ToString(this.lke_Customer.GetColumnValue("CustomerName"));
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
                this.grcStockTakeAllData.ExportToXlsx(sfd.FileName, options);
                try
                {
                    System.Diagnostics.Process.Start("Excel", sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sfd.Dispose();
        }

        private void btnCreateCheckingOrders_Click(object sender, EventArgs e)
        {
            String strPalletID = "";
            
            foreach (int i in this.grvStockTakeAllDataTabelView.GetSelectedRows())
            {
                strPalletID = strPalletID + ","+ this.grvStockTakeAllDataTabelView.GetRowCellValue(i, "PalletID");
            }
            if (strPalletID == "")
                return;
            SqlConnection conn = new SqlConnection(new SwireDBEntities().Database.Connection.ConnectionString);
            SqlCommand cmd = new SqlCommand("STCustomerStockTake_CreateOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter varCustomerID = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            varCustomerID.Value = lke_Customer.EditValue;

            SqlParameter varPalletID = cmd.Parameters.Add("@strPalletID", SqlDbType.VarChar);
            varPalletID.Value = strPalletID;
            SqlParameter CurrentUser = cmd.Parameters.Add("@CurrentUser", SqlDbType.VarChar);
            CurrentUser.Value = Convert.ToString(AppSetting.CurrentUser);
            SqlParameter varCustomerStockTakeID = cmd.Parameters.Add("@CustomerStockTakeID", SqlDbType.Int);
            varCustomerStockTakeID.Direction = ParameterDirection.Output;
            conn.Open();
            int result = cmd.ExecuteNonQuery();

            frm_WM_CustomerStockTakes frm = new frm_WM_CustomerStockTakes(Convert.ToInt32(varCustomerStockTakeID.Value));
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }
    }
}
