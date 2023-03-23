using Common.Controls;
using DA;
using DA.Warehouse;
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

namespace UI.Admin
{
    public partial class frm_AD_NewItemPart : frmBaseForm
    {
        public frm_AD_NewItemPart()
        {
            InitializeComponent();
            Init();
            this.grcPartList.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBParts");
        }

        private void Init()
        {

            this.lkeCategory.Properties.DataSource = FileProcess.LoadTable("SELECT CategoryID, CategoryDescription FROM Categories ORDER BY CategoryID");
            this.lkeCategory.Properties.DropDownRows = 10;
            this.lkeCategory.Properties.DisplayMember = "CategoryDescription";
            this.lkeCategory.Properties.ValueMember = "CategoryID";
            this.lkeCategory.EditValue = 10;

            using (PlantDBContext context = new PlantDBContext())
            {
                this.lke_partGroup.Properties.DataSource = context.GetComboStoreNo("SELECT PartGroupID, PartGroupDescription, DepartmentCategoryID FROM   PartGroups");
                this.lke_partGroup.Properties.DropDownRows = 10;
                this.lke_partGroup.Properties.DisplayMember = "PartGroupDescription";
                this.lke_partGroup.Properties.ValueMember = "PartGroupID";
                this.lke_partGroup.EditValue = 5;


                this.lke_part_category.Properties.DataSource = context.GetComboStoreNo("SELECT  PartCategoryID, PartCategoryDescription FROM  PartCategories");
                this.lke_part_category.Properties.DropDownRows = 10;
                this.lke_part_category.Properties.DisplayMember = "PartCategoryDescription";
                this.lke_part_category.Properties.ValueMember = "PartCategoryID";
                this.lke_part_category.EditValue = 9;
            }
        }




        private void bnt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = String.Format("insert into Parts (PartName, " +
                    "PartGroupID, PartCategoryID , EquipmentGroupID, PartRemark, CategoryID, Unit,UnitPriceVND, UnitPriceUSD, PartEntryTime, CreatedBy) " +
                    "Values (N'{0}','{1}','{2}', 0, N'{3}','{4}','{5}','{6}','{7}','{8}',N'{9}')",
                    this.txtPartName.Text,
                    this.lke_partGroup.EditValue.ToString(),
                    this.lke_part_category.EditValue.ToString(),
                    this.memRemark.Text,
                    this.lkeCategory.EditValue.ToString(),
                    this.txtUnit.Text,
                    this.textVND.Text,
                    this.txtUSD.Text,
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    AppSetting.CurrentUser.LoginName);

                context.Delete(sql);
            }
            //this.Close();
            this.grcPartList.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBParts");
        }

        private void grvPartList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //Load the record here
            //this.txtPartName.Text = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.lke_partGroup.EditValue = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.lke_part_category.EditValue = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.memRemark.Text = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.lkeCategory.EditValue = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.txtUnit.Text = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.textVND.Text = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();
            //this.txtUSD.Text = this.grvPartList.GetFocusedRowCellValue("PartName").ToString();


        }
    }
}
