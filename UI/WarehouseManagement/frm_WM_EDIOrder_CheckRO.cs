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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_EDIOrder_CheckRO : Form
    {
        public frm_WM_EDIOrder_CheckRO(int ReceivingOrderID)
        {
            InitializeComponent();
            this.grcEDI_Order_CheckRO.DataSource = FileProcess.LoadTable("STEDI_Order_Check_RO " + ReceivingOrderID);
        }
    }
}
