using System;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.API.Native;
using DA;
using DevExpress.XtraEditors;
using System.Diagnostics;
using UI.Helper;
using UI.WarehouseManagement;
using System.Linq;

namespace UI.CRM
{
    public partial class frm_CRM_ContractDocumentCreation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int varContractID;
        private string lang = " (VN)";
        public frm_CRM_ContractDocumentCreation(int ContractID)
        {
            InitializeComponent();
            varContractID = ContractID;
            this.tabPageContractDetails.PageVisible = false;
            this.tabPageContractMain.PageVisible = false;
            this.tabPageScopeOfWork.PageVisible = false;
            openMergeAndSaveContract();
        }

        private void performMailMergeItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

            richEditContractTemplate.MailMerge(richEditResult.Document);
            MergeTofile();
            //tabControlRichEditControls.SelectedTabPage = tabPageResult;
        }

        void richEditResult_CalculateDocumentVariable(object sender, CalculateDocumentVariableEventArgs e)
        {
            if (e.VariableName == "ContractDetails")
            {
                RichEditDocumentServer documentServerProducts = new RichEditDocumentServer();
                MailMergeOptions mailMergeOptions = richEditContractDetailTemplate.CreateMailMergeOptions();
                mailMergeOptions.MergeMode = MergeMode.JoinTables;

                richEditContractDetailTemplate.MailMerge(mailMergeOptions, documentServerProducts.Document);
                e.Value = documentServerProducts;
                e.Handled = true;
            }

            else
            {
                RichEditDocumentServer reScopeOfWork = new RichEditDocumentServer();
                MailMergeOptions mailMergeOptions = richEditScopeOfWorkTemplate.CreateMailMergeOptions();
                mailMergeOptions.MergeMode = MergeMode.JoinTables;

                richEditScopeOfWorkTemplate.MailMerge(mailMergeOptions, reScopeOfWork.Document);
                e.Value = reScopeOfWork;
                e.Handled = true;
            }

        }

        #region Helper Methods
        private void showAllFieldCodesItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAllFieldCodes((RichEditControl)tabControlRichEditControls.SelectedTabPage.Controls[0]);
        }

        private void showAllFieldResultsItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAllFieldResults((RichEditControl)tabControlRichEditControls.SelectedTabPage.Controls[0]);
        }

        private void ShowAllFieldCodes(RichEditControl richEditControl)
        {
            ShowAllFieldCodesCommand showAllFieldCodesCommand = new ShowAllFieldCodesCommand(richEditControl);
            showAllFieldCodesCommand.Execute();
        }

        private void ShowAllFieldResults(RichEditControl richEditControl)
        {
            ShowAllFieldResultsCommand showAllFieldResultsCommand = new ShowAllFieldResultsCommand(richEditControl);
            showAllFieldResultsCommand.Execute();
        }

        private void SaveDocument(RichEditControl richEditControl)
        {
            //SaveDocumentAsCommand saveA = new SaveDocumentAsCommand(richEditControl);
            //saveA.Execute();

            DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
            var currentContract = dataProcess.Select(c => c.ContractID == this.varContractID).FirstOrDefault();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word 2007 Document (*.docx)|*.docx";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.DereferenceLinks = true;
                saveFileDialog.ValidateNames = true;
                saveFileDialog.InitialDirectory = AppSetting.PathContractDocumentFiles;
                saveFileDialog.FileName = currentContract.ContractNumber.Replace("/", ".") + lang + " Appendix " + currentContract.AppendixNumber + ".docx";
                //richEditContractTemplate.SaveDocument(fileName, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);


                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                    return;
                string fileNamexx = saveFileDialog.FileName;
                richEditResult.SaveDocument(fileNamexx, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);

                if (XtraMessageBox.Show("Contract document saved ; Do you want to open the contract document file?", "Mail Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(fileNamexx);
                    }
                    catch { }
                }
            }
        }
        private void ViewDataResult(RichEditControl richEditControl)
        {
           ToggleViewMergedDataCommand ViewData = new ToggleViewMergedDataCommand(richEditControl);
            ViewData.Execute();
        }

        private void InsertMergedField(RichEditControl richEditControl)
        {
            InsertMergeFieldCommand InsMeField = new InsertMergeFieldCommand(richEditControl);
            InsMeField.Execute();
        }



        #endregion Helper Methods

        private void MergeTofile()
        {            
            DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
            var currentContract = dataProcess.Select(c => c.ContractID == this.varContractID).FirstOrDefault();
            MailMergeOptions options = richEditContractTemplate.Document.CreateMailMergeOptions();
            options.MergeMode = MergeMode.NewParagraph;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word 2007 Document (*.docx)|*.docx";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.DereferenceLinks = true;
                saveFileDialog.ValidateNames = true;
                saveFileDialog.InitialDirectory = AppSetting.PathContractDocumentFiles;
                saveFileDialog.FileName = currentContract.ContractNumber.Replace("/", ".") + lang + " Appendix " + currentContract.AppendixNumber + ".docx";
                //richEditContractTemplate.SaveDocument(fileName, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);


                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                    return;
                string fileName = saveFileDialog.FileName;
                //richEditResult.MailMerge(options, fileName, DocumentFormat.OpenXml);

                if (XtraMessageBox.Show("Contract document saved ; Do you want to open the contract document file?", "Mail Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(fileName);
                    }
                    catch { }
                }
            }
        }

        private void btnMergeToFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MergeTofile();
        }

        private void openMergeAndSaveContract()
        {
            OpenFileDialog of = new OpenFileDialog();
            //of.Filter = "Excel File|*.xls||*.xlsx";
            of.Filter = "Rich Text Format File|*.rtf";
            of.Title = "WMS - Please select a Document Template file";
            of.Multiselect = false;
            of.RestoreDirectory = true;
            of.InitialDirectory = AppSetting.PathContractTemplateFiles;
            
            if (of.ShowDialog() == DialogResult.OK)
            {
                string fileName = of.FileName;
                if (fileName.Contains("VN"))
                    lang = " (VN)";
                else
                    lang = " (EN)";
                if (fileName.Contains("Appendix"))
                {
                    richEditContractTemplate.LoadDocument(fileName);
                    //this.tabPageContractDetails.PageVisible = true;
                    if (fileName.Contains("VN"))
                    {
                        richEditContractDetailTemplate.LoadDocument(AppSetting.PathContractTemplateFiles + "Supported Templates\\ContractDetailTemplateVN.rtf");
                        richEditScopeOfWorkTemplate.LoadDocument(AppSetting.PathContractTemplateFiles + "Supported Templates\\ContractScopeOfWorkTemplateVN.rtf");
                    }
                    else
                    {
                        richEditContractDetailTemplate.LoadDocument(AppSetting.PathContractTemplateFiles + "Supported Templates\\ContractDetailTemplateEN.rtf");
                        richEditScopeOfWorkTemplate.LoadDocument(AppSetting.PathContractTemplateFiles + "Supported Templates\\ContractScopeOfWorkTemplateEN.rtf");
                    }
                    var datasource = FileProcess.LoadTable("STContractDetailMailMergeByContractID " + varContractID);
                    richEditContractDetailTemplate.Options.MailMerge.DataSource = datasource;
                    richEditScopeOfWorkTemplate.Options.MailMerge.DataSource = datasource;
                }

                else
                {
                    richEditContractTemplate.LoadDocument(fileName);
                    //this.tabPageContractDetails.PageVisible = false;
                }


                richEditContractTemplate.Options.MailMerge.DataSource = FileProcess.LoadTable("STContractMailMerge " + varContractID);
                richEditContractTemplate.MailMerge(richEditResult.Document);
                //MergeTofile();

                //DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
                //var currentContract = dataProcess.Select(c => c.ContractID == this.varContractID).FirstOrDefault();

                //using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                //{
                //    saveFileDialog.Filter = "Word 2007 Document (*.docx)|*.docx";
                //    saveFileDialog.RestoreDirectory = true;
                //    saveFileDialog.CheckFileExists = false;
                //    saveFileDialog.CheckPathExists = true;
                //    saveFileDialog.OverwritePrompt = true;
                //    saveFileDialog.DereferenceLinks = true;
                //    saveFileDialog.ValidateNames = true;
                //    saveFileDialog.InitialDirectory = AppSetting.PathContractDocumentFiles;
                //    saveFileDialog.FileName = "Contract " + currentContract.ContractNumber.Replace("/", "-") + "~" + currentContract.AppendixNumber + ".docx";
                //    //richEditContractTemplate.SaveDocument(fileName, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);


                //    if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                //        return;
                //    string fileNamexx = saveFileDialog.FileName;
                //    richEditResult.SaveDocument(fileNamexx, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);

                //    if (XtraMessageBox.Show("Contract document saved ; Do you want to open the contract document file?", "Mail Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        try
                //        {
                //            Process.Start(fileName);
                //        }
                //        catch { }
                //    }
                //}



            }
        }

        private void btnOpenDocumentTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openMergeAndSaveContract();
        }

        private void richEditContractTemplate_Enter(object sender, EventArgs e)
        {
            richEditBarController1.RichEditControl = richEditContractTemplate;
        }

        private void richEditContractDetailTemplate_Enter(object sender, EventArgs e)
        {
            richEditBarController1.RichEditControl = richEditContractDetailTemplate;
        }

        private void richEditResult_Enter(object sender, EventArgs e)
        {
            richEditBarController1.RichEditControl = richEditResult;
        }

        private void richEditScopeOfWorkTemplate_Enter(object sender, EventArgs e)
        {
            richEditBarController1.RichEditControl = richEditScopeOfWorkTemplate;
        }

        private void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveDocument((RichEditControl)tabControlRichEditControls.SelectedTabPage.Controls[0]);
        }

        private void toggleViewMergedDataItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewDataResult((RichEditControl)tabControlRichEditControls.SelectedTabPage.Controls[0]);
        }

        private void insertMergeFieldItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsertMergedField((RichEditControl)tabControlRichEditControls.SelectedTabPage.Controls[0]);
        }

        private void btnSaveAsAttachment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Save file to temp. folder
            string cusInitial = "";

            // Get contract info
            DataProcess<Contracts> dataProcess = new DataProcess<Contracts>();
            var currentContract = dataProcess.Select(c => c.ContractID == this.varContractID).FirstOrDefault();

            // Get customer info
            var currentCustomer = AppSetting.CustomerListAll.Where(c => c.CustomerID == currentContract.CustomerID).FirstOrDefault();
            cusInitial = currentCustomer.Initial;

            string fileName = AppSetting.PathContractDocumentFiles + "\\ECV-" + cusInitial + "-" + DateTime.Today.Year + "-" + varContractID + ".docx";
            richEditContractTemplate.SaveDocument(fileName, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);

           // Create attact from file
            frm_WM_Attachments.Instance.OrderNumber = currentContract.ContractNumber;
            if (!frm_WM_Attachments.Instance.Enabled) return;
            frm_WM_Attachments.Instance.SaveAttachFile(fileName, "Auto");
            frm_WM_Attachments.Instance.Show();

            // open form Attachment
            this.Close();
        }
    }
}