using Common.Controls;
using DA;
using System;
using DevExpress.XtraEditors;
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
    public partial class frm_CRM_OperatingCostMonthlyParameters : frmBaseForm
    {
        DataProcess<OperationCostMonthlyParameters> dataProcessOperationCostMonthlyParameters = new DataProcess<OperationCostMonthlyParameters>();
        public frm_CRM_OperatingCostMonthlyParameters()
        {
            InitializeComponent();
            this.lke_OperatingCostMonthlyID.Properties.DataSource = FileProcess.LoadTable("ST_WMS_LoadOperatingCostMonth");
            this.lke_OperatingCostMonthlyID.Properties.ValueMember = "OperatingCostMonthlyID";
            this.lke_OperatingCostMonthlyID.Properties.DisplayMember = "MonthDescription";
            this.lke_OperatingCostMonthlyID.EditValue = AppSetting.LastOperationMonthID;

            DataProcess<Stores> storeDA = new DataProcess<Stores>();
            this.lke_MSS_StoreList.Properties.DataSource = storeDA.Select();
            this.lke_MSS_StoreList.Properties.ValueMember = "StoreID";
            this.lke_MSS_StoreList.Properties.DisplayMember = "StoreDescription";

            //this.grcOperatingCostParameters.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + this.lke_OperatingCostMonthlyID.EditValue.ToString())+ "," + this.lke_MSS_StoreList.EditValue.ToString();


        }

        private void grvOperatingCostParameters_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataProcess<object> ParameterDA = new DataProcess<object>();
            int result = -2;
            int customerID = Convert.ToInt32(this.grvOperatingCostParameters.GetRowCellValue(e.RowHandle, "CustomerID"));
            int operationID = Convert.ToInt32(this.grvOperatingCostParameters.GetRowCellValue(e.RowHandle, "OperationCostMonthlyParameterID"));

            switch (e.Column.FieldName)
            {
                case "Index_LocationInOut":
                    {
                        result = ParameterDA.ExecuteNoQuery("UPDATE OperationCostMonthlyParameters SET Index_LocationInOut = {0} WHERE(CustomerID = {1}) AND (OperationCostMonthlyParameterID = {2})",
                            e.Value,customerID , operationID);
                        break;
                    }
                case "Index_Transactions":
                    {
                        result = ParameterDA.ExecuteNoQuery("UPDATE OperationCostMonthlyParameters SET Index_Transactions = {0} WHERE(CustomerID = {1}) AND (OperationCostMonthlyParameterID = {2})",
                            e.Value, customerID, operationID);
                        break;
                    }
            }
        }

        private void lke_OperatingCostMonthlyID_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
            {
                this.grcOperatingCostParameters.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + "," + this.lke_MSS_StoreList.EditValue.ToString());
            }
        }

        private void lke_MSS_StoreList_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
            {
                this.grcOperatingCostParameters.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + "," + this.lke_MSS_StoreList.EditValue.ToString());
            }
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            DataProcess<object> ParameterDA = new DataProcess<object>();
            int result = -2;
            int varOperatingCostMonthlyID = Convert.ToInt32(this.lke_OperatingCostMonthlyID.EditValue);
            int varStoreID = Convert.ToInt32(this.lke_MSS_StoreList.EditValue);
            result = ParameterDA.ExecuteNoQuery("OperatingCostExpenses_UpdateData @OperatingCostMonthlyID = {0}, @StoreID = {1}", varOperatingCostMonthlyID, varStoreID);
            frm_CRM_OperatingCostEntry frm = new frm_CRM_OperatingCostEntry(varOperatingCostMonthlyID, varStoreID);
            frm.Show();
            frm.WindowState = FormWindowState.Normal;

        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            var result = XtraInputBox.Show("Enter code to process : ", "TPWMS", "0");
            if (!Convert.ToString(result).Equals("210172")) return;
            if (this.lke_OperatingCostMonthlyID.EditValue != null && this.lke_MSS_StoreList.EditValue != null)
            {
                var source = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + "," + this.lke_MSS_StoreList.EditValue.ToString());
                if (source.Rows.Count > 0)
                {                
                    MessageBox.Show("Can not create new records; have to input data first", "TPWMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.dataProcessOperationCostMonthlyParameters.ExecuteNoQuery("OperatingCostMonthly_CreateParameters  @OperatingCostMonthlyID={0}", this.lke_OperatingCostMonthlyID.EditValue);


            
                this.grcOperatingCostParameters.DataSource = FileProcess.LoadTable("OperatingCostMonthly_ViewParameterByCustomer " + this.lke_OperatingCostMonthlyID.EditValue.ToString() + "," + this.lke_MSS_StoreList.EditValue.ToString());
            }
            //Private Sub CommandCreateData_Click()
            //    If InputBox("Enter code to process : ") = "210172" Then
            //    If Me.subfrmOperatingCostMonthlyParameterDetails.Form.RecordsetClone.RecordCount > 0 Then
            //        MsgBox("Can not create new records !"), vbCritical
            //       Exit Sub
            //    End If


            //    CurrentDb.QueryDefs("qryActionResults").SQL = "EXEC OperatingCostMonthly_CreateParameters " & Me.ComboMonthID
            //    CurrentDb.QueryDefs("qryActionResults").Execute
            //    Me.subfrmOperatingCostMonthlyParameterDetails.Requery
            //    End If
            //End Sub
        }
    }
}
