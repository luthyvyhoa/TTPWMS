using Common.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ChangeProductDate : frmBaseForm
    {
        #region Properties

        /// <summary>
        /// Gets or sets the changed date.
        /// </summary>
        /// <value>
        /// The changed date.
        /// </value>
        public DateTime ChangedDate => this.dateEditToDate.DateTime;

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string Reason => this.mmReason.Text;

        /// <summary>
        /// Gets or sets the on accept callback action.
        /// </summary>
        /// <value>
        /// The on accept callback action.
        /// </value>
        public Action<DateTime, string> OnAcceptCallbackAction { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="frm_WM_ChangeProductDate"/> class.
        /// </summary>
        public frm_WM_ChangeProductDate()
        {
            InitializeComponent();

            this.RegisterEvent();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="frm_WM_ChangeProductDate"/> class.
        /// </summary>
        /// <param name="dateOfRO">The date of RO.</param>
        public frm_WM_ChangeProductDate(DateTime dateOfRO) : this()
        {
            if (dateOfRO.Year == 1 && dateOfRO.Month == 1 && dateOfRO.Day == 1)
            {
                this.dateEditToDate.DateTime = DateTime.Now;

            }
            else
            {
                this.dateEditToDate.DateTime = dateOfRO;
            }
        }

        #endregion

        #region Event Register

        /// <summary>
        /// Registers the event.
        /// </summary>
        private void RegisterEvent()
        {
            this.btnAccept.Click += btnAccept_Click;
            this.btnClose.Click += btnClose_Click;
        }

        #endregion

        #region Command handling

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnAccept control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Reason))
            {
                this.mmReason.Focus();
                this.mmReason.ShowToolTips = true;
                return;
            }

            this.mmReason.ShowToolTips = false;
            this.Close();
            this.OnAcceptCallbackAction?.Invoke(this.ChangedDate, this.Reason);
        }

        #endregion
    }
}
