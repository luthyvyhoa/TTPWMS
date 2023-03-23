using Common.Controls;
using DA;
using DA.Management;
using DA.Warehouse;
using DevExpress.LookAndFeel;
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
using UI.ReportFile;

namespace UI.Admin
{
    public partial class frm_AD_PettyCash : frmBaseForm
    {
        private List<PettyCash> pettyCashList;
        private List<PettyCashDetails> PettyCashDetailsList;
        private PettyCash currentPettyCash;
        private PettyCash saveCurrentPettyCash;
        private int savePsosition = 0;

        public frm_AD_PettyCash()
        {
            InitializeComponent();

            dateFrom.EditValue = DateTime.Today.AddDays(-180);

            LoadStore();
            LoadCurrency();
            LoadEmployee();
            LoadParts();
            LoadExpCategory();
            Init();
        }
        public frm_AD_PettyCash(int pettyCashID)
        {
            InitializeComponent();

            dateFrom.EditValue = DateTime.Today.AddDays(-180);

            LoadStore();
            LoadCurrency();
            LoadEmployee();
            LoadParts();
            Init_PettyCashID (pettyCashID);
        }

        private void Init_PettyCashID(int pettyCashID)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = "ST_WMS_PettyCashList " + "'" + this.dateFrom.DateTime.ToString("yyyy-MM-dd") + "' , '" + AppSetting.CurrentUser.LoginName + "'," + pettyCashID;
                var dataSource = context.GetComboStoreNo(sql);

                this.pettyCashList = new List<PettyCash>();
                if (this.dateFrom.EditValue != null)
                {
                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PettyCash PC = new PettyCash();
                        PC.PettyCashID = Convert.ToInt32(dataSource.Rows[i]["PettyCashID"].ToString());
                        PC.PettyCashNumber = dataSource.Rows[i]["PettyCashNumber"].ToString();
                        PC.ActionDate = Convert.ToDateTime(dataSource.Rows[i]["ActionDate"].ToString());
                        PC.ClearStatus = dataSource.Rows[i]["ClearStatus"].ToString();
                        PC.ClearBy = Convert.ToInt32(dataSource.Rows[i]["ClearBy"].ToString());
                        PC.AdvanceDate = Convert.ToDateTime(dataSource.Rows[i]["AdvanceDate"].ToString());
                        PC.Remark = dataSource.Rows[i]["Remark"].ToString();
                        PC.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();
                        PC.PettyCashOldID = Convert.ToInt32(dataSource.Rows[i]["PettyCashOldID"].ToString());
                        PC.CreatedTime = Convert.ToDateTime(dataSource.Rows[i]["CreatedTime"].ToString());
                        PC.ts = dataSource.Rows[i]["ts"].ToString();
                        PC.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PC.AdvanceAmount = Convert.ToInt32(dataSource.Rows[i]["AdvanceAmount"].ToString());
                        PC.AdvanceRemark = dataSource.Rows[i]["AdvanceRemark"].ToString();
                        PC.Currency = dataSource.Rows[i]["Currency"].ToString();
                        PC.PaymentTo = Convert.ToInt32(dataSource.Rows[i]["PaymentTo"].ToString());
                        PC.PaymentMethod = dataSource.Rows[i]["PaymentMethod"].ToString();
                        this.pettyCashList.Add(PC);
                    }
                }


                this.dtngPettyCash.DataSource = pettyCashList;
                int position = pettyCashList.Count - 1;
                dtngPettyCash.Position = position;
                if (position >= 0)
                {
                    currentPettyCash = pettyCashList.ElementAt(dtngPettyCash.Position);
                    saveCurrentPettyCash = currentPettyCash;
                    UpdateControlsBy(currentPettyCash);
                    UpdateControlStatus();
                }

            }

        }


        private void Init()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = "ST_WMS_PettyCashList " + "'" + this.dateFrom.DateTime.ToString("yyyy-MM-dd") + "' , '" + AppSetting.CurrentUser.LoginName + "'";
                var dataSource = context.GetComboStoreNo(sql);
                

                //pettyCashList = (from DataRow row in dataSource.Rows
                //                        select new PettyCash
                //                        {
                //                            PettyCashID = Convert.ToInt32( row["PettyCashID"].ToString()),
                //                            PettyCashNumber = row["PettyCashNumber"].ToString(),
                //                            ActionDate = Convert.ToDateTime(row["ActionDate"].ToString()),
                //                            ClearStatus = row["ClearStatus"].ToString()),
                //                            ClearBy = Convert.ToInt32(row["ClearBy"].ToString()),
                //                            AdvanceDate = Convert.ToDateTime(row["AdvanceDate"].ToString()),
                //                            Remark = row["Remark"].ToString(),
                //                            OrderBy = row["OrderBy"].ToString(),
                //                            PettyCashOldID = Convert.ToInt32(row["PettyCashOldID"].ToString()),
                //                            CreatedTime = Convert.ToDateTime(row["CreatedTime"].ToString()),
                //                            ts = row["ts"].ToString(),
                //                            StoreID = Convert.ToInt32(row["StoreID"].ToString()),
                //                            AdvanceAmount = Convert.ToInt32(row["AdvanceAmount"].ToString()),
                //                            AdvanceRemark = row["AdvanceRemark"].ToString(),
                //                            Currency = row["Currency"].ToString()
                //                        }).ToList();

                this.pettyCashList = new List<PettyCash>();
                if (this.dateFrom.EditValue != null)
                {
                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PettyCash PC = new PettyCash();
                        PC.PettyCashID = Convert.ToInt32(dataSource.Rows[i]["PettyCashID"].ToString());
                        PC.PettyCashNumber = dataSource.Rows[i]["PettyCashNumber"].ToString();
                        PC.ActionDate = Convert.ToDateTime(dataSource.Rows[i]["ActionDate"].ToString());
                        PC.ClearStatus = dataSource.Rows[i]["ClearStatus"].ToString();
                        PC.ClearBy = Convert.ToInt32(dataSource.Rows[i]["ClearBy"].ToString());
                        PC.AdvanceDate = Convert.ToDateTime(dataSource.Rows[i]["AdvanceDate"].ToString());
                        PC.Remark = dataSource.Rows[i]["Remark"].ToString();
                        PC.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();
                        PC.PettyCashOldID = Convert.ToInt32(dataSource.Rows[i]["PettyCashOldID"].ToString());
                        PC.CreatedTime = Convert.ToDateTime(dataSource.Rows[i]["CreatedTime"].ToString());
                        PC.ts = dataSource.Rows[i]["ts"].ToString();
                        PC.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PC.AdvanceAmount = Convert.ToInt32(dataSource.Rows[i]["AdvanceAmount"].ToString());
                        PC.AdvanceRemark = dataSource.Rows[i]["AdvanceRemark"].ToString();
                        PC.Currency = dataSource.Rows[i]["Currency"].ToString();
                        PC.PaymentTo = Convert.ToInt32(dataSource.Rows[i]["PaymentTo"].ToString());
                        PC.PaymentMethod = dataSource.Rows[i]["PaymentMethod"].ToString();
                        this.pettyCashList.Add(PC);
                    }
                }
                

                this.dtngPettyCash.DataSource = pettyCashList;
                int position = pettyCashList.Count - 1;
                dtngPettyCash.Position = position;
                if(position >= 0)
                {
                    currentPettyCash = pettyCashList.ElementAt(dtngPettyCash.Position);
                    saveCurrentPettyCash = currentPettyCash;
                    UpdateControlsBy(currentPettyCash);
                    UpdateControlStatus();
                }
                
            }

        }

        private void Update(int savePsosition)
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = "ST_WMS_PettyCashList " + "'" + this.dateFrom.DateTime.ToString("yyyy-MM-dd") + "' , '" + AppSetting.CurrentUser.LoginName + "'";
                var dataSource = context.GetComboStoreNo(sql);

                this.pettyCashList = new List<PettyCash>();
                if (this.dateFrom.EditValue != null)
                {
                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PettyCash PC = new PettyCash();
                        PC.PettyCashID = Convert.ToInt32(dataSource.Rows[i]["PettyCashID"].ToString());
                        PC.PettyCashNumber = dataSource.Rows[i]["PettyCashNumber"].ToString();
                        PC.ActionDate = Convert.ToDateTime(dataSource.Rows[i]["ActionDate"].ToString());
                        PC.ClearStatus = dataSource.Rows[i]["ClearStatus"].ToString();
                        PC.ClearBy = Convert.ToInt32(dataSource.Rows[i]["ClearBy"].ToString());
                        PC.AdvanceDate = Convert.ToDateTime(dataSource.Rows[i]["AdvanceDate"].ToString());
                        PC.Remark = dataSource.Rows[i]["Remark"].ToString();
                        PC.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();
                        PC.PettyCashOldID = Convert.ToInt32(dataSource.Rows[i]["PettyCashOldID"].ToString());
                        PC.CreatedTime = Convert.ToDateTime(dataSource.Rows[i]["CreatedTime"].ToString());
                        PC.ts = dataSource.Rows[i]["ts"].ToString();
                        PC.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PC.AdvanceAmount = Convert.ToInt32(dataSource.Rows[i]["AdvanceAmount"].ToString());
                        PC.AdvanceRemark = dataSource.Rows[i]["AdvanceRemark"].ToString();
                        PC.Currency = dataSource.Rows[i]["Currency"].ToString();
                        PC.PaymentTo = Convert.ToInt32(dataSource.Rows[i]["PaymentTo"].ToString());
                        PC.PaymentMethod = dataSource.Rows[i]["PaymentMethod"].ToString();
                        this.pettyCashList.Add(PC);
                    }
                }


                this.dtngPettyCash.DataSource = pettyCashList;
                //int position = pettyCashList.Count - 1;
                dtngPettyCash.Position = savePsosition;
                //currentPettyCash = pettyCashList.ElementAt(dtngPettyCash.Position);
                //saveCurrentPettyCash = currentPettyCash;
                //UpdateControlsBy(currentPettyCash);
                //UpdateControlStatus();

            }

        }
        private void LoadParts()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.rpi_lke_part.DataSource = context.GetComboStoreNo("SELECT DISTINCT Parts.PartID, Parts.PartName FROM Parts ORDER BY Parts.PartName");
                this.rpi_lke_part.DropDownRows = 20;
                this.rpi_lke_part.DisplayMember = "PartName";
                this.rpi_lke_part.ValueMember = "PartName";
            }
        }
        private void LoadEmployee()
        {
            lkeClearBy.Properties.DataSource = AppSetting.EmployessList;
            int employeeCount = AppSetting.EmployessList.Count();
            if (employeeCount > 20)
                lkeClearBy.Properties.DropDownRows = 20;
            else
                lkeClearBy.Properties.DropDownRows = employeeCount;
            lkeClearBy.Properties.DisplayMember = "VietnamName";
            lkeClearBy.Properties.ValueMember = "EmployeeID";
            lkeClearBy.EditValue = AppSetting.CurrentUser.EmployeeID;

            lkePaymentTo.Properties.DataSource = AppSetting.EmployessList;

                lkePaymentTo.Properties.DropDownRows = 20;
            lkePaymentTo.Properties.DisplayMember = "VietnamName";
            lkePaymentTo.Properties.ValueMember = "EmployeeID";
            lkePaymentTo.EditValue = AppSetting.CurrentUser.EmployeeID;
        }

        private void LoadCurrency()
        {     
            List<string> lst = new List<string>();
            lst.Add("VND");
            lst.Add("USD");
            lst.Add("HKD");
            lst.Add("AUD");
            this.lkeCurrency.Properties.DataSource = lst;
            this.lkeCurrency.EditValue = "VND";

            List<string> lst2 = new List<string>();
            lst2.Add("CASH");
            lst2.Add("TT");

            this.lkePaymentType.Properties.DataSource = lst2;
            this.lkePaymentType.EditValue = "CASH";
        }


        private void LoadExpCategory()
        {
            List<string> lst = new List<string>();
            lst.Add("Hotel");
            lst.Add("Transp.");
            lst.Add("Fuel");
            lst.Add("Meals");
            lst.Add("Phone");
            lst.Add("Entert.");
            this.rpi_lke_exp_category.DataSource = lst;
            this.rpi_lke_exp_category.DropDownRows = 7;
            this.rpi_lke_exp_category.NullText = "";
        }
        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lkeStores.Properties.DataSource = storeDA.Select();
            this.lkeStores.Properties.ValueMember = "StoreID";
            this.lkeStores.Properties.DisplayMember = "StoreDescription";
            this.lkeStores.EditValue = AppSetting.CurrentUser.StoreID;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtngPettyCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngPettyCash.Position = dtngPettyCash.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngPettyCash.Position = dtngPettyCash.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngPettyCash.Position = 0;
            else if (e.KeyData == Keys.Down)
                dtngPettyCash.Position = ((IList<PettyCash>)dtngPettyCash.DataSource).Count;
        }

        private void dtngPettyCash_PositionChanged(object sender, EventArgs e)
        {
            //updateInfoPettyCash();
            currentPettyCash = pettyCashList.ElementAt(dtngPettyCash.Position);
            saveCurrentPettyCash = currentPettyCash;
            UpdateControlsBy(currentPettyCash);
            UpdateControlStatus();
        }

        private void UpdateControlsBy(PettyCash yourcurrentPettyCash)
        {
            currentPettyCash = yourcurrentPettyCash;
            txtPettyCashRecordNumber.EditValue = currentPettyCash.PettyCashNumber;
            memoAdRemark.Text = currentPettyCash.AdvanceRemark;
            memoEpRemark.Text = currentPettyCash.Remark;
            txtAdAmount.Text = currentPettyCash.AdvanceAmount.ToString();
            dteAdDate.EditValue = currentPettyCash.AdvanceDate;
            dateCleared.EditValue = currentPettyCash.ActionDate;
            txtCreatedBy.Text = currentPettyCash.OrderBy;
            lkeStores.EditValue = currentPettyCash.StoreID;
            lkeCurrency.EditValue = currentPettyCash.Currency;
            lkeClearBy.EditValue = currentPettyCash.ClearBy;
            lkePaymentTo.EditValue = currentPettyCash.PaymentTo;
            lkePaymentType.EditValue = currentPettyCash.PaymentMethod;
            LoadPCDetails();
            LoadParts();

        }

        private void LoadPCDetails()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                var dts = context.GetComboStoreNo("ST_WMS_PettyCashDetails " + currentPettyCash.PettyCashID);
                this.PettyCashDetailsList = new List<PettyCashDetails>();
                PettyCashDetailsList = (from DataRow row in dts.Rows
                                        select new PettyCashDetails
                                        {
                                            PettyCashDetailID = Convert.ToInt32(row["PettyCashDetailID"].ToString()),
                                            PartID = Convert.ToInt32(row["PartID"].ToString()),
                                            PartName = row["PartName"].ToString(),
                                            Quantity = Convert.ToInt32(row["Quantity"].ToString()),
                                            Net = row["Net"].ToString(),
                                            VAT = row["VAT"].ToString(),
                                            ExpenseAmount = row["ExpenseAmount"].ToString(),
                                            ExpensesDate = Convert.ToDateTime(row["ExpensesDate"].ToString()),
                                            ItemRemark = row["ItemRemark"].ToString(),
                                            DocumentNumber = row["DocumentNumber"].ToString(),
                                            ExpenseCategory = row["ExpenseCategory"].ToString()
                                        }).ToList();
                this.grcPettyDetails.DataSource = new BindingList<PettyCashDetails>(PettyCashDetailsList);
            }
        }

        private void UpdateControlStatus()
        {
            Boolean isCleared = false;

            if(this.pettyCashList.Count > 0)
            {
                if (string.Equals(this.currentPettyCash.ClearStatus, "false", StringComparison.OrdinalIgnoreCase))
                {
                    isCleared = false;
                    this.btn_accept.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                    btn_accept.Appearance.Options.UseBackColor = true;
                    this.btn_Clear.Appearance.BackColor = DXSkinColors.FillColors.Primary;
                    btn_Clear.Appearance.Options.UseBackColor = true;
                    this.btn_Delete.Appearance.BackColor = DXSkinColors.FillColors.Danger;
                    btn_Delete.Appearance.Options.UseBackColor = true;
                    this.btn_NewItem.Appearance.BackColor = DXSkinColors.FillColors.Success;
                    btn_NewItem.Appearance.Options.UseBackColor = true;
                    this.btn_Update.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                    btn_Update.Appearance.Options.UseBackColor = true;
                }
                else
                {
                    isCleared = true;
                    this.btn_accept.Appearance.BackColor = Color.DarkGray;
                    btn_accept.Appearance.Options.UseBackColor = true;
                    this.btn_Clear.Appearance.BackColor = Color.DarkGray;
                    btn_Clear.Appearance.Options.UseBackColor = true;
                    this.btn_Delete.Appearance.BackColor = Color.DarkGray;
                    btn_Delete.Appearance.Options.UseBackColor = true;
                    this.btn_NewItem.Appearance.BackColor = Color.DarkGray;
                    btn_NewItem.Appearance.Options.UseBackColor = true;
                    this.btn_Update.Appearance.BackColor = Color.DarkGray;
                    btn_Update.Appearance.Options.UseBackColor = true;
                }
            }
            
            else
            {
                this.txtPettyCashRecordNumber.Text = "";
                isCleared = true;
                this.btn_accept.Appearance.BackColor = Color.DarkGray;
                btn_accept.Appearance.Options.UseBackColor = true;
                this.btn_Clear.Appearance.BackColor = Color.DarkGray;
                btn_Clear.Appearance.Options.UseBackColor = true;
                this.btn_Delete.Appearance.BackColor = Color.DarkGray;
                btn_Delete.Appearance.Options.UseBackColor = true;
                this.btn_NewItem.Appearance.BackColor = Color.DarkGray;
                btn_NewItem.Appearance.Options.UseBackColor = true;
                this.btn_Update.Appearance.BackColor = Color.DarkGray;
                btn_Update.Appearance.Options.UseBackColor = true;
            }

            
                
            
            this.lkeClearBy.ReadOnly = isCleared;
            this.txtAdAmount.ReadOnly = isCleared;
            this.memoAdRemark.ReadOnly = isCleared;
            this.memoEpRemark.ReadOnly = isCleared;
            this.dteAdDate.ReadOnly = isCleared;
            this.dateCleared.ReadOnly = isCleared;
            this.lkeCurrency.ReadOnly = isCleared;
            this.lkeStores.ReadOnly = isCleared;
            this.lkePaymentTo.ReadOnly = isCleared;
            this.lkePaymentType.ReadOnly = isCleared;

            this.grvPettyDetails.OptionsBehavior.ReadOnly = isCleared;

            //this.btn_accept.Enabled = !isCleared;
            this.btn_Clear.Enabled = !isCleared;
            this.btn_Delete.Enabled = !isCleared;
            this.btn_NewItem.Enabled = !isCleared;
            this.btn_Update.Enabled = !isCleared;
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            Init();
            //if (this.pettyCashList.Count > 0)
            //{
            //    currentPettyCash = pettyCashList.ElementAt(dtngPettyCash.Position);
            //    saveCurrentPettyCash = currentPettyCash;
            //    UpdateControlsBy(currentPettyCash);
            //    UpdateControlStatus();
            //}
            //else
            UpdateControlStatus();
        }

        private void btn_NewPettyCash_Click(object sender, EventArgs e)
        {
            
            grcPettyDetails.DataSource = new BindingList<PettyCashDetails>(new List<PettyCashDetails>());
            txtPettyCashRecordNumber.EditValue = null;
            memoAdRemark.EditValue = "";
            memoEpRemark.EditValue = "";
            this.txtAdAmount.EditValue = "";


            dteAdDate.EditValue = DateTime.Today;
            dateCleared.EditValue = DateTime.Today;
            txtCreatedBy.EditValue = AppSetting.CurrentUser.LoginName +" - "+ DateTime.Now.ToString("dd/MM/y HH:mm");
            lkeStores.EditValue = AppSetting.StoreID;
            lkeCurrency.EditValue = "VND";
            lkeClearBy.EditValue = AppSetting.CurrentUser.EmployeeID;
            lkePaymentTo.EditValue = AppSetting.CurrentUser.EmployeeID;
            lkePaymentType.EditValue = "TT";
            //lkePaymentTo.EditValue = AppSetting.CurrentUser.EmployeeID;
            //lkePaymentType.EditValue = "CASH";

            using (PlantDBContext context = new PlantDBContext())
            {

                string sql = String.Format("insert into PettyCash ( " +
                    "ClearStatus,ClearBy,AdvanceDate, AdvanceAmount, AdvanceRemark, Currency,Remark, OrderBy, CreatedTime, StoreID, PaymentMethod, ActionDate) " +
                    "Values (0,{0},'{1}',{2},N'{3}','{4}',N'{5}','{6}','{7}',{8},'{9}','{10}')",
                    //this.dateCleared.EditValue.ToString(),
                    AppSetting.CurrentUser.EmployeeID,
                    DateTime.Today.ToString("yyyy-MM-dd"),
                    0,
                    "",
                    "VND",
                    "",
                    AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/y HH:mm"),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                    AppSetting.StoreID,
                    this.lkePaymentType.Text,
                    DateTime.Today.ToString("yyyy-MM-dd"));

                context.Delete(sql);

                Init();

                //for (int i = 0; i < this.PettyCashDetailsList.Count; i ++)
                //{

                //}
            }
        }

        private void grvPettyDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //grvPettyDetails.SetRowCellValue(e.RowHandle, "ExpensesDate", DateTime.Now.Date);
            //grvPettyDetails.SetRowCellValue(e.RowHandle, "Quantity", 1);

            //PettyCashDetails pcd = this.PettyCashDetailsList[grvPettyDetails.GetFocusedDataSourceRowIndex()];
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    string sql = String.Format("insert into PettyDetails (PettyCashID, " +
            //                    "Quantity, PartID, ExpensesDate, ItemDescription) " +
            //                    "Values ('{0}','{1}','{2}','{3}','{4}')",
            //                    this.currentPettyCash.PettyCashID,
            //                    pcd.Quantity,
            //                    pcd.PartID,
            //                    pcd.ExpensesDate.ToString(),
            //                    pcd.PartName
            //                    );
            //    context.Delete(sql);
            //}
            //LoadPCDetails();
        }

        private void grvPettyDetails_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string partSelected = Convert.ToString(this.grvPettyDetails.GetRowCellValue(e.RowHandle, this.grvPettyDetails.Columns["PartID"]));

            if (string.IsNullOrEmpty(partSelected))
            {

                LoadParts();
                this.gridColumnPartID.OptionsColumn.ReadOnly = false;
                this.gridColumnPartID.ColumnEdit = this.rpi_lke_part;
                this.rpi_lke_part.AllowFocused = true;
                this.rpi_lke_part.ImmediatePopup = true;
            }
        }

        private void rpi_lke_part_EditValueChanged(object sender, EventArgs e)
        {
            //var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            //if (selectedValue.GetColumnValue("PartName") != null)
            //{
            //    if (this.rpi_lke_part.GetDataSourceRowByKeyValue(selectedValue.Text) == null) return;
            //    int varPartID = Convert.ToInt32(selectedValue.GetColumnValue("PartID"));
            //    string varPartname = selectedValue.GetColumnValue("PartName").ToString();
            //    PettyCashDetails pcd = new PettyCashDetails();
            //    pcd.PartID = varPartID;
            //    pcd.PartName = varPartname;

            //    this.grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "PartID", varPartID);
            //    this.grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "PartName", varPartname);
            //    grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "ExpensesDate", DateTime.Now.Date);
            //    grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "Quantity", 1);
            //}
            
            


            //this.PettyCashDetailsList.Add(pcd);

        }
        private void grvPettyDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column == gridColumnVAT || e.Column == gridColumnAmount)
            {
                decimal vat = Convert.ToDecimal(grvPettyDetails.GetFocusedRowCellValue(gridColumnVAT));
                decimal amount = Convert.ToDecimal(grvPettyDetails.GetFocusedRowCellValue(gridColumnAmount));
                decimal net = amount - vat;
                grvPettyDetails.SetFocusedRowCellValue(gridColumnNet, net);
                //grvPettyDetails.SetFocusedRowCellValue(gridColumnRemark, this.PettyCashDetailsList.Count);
            }


            if(e.Column != gridColumnPartID && e.Column != gridColumnItemdesc && e.Column != gridColumn1)
            {
                PettyCashDetails pcd = this.PettyCashDetailsList[grvPettyDetails.GetFocusedDataSourceRowIndex()];
                if (pcd.PettyCashDetailID > 0)
                {
                    using (PlantDBContext context = new PlantDBContext())
                    {
                        string sql = String.Format("Update PettyDetails set " +
                                         "ItemDescription = N'{0}', Quantity = {1}, ItemRemark = N'{2}', PartID = {3},ExpensesDate = '{4}', " +
                                         "ExpenseAmount = {5}, VAT = {6}, DocumentNumber= '{7}',ExpenseCategory= '{8}'" +
                                         " WHERE PettyCashDetailID = {9} ",
                                         pcd.PartName,
                                         pcd.Quantity<=0 ? 1: pcd.Quantity,
                                         pcd.ItemRemark,
                                         pcd.PartID,
                                         pcd.ExpensesDate.ToString("yyyy-MM-dd"),
                                         pcd.ExpenseAmount ?? "0",
                                         pcd.VAT ?? "0",
                                         pcd.DocumentNumber ?? "",
                                         pcd.ExpenseCategory ?? "",
                                         pcd.PettyCashDetailID);

                        context.Delete(sql);
                    }
                }
                else if(pcd.PartID > 0)
                {
                    using (PlantDBContext context = new PlantDBContext())
                    {
                        string sql = String.Format("insert into PettyDetails (PettyCashID, " +
                                        "Quantity, PartID, ExpensesDate, ItemDescription) " +
                                        "Values ({0},{1},{2},'{3}',N'{4}') ; SELECT SCOPE_IDENTITY() AS SCOPE_ID",
                                        this.currentPettyCash.PettyCashID,
                                        pcd.Quantity <= 0 ? 1 : pcd.Quantity,
                                        pcd.PartID,
                                        pcd.ExpensesDate.ToString("yyyy-MM-dd"),
                                        pcd.PartName
                                        //pcd.ExpenseAmount ?? "0",
                                        //pcd.VAT ?? "0"
                                        );

                        var dataSource = context.GetComboStoreNo(sql);
                        this.PettyCashDetailsList[grvPettyDetails.GetFocusedDataSourceRowIndex()].PettyCashDetailID 
                            = Convert.ToInt32(dataSource.Rows[0]["SCOPE_ID"].ToString()); ;
                    }
                }
            }
            
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            updateInfoPettyCash();
            MessageBox.Show("Update Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Init();
        }
        private void updateInfoPettyCash()
        {
            if (this.txtPettyCashRecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {
                    string clearDate = "null";
                    if(this.dateCleared.EditValue != null && this.dateCleared.DateTime.ToString("yyyy-MM-dd")!="1900-01-01")
                    {
                        clearDate = "'" + this.dateCleared.DateTime.ToString("yyyy-MM-dd") + "'";
                    }
                    string sql = String.Format("update PettyCash set ActionDate = {0}," +
                        "ClearBy = {1},AdvanceDate = '{2}', AdvanceAmount = {3}, AdvanceRemark =N'{4}', Currency='{5}',Remark = N'{6}'," +
                        " OrderBy = '{7}', CreatedTime ='{8}' , StoreID ={9}, PaymentTo = {10},PaymentMethod= '{11}'  WHERE PettyCashID = {12}",
                        clearDate,
                        this.lkeClearBy.EditValue.ToString(),
                        this.dteAdDate.DateTime.ToString("yyyy-MM-dd"),
                        this.txtAdAmount.EditValue.ToString(),
                        this.memoAdRemark.Text,
                        this.lkeCurrency.EditValue.ToString(),
                        this.memoEpRemark.Text,
                        this.txtCreatedBy.Text,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        this.lkeStores.EditValue.ToString(),
                        this.lkePaymentTo.EditValue ?? "null",
                        this.lkePaymentType.EditValue.ToString(),
                        this.currentPettyCash.PettyCashID);
                    //"yyyy-MM-dd HH:mm:ss"
                    context.Delete(sql);

                    for (int i = 0; i < this.PettyCashDetailsList.Count; i++)
                    {
                        PettyCashDetails pcd = this.PettyCashDetailsList[i];
                        if (pcd.PettyCashDetailID > 0)
                        {
                            sql = String.Format("Update PettyDetails set " +
                                "ItemDescription = N'{0}', Quantity = {1}, ItemRemark = N'{2}', PartID = {3}, ExpensesDate = '{4}', " +
                                "ExpenseAmount = {5}, VAT = {6} ,DocumentNumber = '{7}',ExpenseCategory = '{8}'  WHERE PettyCashDetailID = {9} ",
                                pcd.PartName,
                                pcd.Quantity,
                                pcd.ItemRemark,
                                pcd.PartID,
                                pcd.ExpensesDate.ToString("yyyy-MM-dd"),
                                pcd.ExpenseAmount ?? "0",
                                pcd.VAT ?? "0",
                                pcd.DocumentNumber ?? "",
                                pcd.ExpenseCategory ?? "",
                                pcd.PettyCashDetailID);

                            context.Delete(sql);
                        }
                        else
                        {                   
                            sql = String.Format("insert into PettyDetails (PettyCashID, " +
                                "ItemDescription,Quantity,ItemRemark, PartID, ExpensesDate, ExpenseAmount,VAT,DocumentNumber,ExpenseCategory) " +
                                "Values ('{0}',N'{1}',{2},N'{3}',{4},'{5}',{6},{7},'{8}','{9}')",
                                this.currentPettyCash.PettyCashID,
                                pcd.PartName,
                                pcd.Quantity,
                                pcd.ItemRemark,
                                pcd.PartID,
                                pcd.ExpensesDate.ToString("yyyy-MM-dd"),
                                pcd.ExpenseAmount ?? "0",
                                pcd.VAT ?? "0",
                                pcd.DocumentNumber ?? "",
                                pcd.ExpenseCategory ?? ""
                                );

                            context.Delete(sql);
                        }
                    }
                }
                savePsosition = this.dtngPettyCash.Position;
                Update(savePsosition);
                //MessageBox.Show("Update Successfully!", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure to DELETE this PC?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            int position = grvPettyDetails.GetFocusedDataSourceRowIndex();
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = String.Format("SST_WMS_DeletePC " + this.currentPettyCash.PettyCashID);
                context.Delete(sql);
            }
            //grcPODetails.DataSource = new BindingList<PurchasingOrderDetails>(new List<PurchasingOrderDetails>());
            Init();

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure to clear all items?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = String.Format("Delete from PettyDetails Where PettyCashID = '{0}'",
                                this.currentPettyCash.PettyCashID);

                context.Delete(sql);
            }
            grcPettyDetails.DataSource = new BindingList<PettyCashDetails>(new List<PettyCashDetails>());
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            if (string.Equals(this.currentPettyCash.ClearStatus, "false", StringComparison.OrdinalIgnoreCase))
            {
                this.currentPettyCash.ClearStatus = "true";
                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = String.Format("Update PettyCash  set ClearStatus = 1 where PettyCashID = {0}" ,
                                    this.currentPettyCash.PettyCashID);
                    context.Delete(sql);
                }
                UpdateControlStatus();
            }
            else if (string.Equals(this.currentPettyCash.ClearStatus, "true", StringComparison.OrdinalIgnoreCase))
            {
                this.currentPettyCash.ClearStatus = "false";
                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = String.Format("Update PettyCash  set ClearStatus = 0 where PettyCashID = {0}",
                                    this.currentPettyCash.PettyCashID);
                    context.Delete(sql);
                }
                UpdateControlStatus();
            }
        }

        private void btn_NewItem_Click(object sender, EventArgs e)
        {
            frm_AD_NewItemPart frm = new frm_AD_NewItemPart();
            frm.FormClosing += new FormClosingEventHandler(this.frm_AD_PettyCash_FormClosing);
            frm.ShowDialog();
        }

        private void frm_AD_PettyCash_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadParts();
        }

        private void btn_PrintAdvance_Click(object sender, EventArgs e)
        {
            updateInfoPettyCash();
            //LoadPCDetails();
            rptPettyCashAdvance rpt = new rptPettyCashAdvance();
            //rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;

            using (PlantDBContext context = new PlantDBContext())
            {
                rpt.DataSource = context.GetComboStoreNo("SP_PettyCashAdvance " + this.currentPettyCash.PettyCashID);
                rpt.RequestParameters = false;
            }
            
            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();

        }

        private void btn_PrintExpense_Click(object sender, EventArgs e)
        {
            updateInfoPettyCash();
            //LoadPCDetails();
            rptPettyCashExpense rpt = new rptPettyCashExpense();
            rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;


            using (PlantDBContext context = new PlantDBContext())
            {
                rpt.DataSource = context.GetComboStoreNo("SP_PettyCashExpenses " + this.currentPettyCash.PettyCashID);
                rpt.RequestParameters = false;

            }

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();

        }

        private void btn_ItemReview_Click(object sender, EventArgs e)
        {
            //int propertyID = Convert.ToInt32(this.grvPettyDetails.GetFocusedRowCellValue("PartID"));
            //frm_AD_ItemReview frm = new frm_AD_ItemReview(propertyID);
            //frm.Show();
            //frm.WindowState = FormWindowState.Normal;
            //frm.BringToFront();
        }

        private void grcPettyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                
                int position = grvPettyDetails.GetFocusedDataSourceRowIndex();
                if (position < this.PettyCashDetailsList.Count)
                {
                    var dl = MessageBox.Show("Are you sure to DELETE this Item?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl.Equals(DialogResult.No)) return;
                    if (this.PettyCashDetailsList[position].PettyCashDetailID > 0)
                        using (PlantDBContext context = new PlantDBContext())
                        {
                            string sql = "delete from PettyDetails where PettyCashDetailID = " + this.PettyCashDetailsList[position].PettyCashDetailID;
                            context.Delete(sql);
                        }
                    this.PettyCashDetailsList.RemoveAt(position);
                    grcPettyDetails.DataSource = new BindingList<PettyCashDetails>(this.PettyCashDetailsList);
                }
            }
        }

        private void btnPaymentRequest_Click(object sender, EventArgs e)
        {
            updateInfoPettyCash();
            //LoadPCDetails();

            rptPettyCashPaymentRequest rpt2 = new rptPettyCashPaymentRequest();
            rpt2.Parameters["varCurrentUser2"].Value = AppSetting.CurrentUser.LoginName;

            using (PlantDBContext context = new PlantDBContext())
            {

                rpt2.DataSource = context.GetComboStoreNo("SP_PettyCashExpenses " + this.currentPettyCash.PettyCashID);
                rpt2.RequestParameters = false;
            }

            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2);
            printTool2.AutoShowParametersPanel = false;
            printTool2.ShowPreview();
        }

        private void rpi_hpl_expense_detail_Click(object sender, EventArgs e)
        {
            frm_AD_ExpenseDetails fre = new frm_AD_ExpenseDetails("PC", Convert.ToInt32(this.grvPettyDetails.GetFocusedRowCellValue("PettyCashDetailID")), currentPettyCash.PettyCashNumber);
            fre.Show();
            fre.BringToFront();
        }

        private void rpi_lke_part_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var selectedValue = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (selectedValue.GetColumnValue("PartName") != null)
            {
                if (this.rpi_lke_part.GetDataSourceRowByKeyValue(selectedValue.Text) == null) return;
                int varPartID = Convert.ToInt32(selectedValue.GetColumnValue("PartID"));
                string varPartname = selectedValue.GetColumnValue("PartName").ToString();
                PettyCashDetails pcd = new PettyCashDetails();
                pcd.PartID = varPartID;
                pcd.PartName = varPartname;

                this.grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "PartID", varPartID);
                this.grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "PartName", varPartname);
                grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "ExpensesDate", DateTime.Now.Date);
                grvPettyDetails.SetRowCellValue(this.grvPettyDetails.FocusedRowHandle, "Quantity", 1);
            }
        }
    }
}
