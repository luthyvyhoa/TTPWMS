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
using DA;
using DevExpress.XtraEditors;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_ProductTransRecords : Form
    {
        private BindingList<ProductTransRecord> proTransBD = null;
        private BindingList<ProductTransRecordDetail> proTransDetailsBD = null;
        private DataProcess<ProductTransRecord> proTransDA = new DataProcess<ProductTransRecord>();

        public frm_WM_ProductTransRecords()
        {
            InitializeComponent();

            // Init events
            this.InitEvents();

            // Load customer
            this.LoadCustomer();

            // Load data tran record
            this.LoadDataTrans();

            // Load all transformation
            this.LoadAllTransformation();
        }

        private void LoadDataTrans()
        {
            DataProcess<ProductTransRecord> ptransDA = new DataProcess<ProductTransRecord>();
            var dataSouce = ptransDA.Select();
            this.proTransBD = new BindingList<ProductTransRecord>(dataSouce.ToList());
            this.dataNavigatorReceivingOrders.DataSource = this.proTransBD;
            this.dataNavigatorReceivingOrders.Position = this.proTransBD.Count - 1;
        }

        private void InitEvents()
        {
            this.lookUpEditCustomerID.CloseUp += LookUpEditCustomerID_CloseUp;
            this.lookUpEditCustomerID.EditValueChanged += LookUpEditCustomerID_EditValueChanged;
            this.dataNavigatorReceivingOrders.PositionChanged += DataNavigatorReceivingOrders_PositionChanged;
            this.btnNew.Click += BtnNew_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnConfirmProcess.Click += BtnConfirmProcess_Click;
            this.memoEditRemark.TextChanged += MemoEditRemark_TextChanged;
            rpk_ProductTransformationID.CloseUp += Rpk_ProductTransformationID_CloseUp;
        }

        private void LookUpEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lookUpEditCustomerID.EditValue == null) return;
            string customerName = Convert.ToString(this.lookUpEditCustomerID.GetColumnValue("CustomerName"));
            this.textEditCustomerName.Text = customerName;
        }

        private void LoadAllTransformation()
        {
            DataProcess<ProductTransformation> transForm = new DataProcess<ProductTransformation>();
            int customerID = Convert.ToInt32(this.lookUpEditCustomerID.EditValue);
            this.rpk_ProductTransformationID.DataSource = transForm.Select(tr => tr.CustomerID == customerID);
            this.rpk_ProductTransformationID.DisplayMember = "TransformationFormula";
            this.rpk_ProductTransformationID.ValueMember = "ProductTransformationID";
        }
        private void Rpk_ProductTransformationID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            var lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;

            // Detect is add new or update
            int transFormDetailsID = Convert.ToInt32(this.gridViewProductTransRecordDetails.GetFocusedRowCellValue("ProductTransRecordDetailID"));
            var currentTransDetail = this.proTransDetailsBD[this.gridViewProductTransRecordDetails.FocusedRowHandle];
            DataProcess<ProductTransRecordDetail> dataProcess = new DataProcess<ProductTransRecordDetail>();
            if (transFormDetailsID <= 0)
            {
                currentTransDetail = new ProductTransRecordDetail();
                currentTransDetail.ProductTransformationID = (int)e.Value;
                currentTransDetail.ProductTransRecordID = this.proTransBD[dataNavigatorReceivingOrders.Position].ProductTransRecordID;
                currentTransDetail.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentTransDetail.CreatedTime = DateTime.Now;
                dataProcess.Insert(currentTransDetail);
                LoadDataTransDetails(this.proTransBD[dataNavigatorReceivingOrders.Position]);
            }
            else
            {
                currentTransDetail.ProductTransformationID = (int)e.Value;
                dataProcess.Update(currentTransDetail);
            }
        }

        private void MemoEditRemark_TextChanged(object sender, EventArgs e)
        {
            if (!this.memoEditRemark.IsModified) return;
            int tranID = this.proTransBD[dataNavigatorReceivingOrders.Position].ProductTransRecordID;
            proTransDA.ExecuteNoQuery("Update ProductTransRecords set ProductTransRemark=N'" + this.memoEditRemark.Text + "' where ProductTransRecordID =" + tranID);
            this.proTransBD[dataNavigatorReceivingOrders.Position].ProductTransRemark = this.memoEditRemark.Text;
        }

        private void BtnConfirmProcess_Click(object sender, EventArgs e)
        {
            int tranID = this.proTransBD[dataNavigatorReceivingOrders.Position].ProductTransRecordID;
            foreach (var tranRecordDetail in this.proTransDetailsBD)
            {
                this.proTransDA.ExecuteNoQuery("STProductTransRecordProcess @ProductTransRecordID={0},@ProductTransformationID={1},@TransformationQuantity={2},@UserName={3}",
                tranID, tranRecordDetail.ProductTransformationID, tranRecordDetail.TransformationQuantity, tranRecordDetail.CreatedBy);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.proTransBD.AddNew();
        }

        private void DataNavigatorReceivingOrders_PositionChanged(object sender, EventArgs e)
        {
            var currentProTrans = this.proTransBD[this.dataNavigatorReceivingOrders.Position];
            if (currentProTrans == null) return;
            this.textEditProductTransRecordNumber.Text = currentProTrans.ProductTransRecordNumber;
            this.lookUpEditCustomerID.EditValue = currentProTrans.CustomerID;
            this.memoEditRemark.Text = currentProTrans.ProductTransRemark;
            this.textEditReceivingCreatedBy.Text = currentProTrans.CreatedBy;
            this.textEditReceivingCreatedTime.Text = currentProTrans.CreatedTime.ToString("dd/MM/yyyy");
            this.LoadDataTransDetails(currentProTrans);
        }

        private void LoadDataTransDetails(ProductTransRecord trans)
        {
            DataProcess<ProductTransRecordDetail> dataProcess = new DataProcess<ProductTransRecordDetail>();
            var dataSource = dataProcess.Select(pt => pt.ProductTransRecordID == trans.ProductTransRecordID);
            this.proTransDetailsBD = new BindingList<ProductTransRecordDetail>(dataSource.ToList());
            this.proTransDetailsBD.AddNew();
            this.grcProductTransRecordDetails.DataSource = this.proTransDetailsBD;
        }

        private void LookUpEditCustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.lookUpEditCustomerID.EditValue = e.Value;
            ProductTransRecord currentTransRecord = null;
            if (dataNavigatorReceivingOrders.Position < 0)
            {
                currentTransRecord = new ProductTransRecord();
            }
            else
            {
                currentTransRecord = this.proTransBD[dataNavigatorReceivingOrders.Position];
            }

            currentTransRecord.CustomerID = (int)e.Value;

            if (currentTransRecord.ProductTransRecordID > 0)
            {
                this.proTransDA.Update(currentTransRecord);
            }
            else
            {
                currentTransRecord.CreatedBy = AppSetting.CurrentUser.LoginName;
                currentTransRecord.CreatedTime = DateTime.Now;
                currentTransRecord.ProductTransDate = DateTime.Now;
                currentTransRecord.ProductTransRecordNumber = "TR-";
                this.proTransDA.Insert(currentTransRecord);
                this.LoadDataTrans();
            }
        }

        private void LoadCustomer()
        {
            this.lookUpEditCustomerID.Properties.DataSource = AppSetting.CustomerList;
            this.lookUpEditCustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lookUpEditCustomerID.Properties.ValueMember = "CustomerID";
        }
    }
}

