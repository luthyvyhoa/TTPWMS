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
using DA;
using UI.Helper;
using System.Data.OleDb;

namespace UI.CRM
{
    public partial class frm_CRM_OperatingCostEntry_ImportFile : frmBaseForm
    {
        DataProcess<OperatingCostDetailByCustomers> dataProcessOperatingCostDetailByCustomers = new DataProcess<OperatingCostDetailByCustomers>();
        private frm_CRM_OperatingCostEntry frm_crm_OperatingCostEntry;
        private int currentOperatingCostMonthlyDetailID;
        private int monthlyID;
        private int operatingCostID;
        public frm_CRM_OperatingCostEntry_ImportFile(int id,int monthlyID,int operatingCostID, frm_CRM_OperatingCostEntry frm_crm_OperatingCostEntry)
        {
            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = monthlyID;
            this.monthlyID = monthlyID;
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";
            this.lke_MSS_StoreList.EditValue = AppSetting.CurrentUser.StoreID;
            currentOperatingCostMonthlyDetailID = id;
            this.operatingCostID = operatingCostID;
            this.frm_crm_OperatingCostEntry = frm_crm_OperatingCostEntry;
        }
        private void btn_Browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //of.Filter = "Excel File|*.xls||*.xlsx";
            of.Filter = "Excel File|*.xls";
            of.Title = "WMS - Please select a Excel file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            // of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtEdit_FileBrowser.Text = of.FileName;

                DataTable v_TableSheet = this.GetTableExcelSheetNames(of.FileName);
                lkUEdit_Sheet.Properties.DataSource = v_TableSheet;
                lkUEdit_Sheet.Properties.DisplayMember = "Name";
                lkUEdit_Sheet.Properties.ValueMember = "Name";

                string v_sheetName = "";
                try
                {
                    v_sheetName = Convert.ToString(v_TableSheet.Rows[0]["Name"]);
                    lkUEdit_Sheet.EditValue = v_sheetName;
                }
                catch { }
            }
        }
        private void btn_OpenExcelFile_Click_1(object sender, EventArgs e)
        {
            string v_FilePath = txtEdit_FileBrowser.Text;

            if (System.IO.File.Exists(v_FilePath))
            {
                System.Diagnostics.Process.Start(txtEdit_FileBrowser.Text);
            }
            else
            {
                XtraMessageBox.Show("You must choose to file that need open !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btn_ImportFile_Click(object sender, EventArgs e)
        {

            DataProcess<object> process = new DataProcess<object>();
            string v_PathFile = txtEdit_FileBrowser.Text;
            if (string.IsNullOrEmpty(v_PathFile) || !System.IO.File.Exists(v_PathFile))
            {
                XtraMessageBox.Show("You must choose to file that need process!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!v_PathFile.Substring(v_PathFile.Length - 4, 4).ToUpper().Equals(".xls".ToUpper()))
            {
                XtraMessageBox.Show("This file is not excel file format, select file again!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string v_SheetName = "";
            try
            {
                v_SheetName = Convert.ToString(lkUEdit_Sheet.EditValue);
            }
            catch { }

            if (string.IsNullOrEmpty(v_SheetName))
            {
                XtraMessageBox.Show("You must select sheet !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.ImportDataFromExcelCustomerCommon(v_PathFile);
            btn_CreateData.Enabled = true;
        }
        DataTable v_dtRet = null;
        bool ImportDataFromExcelCustomerCommon(string excelFilePath)
        {
            string v_sheetName = "";

            try
            {
                v_sheetName = Convert.ToString(Convert.ToString(lkUEdit_Sheet.EditValue));
            }
            catch { }

            //string tableName = "";
            //switch (this.fileType)
            //{
            //    case FileTypeImportEnum.CustomerClient:
            //        tableName = "CustomerClients";
            //        break;
            //    default:

            //        break;
            //}

            string myexceldataquery = "select * from [" + v_sheetName.Trim() + "]";
            try
            {
                //create our connection strings 
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelFilePath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                oledbconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, v_sheetName);
                oledbconn.Close();
                v_dtRet = ds.Tables[0];
                this.grcOperationCost.DataSource = v_dtRet;
                this.txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                this.txtEdit_Message.Text = "File imported succesful !";
                //FileProcess.InsertFile(v_dtRet, tableName);
                return true;
            }
            catch (Exception ex)
            {
                txtEdit_Message.ForeColor = System.Drawing.Color.Red;
                this.txtEdit_Message.Text = "Error import file !";
                return false;
            }
        }
      
        #region Excel use Ole 
        DataTable GetTableExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
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



        #endregion
     
        private void btn_CreateData_Click(object sender, EventArgs e)
        {
            try
            {
            DataRow[] listDataExcel = v_dtRet.Select();
            OperatingCostDetailByCustomers operatingCostDetailByCustomers = new OperatingCostDetailByCustomers();
            //add data colunm rate 
            DataTable monlyParmeter = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + monthlyID + "," + this.lke_MSS_StoreList.EditValue.ToString());
            
            //add data colunm remark
            DataTable remarkList = FileProcess.LoadTable("OperatingCostMonthly_ViewDetails " + monthlyID + "," + this.lke_MSS_StoreList.EditValue.ToString());

            //add data colunm OperatingCostDetailByCustomerQuantityAdjusted

            switch (operatingCostID)
            {
                case 10:
                        operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Carton boxes & Transportation";
                    break;
                case 11:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Forwarding Expenses";
                    break;
                case 15:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Excess";
                    break;
                case 30:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Electricity";
                    break;
                default:
                    operatingCostDetailByCustomers.OperatingCostDetailByCustomerRemark = "Clear Data";
                break;
            }

            foreach (DataRow row in listDataExcel)
            {
                operatingCostDetailByCustomers.CustomerID = Convert.ToInt32(row[0]);
                operatingCostDetailByCustomers.OperatingCostMonthlyDetailID = currentOperatingCostMonthlyDetailID;   
                operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantity= Convert.ToDecimal(row[1]);
                DataRow[] rate = monlyParmeter.Select(string.Format("CustomerID ='{0}' ", Convert.ToInt32(row[0])));
                foreach (DataRow rowRate in rate)// nếu cái này không có giá trị  mặc định bằng bao nhiêu
                {
                        operatingCostDetailByCustomers.OperatingCostDriverRate = Convert.ToDecimal(rowRate[13]);
                }
                decimal quantityAdjusted = Convert.ToDecimal(row[1]) * operatingCostDetailByCustomers.OperatingCostDriverRate;
                operatingCostDetailByCustomers.OperatingCostDetailByCustomerQuantityAdjusted = quantityAdjusted;
                int result = dataProcessOperatingCostDetailByCustomers.Insert(operatingCostDetailByCustomers);

                if (result < 0)
                    {
                        MessageBox.Show("Cannot Insert Data Excel  !", "WMS-2017",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

            }
                //for(int i=0; i<this.grvOperationCost.RowCount;i++)
                // {
                //     Console.WriteLine("{0}, {1}", this.grvOperationCost.GetRowCellValue(i,), row[1]);
                // }
                this.txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                this.txtEdit_Message.Text = "File create data succesful !";
                LoadOperatingCostDetailByCustomer();
            }
            catch(Exception e1)
            {
                txtEdit_Message.ForeColor = System.Drawing.Color.Red;
                this.txtEdit_Message.Text = "Error create data file !";
            }
        }
        private void LoadOperatingCostDetailByCustomer()
        {
            frm_crm_OperatingCostEntry.grcOperatingCostDetailByCustomer.DataSource= FileProcess.LoadTable("OperatingCostMonthly_ViewByOperatingCostMonthlyDetailID " + currentOperatingCostMonthlyDetailID);  
        }

    }
}