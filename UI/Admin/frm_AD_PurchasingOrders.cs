using Common.Controls;
using DA;
using DA.Management;
using DA.Warehouse;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helper;
using UI.ReportFile;

namespace UI.Admin
{
    public partial class frm_AD_PurchasingOrders : frmBaseForm
    {
        private List<AdvanceDetail> AdvanceDetailsList;
        private List<PurchaseOrder> POList;
        private int storeID;
        private PurchaseOrder currentPO;
        private PurchaseOrder saveCurrentPO;
        private List<PurchasingOrderDetail> PODetailsList;
        private int savePsosition = 0;
        public frm_AD_PurchasingOrders()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadSupplier();
            LoadStore();
            LoadParts();
            LoadCurrency();
            LoadDept();
            LoadCate();
            Init();
        }

        public frm_AD_PurchasingOrders(int purchasingOrderID)
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadSupplier();
            LoadStore();
            LoadParts();
            LoadCurrency();
            LoadDept();
            LoadCate();
            Init_POID(purchasingOrderID);
        }

        private void LoadStore()
        {
            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lkeStore.Properties.DataSource = storeDA.Select();
            this.lkeStore.Properties.ValueMember = "StoreID";
            this.lkeStore.Properties.DisplayMember = "StoreDescription";
            //this.lkeStore.EditValue = AppSetting.CurrentUser.StoreID;
        }

        private void Init_POID(int purchasingOrderID)
        {
            using (PlantDBContext context = new PlantDBContext())
            {

                storeID = AppSetting.CurrentUser.StoreID;


                string sql = "ST_WMS_PurchasingOrderList '" + AppSetting.CurrentUser.LoginName + "'," + purchasingOrderID;

                var dataSource = context.GetComboStoreNo(sql);

                this.POList = new List<PurchaseOrder>();

                if (dataSource != null)
                {


                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PurchaseOrder PO = new PurchaseOrder();

                        PO.PurchasingOrderID = Convert.ToInt32(dataSource.Rows[i]["PurchasingOrderID"].ToString());
                        PO.SupplierName = dataSource.Rows[i]["SupplierName"].ToString();
                        PO.PurchasingOrderNumber = dataSource.Rows[i]["PurchasingOrderNumber"].ToString();
                        PO.PuchasingDate = Convert.ToDateTime(dataSource.Rows[i]["PuchasingDate"].ToString());

                        PO.SupplierID = Convert.ToInt32(dataSource.Rows[i]["SupplierID"].ToString());

                        PO.OrderEmployeeID = Convert.ToInt32(dataSource.Rows[i]["OrderEmployeeID"].ToString());



                        PO.DeliveryAddress = dataSource.Rows[i]["DeliveryAddress"].ToString();
                        PO.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();

                        PO.OrderConfirmed = dataSource.Rows[i]["OrderConfirmed"].ToString();

                        PO.PurchasingRemark = dataSource.Rows[i]["PurchasingRemark"].ToString();
                        PO.DepartmentCategoryID = dataSource.Rows[i]["DepartmentCategoryID"].ToString();

                        PO.Currency = dataSource.Rows[i]["Currency"].ToString();

                        PO.ExchangeRate = Convert.ToDecimal(dataSource.Rows[i]["ExchangeRate"].ToString());

                        PO.InvoiceNumber = dataSource.Rows[i]["InvoiceNumber"].ToString();

                        PO.UsedPeriod = dataSource.Rows[i]["UsedPeriod"].ToString();


                        PO.StrategicSupplier = dataSource.Rows[i]["StrategicSupplier"].ToString();
                        PO.SupplierAddress = dataSource.Rows[i]["SupplierAddress"].ToString();
                        PO.SupplierContactName = dataSource.Rows[i]["SupplierContactName"].ToString();

                        PO.SupplierTitle = dataSource.Rows[i]["SupplierTitle"].ToString();
                        PO.SupplierPhone = dataSource.Rows[i]["SupplierPhone"].ToString();
                        PO.SupplierFax = dataSource.Rows[i]["SupplierFax"].ToString();
                        PO.SupplierEmail = dataSource.Rows[i]["SupplierEmail"].ToString();
                        PO.SupplierRemark = dataSource.Rows[i]["SupplierRemark"].ToString();

                        PO.SupplierFullName = dataSource.Rows[i]["SupplierFullName"].ToString();


                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["DeliveryDate"].ToString()))
                        {
                            PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["FinalPaymentDate"].ToString()))
                        {
                            PO.FinalPaymentDate = Convert.ToDateTime(dataSource.Rows[i]["FinalPaymentDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["AdvancePaymentDate"].ToString()))
                        {
                            PO.AdvancePaymentDate = Convert.ToDateTime(dataSource.Rows[i]["AdvancePaymentDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["ContractDate"].ToString()))
                        {
                            PO.ContractDate = Convert.ToDateTime(dataSource.Rows[i]["ContractDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["ContractExpiredDate"].ToString()))
                        {
                            PO.ContractExpiredDate = Convert.ToDateTime(dataSource.Rows[i]["ContractExpiredDate"].ToString());
                        }

                        //if (dataSource.Rows[i]["DeliveryDate"]!= null)
                        //    PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        //else
                        //    PO.DeliveryDate = null;

                        //try
                        //{
                        //    PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        //    PO.FinalPaymentDate = Convert.ToDateTime(dataSource.Rows[i]["FinalPaymentDate"].ToString());
                        //    PO.AdvancePaymentDate = Convert.ToDateTime(dataSource.Rows[i]["AdvancePaymentDate"].ToString());
                        //    PO.ContractDate = Convert.ToDateTime(dataSource.Rows[i]["ContractDate"].ToString());
                        //    PO.ContractExpiredDate = Convert.ToDateTime(dataSource.Rows[i]["ContractExpiredDate"].ToString());
                        //}
                        //catch
                        //{

                        //}


                        PO.RiskAssessmentRequired = dataSource.Rows[i]["RiskAssessmentRequired"].ToString();
                        PO.CompetitivePricingRequired = dataSource.Rows[i]["CompetitivePricingRequired"].ToString();
                        PO.ContractNumber = dataSource.Rows[i]["ContractNumber"].ToString();



                        PO.ContractRequired = dataSource.Rows[i]["ContractRequired"].ToString();
                        PO.DocumentFileScan = dataSource.Rows[i]["DocumentFileScan"].ToString();
                        PO.SpecialRequirement = dataSource.Rows[i]["SpecialRequirement"].ToString();
                        PO.StoreNumber = dataSource.Rows[i]["StoreNumber"].ToString();
                        PO.StoreDescription = dataSource.Rows[i]["StoreDescription"].ToString();
                        PO.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PO.CreatedBy = dataSource.Rows[i]["CreatedBy"].ToString();

                        this.POList.Add(PO);
                    }


                    this.dtngPurchasingOrder.DataSource = POList;
                    int position = POList.Count - 1;
                    int current_position = dtngPurchasingOrder.Position;
                    dtngPurchasingOrder.Position = position;
                    if (current_position == 0 && position == 0)
                    {
                        currentPO = POList.ElementAt(dtngPurchasingOrder.Position);
                        saveCurrentPO = currentPO;
                        UpdateControlsBy(currentPO);
                        UpdateControlStatus();
                    }
                }
            }
        }


        private void Init()
        {
            using (PlantDBContext context = new PlantDBContext())
            {

                storeID = AppSetting.CurrentUser.StoreID;


                string sql = "ST_WMS_PurchasingOrderList '" + AppSetting.CurrentUser.LoginName+"'";
                //string sql = "ST_WMS_PurchasingOrderList 'trung'";

                var dataSource = context.GetComboStoreNo(sql);

                this.POList = new List<PurchaseOrder>();

                if (dataSource != null)
                {


                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PurchaseOrder PO = new PurchaseOrder();

                        PO.PurchasingOrderID = Convert.ToInt32(dataSource.Rows[i]["PurchasingOrderID"].ToString());
                        PO.SupplierName = dataSource.Rows[i]["SupplierName"].ToString();
                        PO.PurchasingOrderNumber = dataSource.Rows[i]["PurchasingOrderNumber"].ToString();
                        PO.PuchasingDate = Convert.ToDateTime(dataSource.Rows[i]["PuchasingDate"].ToString());

                        PO.SupplierID = Convert.ToInt32(dataSource.Rows[i]["SupplierID"].ToString());

                        PO.OrderEmployeeID = Convert.ToInt32(dataSource.Rows[i]["OrderEmployeeID"].ToString());



                        PO.DeliveryAddress = dataSource.Rows[i]["DeliveryAddress"].ToString();
                        PO.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();

                        PO.OrderConfirmed = dataSource.Rows[i]["OrderConfirmed"].ToString();

                        PO.PurchasingRemark = dataSource.Rows[i]["PurchasingRemark"].ToString();
                        PO.DepartmentCategoryID = dataSource.Rows[i]["DepartmentCategoryID"].ToString();

                        PO.Currency = dataSource.Rows[i]["Currency"].ToString();

                        PO.ExchangeRate = Convert.ToDecimal(dataSource.Rows[i]["ExchangeRate"].ToString());

                        PO.InvoiceNumber = dataSource.Rows[i]["InvoiceNumber"].ToString();

                        PO.UsedPeriod = dataSource.Rows[i]["UsedPeriod"].ToString();


                        PO.StrategicSupplier = dataSource.Rows[i]["StrategicSupplier"].ToString();
                        PO.SupplierAddress = dataSource.Rows[i]["SupplierAddress"].ToString();
                        PO.SupplierContactName = dataSource.Rows[i]["SupplierContactName"].ToString();

                        PO.SupplierTitle = dataSource.Rows[i]["SupplierTitle"].ToString();
                        PO.SupplierPhone = dataSource.Rows[i]["SupplierPhone"].ToString();
                        PO.SupplierFax = dataSource.Rows[i]["SupplierFax"].ToString();
                        PO.SupplierEmail = dataSource.Rows[i]["SupplierEmail"].ToString();
                        PO.SupplierRemark = dataSource.Rows[i]["SupplierRemark"].ToString();

                        PO.SupplierFullName = dataSource.Rows[i]["SupplierFullName"].ToString();


                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["DeliveryDate"].ToString()))
                        {
                            PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["FinalPaymentDate"].ToString()))
                        {
                            PO.FinalPaymentDate = Convert.ToDateTime(dataSource.Rows[i]["FinalPaymentDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["AdvancePaymentDate"].ToString()))
                        {
                            PO.AdvancePaymentDate = Convert.ToDateTime(dataSource.Rows[i]["AdvancePaymentDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["ContractDate"].ToString()))
                        {
                            PO.ContractDate = Convert.ToDateTime(dataSource.Rows[i]["ContractDate"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dataSource.Rows[i]["ContractExpiredDate"].ToString()))
                        {
                            PO.ContractExpiredDate = Convert.ToDateTime(dataSource.Rows[i]["ContractExpiredDate"].ToString());
                        }

                        //if (dataSource.Rows[i]["DeliveryDate"]!= null)
                        //    PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        //else
                        //    PO.DeliveryDate = null;

                        //try
                        //{
                        //    PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                        //    PO.FinalPaymentDate = Convert.ToDateTime(dataSource.Rows[i]["FinalPaymentDate"].ToString());
                        //    PO.AdvancePaymentDate = Convert.ToDateTime(dataSource.Rows[i]["AdvancePaymentDate"].ToString());
                        //    PO.ContractDate = Convert.ToDateTime(dataSource.Rows[i]["ContractDate"].ToString());
                        //    PO.ContractExpiredDate = Convert.ToDateTime(dataSource.Rows[i]["ContractExpiredDate"].ToString());
                        //}
                        //catch
                        //{

                        //}


                        PO.RiskAssessmentRequired = dataSource.Rows[i]["RiskAssessmentRequired"].ToString();
                        PO.CompetitivePricingRequired = dataSource.Rows[i]["CompetitivePricingRequired"].ToString();
                        PO.ContractNumber = dataSource.Rows[i]["ContractNumber"].ToString();



                        PO.ContractRequired = dataSource.Rows[i]["ContractRequired"].ToString();
                        PO.DocumentFileScan = dataSource.Rows[i]["DocumentFileScan"].ToString();
                        PO.SpecialRequirement = dataSource.Rows[i]["SpecialRequirement"].ToString();
                        PO.StoreNumber = dataSource.Rows[i]["StoreNumber"].ToString();
                        PO.StoreDescription = dataSource.Rows[i]["StoreDescription"].ToString();
                        PO.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PO.CreatedBy = dataSource.Rows[i]["CreatedBy"].ToString();

                        this.POList.Add(PO);
                    }


                    this.dtngPurchasingOrder.DataSource = POList;
                    int position = POList.Count - 1;
                    int current_position = dtngPurchasingOrder.Position;
                    dtngPurchasingOrder.Position = position;
                    if (current_position == 0 && position == 0)
                    {
                        currentPO = POList.ElementAt(dtngPurchasingOrder.Position);
                        saveCurrentPO = currentPO;
                        UpdateControlsBy(currentPO);
                        UpdateControlStatus();
                    }
                }
            }
        }

        private void dtngPurchasingOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                dtngPurchasingOrder.Position = dtngPurchasingOrder.Position - 1;
            else if (e.KeyData == Keys.Right)
                dtngPurchasingOrder.Position = dtngPurchasingOrder.Position + 1;
            else if (e.KeyData == Keys.Up)
                dtngPurchasingOrder.Position = 0;
            else if (e.KeyData == Keys.Down)
            {
                dtngPurchasingOrder.Position = ((IList<PurchaseOrder>)dtngPurchasingOrder.DataSource).Count;
            }
        }

        private void dtngPurchasingOrder_PositionChanged(object sender, EventArgs e)
        {
            currentPO = POList.ElementAt(dtngPurchasingOrder.Position);
            saveCurrentPO = currentPO;
            UpdateControlsBy(currentPO);
            UpdateControlStatus();
        }

        private void UpdateControlsBy(PurchaseOrder yourcurrentPO)
        {
            currentPO = yourcurrentPO;
            txtPORecordNumber.EditValue = currentPO.PurchasingOrderNumber;
            txtOrderBy.Text = currentPO.OrderBy;
            dteOrderDate.EditValue = currentPO.PuchasingDate;
            lkeStore.EditValue = currentPO.StoreID;
            txtContractNo.Text = currentPO.ContractNumber;
            mmSpecRequirement.Text = currentPO.SpecialRequirement;
            dteDeliveryDate.EditValue = currentPO.DeliveryDate;
            dteAdvPayment.EditValue = currentPO.AdvancePaymentDate;
            dteContractDate.EditValue = currentPO.ContractDate;
            lkeCurrency.EditValue = currentPO.Currency;
            dteFinalPayment.EditValue = currentPO.FinalPaymentDate;
            dteContractExpired.EditValue = currentPO.ContractExpiredDate;
            txtAdAmount.Text = currentPO.ExchangeRate.ToString();
            txtInvoiceNo.Text = currentPO.InvoiceNumber;
            lkeSupplier.EditValue = currentPO.SupplierID;
            //txtSupplierNumber.Text = currentPO.SupplierName;
            txtSuppFullName.Text = currentPO.SupplierFullName;
            txtAddress.Text = currentPO.SupplierAddress;
            txtRemark.Text = currentPO.PurchasingRemark;
            txtSupContact.Text = currentPO.SupplierContactName;
            txtPhone.Text = currentPO.SupplierPhone;
            //txtFax.Text = currentPO.SupplierFax;
            txtUsedPeriod.EditValue = currentPO.UsedPeriod;

            if (
                string.Equals(this.currentPO.StrategicSupplier, "true", StringComparison.OrdinalIgnoreCase))
            {
                ckStrategic.Checked = true;
            }
            else
            {
                ckStrategic.Checked = false;
            }


            if (
                string.Equals(this.currentPO.ContractRequired, "true", StringComparison.OrdinalIgnoreCase))
            {
                ckContract.Checked = true;
            }
            else
            {
                ckContract.Checked = false;
            }

            if (
                string.Equals(this.currentPO.CompetitivePricingRequired, "true", StringComparison.OrdinalIgnoreCase))
            {
                ckCompetitivePricing.Checked = true;
            }
            else
            {
                ckCompetitivePricing.Checked = false;
            }

            if (
                string.Equals(this.currentPO.RiskAssessmentRequired, "true", StringComparison.OrdinalIgnoreCase))
            {
                ckRisk.Checked = true;
            }
            else
            {
                ckRisk.Checked = false;
            }

            LoadPODetails();
            //memoAdRemark.Text = currentPettyCash.AdvanceRemark;
            //memoEpRemark.Text = currentPettyCash.Remark;
            //txtAdAmount.Text = currentPettyCash.AdvanceAmount.ToString();
            //dteAdDate.EditValue = currentPettyCash.AdvanceDate;
            //dateCleared.EditValue = currentPettyCash.ActionDate;
            //txtCreatedBy.Text = currentPettyCash.OrderBy;
            //lkeStores.EditValue = currentPettyCash.StoreID;
            //lkeCurrency.EditValue = currentPettyCash.Currency;
            //lkeClearBy.EditValue = currentPettyCash.ClearBy;
            //LoadPCDetails();
            //LoadParts();

        }

        private void LoadPODetails()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                var dts = context.GetComboStoreNo("ST_WMS_PurchasingOrderDetailList " + currentPO.PurchasingOrderID);
                this.PODetailsList = new List<PurchasingOrderDetail>();


                if (dts != null)
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        PurchasingOrderDetail POD = new PurchasingOrderDetail();
                        POD.PartGroupID = Convert.ToInt32(dts.Rows[i]["PartGroupID"].ToString());
                        POD.PurchasingOrderDetailID = Convert.ToInt32(dts.Rows[i]["PurchasingOrderDetailID"].ToString());
                        POD.PurchasingOrderID = Convert.ToInt32(dts.Rows[i]["PurchasingOrderID"].ToString());
                        POD.PartID = Convert.ToInt32(dts.Rows[i]["PartID"].ToString());
                        POD.UnitPriceUSD = dts.Rows[i]["UnitPriceUSD"].ToString();
                        POD.UnitPriceVND = dts.Rows[i]["UnitPriceVND"].ToString();
                        POD.ItemRemark = dts.Rows[i]["ItemRemark"].ToString();
                        POD.Remark = dts.Rows[i]["Remark"].ToString();
                        POD.DepartmentCategoryID = dts.Rows[i]["DepartmentCategoryID"].ToString();
                        POD.PropertyCategoryID = dts.Rows[i]["PropertyCategoryID"].ToString();
                        POD.Status = Convert.ToInt32(dts.Rows[i]["Status"].ToString());
                        POD.ts = dts.Rows[i]["ts"].ToString();
                        POD.OrderQuantity = dts.Rows[i]["OrderQuantity"].ToString();
                        POD.DeliveryQuantity = dts.Rows[i]["DeliveryQuantity"].ToString();
                        POD.DeliveryDateDetail = Convert.ToDateTime(dts.Rows[i]["DeliveryDateDetail"].ToString());
                        POD.PartName = dts.Rows[i]["PartName"].ToString();
                        POD.PartNumber = dts.Rows[i]["PartNumber"].ToString();
                        POD.Amount = dts.Rows[i]["Amount"].ToString();
                        PODetailsList.Add(POD);
                    }




                //PODetailsList = (from DataRow row in dts.Rows
                //                        select new PurchasingOrderDetail
                //                        {
                //                            //PettyCashDetailID = Convert.ToInt32(row["PettyCashDetailID"].ToString()),
                //                            //PartID = Convert.ToInt32(row["PartID"].ToString()),
                //                            //PartName = row["PartName"].ToString(),
                //                            //Quantity = Convert.ToInt32(row["Quantity"].ToString()),
                //                            //Net = row["Net"].ToString(),
                //                            //VAT = row["VAT"].ToString(),
                //                            //ExpenseAmount = row["ExpenseAmount"].ToString(),
                //                            //ExpensesDate = Convert.ToDateTime(row["ExpensesDate"].ToString()),
                //                            //ItemRemark = row["ItemRemark"].ToString()
                //                            PartGroupID = Convert.ToInt32(row["PartGroupID"].ToString()),
                //                            PurchasingOrderDetailID = Convert.ToInt32(row["PurchasingOrderDetailID"].ToString()),
                //                            PurchasingOrderID = Convert.ToInt32(row["PurchasingOrderID"].ToString()),
                //                            PartID = Convert.ToInt32(row["PartID"].ToString()),
                //                            UnitPriceUSD = row["UnitPriceUSD"].ToString(),
                //                            UnitPriceVND = row["UnitPriceVND"].ToString(),
                //                            ItemRemark = row["ItemRemark"].ToString(),
                //                            Remark = row["Remark"].ToString(),
                //                            DepartmentCategoryID = row["DepartmentCategoryID"].ToString(),
                //                            PropertyCategoryID = row["PropertyCategoryID"].ToString(),
                //                            Status = Convert.ToInt32(row["Status"].ToString()),
                //                            ts = row["ts"].ToString(),
                //                            OrderQuantity = row["OrderQuantity"].ToString(),
                //                            DeliveryQuantity = row["DeliveryQuantity"].ToString(),
                //                            DeliveryDateDetail = Convert.ToDateTime(row["DeliveryDateDetail"].ToString()),
                //                            PartName = row["PartName"].ToString(),
                //                            PartNumber = row["PartNumber"].ToString()
                //                        }).ToList();
                this.grcPODetail.DataSource = new BindingList<PurchasingOrderDetail>(PODetailsList);
            }
        }


        private void UpdateControlStatus()
        {
            Boolean isConfirmed = false;

            if (this.POList.Count > 0)
            {
                if (string.Equals(this.currentPO.OrderConfirmed, "false", StringComparison.OrdinalIgnoreCase))
                {
                    isConfirmed = false;
                    this.btn_Delete.Appearance.BackColor = DXSkinColors.FillColors.Danger;
                    btn_Delete.Appearance.Options.UseBackColor = true;
                    this.btn_deleteAdvance.Appearance.BackColor = DXSkinColors.FillColors.Danger;
                    btn_deleteAdvance.Appearance.Options.UseBackColor = true;
                    this.btn_Confirm.Appearance.BackColor = DXSkinColors.FillColors.Warning;
                    btn_Confirm.Appearance.Options.UseBackColor = true;
                    this.btn_Accept.Appearance.BackColor = DXSkinColors.FillColors.Primary;
                    btn_Accept.Appearance.Options.UseBackColor = true;
                }
                else
                {
                    isConfirmed = true;
                    this.btn_Delete.Appearance.BackColor = Color.DarkGray;
                    btn_Delete.Appearance.Options.UseBackColor = true;
                    this.btn_deleteAdvance.Appearance.BackColor = Color.DarkGray;
                    btn_deleteAdvance.Appearance.Options.UseBackColor = true;
                    this.btn_Confirm.Appearance.BackColor = Color.DarkGray;
                    btn_Confirm.Appearance.Options.UseBackColor = true;
                    this.btn_Accept.Appearance.BackColor = Color.DarkGray;
                    btn_Accept.Appearance.Options.UseBackColor = true;
                }
            }

            else
            {
                isConfirmed = true;
                this.btn_Delete.Appearance.BackColor = Color.DarkGray;
                btn_Delete.Appearance.Options.UseBackColor = true;
                this.btn_deleteAdvance.Appearance.BackColor = Color.DarkGray;
                btn_deleteAdvance.Appearance.Options.UseBackColor = true;
                this.btn_Confirm.Appearance.BackColor = Color.DarkGray;
                btn_Confirm.Appearance.Options.UseBackColor = true;
                this.btn_Accept.Appearance.BackColor = Color.DarkGray;
                btn_Accept.Appearance.Options.UseBackColor = true;
                this.txtPORecordNumber.Text = "";
            }


            this.dteOrderDate.ReadOnly = isConfirmed;
            this.lkeStore.ReadOnly = isConfirmed;
            this.dteDeliveryDate.ReadOnly = isConfirmed;
            this.dteAdvPayment.ReadOnly = isConfirmed;
            this.dteContractDate.ReadOnly = isConfirmed;
            this.lkeCurrency.ReadOnly = isConfirmed;
            this.dteFinalPayment.ReadOnly = isConfirmed;
            this.dteContractExpired.ReadOnly = isConfirmed;
            this.txtUsedPeriod.ReadOnly = isConfirmed;
            this.txtContractNo.ReadOnly = isConfirmed;
            this.mmSpecRequirement.ReadOnly = isConfirmed;
            this.txtAdAmount.ReadOnly = isConfirmed;
            this.txtInvoiceNo.ReadOnly = isConfirmed;
            this.ckContract.ReadOnly = isConfirmed;
            this.ckCompetitivePricing.ReadOnly = isConfirmed;
            this.ckRisk.ReadOnly = isConfirmed;
            this.ckStrategic.ReadOnly = isConfirmed;
            this.txtRemark.ReadOnly = isConfirmed;


            //this.dateCleared.ReadOnly = isCleared;
            //this.lkeCurrency.ReadOnly = isCleared;
            //this.lkeStores.ReadOnly = isCleared;
            //this.memoAdRemark.ReadOnly = isCleared;
            //this.memoEpRemark.ReadOnly = isCleared;
            //this.dteAdDate.ReadOnly = isCleared;
            //this.dateCleared.ReadOnly = isCleared;
            //this.lkeCurrency.ReadOnly = isCleared;
            //this.lkeStores.ReadOnly = isCleared;
            //this.memoAdRemark.ReadOnly = isCleared;
            //this.memoEpRemark.ReadOnly = isCleared;
            //this.dteAdDate.ReadOnly = isCleared;
            //this.dateCleared.ReadOnly = isCleared;
            //this.lkeCurrency.ReadOnly = isCleared;
            //this.lkeStores.ReadOnly = isCleared;




            this.grvPODetail.OptionsBehavior.ReadOnly = isConfirmed;
            this.grvAdvances.OptionsBehavior.ReadOnly = isConfirmed;

            this.btn_Accept.Enabled = !isConfirmed;
            this.btn_Confirm.Enabled = !isConfirmed;
            this.btn_Delete.Enabled = !isConfirmed;
            this.btn_deleteAdvance.Enabled = !isConfirmed;
        }
        private void LoadCurrency()
        {
            List<string> lst = new List<string>();
            lst.Add("VND");
            lst.Add("USD");
            lst.Add("HKD");
            lst.Add("AUD");
            lst.Add("EUR");
            lst.Add("GBP");
            lst.Add("NON");
            lst.Add("SGD");
            this.lkeCurrency.Properties.DataSource = lst;
            //this.lkeCurrency.EditValue = "VND";

            //List<string> lst2 = new List<string>();
            //lst2.Add("CASH");
            //lst2.Add("TT");

            //this.lkePaymentType.Properties.DataSource = lst2;
            //this.lkePaymentType.EditValue = "CASH";
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

        private void LoadDept()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.rpi_lke_dept.DataSource = context.GetComboStoreNo("SELECT DepartmentCategories.* FROM DepartmentCategories");
                this.rpi_lke_dept.DropDownRows = 20;
                this.rpi_lke_dept.DisplayMember = "DepartmentCategoryID";
                this.rpi_lke_dept.ValueMember = "DepartmentCategoryID";
            }
        }

        private void LoadCate()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.rpi_lke_cate.DataSource = context.GetComboStoreNo("SELECT PropertyCategories.PropertyCategoryID, PropertyCategories.PropertyCategoryNumber, PropertyCategories.PropertyCategoryDescription FROM PropertyCategories");
                this.rpi_lke_cate.DropDownRows = 20;
                this.rpi_lke_cate.DisplayMember = "PropertyCategoryNumber";
                this.rpi_lke_cate.ValueMember = "PropertyCategoryID";
            }
        }

        private void LoadSupplier()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                this.lkeSupplier.Properties.DataSource = context.GetComboStoreNo("SELECT   SupplierID, SupplierName, " +
                    "SupplierAddress, SupplierContactName, SupplierTitle, SupplierPhone, SupplierFax, SupplierEmail, " +
                    "SupplierRemark, SupplierFullName, StrategicSupplier, ts, CreatedBy, CreatedTime, UpdatedBy, " +
                    "SupplierTaxCode, SupplierBankAccountNumber, SupplierBankAccountName, SupplierOldID, " +
                    "SupplierMobile, SupplierWebsite, SupplierCategoryID FROM Suppliers ORDER BY SupplierName");
                this.lkeSupplier.Properties.DropDownRows = 20;
                this.lkeSupplier.Properties.DisplayMember = "SupplierName";
                this.lkeSupplier.Properties.ValueMember = "SupplierID";
                //this.lkeSupplier.EditValue = AppSetting.CurrentUser.StoreID;
            }
        }

        private void btn_NewPO_Click(object sender, EventArgs e)
        {
            grcPODetail.DataSource = new BindingList<PurchasingOrderDetail>(new List<PurchasingOrderDetail>());
            txtPORecordNumber.Text = "";
            this.lkeSupplier.Focus();
            this.lkeSupplier.ShowPopup();

            //memoAdRemark.EditValue = "";
            //memoEpRemark.EditValue = "";
            //this.txtAdAmount.EditValue = "";


            //dteAdDate.EditValue = DateTime.Today;
            //dateCleared.EditValue = null;
            //txtCreatedBy.EditValue = AppSetting.CurrentUser.LoginName + " - " + DateTime.Now;
            //lkeStores.EditValue = AppSetting.StoreID;
            //lkeCurrency.EditValue = "VND";
            //lkeClearBy.EditValue = AppSetting.CurrentUser.EmployeeID;

            //using (PlantDBContext context = new PlantDBContext())
            //{

            //    string sql = String.Format("INSERT INTO PurchasingOrders (PuchasingDate, SupplierID, OrderBy) VALUES ('{0}', {1}, N'{2}')",
            //        //this.dateCleared.EditValue.ToString(),
            //        DateTime.Now.Date.ToString(),
            //        this.lkeSupplier.GetColumnValue("SupplierID"),
            //        AppSetting.CurrentUser.EmployeeID);

            //    context.Delete(sql);

            //    Init();

            //}
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_PreviewNote_Click(object sender, EventArgs e)
        {
            rptPurchasingOrderNote rpt = new rptPurchasingOrderNote();
            //rpt.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;

            using (PlantDBContext context = new PlantDBContext())
            {
                rpt.DataSource = context.GetComboStoreNo("SP_GoodsReceivedNote " + this.currentPO.PurchasingOrderID);
                rpt.RequestParameters = false;
            }

            ReportPrintToolWMS printTool = new ReportPrintToolWMS(rpt);
            printTool.AutoShowParametersPanel = false;
            printTool.ShowPreview();
        }

        private void btn_CopyPO_Click(object sender, EventArgs e)
        {

        }

        private void btn_NewDetail_Click(object sender, EventArgs e)
        {

        }

        private void btn_PropertiesList_Click(object sender, EventArgs e)
        {
            frm_AD_NewItemPart frm = new frm_AD_NewItemPart();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btn_ReviewBySup_Click(object sender, EventArgs e)
        {
            int propertyID = Convert.ToInt32(this.grvPODetail.GetFocusedRowCellValue("PartID"));
            frm_AD_ItemReview frm = new frm_AD_ItemReview(propertyID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btn_SupplierList_Click(object sender, EventArgs e)
        {
            frm_AD_SupplierList frm = new frm_AD_SupplierList();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure to delete this PO ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = String.Format("ST_WMS_DeletePO " + this.currentPO.PurchasingOrderID);
                context.Delete(sql);
            }
            //grcPODetails.DataSource = new BindingList<PurchasingOrderDetails>(new List<PurchasingOrderDetails>());
            Init();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            var dl = MessageBox.Show("Are you sure to Accept detail this PO ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl.Equals(DialogResult.No)) return;
            using (PlantDBContext context = new PlantDBContext())
            {

                //context.Delete("Update PurchasingOrders set OrderConfirmedAll = 1 where PurchasingOrderID = " + this.currentPO.PurchasingOrderID);
                string sql = String.Format("SP_PurchasingOrderDetailAccept " + this.currentPO.PurchasingOrderID + " , 1");
                context.Delete(sql);
            }



            //if (string.Equals(this.currentPO.OrderConfirmed, "0", StringComparison.OrdinalIgnoreCase))
            //{
            //    //this.currentPettyCash.ClearStatus = "true";
            //    using (PlantDBContext context = new PlantDBContext())
            //    {
            //        string sql = String.Format("SP_PurchasingOrderDetailAccept "+ this.currentPO.PurchasingOrderID + " , 1");
            //        context.Delete(sql);
            //    }
            //    UpdateControlStatus();
            //}
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.Equals(this.currentPO.OrderConfirmed, "false", StringComparison.OrdinalIgnoreCase))
            {
                var dl = MessageBox.Show("Are you sure to Confirm this PO ?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dl.Equals(DialogResult.No)) return;

                this.currentPO.OrderConfirmed = "true";
                using (PlantDBContext context = new PlantDBContext())
                {
                    context.Delete("Update PurchasingOrders set OrderConfirmed = 1 where PurchasingOrderID = " + this.currentPO.PurchasingOrderID);
                    string sql = String.Format("SP_ReceivedPartDetailsInsert " + this.currentPO.PurchasingOrderID + " , '"
                        + AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/y HH:mm") + "'");
                    context.Delete(sql);
                }
                UpdateControlStatus();
            }



        }

        private void lkeSupplier_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkeSupplier_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            //this.txtSupplierNumber.Text = this.lkeSupplier.GetColumnValue("SupplierID").ToString();
            this.txtSuppFullName.Text = this.lkeSupplier.GetColumnValue("SupplierFullName").ToString();
            this.txtAddress.Text = this.lkeSupplier.GetColumnValue("SupplierAddress").ToString();
            this.txtSupContact.Text = this.lkeSupplier.GetColumnValue("SupplierContactName").ToString();
            this.txtPhone.Text = this.lkeSupplier.GetColumnValue("SupplierPhone").ToString();
            //this.txtFax.Text = this.lkeSupplier.GetColumnValue("SupplierFax").ToString();
            //this.txtRemark.Text = this.lkeSupplier.GetColumnValue("SupplierRemark").ToString();
            string ck = this.lkeSupplier.GetColumnValue("StrategicSupplier").ToString();
            if (string.Equals(ck, "true", StringComparison.OrdinalIgnoreCase))
            {
                ckStrategic.Checked = true;
            }
            else
            {
                ckStrategic.Checked = false;
            }



            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set SupplierID = {0} where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.lkeSupplier.GetColumnValue("SupplierID").ToString(),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    Update(savePsosition);

                }
            }
            else
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("INSERT INTO PurchasingOrders (PuchasingDate, SupplierID, OrderBy, StoreID ,CreatedBy) VALUES ('{0}', {1}, N'{2}', {3}, '{4}')",
                        DateTime.Today.ToString("yyyy-MM-dd"),
                        this.lkeSupplier.GetColumnValue("SupplierID").ToString(),
                        AppSetting.CurrentUser.LoginName + " - " + DateTime.Now.ToString("dd/MM/y HH:mm"),
                        AppSetting.CurrentUser.StoreID,
                        AppSetting.CurrentUser.LoginName
                        );

                    context.Delete(sql);

                    Init();

                }
            }
        }

        private void Update(int savePsosition)
        {

            using (PlantDBContext context = new PlantDBContext())
            {

                //storeID = AppSetting.CurrentUser.StoreID;
                string sql = "ST_WMS_PurchasingOrderList " + AppSetting.CurrentUser.LoginName;

                //string sql = "ST_WMS_PurchasingOrderList 'trung'";

                var dataSource = context.GetComboStoreNo(sql);

                this.POList = new List<PurchaseOrder>();

                if (dataSource != null)
                {


                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        PurchaseOrder PO = new PurchaseOrder();

                        PO.PurchasingOrderID = Convert.ToInt32(dataSource.Rows[i]["PurchasingOrderID"].ToString());
                        PO.SupplierName = dataSource.Rows[i]["SupplierName"].ToString();
                        PO.PurchasingOrderNumber = dataSource.Rows[i]["PurchasingOrderNumber"].ToString();
                        PO.PuchasingDate = Convert.ToDateTime(dataSource.Rows[i]["PuchasingDate"].ToString());

                        PO.SupplierID = Convert.ToInt32(dataSource.Rows[i]["SupplierID"].ToString());

                        PO.OrderEmployeeID = Convert.ToInt32(dataSource.Rows[i]["OrderEmployeeID"].ToString());



                        PO.DeliveryAddress = dataSource.Rows[i]["DeliveryAddress"].ToString();
                        PO.OrderBy = dataSource.Rows[i]["OrderBy"].ToString();

                        PO.OrderConfirmed = dataSource.Rows[i]["OrderConfirmed"].ToString();

                        PO.PurchasingRemark = dataSource.Rows[i]["PurchasingRemark"].ToString();
                        PO.DepartmentCategoryID = dataSource.Rows[i]["DepartmentCategoryID"].ToString();

                        PO.Currency = dataSource.Rows[i]["Currency"].ToString();

                        PO.ExchangeRate = Convert.ToDecimal(dataSource.Rows[i]["ExchangeRate"].ToString());

                        PO.InvoiceNumber = dataSource.Rows[i]["InvoiceNumber"].ToString();

                        PO.UsedPeriod = dataSource.Rows[i]["UsedPeriod"].ToString();


                        PO.StrategicSupplier = dataSource.Rows[i]["StrategicSupplier"].ToString();
                        PO.SupplierAddress = dataSource.Rows[i]["SupplierAddress"].ToString();
                        PO.SupplierContactName = dataSource.Rows[i]["SupplierContactName"].ToString();

                        PO.SupplierTitle = dataSource.Rows[i]["SupplierTitle"].ToString();
                        PO.SupplierPhone = dataSource.Rows[i]["SupplierPhone"].ToString();
                        PO.SupplierFax = dataSource.Rows[i]["SupplierFax"].ToString();
                        PO.SupplierEmail = dataSource.Rows[i]["SupplierEmail"].ToString();
                        PO.SupplierRemark = dataSource.Rows[i]["SupplierRemark"].ToString();

                        PO.SupplierFullName = dataSource.Rows[i]["SupplierFullName"].ToString();
                        try
                        {
                            PO.DeliveryDate = Convert.ToDateTime(dataSource.Rows[i]["DeliveryDate"].ToString());
                            PO.FinalPaymentDate = Convert.ToDateTime(dataSource.Rows[i]["FinalPaymentDate"].ToString());
                            PO.AdvancePaymentDate = Convert.ToDateTime(dataSource.Rows[i]["AdvancePaymentDate"].ToString());
                            PO.ContractDate = Convert.ToDateTime(dataSource.Rows[i]["ContractDate"].ToString());
                            PO.ContractExpiredDate = Convert.ToDateTime(dataSource.Rows[i]["ContractExpiredDate"].ToString());
                        }
                        catch
                        {

                        }

                        PO.RiskAssessmentRequired = dataSource.Rows[i]["RiskAssessmentRequired"].ToString();
                        PO.CompetitivePricingRequired = dataSource.Rows[i]["CompetitivePricingRequired"].ToString();
                        PO.ContractNumber = dataSource.Rows[i]["ContractNumber"].ToString();



                        PO.ContractRequired = dataSource.Rows[i]["ContractRequired"].ToString();
                        PO.DocumentFileScan = dataSource.Rows[i]["DocumentFileScan"].ToString();
                        PO.SpecialRequirement = dataSource.Rows[i]["SpecialRequirement"].ToString();
                        PO.StoreNumber = dataSource.Rows[i]["StoreNumber"].ToString();
                        PO.StoreDescription = dataSource.Rows[i]["StoreDescription"].ToString();
                        PO.StoreID = Convert.ToInt32(dataSource.Rows[i]["StoreID"].ToString());
                        PO.CreatedBy = dataSource.Rows[i]["CreatedBy"].ToString();

                        this.POList.Add(PO);
                    }


                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void dteOrderDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set PuchasingDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteOrderDate.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}

        }

        private void lkeStore_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set StoreID = {0} where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.lkeStore.EditValue.ToString(),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}

        }

        private void dteDeliveryDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set DeliveryDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteDeliveryDate.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}

        }

        private void dteAdvPayment_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set AdvancePaymentDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteAdvPayment.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}

        }

        private void dteContractDate_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set ContractDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteContractDate.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}
        }

        private void lkeCurrency_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set Currency = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.lkeCurrency.EditValue.ToString(),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}
        }

        private void dteFinalPayment_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set FinalPaymentDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteFinalPayment.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}
        }

        private void dteContractExpired_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set ContractExpiredDate = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteContractExpired.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}
        }

        private void dteUsedPeriod_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //if (txtPORecordNumber.Text.Length > 0)
            //{
            //    using (PlantDBContext context = new PlantDBContext())
            //    {

            //        string sql = String.Format("Update PurchasingOrders set UsedPeriod = '{0}' where PurchasingOrderID = {1} ",
            //            //this.dateCleared.EditValue.ToString(),
            //            this.dteUsedPeriod.DateTime.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //        context.Delete(sql);

            //        savePsosition = this.dtngPurchasingOrder.Position;
            //        Update(savePsosition);

            //    }
            //}
        }

        private void txtContractNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set ContractNumber = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.txtContractNo.Text,
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);

                    POList.ElementAt(savePsosition).ContractNumber = this.txtContractNo.Text;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void mmSpecRequirement_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set SpecialRequirement = N'{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.mmSpecRequirement.Text,
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).SpecialRequirement = this.mmSpecRequirement.Text;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set PurchasingRemark = N'{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.txtRemark.Text,
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).PurchasingRemark = this.txtRemark.Text;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void txtAdAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set ExchangeRate = {0} where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        Convert.ToDecimal(this.txtAdAmount.Text),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).ExchangeRate = Convert.ToDecimal(this.txtAdAmount.Text);
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void txtInvoiceNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set InvoiceNumber = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.txtInvoiceNo.Text,
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).InvoiceNumber = this.txtInvoiceNo.Text;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void ckContract_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set ContractRequired = {0} where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.ckContract.Checked == true ? "1" : "0",
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).ContractRequired = this.ckContract.Checked == true ? "true" : "false";
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void ckCompetitivePricing_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set CompetitivePricingRequired = {0} where PurchasingOrderID = {1} ",

                        this.ckCompetitivePricing.Checked == true ? "1" : "0",
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).CompetitivePricingRequired = this.ckCompetitivePricing.Checked == true ? "true" : "false";
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void ckRisk_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set RiskAssessmentRequired = {0} where PurchasingOrderID = {1} ",

                        this.ckRisk.Checked == true ? "1" : "0",
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).RiskAssessmentRequired = this.ckRisk.Checked == true ? "true" : "false";
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void ckStrategic_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set StrategicSupplier = {0} where PurchasingOrderID = {1} ",

                        this.ckStrategic.Checked == true ? "1" : "0",
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).StrategicSupplier = this.ckStrategic.Checked == true ? "true" : "false";
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void btn_PObySupp_Click(object sender, EventArgs e)
        {

            int suppID = Convert.ToInt32(this.lkeSupplier.GetColumnValue("SupplierID"));
            string suppName = this.txtSuppFullName.Text;
            frm_AD_POBySupplier frm = new frm_AD_POBySupplier(suppID, suppName);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
        }

        private void btnPaymentRequest_Click(object sender, EventArgs e)
        {

            rptPettyCashPaymentRequest rpt2 = new rptPettyCashPaymentRequest();
            rpt2.Parameters["varCurrentUser2"].Value = AppSetting.CurrentUser.LoginName;


            subRptPartialPayment sub1 = new subRptPartialPayment();

            using (PlantDBContext context = new PlantDBContext())
            {
                rpt2.DataSource = context.GetComboStoreNo("SP_PurchasingOrderPaymentRequest " + this.currentPO.PurchasingOrderID);
                rpt2.RequestParameters = false;

                sub1.DataSource = context.GetComboStoreNo("select * from Advances where OrderNumber = '" + this.currentPO.PurchasingOrderNumber + "'");
                rpt2.xrSubreport1.ReportSource = sub1;
                rpt2.CreateDocument();

                rpt2.Pages.AddRange(sub1.Pages);
                rpt2.PrintingSystem.ContinuousPageNumbering = true;
            }

            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2);
            printTool2.AutoShowParametersPanel = false;
            printTool2.ShowPreview();

        }

        private void btn_PartialPayment_Click(object sender, EventArgs e)
        {
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    string sql = "select * from Advances where OrderNumber = '" + this.currentPO.PurchasingOrderNumber + "'";
            //    this.grcAdvances.DataSource = context.GetComboStoreNo(sql);
            //}
            if (grvAdvances.GetFocusedDataSourceRowIndex() <= this.AdvanceDetailsList.Count
                && this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()].AdvanceID > 0)
            {
                int advanceID = this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()].AdvanceID;

                rptPettyCashPaymentRequest rpt2 = new rptPettyCashPaymentRequest();
                rpt2.Parameters["varCurrentUser2"].Value = AppSetting.CurrentUser.LoginName;

                subRptPartialPayment sub1 = new subRptPartialPayment();
                using (PlantDBContext context = new PlantDBContext())
                {
                    rpt2.DataSource = context.GetComboStoreNo("SP_PurchasingOrderPaymentRequest " + this.currentPO.PurchasingOrderID + " , " + advanceID);
                    rpt2.RequestParameters = false;

                    sub1.DataSource = context.GetComboStoreNo("select * from Advances where OrderNumber = '" + this.currentPO.PurchasingOrderNumber + "'");
                    rpt2.xrSubreport1.ReportSource = sub1;
                    rpt2.CreateDocument();

                    rpt2.Pages.AddRange(sub1.Pages);
                    rpt2.PrintingSystem.ContinuousPageNumbering = true;
                }

                ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2);
                printTool2.AutoShowParametersPanel = false;
                printTool2.ShowPreview();

            }

            //this.txt_popupAmount.Text = "";
            //this.txt_popupRemark.Text = "";
            //txt_popupAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //txt_popupAmount.Properties.Mask.EditMask = "n2";
            //txt_popupAmount.Properties.Mask.UseMaskAsDisplayFormat = true;

            //this.popupAddPartPayment.Show();

        }

        private void popupControlContainer1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_addAdvance_Click(object sender, EventArgs e)
        {
            //string amount = this.txt_popupAmount.Text;
            //string remark = this.txt_popupRemark.Text;


            //using (PlantDBContext context = new PlantDBContext())
            //{

            //    string sql = String.Format("Insert into Advances (AdvanceAmount,AdvanceRemark,OrderNumber,AdvanceDate ) Values ( {0},   N'{1}',  '{2}',   '{3}')  ",
            //            //this.dateCleared.EditValue.ToString(),
            //            //amount,
            //            //remark,
            //            currentPO.PurchasingOrderNumber,
            //            DateTime.Now.ToString("yyyy-MM-dd"),
            //            currentPO.PurchasingOrderID);

            //    context.Delete(sql);


            //    string sql2 = "select * from Advances where OrderNumber = '" + this.currentPO.PurchasingOrderNumber + "'";
            //    this.grcAdvances.DataSource = context.GetComboStoreNo(sql2);
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //PopupContainerBarControl control = popupAddPartPayment.Parent as PopupContainerBarControl;
            //control.ClosePopup();
            //popupAddPartPayment.Visible = false;
        }

        private void dock_PatialPayment_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        {
            //using (PlantDBContext context = new PlantDBContext())
            //{
            //    string sql = "select * from Advances where OrderNumber = '" + this.currentPO.PurchasingOrderNumber + "'";
            //    this.grcAdvances.DataSource = context.GetComboStoreNo(sql);
            //}
            LoadAdvanceDetails();
        }



        private void LoadAdvanceDetails()
        {
            using (PlantDBContext context = new PlantDBContext())
            {
                string sql = "ST_WMS_AdvanceDetails " + this.currentPO.PurchasingOrderID;
                var dts = context.GetComboStoreNo(sql);
                this.AdvanceDetailsList = new List<AdvanceDetail>();
                AdvanceDetailsList = (from DataRow row in dts.Rows
                                      select new AdvanceDetail
                                      {
                                          AdvanceID = Convert.ToInt32(row["AdvanceID"].ToString()),
                                          OrderNumber = row["OrderNumber"].ToString(),
                                          AdvanceDate = Convert.ToDateTime(row["AdvanceDate"].ToString()),
                                          AdvanceAmount = Convert.ToDecimal(row["AdvanceAmount"].ToString()),
                                          AdvanceRemark = row["AdvanceRemark"].ToString(),
                                          PayByDate = Convert.ToDateTime(row["PayByDate"].ToString()),
                                          CreatedBy = row["CreatedBy"].ToString(),
                                          CreatedTime = Convert.ToDateTime(row["CreatedTime"].ToString()),

                                      }).ToList();
                this.grcAdvances.DataSource = new BindingList<AdvanceDetail>(AdvanceDetailsList);
            }
        }

        private void btn_deleteAdvance_Click(object sender, EventArgs e)
        {
            int position = grvAdvances.GetFocusedDataSourceRowIndex();
            if (position < this.AdvanceDetailsList.Count)
            {
                if (this.AdvanceDetailsList[position].AdvanceID > 0)
                    using (PlantDBContext context = new PlantDBContext())
                    {
                        string sql = "delete from Advances where AdvanceID = " + this.AdvanceDetailsList[position].AdvanceID;
                        context.Delete(sql);
                    }
                this.AdvanceDetailsList.RemoveAt(position);
                grcAdvances.DataSource = new BindingList<AdvanceDetail>(this.AdvanceDetailsList);
            }
        }

        private void grvAdvances_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {



            if (grvAdvances.GetFocusedDataSourceRowIndex() <= this.AdvanceDetailsList.Count
                && this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()].AdvanceID > 0)
            {
                //int position = grvAdvances.GetFocusedDataSourceRowIndex();
                AdvanceDetail adv = this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()];
                using (PlantDBContext context = new PlantDBContext())
                {
                    //string sql = "delete from Advances where AdvanceID = " + this.AdvanceDetailsList[position].AdvanceID;
                    //context.Delete(sql);
                    string sql = String.Format("Update Advances set " +
                                     "AdvanceDate = '{0}', AdvanceAmount = {1}, AdvanceRemark = N'{2}', PayByDate = '{3}',CreatedBy = '{4}' " +

                                     " WHERE AdvanceID = {5} ",

                                     //Convert.ToDateTime(grvAdvances.GetFocusedRowCellValue("AdvanceDate")).ToString("yyyy-MM-dd"),
                                     //grvAdvances.GetFocusedRowCellValue("AdvanceAmount").ToString(),
                                     //grvAdvances.GetFocusedRowCellValue("AdvanceRemark").ToString(),
                                     //Convert.ToDateTime(grvAdvances.GetFocusedRowCellValue("PayByDate")).ToString("yyyy-MM-dd"),
                                     //grvAdvances.GetFocusedRowCellValue("CreatedBy").ToString(),
                                     ////grvAdvances.GetFocusedRowCellValue("CreatedTime"),
                                     //grvAdvances.GetFocusedRowCellValue("AdvanceID").ToString()


                                     adv.AdvanceDate.ToString("yyyy-MM-dd"),
                                     adv.AdvanceAmount,
                                     adv.AdvanceRemark,
                                     adv.PayByDate.ToString("yyyy-MM-dd"),
                                     adv.CreatedBy,
                                     //adv.CreatedTime.ToString(),
                                     adv.AdvanceID
                                     );

                    context.Delete(sql);


                }

                //this.AdvanceDetailsList.RemoveAt(position);
                //grcAdvances.DataSource = new BindingList<AdvanceDetail>(this.AdvanceDetailsList);
            }
            else
            {
                //this.grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "PartID", varPartID);             
                //grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "OrderNumber", this.currentPO.PurchasingOrderNumber);
                //if (e.Column != AdvanceDate)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "AdvanceDate", DateTime.Now.Date.ToString());
                //if(e.Column != AdvanceAmount)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "AdvanceAmount", 0);
                //if (e.Column != AdvanceRemark)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "AdvanceRemark", "");
                //if (e.Column != PayByDate)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "PayByDate", DateTime.Now.Date.ToString());
                //if (e.Column != CreatedBy)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "CreatedBy", AppSetting.CurrentUser.LoginName);
                //if (e.Column != CreatedTime)
                //    grvAdvances.SetRowCellValue(this.grvAdvances.FocusedRowHandle, "CreatedTime", DateTime.Now.ToString());

                AdvanceDetail adv = this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()];

                using (PlantDBContext context = new PlantDBContext())
                {
                    string sql = String.Format("insert into Advances (OrderNumber,AdvanceDate, " +
                                    "AdvanceAmount, AdvanceRemark, PayByDate, CreatedBy) " +
                                    "Values ('{0}','{1}',{2},N'{3}','{4}','{5}') ; SELECT SCOPE_IDENTITY() AS SCOPE_ID",

                                    this.currentPO.PurchasingOrderNumber,
                                    e.Column == AdvanceDate ? adv.AdvanceDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"),
                                    e.Column == AdvanceAmount ? adv.AdvanceAmount : 0,
                                    e.Column == AdvanceRemark ? adv.AdvanceRemark : "",
                                    e.Column == PayByDate ? adv.PayByDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"),
                                    e.Column == CreatedBy ? adv.CreatedBy : AppSetting.CurrentUser.LoginName
                                    );

                    var dataSource = context.GetComboStoreNo(sql);
                    this.AdvanceDetailsList[grvAdvances.GetFocusedDataSourceRowIndex()].AdvanceID
                        = Convert.ToInt32(dataSource.Rows[0]["SCOPE_ID"].ToString()); ;
                }
                LoadAdvanceDetails();
            }


        }

        private void rpi_hpl_expense_detail_Click(object sender, EventArgs e)
        {
            frm_AD_ExpenseDetails fre = new frm_AD_ExpenseDetails("PO", Convert.ToInt32(this.grvPODetail.GetFocusedRowCellValue("PurchasingOrderDetailID")), currentPO.PurchasingOrderNumber);
            fre.Show();
            fre.BringToFront();
        }

        private void grvPODetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == UnitPriceVND || e.Column == OrderQuantity)
            {
                decimal price = Convert.ToDecimal(grvPODetail.GetFocusedRowCellValue(UnitPriceVND));
                decimal qty = Convert.ToDecimal(grvPODetail.GetFocusedRowCellValue(OrderQuantity));
                decimal amount = qty * price;
                grvPODetail.SetFocusedRowCellValue(Amount, amount.ToString("0.##"));
                //grvPettyDetails.SetFocusedRowCellValue(gridColumnRemark, this.PettyCashDetailsList.Count);
            }


            if (e.Column != PartID && e.Column != PartName && e.Column != Amount)
            {
                PurchasingOrderDetail pod = this.PODetailsList[grvPODetail.GetFocusedDataSourceRowIndex()];
                if (pod.PurchasingOrderDetailID > 0)
                {
                    using (PlantDBContext context = new PlantDBContext())
                    {
                        string sql = String.Format("Update PurchasingOrderDetails set " +
                                         "PartID = {0}, UnitPriceVND = {1}, ItemRemark = N'{2}', DepartmentCategoryID = '{3}',PropertyCategoryID = {4}, " +
                                         "OrderQuantity = {5} " +
                                         " WHERE PurchasingOrderDetailID = {6} ",

                                         pod.PartID,
                                         pod.UnitPriceVND ?? "0",
                                         pod.ItemRemark,
                                         pod.DepartmentCategoryID ?? "",
                                         pod.PropertyCategoryID ?? "null",
                                         pod.OrderQuantity ?? "1",
                                         pod.PurchasingOrderDetailID);

                        context.Delete(sql);
                    }
                }
                else if (pod.PartID > 0)
                {
                    using (PlantDBContext context = new PlantDBContext())
                    {
                        string sql = String.Format("insert into PurchasingOrderDetails (PurchasingOrderID, " +
                                        "PartID, UnitPriceVND, Status, OrderQuantity ,DeliveryQuantity) " +
                                        "Values ({0},{1},{2},{3},{4},{5}) ; SELECT SCOPE_IDENTITY() AS SCOPE_ID",
                                        this.currentPO.PurchasingOrderID,
                                        pod.PartID,
                                        pod.UnitPriceVND ?? "0",
                                        0,
                                        pod.OrderQuantity ?? "1",
                                        0
                                        );

                        var dataSource = context.GetComboStoreNo(sql);
                        this.PODetailsList[grvPODetail.GetFocusedDataSourceRowIndex()].PurchasingOrderDetailID
                            = Convert.ToInt32(dataSource.Rows[0]["SCOPE_ID"].ToString());
                    }
                }
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

            //    PurchasingOrderDetail pod = new PurchasingOrderDetail();
            //    pod.PartID = varPartID;
            //    pod.PartName = varPartname;

            //    this.grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "PartID", varPartID);
            //    this.grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "PartName", varPartname);
            //    //grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "ExpensesDate", DateTime.Now.Date);
            //    grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "OrderQuantity", 1);
            //}
        }

        private void grcPODetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                int position = grvPODetail.GetFocusedDataSourceRowIndex();
                if (position < this.PODetailsList.Count)
                {
                    var dl = MessageBox.Show("Are you sure to DELETE this Item?", "TPWMS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dl.Equals(DialogResult.No)) return;
                    if (this.PODetailsList[position].PurchasingOrderDetailID > 0)
                        using (PlantDBContext context = new PlantDBContext())
                        {
                            string sql = "delete from PurchasingOrderDetails where PurchasingOrderDetailID = " + this.PODetailsList[position].PurchasingOrderDetailID;
                            context.Delete(sql);
                        }
                    this.PODetailsList.RemoveAt(position);
                    grcPODetail.DataSource = new BindingList<PurchasingOrderDetail>(this.PODetailsList);
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

                PurchasingOrderDetail pod = new PurchasingOrderDetail();
                pod.PartID = varPartID;
                pod.PartName = varPartname;

                this.grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "PartID", varPartID);
                this.grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "PartName", varPartname);
                //grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "ExpensesDate", DateTime.Now.Date);
                grvPODetail.SetRowCellValue(this.grvPODetail.FocusedRowHandle, "OrderQuantity", 1);
            }
        }

        private void dteOrderDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set PuchasingDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteOrderDate.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).PuchasingDate = this.dteOrderDate.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void lkeStore_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set StoreID = {0} where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.lkeStore.EditValue.ToString(),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).StoreID = (int)this.lkeStore.EditValue;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void dteDeliveryDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set DeliveryDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteDeliveryDate.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).DeliveryDate = this.dteDeliveryDate.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void dteAdvPayment_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set AdvancePaymentDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteAdvPayment.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).AdvancePaymentDate = this.dteAdvPayment.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;
                }
            }
        }

        private void dteContractDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set ContractDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteContractDate.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).ContractDate = this.dteContractDate.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void lkeCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set Currency = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.lkeCurrency.EditValue.ToString(),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).Currency = this.lkeCurrency.EditValue.ToString();
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void dteFinalPayment_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set FinalPaymentDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteFinalPayment.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).FinalPaymentDate = this.dteFinalPayment.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }

        private void dteContractExpired_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set ContractExpiredDate = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.dteContractExpired.DateTime.ToString("yyyy-MM-dd"),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).ContractExpiredDate = this.dteContractExpired.DateTime;
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }



        private void txtUsedPeriod_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPORecordNumber.Text.Length > 0)
            {
                using (PlantDBContext context = new PlantDBContext())
                {

                    string sql = String.Format("Update PurchasingOrders set UsedPeriod = '{0}' where PurchasingOrderID = {1} ",
                        //this.dateCleared.EditValue.ToString(),
                        this.txtUsedPeriod.Text.ToString(),
                        currentPO.PurchasingOrderID);

                    context.Delete(sql);

                    savePsosition = this.dtngPurchasingOrder.Position;
                    //Update(savePsosition);
                    POList.ElementAt(savePsosition).UsedPeriod = this.txtUsedPeriod.Text.ToString();
                    this.dtngPurchasingOrder.DataSource = POList;
                    dtngPurchasingOrder.Position = savePsosition;

                }
            }
        }



        private void btnPurchasingRequest_Click(object sender, EventArgs e)
        {
            rptPurchasingRequest rpt2 = new rptPurchasingRequest();
            rpt2.Parameters["varCurrentUser"].Value = AppSetting.CurrentUser.LoginName;
            using (PlantDBContext context = new PlantDBContext())
            {
                rpt2.DataSource = context.GetComboStoreNo("SP_PurchasingOrderRequest " + this.currentPO.PurchasingOrderID);
                rpt2.RequestParameters = false;
            }

            ReportPrintToolWMS printTool2 = new ReportPrintToolWMS(rpt2);
            printTool2.AutoShowParametersPanel = false;
            printTool2.ShowPreview();
        }

        private void frm_AD_PurchasingOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.Modal)
                {
                    return;
                }
                FormCollection openforms = Application.OpenForms;
                bool isOpen = false;
                foreach (Form frms in openforms)
                {
                    if (frms.Name == "frmScanInput")
                    {
                        frms.BringToFront();
                        isOpen = true;
                    }

                }
                if (!isOpen)
                {
                    UI.Helper.frmScanInput inputDialog = new frmScanInput();
                    inputDialog.Show();
                    inputDialog.BringToFront();
                }
            }
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            if (this.currentPO == null) return;
            if (this.currentPO.OrderConfirmed=="false" || this.currentPO.OrderConfirmed == "False")
            {
                MessageBox.Show("Please confirm the PO before process Receiving Goods !", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            //            If Val(Trim(Form_subfrmPurchasingOrderDetails.TextOrderQuantitySum)) = 0 Then
            //        MsgBox("Hello " & CurrentUser() & ", ban chua nhap Order quantity!"), vbInformation, "Purching Orders"
            //        Exit Sub
            //    End If
            decimal sumQtyDetails = Convert.ToDecimal(this.grvPODetail.Columns["OrderQuantity"].SummaryItem.SummaryValue);
            if (sumQtyDetails==0)
            {
                MessageBox.Show($"Hello { AppSetting.CurrentUser.LoginName} ban chua nhap Order quantity!", "Purching Orders", MessageBoxButtons.OK);
                return;
            }

            //'    If Not Me.ToggleConfirm Then
            //'        MsgBox ("Hello " & CurrentUser() & ", please confirm PO!"), vbInformation, "Purchasing Orders"
            //'        Exit Sub
            //'    End If

            if (string.Equals(this.currentPO.OrderConfirmed, "false", StringComparison.OrdinalIgnoreCase))
                MessageBox.Show($"Hello { AppSetting.CurrentUser.LoginName} please confirm PO!", "Purching Orders", MessageBoxButtons.OK);
            //    If CheckingPurchasingOrder(Me.txtPurchasingOrderID) Then
            //        If DCount("[ReceivedPartID]", "ReceivedParts", "[PurchasingOrderID]=" & txtPurchasingOrderID) > 0 Then
            //            If(MsgBox("PO nay da tao Received, nhung chua nhap du so luong, ban co muon tao tiep khong ?", vbInformation + vbYesNo) = vbYes) Then
            //                CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").sql = "SP_ReceivedPropertyInsertNew " & Me.txtPurchasingOrderID & ",'" & CurrentUser() & " - " & Format(Now(), "dd/mm/yy hh:nn") & "','" & CurrentUser() & "'"
            //                CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").Execute
            //                CurrentDb.QueryDefs("_qry_SelectedResults_PlantDB").sql = "SP_ReceivedByPusPurchasingOrder " & Me.txtPurchasingOrderID
            //                DoCmd.OpenForm "frmPartsReceived", acNormal, , "PurchasingOrderID = " & Me.txtPurchasingOrderID
            //            End If
            //        Else
            //            If MsgBox("Ban co chac chan muon tao Goods Receiving khong?", vbInformation + vbYesNo) = vbYes Then
            //                CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").sql = "SP_ReceivedPropertyInsertNew " & Me.txtPurchasingOrderID & ",'" & CurrentUser() & " - " & Format(Now(), "dd/mm/yy hh:nn") & "','" & CurrentUser() & "'"
            //                CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").Execute
            //                CurrentDb.QueryDefs("_qry_SelectedResults_PlantDB").sql = "SP_ReceivedByPusPurchasingOrder " & Me.txtPurchasingOrderID
            //                DoCmd.OpenForm "frmPartsReceived", acNormal, , "PurchasingOrderID = " & Me.txtPurchasingOrderID
            //            End If
            //        End If
            //    Else
            //        If MsgBox("PO nay da nhan du, ban co muon tao tiep khong ?", vbInformation + vbYesNo) = vbYes Then
            //            CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").sql = "SP_ReceivedPropertyInsertNew " & Me.txtPurchasingOrderID & ",'" & CurrentUser() & " - " & Format(Now(), "dd/mm/yy hh:nn") & "','" & CurrentUser() & "'"
            //            CurrentDb.QueryDefs("_qry_ActionResults_PlantDB").Execute
            //            CurrentDb.QueryDefs("_qry_SelectedResults_PlantDB").sql = "SP_ReceivedByPusPurchasingOrder " & Me.txtPurchasingOrderID
            //            DoCmd.OpenForm "frmPartsReceived", acNormal, , "PurchasingOrderID = " & Me.txtPurchasingOrderID
            //        End If
            //    End If
            DialogResult msgConfig = DialogResult.No;
            if (CheckingPurchasingOrder(this.currentPO.PurchasingOrderID))
            {
                int countReceived = 0;
                using (PlantDBContext context2 = new PlantDBContext())
                {
                    var tbReceived = context2.GetComboStoreNo("select count(ReceivedPartID) as CountPur from ReceivedParts where PurchasingOrderID="+this.currentPO.PurchasingOrderID);
                    if (tbReceived!=null && tbReceived.Rows.Count>0)
                        countReceived =Convert.ToInt32(tbReceived.Rows[0]["CountPur"]);
                }

                if (countReceived>0)
                    msgConfig = MessageBox.Show($"PO nay da tao Received, nhung chua nhap du so luong, ban co muon tao tiep khong ?", "Create Received", MessageBoxButtons.YesNo);
                else
                    msgConfig = MessageBox.Show($"Ban co chac chan muon tao Goods Receiving khong?", "Create Received", MessageBoxButtons.YesNo);
            }
            else
                msgConfig = MessageBox.Show($"PO nay da nhan du, ban co muon tao tiep khong ?", "Create Received", MessageBoxButtons.YesNo);

            if (msgConfig.Equals(DialogResult.Yes))
                using (PlantDBContext context2 = new PlantDBContext())
                {
                    context2.ExcecuteNoquery($"SP_ReceivedPropertyInsertNew {this.currentPO.PurchasingOrderID},'" +
                        $"{AppSetting.CurrentUser.LoginName +'-'+DateTime.Now.ToString("dd/MM/yy HH:mm")}','{this.currentPO.CreatedBy}'");
                }

            frm_AD_PO_Received frm = new frm_AD_PO_Received(this.currentPO.PurchasingOrderID);
            frm.Show();
            frm.BringToFront();
        }

        private bool CheckingPurchasingOrder(int purchasingOrderID)
        {
            //SP_CheckingReceivedPartQuantity
            using (PlantDBContext context2 = new PlantDBContext())
            {
                using (SqlConnection conn = new SqlConnection(context2.Database.Connection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SP_CheckingReceivedPartQuantity", conn))
                {
                    SqlParameter outputIdParam = new SqlParameter("@CheckingQuantity", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PurchasingOrderID", SqlDbType.Int).Value=this.currentPO.PurchasingOrderID;
                    cmd.Parameters.Add(outputIdParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return Convert.ToBoolean(outputIdParam.Value);
                }
            }
        }
    }
}
