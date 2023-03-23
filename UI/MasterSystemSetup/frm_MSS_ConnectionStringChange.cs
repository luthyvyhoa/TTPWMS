using DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ConnectionStringChange : Common.Controls.frmBaseForm
    {
        public frm_MSS_ConnectionStringChange()
        {
            InitializeComponent();
            setEvent();
        }
        string[] split = new string[20];
        string strShow = "";
        DataTable dt = null;
        void setEvent()
        {
            
            split = getConnectionString().Split(';');
            strShow = split[1].ToString() + ";" + split[2].ToString() + ";" + split[3].ToString() + ";" + split[5].ToString();
            initListDB();

        }

        void initListDB()
        {
            dt = FileProcess.LoadTable("SELECT Name,'" + strShow + "' as ConnectionString, 'WMS-2012' as Years FROM sys.databases where name like '%SwireDB%'");
            this.lkeNewConnectionString.Properties.DataSource = dt;
            this.lkeNewConnectionString.Properties.DisplayMember = "Name";
            this.lkeNewConnectionString.Properties.ValueMember = "Name";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SwireDBEntities"].ConnectionString;
        }

        private void frm_MSS_ConnectionStringChange_Load(object sender, EventArgs e)
        {
            
            mmConnectionString.Text = strShow;
        }

        private void lkeNewConnectionString_EditValueChanged(object sender, EventArgs e)
        {
            mmConnectionInfo.Text = strShow;
        }

        private void btnOpenMainForm_Click(object sender, EventArgs e)
        {
            //Open main form
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            if (!TestConnection(lkeNewConnectionString.GetColumnValue("Name").ToString()))
            {
                MessageBox.Show("Server has STOPPED! Please choose other server!");
                return;
            }
            else
            {
                btnOpenMainForm.PerformClick();
            }
        }
        private bool TestConnection(string DBReplace)
        {
            string cnnStr = getConnectionString().Replace("SwireDB", DBReplace);
            EntityConnectionStringBuilder b = new EntityConnectionStringBuilder();
            ConnectionStringSettings entityConString = new ConnectionStringSettings("newConnect",cnnStr);
            b.ConnectionString = entityConString.ConnectionString;
            string providerConnectionString = b.ProviderConnectionString;

            SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder();
            conStringBuilder.ConnectionString = providerConnectionString;
            conStringBuilder.ConnectTimeout = 1;
            string constr = conStringBuilder.ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private void btnChangeDefault_Click(object sender, EventArgs e)
        {
            frm_MSS_DefaultDatabaseChange fr = new frm_MSS_DefaultDatabaseChange(dt);
            fr.ShowDialog();
        }
    }
}
