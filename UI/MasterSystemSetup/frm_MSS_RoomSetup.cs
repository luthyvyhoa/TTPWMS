using DA;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_RoomSetup : Common.Controls.frmBaseForm
    {
        private DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
        private DataProcess<Aisles> _aislesDA;
        private List<Rooms> _listRooms;
        private List<Aisles> _listAisles;
        private BindingList<Locations> _listLocations;
        private string _roomID;

        public frm_MSS_RoomSetup()
        {
            InitializeComponent();
            this._aislesDA = new DataProcess<Aisles>();
            this._listRooms = new List<Rooms>();
            this._listAisles = new List<Aisles>();
        }

        private void frm_MSS_RoomSetup_Load(object sender, EventArgs e)
        {
            InitUsed();
            LoadRooms();
            LoadAisles();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvAisles.FocusedRowChanged += GrvAisles_FocusedRowChanged;
            this.grvLocations.CellValueChanged += GrvLocations_CellValueChanged;
            this.btnLabel.Click += BtnLabel_Click;
            this.btnViewRoom.Click += BtnViewRoom_Click;
            this.btnTopLow.Click += BtnTopLow_Click;
            this.btnRawData.Click += BtnRawData_Click;
            this.btnRackingUpdate.Click += BtnRackingUpdate_Click;
            this.btnUpdateLocal.Click += BtnUpdateLocal_Click;
            this.btnNewRoom.Click += BtnNewRoom_Click;
            this.btnDeleteRoom.Click += BtnDeleteRoom_Click;
            this.btnNewAisle.Click += BtnNewAisle_Click;
            this.btnSetupAisle.Click += BtnSetupAisle_Click;
            this.btnDeleteAisle.Click += BtnDeleteAisle_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void BtnLabel_Click(object sender, EventArgs e)
        {
            rptRoomLabel rpt = new rptRoomLabel();
            rpt.DataSource = FileProcess.LoadTable("SELECT DISTINCT SubString([LocationNumber],4,5) AS P, Locations.RoomID"
                                                   + " FROM Locations"
                                                   + " WHERE(((Locations.RoomID) = '" + this._roomID + "'))"
                                                   + " ORDER BY SubString([LocationNumber], 4, 5); ");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnViewRoom_Click(object sender, EventArgs e)
        {
            rptLocationByRoom rpt = new rptLocationByRoom();
            rpt.DataSource = FileProcess.LoadTable("STLocationByRoomReport @RoomID = '" + this._roomID + "'");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnTopLow_Click(object sender, EventArgs e)
        {
            this.grdLocationsReport.RepositoryItems.Clear();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_UsedReport = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            InitUsedReport(rpi_lke_UsedReport);
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_TopReport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpi_chk_LowReport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();


            this.grdLocationsReport.DataSource = FileProcess.LoadTable("SELECT Locations.RoomID, Locations.LocationNumber, Locations.Aisle, Locations.Bay, Locations.High, Locations.Deep, Locations.Used, Locations.Remark, Locations.LocationCode, Locations.[Top], Locations.Low"
                                                                       + " FROM Locations"
                                                                       + " WHERE(((Locations.[Top]) = 1) AND((Locations.Low) = 1))"
                                                                       + " ORDER BY Locations.RoomID, Locations.Aisle, Locations.Bay, Locations.High, Locations.Deep, Locations.Used; ");
            this.grvLocationsReport.Columns.Clear();
            this.grvLocationsReport.PopulateColumns();

            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Used")).ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Top")).ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Low")).ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grdLocationsReport.RepositoryItems.Add(rpi_lke_UsedReport);
            this.grdLocationsReport.RepositoryItems.Add(rpi_chk_TopReport);
            this.grdLocationsReport.RepositoryItems.Add(rpi_chk_LowReport);
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Used")).ColumnEdit = rpi_lke_UsedReport;
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Top")).ColumnEdit = rpi_chk_TopReport;
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Low")).ColumnEdit = rpi_chk_LowReport;

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Locations_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvLocationsReport.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void BtnRawData_Click(object sender, EventArgs e)
        {
            this.grdLocationsReport.RepositoryItems.Clear();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_UsedReport = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            InitUsedReport(rpi_lke_UsedReport);


            this.grdLocationsReport.DataSource = FileProcess.LoadTable("SELECT Locations.LocationID, Locations.LocationNumber, Locations.RoomID, Locations.Aisle, Locations.Bay, Locations.High, Locations.Deep, Locations.LocationCode, Locations.Used"
                                                                      + " FROM Locations"
                                                                      + " WHERE(((Locations.RoomID) = '" + this._roomID + "'))"
                                                                      + " ORDER BY Locations.RoomID, Locations.Aisle, Locations.Bay, Locations.High, Locations.Deep; ");
            this.grvLocationsReport.Columns.Clear();
            this.grvLocationsReport.PopulateColumns();

            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Used")).ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grdLocationsReport.RepositoryItems.Add(rpi_lke_UsedReport);
            this.grvLocationsReport.Columns.FirstOrDefault(c => c.FieldName.Equals("Used")).ColumnEdit = rpi_lke_UsedReport;

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Locations_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvLocationsReport.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void BtnRackingUpdate_Click(object sender, EventArgs e)
        {
            int result = this._aislesDA.ExecuteNoQuery("STRackingConfigurationUpdate");

            if (result != -2)
            {
                XtraMessageBox.Show("Update completed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnUpdateLocal_Click(object sender, EventArgs e)
        {
            LoadAisles();
        }

        private void BtnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (this._listAisles.Count <= 0)
            {
                int result = this._aislesDA.ExecuteNoQuery("DELETE FROM Rooms WHERE RoomID = '" + this._roomID + "'");
                if (result != -2)
                {
                    LoadRooms();
                    LoadAisles();

                    int storeID = AppSetting.CurrentUser.StoreID;
                    if (this.grvAisles.FocusedRowHandle >= 0)
                        storeID = Convert.ToInt32(this.grvAisles.GetFocusedRowCellValue("StoreID"));
                    this.roomDA.ExecuteNoQuery("STCreateRoomLocationDefualt @RoomID = {0}, @StoreID = {1}, @State = {2}", this._roomID, storeID, 1);
                }
            }
            else
            {
                XtraMessageBox.Show("Please delete all aisles of this room first !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewRoom_Click(object sender, EventArgs e)
        {
            frm_MSS_Dialog_NewRoom frm = new frm_MSS_Dialog_NewRoom();
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadRooms();
                LoadAisles();
            }
        }

        private async void BtnSetupAisle_Click(object sender, EventArgs e)
        {
            frm_MSS_Dialog_AisleSetup frm = new frm_MSS_Dialog_AisleSetup(this._listAisles.FirstOrDefault(a => a.Aisle == Convert.ToByte(this.grvAisles.GetFocusedRowCellValue("Aisle"))), this._roomID);
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadAisles();
            }
        }

        private void BtnNewAisle_Click(object sender, EventArgs e)
        {
            frm_MSS_Dialog_NewAisle frm = new frm_MSS_Dialog_NewAisle((byte)(this._listAisles.Count + 2), this._roomID);
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadAisles();
            }
        }

        private void BtnDeleteAisle_Click(object sender, EventArgs e)
        {
            string message = "";
            int result = -2;
            byte aisle = Convert.ToByte(this.grvAisles.GetFocusedRowCellValue("Aisle"));

            var source = FileProcess.LoadTable("SELECT Locations.LocationID FROM Locations"
                                               + " WHERE((Locations.RoomID = '" + this._roomID + "')"
                                               + " AND(Locations.Aisle = " + aisle + ")"
                                               + " AND((Locations.LocationID In(SELECT products.homelocation1 FROM products))"
                                               + " Or(Locations.LocationID In(SELECT products.homelocation2 FROM products))))");

            if (source.Rows.Count > 0)
            {
                XtraMessageBox.Show("ERROR: Cannot delete aisle! . There are " + source.Rows.Count + " home locations in this aisle.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            source = FileProcess.LoadTable("SELECT Locations.LocationID, Pallets.PalletID"
                                           + " FROM Locations INNER JOIN Pallets ON Locations.LocationID = Pallets.LocationID"
                                           + " WHERE(((Locations.RoomID) = 'A')"
                                           + " AND((Locations.Aisle) = 3))");

            if (source.Rows.Count > 0)
            {
                XtraMessageBox.Show("ERROR: Cannot delete aisle! . Some locations in this aisle are using in other tables.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this._listLocations.Count <= 0)
            {
                message = "WARNING : Are you sure you want to delete aisle " + aisle + " in room " + this._roomID + " ?";
            }
            else
            {
                message = "Are you sure you want to delete " + this._listLocations.Count + " locations of aisle " + aisle + " in room " + this._roomID + " ?";
            }

            if (XtraMessageBox.Show(message, "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this._listLocations.Count <= 0)
                {
                    result = this._aislesDA.ExecuteNoQuery("Delete From Locations Where RoomID = {0} And Aisle = {1}", this._roomID, aisle);
                }
            }

            if (result != -2)
            {
                result = this._aislesDA.ExecuteNoQuery("Delete From Aisles Where AisleRoomID = " + Convert.ToInt32(this.grvAisles.GetFocusedRowCellValue("AisleRoomID")));

                if (result != -2)
                {
                    LoadAisles();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrvLocations_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<Locations> locationDA = new DataProcess<Locations>();
            Locations row = this.grvLocations.GetFocusedRow() as Locations;

            int result = locationDA.Update(row);
        }

        private void GrvAisles_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadLocations();
        }

        private void RoomChanged(object sender, EventArgs e)
        {

            CheckButton button = sender as CheckButton;
            if (button.Checked)
            {
                ChangeRoom();
                this._roomID = button.Text;
                LoadCheckRoom();

                this.layoutControlGroup2.Text = "Aisles In Room " + this._roomID;
                this.layoutControlGroup3.Text = "Location In Room " + this._roomID;
                LoadAisles();
            }
        }
        private bool isFirstLoadCheck = false;
        private void LoadCheckRoom()
        {
            isFirstLoadCheck = true;
            ckFull.Checked = roomDA.Select(n => n.RoomID == this._roomID && n.StoreID == AppSetting.CurrentUser.StoreID).FirstOrDefault().isFullyLeased;
            ckVirtual.EditValue = roomDA.Select(n => n.RoomID == this._roomID && n.StoreID == AppSetting.CurrentUser.StoreID).FirstOrDefault().isVirtual;
            isFirstLoadCheck = false;
        }
        #region Load Data
        private void LoadRooms()
        {
            DataProcess<Rooms> roomDA = new DataProcess<Rooms>();
            this._listRooms = roomDA.Select(r => r.StoreID == AppSetting.StoreID).OrderBy(r => r.RoomID).ToList();
            int count = _listRooms.Count;
            int xLocation = 0;
            this.xtraScrollableControl1.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                CheckButton button = new CheckButton();
                button.Name = "btn" + _listRooms[i].RoomID + 1;
                button.Text = _listRooms[i].RoomID;
                if (i == 0)
                {
                    button.Checked = true;
                    this._roomID = _listRooms[i].RoomID;
                    this.layoutControlGroup2.Text = "Aisles In Room " + this._roomID;
                    this.layoutControlGroup3.Text = "Location In Room " + this._roomID;
                }
                button.Size = new Size(40, 40);
                button.Location = new Point(xLocation, 0);
                xLocation += 50;
                button.CheckedChanged += RoomChanged;
                this.xtraScrollableControl1.Controls.Add(button);
                LoadCheckRoom();
            }
        }

        private void LoadAisles()
        {
            this._listAisles = this._aislesDA.Select(a => a.RoomID.Equals(this._roomID) && a.StoreID == AppSetting.StoreID).OrderBy(a => a.Aisle).ToList();
            this.grdAisles.DataSource = this._listAisles;
            if (this._listAisles.Count > 0)
            {
                this.btnSetupAisle.Enabled = true;
                this.btnDeleteAisle.Enabled = true;
                this.btnDeleteRoom.Enabled = false;
                LoadLocations();
            }
            else
            {
                this.btnSetupAisle.Enabled = false;
                this.btnDeleteAisle.Enabled = false;
                this.btnDeleteRoom.Enabled = true;
            }
        }

        private void LoadLocations()
        {
            var dataSouce = AppSetting.LocationList.Where(l => l.RoomID.Equals(this._roomID) && l.Aisle == Convert.ToByte(this.grvAisles.GetFocusedRowCellValue("Aisle"))).OrderBy(l => l.LocationNumber).ToList();
            this._listLocations = new BindingList<Locations>(dataSouce.ToList());
            this.grdLocations.DataSource = this._listLocations;
        }

        private void InitUsed()
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("ID", typeof(short)));
            source.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["ID"] = 1;
            row1["Name"] = "On";

            DataRow row2 = source.NewRow();
            row2["ID"] = 0;
            row2["Name"] = "Off";

            source.Rows.Add(row1);
            source.Rows.Add(row2);

            this.rpi_lke_Used.DataSource = source;
            this.rpi_lke_Used.ValueMember = "ID";
            this.rpi_lke_Used.DisplayMember = "Name";
        }
        #endregion

        private void ChangeRoom()
        {
            foreach (CheckButton button in this.xtraScrollableControl1.Controls)
            {

                if (button.Text.Equals(this._roomID))
                {
                    button.Checked = false;
                }
            }
        }

        private void InitUsedReport(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkeUsedReport)
        {
            var source = new DataTable();

            source.Columns.Add(new DataColumn("ID", typeof(short)));
            source.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow row1 = source.NewRow();
            row1["ID"] = 1;
            row1["Name"] = "On";

            DataRow row2 = source.NewRow();
            row2["ID"] = 0;
            row2["Name"] = "Off";

            source.Rows.Add(row1);
            source.Rows.Add(row2);

            lkeUsedReport.DataSource = source;
            lkeUsedReport.ValueMember = "ID";
            lkeUsedReport.DisplayMember = "Name";
        }

        /// <summary>
        /// Change room is low or top
        /// position=0=> change to Low
        /// position=1=> change to Top
        /// </summary>
        /// <param name="position">int</param>
        private void ChangePosition(int position)
        {
            if (this.grvLocations.DataRowCount <= 0) return;
            Locations locationsSelected = null;
            switch (position)
            {
                // LOW
                case 0:
                    // Change =>LOW
                    for (int rowIndex = 0; rowIndex < this.grvLocations.DataRowCount; rowIndex++)
                    {
                        locationsSelected = (Locations)this.grvLocations.GetRow(rowIndex);
                        locationsSelected.Top = false;
                        locationsSelected.Low = true;
                        locationsSelected.VeryLowHigh = false;
                        locationsSelected = (Locations)this.grvLocations.GetRow(rowIndex);
                    }
                    break;

                // TOP
                case 1:
                    // Change => TOP
                    for (int rowIndex = 0; rowIndex < this.grvLocations.DataRowCount; rowIndex++)
                    {
                        locationsSelected = (Locations)this.grvLocations.GetRow(rowIndex);
                        locationsSelected.Top = true;
                        locationsSelected.Low = false;
                        locationsSelected.VeryLowHigh = false;
                        this._listLocations.Select(l => l = locationsSelected);
                    }
                    break;

                // EXTRA
                case 2:
                    // Change => TOP
                    for (int rowIndex = 0; rowIndex < this.grvLocations.DataRowCount; rowIndex++)
                    {
                        locationsSelected = (Locations)this.grvLocations.GetRow(rowIndex);
                        locationsSelected.Top = false;
                        locationsSelected.Low = false;
                        locationsSelected.VeryLowHigh = true;
                        this._listLocations.Select(l => l = locationsSelected);
                    }
                    break;
            }
            this.grvLocations.RefreshData();
        }

        private void btnTopAll_Click(object sender, EventArgs e)
        {
            this.ChangePosition(1);
        }

        private void btnLowAll_Click(object sender, EventArgs e)
        {
            this.ChangePosition(0);
        }

        private void btnExtraAll_Click(object sender, EventArgs e)
        {
            this.ChangePosition(2);
        }


        private void ckVirtual_Click(object sender, EventArgs e)
        {
            //    bool check = ckFull.Checked;
            // roomDA.ExecuteNoQuery("UPDATE dbo.Rooms SET isVirtual={0} WHERE RoomID={1} AND StoreID={2}", !check, this._roomID, AppSetting.CurrentUser.StoreID);
            //LoadCheckRoom();
        }

        private void ckFull_Click(object sender, EventArgs e)
        {
            //  bool check = ckFull.Checked;
            // int result= roomDA.ExecuteNoQuery("UPDATE dbo.Rooms SET isFullyLeased={0} WHERE RoomID={1} AND StoreID={2}", !check, this._roomID, AppSetting.CurrentUser.StoreID);
            //LoadCheckRoom();
        }

        private void ckVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if (!isFirstLoadCheck)
            {
                bool check = ckFull.Checked;
                roomDA.ExecuteNoQuery("UPDATE dbo.Rooms SET isVirtual={0} WHERE RoomID={1} AND StoreID={2}", !check, this._roomID, AppSetting.CurrentUser.StoreID);
                LoadCheckRoom();
            }
        }

        private void ckFull_CheckedChanged(object sender, EventArgs e)
        {
            if (!isFirstLoadCheck)
            {
                bool check = ckFull.Checked;
                int result = roomDA.ExecuteNoQuery("UPDATE dbo.Rooms SET isFullyLeased={0} WHERE RoomID={1} AND StoreID={2}", !check, this._roomID, AppSetting.CurrentUser.StoreID);
                LoadCheckRoom();
            }
        }

        private void btn_printBarcode_Click(object sender, EventArgs e)
        {
            rptRoomLabel rpt = new rptRoomLabel();

            string strLocationList = "";

            int count = 0;
            if (this.grvLocations.SelectedRowsCount == 0)
                return;
            foreach (var index in this.grvLocations.GetSelectedRows())
            {

                strLocationList += "'" + grvLocations.GetRowCellValue(index, "LocationNumber") + "'";

                if (count < this.grvLocations.SelectedRowsCount - 1)
                {
                    strLocationList += ",";

                }

                count++;
            }

            string sql = "SELECT DISTINCT SubString([LocationNumber],4,5) +N' ('+Cast(LocationCode as varchar(10))+N')' AS P, Locations.RoomID ,'AB' + SubString([LocationNumber],4,2) + SubString([LocationNumber],7,2)  AS Label , SubString([LocationNumber], 4, 5) as Numb "
                                                   + " FROM Locations"
                                                   + " WHERE(((Locations.RoomID) = '" + this._roomID + "')  and (Locations.LocationNumber in(" + strLocationList + ")))"
                                                   + " ORDER BY SubString([LocationNumber], 4, 5); ";

            rpt.DataSource = FileProcess.LoadTable(sql);

            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }
    }
}
