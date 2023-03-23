using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
namespace UI.WarehouseManagement
{
    public partial class frm_WM_BusinessTripPrice : frmBaseForm
    {
        private BindingList<BusinessTripPrices> dataSource = null;
        public frm_WM_BusinessTripPrice()
        {
            InitializeComponent();

            this.InitData();
        }

        private void InitData()
        {
            DataProcess<BusinessTripPrices> businessTripPriceDA = new DataProcess<BusinessTripPrices>();
            this.dataSource = new BindingList<BusinessTripPrices>(businessTripPriceDA.Executing("SELECT BusinessTripPrices.* FROM BusinessTripPrices ORDER BY BusinessTripPrices.BusinessTripPriceDate;").ToList());
            var newBusinessTripPrice = new BusinessTripPrices();
            newBusinessTripPrice.BusinessTripPriceDate = DateTime.Now;
            this.dataSource.Add(newBusinessTripPrice);
            this.grd_WM_BusinessTripPrice.DataSource = dataSource;
        }

        private void grv_WM_BusinessTripPrice_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                BusinessTripPrices businessTripPriceSeleceted = (BusinessTripPrices)this.grv_WM_BusinessTripPrice.GetRow(e.RowHandle);
                if (businessTripPriceSeleceted == null) return;

                DataProcess<BusinessTripPrices> businessTripPriceDA = new DataProcess<BusinessTripPrices>();
                if (businessTripPriceSeleceted.BusinessTripPriceID > 0)
                {
                    businessTripPriceDA.Update(businessTripPriceSeleceted);
                }
                else
                {
                    businessTripPriceSeleceted.CreatedBy = AppSetting.CurrentUser.LoginName;
                    businessTripPriceSeleceted.CreatedTime = DateTime.Now;
                    businessTripPriceDA.Insert(businessTripPriceSeleceted);

                    this.grv_WM_BusinessTripPrice.SetRowCellValue(this.grv_WM_BusinessTripPrice.RowCount, "BusinessTripPriceID", businessTripPriceSeleceted.BusinessTripPriceID);
                    var newBusinessTripPrice = new BusinessTripPrices();
                    newBusinessTripPrice.BusinessTripPriceDate = DateTime.Now;
                    this.dataSource.Add(newBusinessTripPrice);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grv_WM_BusinessTripPrice_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (this.grv_WM_BusinessTripPrice.GetRowCellValue(e.RowHandle, "Locked") == null) return;
            bool isLock = (bool)this.grv_WM_BusinessTripPrice.GetRowCellValue(e.RowHandle, "Locked");
            if (isLock)
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        private void grv_WM_BusinessTripPrice_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (this.grv_WM_BusinessTripPrice.FocusedRowHandle < 0) return;
            bool isLock = Convert.ToBoolean(this.grv_WM_BusinessTripPrice.GetRowCellValue(this.grv_WM_BusinessTripPrice.FocusedRowHandle, "Locked"));
            if (isLock)
                e.Cancel = true;
        }
    }
}
