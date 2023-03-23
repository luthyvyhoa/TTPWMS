using DA;
using DA.Warehouse;
using DevExpress.XtraBars.Controls;
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
    public partial class frm_AD_SupplierList : Form
    {
        public frm_AD_SupplierList()
        {
            InitializeComponent();
            this.grcSupplierList.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBSuppliers");
            LoadSupplierCategory();
        }




        private void LoadSupplierCategory()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.lke_category.Properties.DataSource = context.GetComboStoreNo("SELECT  SupplierCategoryID, SupplierCategoryDescriptions FROM SupplierCategories");
                this.lke_category.Properties.DropDownRows = 2;
                this.lke_category.Properties.DisplayMember = "SupplierCategoryDescriptions";
                this.lke_category.Properties.ValueMember = "SupplierCategoryID";
                //this.lkeSupplier.EditValue = AppSetting.CurrentUser.StoreID;
            }
        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_close_supp_Click(object sender, EventArgs e)
        {
            //PopupContainerBarControl control = popupSuppDetail.Parent as PopupContainerBarControl;
            //control.ClosePopup();
            clearPopup();
            popupSuppDetail.Visible = false;
            this.grcSupplierList.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBSuppliers");
        }

        private void btn_save_supp_Click(object sender, EventArgs e)
        {
            if (txt_suppID.Text.Equals("New*") && txt_name.Text.Length > 0 && txt_taxCode.Text.Length > 0 && lke_category.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = String.Format("Insert into Suppliers (StrategicSupplier,SupplierName,SupplierFullName,SupplierTaxCode,"+
                                                "SupplierContactName, SupplierTitle, SupplierMobile, SupplierEmail, SupplierPhone, " +
                                                "SupplierFax, SupplierAddress, SupplierBankAccountNumber, " +
                                                "SupplierWebsite, SupplierBankAccountName, SupplierRemark,CreatedBy ,SupplierCategoryID) " +
                                                "Values({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}', N'{14}',N'{15}',{16}) ;" +
                                                " SELECT SCOPE_IDENTITY() AS SCOPE_ID",
                                     
                                        chk_strategicSupp.Checked?"1":"0" ,
                                        txt_name.Text,
                                        txt_fullName.Text ,
                                        txt_taxCode.Text,
                                        txt_contactName.Text ,
                                        txt_contactTitle.Text ,
                                        txt_mobile.Text ,
                                        txt_email.Text ,
                                        txt_phone.Text,
                                        txt_fax.Text,
                                        mm_address.Text ,
                                        txt_accNumber.Text ,
                                        txt_web.Text ,
                                        txt_bankAccName.Text ,
                                        mm_notes.Text ,
                                        AppSetting.CurrentUser.LoginName,
                                        lke_category.EditValue.ToString()
                                     );

                    var dataSource = context.GetComboStoreNo(sql);
                    this.txt_suppID.Text = dataSource.Rows[0]["SCOPE_ID"].ToString();


                }
                MessageBox.Show("Create Supplier Successfully!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txt_suppID.Text.Length > 0 && txt_name.Text.Length > 0 && txt_taxCode.Text.Length > 0 && lke_category.Text.Length>0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = String.Format("Update Suppliers  set StrategicSupplier = {0}, SupplierName =N'{1}' ,SupplierFullName=N'{2}',SupplierTaxCode=N'{3}'," +
                                                "SupplierContactName=N'{4}', SupplierTitle= N'{5}', SupplierMobile= N'{6}', SupplierEmail=N'{7}', SupplierPhone=N'{8}', " +
                                                "SupplierFax= N'{9}', SupplierAddress=N'{10}', SupplierBankAccountNumber= N'{11}', " +
                                                "SupplierWebsite= N'{12}', SupplierBankAccountName=N'{13}', SupplierRemark=  N'{14}' , SupplierCategoryID = {15} " +                   
                                                " Where SupplierID = {16}",

                                        chk_strategicSupp.Checked ? "1" : "0",
                                        txt_name.Text,
                                        txt_fullName.Text,
                                        txt_taxCode.Text,
                                        txt_contactName.Text,
                                        txt_contactTitle.Text,
                                        txt_mobile.Text,
                                        txt_email.Text,
                                        txt_phone.Text,
                                        txt_fax.Text,
                                        mm_address.Text,
                                        txt_accNumber.Text,
                                        txt_web.Text,
                                        txt_bankAccName.Text,
                                        mm_notes.Text,
                                        lke_category.EditValue.ToString(),
                                        txt_suppID.Text
                                     );
                    context.Delete(sql);

                }
                MessageBox.Show("Update Info Supplier Successfully!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You must enter Supplier Name and Tax Code, Category!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_delete_supp_Click(object sender, EventArgs e)
        {
            //currentSupplier
            if (txt_suppID.Text.Length > 0)
            {
                var dl = MessageBox.Show("Are you sure to DELETE this Supplier?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = "delete from Suppliers where SupplierID = " + txt_suppID.Text;
                    context.Delete(sql);
                }
                //MessageBox.Show("Update Info Supplier Successfully!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearPopup();
                popupSuppDetail.Visible = false;
                this.grcSupplierList.DataSource = FileProcess.LoadTable("ST_WMS_LoadPlantDBSuppliers");
            }
            //int position = grvSupplierList.GetFocusedDataSourceRowIndex();
            //if (position < this.grvSupplierList.RowCount)
            //{
            //    var dl = MessageBox.Show("Are you sure to DELETE this Item?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (dl.Equals(DialogResult.No)) return;
            //    if (this.PettyCashDetailsList[position].PettyCashDetailID > 0)
            //        using (PlantDBContext context = new PlantDBContext())
            //        {
            //            string sql = "delete from PettyDetails where PettyCashDetailID = " + this.PettyCashDetailsList[position].PettyCashDetailID;
            //            context.Delete(sql);
            //        }
            //    this.PettyCashDetailsList.RemoveAt(position);
            //    grcPettyDetails.DataSource = new BindingList<PettyCashDetails>(this.PettyCashDetailsList);
            //}
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

            //code here to load data to popup, use entity currentSupplier
            string supid = grvSupplierList.GetFocusedRowCellValue("SupplierID").ToString();

            //int position = grvSupplierList.GetFocusedDataSourceRowIndex();
            //if (position < this.grvSupplierList.RowCount)
            if(supid.Length > 0)
            {
                btn_delete_supp.Enabled = true;
                btn_delete_supp.Visible = true;

                //string id = this.grvSupplierList.GetRowCellValue(position, "SupplierID").ToString();
                
                txt_suppID.Text = supid;


                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = "select * from Suppliers where SupplierID = " + supid;
                    var dataSource = context.GetComboStoreNo(sql);
                    txt_name.Text = dataSource.Rows[0]["SupplierName"].ToString();
                    txt_fullName.Text = dataSource.Rows[0]["SupplierFullName"].ToString();
                    txt_contactName.Text = dataSource.Rows[0]["SupplierContactName"].ToString();
                    txt_contactTitle.Text = dataSource.Rows[0]["SupplierTitle"].ToString();
                    txt_mobile.Text = dataSource.Rows[0]["SupplierMobile"].ToString();
                    txt_email.Text = dataSource.Rows[0]["SupplierEmail"].ToString();
                    txt_phone.Text = dataSource.Rows[0]["SupplierPhone"].ToString();
                    txt_fax.Text = dataSource.Rows[0]["SupplierFax"].ToString();
                    mm_address.Text = dataSource.Rows[0]["SupplierAddress"].ToString();
                    txt_accNumber.Text = dataSource.Rows[0]["SupplierBankAccountNumber"].ToString();
                    txt_web.Text = dataSource.Rows[0]["SupplierWebsite"].ToString();
                    txt_taxCode.Text = dataSource.Rows[0]["SupplierTaxCode"].ToString();
                    txt_bankAccName.Text = dataSource.Rows[0]["SupplierBankAccountName"].ToString();
                    mm_notes.Text = dataSource.Rows[0]["SupplierRemark"].ToString();
                    txt_createdBy.Text = dataSource.Rows[0]["CreatedBy"].ToString();                   
                    chk_strategicSupp.Checked = (dataSource.Rows[0]["StrategicSupplier"].ToString() == "true");
                    lke_category.EditValue = dataSource.Rows[0]["SupplierCategoryID"];
                }



                this.popupSuppDetail.Show();
            }

            
        }

        private void btn_createSupp_Click(object sender, EventArgs e)
        {
            btn_delete_supp.Enabled = false;
            btn_delete_supp.Visible = false;
            txt_suppID.Text = "New*";
            this.popupSuppDetail.Show();
        }

        private void clearPopup()
        {
            txt_suppID.Text = "";
            txt_createdBy.Text = "";
            chk_strategicSupp.Checked = false;
            txt_name.Text = "";
            txt_fullName.Text = "";
            txt_taxCode.Text = "";
            txt_contactName.Text = "";
            txt_contactTitle.Text = "";
            txt_mobile.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
            txt_fax.Text = "";
            mm_address.Text = "";
            txt_accNumber.Text = "";
            txt_web.Text = "";
            txt_bankAccName.Text = "";
            mm_notes.Text = "";
            lke_category.EditValue = null;
            btn_delete_supp.Enabled = false;
            btn_delete_supp.Visible = false;
        }




    }
}
