using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIImportMETRO : Common.Controls.frmBaseForm
    {
        DataTable m_DataTableData = null;
        string m_userName = UI.Helper.AppSetting.CurrentUser.LoginName;
        public frm_WM_EDIImportMETRO()
        {
            InitializeComponent();

            SetEvent();
        }
        void Frm_WM_EDIImportMETRO_Load(object sender, EventArgs e)
        {
            LoadData2gridControlEDIMetro();
        }
        void SetEvent()
        {
            this.Load += Frm_WM_EDIImportMETRO_Load;

            btn_Close.ItemClick += Btn_Close_ItemClick;
            btn_CreateEDI.ItemClick += Btn_CreateEDI_ItemClick;
        }

        void Btn_CreateEDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string v_StrSQLPic = "";

            v_StrSQLPic = " SELECT ";
            v_StrSQLPic += " qryEDIProductRemains.tmpRemainQuantity ";
            v_StrSQLPic += " , tmpEDIImportMetro.* ";
            v_StrSQLPic += " , qryEDIProductRemains.tmpProductRemainNumber ";
            v_StrSQLPic += " , qryEDIProductRemains.tmpCustomerID ";
            v_StrSQLPic += " , qryEDIProductRemains.tmpProductRemainID ";
            v_StrSQLPic += " , qryEDIProductRemains.tmpProductRemainName ";
            v_StrSQLPic += " FROM tmpEDIImportMetro LEFT JOIN qryEDIProductRemains ON tmpEDIImportMetro.ART = qryEDIProductRemains.tmpProductRemainNumber ";
            v_StrSQLPic += " ORDER BY qryEDIProductRemains.tmpProductRemainNumber ";

            m_DataTableData = DA.FileProcess.LoadTable(v_StrSQLPic);

            object v_CounttmpProductRemainID = m_DataTableData.Compute("count(tmpProductRemainID)", "tmpProductRemainID is NOT NULL");

            int v_Count = 0;

            try
            {
                v_Count = Convert.ToInt32(v_CounttmpProductRemainID);
            }
            catch { }

            if (v_Count <= 0)
            {
                XtraMessageBox.Show("Not record !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string v_StrSQL = "";
                v_StrSQL = " select cl.name as 'Column_Name', tp.name as 'Data_Type',cl.max_length ";
                v_StrSQL += " from sys.all_columns cl join sys.types tp on cl.user_type_id = tp.user_type_id ";
                v_StrSQL += " where cl.name like 'S%' AND object_id = (select top 1 object_id from sys.objects where type = 'u' and name = 'tmpEDIImportMETRO' ) ";

                DataTable v_DtColumn = DA.FileProcess.LoadTable(v_StrSQL);
                string v_ColumnName = "";

                foreach (DataRow v_Row in v_DtColumn.Rows)
                {
                    v_ColumnName = Convert.ToString(v_Row["Column_Name"]);
                    ConvertToEDIMetro(v_ColumnName);
                }
            }


            // 'Insert to EDI_Orders
            // Dim varStoreNumber As String
            // Dim varNumber As Integer


            // varNumber = 10
            // While varNumber < 140
            //     Call ConvertToEDI(varNumber)
            //     varNumber = varNumber + 1
            // Wend


            // DoCmd.Close
            // Form_subfrmEDIDetails.Requery
            // Form_frmEDIOrders.Requery
            // DoCmd.GoToRecord, , acLast
        }

        void Btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void ConvertToEDIMetro(string i_ColumnName)
        {
            if (m_DataTableData == null) return;

            object v_SumColumnS000 = m_DataTableData.Compute("sum("+ i_ColumnName + ")", "tmpProductRemainID > 0 AND "+ i_ColumnName + " > 0");
            decimal v_SumColumnS = 0;
            try
            {
                v_SumColumnS = Convert.ToDecimal(v_SumColumnS000);
            }
            catch { }

            if (v_SumColumnS > 0)
            {
                string v_StrCustomer = "";
                v_StrCustomer = " SELECT qryEDIProductRemains.tmpRemainQuantity , tmpEDIImportMetro.["+ i_ColumnName +"], qryEDIProductRemains.tmpProductRemainNumber, qryEDIProductRemains.tmpCustomerID";
                v_StrCustomer += " , qryEDIProductRemains.tmpProductRemainID, qryEDIProductRemains.tmpProductRemainName into #Data";
                v_StrCustomer += " FROM tmpEDIImportMetro LEFT JOIN qryEDIProductRemains ON tmpEDIImportMetro.ART = qryEDIProductRemains.tmpProductRemainNumber ORDER BY qryEDIProductRemains.tmpProductRemainNumber";
                v_StrCustomer += " SELECT distinct[tmpCustomerID] FROM #Data GROUP BY [tmpCustomerID] HAVING ([tmpCustomerID] > 0) And (Sum("+ i_ColumnName + ") > 0) ORDER BY [tmpCustomerID]";

                DataTable v_DtCustomer = DA.FileProcess.LoadTable(v_StrCustomer);

                DataProcess<EDI_Orders> v_DaEDIOrder = new DataProcess<EDI_Orders>();
                foreach (DataRow i_Item in v_DtCustomer.Rows)
                {
                    try
                    {
                        string v_varProcessOrderNum = i_ColumnName;
                        int v_varCustomerID = 0;
                        try
                        {
                            v_varCustomerID = Convert.ToInt32(i_Item["tmpCustomerID"]);
                        }
                        catch { }

                        EDI_Orders v_ObjEDIOrder = new EDI_Orders();

                        v_ObjEDIOrder.CustomerOrderNumber = i_ColumnName;
                        v_ObjEDIOrder.OrderDate = DateTime.Now;
                        v_ObjEDIOrder.CustomerReference = "";
                        v_ObjEDIOrder.CustomerID = v_varCustomerID;
                        v_ObjEDIOrder.OrderType = 3;
                        v_ObjEDIOrder.ProcessingStatus = 1;
                        v_ObjEDIOrder.FileUploaded = false;
                        v_ObjEDIOrder.TotalQuantity = 0;
                        v_ObjEDIOrder.CreatedBy = m_userName;
                        v_ObjEDIOrder.CreatedTime = DateTime.Now;
                        v_ObjEDIOrder.CustomerClientCode = i_ColumnName.Substring(1, i_ColumnName.Length - 1);

                        int v_ret = v_DaEDIOrder.Insert(v_ObjEDIOrder);

                        string v_SQLEDI_Detail = "";

                        v_SQLEDI_Detail = " SELECT qryEDIProductRemains.tmpRemainQuantity , tmpEDIImportMetro.[" + i_ColumnName + "], qryEDIProductRemains.tmpProductRemainNumber, qryEDIProductRemains.tmpCustomerID";
                        v_SQLEDI_Detail += " , qryEDIProductRemains.tmpProductRemainID, qryEDIProductRemains.tmpProductRemainName";
                        v_SQLEDI_Detail += " into #Data";
                        v_SQLEDI_Detail += " FROM tmpEDIImportMetro LEFT JOIN qryEDIProductRemains ON tmpEDIImportMetro.ART = qryEDIProductRemains.tmpProductRemainNumber";
                        v_SQLEDI_Detail += " ORDER BY qryEDIProductRemains.tmpProductRemainNumber ";

                        v_SQLEDI_Detail += " Insert Into EDI_OrderDetails (EDI_OrderID,ProductID,ProductNumber,ProductName,Quantity,Status) ";
                        v_SQLEDI_Detail += " SELECT  " + v_ObjEDIOrder.EDI_OrderID + ",[tmpProductRemainID],[tmpProductRemainNumber],[tmpProductRemainName], [" + i_ColumnName + "], 0";
                        v_SQLEDI_Detail += " FROM #Data WHERE [tmpCustomerID]= " + v_varCustomerID + " AND [" + i_ColumnName + "]>0";

                        DA.Warehouse.EDIOrdersDA v_DaInsertPic = new DA.Warehouse.EDIOrdersDA();
                        int v_RetInsertPic = v_DaInsertPic.ExecSQLString(v_SQLEDI_Detail);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Error processing file! Store No. " + i_ColumnName, "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void LoadData2gridControlEDIMetro()
        {
            gridControlEDIMetro.DataSource = DA.FileProcess.LoadTable("select * from tmpEDIImportMetro");
        }

        private void btn_CreateEDI_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_Close_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
