using System.Windows.Forms;
using Common.Controls;
using System;
using DA;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.IO;
using UI.Helper;


namespace UI.Management
{
    public partial class frm_M_DW_News : frmBaseForm
    {
        private BindingList<News> blNewsData = null;
        public frm_M_DW_News()
        {
            InitializeComponent();

            // Init data
            this.InitData();
        }

        private void InitData()
        {
            //buu----
            // Init New Type data
            this.InitNewTypeData();

            // Init News data
            DataProcess<News> newsDA = new DataProcess<News>();
            this.blNewsData = new BindingList<News>(newsDA.Select().ToList());
            this.dnv_NewsData.DataSource = this.blNewsData;
            this.dnv_NewsData.Position = this.blNewsData.Count;
        }

        /// <summary>
        /// Init New type data
        /// </summary>
        private void InitNewTypeData()
        {
            using (var newTypeDataSource = new System.Data.DataTable())
            {
                newTypeDataSource.Columns.Add("ID", typeof(int));
                newTypeDataSource.Columns.Add("Name");

                var newRow01 = newTypeDataSource.NewRow();
                newRow01["ID"] = 0;
                newRow01["Name"] = "Clients + Users";

                var newRow02 = newTypeDataSource.NewRow();
                newRow02["ID"] = 1;
                newRow02["Name"] = "Clients";

                var newRow03 = newTypeDataSource.NewRow();
                newRow03["ID"] = 2;
                newRow03["Name"] = "Users";

                var newRow04 = newTypeDataSource.NewRow();
                newRow04["ID"] = 3;
                newRow04["Name"] = "Workers";
                newTypeDataSource.Rows.Add(newRow01);
                newTypeDataSource.Rows.Add(newRow02);
                newTypeDataSource.Rows.Add(newRow03);
                newTypeDataSource.Rows.Add(newRow04);
                this.lke_M_Type.Properties.DataSource = newTypeDataSource;
                this.lke_M_Type.Properties.DisplayMember = "Name";
                this.lke_M_Type.Properties.ValueMember = "ID";
            }
        }

        private void dnv_NewsData_PositionChanged(object sender, EventArgs e)
        {
            if (this.dnv_NewsData.Position < 0) return;
            var currentNewObj = this.blNewsData[this.dnv_NewsData.Position];
            if (currentNewObj == null) return;

            this.txt_M_NewsID.Text = currentNewObj.CompanyNewID.ToString();
            this.d_M_CreateDate.DateTime = currentNewObj.NewDate == null ? DateTime.Now : (DateTime)currentNewObj.NewDate;
            if (string.IsNullOrEmpty(currentNewObj.CreatedBy))
            {
                this.txt_M_CreateByName.Text = AppSetting.CurrentUser.LoginName;
            }
            else
            {
                this.txt_M_CreateByName.Text = currentNewObj.CreatedBy;
            }

            if (currentNewObj.CreatedTime == null)
            {
                this.txt_M_CreateByTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            }
            else
            {
                this.txt_M_CreateByTime.Text = ((DateTime)currentNewObj.CreatedTime).ToString("dd/MM/yyyy hh:mm");
            }

            this.txt_M_HeadLine.Text = currentNewObj.NewHeadline;
            this.rtb_M_Descriptions.Text = currentNewObj.NewDescriptions;
            this.txt_M_ImageURL.Text = currentNewObj.ImageName;
            this.txt_M_NavigateURL.Text = currentNewObj.NavigateURL;
            this.lke_M_Type.EditValue = currentNewObj.NewType;

            if (!string.IsNullOrEmpty(this.txt_M_ImageURL.Text) && this.txt_M_ImageURL.Text.Length > 4)
            {
                if (this.txt_M_ImageURL.Text.Substring(0, 4).Trim().Equals("http"))
                {
                    this.btn_M_UploadFile.Enabled = false;
                }
            }

            if (currentNewObj.CompanyNewID > 0)
            {
                this.btn_M_Confirm.Enabled = false;
            }
            else
            {
                this.btn_M_Confirm.Enabled = true;
            }
        }

        private void btn_M_ViewAndUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_M_ImageURL.Text))
            {
                // Process upload file
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "TWMS- Please select picture file";
                openFile.RestoreDirectory = true;
                openFile.Filter = "Jpeg image file (*.jpg)|*.jpg";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    this.txt_M_ImageURL.Text = openFile.FileName;
                }
            }
            else
            {
                // Process view image
                Process.Start(this.txt_M_ImageURL.Text);
            }
        }

        private void btn_M_UploadFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_M_ImageURL.Text))
            {
                XtraMessageBox.Show("Please select a picture to post!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                File.Copy(this.txt_M_ImageURL.Text, @"\\Svscsvn-web\inetpub\wwwroot\images\NewsNo" + this.txt_M_NewsID.Text + ".jpg");
                this.txt_M_ImageURL.Text = "http://195.184.11.254/images/NewsNo" + this.txt_M_NewsID.Text + ".jpg";
            }
            catch (IOException Ioex)
            {
                throw Ioex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_M_Confirm_Click(object sender, EventArgs e)
        {
            var newObj = this.blNewsData[this.dnv_NewsData.Position];
            newObj.CreatedBy = AppSetting.CurrentUser.LoginName;
            newObj.CreatedTime = DateTime.Now;
            newObj.ImageName = this.txt_M_ImageURL.Text;
            newObj.NavigateURL = this.txt_M_NavigateURL.Text;
            newObj.NewDate = this.d_M_CreateDate.DateTime;
            newObj.NewDescriptions = this.rtb_M_Descriptions.Text;
            newObj.NewHeadline = this.txt_M_HeadLine.Text;
            newObj.NewsConfirmed = true;
            if (this.lke_M_Type.EditValue != null)
            {
                newObj.NewType = Convert.ToByte(this.lke_M_Type.EditValue);
            }

            DataProcess<News> newsDA = new DataProcess<News>();
            newsDA.Insert(newObj);
            this.txt_M_NewsID.Text = newObj.CompanyNewID.ToString();
            this.btn_M_Confirm.Enabled = false;
        }

        private void btn_M_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
