using Common.Controls;
using DA;
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

namespace UI.CRM
{
    public partial class frm_CRM_ContractCommitments : frmBaseFormNormal
    {
        private BindingList<SP_LoadContractCommitData> dataSource = null;
        private DataProcess<ContractCommitments> dataProcess = new DataProcess<ContractCommitments>();

        public frm_CRM_ContractCommitments()
        {
            InitializeComponent();

            // Load customer list
            this.LoadCustomer();

            // Load Datasource
            this.LoadData();
        }

        private void LoadData()
        {
            DataProcess<SP_LoadContractCommitData> process = new DataProcess<SP_LoadContractCommitData>();
            var dataRoot = process.Executing("SP_LoadContractCommitData").ToList();
            this.dataSource = new BindingList<SP_LoadContractCommitData>(dataRoot);
            this.AddNewRow();
            this.grcContractCommitment.DataSource = this.dataSource;
        }

        private void LoadCustomer()
        {
            this.rle_CustomerID.DataSource = AppSetting.CustomerListAll.OrderBy(b => b.CustomerNumber);
            this.rle_CustomerID.ValueMember = "CustomerID";
            this.rle_CustomerID.DisplayMember = "CustomerNumber";
        }

        private void AddNewRow()
        {
            int countRowEmpty = this.dataSource.Count(r => r.CustomerID <= 0);
            if (countRowEmpty <= 0)
            {
                var newContractCommit = new SP_LoadContractCommitData();
                newContractCommit.FromDate = DateTime.Now;
                newContractCommit.ToDate = DateTime.Now.AddDays(365);
                newContractCommit.RoomID = "All";
                newContractCommit.NumberOfLocations = 0;
                newContractCommit.isMain = false;
                newContractCommit.CreatedBy = AppSetting.CurrentUser.LoginName;
                newContractCommit.CreatedTime = DateTime.Now;
                this.dataSource.Add(newContractCommit);
            }
            this.grvCCCommitments.RefreshData();
        }

        private void rpi_lke_btnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var msgConfig = MessageBox.Show("Do you want delete this contract?", "WMS-2022", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgConfig.Equals(DialogResult.No)) return;
            int contractCommitID = Convert.ToInt32(this.grvCCCommitments.GetFocusedRowCellValue("ContractCommitmentID"));
            var updateContractCommit = this.dataSource.Where(r => r.ContractCommitmentID == contractCommitID).FirstOrDefault();
            updateContractCommit.isDeleted = true;
            this.dataProcess.Update(ConvertModelToRoot((updateContractCommit)));
            this.LoadData();
        }

        private void grvCCCommitments_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            int contractCommitID = Convert.ToInt32(this.grvCCCommitments.GetFocusedRowCellValue("ContractCommitmentID"));
            if (e.Column.FieldName.Equals("FromDate"))
            {
                var fromD = Convert.ToDateTime(e.Value);
                var toDate = fromD.AddDays(365);
                this.grvCCCommitments.SetFocusedRowCellValue("ToDate", toDate);
            }
            if (contractCommitID > 0)
            {
                var updateContractCommit = this.dataSource.Where(r => r.ContractCommitmentID == contractCommitID).FirstOrDefault();
                updateContractCommit.UpdateBy = AppSetting.CurrentUser.LoginName;
                updateContractCommit.UpdateTime = DateTime.Now;
                int resultUpdate = this.dataProcess.Update(ConvertModelToRoot(updateContractCommit));
                if (resultUpdate <= 0)
                {
                    MessageBox.Show("Cập nhật không thành công", "WMS-2022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var newContracCommit = this.dataSource.Where(r => r.ContractCommitmentID <= 0).FirstOrDefault();
                var contracCommitInfo = ConvertModelToRoot(newContracCommit);
                int resultAdd = this.dataProcess.Insert(contracCommitInfo);
                if (resultAdd > 0)
                {
                    this.grvCCCommitments.SetRowCellValue(e.RowHandle, "ContractCommitmentID", contracCommitInfo.ContractCommitmentID);
                    this.AddNewRow();
                }       
            }
        }

        private void rle_CustomerID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            this.grvCCCommitments.SetFocusedRowCellValue("CustomerName", this.rle_CustomerID.GetDisplayValueByKeyValue(e.Value));
        }
        private ContractCommitments ConvertModelToRoot(SP_LoadContractCommitData modelData)
        {
            ContractCommitments currentRootData = null;
            if (modelData.ContractCommitmentID > 0)
            {
                currentRootData = this.dataProcess.Select(r => r.ContractCommitmentID == modelData.ContractCommitmentID).FirstOrDefault();
            }
            else
            {
                currentRootData = new ContractCommitments();
            }
            currentRootData.CDCRemark = modelData.CDCRemark;
            currentRootData.ContractCommitmentID = modelData.ContractCommitmentID;
            currentRootData.CreatedBy = modelData.CreatedBy;
            currentRootData.CreatedTime = modelData.CreatedTime;
            currentRootData.CustomerID = modelData.CustomerID;
            currentRootData.FromDate = modelData.FromDate;
            currentRootData.isDeleted = modelData.isDeleted;
            currentRootData.isMain = modelData.isMain;
            currentRootData.LocationType = modelData.LocationType;
            currentRootData.NumberOfLocations = modelData.NumberOfLocations;
            currentRootData.RoomID = modelData.RoomID;
            currentRootData.ToDate = modelData.ToDate;
            currentRootData.UpdateBy = modelData.UpdateBy;
            currentRootData.UpdateTime = modelData.UpdateTime;
            return currentRootData;
        }
    }
}
