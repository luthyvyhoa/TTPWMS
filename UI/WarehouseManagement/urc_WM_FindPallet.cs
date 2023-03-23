using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_FindPallet : UserControl
    {
        private int _filterMode;

        public urc_WM_FindPallet()
        {
            InitializeComponent();
            this._filterMode = 0;
        }

        private void SetEvents()
        {
            this.chkPalletID.CheckedChanged += chkPalletID_CheckedChanged;
            this.chkReference.CheckedChanged += chkReference_CheckedChanged;
            this.chkRemark.CheckedChanged += chkRemark_CheckedChanged;
        }

        private void chkRemark_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkRemark.Checked)
            {
                this.txtRemark.ReadOnly = false;
                this.txtRemark.Focus();
                this.chkPalletID.Checked = false;
                this.chkReference.Checked = false;
                this._filterMode = 2;
            }
            else
            {
                this.txtRemark.ReadOnly = true;
            }
        }

        private void chkReference_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkReference.Checked)
            {
                this.txtReference.ReadOnly = false;
                this.txtReference.Focus();
                this.chkPalletID.Checked = false;
                this.chkRemark.Checked = false;
                this._filterMode = 3;
            }
            else
            {
                this.txtReference.ReadOnly = true;
            }
        }

        private void chkPalletID_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPalletID.Checked)
            {
                this.txtPalletID.ReadOnly = false;
                this.txtPalletID.Focus();
                this.chkRemark.Checked = false;
                this.chkReference.Checked = false;
                this._filterMode = 1;
            }
            else
            {
                this.txtPalletID.ReadOnly = true;
            }
        }

        public void Find()
        {
            frm_WM_Dialog_LocationDetail frm;

            switch(this._filterMode)
            {
                case 1:
                    {
                        frm = new frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.txtPalletID.Text), 0,true);
                        frm.Show();
                        break;
                    }
                case 2:
                    {
                        frm = new frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.txtPalletID.Text), 1, this.txtRemark.Text, true);
                        frm.Show();
                        break;
                    }
                case 3:
                    {
                        frm = new frm_WM_Dialog_LocationDetail(Convert.ToInt32(this.txtPalletID.Text), 2, this.txtReference.Text, true);
                        frm.Show();
                        break;
                    }
            }
        }
    }
}
