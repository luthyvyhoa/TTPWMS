using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using UI.Helper;
using System.IO;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerBookingImportFiles : Common.Controls.frmBaseForm
    {
        enum eTypeCustomerEDI
        {
            eCustomerCommon = 1
            , eCustomerMetro = 1
        }

        eTypeCustomerEDI m_TypeCustomerEDI = eTypeCustomerEDI.eCustomerCommon;

        // khai báo 1 hàm delegate
        public delegate void GetEDI_Orders();
        // khai báo 1 kiểu hàm delegate
        public GetEDI_Orders MyGetEDI_Order;

        DataTable m_DataTableData = null;
        int m_CustomerMainID = 0;
        string m_userName = AppSetting.CurrentUser.LoginName;
        private int customerIDSelected = 0;
        private Guid bookingIDSelected;

        public frm_WM_CustomerBookingImportFiles(int customerID, Guid bookingID)
        {
            InitializeComponent();
            this.customerIDSelected = customerID;
            this.bookingIDSelected = bookingID;
            SetEvent();
        }
        void frm_WM_CustomerBookingImportFiles_Load(object sender, EventArgs e)
        {
            progressBarControl1.Visible = false;
            LoadData2searchLookUpEdit_CustomerID();
            this.Btn_Browser_Click(sender, e);
        }

        void SetEvent()
        {
            this.Load += frm_WM_CustomerBookingImportFiles_Load;

            btn_Browser.Click += Btn_Browser_Click;
            btn_ImportFile.Click += Btn_ImportFile_Click;
            btn_OpenExcelFile.Click += Btn_OpenExcelFile_Click;
            btn_Process.Click += btn_Process_Click;

            chkEdit_CustomerMain.CheckedChanged += ChkEdit_CustomerMain_CheckedChanged;
            searchLookUpEdit_CustomerID.EditValueChanged += SearchLookUpEdit_CustomerID_EditValueChanged;
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
                    memoEdit_DispatchingMethod.EditValue = v_Cus.CustomerDispatchMethod;

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
                    memoEdit_DispatchingMethod.EditValue = v_Cus.CustomerDispatchMethod;

                    this.m_CustomerMainID = Convert.ToInt32(v_Cus.CustomerMainID);
                }
                catch { }
            }

            if (string.IsNullOrEmpty(Convert.ToString(searchLookUpEdit_CustomerID.EditValue))
                || v_CustomerID == 280
                || v_CustomerID == 993
                || v_CustomerID == 848
                || v_CustomerID == 847
                || v_CustomerID == 850)
            {
                m_TypeCustomerEDI = eTypeCustomerEDI.eCustomerMetro;

                txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                this.txtEdit_Message.Text = "Customer metro !";
            }
            else
            {
                m_TypeCustomerEDI = eTypeCustomerEDI.eCustomerCommon;

                txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                this.txtEdit_Message.Text = "Customer common !";
            }
        }
        void ChkEdit_CustomerMain_CheckedChanged(object sender, EventArgs e)
        {
            LoadData2searchLookUpEdit_CustomerID();
            searchLookUpEdit_CustomerID.Focus();
            searchLookUpEdit_CustomerID.ShowPopup();
        }
        void Btn_Browser_Click(object sender, EventArgs e)
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
        void Btn_OpenExcelFile_Click(object sender, EventArgs e)
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
        void Btn_ImportFile_Click(object sender, EventArgs e)
        {
            DataProcess<object> process = new DataProcess<object>();
            process.Executing("Delete FROM PickingLists");
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

            #region Customer Common
            if (m_TypeCustomerEDI.Equals(eTypeCustomerEDI.eCustomerCommon))
            {
                if (ImportDataFromExcelCustomerCommon(v_PathFile))
                {
                    int v_CustomerID = 0;

                    try
                    {
                        v_CustomerID = Convert.ToInt32(searchLookUpEdit_CustomerID.EditValue);
                    }
                    catch { }

                    string v_StrSQL = " ";
                    v_StrSQL = " UPDATE PickingLists SET CustomerID = " + v_CustomerID + "";
                    v_StrSQL += " DELETE FROM PickingLists WHERE (PickingLists.[Lot_no] Is Null) OR (PickingLists.[Pick_date] Is NULL) OR (PickingLists.[Quantity] = 0) ";

                    DA.Warehouse.EDIOrdersDA v_DaEDI = new DA.Warehouse.EDIOrdersDA();
                    int v_Ret = v_DaEDI.ExecSQLString(v_StrSQL);

                    process.Executing("UPDATE PickingLists SET PickingLists.Truck_no = Replace(PickingLists.Truck_no,NCHAR(0x27),'') WHERE (((PickingLists.Truck_no) Like NCHAR(0x2A)+NCHAR(0x27)+NCHAR(0x2A)));");
                    process.Executing("UPDATE PickingLists SET PickingLists.lot_no = Replace(PickingLists.lot_no,NCHAR(0x27),'') WHERE (((PickingLists.lot_no) Like NCHAR(0x2A)+NCHAR(0x27)+NCHAR(0x2A)));");
                    this.txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                    this.txtEdit_Message.Text = "File imported succesful !";

                    LoadData2gridControlEDI();

                    this.btn_Process.Enabled = true;
                }
                else
                {
                    txtEdit_Message.ForeColor = System.Drawing.Color.Red;
                    this.txtEdit_Message.Text = "Error import file !";
                }
            }
            #endregion Customer Common

            #region Customer Metrol
            else if (m_TypeCustomerEDI.Equals(eTypeCustomerEDI.eCustomerMetro))
            {
                if (ImportDataFromExcelCustomerMetro(v_PathFile))
                {
                    string v_StrUpdate = " Update tmpEDIImportMetro Set X3=ART ";

                    DA.Warehouse.EDIOrdersDA v_DaUpdate = new DA.Warehouse.EDIOrdersDA();
                    int v_RetUpdate = v_DaUpdate.ExecSQLString(v_StrUpdate);

                    int v_RemainUpdate = v_DaUpdate.STEDI_ProductRemainUpdate(this.m_CustomerMainID);

                    this.txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                    this.txtEdit_Message.Text = "File imported succesful !";

                    LoadData2gridControlEDI();

                    this.btn_Process.Enabled = true;
                }
                else
                {
                    txtEdit_Message.ForeColor = System.Drawing.Color.Red;
                    this.txtEdit_Message.Text = "Error import file !";
                }
            }
            #endregion Customer Metrol
        }
        void btn_Process_Click(object sender, EventArgs e)
        {
            int v_CustomerID = 0;

            try
            {
                v_CustomerID = Convert.ToInt32(searchLookUpEdit_CustomerID.EditValue);
            }
            catch { }
            string v_PathFile = txtEdit_FileBrowser.Text;
            if (string.IsNullOrEmpty(v_PathFile))
            {
                XtraMessageBox.Show("You must choose to file that need process!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!v_PathFile.Substring(v_PathFile.Length - 4, 4).ToUpper().Equals(".xls".ToUpper()))
            {
                XtraMessageBox.Show("This file is not excel file format, select file again!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (v_CustomerID <= 0)
            {
                XtraMessageBox.Show("You must select Customer !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookUpEdit_CustomerID.Focus();
                searchLookUpEdit_CustomerID.ShowPopup();
                return;
            }

            #region Create Common
            progressBarControl1.Visible = true;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Minimum = 0;

            if (m_TypeCustomerEDI.Equals(eTypeCustomerEDI.eCustomerCommon))
            {
                try
                {
                    List<ST_WMS_EDI_PickingListsMain_Result> v_ListPicKing = (new DataProcess<ST_WMS_EDI_PickingListsMain_Result>()).Executing("ST_WMS_EDI_PickingListsMain").ToList();
                    progressBarControl1.Properties.Maximum = v_ListPicKing.Count;
                    DataProcess<EDI_Orders> v_DaEDIOrder = new DataProcess<EDI_Orders>();
                    foreach (var v_Item in v_ListPicKing)
                    {
                        string v_varProcessOrderNum = "";
                        int v_varCustomerID = 0;

                        v_varProcessOrderNum = v_Item.lot_no;
                        try
                        {
                            v_varCustomerID = Convert.ToInt32(v_Item.CustomerID);
                        }
                        catch { }

                        int indexSpecialChr = v_Item.Truck_no.IndexOf('\'');
                        if (indexSpecialChr > 0)
                        {
                            string convertStr = v_Item.Truck_no.Replace('\'', ' ');
                            v_Item.Truck_no = convertStr;
                        }

                        string v_StrSQL = "";
                        v_StrSQL = " Insert Into CustomerBookingDetails (";
                        v_StrSQL += " CustomerBookingID";
                        v_StrSQL += " ,ProductID ";
                        v_StrSQL += " ,ProductNumber ";
                        v_StrSQL += " ,ProductName ";
                        v_StrSQL += " ,Quantity";
                        v_StrSQL += " ,Status";
                        v_StrSQL += " , ProductRemark ";
                        v_StrSQL += " , ExpiryDate";
                        v_StrSQL += " , ProductionDate";
                        v_StrSQL += " , ReceivingOrderID";
                        v_StrSQL += " , Weights";
                        v_StrSQL += " , Units";
                        v_StrSQL += " , ClientCode";
                        v_StrSQL += " , CustomerRef";
                        v_StrSQL += " , CustomerLocationCode )";

                        v_StrSQL += " SELECT '" + this.bookingIDSelected + "'";
                        v_StrSQL += " ,0";
                        v_StrSQL += " ,PickingLists.[ART_NO]";
                        v_StrSQL += " ,LEFT(PickingLists.[DESCR],100)";
                        v_StrSQL += " , PickingLists.Quantity";
                        v_StrSQL += " , 0";
                        v_StrSQL += " , PickingLists.ProductRemark";
                        v_StrSQL += " , PickingLists.ExpiryDate";
                        v_StrSQL += " , PickingLists.ProductionDate";
                        v_StrSQL += " , PickingLists.ReceivingOrderID";
                        v_StrSQL += " , PickingLists.Weights";
                        v_StrSQL += " , PickingLists.Units";
                        v_StrSQL += " , PickingLists.ClientCode";
                        v_StrSQL += " , PickingLists.CustomerRef";
                        v_StrSQL += " , PickingLists.CustomerLocationCode";

                        v_StrSQL += " FROM PickingLists WHERE PickingLists.[lot_no]= N'" + v_varProcessOrderNum + "' ";
                        v_StrSQL += " AND PickingLists.[Truck_no]= N'" + v_Item.Truck_no + "' ";
                        v_StrSQL += " AND PickingLists.[UserCurrent] = N'" + m_userName + "'";

                        DataProcess<object> dataProcess = new DataProcess<object>();
                        int result = dataProcess.ExecuteNoQuery(v_StrSQL);

                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                    }
                    //
                    string v_StrSQL1 = "";
                    v_StrSQL1 = "Update CustomerBookingDetails Set Quantity= dbo.FT_CalculatorCartonFromWeightByProductID(Products.ProductID,CustomerBookingDetails.Weights)";
                    v_StrSQL1 += " From CustomerBookingDetails inner join CustomerBookings on CustomerBookingDetails.CustomerBookingID=CustomerBookings.BookingID inner join Customers on CustomerBookings.CustomerID=Customers.CustomerID";
                    v_StrSQL1 += " inner join Products on CustomerBookingDetails.ProductNumber = case when Products.ProductNumber Like '%~%' then SUBSTRING(right(Products.ProductNumber,len(Products.ProductNumber)-4), 1, CHARINDEX('~', right(Products.ProductNumber,len(Products.ProductNumber)-4), 1) - 1) else  right(Products.ProductNumber,len(Products.ProductNumber)-4) end ";
                    v_StrSQL1 += " Where Customers.CustomerMainID in(280) and CustomerBookings.Status='Processing' and CustomerBookingDetails.Quantity is null and CustomerBookings.BookingDate> getdate()-2 and len(Products.ProductNumber)>4";
                    DA.Warehouse.EDIOrdersDA v_DaUpdateEDI = new DA.Warehouse.EDIOrdersDA();
                    int v_RetUpdateEDI = v_DaUpdateEDI.ExecSQLString(v_StrSQL1);
                    //
                    this.txtEdit_Message.ForeColor = System.Drawing.Color.Blue;
                    this.txtEdit_Message.Text = "Update Customer Booking succesful !";
                    if (MessageBox.Show("Update Customer Booking succesful !", "", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        this.Close();
                    }

                    if (MyGetEDI_Order != null)
                    {
                        MyGetEDI_Order();
                    }

                    this.btn_Process.Enabled = false;

                }
                catch (Exception ex)
                {
                    txtEdit_Message.ForeColor = System.Drawing.Color.Red;
                    this.txtEdit_Message.Text = "Error Update Customer Booking !";
                }
            }
            #endregion Create Common
        }

        bool ImportDataFromExcelCustomerCommon(string excelFilePath)
        {
            string v_sheetName = "";

            try
            {
                v_sheetName = Convert.ToString(Convert.ToString(lkUEdit_Sheet.EditValue));
            }
            catch { }

            string ssqltable = "PickingLists";
            string ssqltable_Temp = "tempPickingLists";

            string v_StrSQLCreateTable = "";

            v_StrSQLCreateTable += " if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[" + ssqltable_Temp + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
            v_StrSQLCreateTable += " drop table[dbo].[" + ssqltable_Temp + "] ";

            v_StrSQLCreateTable += " CREATE TABLE[dbo].[" + ssqltable_Temp + "]( ";
            v_StrSQLCreateTable += " [Lot_no] [nvarchar](100) NULL, ";
            v_StrSQLCreateTable += " [Truck_no] [nvarchar](1000) NULL, ";
            v_StrSQLCreateTable += " [Pick_date] [smalldatetime] NULL, ";
            v_StrSQLCreateTable += " [ART_NO] [nvarchar](300) NULL, ";
            v_StrSQLCreateTable += " [DESCR] [nvarchar](300) NULL, ";
            v_StrSQLCreateTable += " [Quantity] [numeric](18, 3) NULL, ";
            v_StrSQLCreateTable += " [Pro_date] [smalldatetime] NULL, ";
            v_StrSQLCreateTable += " [Exp_date] [smalldatetime] NULL, ";
            v_StrSQLCreateTable += " [RO] [int] NULL, ";
            v_StrSQLCreateTable += " [Reference] [nvarchar](300) NULL, ";
            v_StrSQLCreateTable += " [Remark] [nvarchar](300) NULL, ";
            v_StrSQLCreateTable += " [Weights]  [numeric](18, 3) NULL, ";
            v_StrSQLCreateTable += " [Units]  [int] NULL,";
            v_StrSQLCreateTable += " [Client_Code] [nvarchar](50) NULL, ";
            v_StrSQLCreateTable += " [CustomerOrderNumber] [nvarchar](50) NULL,";
            v_StrSQLCreateTable += " [Client_Name] [nvarchar](300) NULL, ";
            v_StrSQLCreateTable += " [Address] [nvarchar](1000) NULL, ";
            v_StrSQLCreateTable += " [CustomerLocationCode] [varchar](50) NULL, ";
            v_StrSQLCreateTable += " [CustomerOrderNumber2] [nvarchar](50) NULL) ";

            DA.Warehouse.EDIOrdersDA v_DACreate = new DA.Warehouse.EDIOrdersDA();
            int v_RetCreate = v_DACreate.ExecSQLString(v_StrSQLCreateTable);

            string myexceldataquery = "select * from [" + v_sheetName.Trim() + "]";
            try
            {
                //create our connection strings 
                string connString = "";
                string extensionFile = Path.GetExtension(excelFilePath);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                        break;
                }
                OleDbConnection oledbconn = new OleDbConnection(connString);
                oledbconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, v_sheetName);
                oledbconn.Close();
                DataTable v_dtRet = ds.Tables[0];

                int resultInsert = FileProcess.InsertFile(v_dtRet, ssqltable_Temp);
                if (resultInsert < 0)
                {
                    MessageBox.Show("Có dữ liệu không hợp lệ trong file import, vui lòng kiểm tra và Import lại file", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string sclearsql = " delete from " + ssqltable + "  where UserCurrent = '" + m_userName + "' ";
                sclearsql += " INSERT INTO[dbo].[" + ssqltable + @"] ([Lot_no],[Truck_no],[Pick_date],[ART_NO],[DESCR],[Quantity],"
                               + " [UserCurrent],[ProductionDate],[ExpiryDate],[ReceivingOrderID],[CustomerRef],[Weights],[ProductRemark],"
                               + "[Units],[ClientCode],[CustomerOrderNumber],[Client_Name],[Address],[CustomerLocationCode],[CustomerOrderNumber2]) "
                               + " select [Lot_no],[Truck_no],[Pick_date],[ART_NO],[DESCR],[Quantity],'" + this.m_userName
                               + "' as [UserCurrent],[Pro_date],[Exp_date],[RO],[Reference],[Weights],[Remark],"
                               + "[Units],[Client_Code],[CustomerOrderNumber],[Client_Name],[Address],[CustomerLocationCode],[CustomerOrderNumber2] from " + ssqltable_Temp + "";
                sclearsql += " if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[" + ssqltable_Temp + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
                sclearsql += " drop table[dbo].[" + ssqltable_Temp + "] ";

                DA.Warehouse.EDIOrdersDA v_daFile = new DA.Warehouse.EDIOrdersDA();
                v_daFile.ExecSQLString(sclearsql);

                //dr.Close();
                //oledbconn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        bool ImportDataFromExcelCustomerMetro(string excelFilePath)
        {
            string connString = "";
            string extensionFile = Path.GetExtension(excelFilePath);
            switch (extensionFile)
            {
                case ".xls":
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                    break;
                case ".xlsx":
                    connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                    break;
                default:
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFilePath + ";Extended Properties=Excel 8.0;";
                    break;
            }
            string v_sheetName = "";

            try
            {
                v_sheetName = Convert.ToString(Convert.ToString(lkUEdit_Sheet.EditValue));
            }
            catch { }

            string ssqltable = "tmpEDIImportMetro";

            DataTable v_dt = this.GetSheetData(excelFilePath, v_sheetName, connString);

            string v_StrSQLCreateTable = "";
            //string v_StrSQLExcel = "SELECT ART,NAME,CAT ";
            string v_StrSQLExcel = "SELECT ART,PRODUCTNAME ";

            v_StrSQLCreateTable += " if exists(select * from dbo.sysobjects where id = object_id(N'[dbo].[tmpEDIImportMetro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
            v_StrSQLCreateTable += " drop table[dbo].[tmpEDIImportMetro] ";
            v_StrSQLCreateTable += @" CREATE TABLE tmpEDIImportMetro 
                                      (
                                        ART nvarchar(50), 
                                        PRODUCTNAME nvarchar(300) ";

            foreach (DataColumn v_Col in v_dt.Columns)
            {
                if (v_Col.ColumnName.ToUpper().Equals("ART".ToUpper())) continue;
                if (v_Col.ColumnName.ToUpper().Equals("PRODUCTNAME".ToUpper())) continue;
                string v_FirstOne = "";

                try
                {
                    v_FirstOne = v_Col.ColumnName.Substring(0, 1);
                }
                catch { }

                if (v_FirstOne.ToUpper().Equals("S".ToUpper()))
                {
                    v_StrSQLCreateTable += " , " + v_Col.ColumnName + " decimal(18,2) ";
                    v_StrSQLExcel += " , " + v_Col.ColumnName;
                }
            }

            v_StrSQLCreateTable += ", X3 nvarchar(50) )";
            v_StrSQLExcel += " FROM [" + v_sheetName.Trim() + "] ";

            DA.Warehouse.EDIOrdersDA v_DACreate = new DA.Warehouse.EDIOrdersDA();
            int v_RetCreate = v_DACreate.ExecSQLString(v_StrSQLCreateTable);

            try
            {
                OleDbConnection srcConn = new OleDbConnection(connString);
                srcConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(v_StrSQLExcel, srcConn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, v_sheetName);
                srcConn.Close();
                DataTable v_dtRet = ds.Tables[0];

                FileProcess.InsertFile(v_dtRet, ssqltable);

                return true;
            }
            catch (Exception ex)
            {
                return false;
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
        void LoadData2searchLookUpEdit_CustomerID()
        {
            searchLookUpEdit_CustomerID.Properties.DataSource = (new DA.DataProcess<STEDI_comboCustomerMainID_Result>()).Executing("STEDI_comboCustomerMainID @IsMain={0},@StoreID={1}", chkEdit_CustomerMain.Checked, AppSetting.StoreID);
            this.searchLookUpEdit_CustomerID.EditValue = this.customerIDSelected;
        }
        void LoadData2gridControlEDI()
        {
            if (m_TypeCustomerEDI.Equals(eTypeCustomerEDI.eCustomerCommon))
            {
                gridControlEDI.DataSource = DA.FileProcess.LoadTable("select * from PickingLists");
            }
            else if (m_TypeCustomerEDI.Equals(eTypeCustomerEDI.eCustomerMetro))
            {
                gridControlEDI.DataSource = DA.FileProcess.LoadTable("select * from tmpEDIImportMetro");
            }
            else
            {
                gridControlEDI.DataSource = null;
            }
        }
        void ConvertToEDIMetro(string i_ColumnName)
        {
            if (m_DataTableData == null) return;

            object v_SumColumnS000 = m_DataTableData.Compute("sum(" + i_ColumnName + ")", "tmpProductRemainID > 0 AND " + i_ColumnName + " > 0");
            decimal v_SumColumnS = 0;
            try
            {
                v_SumColumnS = Convert.ToDecimal(v_SumColumnS000);
            }
            catch { }

            if (v_SumColumnS > 0)
            {
                string v_StrCustomer = "";
                v_StrCustomer = " SELECT qryEDIProductRemains.tmpRemainQuantity , tmpEDIImportMetro.[" + i_ColumnName + @"], qryEDIProductRemains.tmpProductRemainNumber, qryEDIProductRemains.tmpCustomerID
                                    , qryEDIProductRemains.tmpProductRemainID, qryEDIProductRemains.tmpProductRemainName into #Data
                                  FROM tmpEDIImportMetro LEFT JOIN qryEDIProductRemains ON tmpEDIImportMetro.ART = qryEDIProductRemains.tmpProductRemainNumber ORDER BY qryEDIProductRemains.tmpProductRemainNumber";
                v_StrCustomer += " SELECT distinct[tmpCustomerID] FROM #Data GROUP BY [tmpCustomerID] HAVING ([tmpCustomerID] > 0) And (Sum(" + i_ColumnName + ") > 0) ORDER BY [tmpCustomerID]";

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

                        v_SQLEDI_Detail += " Insert Into CustomerBookingDetails (EDI_OrderID,ProductID,ProductNumber,ProductName,Quantity,Status) ";
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

    }
}
