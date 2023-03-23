using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using DA;
using System;

namespace UI.WarehouseManagement
{
    public partial class urc_WM_DODetail : UserControl
    {
        private DispatchingProducts _dp;
        private DataProcess<ST_WMS_LoadDODetailsBreakData_Result> _doDetailBreaks;

        public urc_WM_DODetail(DispatchingProducts dp)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._dp = dp;
            this._doDetailBreaks = new DataProcess<ST_WMS_LoadDODetailsBreakData_Result>();
        }

        #region Properties
        public event EventHandler ReloadData;
        #endregion

        private void urc_WM_DODetail_Load(object sender, System.EventArgs e)
        {
            LoadDOBreaks();
        }

        #region Load Data
        private void LoadDOBreaks()
        {
            BindingList<ST_WMS_LoadDODetailsBreakData_Result> listDODetailBreaks = new BindingList<ST_WMS_LoadDODetailsBreakData_Result>(this._doDetailBreaks.Executing("ST_WMS_LoadDODetailsBreakData @DispatchingOrderID = {0}", this._dp.DispatchingOrderID).ToList());
            this.grdDispatchingOrderDetailBreak.DataSource = listDODetailBreaks;
        }
        #endregion

        public void ReloadDOBreaks()
        {
            LoadDOBreaks();
        }

        private void rpi_chk_IsBreak_CheckedChanged(object sender, System.EventArgs e)
        {
            int currentDODetailID = Convert.ToInt32(this.grvDispatchingOrderDetailBreak.GetRowCellValue(this.grvDispatchingOrderDetailBreak.FocusedRowHandle, this.grvDispatchingOrderDetailBreak.Columns["DispatchingOrderDetailID"]));
            DataProcess<DispatchingOrderDetails> dispatchingOrderDetailsDA = new DataProcess<DispatchingOrderDetails>();
            DispatchingOrderDetails doDetails = dispatchingOrderDetailsDA.Select(d => d.DispatchingOrderDetailID == currentDODetailID).FirstOrDefault();
            doDetails.CheckBreak = ((DevExpress.XtraEditors.CheckEdit)sender).Checked;
            dispatchingOrderDetailsDA.Update(doDetails);
            this.ReloadDOBreaks();
            if (this.ReloadData != null)
            {
                this.ReloadData(sender, e);
            }
        }

        private void grvDispatchingOrderDetailBreak_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("QuantityOfPackages") || e.Column.FieldName.Equals("PalletID"))
            {

                int currentDODetailID = Convert.ToInt32(this.grvDispatchingOrderDetailBreak.GetRowCellValue(this.grvDispatchingOrderDetailBreak.FocusedRowHandle, this.grvDispatchingOrderDetailBreak.Columns["DispatchingOrderDetailID"]));
                short quantity = short.Parse(this.grvDispatchingOrderDetailBreak.GetRowCellValue(this.grvDispatchingOrderDetailBreak.FocusedRowHandle, this.grvDispatchingOrderDetailBreak.Columns["QuantityOfPackages"]).ToString());
                int palletID = Convert.ToInt32(this.grvDispatchingOrderDetailBreak.GetRowCellValue(this.grvDispatchingOrderDetailBreak.FocusedRowHandle, this.grvDispatchingOrderDetailBreak.Columns["PalletID"]));
                DataProcess<DispatchingOrderDetails> dispatchingOrderDetailsDA = new DataProcess<DispatchingOrderDetails>();
                DispatchingOrderDetails doDetails = dispatchingOrderDetailsDA.Select(d => d.DispatchingOrderDetailID == currentDODetailID).FirstOrDefault();
                doDetails.QuantityOfPackages = quantity;
                doDetails.PalletID = palletID;
                try
                {
                    dispatchingOrderDetailsDA.Update(doDetails);
                    this.ReloadDOBreaks();
                    if (this.ReloadData != null)
                    {
                        this.ReloadData(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
