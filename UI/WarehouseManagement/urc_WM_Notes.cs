using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DA;
using UI.Helper;
using UI.ReportFile;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors.Controls;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_Notes : UserControl
    {
        private ST_WMS_LoadNotes_Result _note;
        private DataProcess<Notes> _noteData;
        private DataProcess<ST_WMS_LoadReportNoteData_Result> _reportNoteData;
        private string _orderType;
        private int _orderNumber;
        private string _noteDescription;
        private string vehicleNumber;
        private string _customerNumber;
        private bool _isFirstLoad;
        private bool _isAddNew;
        private int customerIDSelected = -1;

        #region Properties
        public string NoteDescription
        {
            get
            {
                return _noteDescription;
            }

            set
            {
                _noteDescription = value;
            }
        }

        public string VehicleNumber
        {
            get
            {
                return this.vehicleNumber;
            }

            set
            {
                this.vehicleNumber = value;
            }
        }

        public string CustomerNumber
        {
            get
            {
                return _customerNumber;
            }

            set
            {
                _customerNumber = value;
            }
        }

        public int OrderNumber
        {
            get
            {
                return _orderNumber;
            }

            set
            {
                _orderNumber = value;
            }
        }
        #endregion

        public urc_WM_Notes()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._note = new ST_WMS_LoadNotes_Result();
            this._noteData = new DataProcess<Notes>();
            this._reportNoteData = new DataProcess<ST_WMS_LoadReportNoteData_Result>();
            this.lkeCustomerID.Enabled = false;
            txtOccurLocation.Text = AppSetting.StoreName;
        }

        private void CheckNoteConfirm()
        {
            // Check note confirm
            var noteData = FileProcess.LoadTable("select confirmed from notes where orderNumber=" + this.OrderNumber);
            if (noteData.Rows.Count > 0 && Convert.ToBoolean(noteData.Rows[0][0]))
            {
                this.btn_WM_Confirm.Enabled = false;
                this.btn_WM_Delete.Enabled = false;
            }
            else
            {
                this.btn_WM_Confirm.Enabled = true;
                this.btn_WM_Delete.Enabled = true;
            }
        }

        public urc_WM_Notes(string orderType, int orderNumber, int customerID)
        {
            InitializeComponent();
            this._orderType = orderType;
            this.OrderNumber = orderNumber;
            this._isFirstLoad = true;
            this._isAddNew = false;
            this._note = new ST_WMS_LoadNotes_Result();
            this._noteData = new DataProcess<Notes>();
            this._reportNoteData = new DataProcess<ST_WMS_LoadReportNoteData_Result>();
            this.customerIDSelected = customerID;
            InitCustomers();
            InitSupervisor();
            InitOrderType();
            SetEvents();
        }

        /// <summary>
        /// Load data to view by params input
        /// </summary>
        /// <param name="orderType">string</param>
        /// <param name="orderNumber">int</param>
        /// <param name="customerID">int</param>
        public void LoadData(string orderType, int orderNumber, int customerID)
        {
            this._orderType = orderType;
            this.OrderNumber = orderNumber;
            this.customerIDSelected = customerID;
            this.CheckNoteConfirm();
            LoadNotes();
            if (this._note == null)
            {
                SetData();
            }
            else
            {
                BindNotes();
            }
        }
        private void urc_WM_Notes_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.LoadData(this._orderType, this.OrderNumber, this.customerIDSelected);
                this._isFirstLoad = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetEvents()
        {
            this.lkeSupervisor.CloseUp += LkeSupervisor_CloseUp;
            this.lkeCustomerID.CloseUp += LkeCustomerID_CloseUp;
            this.dtOccurTime.Leave += DtOccurTime_Leave;
            this.dtNoteDate.Leave += DtNoteDate_Leave;
            this.lkeSupervisor.Leave += LkeSupervisor_Leave;
            this.lkeCustomerID.Leave += LkeCustomerID_Leave;
            this.lkeCustomerID.EditValueChanged += lkeCustomerID_EditValueChanged;
            this.lkeSupervisor.EditValueChanged += lkeSupervisor_EditValueChanged;
            this.txtCustomerRefNumber.Leave += txtVehicleNumber_Leave;
            this.txtCustomerRepresentative.Leave += txtVehicleNumber_Leave;
            this.txtOccurLocation.Leave += txtVehicleNumber_Leave;
            this.txtRepresentativePosition.Leave += txtVehicleNumber_Leave;
            this.txtVehicleNumber.Leave += txtVehicleNumber_Leave;
            this.dtNoteDate.EditValueChanged += dtNoteDate_EditValueChanged;
            this.dtOccurTime.EditValueChanged += dtOccurTime_EditValueChanged;
            this.mmeNoteDescription.TextChanged += MmeNoteDescription_TextChanged;
        }

        private void MmeNoteDescription_TextChanged(object sender, EventArgs e)
        {
            if (!this.mmeNoteDescription.IsModified) return;
            this._noteData.ExecuteNoQuery("Update Notes set NoteDescription=N'" + this.mmeNoteDescription.Text + "' where NoteID=" + this._note.NoteID);
            this._note.NoteDescription = this.mmeNoteDescription.Text;
        }

        private void LkeSupervisor_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lkeSupervisor.EditValue = e.Value;
            this._note.SupervisorID = Convert.ToInt32(lkeSupervisor.GetColumnValue("EmployeeID"));
            var vietNamName = FileProcess.LoadTable("select VietnamName from Employees where employees.EmployeeID=" + this._note.SupervisorID).Rows[0][0];
            this.txtVietnamName.Text = Convert.ToString(vietNamName);
        }

        private void LkeCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.lkeCustomerID.EditValue = e.Value;
            if (Convert.ToInt32(lkeCustomerID.EditValue) == 0)
                return;
            this.txtCustomerName.Text = lkeCustomerID.GetColumnValue("CustomerName").ToString();
            this._note.CustomerID = Convert.ToInt32(lkeCustomerID.GetColumnValue("CustomerID"));
            this._note.CustomerNumber = lkeCustomerID.GetColumnValue("CustomerNumber").ToString();
            this._note.CustomerName = lkeCustomerID.GetColumnValue("CustomerName").ToString();
        }

        private void SetEnabled(bool isEnabled)
        {
            this.txtCustomerRefNumber.Enabled = isEnabled;
            this.txtOccurLocation.Enabled = isEnabled;
            this.txtRepresentativePosition.Enabled = isEnabled;
            this.txtVehicleNumber.Enabled = isEnabled;
            this.dtNoteDate.Enabled = isEnabled;
            this.txtCustomerRepresentative.Enabled = isEnabled;
            this.dtOccurTime.Enabled = isEnabled;
            this.lkeCustomerID.Enabled = isEnabled;
            this.cbxOrderType.Enabled = isEnabled;
            this.lkeSupervisor.Enabled = isEnabled;
        }

        #region Load Data
        private void LoadNotes()
        {
            DataProcess<ST_WMS_LoadNotes_Result> noteData = new DataProcess<ST_WMS_LoadNotes_Result>();
            this._note = noteData.Executing("ST_WMS_LoadNotes @OrderType = {0}, @OrderNumber = {1}", this._orderType, this.OrderNumber).FirstOrDefault();
        }

        private void InitCustomers()
        {
            this.lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
            this.lkeCustomerID.Properties.ValueMember = "CustomerID";
            this.lkeCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lkeCustomerID.EditValue = this.customerIDSelected;
        }

        private void InitSupervisor()
        {
            DataProcess<ST_WMS_LoadSupervisorData_Result> supervisorData = new DataProcess<ST_WMS_LoadSupervisorData_Result>();
            this.lkeSupervisor.Properties.DataSource = supervisorData.Executing("ST_WMS_LoadSupervisorData");
            this.lkeSupervisor.Properties.ValueMember = "EmployeeID";
            this.lkeSupervisor.Properties.DisplayMember = "EmployeeID";
        }

        private void InitOrderType()
        {
            var source = new List<string>();

            source.Add("RO");
            source.Add("DO");
            source.Add("Other");

            this.cbxOrderType.Properties.Items.AddRange(source);
        }

        //<summary>
        //Bind data if note for this Order already exists
        //</summary>
        private void BindNotes()
        {
            this.txtVietnamName.Text = string.Empty;
            this.txtNoteID.Text = this._note.NoteID.ToString();
            this.txtCreatedBy.Text = this._note.CreatedBy;
            this.txtCreatedTime.Text = this._note.CreatedTime.ToString("dd/MM/yyyy HH:mm");
            this.txtOrderNumber.Text = this._note.OrderNumber.ToString();
            this.txtOccurLocation.Text = this._note.OccurLocation;
            this.txtVehicleNumber.Text = this._note.VehicleNumber;
            this.txtCustomerRepresentative.Text = this._note.CustomerRepresentative;
            this.txtRepresentativePosition.Text = this._note.RepresentativePosition;
            this.mmeNoteDescription.Text = this._note.NoteDescription;
            this.txtCustomerRefNumber.Text = this._note.CustomerRefNumber;
            this.lkeCustomerID.EditValue = this._note.CustomerID;
            this.lkeSupervisor.EditValue = this._note.SupervisorID;
            this.dtNoteDate.EditValue = this._note.NoteDate;
            this.dtOccurTime.EditValue = this._note.OccurTime;
            this.cbxOrderType.Text = this._note.OrderType;
            CloseUpEventArgs eventArgs = new CloseUpEventArgs(this.lkeCustomerID.EditValue);
            CloseUpEventArgs eventArgsSuppervior = new CloseUpEventArgs(this.lkeSupervisor.EditValue);
            this.LkeCustomerID_CloseUp(null, eventArgs);
            this.LkeSupervisor_CloseUp(null, eventArgsSuppervior);

            // Check confirm
            if (this._note.Confirmed)
            {
                SetEnabled(false);
            }
            else
            {
                SetEnabled(true);
            }
        }

        //<summary>
        //
        //</summary>
        private void SetData()
        {
            this._isAddNew = true;
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == this.customerIDSelected).FirstOrDefault();
            System.Data.DataTable specialRequirement = null;
            if (this._orderType.Equals("RO"))
            {
                specialRequirement = FileProcess.LoadTable("select VehicleNumber + ' | ' + SpecialRequirement AS specialRequirement from ReceivingOrders where ReceivingOrderID=" + this.OrderNumber);
            }
            else
            {
                specialRequirement = FileProcess.LoadTable("select  VehicleNumber + ' | ' + SpecialRequirement AS specialRequirement from dispatchingOrders where dispatchingOrderID=" + this.OrderNumber);
            }

            if (specialRequirement != null && specialRequirement.Rows.Count > 0)
            {
                this._noteDescription = Convert.ToString(specialRequirement.Rows[0][0]);
            }
            this._note = new ST_WMS_LoadNotes_Result();
            this._note.CreatedBy = AppSetting.CurrentUser.LoginName;
            this._note.CreatedTime = DateTime.Now;
            this._note.OrderNumber = this.OrderNumber;
            this._note.OrderType = this._orderType;
            this._note.Confirmed = false;
            this._note.OccurLocation = "Kho lạnh Kỷ Nguyên Mới";
            this._note.OccurTime = DateTime.Now;
            this._note.NoteDescription = this._noteDescription;
            this._note.VehicleNumber = this.vehicleNumber;
            this._note.CustomerID = customer.CustomerID;
            this._note.CustomerName = customer.CustomerName;
            this._note.CustomerNumber = customer.CustomerNumber;
            this._note.NoteDate = DateTime.Now;
            this.BindNotes();
            if (this._note.NoteID <= 0)
            {
                CloseUpEventArgs eventArgs = new CloseUpEventArgs(this.lkeCustomerID.EditValue);
                this.LkeCustomerID_CloseUp(null, eventArgs);
                this.LkeCustomerID_Leave(null, null);
            }
        }
        #endregion

        #region Events
        private void DtOccurTime_Leave(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                if (dtOccurTime.IsModified)
                {
                    UpdateNote();
                }
            }
        }

        private void DtNoteDate_Leave(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                if (dtNoteDate.IsModified)
                {
                    UpdateNote();
                }
            }
        }

        private void LkeSupervisor_Leave(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                if (lkeSupervisor.IsModified)
                {
                    UpdateNote();
                }
            }
        }

        private void LkeCustomerID_Leave(object sender, EventArgs e)
        {
            if (!this._isAddNew)
            {
                if (lkeCustomerID.IsModified)
                {
                    UpdateNote();
                }
            }
            else
            {
                this._isAddNew = false;
                var currentNoteInsert = GetNoteData();
                this._noteData.Insert(currentNoteInsert);
                this._note.NoteID = currentNoteInsert.NoteID;
                this.BindNotes();
            }
        }

        private void lkeSupervisor_EditValueChanged(object sender, System.EventArgs e)
        {
            //UpdateNote();
        }

        private void lkeCustomerID_EditValueChanged(object sender, System.EventArgs e)
        {
        }

        private void txtVehicleNumber_Leave(object sender, EventArgs e)
        {
            TextEdit edit = sender as TextEdit;
            this._note.VehicleNumber = txtVehicleNumber.Text;
            this._note.CustomerRepresentative = txtCustomerRepresentative.Text;
            this._note.RepresentativePosition = txtRepresentativePosition.Text;
            this._note.OccurLocation = txtOccurLocation.Text;
            this._note.CustomerRepresentative = txtCustomerRepresentative.Text;
            this._note.CustomerRefNumber = txtCustomerRefNumber.Text;
            if (!this._isAddNew)
            {
                if (edit.IsModified)
                {
                    UpdateNote();
                }
            }
        }

        private void dtOccurTime_EditValueChanged(object sender, EventArgs e)
        {
            this._note.OccurTime = dtOccurTime.DateTime;
        }

        private void dtNoteDate_EditValueChanged(object sender, EventArgs e)
        {
            this._note.NoteDate = dtNoteDate.DateTime;
            if (this._isFirstLoad || this._isAddNew)
            {
                return;
            }
        }

        #endregion

        #region Public methods
        public bool ConfirmNote(string loginName)
        {
            if (String.IsNullOrEmpty(mmeNoteDescription.Text))
            {
                XtraMessageBox.Show("Please enter the description of the Note !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mmeNoteDescription.Focus();
                return false;
            }

            if (lkeCustomerID.EditValue == null)
            {
                XtraMessageBox.Show("Please enter the Customer of the Note !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.lkeCustomerID.Focus();
                return false;
            }

            this._note.Confirmed = true;
            this._note.ConfirmedBy = loginName;
            this._note.ConfirmTime = DateTime.Now;

            this._noteData.Update(GetNoteData());
            SetEnabled(false);
            return true;
        }

        public void UpdateNote()
        {
            try
            {
                if (this._note.NoteID == 0)
                {
                    SetData();
                }
                else
                {
                    this._noteData.Update(GetNoteData());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreviewReport(bool isPreview)
        {
            this.UpdateNote();
            rptNotes reportNote = new rptNotes();
            reportNote.DataSource = FileProcess.LoadTable("ST_WMS_LoadReportNoteData @NoteID =" + Convert.ToInt32(txtNoteID.Text));
            reportNote.Parameters["Barcode"].Value = this._orderType.ToString() + this.OrderNumber.ToString("D9");
            reportNote.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(reportNote);
            printTool.AutoShowParametersPanel = false;
            if (isPreview)
            {
                printTool.ShowPreviewDialog();
            }
            else
            {
                printTool.Print();
                printTool.Print();
            }

        }

        public void RefreshNote(string orderType, int orderNumber, int customerID)
        {
            this._orderType = orderType;
            this.OrderNumber = orderNumber;
            this.customerIDSelected = customerID;

            LoadNotes();

            if (this._note == null)
            {
                SetData();
            }
            else
            {
                BindNotes();
            }

        }

        public void DeleteNote()
        {
            int result = this._noteData.ExecuteNoQuery("Delete From Notes Where NoteID = {0}", this._note.NoteID);
            this.RefreshNote(this._orderType, this.OrderNumber, this.customerIDSelected);
        }
        #endregion

        private Notes GetNoteData()
        {
            Notes note = new Notes();
            note.NoteID = this._note.NoteID;
            note.Confirmed = this._note.Confirmed;
            note.ConfirmedBy = this._note.ConfirmedBy;
            note.ConfirmTime = this._note.ConfirmTime;
            note.CreatedBy = this._note.CreatedBy;
            note.CreatedTime = this._note.CreatedTime;
            note.CustomerID = this._note.CustomerID;
            note.CustomerName = this._note.CustomerName;
            note.CustomerNumber = this._note.CustomerNumber;
            note.CustomerRefNumber = this._note.CustomerRefNumber;
            note.CustomerRepresentative = this._note.CustomerRepresentative;
            note.DocumentFolder = this._note.DocumentFolder;
            note.NoteDate = this._note.NoteDate;
            note.NoteDescription = this._note.NoteDescription;
            note.VehicleNumber = this._note.VehicleNumber;
            note.OccurLocation = this._note.OccurLocation;
            note.OccurTime = this._note.OccurTime;
            note.OrderNumber = this._note.OrderNumber;
            note.OrderType = this._note.OrderType;
            note.RepresentativePosition = this._note.RepresentativePosition;
            note.SupervisorID = this._note.SupervisorID;
            note.VehicleNumber = this._note.VehicleNumber;

            return note;
        }

        private void mmeNoteDescription_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(mmeNoteDescription.Text) && this.mmeNoteDescription.IsModified)
            {
                this._note.NoteDescription = this.mmeNoteDescription.Text;
            }
        }

        private void btn_WM_Delete_Click(object sender, EventArgs e)
        {
            this.DeleteNote();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.PreviewReport(true);
        }

        private void btn_WM_Print_Click(object sender, EventArgs e)
        {
            this.PreviewReport(false);
        }

        private void btn_WM_ViewFile_Click(object sender, EventArgs e)
        {

        }

        private void btn_WM_Confirm_Click(object sender, EventArgs e)
        {
            this.ConfirmNote(AppSetting.CurrentUser.LoginName);
            this.txt_WM_ConfirmedBy.Text = AppSetting.CurrentUser.LoginName;
            this.txt_WM_ConfirmedTime.EditValue = DateTime.Now;
            this.btn_WM_Confirm.Enabled = false;
            this.btn_WM_Delete.Enabled = false;
        }
    }
}
