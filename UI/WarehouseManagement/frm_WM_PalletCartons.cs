using Common.Controls;
using Common.Logging;
using DA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_PalletCartons : frmBaseForm
    {
        DataProcess<STLabelPalletCartonWeight> multilabel = new DataProcess<STLabelPalletCartonWeight>();
        private static readonly ILog log = LogManager.GetLogger(typeof(frm_WM_PalletCartons));
        private int palletIDSelected = -1;
        private int accept = -1;
        private IList<PalletCartons> listData = null;
        private bool isNegativeValue = false;
        private int totalOriginalQuantity;
        private decimal damage = 0;
        private decimal percent = 0;
        private int roID = 0;
        private decimal _net = 0;
        private decimal? _gross = 0;
        public frm_WM_PalletCartons(int palletID, int accept, int totalQuantity, decimal? damage, decimal? percent, int roID, decimal net = 0, decimal? gross = 0)
        {
            InitializeComponent();
            this.totalOriginalQuantity = totalQuantity;
            this.palletIDSelected = palletID;
            this.roID = roID;
            this.accept = accept;
            this._net = net;
            this._gross = gross;
            if (damage != null)
                this.damage = (decimal)damage;
            if (percent != null)
                this.percent = (decimal)percent;
            if (this.accept >= 2)
            {
                this.grv_WM_PelletData.OptionsBehavior.Editable = false;
                this.btn_WM_Update.Enabled = false;
            }
            else
            {
                this.grv_WM_PelletData.OptionsBehavior.Editable = true;
                this.btn_WM_Update.Enabled = true;
            }
            if (accept > 0)
            {
                this.colDeleteColumn.OptionsColumn.AllowEdit = false;
                this.colDeleteColumn.OptionsColumn.AllowFocus = false;
            }
            else
            {
                this.colDeleteColumn.OptionsColumn.AllowEdit = true;
                this.colDeleteColumn.OptionsColumn.AllowFocus = true;
            }
        }

        private void frm_WM_PalletCartons_Load(object sender, System.EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            using (var context = new SwireDBEntities())
            {
                var dataPalletCarton = context.PalletCartons
                     .Join(context.Pallets, pc => pc.PalletID, p => p.PalletID, (pc, p) => new
                     {
                         pc,
                         p.Label,
                     })
                     .Where(dataSource => dataSource.pc.PalletID == this.palletIDSelected).ToList();

                if (dataPalletCarton == null) return;
                if (dataPalletCarton.Count() < 0) return;


                this.grd_WM_PelletData.DataSource = dataPalletCarton;
                DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
                var currentPallet = palletDA.Select(p => p.PalletID == this.palletIDSelected).FirstOrDefault();
                this.lbl_WM_PalletID.Text = this.palletIDSelected.ToString();
                this.lbl_WM_Location.Text = currentPallet.Label;
                this.listData = new List<PalletCartons>(dataPalletCarton.Select(pallect => pallect.pc));
            }
        }

        private void grv_WM_PelletData_KeyDown(object sender, KeyEventArgs e)
        {
            // Only process on PalletWeight column
            if (!this.grv_WM_PelletData.FocusedColumn.FieldName.Equals("pc.PalletWeight")) return;

            // Only process when Enter key press
            if (!e.KeyCode.Equals(Keys.Enter)) return;

            try
            {
                this.grv_WM_PelletData.MoveNext();
            }
            catch (Exception)
            {
            }
        }

        private void btn_WM_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_WM_Update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            double weightTotal = Convert.ToDouble(this.gridColumn2.SummaryItem.SummaryValue.ToString());
            if (weightTotal <= 0) return;

            // Get sum of fiedl AfterDPQuantity
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            double afterDPQuantitySum = palletDA.Select(p => p.PalletID == this.palletIDSelected).Sum(sum => sum.AfterDPQuantity);
            double originalQuantitySum = palletDA.Select(p => p.PalletID == this.palletIDSelected).Sum(sum => sum.OriginalQuantity);

            if (afterDPQuantitySum.Equals(originalQuantitySum))
            {
                // This data is not confirm
                if (this.accept < 2)
                {
                    // Update pallet Info
                    this.UpdatePalletInfo();
                    int result = palletDA.ExecuteNoQuery("STPalletCartonWeightUpdate @PalletID={0}", this.palletIDSelected);
                    if (result < 0)
                    {
                        MessageBox.Show("Update is fail");
                        return;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Can not update! This record is confirmed!");
                }
            }
            else
            {
                MessageBox.Show("Product is dispatched! Can not change weight");
            }
        }

        private void grv_WM_PelletData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (string.IsNullOrEmpty(Convert.ToString(e.Value))) return;
            this.listData[e.RowHandle].IsModified = true;
            switch (e.Column.FieldName)
            {
                case "pc.PalletGrossWeight":
                    var gross = Convert.ToDecimal(e.Value);
                    var newNet = gross - this.damage;
                    this.grv_WM_PelletData.SetFocusedRowCellValue("pc.PalletWeight", newNet);
                    var newWeightPay = gross - Convert.ToDecimal(this.grv_WM_PelletData.GetFocusedRowCellValue("pc.TareWeight"));
                    this.grv_WM_PelletData.SetFocusedRowCellValue("pc.CartonWeightPay", newWeightPay);
                    break; 
                case "pc.TareWeight":
                    this.grv_WM_PelletData.SetFocusedRowCellValue("pc.PalletGrossWeight", 0);
                    var weightPay = 0 - Convert.ToDecimal(e.Value);
                    this.grv_WM_PelletData.SetFocusedRowCellValue("pc.CartonWeightPay", weightPay);
                    break;
            }
        }

        /// <summary>
        /// Update palletInfo
        /// </summary>
        private void UpdatePalletInfo()
        {
            // Get list palletInfo was modified
            var listPalletCartonUpdate = this.listData.Where(pc => pc.IsModified == true).ToArray();
            
            foreach(var item in listPalletCartonUpdate)
            {
                item.UpdatedBy = AppSetting.CurrentUser.LoginName;
                item.UpdatedTime = DateTime.Now;
            }
            if (listPalletCartonUpdate.Count() <= 0) return;
            DataProcess<PalletCartons> palletCartorDA = new DataProcess<PalletCartons>();
            palletCartorDA.Update(listPalletCartonUpdate);

        }

        private void btn_WM_Cancel_ItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_WM_Update_ItemClick(object sender, EventArgs e)
        {
            double weightTotal = Convert.ToDouble(this.gridColumn2.SummaryItem.SummaryValue.ToString());
            if (weightTotal <= 0) return;

            // Check weight negative value
            if (this.isNegativeValue)
            {
                var dl = MessageBox.Show("There are the values invalid, Do you want to ignore it and update?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
            }

            // Get total unit scan
            int totalUnit = Convert.ToInt32(this.gridColumn3.SummaryItem.SummaryValue);
            if (this.totalOriginalQuantity < totalUnit)
            {
                var dl = MessageBox.Show("Total original quantity and total unit scan is difference ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
            }


            int totalCarton = Convert.ToInt32(this.gridColumn1.SummaryItem.SummaryValue);
            if (this.totalOriginalQuantity < totalCarton || this.totalOriginalQuantity > totalCarton)
            {
                MessageBox.Show("Can not update. Total original quantity and total CartonID is difference");
                return;
                //var dl = MessageBox.Show("Total original quantity and total unit scan is difference ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (dl.Equals(DialogResult.No)) return;
            }

            // Get sum of fiedl AfterDPQuantity
            DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
            double afterDPQuantitySum = palletDA.Select(p => p.PalletID == this.palletIDSelected).Sum(sum => sum.AfterDPQuantity);
            double originalQuantitySum = palletDA.Select(p => p.PalletID == this.palletIDSelected).Sum(sum => sum.OriginalQuantity);

            if (afterDPQuantitySum.Equals(originalQuantitySum))
            {
                // This data is not confirm
                if (this.accept < 2)
                {
                    // Update pallet Info
                    this.UpdatePalletInfo();
                    int result = palletDA.ExecuteNoQuery("STPalletCartonWeightUpdate @PalletID={0}", this.palletIDSelected);

                    if (result < 0)
                    {
                        MessageBox.Show("Update is fail");
                        return;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Can not update! This record is confirmed!");
                }
            }
            else
            {
                MessageBox.Show("Product is dispatched! Can not change weight");
            }
        }

        private void grv_WM_PelletData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            double weight = Convert.ToDouble(this.grv_WM_PelletData.GetRowCellValue(e.RowHandle, "pc.PalletWeight"));
            double netSupplier = Convert.ToDouble(this.grv_WM_PelletData.GetRowCellValue(e.RowHandle, "pc.NetWeightSupplier"));
            var redundancyValue = weight - netSupplier;
            var ratioValue = netSupplier % 100;
            var hasValid = redundancyValue > (ratioValue * 3);


            //if (weight < 0 || hasValid)
            if (weight < 0 || (Math.Abs(weight - netSupplier) / netSupplier > 0.03) && netSupplier > 0)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
                this.isNegativeValue = true;
            }
        }

        private void lbl_WM_PalletID_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(this.textOriginalPalletID.Text)))
            {
                frm_WM_ImportCartonWeight frm = new frm_WM_ImportCartonWeight("RO", this.roID);
                frm.ShowDialog();
                this.LoadData();
            }
            else
            {
                //Code here to process import from other PalletID
                //STPalletCartonExportByPalletID
                var dl = MessageBox.Show("Do you want export cartons from this pallet ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
                DataProcess<Pallets> palletDA = new DataProcess<Pallets>();
                int result = palletDA.ExecuteNoQuery("STPalletCartonExportByPalletID @PalletIDS={0}, @PalletIDD={1}, @CreateBy = {2}", this.textOriginalPalletID.Text, this.palletIDSelected, AppSetting.CurrentUser.LoginName);
                this.LoadData();
            }

        }

        private void rpi_btn_Delete_Click(object sender, EventArgs e)
        {
            int palletCartonID = Convert.ToInt32(this.grv_WM_PelletData.GetFocusedRowCellValue("pc.PalletCartonID"));
            DataProcess<PalletCartons> palletCaton = new DataProcess<PalletCartons>();
            palletCaton.ExecuteNoQuery("Delete PalletCartons Where PalletCartonID =" + palletCartonID);
            this.LoadData();
        }

        private void btnProcessTareW_Click(object sender, EventArgs e)
        {
            int tareWeightInput = Convert.ToInt32(this.txtInputTareW.EditValue);
            DataProcess<PalletCartons> palletCaton = new DataProcess<PalletCartons>();
            palletCaton.ExecuteNoQuery("Update PalletCartons Set TareWeight={0} Where PalletID ={1}", tareWeightInput, this.palletIDSelected);
            this.LoadData();
        }

        private void PrintLabelDecal(bool isPreview)
        {
            log.Debug("==> frm_WM_PalletCartons chạy hàm PrintLabelDecal");
            rptInlabel lb = new rptInlabel();
            lb.DataSource = multilabel.Executing("STLabelPalletCartonWeight @PalletID={0}", this.palletIDSelected);
            IList<STLabelPalletCartonWeight> getCartonIDBarcode = (IList<STLabelPalletCartonWeight>)lb.DataSource;
            lb.bcCartonID.Text = getCartonIDBarcode.Select(obj => obj.CartonID.ToString()).FirstOrDefault();
            lb.RequestParameters = false;
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(lb);
            printTool.AutoShowParametersPanel = false;

            if (isPreview)
            {
                printTool.ShowPreview();
            }
            else
            {
                printTool.Print();
            }
        }

        private void btnInlabel_Click(object sender, EventArgs e)
        {
            PrintLabelDecal(true);
        }

        private void grv_WM_PelletData_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grv_WM_PelletData.SetRowCellValue(e.RowHandle, "pc.PalletWeight", this._net);
            grv_WM_PelletData.SetRowCellValue(e.RowHandle, "pc.PalletGrossWeight", this._gross);
        }
    }
}
