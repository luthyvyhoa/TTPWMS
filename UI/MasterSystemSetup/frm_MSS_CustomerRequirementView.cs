using System.Windows.Forms;
using Common.Controls;
using DA;
using UI.Helper;
using DA.Warehouse;
namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_CustomerRequirementView : frmBaseForm
    {
        private int customerMainID = -1;
        public frm_MSS_CustomerRequirementView(int customerMainID)
        {
            InitializeComponent();
            this.customerMainID = customerMainID;
        }

        /// <summary>
        /// Allow display form
        /// </summary>
        public bool IsDisplay
        {
            get
            {
                return this.ValidateIsDisplay();
            }
        }

        private void btn_MSS_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frm_MSS_CustomerRequirementView_Load(object sender, System.EventArgs e)
        {
            DataProcess<STCustomerRequirements_Result> customerRequirementsDA = new DataProcess<STCustomerRequirements_Result>();
            var listRequirements = customerRequirementsDA.Executing("STCustomerRequirements @CustomerMainID={0}", this.customerMainID);

            if (listRequirements == null) return;
            urc_MSS_CustomerRequirementsViewContend requirementDisplay;
            foreach (var requirementItem in listRequirements)
            {
                requirementDisplay = new urc_MSS_CustomerRequirementsViewContend();
                requirementDisplay.UpdateBy = requirementItem.UpdateBy;
                requirementDisplay.Time = requirementItem.UpdateTime.ToString();
                requirementDisplay.RequirementContent = requirementItem.RequirementDetails;
                this.flpMain.Controls.Add(requirementDisplay);
                this.flpMain.Update();
                this.flpMain.Refresh();
            }
        }

        private void btn_MSS_ReadAndUnderstood_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataProcess<object> confirmDA = new DataProcess<object>();
            int result = confirmDA.ExecuteNoQuery("STCustomerRequirementRemindInsert @CustomerMainID={0},@LoginName={1},@OrderType={2}",
                   this.customerMainID,
                   AppSetting.CurrentUser.LoginName,
                   "RO");
            this.Close();
        }

        private bool ValidateIsDisplay()
        {
            ReceivingOrdersDA confirmDA = new ReceivingOrdersDA();
            System.Data.Entity.Core.Objects.ObjectParameter isDisplay = new System.Data.Entity.Core.Objects.ObjectParameter("Return", false);
            int result = confirmDA.STCustomerRequirementRemind(this.customerMainID, AppSetting.CurrentUser.LoginName, "RO", isDisplay);
            return (bool)isDisplay.Value;
        }

    }
}
