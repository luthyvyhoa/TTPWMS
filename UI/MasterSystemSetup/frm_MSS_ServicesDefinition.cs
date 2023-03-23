using Common.Controls;
using DA;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.ComponentModel;
using UI.Helper;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ServicesDefinition : frmBaseForm
    {
        private DataProcess<ServicesDefinition> serviceDefinitionDA = new DataProcess<ServicesDefinition>();
        private BindingList<ServicesDefinition> bindingList = null;

        public frm_MSS_ServicesDefinition()
        {
            InitializeComponent();
            bool isIT = this.CheckUserDepartment();
            if (isIT) this.txtCalculatedSQL.Enabled = true;
            else this.txtCalculatedSQL.Enabled = false;
        }

        private void frm_MSS_ServicesDefinition_Load(object sender, System.EventArgs e)
        {
            // Declare DataAccess to DB
            DataProcess<ServicesDefinitionMeasures> meaSureDA = new DataProcess<ServicesDefinitionMeasures>();

            // Load datasource for measure
            this.rpi_lke_Measure.DataSource = meaSureDA.Executing("SELECT ServicesDefinitionMeasures.ServicesDefinitionMeasureID, ServicesDefinitionMeasures.ServicesDefinitionMeasureVN FROM ServicesDefinitionMeasures");
            this.rpi_lke_Measure.DisplayMember = "ServicesDefinitionMeasureID";
            this.rpi_lke_Measure.ValueMember = "ServicesDefinitionMeasureID";

            // Load data source for Customer Catefory
            this.InitDataCategoryCustomer();

            //Load datasouce for Category
            this.InitCategory();

            //Load datasouce for ServiceType
            this.InitServiceType();

            // Load dataSource for Service Definition
            var dataSource = serviceDefinitionDA.Executing("SELECT ServicesDefinition.* FROM ServicesDefinition ORDER BY ServicesDefinition.ServiceID");
            this.bindingList = new BindingList<ServicesDefinition>(dataSource.ToList());
            grd_MSS_ServicesDefinition.DataSource = this.bindingList;

            // Enable/ disable buton Edit vs Update vs Memotext
            this.SetActiveControls(false);
        }

        /// <summary>
        /// Load data source for Customer category
        /// </summary>
        private void InitDataCategoryCustomer()
        {
            using (var tbcustomerCategory = new System.Data.DataTable())
            {
                tbcustomerCategory.Columns.Add("ID");
                tbcustomerCategory.Columns.Add("Name");

                // Other row
                var otherRow = tbcustomerCategory.NewRow();
                otherRow["ID"] = 0;
                otherRow["Name"] = "Other";

                // Other row
                var wmsRow = tbcustomerCategory.NewRow();
                wmsRow["ID"] = 1;
                wmsRow["Name"] = "WMS";

                // Other row
                var documentRow = tbcustomerCategory.NewRow();
                documentRow["ID"] = 2;
                documentRow["Name"] = "Document";

                tbcustomerCategory.Rows.Add(otherRow);
                tbcustomerCategory.Rows.Add(wmsRow);
                tbcustomerCategory.Rows.Add(documentRow);

                this.rpi_lke_CustomerCat.DataSource = tbcustomerCategory;
                this.rpi_lke_CustomerCat.ValueMember = "ID";
                this.rpi_lke_CustomerCat.DisplayMember = "Name";
            }
        }
        /// <summary>
        /// Load datasouce Category
        /// </summary>
        private void InitCategory()
        {
            using (var tbCategory = new System.Data.DataTable())
            {
                tbCategory.Columns.Add("Name");

                // Other row
                var gRow = tbCategory.NewRow();
                gRow["Name"] = "G";

                // Other row
                var rRow = tbCategory.NewRow();
                rRow["Name"] = "R";

                // Other row
                var dRow = tbCategory.NewRow();
                dRow["Name"] = "D";

                tbCategory.Rows.Add(gRow);
                tbCategory.Rows.Add(rRow);
                tbCategory.Rows.Add(dRow);

                this.rpi_lke_Category.DataSource = tbCategory;
                this.rpi_lke_Category.ValueMember = "Name";
                this.rpi_lke_Category.DisplayMember = "Name";

            }
        }
        /// <summary>
        /// load datasouce Service Type
        /// </summary>
        private void InitServiceType()
        {
            using (var tbServiceType = new System.Data.DataTable())
            {
                tbServiceType.Columns.Add("Name");

                // Other row
                var handlingRow = tbServiceType.NewRow();
                handlingRow["Name"] = "Handling";

                // Other row
                var storageRow = tbServiceType.NewRow();
                storageRow["Name"] = "Storage";

                // Other row
                var transportRow = tbServiceType.NewRow();
                transportRow["Name"] = "Transport";

                // Other row
                var valueAddRow = tbServiceType.NewRow();
                valueAddRow["Name"] = "ValueAdded";

                tbServiceType.Rows.Add(handlingRow);
                tbServiceType.Rows.Add(storageRow);
                tbServiceType.Rows.Add(transportRow);
                tbServiceType.Rows.Add(valueAddRow);

                this.rpi_lke_ServiceType.DataSource = tbServiceType;
                this.rpi_lke_ServiceType.ValueMember = "Name";
                this.rpi_lke_ServiceType.DisplayMember = "Name";
            }
        }

        private void mm_MSS_ScopeOfWork_EditValueChanged(object sender, EventArgs e)
        {
            this.grv_MSS_ServicesDefinition.SetFocusedRowCellValue("ScopeOfWork", mm_MSS_ScopeOfWork.EditValue);
            this.grv_MSS_ServicesDefinition.SetRowCellValue(grv_MSS_ServicesDefinition.FocusedRowHandle, "IsModified", 1);
        }

        private void grv_MSS_ServicesDefinition_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var scopeData = this.grv_MSS_ServicesDefinition.GetRowCellValue(this.grv_MSS_ServicesDefinition.FocusedRowHandle, "ScopeOfWork");
            var scopeVietNamData = this.grv_MSS_ServicesDefinition.GetRowCellValue(this.grv_MSS_ServicesDefinition.FocusedRowHandle, "ScopeOFWorkVietnam");
            this.mm_MSS_ScopeOfWork.EditValue = string.Empty;
            this.mm_MSS_ScopeOfWorkVN.EditValue = string.Empty;
            if (scopeData != null)
            {
                this.mm_MSS_ScopeOfWork.EditValue = scopeData;
            }
            if (scopeVietNamData != null)
            {
                this.mm_MSS_ScopeOfWorkVN.EditValue = scopeVietNamData;
            }

            this.txtCalculatedSQL.EditValue = this.grv_MSS_ServicesDefinition.GetRowCellValue(this.grv_MSS_ServicesDefinition.FocusedRowHandle, "CalculatedSQL");

            // validate to add new row
            if (!this.grv_MSS_ServicesDefinition.OptionsBehavior.ReadOnly && e.FocusedRowHandle > 1)
            {
                string serviceNumber = Convert.ToString(this.grv_MSS_ServicesDefinition.GetRowCellValue(e.FocusedRowHandle, "ServiceNumber"));
                if (!string.IsNullOrEmpty(serviceNumber) && this.grv_MSS_ServicesDefinition.RowCount - 1 == e.FocusedRowHandle)
                    this.AddNewService();
            }
        }

        private void grv_MSS_ServicesDefinition_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.grv_MSS_ServicesDefinition.SetRowCellValue(e.RowHandle, "IsModified", 1);
        }

        private void mm_MSS_ScopeOfWorkVN_EditValueChanged(object sender, EventArgs e)
        {
            this.grv_MSS_ServicesDefinition.SetFocusedRowCellValue("ScopeOFWorkVietnam", mm_MSS_ScopeOfWorkVN.EditValue);
            this.grv_MSS_ServicesDefinition.SetRowCellValue(grv_MSS_ServicesDefinition.FocusedRowHandle, "IsModified", 1);
        }

        private void rpi_chk_Discontinued_CheckedChanged(object sender, EventArgs e)
        {
            this.grv_MSS_ServicesDefinition.SetRowCellValue(grv_MSS_ServicesDefinition.FocusedRowHandle, "IsModified", 1);
        }

        private void btn_Close_servicesdefinition_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_MSS_Update_ItemClick(object sender, EventArgs e)
        {
            IList<ServicesDefinition> sourceUpdate = (IList<ServicesDefinition>)this.grd_MSS_ServicesDefinition.DataSource;
            var lstUpdate = sourceUpdate.Where(x => x.IsModified == true && x.ServiceID > 0).ToArray();
            foreach(var obj in lstUpdate)
            {
                obj.UpdateTime = DateTime.Now;
            }
            serviceDefinitionDA.Update(lstUpdate);
            var sourceInsert = sourceUpdate.Where(x => x.ServiceID == 0 && !string.IsNullOrEmpty(x.ServiceNumber)).ToArray();
            foreach (var newService in sourceInsert)
            {
                if (newService.Discontinued == null) newService.Discontinued = false;
                if (newService.PLUServiceType == null) newService.PLUServiceType = "Storage";
            }
            serviceDefinitionDA.Insert(sourceInsert);
            // Load dataSource for Service Definition
            var dataSource = serviceDefinitionDA.Executing("SELECT ServicesDefinition.* FROM ServicesDefinition ORDER BY ServicesDefinition.ServiceID");
            this.bindingList = new BindingList<ServicesDefinition>(dataSource.ToList());
            grd_MSS_ServicesDefinition.DataSource = this.bindingList;
            this.SetActiveControls(false);
        }

        private void SetActiveControls(bool isActive)
        {
            this.grv_MSS_ServicesDefinition.OptionsBehavior.ReadOnly = !isActive;
            this.btn_Edit_Servicesdefinition.Enabled = !isActive;
            this.btn_Update_Servicedefinition.Enabled = isActive;
            this.mm_MSS_ScopeOfWork.ReadOnly = !isActive;
            this.mm_MSS_ScopeOfWorkVN.ReadOnly = !isActive;
            this.txtCalculatedSQL.ReadOnly = !isActive;
        }

        private void btn_Edit_Servicesdefinition_Click(object sender, EventArgs e)
        {
            this.SetActiveControls(true);
            this.AddNewService();
        }

        private void AddNewService()
        {
            ServicesDefinition newService = new ServicesDefinition();
            newService.CreatedBy = AppSetting.CurrentUser.LoginName;
            newService.CreatedTime = DateTime.Now;
            newService.IsModified = false;
            newService.ScopeOfWork = string.Empty;
            newService.ScopeOFWorkVietnam = string.Empty;
            newService.CustomerCategory = 1;
            newService.ServiceType = "Handling";
            this.bindingList.Add(newService);
        }

        private void rpi_lke_CustomerCat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rpi_lke_Measure_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value == null) return;
            var lke = (LookUpEdit)sender;
            lke.EditValue = e.Value;
            var measureInfo = (ServicesDefinitionMeasures)lke.GetSelectedDataRow();
            if (measureInfo == null) return;
            this.grv_MSS_ServicesDefinition.SetRowCellValue(this.grv_MSS_ServicesDefinition.FocusedRowHandle, "MeasureVietnam", measureInfo.ServicesDefinitionMeasureVN);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.btn_Edit_Servicesdefinition_Click(sender, e);
            this.grv_MSS_ServicesDefinition.FocusedRowHandle = this.grv_MSS_ServicesDefinition.RowCount - 1;
            this.grv_MSS_ServicesDefinition.FocusedColumn = this.gridColumn1;
            this.grv_MSS_ServicesDefinition.ShowEditor();
        }

        private void grv_MSS_ServicesDefinition_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName.Equals("IsModified")) return;            
            int serviceID = Convert.ToInt32(this.grv_MSS_ServicesDefinition.GetFocusedRowCellValue("ServiceID"));
            var currentService = this.bindingList.Where(s => s.ServiceID == serviceID).FirstOrDefault();
            DataProcess<ServicesDefinition> sDA = new DataProcess<ServicesDefinition>();
            if (!currentService.IsModified) return;
            switch (e.Column.FieldName)
            {
                case "ServiceNumber":
                case "ServiceName":
                    if (currentService.ServiceID <= 0 && currentService.IsModified)
                    {
                        //Insert new service
                        currentService.CreatedBy = AppSetting.CurrentUser.LoginName;
                        currentService.CreatedTime = DateTime.Now;
                        currentService.ServiceName = Convert.ToString(this.grv_MSS_ServicesDefinition.GetFocusedRowCellValue("ServiceName"));
                        currentService.ServiceNumber = Convert.ToString(this.grv_MSS_ServicesDefinition.GetFocusedRowCellValue("ServiceNumber"));
                        serviceDefinitionDA.Insert(currentService);
                        this.bindingList[this.bindingList.Count - 1] = currentService;
                    }
                    else
                    {
                        if (currentService.IsModified)
                        {
                            serviceDefinitionDA.Update(currentService);
                            sDA.ExecuteNoQuery("Update ServicesDefinition set UpdateBy='" + AppSetting.CurrentUser.LoginName + "', UpdateTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' where ServiceID=" + serviceID);
                        }

                    }
                    break;
                case "MeasureVietnam":
                    if (currentService.IsModified)
                    {
                        currentService.MeasureVietnam = Convert.ToString(e.Value);
                        serviceDefinitionDA.Update(currentService);
                        sDA.ExecuteNoQuery("Update ServicesDefinition set UpdateBy='" + AppSetting.CurrentUser.LoginName + "', UpdateTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' where ServiceID=" + serviceID);

                    }
                    break;
                default:
                    if (currentService.ServiceID > 0 && currentService.IsModified)
                    {
                        serviceDefinitionDA.Update(currentService);
                        sDA.ExecuteNoQuery("Update ServicesDefinition set UpdateBy='" + AppSetting.CurrentUser.LoginName + "', UpdateTime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' where ServiceID=" + serviceID);
                    }
                    break;
            }
        }
        private bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*£§€|<>";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        private void grv_MSS_ServicesDefinition_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.grv_MSS_ServicesDefinition.FocusedRowHandle < 0) return;
            switch (this.grv_MSS_ServicesDefinition.FocusedColumn.FieldName)
            {
                case "ServiceNumber":
                    if (e.Value.ToString().Length > 15)
                    {
                        e.ErrorText = "Length this column <= 15";
                        e.Valid = false;
                    }
                    foreach (var service in this.bindingList)
                    {
                        if (service.ServiceNumber != null && service.ServiceNumber.Trim().ToUpper().Equals(e.Value.ToString().Trim().ToUpper()))
                        {
                            e.ErrorText = "This service name has existed";
                            e.Valid = false;
                        }                        
                    }
                    if (hasSpecialChar(e.Value.ToString()))
                    {
                        e.ErrorText = "Has Special Char";
                        e.Valid = false;
                    } else
                        e.Value= e.Value.ToString().Trim().ToUpper();
                    break;
                case "ServiceName":
                    if (e.Value.ToString().Length > 30)
                    {
                        e.ErrorText = "Length this column <= 30";
                        e.Valid = false;
                    }
                    //foreach (var service in this.bindingList)
                    //{
                    //    if (service.ServiceName != null && service.ServiceName.Trim().ToUpper().Equals(e.Value.ToString().Trim().ToUpper()))
                    //    {
                    //        e.ErrorText = "This service name has existed";
                    //        e.Valid = false;
                    //    }
                    //}
                    if (hasSpecialChar(e.Value.ToString()))
                    {
                        e.ErrorText = "Has Special Char";
                        e.Valid = false;
                    } //else
                        //e.Value = e.Value.ToString().Trim().ToUpper();
                        //e.Value = e.Value.ToString().Trim();
                    break;
                case "ServiceNameVietnamese":
                    if (e.Value.ToString().Length > 60)
                    {
                        e.ErrorText = "Length this column <= 60";
                        e.Valid = false;
                    }
                    if (hasSpecialChar(e.Value.ToString()))
                    {
                        e.ErrorText = "Has Special Char";
                        e.Valid = false;
                    } //else
                        //e.Value = e.Value.ToString().Trim().ToUpper();
                        //e.Value = e.Value.ToString().Trim();
                    break;
            }
        }

        private bool CheckUserDepartment()
        {
            var isExistApplication = FileProcess.LoadTable("ST_WMS_LoadApplicationByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "',@ApplicationName='" + Application.ProductName + "'");
            if (isExistApplication == null || isExistApplication.Rows.Count <= 0)
            {
                return false;
            }

            int userApplicationID = (int)isExistApplication.Rows[0]["UserApplicationId"];
            var datasource = FileProcess.LoadTable("ST_WMS_LoadAllRoleByUser @LoginName='" + AppSetting.CurrentUser.LoginName + "' ,@UserApplicationID=" + userApplicationID);

            // Checking current user has level of IT
            var departmentRole = datasource.Select("UserDepartmentDefinitionID=2");
            if (departmentRole == null || !departmentRole.Any())
            {
                return false;
            }
            return true;
        }

        private void txtCalculatedSQL_EditValueChanged(object sender, EventArgs e)
        {
            this.grv_MSS_ServicesDefinition.SetFocusedRowCellValue("CalculatedSQL", txtCalculatedSQL.EditValue);
            this.grv_MSS_ServicesDefinition.SetRowCellValue(grv_MSS_ServicesDefinition.FocusedRowHandle, "IsModified", 1);
        }
    }
}

