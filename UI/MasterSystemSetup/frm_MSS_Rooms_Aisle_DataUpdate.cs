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

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Rooms_Aisle_DataUpdate : Form
    {
        public frm_MSS_Rooms_Aisle_DataUpdate()
        {
            InitializeComponent();

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            string query = " SELECT DISTINCT Rooms.RoomID, rooms.TemperatureFrom, Rooms.TemperatureTo,Rooms.RoomProductStorage " +
                            " FROM Products INNER JOIN Customers ON PRoducts.CustomerID = Customers.CustomerID" +
                            " JOIN Rooms ON Products.TemperatureRequire" +
                            " BETWEEN Rooms.TemperatureFrom AND Rooms.TemperatureTo AND Rooms.StoreID = Customers.StoreID " +
                            " WHERE Customers.StoreID=" + AppSetting.StoreID;
            this.grdRooms.DataSource = FileProcess.LoadTable(query);
        }

        private void grvRooms_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            string roomID = Convert.ToString(this.grvRooms.GetFocusedRowCellValue("RoomID"));
            DataProcess<Aisles> aisleDA = new DataProcess<Aisles>();
            this.grdAisle.DataSource = aisleDA.Select(a => a.RoomID == roomID);
        }
    }
}
