using Common.Controls;
using DA;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CustomerBookingChart : frmBaseForm
    {
        private IList<STCustomerBookingViewByDate_Result> data;
        public frm_WM_CustomerBookingChart()
        {
            InitializeComponent();
        }

        private void DrawChart()
        {
            ChartSetting();
            chartCustomerBooking.DataSource = data;
        }

        private void ChartSetting()
        {
            // Create a series, and add it to the chart. 
            Series allSeries = new Series("All Series", ViewType.Line);
            chartCustomerBooking.Series.Add(allSeries);
            allSeries.View.Color = Color.Red;
            SideBySideBarSeriesLabel label1 = allSeries.Label as SideBySideBarSeriesLabel;
            if (label1 != null)
            {
                label1.Position = BarSeriesLabelPosition.Top;
            }

            Series RSeries = new Series("RO Series", ViewType.Line);
            chartCustomerBooking.Series.Add(RSeries);
            RSeries.View.Color = Color.Blue;
            SideBySideBarSeriesLabel label2 = allSeries.Label as SideBySideBarSeriesLabel;
            if (label2 != null)
            {
                label2.Position = BarSeriesLabelPosition.Top;
            }

            Series DSeries = new Series("DO Series", ViewType.Line);
            chartCustomerBooking.Series.Add(DSeries);
            DSeries.View.Color = Color.Green;
            SideBySideBarSeriesLabel label3 = allSeries.Label as SideBySideBarSeriesLabel;
            if (label3 != null)
            {
                label3.Position = BarSeriesLabelPosition.Top;
            }

            // Adjust the series data members. 
            allSeries.ArgumentDataMember = "BookingDate";
            allSeries.ValueDataMembers.AddRange(new string[] { "Weights" });

            RSeries.ArgumentDataMember = "BookingDate";
            RSeries.ValueDataMembers.AddRange(new string[] { "Weights_RO" });

            DSeries.ArgumentDataMember = "BookingDate";
            DSeries.ValueDataMembers.AddRange(new string[] { "Weights_DO" });

            // Access the view-type-specific options of the series. 
            //((LineSeriesView)allSeries.View).ColorEach = true;
            //((LineSeriesView)RSeries.View).ColorEach = true;
            //((LineSeriesView)DSeries.View).ColorEach = true;
        }

        public IList<STCustomerBookingViewByDate_Result> Data
        {
            get { return data; }
            set { data = value; }
        }

        private void frm_WM_CustomerBookingChart_Load(object sender, EventArgs e)
        {
            DrawChart();
        }
    }
}
