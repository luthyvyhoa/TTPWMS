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
    public partial class frm_WM_Dialog_BreakPallet : frmBaseForm
    {
        bool m_isResultOK = false;
        int m_OldQuatity = 0;
        int m_PalletID = 0;

        public frm_WM_Dialog_BreakPallet()
        {
            InitializeComponent();
        }

        public frm_WM_Dialog_BreakPallet(int i_oldQuatity, int i_palletID)
        {
            InitializeComponent();

            Set_Event();

            this.m_OldQuatity = i_oldQuatity;
            this.m_PalletID = i_palletID;
        }

        void Frm_WM_Dialog_BreakPallet_Load(object sender, EventArgs e)
        {
            textEditPalletID.Text = m_PalletID.ToString();

            spinEditOldQuantity.Value = m_OldQuatity;
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

            btnCancel.Click += BtnCancel_Click;
            btnBreak.Click += BtnBreak_Click;
        }

        void BtnBreak_Click(object sender, EventArgs e)
        {
            if (spinEditNewQuantity.Value <= 0)
            {
                XtraMessageBox.Show("Wrong quantity !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                DA.Warehouse.PalletDA da = new DA.Warehouse.PalletDA();
                ObjectParameter v_varnewPalletID = new ObjectParameter("varnewPalletID", 0);

                int result = da.STPalletBreakReturnNewPalletID(this.m_PalletID, Convert.ToInt16(spinEditNewQuantity.Value), UI.Helper.AppSetting.CurrentUser.LoginName, v_varnewPalletID);

                IList<STLabel1Label_Result> v_STLabel1Label_Result = (new DataProcess<STLabel1Label_Result>()).Executing("STLabel1Label  @PalletID = {0}", v_varnewPalletID.Value).ToList();

                if (XtraMessageBox.Show("Are you sure to print label? ", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var v_list = FileProcess.LoadTable("STLabel1Label @PalletID =" + (int)v_varnewPalletID.Value);
                        ReportFile.rptLabel_Barcode v_Report = new ReportFile.rptLabel_Barcode();
                        v_Report.Parameters["varCurrentUser"].Value = UI.Helper.AppSetting.CurrentUser.LoginName;
                        v_Report.DataSource = v_list;
                        v_Report.RequestParameters = false;
                        v_Report.Print();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                m_isResultOK = true;
                this.Close();

            }
        }

        void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}