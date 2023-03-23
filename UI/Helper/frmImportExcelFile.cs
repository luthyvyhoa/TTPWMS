using Common.Controls;
using DA;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Helper
{
    public partial class frmImportExcelFile : frmBaseForm
    {
        int m_CustomerMainID = 0;
        string m_userName = AppSetting.CurrentUser.LoginName;
        private DataTable importSource;

        public frmImportExcelFile()
        {
            InitializeComponent();

            // Init events
            chkEdit_CustomerMain.CheckedChanged += ChkEdit_CustomerMain_CheckedChanged;
            searchLookUpEdit_CustomerID.EditValueChanged += SearchLookUpEdit_CustomerID_EditValueChanged;

            this.LoadData2searchLookUpEdit_CustomerID();
        }
        /// <summary>
        /// Get datasource from excel file has imported
        /// </summary>
        public DataTable ExcelImportSource
        {
            get
            {
                return this.importSource;
            }
        }

        void SearchLookUpEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(searchLookUpEdit_CustomerID.EditValue);
            }
            catch { }

            if (chkEdit_CustomerMain.Checked == true)
            {
                var v_Cus = ((IEnumerable<STEDI_comboCustomerMainID_Result>)searchLookUpEdit_CustomerID.Properties.DataSource).Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                try
                {
                    txtEdit_CustomerName.EditValue = v_Cus.CustomerName;
                    this.m_CustomerMainID = Convert.ToInt32(v_Cus.CustomerMainID);
                }
                catch { }
            }
            else
            {
                var v_Cus = ((IEnumerable<STEDI_comboCustomerMainID_Result>)searchLookUpEdit_CustomerID.Properties.DataSource).Where(c => c.CustomerID == v_CustomerID).FirstOrDefault();
                try
                {
                    txtEdit_CustomerName.EditValue = v_Cus.CustomerName;
                    this.m_CustomerMainID = Convert.ToInt32(v_Cus.CustomerMainID);
                }
                catch { }
            }
        }

        void LoadData2searchLookUpEdit_CustomerID()
        {
            searchLookUpEdit_CustomerID.Properties.DataSource = (new DA.DataProcess<STEDI_comboCustomerMainID_Result>()).Executing("STEDI_comboCustomerMainID @IsMain={0},@StoreID={1}", chkEdit_CustomerMain.Checked, AppSetting.StoreID);
        }

        bool ImportDataFromExcelCustomerCommon(string excelFilePath)
        {
            string v_sheetName = "";
            this.grvFileContents.Columns.Clear();
            grdFileContents.Refresh();
            try
            {
                v_sheetName = Convert.ToString(Convert.ToString(lkUEdit_Sheet.EditValue));
            }
            catch { }
            string myexceldataquery = "select * from [" + v_sheetName.Trim() + "]";
            try
            {
                //create our connection strings 
                string sexcelconnectionstring = "";
                string extensionFile = Path.GetExtension(excelFilePath);
                switch (extensionFile)
                {
                    case ".xls":
                        sexcelconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        sexcelconnectionstring = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        sexcelconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                }
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                oledbconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, v_sheetName);
                oledbconn.Close();
                DataTable v_dtRet = ds.Tables[0];
                this.grdFileContents.DataSource = v_dtRet;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void ChkEdit_CustomerMain_CheckedChanged(object sender, EventArgs e)
        {
            LoadData2searchLookUpEdit_CustomerID();
            searchLookUpEdit_CustomerID.Focus();
            searchLookUpEdit_CustomerID.ShowPopup();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            DataProcess<object> process = new DataProcess<object>();
            string v_PathFile = txtEdit_FileBrowser.Text;
            if (string.IsNullOrEmpty(v_PathFile) || !System.IO.File.Exists(v_PathFile))
            {
                XtraMessageBox.Show("You must choose to file that need process!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (v_PathFile.Substring(v_PathFile.Length - 5, 5).ToUpper().Equals(".xlsx".ToUpper())|| v_PathFile.Substring(v_PathFile.Length - 4, 4).ToUpper().Equals(".xls".ToUpper()))
            {
              
            }
            else
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
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls;*.xlsx";
            //of.Filter = "Excel File|*.xls";
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

        private void btn_OpenExcelFile_Click(object sender, EventArgs e)
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

        DataTable GetTableExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                string connString = "";
                string extensionFile = Path.GetExtension(excelFile);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
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

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            if (this.grdFileContents.DataSource == null) return;
            var v_dtRet = (DataTable)this.grdFileContents.DataSource;
            this.importSource = v_dtRet;
            this.Close();
        }

        private void grdFileContents_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void grdFileContents_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (filenames != null)
            {
                foreach (string name in filenames)
                {
                    try
                    {
                        this.txtEdit_FileBrowser.Text = name;
                        GetSheetName();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private void GetSheetName()
        {
            // txtEdit_FileBrowser.Text = of.FileName;

            DataTable v_TableSheet = this.GetTableExcelSheetNames(txtEdit_FileBrowser.Text);
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
}
