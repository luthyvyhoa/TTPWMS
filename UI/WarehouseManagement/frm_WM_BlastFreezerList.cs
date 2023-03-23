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

namespace UI.WarehouseManagement
{
    public partial class frm_WM_BlastFreezerList : frmBaseForm
    {
        BindingList<BlastFreezers> lstBlastFreezer;
        public frm_WM_BlastFreezerList()
        {
            InitializeComponent();
            LoadData(0);
        }
        private void LoadData(int room=0)
        {
            DataProcess<BlastFreezers> blastFreezersDA = new DataProcess<BlastFreezers>();
            DateTime comparedTimeValue = DateTime.Now.AddDays(-31);     
            try
            {
                if(room==0)
                {
                  lstBlastFreezer = new BindingList<BlastFreezers>( blastFreezersDA.Executing("SELECT BlastFreezers.*,StoreID FROM dbo.BlastFreezers Left JOIN Customers ON BlastFreezers.CustomerID=Customers.CustomerID WHERE DateIn > GETDATE() - 31 and StoreID=" + (int)AppSetting.CurrentUser.StoreID).ToList());
                }
                else
                {
                  lstBlastFreezer = new BindingList<BlastFreezers>(blastFreezersDA.Executing("SELECT BlastFreezers.*,StoreID FROM dbo.BlastFreezers Left JOIN Customers ON BlastFreezers.CustomerID=Customers.CustomerID WHERE DateIn > GETDATE() - 31 and BlastFreezerRoomID=" + room + " and StoreID=" + (int)AppSetting.CurrentUser.StoreID).ToList());
                }

                grcBFList.DataSource = lstBlastFreezer;
               }
            catch
            {

            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex==0)
            {
                LoadData(0);
            }
            if (radioGroup1.SelectedIndex == 1)
            {
                LoadData(1);
            }
            if (radioGroup1.SelectedIndex == 2)
            {
                LoadData(2);
            }
        }

        private void rpe_chck_IsAttachment_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void rpe_link_DoubleClick(object sender, EventArgs e)
        {
           
                frm_WM_BlastFreezers frm =  frm_WM_BlastFreezers.GetInstance();
                frm.FindBlastFreezer(grvBFList.GetFocusedRowCellValue("BlastFreezerRecordNumber").ToString());
               // frm.Dispose();
                frm.Show();
            
        }
    }
}
