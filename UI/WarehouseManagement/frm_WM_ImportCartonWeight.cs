using Common.Controls;
using DA;
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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ImportCartonWeight : frmBaseForm
    {
        private string fileName = "";
        private int orderID = 0;
        private string orderType = "";
        private DataTable tbPallet = null;
        private DataTable tbDataSouce = null;
        private bool dataValid = true;
        public frm_WM_ImportCartonWeight(string orderType, int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.orderType = orderType;
            if (orderType.Equals("RO"))
            {
                this.LoadPalletsRO();
            }
            else
            {
                this.LoadPalletsDO();
            }
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excell File |*.xls;*.xlsx;*,xlsx";
            of.Title = "WMS - Please select a Excel file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                txtEdit_FileBrowser.Text = of.FileName;
                this.fileName = of.FileName;
                this.tbDataSouce = OpenFile(of.FileName);
                this.grdImport.DataSource = this.tbDataSouce;
            }
        }

        private void LoadPalletsRO()
        {
            string query = " select Pallets.PalletID from ReceivingOrders " +
                            " inner join ReceivingOrderDetails on ReceivingOrders.ReceivingOrderID = ReceivingOrderDetails.ReceivingOrderID " +
                            " inner join Pallets on Pallets.ReceivingOrderDetailID = ReceivingOrderDetails.ReceivingOrderDetailID " +
                            " where ReceivingOrders.ReceivingOrderID =" + this.orderID;
            this.tbPallet = FileProcess.LoadTable(query);
        }

        private void LoadPalletsDO()
        {
            string query = " SELECT  DispatchingOrderDetails.PalletID FROM  " +
                            " DispatchingProducts inner join DispatchingLocations on DispatchingProducts.DispatchingProductID=	DispatchingLocations.DispatchingProductID " +
                            " inner join DispatchingOrderDetails on DispatchingOrderDetails.DispatchingLocationID=DispatchingLocations.DispatchingLocationID " +
                            " where DispatchingProducts.DispatchingProductID =" + this.orderID;
            this.tbPallet = FileProcess.LoadTable(query);
        }
        public DataTable OpenFile(string fileName)
        {
            DataTable v_dtRet = null;
            string myexceldataquery = "select * from [Sheet1$] ";
            try
            {
                //create our connection strings 
                string connString = "";
                string extensionFile = Path.GetExtension(fileName);
                switch (extensionFile)
                {
                    case ".xls":
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx":
                        connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileName};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=2\"";
                        break;
                    default:
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
                        break;
                }
                //Detect current excel format
                OleDbConnection oledbconn = new OleDbConnection(connString);
                oledbconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
                da.Fill(ds, "tbImport");
                oledbconn.Close();
                v_dtRet = ds.Tables[0];
                v_dtRet.Columns.Add("IsValid", typeof(bool));
                int count = 0;
                int index = 0;
                foreach (DataRow rowIndex in v_dtRet.Rows)
                {
                    count = this.tbPallet.Select("PalletID=" + rowIndex["PalletID"]).Count();
                    if (count <= 0) v_dtRet.Rows[index]["IsValid"] = false;
                    else v_dtRet.Rows[index]["IsValid"] = true;
                    index++;
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
            return v_dtRet;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!this.dataValid)
            {
                MessageBox.Show("PalletID invalid, please re-checked it!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "";
            DataProcess<object> DA = new DataProcess<object>();

            if (orderType.Equals("RO"))
            {
                foreach (DataRow rowIndex in this.tbDataSouce.Rows)
                {
                    query = "INSERT INTO PalletCartons(PalletID,PalletWeight,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime," +
                        " PalletGrossWeight,CartonWeightPay,NetWeightSupplier) " +
                        " VALUES(" + rowIndex["PalletID"] + "," + rowIndex["Net"] + ",'" + AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy/MM/dd")
                        + "','" + AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "'," + rowIndex["Gross"] + "," +
                        rowIndex["NetPay"] + "," + rowIndex["SuppierNet"] + ")";
                    int result = DA.ExecuteNoQuery(query);
                }
            }
            else
            {
                DataProcess<DispatchingOrderDetails> dODetailDA = new DataProcess<DispatchingOrderDetails>();
                DispatchingOrderDetails doDetailInfo = null;
                foreach (DataRow rowIndex in this.tbDataSouce.Rows)
                {
                    int palletID = Convert.ToInt32(rowIndex["PalletID"]);
                    doDetailInfo = dODetailDA.Select(d => d.PalletID == palletID).FirstOrDefault();
                    query = "INSERT INTO DispatchingCartons(DispatchingOrderDetailID,CartonWeight,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime)" +
                        " VALUES(" + doDetailInfo.DispatchingOrderDetailID + "," + rowIndex["Net"] + ",'" + AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy/MM/dd")
                        + "','" + AppSetting.CurrentUser.LoginName + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    int result = DA.ExecuteNoQuery(query);
                }
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvImport_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            bool isValid = Convert.ToBoolean(this.grvImport.GetRowCellValue(e.RowHandle, "IsValid"));
            if (!isValid)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
                this.dataValid = false;
            }
            else
            {
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
            }

        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            this.tbDataSouce.Rows.RemoveAt(this.grvImport.FocusedRowHandle);
            int count = 0;
            int index = 0;
            this.dataValid = true;
            foreach (DataRow rowIndex in this.tbDataSouce.Rows)
            {
                count = this.tbPallet.Select("PalletID=" + rowIndex["PalletID"]).Count();
                if (count <= 0) this.tbDataSouce.Rows[index]["IsValid"] = false;
                else this.tbDataSouce.Rows[index]["IsValid"] = true;
                index++;
            }
            this.grvImport.RefreshData();
        }
    }
}
