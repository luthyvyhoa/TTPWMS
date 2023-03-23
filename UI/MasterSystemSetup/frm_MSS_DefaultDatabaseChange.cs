using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_DefaultDatabaseChange : Common.Controls.frmBaseForm
    {
        DataTable tbDatabase = new DataTable();
        public frm_MSS_DefaultDatabaseChange()
        {
            InitializeComponent();
        }
        public frm_MSS_DefaultDatabaseChange(DataTable dt)
        {
            InitializeComponent();
            tbDatabase = dt;
            this.repositoryItemCheckEditCurrent.CheckedChanged += repositoryItemCheckEditCurrent_CheckedChanged;
            this.repositoryItemCheckEditDefault.CheckedChanged += repositoryItemCheckEditDefault_CheckedChanged;
        }

        void repositoryItemCheckEditDefault_CheckedChanged(object sender, EventArgs e)
        {
            updateGridview("Default");
        }

        void repositoryItemCheckEditCurrent_CheckedChanged(object sender, EventArgs e)
        {
            updateGridview("Current");
        }
        private void updateGridview(string column)
        {
            DataRow dr = this.gridViewDatabaseInfo.GetDataRow(gridViewDatabaseInfo.FocusedRowHandle);
            tbDatabase = gridControlDatabaseInfo.DataSource as DataTable;
            foreach (DataRow item in tbDatabase.Rows)
            {
                if (item["Name"].ToString() != dr["Name"].ToString())
                {
                    item[column] = false;
                }
            }
            gridControlDatabaseInfo.DataSource = tbDatabase;
        }

        private void frm_MSS_DefaultDatabaseChange_Load(object sender, EventArgs e)
        {
            string strCon = ConfigurationManager.ConnectionStrings["SwireDBEntities"].ConnectionString;
            DataColumnCollection columns = tbDatabase.Columns;
            if (!columns.Contains("Default"))
            {
                tbDatabase.Columns.Add("Default", typeof(bool));
            }
            if (!columns.Contains("Current"))
            {
                tbDatabase.Columns.Add("Current", typeof(bool));
            }
            foreach (DataRow item in tbDatabase.Rows)
            {
                if (strCon.Contains(item["Name"].ToString()))
                {
                    item["Current"] = true;
                    item["Default"] = true;
                }
                else
                {
                    item["Current"] = false;
                    item["Default"] = false;
                }
            }
            this.gridControlDatabaseInfo.DataSource = tbDatabase;
        }
    }
}
