using Common.Controls;
using DA;
using DA.Warehouse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_Totes : frmBaseForm
    {
        DataTable dataSourceTote = null;
        public frm_WM_Totes()
        {
            InitializeComponent();
            LoadData();
            SetEvent();
        }
        public void SetEvent()
        {
            txtFromID.EditValueChanged += txtFromID_EditValueChanged;
            txtToID.EditValueChanged += txtFromID_EditValueChanged;
            txtToID.KeyDown += txtFromID_KeyDown;
            txtFromID.KeyDown += txtFromID_KeyDown;
        }
        DataProcess<Tote> totesDA = new DataProcess<Tote>();
        private void LoadData()
        {
            dataSourceTote= FileProcess.LoadTable("ST_WMS_LoadTotes");
            this.grcTotes.DataSource = dataSourceTote;
        }
        // create Tote
        private void btnCreateTotes_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotes.EditValue) > 500) {
                MessageBox.Show("Please input value <= 500 !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Tote tote = new Tote();
            tote.CreateBy = AppSetting.CurrentUser.LoginName;
            tote.CreateTime = DateTime.Now;
            int record = Convert.ToInt32(txtTotes.EditValue);
            if (record < 1 ) return;
            for (int i=0;i< record;i++)
            {
                totesDA.Insert(tote);
            }
            dataSourceTote = FileProcess.LoadTable("ST_WMS_LoadTotesNewInsert " + txtTotes.EditValue);
            this.grcTotes.DataSource = dataSourceTote;
        }
        // Update Tote
        private void grvTotes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName=="Remark")
            {
                totesDA.ExecuteNoQuery("UPDATE dbo.Totes SET Remark= {0} WHERE ToteNumber={1}",e.Value,grvTotes.GetFocusedRowCellValue("ToteNumber"));
            }
        }
        //Delete Tote
        private void grcTotes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                Int32[] selectedRowHandles = grvTotes.GetSelectedRows();
                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    int selectedRowHandle = selectedRowHandles[i];
                    if (selectedRowHandle >= 0)
                    {
                        string toteNumber = Convert.ToString(grvTotes.GetRowCellValue(selectedRowHandle, "ToteNumber")).Trim();
                        int result =totesDA.ExecuteNoQuery("Delete from totes where ToteNumber={0}", toteNumber);
                        if(result<0)
                        {
                            MessageBox.Show("Can not delete Tote " + toteNumber, "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }  
                }
                grvTotes.DeleteSelectedRows();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
                rptLabelTote rptTote = new rptLabelTote();
                rptTote.Parameters["parameter1"].Value = 3;
                rptTote.DataSource = dataSourceTote;
                rptTote.RequestParameters = false;
                
                ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptTote);
                printTool.AutoShowParametersPanel = false;
                printTool.ShowPreview();
        }
        //select Tote ID
        private void txtFromID_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataFT();
        }

        private void txtFromID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyCode.Equals(Keys.Enter)) return;
            LoadDataFT();
        }

        private void LoadDataFT()
        {
            if (txtToID.EditValue == null || txtFromID.EditValue == null) return;
            int from = Convert.ToInt32(txtFromID.EditValue);
            int to = Convert.ToInt32(txtToID.EditValue);
            if (from > to) return;
            dataSourceTote = FileProcess.LoadTable("ST_WMS_LoadTotesFDTD " + from + "," + to);
            this.grcTotes.DataSource = dataSourceTote;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrintBarcodes_Click(object sender, EventArgs e)
        {
            //Code here to generate barcoee data sources and then print the barcode
            rptLabel_BarcodeRandom rptBarCode = new rptLabel_BarcodeRandom();
            rptBarCode.RequestParameters = false;
            string sql = "ST_WMS_BarcodeRandomCreated " + this.textQtyBarcode.EditValue.ToString();
            rptBarCode.DataSource = FileProcess.LoadTable(sql);
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rptBarCode);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreviewDialog();
        }
    }
}
