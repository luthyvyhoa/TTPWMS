using System;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_QuantitiesOfPrint : Form
    {
        int copy = 0;
        public int Qty
        {
            get
            {
                return copy;
            }
       
        }
        public frm_WM_QuantitiesOfPrint()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
                return;
            else
            {
                copy = Convert.ToInt32(txtQty.Text);
            }
            this.Close();
        }
    }
}
