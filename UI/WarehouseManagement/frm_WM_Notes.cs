using Common.Controls;
using DA;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Notes : frmBaseForm
    {
        private DataRow currentNote = null;
        private DataRowCollection noteList = null;
        private bool firstBind = true;
        private DataProcess<Notes> noteDataProcess = new DataProcess<Notes>();
        private bool newMode = false;
        public frm_WM_Notes()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            loadNoteList();
            bindData();
            alwaysInvisible();
            enableOrNot();
        }

        private void enableOrNot()
        {
            bool confirmed = Convert.ToBoolean(currentNote["Confirmed"].ToString());
            if (confirmed)
            {
                // Confirmed, can't edit
                dtDate.Enabled = false;
                txtOrderNumber.Enabled = false;
                txtCustomerRep.Enabled = false;
                txtPosition.Enabled = false;
                txtRefNumber.Enabled = false;
                dtDateAndTime.Enabled = false;
                txtWhere.Enabled = false;
                txtContTruckNo.Enabled = false;
                txtDescription.Enabled = false;
                btnConfirm.Enabled = false;
                btnDelete.Enabled = false;
                btnBrowse.Enabled = false;
                txtDocumentFolder.Enabled = false;
                lkeCustomerID.Enabled = false;
                lkeOrderType.Enabled = false;
                lkeSupervisor.Enabled = false;
                btnGotoOrder.Enabled = false;
            }
            else
            {
                // Not confirm yet, can edit
                dtDate.Enabled = true;
                txtOrderNumber.Enabled = true;
                txtCustomerRep.Enabled = true;
                txtPosition.Enabled = true;
                txtRefNumber.Enabled = true;
                dtDateAndTime.Enabled = true;
                txtWhere.Enabled = true;
                txtContTruckNo.Enabled = true;
                txtDescription.Enabled = true;
                btnConfirm.Enabled = true;
                btnDelete.Enabled = true;
                btnBrowse.Enabled = true;
                txtDocumentFolder.Enabled = true;
                lkeCustomerID.Enabled = true;
                lkeOrderType.Enabled = true;
                lkeSupervisor.Enabled = true;
                btnGotoOrder.Enabled = true;
            }
        }

        private void alwaysInvisible()
        {
            txtNoteID.Enabled = false;
            txtCreated.Enabled = false;
            dtCreated.Enabled = false;
            txtCustomerNuber.Enabled = false;
            txtCustomerName.Enabled = false;
            txtSupervisorName.Enabled = false;
            txtConfirmTime.Enabled = false;
            txtConfirmedBy.Enabled = false;
        }

        private void bindData()
        {
            if (firstBind)
            {
                setCustomerIDData();
                setSupervisorData();
                setOrderTypeData();
                firstBind = false;
            }
            else
            {
                lkeSupervisor.EditValue = Convert.IsDBNull(currentNote["SupervisorID"]) ? (int?)null : Convert.ToInt32(currentNote["SupervisorID"]);
                //lkeSupervisor.Text = currentNote["SupervisorID"].ToString();
                lkeCustomerID.EditValue = Convert.ToInt32(currentNote["CustomerID"].ToString());
                //lkeCustomerID.Text = currentNote["CustomerID"].ToString();
                lkeOrderType.EditValue = currentNote["OrderType"].ToString();
                //lkeOrderType.Text = currentNote["OrderType"].ToString();
            }

            // Set value for all Textbox and DateEdit
            txtNoteID.Text = currentNote["NoteID"].ToString();
            dtDate.EditValue = Convert.ToDateTime(currentNote["NoteDate"]);
            //dtDate.Text = Convert.ToDateTime(currentNote["NoteDate"]).ToString("M/d/yyyy");
            txtCreated.Text = currentNote["CreatedBy"].ToString();
            dtCreated.EditValue = Convert.ToDateTime(currentNote["CreatedTime"]);
            //dtCreated.Text = Convert.ToDateTime(currentNote["CreatedTime"]).ToString("dd/MM/yy hh:mm");
            txtCustomerNuber.Text = currentNote["CustomerNumber"].ToString();
            txtCustomerName.Text = currentNote["CustomerName"].ToString();
            txtOrderNumber.Text = currentNote["OrderNumber"].ToString();
            txtCustomerRep.Text = Convert.IsDBNull(currentNote["CustomerRepresentative"]) ? null : currentNote["CustomerRepresentative"].ToString();
            txtPosition.Text = Convert.IsDBNull(currentNote["RepresentativePosition"]) ? null : currentNote["RepresentativePosition"].ToString();
            txtRefNumber.Text = Convert.IsDBNull(currentNote["CustomerRefNumber"]) ? null : currentNote["CustomerRefNumber"].ToString();
            dtDateAndTime.EditValue = Convert.ToDateTime(currentNote["OccurTime"]);
            //dtDateAndTime.Text = Convert.ToDateTime(currentNote["OccurTime"]).ToString("M/d/yyyy h:mm:ss");
            txtWhere.Text = currentNote["OccurLocation"].ToString();
            txtContTruckNo.Text = currentNote["VehicleNumber"].ToString();
            txtSupervisorName.Text = currentNote["VietnamName"].ToString();
            txtDescription.Text = currentNote["NoteDescription"].ToString();
            txtConfirmTime.Text = Convert.IsDBNull(currentNote["ConfirmTime"]) ? null : currentNote["ConfirmTime"].ToString();
            txtConfirmedBy.Text = Convert.IsDBNull(currentNote["ConfirmedBy"]) ? null : currentNote["ConfirmedBy"].ToString();
            txtDocumentFolder.Text = Convert.IsDBNull(currentNote["DocumentFolder"]) ? null : currentNote["DocumentFolder"].ToString();

            //// Set value for lkePalletStatus
            //lkePalletStatus.EditValue = currentQuarantine.PalletStatus.ToString();
            //lkePalletStatus.Text = currentQuarantine.PalletStatus.ToString();
        }

        private void loadNoteList()
        {
            // Load notes of last month
            string queryString = "SELECT Notes.*, Employees.VietnamName, Customers.StoreID " +
                                 "FROM(Notes LEFT JOIN Employees ON Notes.SupervisorID = Employees.EmployeeID) INNER JOIN Customers ON Notes.CustomerID = Customers.CustomerID " +
                                 "WHERE(((Customers.StoreID) = " + AppSetting.StoreID + ") AND((Notes.NoteDate) > GetDate() - 60)); ";

            DataTable dataSource = FileProcess.LoadTable(queryString);
            noteList = dataSource.Rows;

            dtNavigatorService.DataSource = dataSource;
            currentNote = noteList[noteList.Count - 1];
            dtNavigatorService.Position = noteList.Count;
        }

        private void setOrderTypeData()
        {
            // Set items for lkeOrderType
            var list = new List<string>();
            list.Add("RO");
            list.Add("DO");
            list.Add("Other");
            lkeOrderType.Properties.DataSource = list;
            lkeOrderType.EditValue = "RO";
        }

        private void setSupervisorData()
        {
            // FIXME: Execute null
            // Set items for lkeSupervisor
            string queryString = "SELECT Employees.EmployeeID, Employees.VietnamName "
            + "FROM Employees INNER JOIN Positions ON Employees.PositionID = Positions.PositionID "
            + "WHERE (((Positions.ManagementLevel)=7 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true')) "

            + "OR (((Positions.ManagementLevel)=30 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true')) "

            + "OR (((Positions.ManagementLevel)=13 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true')) "

            + "OR (((Positions.ManagementLevel)=10 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true'))"
            //hung 17/09/2018

            + "OR (((Positions.ManagementLevel)=5 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true'))"

            + "OR (((Positions.ManagementLevel)=15 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true'))"

            + "OR (((Positions.ManagementLevel)=2 and StoreID=" + AppSetting.StoreID + ") "
            + "AND ((Employees.Active)='true'))";

            DataTable dataSource = FileProcess.LoadTable(queryString);
            lkeSupervisor.Properties.DataSource = dataSource;
            if (!string.IsNullOrEmpty(Convert.ToString(currentNote["SupervisorID"])))
            {
                lkeSupervisor.EditValue = Convert.ToInt32(currentNote["SupervisorID"]);
            }
        }

        private void setCustomerIDData()
        {
            // Set items for lkeCustomerID
            lkeCustomerID.Properties.DataSource = AppSetting.CustomerList;
            lkeCustomerID.EditValue = Convert.ToInt32(currentNote["CustomerID"]);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtNavigatorService_PositionChanged(object sender, EventArgs e)
        {
            currentNote = noteList[dtNavigatorService.Position];
            bindData();
            enableOrNot();
        }

        private void lkeCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            int selectedID = Convert.ToInt32(lkeCustomerID.EditValue);
            updateCustomerInfo(selectedID);
            if (newMode)
            {
                // Run addNewNote function
                int result = addNewNote();
                if (result <= 0)
                {
                    MessageBox.Show("Insert fail !", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                newMode = false;
                // Refresh informations
                loadNoteList();
            }
        }

        private int addNewNote()
        {
            Notes newNote = new Notes();
            setValForInserNoteOrUpdateNote(newNote);
            newNote.Confirmed = false;
            return noteDataProcess.Insert(newNote);
        }

        private void updateCustomerInfo(int selectedID)
        {
            // Find this customer
            Customers customer = AppSetting.CustomerList.Where(c => c.CustomerID == selectedID).FirstOrDefault();
            if (customer == null) return;
            txtCustomerNuber.Text = customer.CustomerNumber;
            txtCustomerName.Text = customer.CustomerName;
        }

        private void lkeSupervisor_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkeSupervisor.EditValue == null) return;
            int selectedID = Convert.ToInt32(lkeSupervisor.EditValue);
            updateSupervisorInfo(selectedID);
        }

        private void updateSupervisorInfo(int selectedID)
        {
            // Find this supervisor
            DataProcess<Employees> dataProcess = new DataProcess<Employees>();
            var employee = dataProcess.Select(em => em.EmployeeID == selectedID).FirstOrDefault();
            txtSupervisorName.Text = employee.VietnamName;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtDescription == null || txtDescription.Text == null || txtDescription.Text == "")
            {
                MessageBox.Show("Please enter the description of the Note !", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lkeCustomerID == null || lkeCustomerID.EditValue == null)
            {
                MessageBox.Show("Please enter the Customer of the Note !", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            form_Current();
        }

        private void form_Current()
        {
            int noteID = Int32.Parse(txtNoteID.Text);

            Notes updateNote = noteDataProcess.Select(n => n.NoteID == noteID).FirstOrDefault();
            // Set update filed values
            setValForInserNoteOrUpdateNote(updateNote);
            updateNote.Confirmed = true;
            int result = noteDataProcess.Update(updateNote);
            // 
            if (result <= 0)
            {
                MessageBox.Show("Cannot confirm this note!", "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Refresh control values
                int currentPos = dtNavigatorService.Position;
                loadNoteList();
                dtNavigatorService.Position = currentPos;
            }
        }

        private void setValForInserNoteOrUpdateNote(Notes updateNote)
        {
            updateNote.NoteDate = Convert.ToDateTime(dtDate.EditValue);
            updateNote.OrderNumber = Convert.ToInt32(txtOrderNumber.Text);
            updateNote.CustomerRepresentative = txtCustomerRep.Text;
            updateNote.RepresentativePosition = txtPosition.Text;
            updateNote.CustomerRefNumber = txtRefNumber.Text;
            updateNote.OccurTime = Convert.ToDateTime(dtDateAndTime.EditValue);
            updateNote.OccurLocation = txtWhere.Text;
            updateNote.VehicleNumber = txtContTruckNo.Text;
            updateNote.NoteDescription = txtDescription.Text;
            updateNote.ConfirmTime = DateTime.Now;
            updateNote.ConfirmedBy = AppSetting.CurrentUser.LoginName;
            updateNote.CustomerID = Convert.ToInt32(lkeCustomerID.EditValue);
            updateNote.CustomerName = txtCustomerName.Text;
            updateNote.CustomerNumber = txtCustomerNuber.Text;
            updateNote.DocumentFolder = txtDocumentFolder.Text;
            updateNote.OrderType = lkeOrderType.EditValue.ToString();
            updateNote.OrderNumber = Convert.ToInt32(txtOrderNumber.Text);
            updateNote.CreatedTime = Convert.ToDateTime(dtCreated.EditValue);
            updateNote.CreatedBy = txtCreated.Text;
            updateNote.SupervisorID = Convert.ToInt32(lkeSupervisor.EditValue);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            txtDocumentFolder.Text = System.IO.Path.GetFullPath(openFileDialog.FileName);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetDataForInsert();
        }

        private void resetDataForInsert()
        {
            newMode = true;

            txtNoteID.Text = "AutoNumber";
            dtDate.EditValue = DateTime.Now;
            txtCreated.Text = AppSetting.CurrentUser.LoginName;
            lkeOrderType.EditValue = "RO";
            dtDateAndTime.EditValue = DateTime.Now.ToString("M/d/yyyy h:mm:ss");
            txtWhere.Text = "Kho lạnh Swire Việt Nam";

            dtDate.Enabled = true;
            txtOrderNumber.Enabled = true;
            txtCustomerRep.Enabled = true;
            txtPosition.Enabled = true;
            txtRefNumber.Enabled = true;
            dtDateAndTime.Enabled = true;
            txtWhere.Enabled = true;
            txtContTruckNo.Enabled = true;
            txtDescription.Enabled = true;
            btnConfirm.Enabled = true;
            btnDelete.Enabled = true;
            btnBrowse.Enabled = true;
            txtDocumentFolder.Enabled = true;
            lkeOrderType.Enabled = true;
            lkeSupervisor.Enabled = true;
            lkeCustomerID.Enabled = true;
            lkeCustomerID.Focus();
            lkeCustomerID.ShowPopup();
        }

        private void btnViewFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtDocumentFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong hyperLink! Detail: " + ex, "WMS-2022",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete a record(s).\n"
                + "If you click Yes, you won't be able to undo this Delete operation.\n"
                + "Do you sure to delete these records ?", "WMS-2022",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                deleteThisNote(Convert.ToInt32(txtNoteID.Text));
            }

        }

        private void deleteThisNote(int noteID)
        {
            Notes found = noteDataProcess.Select(n => n.NoteID == noteID).FirstOrDefault();
            if (found != null)
            {
                // int result = noteDataProcess.Delete(found);
                int result = noteDataProcess.ExecuteNoQuery("DELETE FROM Notes WHERE NoteID = " + noteID);
                if (result <= 0)
                {
                    MessageBox.Show("Cannot delete this note!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Refresh navigator
                    loadNoteList();
                }
            }
            else
            {
                MessageBox.Show("Cannot find this note!", "WMS-2022",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPreviewNote_Click(object sender, EventArgs e)
        {
            rptNotes rpt = new rptNotes();
            int noteID = Int32.Parse(txtNoteID.Text);
            //rpt.DataSource = noteDataProcess.Select(n => n.NoteID == noteID);
            rpt.DataSource = FileProcess.LoadTable("STNotes " + noteID);
            rpt.Parameters["Barcode"].Value = currentNote["OrderType"].ToString() + Convert.ToInt32(currentNote["OrderNumber"]).ToString("D9");
            rpt.RequestParameters = false;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            rptNotes rpt = new rptNotes();
            int noteID = Int32.Parse(txtNoteID.Text);
            
            rpt.DataSource = FileProcess.LoadTable("STNotes "+ noteID);
            rpt.Parameters["Barcode"].Value = currentNote["OrderType"].ToString() + Convert.ToInt32(currentNote["OrderNumber"]).ToString("D9");
            rpt.RequestParameters = false;
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.Print();
        }

        private void btnGotoOrder_Click(object sender, EventArgs e)
        {
            frm_WM_ReceivingOrders.Instance.Show();

        }
    }
}
