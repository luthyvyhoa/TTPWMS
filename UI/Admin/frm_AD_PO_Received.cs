using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Controls;
using DA.Warehouse;
using UI.Helper;

namespace UI.Admin
{
    public partial class frm_AD_PO_Received : frmBaseFormNormal
    {
        private int PurchasingOrderID;
        public frm_AD_PO_Received(int _purchasingOrderID)
        {
            InitializeComponent();
            this.PurchasingOrderID = _purchasingOrderID;
            LoadParts();
            this.InitData();
        }
        private void LoadParts()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.rpi_lke_part.DataSource = context.GetComboStoreNo("SELECT DISTINCT Parts.PartID, Parts.PartName FROM Parts ORDER BY Parts.PartName");
                this.rpi_lke_part.DropDownRows = 20;
                this.rpi_lke_part.DisplayMember = "PartName";
                this.rpi_lke_part.ValueMember = "PartID";
            }
        }

        private void InitData()
        {
            using (PlantDBContext context2 = new PlantDBContext())
            {
                var ReceivedPartsInfo = context2.GetComboStoreNo($"SP_ReceivedByPusPurchasingOrder {this.PurchasingOrderID}");
                if (ReceivedPartsInfo != null && ReceivedPartsInfo.Rows.Count > 0)
                {
                    int PartReceivedID = Convert.ToInt32(ReceivedPartsInfo.Rows[0]["ReceivedPartID"]);
                    // init data partReceived
                    this.txtPartReceivedID.EditValue = Convert.ToInt32(ReceivedPartsInfo.Rows[0]["ReceivedPartID"]);
                    this.textPOID.EditValue = this.PurchasingOrderID;
                    this.dteOrderDate.EditValue = Convert.ToDateTime(ReceivedPartsInfo.Rows[0]["PuchasingDate"]);
                    this.dteDeliveryDate.EditValue = Convert.ToDateTime(ReceivedPartsInfo.Rows[0]["DeliveryDate"]);
                    this.txtOrderBy.EditValue = Convert.ToString(ReceivedPartsInfo.Rows[0]["OrderBy"]);
                    //this.lkeSupplier.EditValue= Convert.ToString(ReceivedPartsInfo.Rows[0]["PartReceivedID"]);
                    this.txtRemarks.EditValue = Convert.ToString(ReceivedPartsInfo.Rows[0]["PurchasingRemark"]);

                    // load details data
                    var ReceivedPartDetailsInfo = context2.GetComboStoreNo($"SP_LoadPurchasingOrderReceivedDetails @PartReceivedID={PartReceivedID}");
                    this.grcGoodReceived.DataSource = ReceivedPartDetailsInfo;
                }
            }
        }
        private void rpi_lke_part_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (selectedValue.GetColumnValue("PartName") != null)
            {
                if (this.rpi_lke_part.GetDataSourceRowByKeyValue(selectedValue.Text) == null) return;
                int varPartID = Convert.ToInt32(selectedValue.GetColumnValue("PartID"));
                string varPartname = selectedValue.GetColumnValue("PartName").ToString();

                //PurchasingOrderDetail pod = new PurchasingOrderDetail();
                //pod.PartID = varPartID;
                //pod.PartName = varPartname;

                this.grvReceivedParts.SetRowCellValue(this.grvReceivedParts.FocusedRowHandle, "PropertyCategoryID", varPartID);
                this.grvReceivedParts.SetRowCellValue(this.grvReceivedParts.FocusedRowHandle, "ItemRemark", varPartname);
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            using (PlantDBContext context2 = new PlantDBContext())
            {
                var ReceivedPartsInfo = context2.ExcecuteNoquery($"Update ReceivedParts set OrderConfirmed=1,ConfirmBy={AppSetting.CurrentUser.LoginName}" +
                    $" where ReceivedPartID={Convert.ToInt32(this.txtPartReceivedID.EditValue)}");
                this.Close();
            }
        }

        private void grvReceivedParts_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (this.grvReceivedParts.FocusedRowHandle < 0) return;
            int detailID = Convert.ToInt32(this.grvReceivedParts.GetRowCellValue(e.RowHandle, "PartReceivedDetailID"));
            using (PlantDBContext context2 = new PlantDBContext())
            {
                switch (e.Column.FieldName)
                {
                    case "DeliveryQuantity":
                        var ReceivedPartsInfo = context2.ExcecuteNoquery($"Update ReceivedPartDetails set DeliveryQuantity={e.Value} where PartReceivedDetailID={detailID}");
                        break;
                    case "PropertyCategoryID":
                        var partID = context2.ExcecuteNoquery($"Update ReceivedPartDetails set PropertyCategoryID={e.Value} where PartReceivedDetailID={detailID}");
                        break;
                    case "ItemRemark":
                        var partName = context2.ExcecuteNoquery($"Update ReceivedPartDetails set ItemRemark=N'{e.Value}' where PartReceivedDetailID={detailID}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
