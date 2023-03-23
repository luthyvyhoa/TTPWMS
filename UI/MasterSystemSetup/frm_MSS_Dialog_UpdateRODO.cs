using Common.Controls;
using DA;
using System.Collections.Generic;
using System.Linq;
using System;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Data;
using UI.Helper;

namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_Dialog_UpdateRODO : frmBaseForm
    {

        ST_WMS_LoadRecordProductData_Result obj_LoadRecordProductData;
        class CActionForm
        {
            public static int LoadForm = 1;
            public static int UpdateSelected = 2;
            public static int Edit = 4;
            public static int UpdateAll = 5;
            public static int Cancel = 6;
        }

        public frm_MSS_Dialog_UpdateRODO()
        {
            InitializeComponent();

            SetEvent();
        }

        public frm_MSS_Dialog_UpdateRODO(ST_WMS_LoadRecordProductData_Result i_LoadRecordProductData_Result)
        {
            InitializeComponent();

            obj_LoadRecordProductData = i_LoadRecordProductData_Result;

            SetEvent();
        }

        void Frm_MSS_Dialog_UpdateRODO_Load(object sender, EventArgs e)
        {
            DA.Master.ProductDA da = new DA.Master.ProductDA();

            try
            {
                int result = da.UpdateOrder((int)obj_LoadRecordProductData.ProductID, AppSetting.CurrentUser.LoginName);
            }
            catch { }

            var dataSource = FileProcess.LoadTable("select * from tmpUpdateRODO where UserId ='" + AppSetting.CurrentUser.LoginName + "' order by OrderNumber DESC");
            grd_MSS_View.DataSource = dataSource;
        }

        void SetEvent()
        {
            this.Load += Frm_MSS_Dialog_UpdateRODO_Load;
            this.Btn_close_updateproduct.Click += Btn_close_updateproduct_Click; ;
            this.btnUpdateSelected.Click += BtnUpdateSelected_Click;
            this.btnUpdateAll.Click += BtnUpdateAll_Click;
        }

        private void BtnUpdateAll_Click(object sender, EventArgs e)
        {
            DataTable sourceUpdate = (DataTable)this.grd_MSS_View.DataSource;
            DataProcess<object> tmpUpdateDA = new DataProcess<object>();
            using (var context = new SwireDBEntities())
            {
                foreach (DataRow rw in sourceUpdate.Rows)
                {
                    if (rw[5].Equals(true))
                    {
                        tmpUpdateDA.ExecuteNoQuery("ST_WMS_UpdatetmpRODOData @ID={0}," +
                        " @ID={1}," +
                        " @OrderNumber={2}," +
                        " @OldProductName={3}," +
                        " @OldProductNumber={4}," +
                        " @OldWeightPerPackage={5}," +
                        " @Updated={6}," +
                        " @OrderDetailID={7}," +
                        " @OrderDate={8}," +
                        " @UserId={9}", (int)rw[0], rw[1].ToString(), rw[2].ToString(), rw[3].ToString(),
                            (decimal)rw[4],
                            (bool)rw[5], (int)rw[6],
                        (DateTime)rw[7],
                        AppSetting.CurrentUser.LoginName);
                    }
                }
            }

            if (obj_LoadRecordProductData.CustomerType.ToUpper().Equals(CustomerTypeEnum.RANDOM_WEIGHT.ToUpper()))
            {
                XtraMessageBox.Show("This customer does not allow to update unit or weight!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (XtraMessageBox.Show("Are you sure to update all ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProcess<object> updateOrderDA = new DataProcess<object>();
                    int result = updateOrderDA.ExecuteNoQuery("UPDATE ReceivingOrderDetails SET ProductNumber = {0}, ProductName = {1} Where ProductID = {2}", obj_LoadRecordProductData.ProductNumber, obj_LoadRecordProductData.ProductName, obj_LoadRecordProductData.ProductID);
                    result = updateOrderDA.ExecuteNoQuery("UPDATE DispatchingProducts SET ProductNumber = {0}, ProductName = {1} Where ProductID = {2}", obj_LoadRecordProductData.ProductNumber, obj_LoadRecordProductData.ProductName, obj_LoadRecordProductData.ProductID);
                    this.Close();

                }
            }
            else
            {
                if (XtraMessageBox.Show("Are you sure to update all ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DA.Master.ProductDA da = new DA.Master.ProductDA();
                    int result = da.STProductUpdate((int)obj_LoadRecordProductData.ProductID, null, null, AppSetting.CurrentUser.LoginName);
                    this.Close();
                }
            }

            // Raise Reload Data event to RO,DO to reload data
            Common.Process.RefreshData.OnReloadData(new Products(), e);
            SetEnableButton(CActionForm.UpdateAll);

            this.Close();
        }

        private void BtnUpdateSelected_Click(object sender, EventArgs e)
        {
            IList<DataRow> sourceUpdateData = new List<DataRow>();
            DataProcess<object> tmpUpdateDA = new DataProcess<object>();
            DataTable sourceUpdate = (DataTable)this.grd_MSS_View.DataSource;

            using (var context = new SwireDBEntities())
            {
                for (int i = 0; i < sourceUpdate.Rows.Count; i++)
                {
                    if (sourceUpdate.Rows[i][5].Equals(true))
                    {
                        sourceUpdateData.Add(sourceUpdate.Rows[i]);
                        int result = tmpUpdateDA.ExecuteNoQuery("Update tmpUpdateRODO Set Updated = {0} Where ID = {1}", true, sourceUpdate.Rows[i]["ID"]);
                    }
                }
            }

            if (obj_LoadRecordProductData.CustomerType.ToUpper().Equals(CustomerTypeEnum.RANDOM_WEIGHT.ToUpper()))
            {
                XtraMessageBox.Show("This customer does not allow to update unit or weight!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (XtraMessageBox.Show("Are you sure to update selected ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProcess<object> updateOrderDA = new DataProcess<object>();
                    int result = updateOrderDA.ExecuteNoQuery("UPDATE ReceivingOrderDetails SET ProductNumber = {0}, ProductName = {1} Where ProductID = {2} AND ReceivingOrderDetailID IN (SELECT OrderDetailID FROM tmpUpdateRODO WHERE Updated = 1)", obj_LoadRecordProductData.ProductNumber, obj_LoadRecordProductData.ProductName, obj_LoadRecordProductData.ProductID);
                    this.Close();
                }
            }
            else
            {
                if (XtraMessageBox.Show("Are you sure to update selected ?", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strConditionR = "";
                    string strConditionD = "";

                    if (sourceUpdateData.Count == 0)
                    {
                        XtraMessageBox.Show("You have to select order to updating!", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        strConditionR = "0";
                        strConditionD = "0";

                        foreach (var item in sourceUpdateData)
                        {
                            if (item[1].ToString().Substring(0, 2).ToUpper().Equals("RO".ToUpper()))
                            {
                                strConditionR = strConditionR + "," + item[6].ToString();
                            }
                            else
                            {
                                strConditionD = strConditionD + "," + item[6].ToString();
                            }
                        }
                        strConditionR = "(" + strConditionR + ")";
                        strConditionD = "(" + strConditionD + ")";

                        var currrentUser = AppSetting.CurrentUser.LoginName;
                        DA.Master.ProductDA da = new DA.Master.ProductDA();
                        int result = da.STProductUpdate((int)obj_LoadRecordProductData.ProductID, strConditionR, strConditionD, currrentUser);

                        this.Close();
                    }
                }
            }

            // Raise Reload Data event to RO,DO to reload data
            Common.Process.RefreshData.OnReloadData(sender, e);
            SetEnableButton(CActionForm.UpdateSelected);

            this.Close();
        }

        private void Btn_close_updateproduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Btn_MSS_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grv_MSS_View.Columns["Updated"].OptionsColumn.AllowEdit = false;

            SetEnableButton(CActionForm.Cancel);
        }

        void Btn_MSS_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grv_MSS_View.Columns["Updated"].OptionsColumn.AllowEdit = true;

            SetEnableButton(CActionForm.Edit);
        }

        void ActiveEditor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            object v_data = this.grv_MSS_View.GetFocusedRowCellValue("Updated");
            if (Convert.ToBoolean(v_data) == true)
            {
                this.grv_MSS_View.SetFocusedRowCellValue("Updated", 0);
            }
            else
            {
                this.grv_MSS_View.SetFocusedRowCellValue("Updated", 1);
            }
        }

        void grv_MSS_View_ShownEditor(object sender, EventArgs e)
        {
            this.grv_MSS_View.ActiveEditor.MouseUp += ActiveEditor_MouseUp;
        }

        void SetEnableButton(int i_ActionControlForm)
        {
            //#region LoadForm

            //if (i_ActionControlForm.Equals(CActionForm.LoadForm))
            //{
            //    btn_MSS_Cancel.Enabled = false;
            //    btn_MSS_Edit.Enabled = true;
            //    btn_MSS_UpdateAll.Enabled = false;
            //    btn_MSS_UpdateSelected.Enabled = false;
            //}
            //#endregion LoadForm

            //#region Edit

            //else if (i_ActionControlForm.Equals(CActionForm.Edit))
            //{
            //    btn_MSS_Cancel.Enabled = true;
            //    btn_MSS_Edit.Enabled = false;
            //    btn_MSS_UpdateAll.Enabled = true;
            //    btn_MSS_UpdateSelected.Enabled = true;
            //}

            //#endregion Edit

            //#region UpdateAll

            //else if (i_ActionControlForm.Equals(CActionForm.UpdateAll))
            //{
            //    btn_MSS_Cancel.Enabled = false;
            //    btn_MSS_Edit.Enabled = true;
            //    btn_MSS_UpdateAll.Enabled = false;
            //    btn_MSS_UpdateSelected.Enabled = false;

            //}
            //#endregion UpdateAll

            //#region UpdateSelected

            //else if (i_ActionControlForm.Equals(CActionForm.UpdateSelected))
            //{
            //    btn_MSS_Cancel.Enabled = false;
            //    btn_MSS_Edit.Enabled = true;
            //    btn_MSS_UpdateAll.Enabled = false;
            //    btn_MSS_UpdateSelected.Enabled = false;
            //}
            //#endregion UpdateSelected

            //#region Cancel

            //else if (i_ActionControlForm.Equals(CActionForm.Cancel))
            //{
            //    btn_MSS_Cancel.Enabled = false;
            //    btn_MSS_Edit.Enabled = true;
            //    btn_MSS_UpdateAll.Enabled = false;
            //    btn_MSS_UpdateSelected.Enabled = false;
            //}

            //#endregion Cancel

            //#region Other

            //else
            //{
            //    btn_MSS_Cancel.Enabled = false;
            //    btn_MSS_Edit.Enabled = false;
            //    btn_MSS_UpdateAll.Enabled = false;
            //    btn_MSS_UpdateSelected.Enabled = false;
            //}

            //#endregion Other
        }

        private void btn_MSS_Close_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_MSS_UpdateSelected_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_MSS_UpdateAll_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void frm_MSS_Dialog_UpdateRODO_Load_1(object sender, EventArgs e)
        {

        }
    }
}
