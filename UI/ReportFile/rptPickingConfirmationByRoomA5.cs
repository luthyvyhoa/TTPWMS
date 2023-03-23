using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptPickingConfirmationByRoomA5 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPickingConfirmationByRoomA5()
        {
            InitializeComponent();
            GroupHeaderBand RoomIDGroup = new DevExpress.XtraReports.UI.GroupHeaderBand();
            RoomIDGroup.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("RoomID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            RoomIDGroup.HeightF = 0F;
            RoomIDGroup.Level = 1;
            RoomIDGroup.Name = "RoomID";
            RoomIDGroup.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            RoomIDGroup});
            xrLabel1.Visible = true;
            this.xrLabel46.Text = AppSetting.CurrentUser.LoginName;
        }
        public rptPickingConfirmationByRoomA5(bool GroupDO)
        {
            InitializeComponent();

            xrLabel1.Visible = false;
            this.xrLabel46.Text = AppSetting.CurrentUser.LoginName;
        }

        private void xrLabel14_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = true;
            }

            else
            {
                lbl.Visible = false;
            }

        }

        private void xrLabel36_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = true;
            }

            else
            {
                lbl.Visible = false;
            }

        }

        private void xrLabel7_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel20_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel8_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel21_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel25_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel34_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel33_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }

        private void xrLabel35_BeforePrint(object sender, CancelEventArgs e)
        {
            var lbl = (XRLabel)sender;
            string productNo = Convert.ToString(this.GetCurrentColumnValue("Packages"));


            if (productNo == "KGR")
            {
                lbl.Visible = false;
            }

            else
            {
                lbl.Visible = true;
            }
        }
    }
}
