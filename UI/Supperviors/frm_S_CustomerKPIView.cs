using DA;
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
using WMS.DA;

namespace UI.Supperviors
{
    public partial class frm_S_CustomerKPIView : Form
    {
        public frm_S_CustomerKPIView()
        {
            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";

            this.lkeCustomers.Properties.DataSource = FileProcess.LoadTable("STComboCustomerMainID " + AppSetting.StoreID);
            this.lkeCustomers.Properties.DropDownRows = 20;
            this.lkeCustomers.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomers.Properties.ValueMember = "CustomerID";

            //code here to check whether the record
            this.labelConfirmed.BackColor = Color.Blue;



        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (this.lkeCustomers.EditValue == null) return;

            //// code to insert to the CustomerKPIRecordings here
            //CustomerKPIRecording newRecord = null;
            //DataProcess<CustomerKPIRecording> recordDA = new DataProcess<CustomerKPIRecording>();
            //CustomerKPIRecording[] arr = new CustomerKPIRecording[this.grvKPIList.RowCount];
            //for (int index = 0; index < this.grvKPIList.RowCount; index++)
            //{
            //    var currentRow = (DataRow)this.grvKPIList.GetRow(index);
            //    newRecord = new CustomerKPIRecording();
            //    newRecord.ActualRecordedQuantity = Convert.ToDecimal(currentRow["ActualQTY"]);
            //    newRecord.CustomerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            //    newRecord.CustomerKPICategoryID = 1;
            //    newRecord.CustomerKPIRecordingID = 1;
            //    newRecord.CustomerKPIRecordingRemark = "";
            //    newRecord.OperatingCostMonthlyID = 1;
            //    newRecord.RecordedKPIQuantity = 1;
            //    newRecord.RelatedActivityQuantity = 1;
            //    arr[index] = newRecord;
            //}

            //// Insert array , please re-check data is correct before uncomment below code
            //recordDA.Insert(arr);
            //MessageBox.Show("KPI data created !", "TPWMS");

            //Làm lại code chỗ này, khi nhấn confirm thì update tất cả các records là đã confirm rồi, không cho phép cập nhật nữa
            //UPDATE CustomerKPIRecordings SET ConfirmedBy = AppSetting.CurrentUser, ConfirmedTime = GETDATE() WHERE CustomerID = @CustomerID and OperatingCostMonthlyID = @OperatingCostMonthlyID
            string confirmStr = string.Empty;
            int kpiID = 0;
            DataProcess<object> dataProcess = new DataProcess<object>();
            for (int index = 0; index < this.grvKPIList.RowCount; index++)
            {
                confirmStr = Convert.ToString(this.grvKPIList.GetRowCellValue(index, "ConfirmTime"));
                if (!string.IsNullOrEmpty(confirmStr)) continue;
                kpiID = Convert.ToInt32(this.grvKPIList.GetRowCellValue(index, "CustomerKPIRecordingID"));
                dataProcess.ExecuteNoQuery("Update CustomerKPIRecordings set ConfirmTime=N'" + AppSetting.CurrentUser.LoginName
                    + "',ConfirmedTime='" + DateTime.Now + "' Where CustomerKPIRecordingID=" + kpiID);
            }
            this.labelConfirmed.BackColor = Color.Red;
            this.btnConfirm.Enabled = false;
        }

        private void lkeCustomers_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {


        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            // code to export to excel file here.
            //string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           // string fileName = "D:\\WMS-2017\\" + "PalletHistory_" + this.textEditCustomerName.Text + "_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" 
                + "CustomerKPI_" + this.lkeCustomers.GetColumnValue("CustomerNumber").ToString() +"_" + this.lke_OperatingCostMonthlyID.GetColumnValue("MonthDescription").ToString() + ".xlsx";
            this.grvKPIList.ExportToXlsx(fileName);
            System.Diagnostics.Process.Start(fileName);
        }

        private void grvKPIList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.grvKPIList.DataSource == null)
                return;
            else
            {
                if (this.grvKPIList.GetFocusedRowCellValue("CustomerKPICategoryID") != null)
                    this.chartCustomerKPIView.DataSource = FileProcess.LoadTable("STCustomerKPIReportShowChart " + this.lkeCustomers.EditValue.ToString() + "," + this.grvKPIList.GetFocusedRowCellValue("CustomerKPICategoryID").ToString());
            }
            //MessageBox.Show("STCustomerKPIReportShowChart " + this.lkeCustomers.EditValue.ToString() + "," + this.grvKPIList.GetFocusedRowCellValue("CustomerKPICategoryID").ToString());
        }

        private void btnDeleteRefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the recorded KPI and rebuild the data ?", "Refresh Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.grcKPIList.DataSource = FileProcess.LoadTable("STCustomerKPIReportShowRefreshed " + this.lkeCustomers.EditValue.ToString() + ", " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + ",'" + AppSetting.CurrentUser.LoginName + "'");
            }
        }

        private void grvKPIList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int kpiID = Convert.ToInt32(this.grvKPIList.GetRowCellValue(e.RowHandle, "CustomerKPIRecordingID"));
            int plannedKPIID = Convert.ToInt32(this.grvKPIList.GetRowCellValue(e.RowHandle, "CustomerKPIPlanningID"));
            DataProcess<object> dataProcess = new DataProcess<object>();
            switch (e.Column.FieldName)
            {
                case "CustomerKPIRecordingRemark":
                    dataProcess.ExecuteNoQuery("Update CustomerKPIRecordings set CustomerKPIRecordingRemark=N'" + e.Value + "' Where CustomerKPIRecordingID=" + kpiID);
                    break;
                case "PlannedKPIQuantity":
                    dataProcess.ExecuteNoQuery("Update CustomerKPIPlannings set PLannedKPIQuantity =" + e.Value + " Where CustomerKPIPlanningID=" + plannedKPIID);
                    break;
                default:
                    break;
            }
        }

        private void lkeCustomers_EditValueChanged(object sender, EventArgs e)
        {
            // code to refresh the grid
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            this.txtCustomerName.Text = this.lkeCustomers.GetColumnValue("CustomerName").ToString();
            //AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
            this.grcKPIList.DataSource = FileProcess.LoadTable("STCustomerKPIReport " + this.lkeCustomers.EditValue.ToString() + ", " + this.lke_OperatingCostMonthlyID.EditValue + " ,'system'");

            // Kiểm tra nếu đã confirm (Đã có confirmby, Confirmtime tróng record rồi thì không cho update, delete hoặc insert
            //
            this.labelConfirmed.BackColor = Color.Red;
            this.btnConfirm.Enabled = false;

            // Còn nếu chưa confirm thì cho update, delete hoặc insert
            this.labelConfirmed.BackColor = Color.Blue;
            this.btnConfirm.Enabled = true;
        }

        private void lke_OperatingCostMonthlyID_EditValueChanged(object sender, EventArgs e)
        {
            // code to refresh the grid
            int customerID = Convert.ToInt32(this.lkeCustomers.EditValue);
            //this.txtCustomerName.Text = this.lkeCustomers.GetColumnValue("CustomerName").ToString();
            //AppSetting.CustomerListAll.Where(c => c.CustomerID == customerID).FirstOrDefault().CustomerName;
            if (this.lkeCustomers.EditValue == null)
                return;
            else
                this.grcKPIList.DataSource = FileProcess.LoadTable("STCustomerKPIReport " + this.lkeCustomers.EditValue.ToString() + ", " + this.lke_OperatingCostMonthlyID.EditValue + " ,'system'");

            // Kiểm tra nếu đã confirm (Đã có confirmby, Confirmtime tróng record rồi thì không cho update, delete hoặc insert
            //
            this.labelConfirmed.BackColor = Color.Red;
            this.btnConfirm.Enabled = false;

            // Còn nếu chưa confirm thì cho update, delete hoặc insert
            this.labelConfirmed.BackColor = Color.Blue;
            this.btnConfirm.Enabled = true;
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            if (this.grvKPIList.DataSource == null)
                return;
            else
            {
                if (this.grvKPIList.GetFocusedRowCellValue("CustomerKPICategoryID").ToString() != null)
                    this.chartCustomerKPIView.DataSource = FileProcess.LoadTable("STCustomerKPIReportShowChart " + this.lkeCustomers.EditValue.ToString() + "," + this.grvKPIList.GetFocusedRowCellValue("CustomerKPICategoryID").ToString());
            }
        }
    }
}
