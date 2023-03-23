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

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerEvent : UserControl
    {
        private DataProcess<CustomerEvents> customerEventDA = new DataProcess<CustomerEvents>();
        private int customerMainID = 0;
        private BindingList<CustomerEvents> customerEventsDataSource = null;

        public urc_MSS_CustomerEvent()
        {
            InitializeComponent();

            this.customerEventsDataSource = new BindingList<CustomerEvents>
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            this.RegisterEvents();

            // Load confidential data
            this.LoadConfidential();

            // Load category
            this.LoadCategory();

            // Load customer events 
            this.LoadCustomerEvents();
        }

        public int CustomerMainID
        {
            get
            {
                return this.customerMainID;
            }
            set
            {
                this.customerMainID = value;
                this.LoadCustomerEvents();
            }
        }

        private void LoadConfidential()
        {
            using (DataTable dataSource = new DataTable())
            {
                dataSource.Columns.Add("ID", typeof(int));
                dataSource.Columns.Add("Name", typeof(string));

                var publicRow = dataSource.NewRow();
                publicRow["ID"] = 0;
                publicRow["Name"] = "Public";
                var confidentialRow = dataSource.NewRow();
                confidentialRow["ID"] = 1;
                confidentialRow["Name"] = "Confidential";
                var privateRow = dataSource.NewRow();
                privateRow["ID"] = 2;
                privateRow["Name"] = "Private";
                dataSource.Rows.Add(publicRow);
                dataSource.Rows.Add(confidentialRow);
                dataSource.Rows.Add(privateRow);

                this.rpi_lke_Confidential.DataSource = dataSource;
                this.rpi_lke_Confidential.DisplayMember = "Name";
                this.rpi_lke_Confidential.ValueMember = "ID";
            }
        }

        private void LoadCategory()
        {
            using (DataTable dataSource = new DataTable())
            {
                dataSource.Columns.Add("ID", typeof(int));
                dataSource.Columns.Add("Name", typeof(string));
                //0;Marketing;1;Service;2;Internal

                var makettingRow = dataSource.NewRow();
                makettingRow["ID"] = 0;
                makettingRow["Name"] = "Marketing";
                var serviceRow = dataSource.NewRow();
                serviceRow["ID"] = 1;
                serviceRow["Name"] = "Service";
                var internalRow = dataSource.NewRow();
                internalRow["ID"] = 2;
                internalRow["Name"] = "Internal";
                dataSource.Rows.Add(makettingRow);
                dataSource.Rows.Add(serviceRow);
                dataSource.Rows.Add(internalRow);

                this.rpi_lke_Category.DataSource = dataSource;
                this.rpi_lke_Category.DisplayMember = "Name";
                this.rpi_lke_Category.ValueMember = "ID";
            }
        }

        private void LoadCustomerEvents()
        {
            var listEvents = this.customerEventDA.Select(cus => cus.CustomerMainID == this.customerMainID).ToList();
            this.customerEventsDataSource = new BindingList<CustomerEvents>(listEvents)
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            this.grdCustomerEvents.DataSource = customerEventsDataSource;
            this.AddNewItemToDataSource(this.customerEventsDataSource);
        }

        private void RegisterEvents()
        {
            this.grvCustomerEvents.CellValueChanged += grvCustomerEvents_CellValueChanged;
        }

        private void grvCustomerEvents_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
            {
                return;
            }

            var currentEvent = this.grvCustomerEvents.GetRow(e.RowHandle) as CustomerEvents;
            if (currentEvent == null)
            {
                // TODO:
                return;
            }

            switch (e.Column.Name)
            {
                case "grcApprovedBy":
                case "grcConfirmed":
                case "grcUpdateBy":
                case "grcUpdateTime":
                case "grcRequirementCategory":
                case "grcCategory":
                    break;

                case "grcRequirementDetails":
                    currentEvent.EventDescription = e.Value.ToString();
                    break;

                default:
                    break;
            }

            // Update on DB
            this.CreateOrUpdateEvent(currentEvent);
        }

        private void rpi_lke_Category_EditValueChanged(object sender, EventArgs e)
        {
            // Get current value
            int confidentalValue;
            var lookupEditCtrl = sender as DevExpress.XtraEditors.LookUpEdit;
            if (lookupEditCtrl == null)
            {
                return;
            }

            int.TryParse(lookupEditCtrl.EditValue.ToString(), out confidentalValue);

            // Get Event model
            var currentEvent = this.grvCustomerEvents.GetFocusedRow() as CustomerEvents;
            if (currentEvent == null)
            {
                return;
            }

            // Update UI + Model
            currentEvent.EventCategory = Convert.ToByte(confidentalValue);

            // Update on DB
            this.CreateOrUpdateEvent(currentEvent);

            // Set selected Row
            var currentSelectedRow = this.grvCustomerEvents.FocusedRowHandle;
            this.grvCustomerEvents.SelectRow(currentSelectedRow);
        }

        private void rpi_lke_Confidential_EditValueChanged(object sender, EventArgs e)
        {
            // Get current value
            int confidentalValue;
            var lookupEditCtrl = sender as DevExpress.XtraEditors.LookUpEdit;
            if (lookupEditCtrl == null)
            {
                return;
            }

            int.TryParse(lookupEditCtrl.EditValue.ToString(), out confidentalValue);

            // Get Event model
            var currentEvent = this.grvCustomerEvents.GetFocusedRow() as CustomerEvents;
            if (currentEvent == null)
            {
                return;
            }

            // Update UI + Model
            currentEvent.ConfidentialLevel = Convert.ToByte(confidentalValue);

            // Update on DB
            this.CreateOrUpdateEvent(currentEvent);
        }

        private void rpi_chk_Confirmed_CheckedChanged(object sender, EventArgs e)
        {
            // Update model
            var checkCtrol = sender as DevExpress.XtraEditors.CheckEdit;
            if (checkCtrol == null)
            {
                return;
            }

            var currentEvent = this.grvCustomerEvents.GetFocusedRow() as CustomerEvents;

            // Update UI
            if (checkCtrol.Checked)
            {
                // Update confirm Time, Confirm By value
                currentEvent.Confirmed = true;
                currentEvent.ConfirmedBy = AppSetting.CurrentUser.LoginName;
                currentEvent.ConfirmedTime = DateTime.Now;
            }
            else
            {
                currentEvent.Confirmed = false;
                currentEvent.ConfirmedBy = null;
                currentEvent.ConfirmedTime = null;
            }

            // Update on DB
            this.CreateOrUpdateEvent(currentEvent);
        }

        /// <summary>
        /// Handles the Load event of the urc_MSS_CustomerEvent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void urc_MSS_CustomerEvent_Load(object sender, EventArgs e)
        {
            this.LoadCustomerEvents();
            //var needAddedNewRow = this.customerEventsDataSource.All(ev => ev.CustomerEventID != 0);
            //if (needAddedNewRow)
            //{
            //    this.grvCustomerEvents.AddNewRow();
            //}
        }

        private void CreateOrUpdateEvent(CustomerEvents customerEvent)
        {
            customerEvent.CreatedBy = AppSetting.CurrentUser.LoginName;
            if (customerEvent.CustomerEventID > 0)
            {
                this.customerEventDA.Update(customerEvent);
            }
            else
            {
                this.customerEventDA.Insert(customerEvent);
            }

            if (this.customerEventsDataSource.All(e => e.CustomerEventID > 0))
            {
                this.AddNewItemToDataSource(this.customerEventsDataSource);
            }
        }

        private void AddNewItemToDataSource(BindingList<CustomerEvents> bindingList)
        {
            var addingNewItem = bindingList.AddNew();
            addingNewItem.CreatedTime = DateTime.Now;
            addingNewItem.EventDate = DateTime.Now;
            addingNewItem.CustomerMainID = this.CustomerMainID;

            this.grvCustomerEvents.FocusedRowHandle = this.grvCustomerEvents.RowCount; // Select last row
        }
    }
}
