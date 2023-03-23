using System;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using Common.Controls;
using DA;
using UI.Helper;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_CloseStock : frmBaseForm
    {
        private DataProcess<ClosedPeriods> _closedPeriodsData;
        private DateTime _lastToDate;
        private List<STConfirmationAll_Result> _listConfirmed;

        public frm_WM_CloseStock(List<STConfirmationAll_Result> data)
        {
            InitializeComponent();
            this._closedPeriodsData = new DataProcess<ClosedPeriods>();
            this._listConfirmed = data;
        }

        private void frm_WM_CloseStock_Load(object sender, EventArgs e)
        {
            //this.txtWeek.Text = ;
            Init(LoadData());
            SetEvents();
        }

        private void SetEvents()
        {
            this.btnClose.Click += btnClose_Click;
            this.btnOK.Click += btnOK_Click;
        }

        #region Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppSetting.CurrentUser.LevelOfAuthorization.Equals("Employee"))
                {
                    XtraMessageBox.Show("You are not allowed to update !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.dtFrom.DateTime.AddDays(-1) > this._lastToDate)
                {
                    XtraMessageBox.Show("Please close the previous period before this period", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (this.dtTo.DateTime < this._lastToDate)
                {
                    XtraMessageBox.Show("This period is already closed !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach(STConfirmationAll_Result item in this._listConfirmed)
                {
                    if(item.OrderDate >= dtFrom.DateTime && item.OrderDate <= dtTo.DateTime)
                    {
                        XtraMessageBox.Show("Please Confirm all orders for the closed period", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this._closedPeriodsData.ExecuteNoQuery("STCloseStock @varFromDate = {0}, @varToDate = {1}", this.dtFrom.DateTime, this.dtTo.DateTime);
                XtraMessageBox.Show("Stock is closed successful!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion


        private void Init(DateTime date)
        {
            this.dtFrom.EditValue = FirstMonday(date);
            this.dtTo.EditValue = this.dtFrom.DateTime.AddDays(6);
            this.txtYear.Text = this.dtFrom.DateTime.Year.ToString();
            this.txtWeek.Text = GetWeekNumber(this.dtFrom.DateTime).ToString();
        }

        private DateTime LoadData()
        {
            if(this._closedPeriodsData.Select().ToList().Count>0)
            {
                this._lastToDate = this._closedPeriodsData.Select().FirstOrDefault().ToDate.Value;
                return this._lastToDate.AddDays(3);
            }
            else
            {
                this._lastToDate = DateTime.Now.AddDays(3);
                return this._lastToDate;

            }

        }

        private DateTime FirstMonday(DateTime date)
        {
            while(date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            return date;
        }

        public int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            return weekNum;
        }
    }
}
