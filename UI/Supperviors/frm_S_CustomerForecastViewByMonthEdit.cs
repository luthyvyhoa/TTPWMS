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

namespace UI.Supperviors
{
    public partial class frm_S_CustomerForecastViewByMonthEdit : frmBaseForm
    {
        private DataProcess<object> DA = new DataProcess<object>();
        public frm_S_CustomerForecastViewByMonthEdit()
        {
            InitializeComponent();
        }
        int CustomerForecastiD;
        public frm_S_CustomerForecastViewByMonthEdit(int id, decimal value,string name)
        {
            InitializeComponent();
            txtValue.EditValue = Convert.ToString(value);
            lbName.Text = name;
            this.CustomerForecastiD = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                int result=DA.ExecuteNoQuery("Update  CustomerForecasts set DailyStockPallet={0} where CustomerForecastID={1}", Convert.ToDecimal(txtValue.EditValue), CustomerForecastiD);
                if(result<0)
                {
                    MessageBox.Show("Can''t Insert", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

            
            //Raise Envent 
            Common.Process.RefreshData.OnReloadData(sender, e);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}
