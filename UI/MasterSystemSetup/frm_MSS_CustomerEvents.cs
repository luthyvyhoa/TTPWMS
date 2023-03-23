using System.Windows.Forms;
using Common.Controls;
using DA;
using System.Collections.Generic;
using System.Linq;
using System;
using UI.Helper;
using UI.WarehouseManagement;
using UI.Management;

namespace UI.MasterSystemSetup
{
    /// <summary>
    /// The frm_MSS_CustomerEvents
    /// </summary>
    public partial class frm_MSS_CustomerEvents : frmBaseForm
    {
        #region Private fields
        /// <summary>
        /// List of Customer events
        /// </summary>
        private List<ST_WWS_CustomerEvents_Result> customerEvents;

        /// <summary>
        /// Binding source
        /// </summary>
        private BindingSource bindingSource;
        private int customerEventID = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for frm_MSS_CustomerEvents
        /// </summary>
        public frm_MSS_CustomerEvents()
        {
            InitializeComponent();
            //this.chkAll.Checked = true;
            this.customerEvents = new List<ST_WWS_CustomerEvents_Result>();
            this.bindingSource = new BindingSource();

        }
        public frm_MSS_CustomerEvents(int customerEventIDParam)
        {
            InitializeComponent();
            //this.chkAll.Checked = true;
            this.customerEvents = new List<ST_WWS_CustomerEvents_Result>();
            this.bindingSource = new BindingSource();
            this.customerEventID = customerEventIDParam;
        }
        #endregion

        #region Events
        /// <summary>
        /// Handle chkMainCustomer_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkMainCustomer_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    if (this.chkMainCustomer.Checked)
        //    {
        //        this.lkeMainCustomer.Enabled = true;
        //        this.chkAll.Checked = false;
        //        this.chkNonConfirmation.Checked = false;
        //    }
        //}

        /// <summary>
        /// Handle Loaded event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_MSS_CustomerEvents_Load(object sender, System.EventArgs e)
        {
            lkeCustomerID.Enabled = false;


            DataProcess<ST_WWS_CustomerEvents_Result> customerEvent = new DataProcess<ST_WWS_CustomerEvents_Result>();

            this.customerEvents = customerEvent.Executing("ST_WWS_CustomerEvents @CustomerEventID={0}",this.customerEventID).ToList();

            //this.txtFromDate.Text = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            //this.txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            List<Confidential> confidentials = new List<Confidential>();
            List<EventCategory> eventCategorys = new List<EventCategory>();

            //this.LoadDataToFilterCombobox();

            foreach (var item in this.customerEvents)
            {
                var confidenItem = new Confidential();
                var eventCategory = new EventCategory();

                if (item.ConfidentialLevel.HasValue)
                {
                    confidenItem.ValueMember = item.ConfidentialLevel.Value;
                    this.GetConfidentialDisplayMember(confidenItem);
                    confidentials.Add(confidenItem);
                }

                if (item.EventCategory.HasValue)
                {
                    eventCategory.ValueMember = item.EventCategory.Value;
                    this.GetEventCategoryDisplayMember(eventCategory);
                    eventCategorys.Add(eventCategory);
                }
            }

            this.bindingSource.DataSource = this.customerEvents;
            this.textBox1.DataBindings.Add("Text", this.bindingSource, "CustomerEventID");
            this.txtCustomerEventNumber.DataBindings.Add("Text", this.bindingSource, "CustomerEventNumber");
            this.txtEventDate.DataBindings.Add("Text", this.bindingSource, "EventDate");
            this.txtCreatedBy.DataBindings.Add("Text", this.bindingSource, "CreatedBy");
            this.txtCreatedDate.DataBindings.Add("Text", this.bindingSource, "CreatedTime");
            this.txtConfirmedBy.DataBindings.Add("Text", this.bindingSource, "ConfirmedBy");
            this.txtCustomerName.DataBindings.Add("Text", this.bindingSource, "CustomerName");
            //this.txtDocumentFolder.DataBindings.Add("Text", this.bindingSource, "DocumentFolder");
            this.mmeEventDesc.DataBindings.Add("Text", this.bindingSource, "EventDescription");

            lkeCustomerID.Properties.DataSource = this.bindingSource;
            lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            lkeCustomerID.Properties.ValueMember = "CustomerNumber";
            lkeCustomerID.DataBindings.Add("EditValue", this.bindingSource, "CustomerNumber");
            this.lkeConfidentiality.Properties.DataSource = confidentials;
            this.lkeConfidentiality.Properties.DisplayMember = "DisplayMember";
            this.lkeConfidentiality.Properties.ValueMember = "ValueMember";
            this.lkeConfidentiality.DataBindings.Add("EditValue", this.bindingSource, "ConfidentialLevel", true, DataSourceUpdateMode.OnPropertyChanged);

            this.lkeEventCategory.Properties.DataSource = eventCategorys;
            this.lkeEventCategory.Properties.DisplayMember = "DisplayMember";
            this.lkeEventCategory.Properties.ValueMember = "ValueMember";

            this.lkeEventCategory.DataBindings.Add("EditValue", this.bindingSource, "EventCategory", true, DataSourceUpdateMode.OnPropertyChanged);
            this.dataNavigatorBillings.DataSource = this.bindingSource;
            //this.chkRemind.DataBindings.Add("Checked", bindingSource, "ReminderRequired", true);
            //this.txtReminderText.DataBindings.Add("Text", this.bindingSource, "ReminderText");
            //this.dtReminderTime.DataBindings.Add("Text", this.bindingSource, "ReminderTime");
            //this.SetVisibleRemind();


            //this.I.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            this.SetEnableEditControl();
        }

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = !((bool)e.Value);
        }

        /// <summary>
        /// Handle chkAll_CheckedChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chkAll.Checked)
        //    {
        //        this.lkeMainCustomer.Enabled = false;
        //        this.chkNonConfirmation.Checked = false;
        //        this.chkMainCustomer.Checked = false;
        //    }
        //}

        /// <summary>
        /// Handle chkNonConfirmation_CheckedChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkNonConfirmation_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chkNonConfirmation.Checked)
        //    {
        //        this.chkAll.Checked = false;
        //        this.chkMainCustomer.Checked = false;
        //        this.lkeMainCustomer.Enabled = false;

        //        var displayDatas = this.customerEvents.Where(n => n.Confirmed.HasValue && n.Confirmed.Value == false).ToList();

        //        if (displayDatas.Any())
        //        {
        //            this.bindingSource.DataSource = displayDatas;
        //        }
        //        else
        //        {
        //            this.ClearData();
        //        }
        //    }
        //}

        /// <summary>
        /// Handle lkeMainCustomer_EditValueChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void lkeMainCustomer_EditValueChanged(object sender, EventArgs e)
        //{
        //    int customerMainID = int.Parse(this.lkeMainCustomer.EditValue.ToString());

        //    var displayDatas = this.customerEvents.Where(n => n.CustomerMainID == customerMainID).ToList();

        //    if (displayDatas.Any())
        //    {
        //        this.bindingSource.DataSource = displayDatas;
        //    }
        //    else
        //    {
        //        this.ClearData();
        //    }
        //}

        /// <summary>
        /// Handle chkRemind_CheckedChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkRemind_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.SetVisibleRemind();
        //}

        private void btnConfirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtConfirmedBy.Text = AppSetting.CurrentUser.LoginName;
            int customerEventId = -1;

            if (int.TryParse(this.textBox1.Text, out customerEventId))
            {
                DataProcess<CustomerEvents> customerEventDataProcess = new DataProcess<CustomerEvents>();
                var customerEvent = customerEventDataProcess.Select(n => n.CustomerEventID == customerEventId).FirstOrDefault();

                if (customerEvent != null)
                {
                    customerEvent.ConfirmedBy = this.txtConfirmedBy.Text;
                    customerEvent.ConfirmedTime = DateTime.Now;
                    customerEvent.ManagerFeedback = this.txtManagerFeedBack.Text.Trim();
                    //customerEvent.ReminderText = this.txtReminderText.Text.Trim();
                    customerEventDataProcess.Update(customerEvent);
                }
            }
        }

        /// <summary>
        /// Handle click in btnDelete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtConfirmedBy.Text = AppSetting.CurrentUser.LoginName;
            int customerEventId = -1;

            if (int.TryParse(this.textBox1.Text, out customerEventId))
            {
                DataProcess<CustomerEvents> customerEventDataProcess = new DataProcess<CustomerEvents>();
                var customerEvent = customerEventDataProcess.Select(n => n.CustomerEventID == customerEventId).FirstOrDefault();

                if (customerEvent != null)
                {
                    customerEventDataProcess.Delete(customerEvent);
                }

                var customerEventItem = this.customerEvents.FirstOrDefault(n => n.CustomerEventID == customerEventId);

                if (customerEventItem != null)
                {
                    this.customerEvents.Remove(customerEventItem);
                }
            }
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Load data to Main customer combobox
        /// </summary>
        //private void LoadDataToFilterCombobox()
        //{
        //    DataProcess<STcomboCustomerID_Result> comboCustomerID = new DataProcess<STcomboCustomerID_Result>();
        //    var customerIDs = comboCustomerID.Executing("STcomboCustomerID").Select(n => new { n.CustomerID, n.CustomerName, n.CustomerMainID });

        //    this.lkeMainCustomer.Properties.DataSource = customerIDs;
        //    this.lkeMainCustomer.Properties.DisplayMember = "CustomerName";
        //    this.lkeMainCustomer.Properties.ValueMember = "CustomerMainID";
        //    this.lkeMainCustomer.Properties.PopulateColumns();
        //    this.lkeMainCustomer.Properties.Columns[2].Visible = false;
        //}

        /// <summary>
        /// Get Confidential display value
        /// </summary>
        /// <param name="confidential"></param>
        private void GetConfidentialDisplayMember(Confidential confidential)
        {
            if (confidential.ValueMember == 0)
            {
                confidential.DisplayMember = "Public";
            }
            else if (confidential.ValueMember == 1)
            {
                confidential.DisplayMember = "Confidential";
            }
            else if (confidential.ValueMember == 2)
            {
                confidential.DisplayMember = "Private";
            }
        }

        /// <summary>
        /// Get Event Category Display Member
        /// </summary>
        /// <param name="eventCategory"></param>
        private void GetEventCategoryDisplayMember(EventCategory eventCategory)
        {
            if (eventCategory.ValueMember == 0)
            {
                eventCategory.DisplayMember = "Marketing";
            }
            else if (eventCategory.ValueMember == 1)
            {
                eventCategory.DisplayMember = "Service";
            }
            else if (eventCategory.ValueMember == 2)
            {
                eventCategory.DisplayMember = "Internal";
            }
        }

        /// <summary>
        /// Clear data of textbox
        /// </summary>
        private void ClearData()
        {
            this.txtCustomerEventNumber.Text = "";
            this.txtEventDate.Text = "";
            this.txtCreatedBy.Text = "";
            this.txtCreatedDate.Text = "";
            this.txtConfirmedBy.Text = "";
            this.txtCustomerName.Text = "";
            //this.txtDocumentFolder.Text = "";
            this.mmeEventDesc.Text = "";
        }

        /// <summary>
        /// Set visible layout control Remind
        /// </summary>
        //private void SetVisibleRemind()
        //{
        //    if (!this.chkRemind.Checked)
        //    {
        //        this.layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //        this.layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //    }
        //    else
        //    {
        //        this.layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //        this.layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        //    }
        //}

        private void SetEnableEditControl()
        {
            //this.txtFromDate.ReadOnly = true;
            //this.txtToDate.ReadOnly = true;
            this.txtCustomerEventNumber.ReadOnly = true;
            this.txtEventDate.ReadOnly = true;
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedDate.ReadOnly = true;
            this.txtConfirmedBy.ReadOnly = true;
            //Binding bind = new Binding("Enabled", this.bindingSource, "Confirmed", true);
            //bind.Format += SwitchBool;
            //bind.Parse += SwitchBool;

            this.btnConfirm.DataBindings.Add(SetEnableBindingControl());
            this.btnDelete.DataBindings.Add(SetEnableBindingControl());
            this.txtCustomerName.DataBindings.Add(SetEnableBindingControl());
            this.lkeConfidentiality.DataBindings.Add(SetEnableBindingControl());
            this.lkeCustomerID.DataBindings.Add(SetEnableBindingControl());
            this.mmeEventDesc.DataBindings.Add(SetEnableBindingControl());
            this.txtManagerFeedBack.DataBindings.Add(SetEnableBindingControl());
            this.lkeEventCategory.DataBindings.Add(SetEnableBindingControl());
        }

        private Binding SetEnableBindingControl()
        {
            Binding bind = new Binding("Enabled", this.bindingSource, "Confirmed", true);
            bind.Format += SwitchBool;
            bind.Parse += SwitchBool;
            return bind;
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                int  customerID = Convert.ToInt32(lkeCustomerID.GetColumnValue("CustomerID"));
                frm_WM_Attachments.Instance.OrderNumber = this.lkeCustomerID.EditValue.ToString();
                frm_WM_Attachments.Instance.CustomerID = customerID;
                if (frm_WM_Attachments.Instance.Enabled)
                {
                    frm_WM_Attachments.Instance.ShowDialog();
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        private void txtCustomerEventNumber_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Btn_BrNewBillingConfirmation_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void btnViewEventList_Click(object sender, EventArgs e)
        {
            frm_MSS_CustomerEventList frm = new frm_MSS_CustomerEventList();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
        }
    }

    /// <summary>
    /// The Confidential type
    /// </summary>
    internal class Confidential
    {
        /// <summary>
        /// Get or set the Value member
        /// </summary>
        public byte ValueMember { get; set; }

        /// <summary>
        /// Get or set the DisplayMember
        /// </summary>
        public string DisplayMember { get; set; }
    }

    /// <summary>
    /// The EventCategory type
    /// </summary>
    internal class EventCategory
    {
        /// <summary>
        /// Get or set the Value member
        /// </summary>
        public byte ValueMember { get; set; }

        /// <summary>
        /// Get or set the DisplayMember
        /// </summary>
        public string DisplayMember { get; set; }
    }
}
