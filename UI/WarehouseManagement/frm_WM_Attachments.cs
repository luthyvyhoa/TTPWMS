using Common.Controls;
using Common.Process;
using DA;
using DA.Warehouse;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet;
using iText.Barcodes;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;
using UI.Helper;
using UI.Management;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Attachments : frmBaseForm
    {
        private static frm_WM_Attachments _instance;
        private AttachmentDA _attachmentDA;
        private string _orderNumber;
        private int _customerID;
        private string _appenfixNumber;
        private PictureEdit picViewer = new PictureEdit();
        private PdfViewer pdfViewer = new PdfViewer();
        private SpreadsheetControl excelViewer = new SpreadsheetControl();
        private RichEditControl wordViewer = new RichEditControl();
        private LabelControl lblWarning = new LabelControl();
        private string truckInOut = string.Empty;
        private int departmentCurrentUser = 0;
        private int positionCurrentUser = 0;
        private DataProcess<Employees> employeeDA = new DataProcess<Employees>();
        private string controlName = "picViewer";
        private static FTPData fTPData = new FTPData();
        public static frm_WM_Attachments Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frm_WM_Attachments();
                }
                return _instance;
            }
        }
        public static frm_WM_Attachments Instance2
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frm_WM_Attachments();
                }
                return _instance;
            }
        }

        public string TruckInout
        {
            get
            {
                return this.truckInOut;
            }
            set
            {
                this.truckInOut = value;
            }
        }
        public string OrderNumber
        {
            get
            {
                return _orderNumber;
            }

            set
            {
                _orderNumber = value;
                this.Text = "Attachments " + this._orderNumber;
                LoadAttachments();
            }
        }

        public int CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
            }
        }
        public String AppenfixNumber
        {
            get
            {
                return _appenfixNumber;
            }
            set
            {
                _appenfixNumber = value;
                LoadAttachments();
            }
        }

        private frm_WM_Attachments()
        {
            InitializeComponent();
            this.IsFixHeightScreen = false;
            this._attachmentDA = new AttachmentDA();
            this._orderNumber = "";
            this._customerID = 0;
            this._appenfixNumber = "";
            InitPrintStatus();
            SetEvents();
        }

        //private frm_WM_Attachments(string app)
        //{
        //    InitializeComponent();
        //    this.IsFixHeightScreen = false;
        //    this._attachmentDA = new AttachmentDA();
        //    this._orderNumber = "";
        //    this._customerID = 0;
        //    this._appenfixNumber = "";
        //    InitConfidentialLevel();
        //    InitPrintStatus();
        //    SetEvents();
        //}


        private void SetEvents()
        {
            // init controls
            this.picViewer.Dock = DockStyle.Fill;
            this.picViewer.AllowDrop = true;

            this.pdfViewer.Dock = DockStyle.Fill;
            this.pdfViewer.AllowDrop = true;

            this.excelViewer.Dock = DockStyle.Fill;
            this.excelViewer.AllowDrop = true;

            this.wordViewer.Dock = DockStyle.Fill;
            this.wordViewer.AllowDrop = true;

            this.lblWarning.Text = "App doesn't support to preview this file";
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.Location = new Point((this.pnlDocument.Width / 2) + this.pnlDocument.Location.X, this.pnlDocument.Height / 2 + this.pnlDocument.Location.X);

            this.btnAttach.Click += btnAttach_Click;
            this.btnBroweseFile.Click += btnBroweseFile_Click;
            this.btnViewAllAttachment.Click += btnViewAllAttachment_Click;
            this.btnEmailAttachment.Click += btnEmailAttachment_Click;

            this.picViewer.DragDrop += pnlDocument_DragDrop;
            this.pdfViewer.DragDrop += pnlDocument_DragDrop;
            this.excelViewer.DragDrop += pnlDocument_DragDrop;
            this.wordViewer.DragDrop += pnlDocument_DragDrop;

            this.pnlDocument.DragEnter += pnlDocument_DragEnter;
            this.picViewer.DragEnter += pnlDocument_DragEnter;
            this.pdfViewer.DragEnter += pnlDocument_DragEnter;
            this.excelViewer.DragEnter += pnlDocument_DragEnter;
            this.wordViewer.DragEnter += pnlDocument_DragEnter;

            this.excelViewer.DragOver += excelViewer_DragOver;
        }

        private void DownloadAttach()
        {
            int attachmentID = (int)this.tileViewAttachment.GetFocusedRowCellValue("AttachmentID");
            var listAttachments = this._attachmentDA.Select(a => a.OrderNumber == this.OrderNumber && a.AttachmentID == attachmentID).FirstOrDefault();
            if (listAttachments == null) return;
            string path = ConfigurationManager.AppSettings["PathCopyFile"];
            string source = ConfigurationManager.AppSettings["PathPasteFile"] + "\\" + listAttachments.AttachmentFile;
            string fileExtension = Path.GetExtension(source);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string orderNumberReplace;
            orderNumberReplace = this._orderNumber.Replace('/', '.');

            if (!Directory.Exists(path + "\\" + orderNumberReplace))
            {
                Directory.CreateDirectory(path + "\\" + orderNumberReplace);
            }

            string target = path + "\\" + orderNumberReplace + "\\" + orderNumberReplace + "_" + AppSetting.CurrentUser.LoginName + "_" + DateTime.Now.ToString("yyyy-MM-dd") + fileExtension;

            if (File.Exists(target))
            {
                File.Delete(target);
            }
            File.Copy(source, target);

            Process.Start(target);
        }

        void excelViewer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }



        #region Load Data
        private void LoadAttachments()
        {
            this.pnlDocument.Controls.Clear();
            this.txtFileBrower.Text = string.Empty;
            this.txtNewDescription.Text = string.Empty;
            DataProcess<STAttachmentView_Result> attachmentDA = new DataProcess<STAttachmentView_Result>();
            IEnumerable<STAttachmentView_Result> dataSource = null;
            if (!_appenfixNumber.Equals(""))
            {
                dataSource = attachmentDA.Executing("STAttachmentViewWithAppendix @OrderNumber = {0},@Appendix={1}", this._orderNumber, _appenfixNumber);
            }
            else if (string.IsNullOrEmpty(this.truckInOut))
            {
                dataSource = attachmentDA.Executing("STAttachmentView @OrderNumber = {0}", this._orderNumber);
            }
            else
            {
                dataSource = attachmentDA.Executing("STAttachmentView_TruckCont @ContInOutID={0},@VehicleType={1}", Convert.ToInt32(this.OrderNumber), this.truckInOut);
            }
            this.grcAttachmentCardView.DataSource = dataSource;
            if (dataSource != null && dataSource.Count() > 0)
            {
                this.tileViewAttachment.FocusedRowHandle = dataSource.Count() - 1;
            }

            // Load department ID of current user
            var depart = this.employeeDA.Select(u => u.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().Department;
            if (depart != null) this.departmentCurrentUser = Convert.ToInt32(depart);

            var posit = this.employeeDA.Select(u => u.EmployeeID == AppSetting.CurrentUser.EmployeeID).FirstOrDefault().PositionID;
            if (posit != 0) this.positionCurrentUser = Convert.ToInt32(posit);
        }

        private void InitPrintStatus()
        {
            var source = new DataTable();

            source.Columns.Add("ID", typeof(byte));
            source.Columns.Add("Name", typeof(string));

            var rowNo = source.NewRow();
            var rowRO = source.NewRow();
            var rowDO = source.NewRow();

            rowNo["ID"] = 0;
            rowNo["Name"] = "No";

            rowRO["ID"] = 1;
            rowRO["Name"] = "RO";

            rowDO["ID"] = 2;
            rowDO["Name"] = "DO";

            source.Rows.Add(rowNo);
            source.Rows.Add(rowRO);
            source.Rows.Add(rowDO);

            // this.rpi_lke_PrintStatus.DataSource = source;
            // this.rpi_lke_PrintStatus.ValueMember = "ID";
            // this.rpi_lke_PrintStatus.DisplayMember = "Name";
        }
        #endregion

        #region Events
        private void rpi_btn_ViewFile_Click(object sender, EventArgs e)
        {
            int confidentialLevel = Convert.ToInt32(this.tileViewAttachment.GetFocusedRowCellValue("ConfidentialLevel"));
            string user = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentUser"));
            this.pnlDocument.Controls.Clear();

            switch (confidentialLevel)
            {
                case 0:
                    ViewFile();
                    break;
                case 1:
                    if (user.Equals(AppSetting.CurrentUser.LoginName))
                    {
                        ViewFile();
                    }
                    else
                    {

                        var userOther = FileProcess.LoadTable("select top 1 EmployeeID from UserAccounts where LoginName='" + user + "'");
                        string employeeID = Convert.ToString(userOther.Rows[0]["EmployeeID"]);
                        if (string.IsNullOrEmpty(employeeID) || employeeID.ToUpper().Equals("AUTO"))
                        {
                            ViewFile();
                            return;
                        }
                        var depart = FileProcess.LoadTable("select top 1 Department from Employees where EmployeeID=" + userOther.Rows[0]["EmployeeID"]);
                        int departmentIDOrderUser = 0;
                        if (depart != null && depart.Rows.Count > 0) departmentIDOrderUser = Convert.ToInt32(depart.Rows[0]["Department"]);

                        // Is Manager
                        if (1 > 2)// sample condition to view file
                        {
                            ViewFile();
                        }
                        else if (((this.departmentCurrentUser == 5 || this.departmentCurrentUser == 7 || this.departmentCurrentUser == 8) && (this.departmentCurrentUser == departmentIDOrderUser))
                                    || this.positionCurrentUser == 24 || this.positionCurrentUser == 83 || UserPermission.CheckAdminDepartment(AppSetting.CurrentUser.LoginName))
                        {
                            ViewFile();
                        }
                        else
                        {
                            this.lblWarning.Text = "You are not allowed to view this file !";
                            this.pnlDocument.Controls.Add(this.lblWarning);
                        }
                    }
                    break;
                case 2:
                    if (user.Equals(AppSetting.CurrentUser.LoginName))
                    {
                        ViewFile();
                    }
                    else
                    {
                        this.lblWarning.Text = "You are not allowed to view this file !";
                        this.pnlDocument.Controls.Add(this.lblWarning);
                    }
                    break;
            }
        }

        private void DeleteAttachment()
        {
            string user = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentUser"));

            if (XtraMessageBox.Show("Are you sure to delete the this attachment ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DeleteFile())
                {
                    int id = Convert.ToInt32(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentID"));
                    int result = this._attachmentDA.STAttachmentUpdate(id, this._orderNumber, this.txtNewDescription.Text, this.txtFileBrower.Text, DateTime.Now, AppSetting.CurrentUser.LoginName, 2, 0, 0, "");
                    this.CheckOrderAttachmentHasExist();
                    if (result == -2)
                    {
                        XtraMessageBox.Show("Delete attachment failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadAttachments();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Can Not Delete File !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("You are not allowed to delete other people's file !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmailAttachment_Click(object sender, EventArgs e)
        {
            List<Attachments> listAttachments = this._attachmentDA.Select(a => a.OrderNumber == this.OrderNumber && a.IsDeleted == false).ToList();
            if (!this.ValidateSendEmail(listAttachments)) return;
        }

        private bool ValidateSendEmail(List<Attachments> listAttachments)
        {
            if (this.tileViewAttachment.RowCount <= 0)
            {
                return false;
            }

            string orderType = this._orderNumber.Substring(0, 2);
            string reportName = "Photo of " + this._orderNumber;

            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == this._customerID).FirstOrDefault();

            if (String.IsNullOrEmpty(customer.Email))
            {
                XtraMessageBox.Show("This Customer does not have e-mail address !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                string email = XtraInputBox.Show("Please check Email: ", "TPWMS", customer.Email);

                if (String.IsNullOrEmpty(email))
                {
                    XtraMessageBox.Show("Wrong email !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (XtraMessageBox.Show("Send report to the address: " + email, "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SendMail(email, "SCS VN - Auto Report - " + reportName, customer.CustomerName, listAttachments);
                    }
                }
            }
            return true;
        }

        private void btnViewAllAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tileViewAttachment.RowCount <= 0)
                {
                    return;
                }

                List<Attachments> listAttachments = this._attachmentDA.Select(a => a.OrderNumber == this.OrderNumber && a.IsDeleted == false && a.ConfidentialLevel == 0).ToList();

                string target = ConfigurationManager.AppSettings["PathCopyFile"] + "\\" + AppSetting.CurrentUser.LoginName;
                string source = ConfigurationManager.AppSettings["PathPasteFile"];
                string fileExtension = "";

                if (Directory.Exists(target))
                {
                    Directory.Delete(target, true);
                    Directory.CreateDirectory(target);
                }
                else
                {
                    Directory.CreateDirectory(target);
                }

                foreach (Attachments file in listAttachments)
                {
                    try
                    {
                        int dotPosition = file.AttachmentFile.LastIndexOf(".");
                        fileExtension = file.AttachmentFile.Substring(dotPosition);
                        File.Copy(source + "\\" + file.AttachmentFile, target + "\\" + this._orderNumber + "-Image" + file.AttachmentID + "-" + file.AttachmentDescription + fileExtension, true);
                    }
                    catch { }
                }

                Process.Start("C:\\WINDOWS\\explorer.exe", target);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBroweseFile_Click(object sender, EventArgs e)
        {
            //*.Doc; *.Xls; *.Xlsx; *.Pdf; *.JPG; *.PNG; *.JFIF; *.JPEG; *.TIFF; *.GIF; *.Rar; *.Tif; *.msg
            this.dlgBrowerFile.Filter = "All File|*.*|Access Project|*.ADP|Word Document|*.Docx|Excel 2003|*.Xls|Excel 2016|*.Xlsx|Pdf Document|*.Pdf|(*.JPG)|*.JPG|(*.PNG)|*.PNG|(*.JFIF)|*.JFIF|(*.JPEG)|*.JPEG|(*.TIFF)|*.TIFF|(*.GIF)|*.GIF|(*.RAR)|*.Rar|(*.TIF)|*.Tif|(*MSG)|*.msg";
            this.dlgBrowerFile.InitialDirectory = "D:\\";
            //this.dlgBrowerFile.

            if (this.dlgBrowerFile.ShowDialog() == DialogResult.OK)
            {
                this.txtFileBrower.Text = this.dlgBrowerFile.FileName;

                if (!String.IsNullOrEmpty(this.txtFileBrower.Text))
                {
                    this.CopyOpenFile(this.txtFileBrower.Text);
                    this.txtNewDescription.ReadOnly = false;
                    this.txtNewDescription.Focus();
                }

            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtFileBrower.Text))
            {
                XtraMessageBox.Show("Please choose file attachment", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (String.IsNullOrEmpty(this.txtNewDescription.Text))
                {
                    XtraMessageBox.Show("Please enter the Description !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNewDescription.Focus();
                }
                else
                {
                    this.SaveAttachFile(this.txtFileBrower.Text, this.txtNewDescription.Text);
                }
            }
        }

        public void SaveAttachFile(string filePath, string des)
        {

            int confidentialLevel = 1;
            if (AppSetting.CurrentEmployee.Department == 7)
                confidentialLevel = 1;
            else
                confidentialLevel = 0;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);

            string encryptedFile = GetMD5Hash(fileName + DateTime.Now) + fileExtension;
            if (CopyFile(filePath, encryptedFile))
            {
                int result;
                int fileSize = (int)(new FileInfo(filePath).Length / 1024);
                if (_appenfixNumber.Equals(""))
                {
                    result = this._attachmentDA.STAttachmentUpdate(0, this._orderNumber, des, encryptedFile, DateTime.Now, AppSetting.CurrentUser.LoginName, 3, fileSize, confidentialLevel, fileName);

                }
                else
                {
                    string strSQL = "STAttachmentInsert '" + this._orderNumber + "','" + des + "','" + encryptedFile + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" +
                        AppSetting.CurrentUser.LoginName + "','" + fileSize + "'," + confidentialLevel + ",'" + fileName + "','" + _appenfixNumber + "'";
                    result = this._attachmentDA.ExecuteNoQuery(strSQL);

                }
                this.UpdateStateAttachmentsOrder(1);

                if (result == -2)
                {
                    XtraMessageBox.Show("Add attachment failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtFileBrower.Text = "";
                    txtNewDescription.Text = "";
                    LoadAttachments();
                }
            }
        }

        private void UpdateStateAttachmentsOrder(int state)
        {
            if (string.IsNullOrEmpty(this._orderNumber)) return;
            if (!this._orderNumber.Contains('-')) return;
            var orderValus = this._orderNumber.Split('-');
            string orderType = orderValus[0];
            switch (orderType.ToUpper())
            {
                case "DO":
                    this.employeeDA.ExecuteNoQuery("Update DispatchingOrders set IsAttachment=" + state + " where DispatchingOrderNumber='" + this._orderNumber + "'");
                    break;
                case "RO":
                    this.employeeDA.ExecuteNoQuery("Update ReceivingOrders set IsAttachment=" + state + " where ReceivingOrderNumber='" + this._orderNumber + "'");
                    break;
                case "TW":
                    this.employeeDA.ExecuteNoQuery("Update Trips set IsAttachment=" + state + " where TripNumber='" + this._orderNumber + "'");
                    break;
                case "CL":
                    this.employeeDA.ExecuteNoQuery("Update CustomerInquiries set IsAttachment=" + state + " where CustomerInquiryNumber='" + this._orderNumber + "'");
                    break;
                case "QT":
                    this.employeeDA.ExecuteNoQuery("Update CustomerQuotations set IsAttachment=" + state + " where QuotationNumber='" + this._orderNumber + "'");
                    break;
                case "BL":
                    this.employeeDA.ExecuteNoQuery("Update Billings set IsAttachment=" + state + " where BillingID=" + this._orderNumber.Substring(3));
                    break;
                case "CB":
                    this.employeeDA.ExecuteNoQuery("Update CustomerServiceCosting set IsAttachment=" + state + " where CustomerServiceCostingID=" + this._orderNumber.Substring(3));
                    break;
                case "BF":
                    this.employeeDA.ExecuteNoQuery("Update BlastFreezers set IsAttachment=" + state + " where BlastFreezerID=" + this._orderNumber.Substring(3));
                    break;
                case "TB": //BigC Trip
                    this.employeeDA.ExecuteNoQuery("Update BigC_Trips set IsAttachment=" + state + " where TripNumber='" + this._orderNumber + "'");
                    break;
                case "QE": //QHSE_Equipments
                    this.employeeDA.ExecuteNoQuery("Update QHSE_Equipments set IsAttachment=" + state + " where QHSE_EquipmentNumber='" + this._orderNumber + "'");
                    break;
                default:
                    break;
            }
        }

        private void CheckOrderAttachmentHasExist()
        {
            var result = FileProcess.LoadTable("select count(*) Counts from Attachments where OrderNumber='" + this._orderNumber + "' and IsDeleted=0");
            int count = Convert.ToInt16(result.Rows[0]["Counts"]);
            if (count <= 0)
            {
                this.UpdateStateAttachmentsOrder(0);
            }
        }


        #endregion

        #region Others
        /// <summary>
        /// Copy file to folder in server
        /// </summary>
        /// <returns></returns>
        private bool CopyFile(string filePath, string encryptedFile)
        {
            string sourcePath = Path.GetDirectoryName(filePath);
            string targetPath = ConfigurationManager.AppSettings["PathPasteFile"];
            NetworkShare.DisconnectFromShare(targetPath, true); //Disconnect in case we are currently connected with our credentials;
            NetworkShare.ConnectToShare(targetPath, "userwms", "Tda@Knm*%!"); //Connect with the new credentials

            if (System.IO.Directory.Exists(sourcePath))
            {
                if (File.Exists(targetPath + "\\" + encryptedFile))
                {
                    XtraMessageBox.Show("There is already a file with the same name in location", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    try
                    {
                        File.Copy(filePath, targetPath + "\\" + encryptedFile);
                        NetworkShare.DisconnectFromShare(targetPath, false);
                    }
                    catch (Exception ex)
                    {
                        NetworkShare.DisconnectFromShare(targetPath, false);
                        XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                NetworkShare.DisconnectFromShare(targetPath, false);
                string errString = sourcePath + " doesn't exist!";
                XtraMessageBox.Show(errString, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Encrypt file name with MD5 algothrism
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string GetMD5Hash(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Delete Attachment file in server
        /// </summary>
        /// <returns></returns>
        private bool DeleteFile()
        {
            string path = ConfigurationManager.AppSettings["PathPasteFile"];
            string attachmentFile = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentFile"));
            NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
            NetworkShare.ConnectToShare(path, "userwms", "Tda@Knm*%!"); //Connect with the new credentials
            if (File.Exists(path + "\\" + attachmentFile))
            {
                try
                {
                    string extendFile = Path.GetExtension(attachmentFile);
                    if (extendFile.ToUpper().Equals(".PDF"))
                        this.pdfViewer.CloseDocument();

                    File.Delete(path + "\\" + attachmentFile);
                }
                catch (Exception ex)
                {
                    NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
                    return false;
                }
            }
            else
            {
                NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
                XtraMessageBox.Show("File do not exist !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// View attachment file
        /// </summary>
        private void ViewFile()
        {
            string path = ConfigurationManager.AppSettings["PathPasteFile"];
            string attachmentFile = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentFile"));
            NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
            NetworkShare.ConnectToShare(path, "userwms", "Tda@Knm*%!"); //Connect with the new credentials
            string pathFileName = path + "//" + attachmentFile;
            if (File.Exists(pathFileName))
            {
                CopyOpenFile(pathFileName);
                NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
            }
            else
            {
                NetworkShare.DisconnectFromShare(path, true); //Disconnect in case we are currently connected with our credentials;
                XtraMessageBox.Show("File do not exist !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Copy file from server to local and open
        /// </summary>
        /// <param name="filePath"></param>
        private void CopyOpenFile(string source)
        {
            try
            {
                string fileExtension = Path.GetExtension(source);
                string path = ConfigurationManager.AppSettings["PathCopyFile"];

                this.pnlDocument.Controls.Clear();
                switch (fileExtension.ToUpper())
                {
                    //Image
                    case ".JPG":
                    case ".PNG":
                    case ".JPEG":
                    case ".GIF":
                    case ".ICO":
                        this.picViewer.LoadAsync(source);
                        this.picViewer.Properties.SizeMode = PictureSizeMode.Zoom;
                        this.pnlDocument.Controls.Add(this.picViewer);
                        this.controlName = "picViewer";
                        break;

                    //PDF
                    case ".PDF":
                        this.pdfViewer.LoadDocument(source);
                        this.pnlDocument.Controls.Add(this.pdfViewer);
                        this.controlName = "pdfViewer";
                        break;

                    //Excel
                    case ".XLS":
                    case ".XLSX":
                        this.excelViewer.LoadDocument(source);
                        this.pnlDocument.Controls.Add(this.excelViewer);
                        this.controlName = "excelViewer";
                        this.excelViewer.ReadOnly = true;
                        break;

                    //Word
                    case ".DOC":
                    case ".DOCX":
                        this.wordViewer.LoadDocument(source);
                        this.pnlDocument.Controls.Add(this.wordViewer);
                        this.controlName = "wordViewer";
                        this.wordViewer.ReadOnly = true;
                        break;

                    // Default is open file with special application install on windows
                    default:
                        this.lblWarning.Text = "App doesn't support to preview this file";
                        this.pnlDocument.Controls.Add(this.lblWarning);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Send attachment to customers
        /// </summary>
        public void SendMail(string toEmail, string subject, string customerName, List<Attachments> listAttachments)
        {
            try
            {
                string target = ConfigurationManager.AppSettings["PathCopyFile"];
                string source = ConfigurationManager.AppSettings["PathPasteFile"];
                string fileExtension = "";
                string boby = "Please find the attached report";

                if (Directory.Exists(target + "\\" + AppSetting.CurrentUser.LoginName))
                {
                    Directory.Delete(target + "\\" + AppSetting.CurrentUser.LoginName);
                    Directory.CreateDirectory(target + "\\" + AppSetting.CurrentUser.LoginName);
                }
                else
                {
                    Directory.CreateDirectory(target + "\\" + AppSetting.CurrentUser.LoginName);
                }

                IList<string> attachPathFile = new List<string>();
                foreach (Attachments file in listAttachments)
                {
                    int dotPosition = file.AttachmentFile.LastIndexOf(".");
                    fileExtension = file.AttachmentFile.Substring(dotPosition);
                    string sourceFileName = source + "\\" + file.AttachmentFile;
                    string desFileName = target + "\\" + this._orderNumber + "-Image" + file.AttachmentID + "-" + file.AttachmentDescription + fileExtension;
                    //desFileName=C:\local - data\DO - 1934171 - Image831991 - Attach by Scan Machine..pdf
                    if (!File.Exists(desFileName))
                    {
                        File.Copy(sourceFileName, desFileName);
                    }
                    attachPathFile.Add(desFileName);
                }

                Common.Process.DataTransfer.SendMail(toEmail, subject, boby, attachPathFile.ToArray());

                XtraMessageBox.Show("Email sent successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Send failed!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_WM_Attachments_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.truckInOut = string.Empty;
            this.Hide();
            e.Cancel = true;
        }

        private void SendEmail()
        {
            string attachmentFile = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentFile"));
            List<Attachments> listAttachments = this._attachmentDA.Select(a => a.OrderNumber == this.OrderNumber && a.IsDeleted == false && a.AttachmentFile == attachmentFile).ToList();
            if (!this.ValidateSendEmail(listAttachments)) return;
        }

        void pnlDocument_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void pnlDocument_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // for this program, we allow a file to be dropped from Explorer
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string filePath in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        this.SaveAttachFile(filePath, fileName);
                    }
                }

                // or this tells us if it is an Outlook attachment drop
                else if (e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    e.Effect = DragDropEffects.Copy;
                    //
                    // the first step here is to get the filename
                    // of the attachment and
                    // build a full-path name so we can store it
                    // in the temporary folder
                    //

                    // set up to obtain the FileGroupDescriptor
                    // and extract the file name
                    Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                    byte[] fileGroupDescriptor = new byte[512];
                    theStream.Read(fileGroupDescriptor, 0, 512);
                    // used to build the filename from the FileGroupDescriptor block
                    StringBuilder fileName = new StringBuilder("");
                    // this trick gets the filename of the passed attached file
                    for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                    { fileName.Append(Convert.ToChar(fileGroupDescriptor[i])); }
                    theStream.Close();
                    string path = Path.GetTempPath();
                    // put the zip file into the temp directory
                    string theFile = path + fileName.ToString();
                    // create the full-path name

                    //
                    // Second step:  we have the file name.
                    // Now we need to get the actual raw
                    // data for the attached file and copy it to disk so we work on it.
                    //

                    // get the actual raw file into memory
                    MemoryStream ms = (MemoryStream)e.Data.GetData(
                        "FileContents", true);
                    // allocate enough bytes to hold the raw data
                    byte[] fileBytes = new byte[ms.Length];
                    // set starting position at first byte and read in the raw data
                    ms.Position = 0;
                    ms.Read(fileBytes, 0, (int)ms.Length);
                    // create a file and save the raw zip file to it
                    FileStream fs = new FileStream(theFile, FileMode.Create);
                    fs.Write(fileBytes, 0, (int)fileBytes.Length);

                    fs.Close();  // close the file

                    FileInfo tempFile = new FileInfo(theFile);
                    this.SaveAttachFile(theFile, tempFile.Name);

                    // always good to make sure we actually created the file
                    if (tempFile.Exists == true)
                    {
                        // for now, just delete what we created
                        tempFile.Delete();
                    }
                    else
                    { Trace.WriteLine("File was not created!"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File was not created!");
            }
        }

        private void EditAttach()
        {
            string user = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentUser"));
            if (!user.Equals(AppSetting.CurrentUser.LoginName)) return;
            switch (this.controlName)
            {
                case "picViewer":
                case "pdfViewer":
                    break;
                case "excelViewer":
                    this.excelViewer.ReadOnly = false;
                    break;
                case "wordViewer":
                    this.wordViewer.ReadOnly = false;
                    break;
                default:
                    break;
            }
        }

        public void import_barcode(string SRC, string DEST)
        {
            using (var document = new PdfDocument(new PdfReader(SRC), new PdfWriter(DEST)))
            {
                iText.Kernel.Pdf.Canvas.PdfCanvas canvas = new PdfCanvas(document.GetFirstPage());
                Barcode128 code128 = new Barcode128(document);
                string barcode = this._orderNumber.Substring(0, 2) + Convert.ToInt32(this._orderNumber.Substring(3)).ToString("D9");
                code128.SetCode(barcode);
                code128.SetCodeType(Barcode128.CODE128);
                PdfFormXObject xObject =
                code128.CreateFormXObject(ColorConstants.BLACK, ColorConstants.BLACK, document);
                float x = 450;
                float y = 750;
                float w = xObject.GetWidth();
                float h = xObject.GetHeight();
                canvas.SaveState();
                canvas.SetFillColor(ColorConstants.LIGHT_GRAY);
                canvas.Rectangle(x, y, w + 5, h + 5);
                canvas.Fill();
                canvas.RestoreState();
                canvas.AddXObject(xObject, 450, 750);
            }
        }

        private void checkEdit1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void textOrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            this._orderNumber = this.textOrderNumber.Text;
            LoadAttachments();

        }

        private void tileView1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            string caption = e.Item.Name;
            int attachmentIDSelected = (int)this.tileViewAttachment.GetFocusedRowCellValue("AttachmentID");
            switch (caption)
            {
                case "cbEmail":
                    SendEmail();
                    break;
                case "cbDelete":
                    DeleteAttachment();
                    break;
                case "cbDownload":
                    DownloadAttach();
                    break;
                case "cbConfidential":
                    //0=>"Public"
                    //1=>"Confidential"
                    //2=>"Private"
                    if (attachmentIDSelected < 0) return;
                    string user = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentUser"));
                    if (!user.Equals(AppSetting.CurrentUser.LoginName))
                    {
                        MessageBox.Show("You can not change this value", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var currentConfidential = Convert.ToInt32(this.tileViewAttachment.GetFocusedRowCellValue("ConfidentialLevel"));
                    int confidentialUpdate = 0;
                    switch (currentConfidential)
                    {
                        case 0: confidentialUpdate = 1; break;
                        case 1: confidentialUpdate = 2; break;
                        case 2: confidentialUpdate = 0; break;
                        default:
                            confidentialUpdate = 0;
                            break;
                    }

                    int result = this._attachmentDA.ExecuteNoQuery("Update Attachments set ConfidentialLevel = " + confidentialUpdate + " where AttachmentID= " + attachmentIDSelected);
                    if (result > 0) this.tileViewAttachment.SetFocusedRowCellValue("ConfidentialLevel", confidentialUpdate);
                    this.tileViewAttachment.RefreshData();
                    break;
                case "btnEdit":

                    var currentDes = Convert.ToString(this.tileViewAttachment.GetFocusedRowCellValue("AttachmentDescription"));
                    var inputResult = XtraInputBox.Show("Enter a new description", "Attachment Description", currentDes);
                    if (attachmentIDSelected < 0) return;
                    var attachmentUpdate = this._attachmentDA.Select(a => a.AttachmentID == attachmentIDSelected).FirstOrDefault();
                    attachmentUpdate.AttachmentDescription = inputResult;
                    int resultUpdate = this._attachmentDA.Update(attachmentUpdate);
                    if (resultUpdate > 0) this.tileViewAttachment.SetFocusedRowCellValue("AttachmentDescription", inputResult);
                    this.tileViewAttachment.RefreshData();
                    break;
                case "btnEditAttach":
                    this.EditAttach();
                    break;
            }
        }

        private void tileViewAttachment_ContextButtonCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewContextButtonCustomizeEventArgs e)
        {

        }

        private void tileViewAttachment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            rpi_btn_ViewFile_Click(sender, e);
        }

        private void grcAttachmentCardView_ProcessGridKey(object sender, KeyEventArgs e)
        {
        }

        private void tileViewAttachment_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            this.rpi_btn_ViewFile_Click(sender, e);
        }
    }
}
