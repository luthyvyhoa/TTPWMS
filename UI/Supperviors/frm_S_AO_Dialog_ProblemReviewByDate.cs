using DA;
using DevExpress.XtraEditors;
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

namespace UI.Supperviors
{
    public partial class frm_S_AO_Dialog_ProblemReviewByDate : Common.Controls.frmBaseForm
    {
        private DataTable _tbProblems;
        private byte _filterMode;

        public frm_S_AO_Dialog_ProblemReviewByDate(DateTime from, DateTime to)
        {
            InitializeComponent();
            this.dtFrom.EditValue = from;
            this.dtTo.EditValue = to;
            this.grvProblemReview.OptionsBehavior.ReadOnly = true;
            this._tbProblems = new DataTable();
            this._filterMode = 1;
            this.chkAll.Checked = true;
        }

        private void frm_S_AO_Dialog_ProblemReviewByDate_Load(object sender, EventArgs e)
        {
            this._tbProblems = FileProcess.LoadTable("STProblem_ReviewByDate @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "'");
            LoadProblems();
            SetEvents();
        }

        private void SetEvents()
        {
            this.rpi_hpl_InternalAuditID.DoubleClick += Rpi_hpl_InternalAuditID_DoubleClick;
            this.chkNotConfirm.EditValueChanging += CheckedChanging;
            this.chkAvailable.EditValueChanging += CheckedChanging;
            this.chkAll.EditValueChanging += CheckedChanging;
            this.chkNotConfirm.CheckedChanged += CheckedChanged;
            this.chkAvailable.CheckedChanged += CheckedChanged;
            this.chkAll.CheckedChanged += CheckedChanged;
            this.btnClose.Click += BtnClose_Click;
            this.btnDataRaw.Click += BtnDataRaw_Click;
        }

        private void Rpi_hpl_InternalAuditID_DoubleClick(object sender, EventArgs e)
        {
            int problemID = Convert.ToInt32(this.grvProblemReview.GetFocusedRowCellValue("InternalAuditID"));
            frm_S_AO_InternalAudits frm = new frm_S_AO_InternalAudits(problemID);
            frm.Show();
        }

        private void CheckedChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (!Convert.ToBoolean(e.NewValue))
            {
                if (this._filterMode == Convert.ToByte(edit.Tag))
                {
                    e.Cancel = true;
                }
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
            {
                byte prevFilterMode = this._filterMode;
                this._filterMode = Convert.ToByte(edit.Tag);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDataRaw_Click(object sender, EventArgs e)
        {
            this.grdDataRaw.DataSource = FileProcess.LoadTable("STProblem_DataRaw @FromDate = '" + this.dtFrom.DateTime.ToString("yyyy-MM-dd") + "', @ToDate = '" + this.dtTo.DateTime.ToString("yyyy-MM-dd") + "', @StoreID = " + AppSetting.StoreID);
            this.grvDataRaw.PopulateColumns();

            string pathSaveFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = pathSaveFile + "\\" + "Problem_DataRaw_" + DateTime.Now.ToString("dd_MM_yy") + ".xlsx";

            this.grvDataRaw.ExportToXlsx(fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void LoadProblems()
        {
            this.grdProblemReview.DataSource = this._tbProblems;
            this.txtTotal.Text = this._tbProblems.Rows.Count.ToString();
        }

        private void UnCheckPreviousFilter(byte lastFilter)
        {
            switch (lastFilter)
            {
                case 1:
                    {
                        this.chkAll.Checked = false;
                        break;
                    }
                case 2:
                    {
                        this.chkAvailable.Checked = false;
                        break;
                    }
                case 3:
                    {
                        this.chkNotConfirm.Checked = false;
                        break;
                    }
            }
        }

        private void FilterModeChanged()
        {
            switch (this._filterMode)
            {
                case 2:
                    {
                        this._tbProblems = FileProcess.LoadTable("STProblem_AvailableConfirm");
                        LoadProblems();
                        break;
                    }
                default:
                    {
                        this._tbProblems = FileProcess.LoadTable("STProblem_ReviewByDate @FromDate = null, @ToDate = null");
                        LoadProblems();
                        break;
                    }
            }
        }
    }
}
