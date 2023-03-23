﻿using System;
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
    public partial class frm_WM_Dialog_PalletInfor_ProductionDate : frmBaseForm
    {
        bool m_isResultOK = false;
        string m_CustomerRef = "";
        int m_ROID = 0;

        public frm_WM_Dialog_PalletInfor_ProductionDate()
        {
            InitializeComponent();

            Set_Event();
        }

        public frm_WM_Dialog_PalletInfor_ProductionDate(string i_CustomerRef, int i_ROID)
        {
            InitializeComponent();

            this.m_CustomerRef = i_CustomerRef;

            this.m_ROID = i_ROID;

            Set_Event();
        }

        void Frm_WM_Dialog_BreakPallet_Load(object sender, EventArgs e)
        {
            textEdit_ROID.Text = m_ROID.ToString();

            if (string.IsNullOrEmpty(m_CustomerRef))
            {
                try
                {
                    textEdit_CustomerRef.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                catch { }
                
            }
            else
            {
                try
                {
                    textEdit_CustomerRef.Text = Convert.ToDateTime(m_CustomerRef).ToString("dd/MM/yyyy");
                }
                catch { }
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