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
    public partial class frm_WM_CheckPalletReturn : Form
    {
        public frm_WM_CheckPalletReturn()
        {
            InitializeComponent();
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.InitData();
        }

        private void InitData()
        {
            this.grdPalletReturnList.DataSource = FileProcess.LoadTable("STLoadPalletScanReturn");
        }

        private void grvPalletReturnList_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int status = Convert.ToInt32(this.grvPalletReturnList.GetRowCellValue(e.RowHandle, "Status"));
            if (status == 1) e.Appearance.BackColor = Color.LightGreen;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSearch = this.radioGroup1.SelectedIndex;
            layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            switch (indexSearch)
            {
                //All
                case 0:
                    this.grdPalletReturnList.DataSource = FileProcess.LoadTable("STLoadPalletScanReturn");
                    break;

                //Picking
                case 1:
                    var pickingSource = FileProcess.LoadTable("STLoadPalletScanReturn").Select("Status=0");
                    ConvertSource(pickingSource);
                    break;

                //Checked
                case 2:
                    var checkedSource = FileProcess.LoadTable("STLoadPalletScanReturn").Select("Status=1");
                    ConvertSource(checkedSource);
                    break;

                //DOID
                case 3:
                    layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
                default:
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDOID.Text)) return;
            var doSource = FileProcess.LoadTable("STLoadPalletScanReturn").Select("DOID='" + this.txtDOID.Text + "'");
            ConvertSource(doSource);
        }

        private void ConvertSource(DataRow[] dr)
        {
            if(dr.Length<=0)
            {
                this.grdPalletReturnList.DataSource = null;
                return;
            }

            DataTable newSource = dr.CopyToDataTable();
            this.grdPalletReturnList.DataSource = newSource;
        }

    }
}

