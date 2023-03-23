using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System;
using System.Windows.Forms;
using DA;
using UI.Helper;


namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerRequirements : UserControl
    {
        private DataProcess<CustomerRequirements> _requirementData;
        private Customers _currentCustomer;
        private bool _isLocked;
        private BindingList<CustomerRequirements> requirements;
        /// <summary>
        /// Lock gridView if not Supervisor
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }

            set
            {
                _isLocked = value;
                SetReadOnly(this._isLocked);
            }
        }

        public Customers CurrentCustomer
        {
            set
            {
                this._currentCustomer = value;
                FilterData();
            }
        }

        public urc_MSS_CustomerRequirements()
        {
            InitializeComponent();
            this._currentCustomer = new Customers();
            this.Dock = DockStyle.Fill;
            this._requirementData = new DataProcess<CustomerRequirements>();
        }

        private void urc_MSS_CustomerRequirements_Load(object sender, EventArgs e)
        {
            InitRequirementCategory();
            LoadRequirements();
            SetEvents();
            SetEditable(false);
            FilterData();
        }

        private void SetEvents()
        {
            this.grvCustomerRequirements.InitNewRow += grvCustomerRequirements_InitNewRow;
            this.rpi_chk_Confirmed.CheckedChanged += Rpi_chk_Confirmed_CheckedChanged;
            this.grvCustomerRequirements.KeyDown += GrvCustomerRequirements_KeyDown;
            this.rpi_lke_RequirementCategory.EditValueChanged += Rpi_lke_RequirementCategory_EditValueChanged;
        }

        private void Rpi_lke_RequirementCategory_EditValueChanged(object sender, EventArgs e)
        {
            var lke = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (lke == null) return;

            // find category id select has exit
            var categorySelected = Convert.ToInt32(lke.EditValue);
            var categoryFind = this.requirements.Where(r => r.RequirementCategory == categorySelected && r.CustomerMainID==this._currentCustomer.CustomerMainID).Count();
            if (categoryFind > 0)
            {
                MessageBox.Show("This category has existed, could not add new it.", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.LoadRequirements();
                return;
            }
        }

        private void GrvCustomerRequirements_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Delete))
            {
                var confirm = MessageBox.Show("Do you want to delete this requirement?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm.Equals(DialogResult.Yes))
                {
                    var customerRequirement = (CustomerRequirements)this.grvCustomerRequirements.GetRow(this.grvCustomerRequirements.FocusedRowHandle);
                    if (customerRequirement == null) return;
                    this._requirementData.Delete(customerRequirement);
                    this.grvCustomerRequirements.DeleteRow(this.grvCustomerRequirements.FocusedRowHandle);
                }
            }
        }

        private void Rpi_chk_Confirmed_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk.Checked)
            {
                this.grvCustomerRequirements.SetFocusedRowCellValue("ApprovedBy", AppSetting.CurrentUser.LoginName);
                this.grvCustomerRequirements.SetFocusedRowCellValue("RequirementConfirmed", true);
            }
            else
            {
                this.grvCustomerRequirements.SetFocusedRowCellValue("RequirementConfirmed", false);
            }
        }

        #region Load Data
        private void LoadRequirements()
        {
            this.requirements = new BindingList<CustomerRequirements>((List<CustomerRequirements>)this._requirementData.Select());
            this.grdCustomerRequirements.DataSource = requirements;
        }

        private void InitRequirementCategory()
        {

            var source = new DataTable();

            source.Columns.Add("ID", typeof(byte));
            source.Columns.Add("Name", typeof(string));

            // Create row
            var row1 = source.NewRow();
            var row2 = source.NewRow();
            var row3 = source.NewRow();
            var row4 = source.NewRow();

            // Set data
            row1["ID"] = 1;
            row1["Name"] = "Receiving";

            row2["ID"] = 2;
            row2["Name"] = "Dispatching";

            row3["ID"] = 3;
            row3["Name"] = "Storage";

            row4["ID"] = 4;
            row4["Name"] = "Administration";

            // Add row
            source.Rows.Add(row1);
            source.Rows.Add(row2);
            source.Rows.Add(row3);
            source.Rows.Add(row4);

            this.rpi_lke_RequirementCategory.DataSource = source;
            this.rpi_lke_RequirementCategory.ValueMember = "ID";
            this.rpi_lke_RequirementCategory.DisplayMember = "Name";
        }
        #endregion

        #region Events
        private void grvCustomerRequirements_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grvCustomerRequirements.SetRowCellValue(e.RowHandle, this.grvCustomerRequirements.Columns["UpdateBy"], AppSetting.CurrentUser.LoginName);
            this.grvCustomerRequirements.SetRowCellValue(e.RowHandle, this.grvCustomerRequirements.Columns["UpdateTime"], DateTime.Now);
            this.grvCustomerRequirements.SetRowCellValue(e.RowHandle, this.grvCustomerRequirements.Columns["CustomerMainID"], this._currentCustomer.CustomerMainID);
            this.grvCustomerRequirements.SetRowCellValue(e.RowHandle, this.grvCustomerRequirements.Columns["CustomerRequirementID"], -1);
        }
        #endregion

        public void UpdateCustomerRequirement()
        {
            CustomerRequirements customerRequirements = new CustomerRequirements();
            DataProcess<object> da = new DataProcess<object>();
            if (this.grdCustomerRequirements.DataSource == null) return;
            try
            {
                BindingList<CustomerRequirements> source = (BindingList<CustomerRequirements>)this.grdCustomerRequirements.DataSource;
                int count = source.Count;

                for (int i = 0; i < count; i++)
                {
                    if (source[i].CustomerMainID - this._currentCustomer.CustomerMainID == 0)
                    {
                        if (source[i].CustomerRequirementID == -1)
                        {
                              customerRequirements.ApprovedBy = source[i].ApprovedBy;
                            customerRequirements.CustomerMainID = source[i].CustomerMainID;

                            customerRequirements.RequirementCategory = source[i].RequirementCategory;
                            customerRequirements.RequirementConfirmed = source[i].RequirementConfirmed;
                            customerRequirements.RequirementDetails = source[i].RequirementDetails;
                            customerRequirements.CustomerRequirementID = source[i - 1].CustomerRequirementID + 1;
                            customerRequirements.UpdateBy = source[i].UpdateBy;
                            customerRequirements.UpdateTime = source[i].UpdateTime;

                           // source[i].CustomerRequirementID = source[i - 1].CustomerRequirementID + 1;
                            //this._requirementData.Insert(source[i]);
                            int result = da.ExecuteNoQuery("INSERT INTO dbo.CustomerRequirements( CustomerMainID,RequirementDetails,UpdateBy,UpdateTime,RequirementConfirmed,ApprovedBy,RequirementCategory) VALUES({0},{1},{2},{3},{4},{5},{6})", customerRequirements.CustomerMainID, customerRequirements.RequirementDetails,
                                   customerRequirements.UpdateBy,
                                      customerRequirements.UpdateTime,
                                         customerRequirements.RequirementConfirmed,
                                            customerRequirements.ApprovedBy,
                                            customerRequirements.RequirementCategory);
                            if (result < 0)
                            {
                                this.LoadRequirements();
                                MessageBox.Show("Can't Not Insert Because Detail  Null", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //source[i].CustomerRequirementID = source[i - 1].CustomerRequirementID + 1;
                            //this._requirementData.Insert(source[i]);
                        }
                        else
                        {
                            int result = this._requirementData.Update(source[i]);
                        }
                    }
                }
            }
            catch (Exception ex )
            {
            }
        }

        public void SetEditable(bool isEditable)
        {
            this.grcApprovedBy.OptionsColumn.AllowEdit = isEditable;
            this.grcConfirmed.OptionsColumn.AllowEdit = isEditable;
            this.grcRequirementCategory.OptionsColumn.AllowEdit = isEditable;
            this.grvCustomerRequirements.OptionsBehavior.ReadOnly = !isEditable;
            this.grvCustomerRequirements.OptionsBehavior.Editable = isEditable;
        }

        private void FilterData()
        {
            this.grcCustomerRequirementID.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(this.grcCustomerMainID, (object)this._currentCustomer.CustomerMainID);
        }

        private void SetReadOnly(bool isReadOnly)
        {
            this.grvCustomerRequirements.OptionsBehavior.ReadOnly = isReadOnly;
            this.grvCustomerRequirements.OptionsBehavior.Editable = !isReadOnly;
            this.grcConfirmed.OptionsColumn.ReadOnly = isReadOnly;
        }
    }
}
