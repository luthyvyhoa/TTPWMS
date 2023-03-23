using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace UI.ReportFile
{
    public partial class rptReceivingProductQualityChecking : DevExpress.XtraReports.UI.XtraReport
    {
        public rptReceivingProductQualityChecking()
        {
            InitializeComponent();
            this.xrRichText1.Html = @"<html><head><title>MyTitle</title></head><body><p>Test</p></body></html>";
            this.xrRichText1.BeforePrint += xrRichText1_BeforePrint;
            this.xrPictureBox2.Image = UI.Properties.Resources.ImageCompany;
        }

        void xrRichText1_BeforePrint(object sender, CancelEventArgs e)
        {
            RichEditControl richEditControl1 = new RichEditControl();
            richEditControl1.RtfText = this.xrRichText1.Rtf;
            Document doc = richEditControl1.Document;
            DocumentRange range = richEditControl1.Document.Range;
            CharacterProperties cp = doc.BeginUpdateCharacters(range);
            cp.FontName = "Arial";
            cp.FontSize = 9;
            cp.ForeColor = Color.Black;
            cp.Underline = UnderlineType.DoubleWave;
            cp.UnderlineColor = Color.White;
            doc.EndUpdateCharacters(cp);
            this.xrRichText1.Rtf = richEditControl1.RtfText;
            richEditControl1.Dispose();
        }

        private void rptReceivingProductQualityChecking_BeforePrint(object sender, CancelEventArgs e)
        {
        }

    }
}
