using Common.Controls;
using DA;
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
    public partial class frm_S_PCO_EmployeeOTEdit : frmBaseForm
    {
        private SwireDBEntities context = new SwireDBEntities();
        private STEmployeeOTView_Result currentItem = new STEmployeeOTView_Result();
        private frm_S_PCO_EmployeeOTSupervisors callBack;
        public frm_S_PCO_EmployeeOTEdit()
        {
            InitializeComponent();
        }

        public frm_S_PCO_EmployeeOTSupervisors CallBack
        {
            get { return callBack; }
            set { callBack = value; }
        }

        public STEmployeeOTView_Result CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value; }
        }

        private void InitData()
        {
            InitTextEditData();
            InitLookupEditData();
            InitDateEditData();
            EnableQtyOrNot();
            txtEmployeeID.ReadOnly = true;
            txtEmployeeName.ReadOnly = true;
        }

        private void EnableQtyOrNot()
        {
            if (currentItem.DayStatus == "L" || currentItem.DayStatus == "H" || currentItem.DayStatus == "S" || currentItem.DayStatus == "O")
            {
                txtQty.Enabled = false;
                txtQty.Visible = false;
            }
            else
            {
                txtQty.Enabled = true;
                txtQty.Visible = true;
                txtQty.Text = currentItem.HourQuantity.ToString();
            }
        }

        private void InitDateEditData()
        {
            dtDate.EditValue = currentItem.EmployeeOTSupervisorDate;
        }

        private void InitLookupEditData()
        {
            List<string> list = new List<string>();
            list.Add("OTS");
            list.Add("OTN");
            list.Add("OTH");
            list.Add("H");
            list.Add("S");
            list.Add("L");
            list.Add("O");
            list.Add("XXX");
            lkeCheck.Properties.DataSource = list;
            lkeCheck.EditValue = currentItem.DayStatus;
        }

        private void InitTextEditData()
        {
            txtEmployeeID.Text = currentItem.EmployeeID.ToString();
            txtTimework.Text = currentItem.TimeWork;
            txtEmployeeName.Text = currentItem.VietnamName;
            txtRemark.Text = currentItem.Remarks;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //CurrentDb.QueryDefs("_qry_ActionResults").sql = "STEmployeeOTEdit " & Me.TextEmployeeOTSupervisorID & ",'" & Format(Me.TextDate, "yyyy-MM-dd") & "',0,N'" & Me.TextRemark & "', '" & Trim(Me.CboCheck) & "','" & CurrentUser() & "'"
            int varEmployeeOTSupervisorID = Convert.ToInt32(currentItem.EmployeeOTSupervisorID);
            DateTime varDate = Convert.ToDateTime(dtDate.EditValue);
            float varHourQty;
            try
            {
                varHourQty = float.Parse(txtQty.Text);
            }
            catch
            {
                varHourQty = 0;
            }
            string remarks = txtRemark.Text;
            string dayStatus = lkeCheck.EditValue.ToString();

            var dtm = FileProcess.LoadTable("STCheckOTHourByEmployeeByMonth @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "',@h=" + varHourQty);
            var h = Convert.ToInt32(dtm.Rows[0]["TotalHour"]);
            if (h + varHourQty > 30)
            {
                var confirm = MessageBox.Show("Tong so gio OT nhan vien nay trong thang > 30! [" + h + " + " + varHourQty + "], tiep tuc?", "Cham cong",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirm.Equals(DialogResult.No)) return;
            }

            var dtd = FileProcess.LoadTable("STCheckOTHourByEmployeeByDay @d='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy-MM-dd") + "',@e=" + txtEmployeeID.Text + ", @OT='" + lkeCheck.EditValue + "',@h=" + varHourQty);
            var hd = Convert.ToInt32(dtd.Rows[0]["TotalHour"]);
            if (hd + varHourQty > 4)
            {
                var confirmd = MessageBox.Show("Tong so gio OT nhan vien nay trong ngay > 4! [" + hd + " + " + varHourQty + "], tiep tuc?", "Cham cong",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmd.Equals(DialogResult.No)) return;
            }


            string varUser = AppSetting.CurrentUser.LoginName;
            byte flag = 1;
            int result = context.STEmployeeOTEdit(varEmployeeOTSupervisorID, varDate, varHourQty, remarks, dayStatus, varUser, flag);
            if (result <= 0)
            {
                MessageBox.Show("Fail to execute store STEmployeeOTEdit!", "WMS-2022",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            callBack.Requery();
            this.Close();
        }

        private void frm_S_PCO_EmployeeOTEdit_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
