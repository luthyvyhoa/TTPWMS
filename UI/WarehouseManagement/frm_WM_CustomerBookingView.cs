using Common.Controls;
using DA;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerBookingView : frmBaseForm
    {
        private string userName = AppSetting.CurrentUser.LoginName;
        private frm_WM_CustomerBookingEntry frmCustomerBooking = null;
        public frm_WM_CustomerBookingView()
        {
            try
            {
                InitializeComponent();

                InitData();
            }
            catch { }
        }

        private void InitData()
        {
            try
            {
                initTimeData();
                getDataForlke();
                setDefaultValRadg();
                loadDataForGrid1();
                loadDataForGrid2();
                loadDataForGrid3();
                loadDataForGrid4();
            }
            catch { }
        }

        private void getDataForlke()
        {
            try
            {
                lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
            }
            catch { }
        }

        private void setDefaultValRadg()
        {
            try
            {
                radgFrameWarehouse.SelectedIndex = 0;
                radgFrameSelectCustomer.SelectedIndex = 0;
            }
            catch { }
        }

        private void initTimeData()
        {
            try
            {
                dtFromDate.EditValue = DateTime.Now;
                dtToDate.EditValue = DateTime.Now.AddDays(7);
                dtBookingDate.EditValue = DateTime.Now;
            }
            catch { }
        }

        private void loadDataForGrid4()
        {
            try
            {
                //If Form_frmInOutViewByDate.subfrmInOutView_Details.Visible = False Then Exit Sub
                //    CurrentDb.QueryDefs("qrysubfrmInOutViewByDate_Order").sql = "STInOutView_Details " & Me.TextDispatchingOrderID & ",1"
                //    Form_frmInOutViewByDate.subfrmInOutView_Details.Requery

                DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
                executeSTInOutView_Booking_DO_With3Params(fromDate, toDate, userName);
            }
            catch { }
        }

        private void executeSTInOutView_Booking_DO_With3Params(DateTime from, DateTime to, string userName)
        {
            try
            {
                // Execute store STInOutView_Booking_DO
                DataProcess<STInOutView_Booking_DO_Result> dp = new DataProcess<STInOutView_Booking_DO_Result>();
                IList<STInOutView_Booking_DO_Result> result = dp.Executing("STInOutView_Booking_DO @FromDate = {0}, @ToDate = {1}, @UserName = {2}", new DateTime(from.Year, from.Month, from.Day), new DateTime(to.Year, to.Month, to.Day), userName).ToList();
                grdCustomerBookingDetails_D.DataSource = result;
            }
            catch { }
        }

        private void executeSTInOutView_Booking_DO_With2Params(DateTime from, DateTime to)
        {
            try
            {
                // Execute store STInOutView_Booking_DO
                DataProcess<STInOutView_Booking_DO_Result> dp = new DataProcess<STInOutView_Booking_DO_Result>();
                IList<STInOutView_Booking_DO_Result> result = dp.Executing("STInOutView_Booking_DO @FromDate = {0}, @ToDate = {1}", new DateTime(from.Year, from.Month, from.Day), new DateTime(to.Year, to.Month, to.Day)).ToList();
                grdCustomerBookingDetails_D.DataSource = result;
            }
            catch { }
        }

        private void loadDataForGrid3()
        {
            try
            {
                DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                executeSTCustomerBookingDetailsWith1Param(bookingDate);
            }
            catch { }
        }

        private void executeSTCustomerBookingDetailsWith1Param(DateTime bookingDate)
        {
            try
            {
                // Execute store STCustomerBookingDetails
                DataProcess<STCustomerBookingDetails_Result> dp = new DataProcess<STCustomerBookingDetails_Result>();
                IList<STCustomerBookingDetails_Result> result = dp.Executing("STCustomerBookingDetails @BookingDate = {0}", bookingDate.ToString("yyyy-MM-dd")).ToList();
                grdCustomerBookingDetails.DataSource = result;
            }
            catch { }
        }

        private void executeSTCustomerBookingDetailsWith4Params(DateTime bookingDate, int timeSlotID, int customerMainID, string userName)
        {
            try
            {
                // Execute store STCustomerBookingDetails
                DataProcess<STCustomerBookingDetails_Result> dp = new DataProcess<STCustomerBookingDetails_Result>();

                IList<STCustomerBookingDetails_Result> result = dp.Executing("STCustomerBookingDetails @BookingDate = {0}, @TimeSlotID = {1}, @CustomerMainID = {2}, @UserName = {3}", bookingDate.ToString("yyyy-MM-dd"), timeSlotID, customerMainID, userName).ToList();
                grdCustomerBookingDetails.DataSource = result;
            }
            catch { }
        }

        private void executeSTCustomerBookingDetailsWith5Params(DateTime bookingDate, int timeSlotID, int customerMainID, string userName, string status)
        {
            try
            {
                // Execute store STCustomerBookingDetails
                DataProcess<STCustomerBookingDetails_Result> dp = new DataProcess<STCustomerBookingDetails_Result>();
                IList<STCustomerBookingDetails_Result> result = dp.Executing("STCustomerBookingDetails @BookingDate = {0}, @TimeSlotID = {1}, @CustomerMainID = {2}, @UserName = {3}, @Status = {4}", bookingDate.ToString("yyyy-MM-dd"), timeSlotID, customerMainID, userName, status).ToList();
                grdCustomerBookingDetails.DataSource = result;
            }
            catch { }
        }

        private void loadDataForGrid2()
        {
            try
            {
                executeSTCustomerBookingByTimeSlot();
            }
            catch { }
        }

        private void executeSTCustomerBookingByTimeSlot()
        {
            try
            {
                // Excute store STCustomerBookingByTimeSlot
                DataProcess<STCustomerBookingByTimeSlot_Result> dp = new DataProcess<STCustomerBookingByTimeSlot_Result>();
                DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                int warehouseID = Convert.ToInt32(radgFrameWarehouse.EditValue);
                IList<STCustomerBookingByTimeSlot_Result> result = dp.Executing("STCustomerBookingByTimeSlot @BookingDate = {0}, @WarehouseID = {1}", new DateTime(bookingDate.Year, bookingDate.Month, bookingDate.Day), warehouseID).ToList();
                grdCustomerBookingTimeSlots.DataSource = result;
            }
            catch { }
        }

        private void loadDataForGrid1()
        {
            try
            {
                //        Form_frmCustomerBookingView.TextBookingDate = Me.TextBookingDateFull
                //CurrentDb.QueryDefs("qryCustomerBookingTimeSlots").sql = "STCustomerBookingByTimeSlot '" & Format(Me.TextBookingDateFull, "yyyy-MM-dd") & "', " & Form_frmCustomerBookingView.FrameWarehouse
                //Form_frmCustomerBookingView.subfrmCustomerBookingTimeSlots.Requery
                //Form_frmCustomerBookingView.GraphTimeSlot.Requery
                //Form_frmCustomerBookingView.GraphTimeSlot.SetFocus

                executeSTCustomerBookingViewByDate();
            }
            catch { }
        }

        private void executeSTCustomerBookingViewByDate()
        {
            try
            {
                // Execute store STCustomerBookingViewByDate
                DataProcess<STCustomerBookingViewByDate_Result> dp = new DataProcess<STCustomerBookingViewByDate_Result>();
                DateTime fromDate = Convert.ToDateTime(dtFromDate.EditValue);
                DateTime toDate = Convert.ToDateTime(dtToDate.EditValue);
                int warehouseID = Convert.ToInt32(radgFrameWarehouse.EditValue);
                IList<STCustomerBookingViewByDate_Result> result = dp.Executing("STCustomerBookingViewByDate @FromDate = {0}, @ToDate = {1}", new DateTime(fromDate.Year, fromDate.Month, fromDate.Day), new DateTime(toDate.Year, toDate.Month, toDate.Day)).ToList();
                grdCustomerBookingViewByDate.DataSource = result;
            }
            catch { }
        }

        private void grvCustomerBookingViewByDate_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Weights")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.Column.FieldName == "Weights_RO")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == "Weights_DO")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.Column.FieldName == "Pallets")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.Column.FieldName == "Pallets_RO")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == "Pallets_DO")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                e.Appearance.Options.UseBorderColor = false;
                e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
                e.Handled = true;
            }
            catch { }
        }

        private void grvCustomerBookingTimeSlots_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Weights")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.Column.FieldName == "Weights_RO")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == "Weights_DO")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.Column.FieldName == "Pallets")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.Column.FieldName == "Pallets_RO")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == "Pallets_DO")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                if (e.Column.FieldName == "Cartons")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.Column.FieldName == "Cartons_RO")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
                if (e.Column.FieldName == "Cartons_DO")
                {
                    e.Appearance.ForeColor = Color.White;
                }
                e.Appearance.Options.UseBorderColor = false;
                e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
                e.Handled = true;
            }
            catch { }
        }

        private void grvCustomerBookingDetails_D_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            try
            {
                e.Appearance.ForeColor = Color.FromArgb(255, 255, 0);
                e.Appearance.Options.UseBorderColor = false;
                e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
                e.Handled = true;
            }
            catch { }
        }

        private void btnCommandToday_Click(object sender, EventArgs e)
        {
            try
            {
                dtBookingDate.EditValue = DateTime.Now;
                REQUERYFORM();
            }
            catch { }

        }

        private void REQUERYFORM()
        {
            try
            {
                //Dim varBookingDate As Date
                //varBookingDate = Me.TextBookingDate

                //Form_frmCustomerBookingView.subfrmCustomerBookingViewByDate.Requery
                //Form_frmCustomerBookingView.subfrmCustomerBookingViewByDate.Form.RecordsetClone.FindFirst ("[BookingDateFull]=#" & Format(varBookingDate, "yyyy-MM-dd") & "#")
                //Form_frmCustomerBookingView.subfrmCustomerBookingViewByDate.Form.Bookmark = Form_frmCustomerBookingView.subfrmCustomerBookingViewByDate.Form.RecordsetClone.Bookmark

                DateTime varBookingDate;
                varBookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
            }
            catch { }

        }

        private void btnCommandWeekPlanChart_Click(object sender, EventArgs e)
        {
            try
            {
                executeSTCustomerBookingViewByDate();
                IList<STCustomerBookingViewByDate_Result> list = (IList<STCustomerBookingViewByDate_Result>)grdCustomerBookingViewByDate.DataSource;
                frm_WM_CustomerBookingChart form = new frm_WM_CustomerBookingChart();
                form.Data = list;
                form.Show();
            }
            catch { }

        }

        private void radgFrameSelectCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var timeLotID = this.grvCustomerBookingTimeSlots.GetFocusedRowCellValue("TimeSlotID");
                switch (Convert.ToInt32(radgFrameSelectCustomer.EditValue))
                {
                    case 0:
                        {
                            customerIDLayoutControlItem.ContentVisible = false;
                            customerNameLayoutControlItem.ContentVisible = false;
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith1Param(bookingDate);
                            break;
                        }
                    case 1:
                        {
                            customerIDLayoutControlItem.ContentVisible = true;
                            customerNameLayoutControlItem.ContentVisible = true;
                            lkeCustomerID.Focus();
                            lkeCustomerID.ShowPopup();
                            break;
                        }
                    case 2:
                        {
                            customerIDLayoutControlItem.ContentVisible = false;
                            customerNameLayoutControlItem.ContentVisible = false;
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith4Params(bookingDate, (int)timeLotID, 0, userName);
                            executeSTInOutView_Booking_DO_With3Params(bookingDate, bookingDate, userName);
                            break;
                        }
                    case 3:
                        {
                            customerIDLayoutControlItem.ContentVisible = false;
                            customerNameLayoutControlItem.ContentVisible = false;
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith5Params(bookingDate, (int)timeLotID, 0, userName, "Processing");
                            break;
                        }
                    default:
                        {
                            customerIDLayoutControlItem.ContentVisible = false;
                            customerNameLayoutControlItem.ContentVisible = false;
                            break;
                        }
                }
            }
            catch { }
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                radgFrameSelectCustomer.EditValue = 1;
                int customerID = Convert.ToInt32(lkeCustomerID.EditValue);
                DataProcess<Customers> dp = new DataProcess<Customers>();
                Customers customer = dp.Select(c => c.CustomerID == customerID).FirstOrDefault();
                txtCustomerName.Text = customer.CustomerName;
                DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                int customerMainID = Convert.ToInt32(customer.CustomerMainID);
                var timeLotID = this.grvCustomerBookingTimeSlots.GetFocusedRowCellValue("TimeSlotID");
                executeSTCustomerBookingDetailsWith3Params(bookingDate, (int)timeLotID, customerMainID);
            }
            catch { }
        }

        private void executeSTCustomerBookingDetailsWith3Params(DateTime bookingDate, int timeSlotID, int customerMainID)
        {
            try
            {
                // Execute store STCustomerBookingDetails
                DataProcess<STCustomerBookingDetails_Result> dp = new DataProcess<STCustomerBookingDetails_Result>();
                IList<STCustomerBookingDetails_Result> result = dp.Executing("STCustomerBookingDetails @BookingDate = {0}, @TimeSlotID = {1}, @CustomerMainID = {2}", bookingDate, timeSlotID, customerMainID).ToList();
                grdCustomerBookingDetails.DataSource = result;
            }
            catch { }
        }

        private void radgFrameWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var timeLotId = this.grvCustomerBookingTimeSlots.GetFocusedRowCellValue("TimeSlotID");
                switch (Convert.ToInt32(radgFrameWarehouse.EditValue))
                {
                    case 0:
                        {
                            executeSTCustomerBookingByTimeSlot();
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith1Param(bookingDate);
                            break;
                        }
                    case 1:
                        {
                            executeSTCustomerBookingByTimeSlot();
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith4Params(bookingDate, (int)timeLotId, 0, userName);
                            break;
                        }
                    case 2:
                        {
                            executeSTCustomerBookingByTimeSlot();
                            DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                            executeSTCustomerBookingDetailsWith5Params(bookingDate, (int)timeLotId, 0, userName, "Processing");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                // FIXME: Update Graph
                chartCustomerBookingView.DataSource = grvCustomerBookingTimeSlots.DataSource;
            }
            catch { }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                //frm_WM_CustomerBookingEntry form = new frm_WM_CustomerBookingEntry();
                //form.IsAddNew = true;
                //form.Show();

                //    DoCmd.OpenForm "frmCustomerBookingEntry", acNormal
                //    DoCmd.GoToRecord , , acNewRec
                //'    MsgBox (Form_subfrmCustomerBookingViewByDate.TextBookingDateFull.value)
                //    Form_frmCustomerBookingEntry.TextBookingDate = Form_subfrmCustomerBookingViewByDate.TextBookingDateFull
                //nghia 13-5-2019
                frm_WM_CustomerBookingEntry frm = new frm_WM_CustomerBookingEntry();
                frm.Show();
                frm.WindowState = FormWindowState.Normal;
            }
            catch { }
        }
        private void rpi_btn_View_Click(object sender, EventArgs e)
        {
            //int handleIndex = grvCustomerBookingDetails_D.FocusedRowHandle;
            //int dispatchingOrderID = Convert.ToInt32(grvCustomerBookingDetails_D.GetRowCellValue(handleIndex, "DispatchingOrderID").ToString());
            //frm_WM_DispatchingOrders form = frm_WM_DispatchingOrders.Instance;
            //form.DispatchingOrderIDFind = dispatchingOrderID;
            //form.Show();
        }

        private void frm_WM_CustomerBookingView_Load(object sender, EventArgs e)
        {
            DrawChart();
            SetDataForWeekLabel();
        }

        private void SetDataForWeekLabel()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime valuatedDate = Convert.ToDateTime(dtFromDate.EditValue);
            Calendar cal = dfi.Calendar;
            int weekOfYear = cal.GetWeekOfYear(valuatedDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            lblWeek.Text = weekOfYear.ToString();
        }

        private void DrawChart()
        {
            chartCustomerBookingView.DataSource = grvCustomerBookingTimeSlots.DataSource;
            ChartSetting();
        }

        private void ChartSetting()
        {
            // Create a series, and add it to the chart. 
            Series allSeries = new Series("All Series", ViewType.Bar);
            chartCustomerBookingView.Series.Add(allSeries);
            allSeries.View.Color = Color.Red;

            Series RSeries = new Series("RO Series", ViewType.Bar);
            chartCustomerBookingView.Series.Add(RSeries);
            RSeries.View.Color = Color.Blue;

            Series DSeries = new Series("DO Series", ViewType.Bar);
            chartCustomerBookingView.Series.Add(DSeries);
            DSeries.View.Color = Color.Green;

            // Adjust the series data members. 
            allSeries.ArgumentDataMember = "TimeSlotID";
            allSeries.ValueDataMembers.AddRange(new string[] { "Weights" });

            RSeries.ArgumentDataMember = "TimeSlotID";
            RSeries.ValueDataMembers.AddRange(new string[] { "Weights_RO" });

            DSeries.ArgumentDataMember = "TimeSlotID";
            DSeries.ValueDataMembers.AddRange(new string[] { "Weights_DO" });

            // Access the view-type-specific options of the series. 
            //((BarSeriesView)allSeries.View).ColorEach = true;
            //((BarSeriesView)RSeries.View).ColorEach = true;
            //((BarSeriesView)DSeries.View).ColorEach = true;
            //allSeries.LegendPointOptions.Pattern = "{A}";
            //RSeries.LegendPointOptions.Pattern = "{A}";
            //DSeries.LegendPointOptions.Pattern = "{A}";
        }

        private void grvCustomerBookingDetails_D_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                string columnName = e.Column.Name;
                int handleIndex = grvCustomerBookingDetails_D.FocusedRowHandle;
                switch (e.Column.Name)
                {
                    case "buttonGridColumn":
                        int dispatchingOrderID = Convert.ToInt32(grvCustomerBookingDetails_D.GetRowCellValue(handleIndex, "DispatchingOrderID").ToString());
                        frm_WM_DispatchingOrders frmDispatching = frm_WM_DispatchingOrders.GetInstance(dispatchingOrderID);
                        if (frmDispatching.Visible)
                        {
                            frmDispatching.ReloadData();
                        }
                        frmDispatching.Show();
                        break;
                    case "BookingNumber1":
                        string bookingNumber = grvCustomerBookingDetails_D.GetRowCellValue(handleIndex, "BookingNumber").ToString();
                        if (this.frmCustomerBooking == null)
                        {
                            this.frmCustomerBooking = new frm_WM_CustomerBookingEntry();
                        }
                        this.frmCustomerBooking.BookingNumber = bookingNumber;
                        this.frmCustomerBooking.LoadBookings();
                        this.frmCustomerBooking.Show();
                        break;
                    default:
                        break;
                }
                if (columnName != "buttonGridColumn")
                {
                    return;
                }


                if (columnName != "BookingNumber1")
                {
                    return;
                }

            }
            catch
            {

            }
        }

        private void lblWeek_Click(object sender, EventArgs e)
        {
            DataProcess<STCustomerBookingCalendarWeek_Result> dp = new DataProcess<STCustomerBookingCalendarWeek_Result>();
            lkeWeek.Properties.DataSource = dp.Executing("STCustomerBookingCalendarWeek").ToList();
            lkeWeek.EditValue = Convert.ToByte(lblWeek.Text);
            lkeWeek.Focus();
            lkeWeek.ShowPopup();
        }

        private void lkeWeek_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object row = lkeWeek.GetSelectedDataRow();
                System.Reflection.PropertyInfo piFirstDate = row.GetType().GetProperty("FirstDate");
                DateTime firstDate = Convert.ToDateTime(piFirstDate.GetValue(row, null));
                System.Reflection.PropertyInfo piLastDate = row.GetType().GetProperty("LastDate");
                DateTime lastDate = Convert.ToDateTime(piLastDate.GetValue(row, null));
                dtFromDate.EditValue = firstDate;
                dtToDate.EditValue = lastDate;
            }
            catch { }
        }

        private void grvCustomerBookingViewByDate_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "NameDayOfWeek")
            {
                string value = Convert.ToString(currentView.GetRowCellValue(e.RowHandle, "NameDayOfWeek"));
                if (value == "SUN")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void grvCustomerBookingViewByDate_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Handled = true;
            e.Appearance.BackColor = Color.FromArgb(0, 128, 128);
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
        }

        private void grvCustomerBookingTimeSlots_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Handled = true;
            e.Appearance.BackColor = Color.FromArgb(0, 128, 128);
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
        }

        private void grvCustomerBookingDetails_D_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Handled = true;
            e.Appearance.BackColor = Color.FromArgb(0, 128, 128);
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
        }

        private void grvCustomerBookingTimeSlots_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var timeLotID = this.grvCustomerBookingTimeSlots.GetFocusedRowCellValue("TimeSlotID");
            DataProcess<STCustomerBookingDetails_Result> dp = new DataProcess<STCustomerBookingDetails_Result>();
            IList<STCustomerBookingDetails_Result> result = dp.Executing("STCustomerBookingDetails @BookingDate = {0}, @TimeSlotID = {1}", this.dtBookingDate.DateTime.ToString("yyyy-MM-dd"), timeLotID).ToList();
            grdCustomerBookingDetails.DataSource = result;
        }

        private void dtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            try
            {
                executeSTCustomerBookingViewByDate();
                dtBookingDate.EditValue = dtFromDate.EditValue;
            }
            catch { }
        }

        private void dtToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            try
            {
                executeSTCustomerBookingViewByDate();
            }
            catch { }
        }

        private void dtBookingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            try
            {
                executeSTCustomerBookingByTimeSlot();
                DateTime bookingDate = Convert.ToDateTime(dtBookingDate.EditValue);
                executeSTInOutView_Booking_DO_With2Params(bookingDate, bookingDate);
                // FIXME: Update graph
                chartCustomerBookingView.DataSource = grvCustomerBookingTimeSlots.DataSource;
                chartCustomerBookingView.Focus();
            }
            catch { }
        }
    }
}
