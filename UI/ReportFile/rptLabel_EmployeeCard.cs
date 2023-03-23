using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Text;
using UI.Helper;

namespace UI.ReportFile
{
    public partial class rptLabel_EmployeeCard : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabel_EmployeeCard()
        {
            InitializeComponent();
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //string proDate = Convert.ToString(this.GetCurrentColumnValue("ProductionDate"));
            //string expDate =  Convert.ToString(this.GetCurrentColumnValue("UseByDate"));
            //var remark = this.GetCurrentColumnValue("CustomerRef");
            //StringBuilder stringCombine = new StringBuilder();
            //stringCombine.Append(string.IsNullOrEmpty(proDate) ? null : (Convert.ToDateTime(proDate).ToString("dd/MM/yyyy")));
            //stringCombine.Append("~");
            //stringCombine.Append(string.IsNullOrEmpty(expDate) ? null : (Convert.ToDateTime(expDate).ToString("dd/MM/yyyy")));
            //stringCombine.Append("~");
            //stringCombine.Append(remark);
            //this.xrLabel3.Text = stringCombine.ToString();
        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrLabel20.Text = "by :" + AppSetting.CurrentUser.LoginName;
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string emplyeeID;
            int employee;
            employee = (int)xrLabelEmployeeID.Value;
            emplyeeID = xrLabelEmployeeID.Text;
            if (employee < 1)
            {
                this.xrPictureBox1.Image = null;
            }
            else
            {
                string imagePath = AppSetting.PathEmployeePicture + emplyeeID + ".jpg";
                if (System.IO.File.Exists(imagePath))
                {
                    this.xrPictureBox1.Image = Image.FromFile(imagePath);
                    emplyeeID = "0";
                }
                else
                {
                    string imagePath0 = AppSetting.PathEmployeePicture + "0.jpg";
                    this.xrPictureBox1.Image = Image.FromFile(imagePath0);
                    emplyeeID = "0";
                }
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
