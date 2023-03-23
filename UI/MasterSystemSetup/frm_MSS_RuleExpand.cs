using DA;
using DevExpress.XtraGrid.Columns;
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
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_RuleExpand : Form
    {
        private int customerID = 0;
        public frm_MSS_RuleExpand(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;

            this.InitData();
        }
        DataProcess<Object> DB = new DataProcess<Object>();
        DataProcess<Products> pData = new DataProcess<Products>();


        private void InitData()
        {
            //Load product
            this.grdProduct.DataSource = pData.Select(p => p.Discontinue == false && p.CustomerID==this.customerID).ToList();

            // Load Client group
            DataProcess<STCustomerClients_Result> cgData = new DataProcess<STCustomerClients_Result>();
            this.lkeClientGroup.Properties.DataSource = cgData.Executing("STCustomerClients @CustomerID={0}",this.customerID).ToList();
            this.lkeClientGroup.Properties.DisplayMember = "CustomerClientCode";
            this.lkeClientGroup.Properties.ValueMember = "CustomerClientID";

            // Load Client
            DataProcess<CustomerClients> cData = new DataProcess<CustomerClients>();
            this.lkeClients.Properties.DataSource = cData.Select(c=>c.CustomerID==this.customerID);
            this.lkeClients.Properties.DisplayMember = "CustomerClientCode";
            this.lkeClients.Properties.ValueMember = "CustomerClientID";

            // Load dispatching method
            DataProcess<CustomerDispatchMethod> dmData = new DataProcess<CustomerDispatchMethod>();
            this.lkeDispatchingRule.Properties.DataSource = dmData.Select();
            this.lkeDispatchingRule.Properties.DisplayMember = "CustomerDispatchMethod1";
            this.lkeDispatchingRule.Properties.ValueMember = "CustomerDispatchMethodID";

            // Load Rule
            DataProcess<STExCustomerClientRuleLoad_Result> dataRule = new DataProcess<STExCustomerClientRuleLoad_Result>();
            this.grdGroupProduct.DataSource = dataRule.Executing("STExCustomerClientRuleLoad").ToList(); ;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel File|*.xls||*.xlsx";
            //of.Filter = "Excel File|*.xls";
            of.Title = "WMS - Please select a Excel file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            // of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (of.ShowDialog() == DialogResult.OK)
            {
             //   txtEdit_FileBrowser.Text = of.FileName;

                DataTable v_TableSheet = this.GetTableExcelSheetNames(of.FileName);

               // lkUEdit_Sheet.Properties.DataSource = v_TableSheet;
               // lkUEdit_Sheet.Properties.DisplayMember = "Name";
               // lkUEdit_Sheet.Properties.ValueMember = "Name";

                string v_sheetName = "";
                try
                {

                    DataTable dt = ReadExcelFile(v_TableSheet.Rows[0][0].ToString(), of.FileName, 0);
                    while (dt.Columns.Count > 2)
                    {
                        dt.Columns.RemoveAt(dt.Columns.Count);
                    }


                    this.grdProduct.DataSource = ConvertExcelToListProduct(dt);
                    ColRemark.Visible = true;
                    //GridColumn colError = new GridColumn();
                    //    colError.Caption = "Error";
                    //colError.FieldName = "gridColumn2";
                    //colError.MinWidth = 25;
                    //colError.Name = "gridColumn2";
                    //colError.Visible = true;
                    //colError.VisibleIndex = 4;
                    //colError.Width = 94;

                    //this.grvProduct.Columns.Add(colError);
                }
                catch { }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*Kiem tra product 
             *  
             * 
             */
            //
            try
            {
                if (lkeDispatchingRule.EditValue == null)
                {
                    lkeDispatchingRule.ShowPopup();
                    lkeDispatchingRule.Focus();
                    return;
                }
                else if (lkeClientGroup.EditValue == null && lkeClients.EditValue == null)
                {
                    lkeClientGroup.ShowPopup();
                    lkeClientGroup.Focus();
                    return;
                }
                else
                {
                    //Kiem tra trung truoc khi add
                    DataProcess<ExCustomerClientRule> dataCheck = new DataProcess<ExCustomerClientRule>();
                    String SQL = "Select * from ExCustomerClientRule where ProductID in (";
                    String ListID = "";
                    String ListProduct = "";
                    String ListError = "";


                    for (int i = 0; i < grvProduct.DataRowCount; i++)
                    {
                        if (grvProduct.IsRowSelected(i))
                        {
                            string IDProduct = grvProduct.GetRowCellValue(i, grvProduct.Columns[0]).ToString();
                            ListID += IDProduct + ",";
                            ListProduct += grvProduct.GetRowCellValue(i, grvProduct.Columns[1]).ToString() + ","; ;
                            if (Convert.ToString(grvProduct.GetRowCellValue(i, grvProduct.Columns[3])).Equals("Sản phẩm không tồn tại"))
                            {
                                ListError += grvProduct.GetRowCellValue(i, grvProduct.Columns[1]).ToString() + ","; ;

                            }
                        }

                    }
                    if (ListError.Length > 2)
                    {
                        string msg = string.Format("ProductNumber  error: {0} Please Uncheck", ListError);
                        MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SQL = SQL + ListID.Substring(0, ListID.Length - 1) + ")" + " and CustomerID=" + customerID;
                    var dataWarning = dataCheck.Executing(SQL);
                    if (dataWarning != null && dataWarning.Count() > 0)
                    {

                        string msg = string.Format("ProductNumber exist in rule {0}", ListProduct);
                        DialogResult dia = MessageBox.Show(msg, "Infomation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dia == DialogResult.No) return;



                    }
                    // Load
                    for (int i = 0; i < grvProduct.DataRowCount; i++)
                    {
                        if (grvProduct.IsRowSelected(i))
                        {
                            Int32 IDProduct = Convert.ToInt32(grvProduct.GetRowCellValue(i, grvProduct.Columns[0]).ToString());
                            int result = 0;
                            if (dataWarning.Where(n => n.ProductID == IDProduct).Count() > 0)
                            {
                                result = DB.ExecuteNoQuery("STExCustomerClientRuleInsert @ExClientRuleID={8}, @CustomerID={0}, @ProductID={1},@ProductNumber={2} , @ProductName={3},@ClientID={4},@RuleID={5},@IsClientGroup={6},@CreatedBy={7} ", customerID, grvProduct.GetRowCellValue(i, grvProduct.Columns[0]), grvProduct.GetRowCellValue(i, grvProduct.Columns[1]), grvProduct.GetRowCellValue(i, grvProduct.Columns[2]), lkeClients.EditValue == null ? lkeClientGroup.EditValue : lkeClients.EditValue, lkeDispatchingRule.EditValue, lkeClients.EditValue == null ? true : false, AppSetting.CurrentUser.LoginName, 10);

                            }
                            else// them moi
                            {
                                result = DB.ExecuteNoQuery("STExCustomerClientRuleInsert @CustomerID={0}, @ProductID={1},@ProductNumber={2} , @ProductName={3},@ClientID={4},@RuleID={5},@IsClientGroup={6},@CreatedBy={7} ", customerID, grvProduct.GetRowCellValue(i, grvProduct.Columns[0]), grvProduct.GetRowCellValue(i, grvProduct.Columns[1]), grvProduct.GetRowCellValue(i, grvProduct.Columns[2]), lkeClients.EditValue == null ? lkeClientGroup.EditValue : lkeClients.EditValue, lkeDispatchingRule.EditValue, lkeClients.EditValue == null ? true : false, AppSetting.CurrentUser.LoginName);

                            }
                        }


                    }
                    // Load Rule
                    DataProcess<STExCustomerClientRuleLoad_Result> dataRule = new DataProcess<STExCustomerClientRuleLoad_Result>();
                    this.grdGroupProduct.DataSource = dataRule.Executing("STExCustomerClientRuleLoad").ToList(); ;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
          
        }

        public List<Products> ConvertExcelToListProduct(DataTable dtInput)
        {
            List<Products> objectList = new List<Products>();

            foreach (DataRow dr in dtInput.Rows)
            {
                string ProductNumber = dr[0].ToString();

                Products newObj = new Products();
                newObj.ProductNumber = ProductNumber;

                newObj.ProductName = dr[1].ToString();  // Beware of the possible conversion errors due to type mismatches
                var checkProduct = pData.Select().FirstOrDefault(n => n.ProductNumber == ProductNumber);
                newObj.ProductID = checkProduct == null ? 0 : checkProduct.ProductID;
                if(checkProduct==null)
                {
                    newObj.Remark ="Sản phẩm không tồn tại";

                }

                objectList.Add(newObj);
            }
            return objectList;
        }

        private DataTable ReadExcelFile(string sheetName, string path, Int32 numRow = 30)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = numRow == 0 ? String.Format("Select * from [{0}]", sheetName) : String.Format("Select top {0} * from [{1}]", numRow, sheetName);
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
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
            catch (Exception ex)
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

        private void grvGroupProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                STExCustomerClientRuleLoad_Result rule = this.grvGroupProduct.GetRow(this.grvGroupProduct.FocusedRowHandle) as STExCustomerClientRuleLoad_Result;
                if (rule == null) return;

                string msg = string.Format("Delete {0}: {1} \nAre you sure ?", "Rule ", rule.ProductNumber);
                DialogResult dia = MessageBox.Show(msg, "Infomation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.No) return;
                int result = DB.ExecuteNoQuery("Delete from ExCustomerClientRule where ExClientRuleID=" + rule.ExClientRuleID);
                if (result<1)
                {
                    //error
                    MessageBox.Show("Error!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Load Rule
                    DataProcess<STExCustomerClientRuleLoad_Result> dataRule = new DataProcess<STExCustomerClientRuleLoad_Result>();
                    this.grdGroupProduct.DataSource = dataRule.Executing("STExCustomerClientRuleLoad").ToList(); ;
                }
            }
        }

        private void lkeClientGroup_EditValueChanged(object sender, EventArgs e)
        {
            lkeClients.EditValue = null;
    
        }

        private void lkeClients_EditValueChanged(object sender, EventArgs e)
        {
        
           lkeClientGroup.EditValue = null;
         
        }
    }
}
