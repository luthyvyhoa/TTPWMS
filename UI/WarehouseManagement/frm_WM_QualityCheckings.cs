using DA;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_QualityCheckings : Common.Controls.frmBaseForm
    {
        private DataProcess<QualityCheckings> _qcDA;
        private BindingList<QualityCheckings> _listQC;
        private QualityCheckings _currentQC;
        private bool _isModified;

        public frm_WM_QualityCheckings()
        {
            InitializeComponent();
            this.dtFrom.EditValue = DateTime.Now.AddYears(-1);
            this.dtTo.EditValue = DateTime.Now;
            this._qcDA = new DataProcess<QualityCheckings>();
            this._currentQC = new QualityCheckings();
            this._isModified = false;
        }

        private void frm_WM_QualityCheckings_Load(object sender, EventArgs e)
        {
            LoadQC();
            SetEnabled();
            SetEvents();
        }

        private void SetEvents()
        {
            this.grvQualityCheckDetail.KeyDown += GrvQualityCheckDetail_KeyDown;
            this.rpi_hpl_Reference.Click += Rpi_hpl_Reference_Click;
            this.grvQualityCheckDetail.CellValueChanged += GrvQualityCheckDetail_CellValueChanged;
            this.dtQCDate.EditValueChanged += DtQCDate_EditValueChanged;
            this.dtQCDate.Leave += ControlLeave;
            this.mmeRemark.EditValueChanged += MmeRemark_EditValueChanged;
            this.mmeRemark.Leave += ControlLeave;
            this.nvtQualityCheck.PositionChanged += NvtQualityCheck_PositionChanged;
            this.btnConfirm.MouseUp += BtnConfirm_MouseUp;
            this.btnConfirm.CheckedChanged += BtnConfirm_CheckedChanged;
            this.btnReport.Click += BtnReport_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnNote.Click += BtnNote_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void GrvQualityCheckDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!this._currentQC.Confirmed)
                {
                    int[] selectedRows = this.grvQualityCheckDetail.GetSelectedRows();

                    foreach (int row in selectedRows)
                    {
                        int detailID = Convert.ToInt32(this.grvQualityCheckDetail.GetRowCellValue(row, "QualityCheckingDetailID"));
                        if (!Convert.ToBoolean(this.grvQualityCheckDetail.GetRowCellValue(row, "CheckingPassed")))
                        {
                            int result = this._qcDA.ExecuteNoQuery("Delete From QualityCheckingDetails Where QualityCheckingDetailID = {0}", detailID);
                        }
                        else
                        {
                            XtraMessageBox.Show("Can not delete checked service !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    LoadQCDetail();
                }
            }
        }

        private void Rpi_hpl_Reference_Click(object sender, EventArgs e)
        {
            string orderNumber = Convert.ToString(this.grvQualityCheckDetail.GetFocusedRowCellValue("ReferenceNumber"));
            int orderID = Convert.ToInt32(orderNumber.Substring(3));

            if (orderNumber.Substring(0, 2).Equals("RO"))
            {
                frm_WM_ReceivingOrders.Instance.ReceivingOrderIDFind = orderID;
                frm_WM_ReceivingOrders.Instance.Show();
            }
            else
            {
                var frmDispatching = frm_WM_DispatchingOrders.GetInstance(orderID);
                if (frmDispatching.Visible)
                {
                    frmDispatching.ReloadData();
                }
                frmDispatching.Show();
            }
        }

        private void GrvQualityCheckDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int detailID = Convert.ToInt32(this.grvQualityCheckDetail.GetFocusedRowCellValue("QualityCheckingDetailID"));
            int result = -2;

            switch (e.Column.FieldName)
            {
                case "QuantityOfPackages":
                    {
                        decimal weightPerPackage = Convert.ToDecimal(this.grvQualityCheckDetail.GetFocusedRowCellValue("WeightPerPackage"));
                        short inner = Convert.ToInt16(this.grvQualityCheckDetail.GetFocusedRowCellValue("Inners"));
                        int newQty = Convert.ToInt32(e.Value);

                        int newUnits = newQty * inner;
                        float newWeight = (float)(newQty * weightPerPackage);

                        result = this._qcDA.ExecuteNoQuery("Update QualityCheckingDetails Set QuantityOfPackages = " + newQty + ", TotalUnits = " + newUnits + ", TotalWeight = " + newWeight + " Where QualityCheckingDetailID = " + detailID);
                        break;
                    }
                case "CheckingPassed":
                    {
                        result = this._qcDA.ExecuteNoQuery("Update QualityCheckingDetails Set CheckingPassed = {0}, CheckedBy = {1} Where QualityCheckingDetailID = {2}", Convert.ToBoolean(e.Value), AppSetting.CurrentUser.LoginName, detailID);
                        break;
                    }
                case "CheckingQuantity":
                    {
                        result = this._qcDA.ExecuteNoQuery("Update QualityCheckingDetails Set CheckingQuantity = " + Convert.ToInt32(e.Value) + ", CheckedBy = '" + AppSetting.CurrentUser.LoginName + "' Where QualityCheckingDetailID = " + detailID);
                        break;
                    }
                case "CheckingDetailRemark":
                    {
                        result = this._qcDA.ExecuteNoQuery("Update QualityCheckingDetails Set CheckingDetailRemark = '" + Convert.ToString(e.Value) + "', CheckedBy = '" + AppSetting.CurrentUser.LoginName + "' Where QualityCheckingDetailID = " + detailID);
                        break;
                    }
            }

            if (result != -2)
            {
                LoadQCDetail();
            }
        }

        private void DtQCDate_EditValueChanged(object sender, EventArgs e)
        {
            this._isModified = true;
            this._currentQC.QualityCheckingDate = this.dtQCDate.DateTime;
        }

        private void MmeRemark_EditValueChanged(object sender, EventArgs e)
        {
            this._isModified = true;
            this._currentQC.QualityCheckingRemark = this.mmeRemark.Text;
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            if (this._isModified)
            {
                this._isModified = false;
                int result = this._qcDA.Update(this._currentQC);
            }
        }

        private void NvtQualityCheck_PositionChanged(object sender, EventArgs e)
        {
            this._currentQC = this._listQC[this.nvtQualityCheck.Position];
            BindData();
            LoadQCDetail();
        }

        private void BtnConfirm_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.grvQualityCheckDetail.RowCount <= 0)
            {
                XtraMessageBox.Show("Can not confirm empty order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnConfirm.Toggle();
            }
        }

        private void BtnConfirm_CheckedChanged(object sender, EventArgs e)
        {
            this._currentQC.Confirmed = this.btnConfirm.Checked;

            if (this._currentQC.Confirmed)
            {
                this._currentQC.ConfirmedBy = AppSetting.CurrentUser.LoginName;
                this._currentQC.ConfirmedTime = DateTime.Now;
            }
            else
            {
                this._currentQC.ConfirmedBy = null;
                this._currentQC.ConfirmedTime = null;
            }
            int result = this._qcDA.Update(this._currentQC);

            if (result != -2)
            {
                SetEnabled();
            }
            else
            {
                XtraMessageBox.Show("Update failed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadQC();
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (!this._currentQC.Confirmed)
            {
                XtraMessageBox.Show("Printing Note requires the Qualaity Checking Job to be confirmed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            rptQualityCheckingFDTD rpt = new rptQualityCheckingFDTD(this.dtFrom.DateTime, this.dtTo.DateTime);
            rpt.DataSource = FileProcess.LoadTable("SELECT Products.ProductNumber, Products.ProductName, QualityCheckingDetails.QuantityOfPackages, QualityCheckingDetails.TotalUnits, QualityCheckingDetails.TotalWeight, QualityCheckingDetails.CheckingDetailRemark, QualityCheckingDetails.CheckingPassed, QualityCheckingDetails.ReferenceNumber, QualityCheckings.QualityCheckingDate, QualityCheckings.QualityCheckingID, QualityCheckings.StartTime, QualityCheckings.EndTime, QualityCheckings.CreatedBy, QualityCheckings.Confirmed, QualityCheckings.ConfirmedBy, QualityCheckings.ConfirmedTime, QualityCheckings.QualityCheckingRemark, Customers.CustomerNumber, Customers.CustomerName, QualityCheckingDetails.CheckingQuantity " +
                                                   "FROM((QualityCheckings INNER JOIN QualityCheckingDetails ON QualityCheckings.QualityCheckingID = QualityCheckingDetails.QualityCheckingID) INNER JOIN Products ON QualityCheckingDetails.ProductID = Products.ProductID) INNER JOIN Customers ON Products.CustomerID = Customers.CustomerID " +
                                                   "WHERE(((QualityCheckings.QualityCheckingDate)Between '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "' And '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "')); ");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.grvQualityCheckDetail.RowCount > 0)
            {
                XtraMessageBox.Show("Please delete the details before delete this Checking Order !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int result = this._qcDA.ExecuteNoQuery("Delete From QualityCheckings Where QualityCheckingID = " + this._currentQC.QualityCheckingID);
                LoadQC();
            }
        }

        private void BtnNote_Click(object sender, EventArgs e)
        {
            if (!this._currentQC.Confirmed)
            {
                XtraMessageBox.Show("Printing Note requires the Qualaity Checking Job to be confirmed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            rptQualityCheckingNote rpt = new rptQualityCheckingNote();
            rpt.DataSource = FileProcess.LoadTable("SELECT Products.ProductNumber, Products.ProductName, QualityCheckingDetails.QuantityOfPackages, QualityCheckingDetails.TotalUnits, QualityCheckingDetails.TotalWeight, QualityCheckingDetails.CheckingDetailRemark, QualityCheckingDetails.CheckingPassed, QualityCheckingDetails.ReferenceNumber, QualityCheckings.QualityCheckingDate, QualityCheckings.QualityCheckingID, QualityCheckings.StartTime, QualityCheckings.EndTime, QualityCheckings.CreatedBy, QualityCheckings.Confirmed, QualityCheckings.ConfirmedBy, QualityCheckings.ConfirmedTime, QualityCheckings.QualityCheckingRemark, Customers.CustomerNumber, Customers.CustomerName, QualityCheckingDetails.CustomerRef, QualityCheckings.QualityCheckingRemark " +
                             "FROM((QualityCheckings INNER JOIN QualityCheckingDetails ON QualityCheckings.QualityCheckingID = QualityCheckingDetails.QualityCheckingID) INNER JOIN Products ON QualityCheckingDetails.ProductID = Products.ProductID) INNER JOIN Customers ON Products.CustomerID = Customers.CustomerID " +
                             "WHERE(((QualityCheckings.QualityCheckingID) = " + this._currentQC.QualityCheckingID + ")); ");
            ReportPrintToolWMS tool = new ReportPrintToolWMS(rpt);
            tool.ShowPreview();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Load Data
        private void LoadQC()
        {
            DateTime date = DateTime.Now.AddDays(-31);
            this._listQC = new BindingList<QualityCheckings>(this._qcDA.Select(q => q.QualityCheckingDate > date).ToList());
            this.nvtQualityCheck.DataSource = this._listQC;
            this.nvtQualityCheck.Position = this._listQC.Count;
            if (this._listQC.Count <= 0)
            {
                this._currentQC = new QualityCheckings();
            }
            else
            {
                this._currentQC = this._listQC[this.nvtQualityCheck.Position];
            }

            BindData();
            LoadQCDetail();
        }

        private void LoadQCDetail()
        {
            this.grdQualityCheckDetail.DataSource = FileProcess.LoadTable("SELECT QualityCheckingDetails.*, Products.ProductNumber, Products.ProductName, Products.WeightPerPackage, Products.Inners " +
                                                                          "FROM QualityCheckingDetails INNER JOIN Products ON QualityCheckingDetails.ProductID = Products.ProductID " +
                                                                          "Where QualityCheckingID = " + this._currentQC.QualityCheckingID);
            this.grvQualityCheckDetail.ClearSelection();

        }

        private void BindData()
        {
            this.txtQCID.Text = this._currentQC.QualityCheckingID.ToString();
            this.dtQCDate.EditValue = this._currentQC.QualityCheckingDate;
            this.txtCreatedBy.Text = this._currentQC.CreatedBy;
            this.txtCreatedTime.Text = this._currentQC.CreatedTime.ToString();
            this.mmeRemark.Text = this._currentQC.QualityCheckingRemark;
            if (this._currentQC.Confirmed)
            {
                this.btnConfirm.Checked = true;
                this.txtConfirmedBy.Text = this._currentQC.ConfirmedBy;
                this.txtConfirmedTime.Text = this._currentQC.ConfirmedTime.ToString();
            }
            else
            {
                this.btnConfirm.Checked = false;
            }
        }
        #endregion

        private void SetEnabled()
        {
            this.dtQCDate.ReadOnly = this._currentQC.Confirmed;
            this.mmeRemark.ReadOnly = this._currentQC.Confirmed;
            this.grvQualityCheckDetail.OptionsBehavior.ReadOnly = this._currentQC.Confirmed;
        }
    }
}
