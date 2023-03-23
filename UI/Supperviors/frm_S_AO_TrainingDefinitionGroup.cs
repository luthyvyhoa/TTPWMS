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

namespace UI.Supperviors
{
    public partial class frm_S_AO_TrainingDefinitionGroup : Common.Controls.frmBaseForm
    {
        TrainingGroupDefinition trainningGroup = null;
        DataProcess<TrainingGroupDefinition> trainningGroupDA = new DataProcess<TrainingGroupDefinition>();
        BindingList<TrainingGroupDefinition> Lst_Main = null;
       


        public event EventHandler setActiveReLoad = null;

        public void OnActiveControl(EventArgs e)
        {
            EventHandler handler = this.setActiveReLoad;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public frm_S_AO_TrainingDefinitionGroup()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            this.Lst_Main = new BindingList<TrainingGroupDefinition>(this.trainningGroupDA.Select().ToList());
            grcTraniningDefinitionGroup.DataSource = this.Lst_Main;
        }

        private void grvTranningDefinitionGroup_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            
            this.trainningGroup = this.grvTraniningDefinitionGroup.GetRow(e.RowHandle) as TrainingGroupDefinition;
           // this.trainningGroupDA.Insert(trainningGroup);
        }

        private void grvTraniningDefinitionGroup_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.trainningGroup = this.grvTraniningDefinitionGroup.GetRow(e.RowHandle) as TrainingGroupDefinition;
        }

        private void grvTraniningDefinitionGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.trainningGroup == null) return;
            if (this.trainningGroup.TrainingGroupDefinitionID == 0)
            {
                //Insert
                if (!this.InsertData(this.trainningGroup))
                {
                    MessageBox.Show("Error: insert data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Update
                if (!this.UpdateData(this.trainningGroup))
                {
                    MessageBox.Show("Error: update data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.trainningGroup = null;
        }
        private void grcTraniningDefinitionGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TrainingGroupDefinition trainingGroupDefinition = this.grvTraniningDefinitionGroup.GetRow(this.grvTraniningDefinitionGroup.FocusedRowHandle) as TrainingGroupDefinition;
                if (trainingGroupDefinition == null) return;

                string msg = string.Format("Delete {0}: {1} \nAre you sure ?", "TrainingGroupDefinition ID", trainingGroupDefinition.TrainingGroupDefinitionID);
                DialogResult dia = MessageBox.Show(msg, "Infomation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.No) return;

                if (!this.DeleteData(trainingGroupDefinition))
                {
                    //error
                    MessageBox.Show("Error!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Lst_Main.Remove(trainingGroupDefinition);
                }
            }
        }
        public bool InsertData(TrainingGroupDefinition trainingGroupDefinition)
        {
            int i = new DataProcess<TrainingGroupDefinition>().Insert(trainingGroupDefinition);
            return i > 0;
        }
        public bool UpdateData(TrainingGroupDefinition trainingGroupDefinition)
        {
            int i = new DataProcess<TrainingGroupDefinition>().Update(trainingGroupDefinition);
            return i > 0;
        }
        public bool DeleteData(TrainingGroupDefinition trainingGroupDefinition)
        {
            int i = trainningGroupDA.ExecuteNoQuery("delete from TrainingGroupDefinitions where TrainingGroupDefinitionID={0}",trainingGroupDefinition.TrainingGroupDefinitionID);
            return i > 0;
        }

        private void btn_Close_PossitionSytem_Click(object sender, EventArgs e)
        {
            this.grvTraniningDefinitionGroup.ClearSelection();
            this.grvTraniningDefinitionGroup.FocusedRowHandle = 1;
            this.grvTraniningDefinitionGroup.SelectRow(1);
            OnActiveControl(e);
            this.Close();
            // Raise event
            //Common.Process.RefreshData.OnReloadData(sender, e);
        }
    }
}
