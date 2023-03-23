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
    public partial class frm_S_AO_TrainingDefinitions : Common.Controls.frmBaseForm
    {
        TrainingDefinitions trainningDefinitions = null;
        DataProcess<TrainingDefinitions> trainningDA = new DataProcess<TrainingDefinitions>();
        DataProcess<TrainingGroupDefinition> trainningGroupDA = new DataProcess<TrainingGroupDefinition>();
        BindingList<TrainingDefinitions> Lst_Main = null;
        BindingList<TrainingGroupDefinition> Lst_MainGroup = null;

       
        public frm_S_AO_TrainingDefinitions(frm_S_AO_TrainingDefinitionGroup frm_S_AO_TrainingGroup)
        {
            InitializeComponent();
            LoadData();
            frm_S_AO_TrainingGroup.setActiveReLoad += RefreshData_ReloadDataEvent;
        }
        private void LoadData()
        {
            this.Lst_Main = new BindingList<TrainingDefinitions>(this.trainningDA.Select().ToList());
            grcTrainning.DataSource = this.Lst_Main;
            //Common.Process.RefreshData.ReloadDataEvent += RefreshData_ReloadDataEvent;
            InitTrainningGroup();
        }

        private void RefreshData_ReloadDataEvent(object sender, EventArgs e)
        {
            this.InitTrainningGroup();
        }

        private void InitTrainningGroup()
        {
            rpi_TrainningGroup.DataSource = null;
            this.Lst_MainGroup = new BindingList<TrainingGroupDefinition>(this.trainningGroupDA.Select().ToList());
            rpi_TrainningGroup.DataSource = this.Lst_MainGroup;
            rpi_TrainningGroup.DisplayMember = "TrainingGroupDescription";
            rpi_TrainningGroup.ValueMember = "TrainingGroupDefinitionID";
        }

        private void grvTrainning_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.trainningDefinitions = this.grvTrainning.GetRow(e.RowHandle) as TrainingDefinitions;
        }

        private void grvTrainning_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.trainningDefinitions = this.grvTrainning.GetRow(e.RowHandle) as TrainingDefinitions;
        }

        private void grvTrainning_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.trainningDefinitions == null) return;
            if (this.trainningDefinitions.TrainingDefinitionID == 0)
            {
                //Insert
                if (!this.InsertData(this.trainningDefinitions))
                {
                    MessageBox.Show("Error: insert data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Update
                if (!this.UpdateData(this.trainningDefinitions))
                {
                    MessageBox.Show("Error: update data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.trainningDefinitions = null;
            Common.Process.RefreshData.OnReloadData(sender, e);
        }

        private void grvTrainning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TrainingDefinitions trainingGroupDefinition = this.grvTrainning.GetRow(this.grvTrainning.FocusedRowHandle) as TrainingDefinitions;
                if (trainingGroupDefinition == null) return;

                string msg = string.Format("Delete {0}: {1} \nAre you sure ?", "TrainingDefinitions ID", trainingGroupDefinition.TrainingDefinitionID);
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
        public bool InsertData(TrainingDefinitions trainingGroupDefinition)
        {
            int i = new DataProcess<TrainingDefinitions>().Insert(trainingGroupDefinition);
            return i > 0;
        }
        public bool UpdateData(TrainingDefinitions trainingGroupDefinition)
        {
            int i = new DataProcess<TrainingDefinitions>().Update(trainingGroupDefinition);
            return i > 0;
        }
        public bool DeleteData(TrainingDefinitions trainingGroupDefinition)
        {
            int i = trainningDA.ExecuteNoQuery("delete from TrainingDefinitions where TrainingDefinitionID={0}", trainingGroupDefinition.TrainingDefinitionID);
            return i > 0;
        }

        private void btn_Close_PossitionSytem_Click(object sender, EventArgs e)
        {
            this.grvTrainning.ClearSelection();
            this.grvTrainning.FocusedRowHandle = 1;
            this.grvTrainning.SelectRow(1);
            this.Close();
        }
    }
}
