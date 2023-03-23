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

namespace UI.MasterSystemSetup
{
    public partial class Frm_MSS_RoomSetupEmployee : frmBaseForm
    {

        public Frm_MSS_RoomSetupEmployee()
        {
            InitializeComponent();
        }

        private void rbcbase_Click(object sender, EventArgs e)
        {

        }

        private void Frm_MSS_RoomSetupEmployee_Load(object sender, EventArgs e)
        {
            DataProcess<STRoomEmployeeSetup_Result> DA = new DataProcess<STRoomEmployeeSetup_Result>();
            BindingList<STRoomEmployeeSetup_Result> lis = new BindingList<STRoomEmployeeSetup_Result>(DA.Executing("STRoomEmployeeSetup @varStoreID = {0}", AppSetting.StoreID).ToList());
            this.grd_EmployeesList.DataSource = lis;


        }

        private void gv_EmployeesList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            LoadRoom();
        }
        private void LoadRoom()
        {
            try
            {
                int employessID = 0;
                employessID = Convert.ToInt32(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "EmployeeID"));

                string listRoom = Convert.ToString(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "ROOM"));
                DataProcess<STRoomByEmployee_Result> DA = new DataProcess<STRoomByEmployee_Result>();
                BindingList<STRoomByEmployee_Result> lis = new BindingList<STRoomByEmployee_Result>(DA.Executing("STRoomByEmployee @EmpID={0} , @varStoreID = {1} ,@varRoom={2}", employessID, AppSetting.StoreID, listRoom).ToList());
                this.grdRooms.DataSource = lis;
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void rpi_room_CheckStateChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit ck = (DevExpress.XtraEditors.CheckEdit)sender;
            int employessID = Convert.ToInt32(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "EmployeeID"));
            int roomID = Convert.ToInt32(this.grvRooms.GetRowCellValue(this.grvRooms.FocusedRowHandle, "RoomID"));
            string remark = Convert.ToString(this.grvRooms.GetRowCellValue(this.grvRooms.FocusedRowHandle, "AreaRemark"));
            int EmployeeAreaID = Convert.ToInt32(this.grvRooms.GetRowCellValue(this.grvRooms.FocusedRowHandle, "EmployeeAreaID"));

            DataProcess<STRoomByEmployee_Result> DA = new DataProcess<STRoomByEmployee_Result>();
            if (ck.Checked)
            {
                DA.ExecuteNoQuery("insert into EmployeeAreaResponsibities values ({0},{1},{2},{3})", employessID, roomID, remark, AppSetting.StoreID);
            }
            else
            {
                if (EmployeeAreaID != 0)
                {
                    DA.ExecuteNoQuery("delete from EmployeeAreaResponsibities where EmployeeAreaID={0} ", EmployeeAreaID);

                }

            }
            DataProcess<STRoomEmployeeSetup_Result> DA1 = new DataProcess<STRoomEmployeeSetup_Result>();
            BindingList<STRoomEmployeeSetup_Result> lis = new BindingList<STRoomEmployeeSetup_Result>(DA1.Executing("STRoomEmployeeSetup @varStoreID = {0}", AppSetting.StoreID).ToList());
            this.grd_EmployeesList.DataSource = lis;

            LoadRoom();


        }

        private void btnCheckall_Click(object sender, EventArgs e)
        {
            int employessID = Convert.ToInt32(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "EmployeeID"));
            if (employessID != 0)
            {
                DataProcess<STRoomByEmployee_Result> DA = new DataProcess<STRoomByEmployee_Result>();
                DA.ExecuteNoQuery("STRoomByEmployeeUpdateAll  @EmpID={0} , @varStoreID = {1}", employessID, AppSetting.StoreID); ;

            }
            LoadRoom();

        }

        private void grvRooms_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            if(e.Column.FieldName== "AreaRemark")
            {
                string remark = Convert.ToString(this.grvRooms.GetRowCellValue(this.grvRooms.FocusedRowHandle, "AreaRemark"));
                int EmployeeAreaID = Convert.ToInt32(this.grvRooms.GetRowCellValue(this.grvRooms.FocusedRowHandle, "EmployeeAreaID"));
                DataProcess<STRoomByEmployee_Result> DA = new DataProcess<STRoomByEmployee_Result>();
                DA.ExecuteNoQuery("update EmployeeAreaResponsibities set AreaRemark = {0} where EmployeeAreaID={1}", remark, EmployeeAreaID); ;
            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hpl_VietNamName_Click(object sender, EventArgs e)
        {
            int employessID = 0;
            employessID = Convert.ToInt32(this.gv_EmployeesList.GetRowCellValue(this.gv_EmployeesList.FocusedRowHandle, "EmployeeID"));
            frm_MSS_Employees frmEmpDetail = new frm_MSS_Employees(employessID);
            if (!frmEmpDetail.Enabled) return;
            frmEmpDetail.StartPosition = FormStartPosition.CenterScreen;
            frmEmpDetail.ShowInTaskbar = false;
            frmEmpDetail.ShowDialog(this);
            frmEmpDetail.WindowState = FormWindowState.Maximized;
        }
    }
}
