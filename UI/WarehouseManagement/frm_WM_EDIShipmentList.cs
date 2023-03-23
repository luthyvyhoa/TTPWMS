using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIShipmentList : frmBaseFormNormal
    {
        public int TripID { get; private set; }
        private string fileName = string.Empty;
        private string sheetName = string.Empty;
        private int flag = 0;

        public frm_WM_EDIShipmentList()
        {
            InitializeComponent();
            this.dFrom.DateTime = DateTime.Today;
            this.dTo.DateTime = DateTime.Today.AddDays(1);

            this.LoadData2searchLookUpEdit_CustomerID();
        }

        
        void LoadData2searchLookUpEdit_CustomerID()
        {
            searchLookUpEdit_CustomerID.Properties.DataSource = AppSetting.CustomerList.OrderBy(b => b.CustomerNumber);
            this.searchLookUpEdit_CustomerID.Properties.DisplayMember = "CustomerNumber";
            this.searchLookUpEdit_CustomerID.Properties.ValueMember = "CustomerID";
        }

        private void searchLookUpEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_CustomerName.EditValue = this.searchLookUpEdit_CustomerID.GetColumnValue("CustomerName");
            LoadGrids();
        }
        private void LoadGrids()
        {
            if (this.dFrom.EditValue == null || this.dTo.EditValue == null || this.searchLookUpEdit_CustomerID.EditValue == null) return;
            this.grcShipmentList.DataSource = FileProcess.LoadTable("ST_WMS_LoadEDI_ShipmentList " + this.searchLookUpEdit_CustomerID.EditValue + ",'" +
                this.dFrom.DateTime.ToString("yyyy-MM-dd") + "','" + this.dTo.DateTime.ToString("yyyy-MM-dd") + "'");
        }
        private void btn_Browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files| *.xls; *.xlsx; ";
            of.Title = "WMS - Please select a Excel file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.fileName = of.FileName;

                DataTable v_TableSheet = this.GetTableExcelSheetNames(of.FileName);

                // get sheet first in file
                this.sheetName = Convert.ToString(v_TableSheet.Rows[0]["Name"]);
                this.txtEdit_FileBrowser.Text = fileName;
            }
        }
        DataTable GetTableExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                var pathArr = excelFile.Split('.');
                var excelType = pathArr[pathArr.Length - 1];
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                 "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                switch (excelType.ToUpper())
                {
                    case "XLSX":
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + "; Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;\'";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                 "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                }

                objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }

                DataTable v_Dt = new DataTable();
                v_Dt.Columns.Add("Name", typeof(string));

                foreach (DataRow i_Row in dt.Rows)
                {
                    DataRow v_Row = v_Dt.NewRow();
                    v_Row["Name"] = i_Row["TABLE_NAME"];

                    v_Dt.Rows.Add(v_Row);
                }

                return v_Dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        DataTable GetSheetData(string i_excelFile, string sheetName, string i_ConnectString)
        {
            string srcQuery = "Select * from [" + sheetName + "]";
            OleDbConnection srcConn = new OleDbConnection(i_ConnectString);
            srcConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand(srcQuery, srcConn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
            da.Fill(ds, sheetName);
            srcConn.Close();
            return ds.Tables[0];
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit_CustomerID.EditValue == null)
            {
                this.searchLookUpEdit_CustomerID.Focus();
                this.searchLookUpEdit_CustomerID.ShowPopup();
                return;
            }

            if (this.dFrom.EditValue == null || this.dTo.EditValue == null)
            {
                MessageBox.Show("Date import is invalid !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dFrom.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtEdit_FileBrowser.Text))
            {
                MessageBox.Show("Import file is invalid !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btn_Browser.Focus();
                return;
            }

            // get all data on current sheet
            string myexceldataquery = "select * from [" + this.sheetName.Trim() + "]";

            //create our connection strings 
            string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + fileName + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
            var pathArr = fileName.Split('.');
            var excelType = pathArr[pathArr.Length - 1];
            switch (excelType.ToUpper())
            {
                case "XLSX":
                    sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + "; Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;\'";
                    break;
                default:
                    sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + fileName + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                    break;
            }

            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            oledbconn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
            da.Fill(ds, this.sheetName);
            oledbconn.Close();
            DataTable v_dtRet = ds.Tables[0];
            v_dtRet.Columns.Add("CreatedTime", typeof(DateTime));
            v_dtRet.Columns.Add("CreatedBy", typeof(string));
            v_dtRet.Columns["CreatedTime"].SetOrdinal(v_dtRet.Columns.Count-2);
            v_dtRet.Columns["CreatedBy"].SetOrdinal(v_dtRet.Columns.Count-1);

            for (int rowIndex = 0; rowIndex < v_dtRet.Rows.Count; rowIndex++)
            {
                v_dtRet.Rows[rowIndex]["CreatedTime"] = DateTime.Now;
                v_dtRet.Rows[rowIndex]["CreatedBy"] = AppSetting.CurrentUser.LoginName;
            }

            // Insert excel into DB
            FileProcess.InsertFile(v_dtRet, "tmpEDIShipmentImport");

            // Create new trip
            DataProcess<object> importDA = new DataProcess<object>();

            if (this.flag == 0)
            {
                int result = importDA.ExecuteNoQuery("STTripPlanImport @UserID={0},@CustomerID={1},@FromDate={2},@ToDate={3}",
                    AppSetting.CurrentUser.LoginName, this.searchLookUpEdit_CustomerID.EditValue, this.dFrom.DateTime.ToString("yyyy-MM-dd"), this.dTo.DateTime.ToString("yyyy-MM-dd"));
                if (result > 0)
                {
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Import is not succeed", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                int result = importDA.ExecuteNoQuery("ST_OMD_ED_VehicleImport @UserID={0},@CustomerID={1},@FromDate={2},@ToDate={3}",
                    AppSetting.CurrentUser.LoginName, this.searchLookUpEdit_CustomerID.EditValue, this.dFrom.DateTime.ToString("yyyy-MM-dd"), this.dTo.DateTime.ToString("yyyy-MM-dd"));
                if (result > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR : Import FAIL", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

        }

        private void grvShipmentList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string sql = "ST_WMS_LoadEDI_ShipmentDetails " + this.grvShipmentList.GetFocusedRowCellValue("EDI_ShipmentID");
            this.grcShipmentDetails.DataSource = FileProcess.LoadTable(sql);
        }

        private void dFrom_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrids();
        }

        private void dTo_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrids();
        }

        private void grcShipmentDetails_Click(object sender, EventArgs e)
        {
            //LoadGrids();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            this.dFrom.DateTime = this.dFrom.DateTime.AddDays(1);
            this.dTo.DateTime = this.dTo.DateTime.AddDays(1);
            LoadGrids();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            this.dFrom.DateTime = this.dFrom.DateTime.AddDays(-1);
            this.dTo.DateTime = this.dTo.DateTime.AddDays(-1);
            LoadGrids();

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int re;
            string strSQL = "";
            foreach (var index in this.grvShipmentList.GetSelectedRows())
            {
                DataProcess<object> v_Da = new DataProcess<object>();
                strSQL = "STEDI_ProcessShipment " + Convert.ToInt32(this.grvShipmentList.GetRowCellDisplayText(index, "EDI_ShipmentID")) + ", '" + AppSetting.CurrentUser + "'"; ;
                re = v_Da.ExecuteNoQuery(strSQL);
                if (re < 0)
                {
                    MessageBox.Show("Process Fail", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadGrids();
        }
    }
}
