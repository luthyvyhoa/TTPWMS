using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common.Controls;
using System.Data.Entity.Core.Objects;
using DA;
using DevExpress.XtraReports.UI;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Dialog_PalletInfor_LocationRemark : frmBaseForm
    {
        bool m_isResultOK = false;
        string m_Remark = "";
        int m_PalletID = 0;

        public frm_WM_Dialog_PalletInfor_LocationRemark()
        {
            InitializeComponent();

            Set_Event();
        }

        public frm_WM_Dialog_PalletInfor_LocationRemark(string i_Remark, int i_PalletID)
        {
            InitializeComponent();

            this.m_Remark = i_Remark;

            this.m_PalletID = i_PalletID;

            Set_Event();
        }

        void Frm_WM_Dialog_BreakPallet_Load(object sender, EventArgs e)
        {
            textEdit_ROID.Text = m_PalletID.ToString();
            if (string.IsNullOrEmpty(m_Remark))
            {
                textEdit_Infor.Text = "~";
            }
            else
            {
                textEdit_Infor.Text = m_Remark;
            }
        }

        void Frm_WM_Dialog_BreakPallet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_isResultOK == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        void Set_Event()
        {
            this.Load += Frm_WM_Dialog_BreakPallet_Load;
            this.FormClosing += Frm_WM_Dialog_BreakPallet_FormClosing;

            btn_Cancel.Click += Btn_Cancel_Click;
            btn_Ok.Click += Btn_Ok_Click;
        }

        void Btn_Ok_Click(object sender, EventArgs e)
        {
            m_isResultOK = true;
            this.Close();
        }

        void Btn_Cancel_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}