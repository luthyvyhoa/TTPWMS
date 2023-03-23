using Common.Controls;
using DA;
using DA.Management;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;

namespace UI.Admin
{
    public partial class frm_AD_ExpenseDetails : Form
    {
        public List<ExpenseDetail> EDList = new List<ExpenseDetail>();
        private int ExpenseOrderDetailID;
        private string ExpenseOrderNumber;
        public frm_AD_ExpenseDetails(string OrderType, int OrderDetailID, string ExpenseOrderNumber)
        {

            InitializeComponent();

            //this.grcExpenseDetail.DataSource = new BindingList<ExpenseDetail>(EDList);
            this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" + ExpenseOrderNumber + "'," + OrderDetailID);

            //this.rpe_lue_PartID.DataSource = FileProcess.LoadTable("ST_WMS_LoadPartExpenseDetails " + OrderType + "'," + OrderDetailID);
            
            this.grcPasteData.DataSource = new BindingList<ExpenseDetail>(EDList);

            this.ExpenseOrderDetailID = OrderDetailID;
            this.ExpenseOrderNumber = ExpenseOrderNumber;

            //gridColumn17.ReadOnly = false;
            this.btn_update.Enabled = false;
            this.btn_update.Appearance.BackColor = Color.DarkGray;
            btn_update.Appearance.Options.UseBackColor = true;

        }

        private void rpe_hle_OrdeerNumber_Click(object sender, EventArgs e)
        {
            //Code here to go to difference orders
        }

        private void grvExpensesDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Code here to update data in the grid
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            foreach (ExpenseDetail ED in EDList)
            {
                if (ED.ExpenseCode.Length > 0 && ED.ExpenseName.Length > 0 && ED.ExpenseAmount.Length > 0 
                    //&& IsDigitsOnly(ED.ExpenseAmount)
                    && (new Regex(@"^-?[0-9][0-9,\.]*$").IsMatch(ED.ExpenseAmount))
                    )
                {
                    DataProcess<object> dataProcess = new DataProcess<object>();
                    string sql = String.Format("Insert into  OperatingCostExpenseDetails  (ExpenseOrderNumber,ExpenseOrderDetailID,ExpenseCode,ExpenseName," +
                                                "ExpenseAmount, ExpenseRemark, OrderNumber, CreatedBy, CreatedTime, ExpenseQuantity , ExpenseUnitPrice) " +
                                                "Values('{0}', {1}, '{2}', N'{3}', {4}, N'{5}', '{6}', N'{7}' , getdate(), {8} , {9} ) ",

                                                this.ExpenseOrderNumber,
                                                this.ExpenseOrderDetailID,
                                                ED.ExpenseCode,
                                                ED.ExpenseName,
                                                ED.ExpenseAmount,
                                                ED.ExpenseRemark,
                                                ED.OrderNumber,                           
                                                AppSetting.CurrentUser.LoginName,
                                                ED.ExpenseQuantity,
                                                ED.ExpenseUnitPrice


                                     );
                    dataProcess.ExecuteNoQuery(sql);
                }
                else
                {
                    MessageBox.Show("Data error : " + ED.ExpenseCode + " | " +
                                                ED.ExpenseName + " | " +
                                                ED.ExpenseAmount + " | " +
                                                ED.OrderNumber + " | " +
                                                ED.ExpenseQuantity + " | " +
                                                ED.ExpenseUnitPrice, "WMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
            this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" + ExpenseOrderNumber + "'," + ExpenseOrderDetailID);
            MessageBox.Show("Import Done !", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.grcPasteData.DataSource = null;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                this.grvPasteData.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Update;
                
            }
            else
            {
                this.grvPasteData.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Append;
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            int position = grvExpenseDetail.GetFocusedDataSourceRowIndex();
            if (this.grvExpenseDetail.GetRowCellValue(position, "OperatingCostExpenseDetailID") != null)
            {
                DataProcess<object> dataProcess = new DataProcess<object>();
                string id = this.grvExpenseDetail.GetRowCellValue(position, "OperatingCostExpenseDetailID").ToString();
                string code = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseCode").ToString();
                string des = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseName").ToString();
                int amount = Convert.ToInt32(this.grvExpenseDetail.GetRowCellValue(position, "ExpenseAmount").ToString());
                string remark = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseRemark").ToString();
                string no = this.grvExpenseDetail.GetRowCellValue(position, "OrderNumber").ToString();
                string quantity = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseQuantity").ToString().Length > 0 ?
                                this.grvExpenseDetail.GetRowCellValue(position, "ExpenseQuantity").ToString() : "0";

                string unitPrice = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseUnitPrice").ToString().Length > 0 ?
                                this.grvExpenseDetail.GetRowCellValue(position, "ExpenseUnitPrice").ToString() : "0";

                string sql = String.Format("Update OperatingCostExpenseDetails " +
                    "set ExpenseCode = '{0}', ExpenseName =N'{1}', ExpenseAmount= {2},ExpenseRemark= N'{3}',OrderNumber ='{4}',ExpenseQuantity = {5} , ExpenseUnitPrice = {6} " +
                    "Where OperatingCostExpenseDetailID = {7} ",
                    code, des, amount, remark, no, quantity, unitPrice, id  
                    );
                dataProcess.ExecuteNoQuery(sql);
                MessageBox.Show("Update Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_update.Enabled = false;
                this.btn_update.Appearance.BackColor = Color.DarkGray;
                btn_update.Appearance.Options.UseBackColor = true;
            }
            //this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" + ExpenseOrderNumber + "'," + ExpenseOrderDetailID);
        }

        private void grcExpenseDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{

            //    int position = grvPalletStatusChange.GetFocusedDataSourceRowIndex();
            //    if (position < this.PalletStatusChangeDetailList.Count)
            //    {
            //        var dl = MessageBox.Show("Are you sure to DELETE this Item?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (dl.Equals(DialogResult.No)) return;
            //        if (this.PalletStatusChangeDetailList[position].PalletStatusChangeDetailID > 0)
            //        {
            //            DataProcess<object> dataProcess = new DataProcess<object>();
            //            string sql = "DELETE FROM PalletStatusChangeDetails WHERE PalletStatusChangeDetailID = " + this.PalletStatusChangeDetailList[position].PalletStatusChangeDetailID;
            //            dataProcess.ExecuteNoQuery(sql);
            //        }
            //        this.PalletStatusChangeDetailList.RemoveAt(position);
            //        grdPalletStatusChange.DataSource = new BindingList<PalletStatusChangeDetails>(this.PalletStatusChangeDetailList);
            //    }
            //}
            if (e.KeyCode == Keys.Delete)
            {
                bool isDelete = false;
                //int result = -1;
                int[] selectRows = this.grvExpenseDetail.GetSelectedRows();
                if (selectRows.Count() <= 0) return;

                if (XtraMessageBox.Show("Are you sure to delete pallets ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                DataProcess<object> dataProcess = new DataProcess<object>();
                for (int i = 0; i < selectRows.Count(); ++i)
                {
                    int id = Convert.ToInt32(this.grvExpenseDetail.GetRowCellValue(selectRows[i], "OperatingCostExpenseDetailID"));
                    dataProcess.ExecuteNoQuery("DELETE FROM OperatingCostExpenseDetails WHERE OperatingCostExpenseDetailID = " + id);
                    isDelete = true;
                }

                if (isDelete)
                {
                    this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" + ExpenseOrderNumber + "'," + ExpenseOrderDetailID);
                }
            }
        }

        private void grvExpenseDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.btn_update.Enabled = true;
            this.btn_update.Appearance.BackColor = DXSkinColors.FillColors.Primary;
            btn_update.Appearance.Options.UseBackColor = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sql = String.Format("Delete from OperatingCostExpenseDetails Where ExpenseOrderDetailID = {0} ", ExpenseOrderDetailID);
            DataProcess<object> dataProcess = new DataProcess<object>();
            dataProcess.ExecuteNoQuery(sql);
            this.grcExpenseDetail.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostExpenseDetails '" + ExpenseOrderNumber + "'," + ExpenseOrderDetailID);
        }

        private void frm_AD_ExpenseDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.btn_update.Enabled == true)
            {
                var dl = MessageBox.Show("Do you want to save the changes?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;
                for (int i = 0; i < grvExpenseDetail.RowCount; i++)
                {


                    int position = i;
                    if (this.grvExpenseDetail.GetRowCellValue(position, "OperatingCostExpenseDetailID") != null)
                    {
                        DataProcess<object> dataProcess = new DataProcess<object>();
                        string id = this.grvExpenseDetail.GetRowCellValue(position, "OperatingCostExpenseDetailID").ToString();
                        string code = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseCode").ToString();
                        string des = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseName").ToString();
                        int amount = Convert.ToInt32(this.grvExpenseDetail.GetRowCellValue(position, "ExpenseAmount").ToString());
                        string remark = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseRemark").ToString();
                        string no = this.grvExpenseDetail.GetRowCellValue(position, "OrderNumber").ToString();
                        string quantity = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseQuantity").ToString().Length > 0 ?
                                        this.grvExpenseDetail.GetRowCellValue(position, "ExpenseQuantity").ToString() : "0";

                        string unitPrice = this.grvExpenseDetail.GetRowCellValue(position, "ExpenseUnitPrice").ToString().Length > 0 ?
                                        this.grvExpenseDetail.GetRowCellValue(position, "ExpenseUnitPrice").ToString() : "0";

                        string sql = String.Format("Update OperatingCostExpenseDetails " +
                            "set ExpenseCode = '{0}', ExpenseName =N'{1}', ExpenseAmount= {2},ExpenseRemark= N'{3}',OrderNumber ='{4}',ExpenseQuantity = {5} , ExpenseUnitPrice = {6} " +
                            "Where OperatingCostExpenseDetailID = {7} ",
                            code, des, amount, remark, no, quantity, unitPrice, id
                            );
                        dataProcess.ExecuteNoQuery(sql);
                    }
                }

            }
            

        }
    }
}
