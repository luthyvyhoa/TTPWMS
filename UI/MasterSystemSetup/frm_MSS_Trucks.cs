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
    public partial class frm_MSS_Trucks : frmBaseForm
    {
        Truck truck = null;
        DataProcess<Truck> truckDA = new DataProcess<Truck>();
        BindingList<Truck> Lst_Main = null;
        public frm_MSS_Trucks()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            this.Lst_Main = new BindingList<Truck>(this.truckDA.Select().ToList());
            grcTruck.DataSource = this.Lst_Main;
        }
        private void grvTruck_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.truck = this.grvTruck.GetRow(e.RowHandle) as Truck;
        }
        private void grvTruck_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.truck = this.grvTruck.GetRow(e.RowHandle) as Truck;
        }

        private void grvTruck_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.truck == null) return;
            if (this.truck.TruckID == 0)
            {
                //Insert
                if (!this.InsertData(this.truck))
                {
                    MessageBox.Show("Error: insert data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Update
                if (!this.UpdateData(this.truck))
                {
                    MessageBox.Show("Error: update data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.truck = null;
        }

        private void grvTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Truck t = this.grvTruck.GetRow(this.grvTruck.FocusedRowHandle) as Truck;
                if (t == null) return;

                string msg = string.Format("Delete {0}: {1} \nAre you sure ?", "TrainingGroupDefinition ID", t.TruckID);
                DialogResult dia = MessageBox.Show(msg, "Infomation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.No) return;

                if (!this.DeleteData(t))
                {
                    //error
                    MessageBox.Show("Error!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Lst_Main.Remove(t);
                }
            }
        }

        public bool InsertData(Truck t)
        {
            t.CreateTime = DateTime.Now;
            t.CreateBy = AppSetting.CurrentUser.LoginName;
            int i = new DataProcess<Truck>().Insert(t);
            return i > 0;
        }
        public bool UpdateData(Truck t)
        {
            if (t.ChillFrozen != null)
            {
                t.ChillFrozen = t.ChillFrozen.ToUpper();
                if (t.ChillFrozen.Length > 1)
                {
                    MessageBox.Show("Error! Value one char", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            
            int i = new DataProcess<Truck>().Update(t);
            return i > 0;
        }
        public bool DeleteData(Truck t)
        {
            int i = truckDA.ExecuteNoQuery("delete from Trucks where TruckID={0}", t.TruckID);
            return i > 0;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
