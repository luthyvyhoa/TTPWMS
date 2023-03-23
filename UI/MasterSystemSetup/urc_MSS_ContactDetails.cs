using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;
using DevExpress.XtraEditors;

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_ContactDetails : UserControl
    {
        private Customers _currentCustomer;
        private DataProcess<CustomerContacts> _contactData;
        bool isEdit;
        //private static urc_MSS_ContactDetails _instance;

        public Customers CurrentCustomer
        {
            set
            {
                this._currentCustomer = value;
                FilterData();
            }
        }

        //public static urc_MSS_ContactDetails Instance
        //{
        //    get
        //    {
        //        if(_instance == null)
        //        {
        //            _instance = new urc_MSS_ContactDetails();
        //        }
        //        return _instance;
        //    }
        //}

        public urc_MSS_ContactDetails()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._currentCustomer = new Customers();
            this._contactData = new DataProcess<CustomerContacts>();
        }

        private void urc_MSS_ContactDetails_Load(object sender, EventArgs e)
        {
            LoadCustomerContactData();
            SetEvents();
            SetEditable(false);
            FilterData();
        }

        private void SetEvents()
        {
            this.grvContactDetails.InitNewRow += grvContactDetails_InitNewRow;
        }

        public void SetEditable(bool isEditable)
        {
            this.grcName.OptionsColumn.AllowEdit = isEditable;
            this.grcPhone.OptionsColumn.AllowEdit = isEditable;
            this.grcPosition.OptionsColumn.AllowEdit = isEditable;
            this.grcEmail.OptionsColumn.AllowEdit = isEditable;
            this.grcMobile.OptionsColumn.AllowEdit = isEditable;
            this.grvContactDetails.OptionsBehavior.Editable = isEditable;
            this.grvContactDetails.OptionsBehavior.ReadOnly = !isEditable;
            isEdit = isEditable;


        }

        #region Load Data
        private void LoadCustomerContactData()
        {
            BindingList<CustomerContacts> contacts = new BindingList<CustomerContacts>((List<CustomerContacts>)this._contactData.Select());
            this.grdContactDetails.DataSource = contacts;
        }
        #endregion

        #region Events
        private void grvContactDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvContactDetails.SetRowCellValue(e.RowHandle, this.grvContactDetails.Columns["CustomerMainID"], this._currentCustomer.CustomerMainID);
            this.grvContactDetails.SetRowCellValue(e.RowHandle, this.grvContactDetails.Columns["CustomerContactID"], -1);
        }
        #endregion

        public void UpdateCustomerContacts()
        {
            try
            {
                //error  source[i].CustomerMainID la gi ?
                BindingList<CustomerContacts> source = (BindingList<CustomerContacts>)this.grdContactDetails.DataSource;
                int count = source.Count;

                for (int i = 0; i < count; i++)
                {
                    if (source[i].CustomerMainID - this._currentCustomer.CustomerMainID == 0)
                    {
               

                        if (source[i].CustomerContactID == 0)
                        {
                            source[i].CreatedBy = AppSetting.CurrentUser.LoginName;
                            source[i].CreatedTime = DateTime.Now;
                            this._contactData.Insert(source[i]);
                     
                        }
                        else
                        {
                            this._contactData.Update(source[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void setCustomerContacts(CustomerContacts currentCustomerContacts)
        {
            try
            {
                currentCustomerContacts.Name = Convert.ToString(this.grvContactDetails.GetFocusedRowCellValue("Name"));
                currentCustomerContacts.Position = Convert.ToString(this.grvContactDetails.GetFocusedRowCellValue("Position"));
                currentCustomerContacts.Mobile = Convert.ToString(this.grvContactDetails.GetFocusedRowCellValue("Mobile"));
                currentCustomerContacts.Phone = Convert.ToString(this.grvContactDetails.GetFocusedRowCellValue("Phone"));
                currentCustomerContacts.Email = Convert.ToString(this.grvContactDetails.GetFocusedRowCellValue("Email"));
            }
           catch(Exception e)
            {

            }
       
        }


        private void FilterData()
        {
            this.LoadCustomerContactData();
            this.grcContactID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(this.grcCustomerMainID, (object)this._currentCustomer.CustomerMainID);
        }
        DataProcess<CustomerContacts> dataProcessCustomerContacts = new DataProcess<CustomerContacts>();
        private void grvContactDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
            //int currentCustomerContact=Convert.ToInt32(this.grvContactDetails.GetFocusedRowCellValue("CustomerContactID"));
            //CustomerContacts customerContacts = dataProcessCustomerContacts.Select(n => n.CustomerContactID == currentCustomerContact).FirstOrDefault();
            //if(customerContacts==null)
            //{
            //    customerContacts = new CustomerContacts();
            //   setCustomerContacts(customerContacts);
            //  //  customerContacts.
            //    customerContacts.CustomerMainID = Convert.ToInt32(this._currentCustomer.CustomerMainID);
            //    int result = this._contactData.Insert(customerContacts);
            //}
            //else
            //{
            //    setCustomerContacts(customerContacts);
            //   int result =  this._contactData.Update(customerContacts);
            //}
          
        }

        private void grvContactDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Delete)) return;
            if (this.grvContactDetails.RowCount <= 0) return;
            if(isEdit==true)
            {
                int indexContactDetail = Convert.ToInt32(this.grvContactDetails.GetFocusedRowCellValue("CustomerContactID"));
                var confirm = MessageBox.Show("Do you want to delete this record?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm.Equals(DialogResult.No)) return;
                this._contactData.ExecuteNoQuery("Delete CustomerContacts Where CustomerContactID = {0}", indexContactDetail);
                this.LoadCustomerContactData();

            }

        }

        private void rpe_ResetPassword_Click(object sender, EventArgs e)
        {
            //Code here to process reset password using ST_ClientUserUniversal_ResetPassword
            string npass = XtraInputBox.Show("Please enter new password for this Customer Contact to access the web : ", "TPWMS", String.Empty);
            if (npass == null || npass == "")
                return;
            else
            { 
                int result = 0;
                string webuser = this.grvContactDetails.GetFocusedRowCellValue("Email").ToString();
                result = this._contactData.ExecuteNoQuery("ST_ClientUserUniversal_ResetPassword @LoginName = {0}, @nPassword {1)", webuser,npass);
                if (result == 1)
                    MessageBox.Show("Successfully reset password of the user " + webuser, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error reset password of the user " + webuser, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
