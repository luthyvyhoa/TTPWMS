using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace UI.MasterSystemSetup
{
    partial class frm_MSS_Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MSS_Products));
            DevExpress.Utils.TrackBarContextButton trackBarContextButton1 = new DevExpress.Utils.TrackBarContextButton();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.btn_P_New = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Copy = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Save = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControlProductInfo = new DevExpress.XtraLayout.LayoutControl();
            this.txtBoxSize = new DevExpress.XtraEditors.TextEdit();
            this.txtSubCode = new DevExpress.XtraEditors.TextEdit();
            this.btnAddPackageType = new DevExpress.XtraEditors.SimpleButton();
            this.grdHeSoQuyDoi = new DevExpress.XtraGrid.GridControl();
            this.grvHeSoQuyDoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_lke_DVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.txtEdit_GTIN = new DevExpress.XtraEditors.TextEdit();
            this.labelControlStopStrip = new DevExpress.XtraEditors.LabelControl();
            this.btnShowERPUOMList = new DevExpress.XtraEditors.SimpleButton();
            this.imgSld_Products = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.grcProductPackages = new DevExpress.XtraGrid.GridControl();
            this.grvProductPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleteColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpi_btn_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rpi_lke_PackagesList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnProductList = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnPalletInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtERP = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEdit_WAREHOUSE_NO = new DevExpress.XtraEditors.LookUpEdit();
            this.chkEdit_Discontinue = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpEdit_HomeRoom2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_HomeRoom1 = new DevExpress.XtraEditors.LookUpEdit();
            this.chkEdit_IsWeightingRequire = new DevExpress.XtraEditors.CheckEdit();
            this.chkEdit_IsAllowLocationChange = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit_CBM = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpEdit_CustomerProductGroups = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit_Inners = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_PackagesPerPallet2 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_PackagesPerPallet = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpEdit_Packages = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit_GrossWeightPerPackage = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_WeightPerPackage = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_WarningDaysBeforeExpiry = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_TemperatureRequire = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpEdit_ProductCategoryID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEdit_Origin = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_ProductNameVN = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_ProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_ProductNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_InitialLabel = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEdit_CustomerID = new DevExpress.XtraEditors.LookUpEdit();
            this.radGroup_PickingMethod = new DevExpress.XtraEditors.RadioGroup();
            this.txtEdit_Remark = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_CreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.dateEdit_CreatedTime = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit_PickingLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.txtProductID = new DevExpress.XtraEditors.TextEdit();
            this.lke_WM_Products = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit_SafetyStock = new DevExpress.XtraEditors.SpinEdit();
            this.spPcs = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_SelfLifeDays = new DevExpress.XtraEditors.SpinEdit();
            this.lke_PackageTypes = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit_Net = new DevExpress.XtraEditors.SpinEdit();
            this.chkEdit_IsGetNet = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPickingLocation = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCancelButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPackageList = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_P_ProductList = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_UpdateOrder1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_PalletInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Close = new DevExpress.XtraBars.BarButtonItem();
            this.btn_P_Cancel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_P_StopProduct = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlProductInfo)).BeginInit();
            this.layoutControlProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeSoQuyDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHeSoQuyDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_GTIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSld_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProductPackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PackagesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtERP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_WAREHOUSE_NO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_Discontinue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_HomeRoom2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_HomeRoom1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsWeightingRequire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsAllowLocationChange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_CBM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_CustomerProductGroups.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Inners.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PackagesPerPallet2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PackagesPerPallet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Packages.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_GrossWeightPerPackage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_WeightPerPackage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_WarningDaysBeforeExpiry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TemperatureRequire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_ProductCategoryID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Origin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductNameVN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_InitialLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_CustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroup_PickingMethod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Remark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_CreatedTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_CreatedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_PickingLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_WM_Products.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SafetyStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPcs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SelfLifeDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_PackageTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Net.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsGetNet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPickingLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPackageList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcbase
            // 
            this.rbcbase.ExpandCollapseItem.Id = 0;
            this.rbcbase.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_P_New,
            this.btn_P_Copy,
            this.btn_P_Save,
            this.btn_P_Edit,
            this.btn_P_Delete,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.btn_P_ProductList,
            this.btn_P_UpdateOrder1,
            this.btn_P_PalletInfor,
            this.btn_P_Close,
            this.btn_P_Cancel,
            this.btn_P_StopProduct});
            this.rbcbase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbcbase.MaxItemId = 29;
            this.rbcbase.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.rbcbase.OptionsMenuMinWidth = 550;
            // 
            // 
            // 
            this.rbcbase.SearchEditItem.AccessibleName = "Search Item";
            this.rbcbase.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.rbcbase.SearchEditItem.EditWidth = 150;
            this.rbcbase.SearchEditItem.Id = -5000;
            this.rbcbase.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.rbcbase.SearchEditItem.UseEditorPadding = false;
            this.rbcbase.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.rbcbase.ShowToolbarCustomizeItem = false;
            this.rbcbase.Size = new System.Drawing.Size(1551, 44);
            this.rbcbase.Toolbar.ShowCustomizeItem = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_New);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_Copy);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_Edit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_Save);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_Delete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_P_Cancel);
            this.ribbonPageGroup1.Text = "Edit";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup8,
            this.ribbonPageGroup10,
            this.ribbonPageGroup9});
            // 
            // btn_P_New
            // 
            this.btn_P_New.Caption = "New";
            this.btn_P_New.Id = 2;
            this.btn_P_New.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_New.ImageOptions.SvgImage")));
            this.btn_P_New.Name = "btn_P_New";
            // 
            // btn_P_Copy
            // 
            this.btn_P_Copy.Caption = "Copy";
            this.btn_P_Copy.Id = 3;
            this.btn_P_Copy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_Copy.ImageOptions.SvgImage")));
            this.btn_P_Copy.Name = "btn_P_Copy";
            // 
            // btn_P_Save
            // 
            this.btn_P_Save.Caption = "Save";
            this.btn_P_Save.Id = 4;
            this.btn_P_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_Save.ImageOptions.SvgImage")));
            this.btn_P_Save.Name = "btn_P_Save";
            // 
            // btn_P_Edit
            // 
            this.btn_P_Edit.Caption = "Edit";
            this.btn_P_Edit.Id = 5;
            this.btn_P_Edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_Edit.ImageOptions.SvgImage")));
            this.btn_P_Edit.Name = "btn_P_Edit";
            // 
            // btn_P_Delete
            // 
            this.btn_P_Delete.Caption = "Delete";
            this.btn_P_Delete.Id = 6;
            this.btn_P_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_Delete.ImageOptions.SvgImage")));
            this.btn_P_Delete.Name = "btn_P_Delete";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Close";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "Close";
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panel1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.panel1, DevExpress.Utils.DefaultBoolean.Default);
            this.panel1.Controls.Add(this.layoutControlProductInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 686);
            this.panel1.TabIndex = 6;
            // 
            // layoutControlProductInfo
            // 
            this.layoutControlProductInfo.Controls.Add(this.txtBoxSize);
            this.layoutControlProductInfo.Controls.Add(this.txtSubCode);
            this.layoutControlProductInfo.Controls.Add(this.btnAddPackageType);
            this.layoutControlProductInfo.Controls.Add(this.grdHeSoQuyDoi);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_GTIN);
            this.layoutControlProductInfo.Controls.Add(this.labelControlStopStrip);
            this.layoutControlProductInfo.Controls.Add(this.btnShowERPUOMList);
            this.layoutControlProductInfo.Controls.Add(this.imgSld_Products);
            this.layoutControlProductInfo.Controls.Add(this.grcProductPackages);
            this.layoutControlProductInfo.Controls.Add(this.btnCancel);
            this.layoutControlProductInfo.Controls.Add(this.btnStop);
            this.layoutControlProductInfo.Controls.Add(this.btnCopy);
            this.layoutControlProductInfo.Controls.Add(this.btnEdit);
            this.layoutControlProductInfo.Controls.Add(this.btnDelete);
            this.layoutControlProductInfo.Controls.Add(this.btnProductList);
            this.layoutControlProductInfo.Controls.Add(this.btnUpdateOrder);
            this.layoutControlProductInfo.Controls.Add(this.btnPalletInfo);
            this.layoutControlProductInfo.Controls.Add(this.btnNew);
            this.layoutControlProductInfo.Controls.Add(this.btnClose);
            this.layoutControlProductInfo.Controls.Add(this.txtERP);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_WAREHOUSE_NO);
            this.layoutControlProductInfo.Controls.Add(this.chkEdit_Discontinue);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_HomeRoom2);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_HomeRoom1);
            this.layoutControlProductInfo.Controls.Add(this.chkEdit_IsWeightingRequire);
            this.layoutControlProductInfo.Controls.Add(this.chkEdit_IsAllowLocationChange);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_CBM);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_CustomerProductGroups);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_Inners);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_PackagesPerPallet2);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_PackagesPerPallet);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_Packages);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_GrossWeightPerPackage);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_WeightPerPackage);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_WarningDaysBeforeExpiry);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_TemperatureRequire);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_ProductCategoryID);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_Origin);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_ProductNameVN);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_ProductName);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_ProductNumber);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_InitialLabel);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_CustomerName);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_CustomerID);
            this.layoutControlProductInfo.Controls.Add(this.radGroup_PickingMethod);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_Remark);
            this.layoutControlProductInfo.Controls.Add(this.txtEdit_CreatedBy);
            this.layoutControlProductInfo.Controls.Add(this.dateEdit_CreatedTime);
            this.layoutControlProductInfo.Controls.Add(this.lookUpEdit_PickingLocation);
            this.layoutControlProductInfo.Controls.Add(this.txtProductID);
            this.layoutControlProductInfo.Controls.Add(this.lke_WM_Products);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_SafetyStock);
            this.layoutControlProductInfo.Controls.Add(this.spPcs);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_SelfLifeDays);
            this.layoutControlProductInfo.Controls.Add(this.lke_PackageTypes);
            this.layoutControlProductInfo.Controls.Add(this.spinEdit_Net);
            this.layoutControlProductInfo.Controls.Add(this.chkEdit_IsGetNet);
            this.layoutControlProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlProductInfo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlProductInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControlProductInfo.Name = "layoutControlProductInfo";
            this.layoutControlProductInfo.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(807, 474, 965, 366);
            this.layoutControlProductInfo.Root = this.layoutControlGroup1;
            this.layoutControlProductInfo.Size = new System.Drawing.Size(1551, 686);
            this.layoutControlProductInfo.TabIndex = 2;
            this.layoutControlProductInfo.Text = "layoutControl1";
            // 
            // txtBoxSize
            // 
            this.txtBoxSize.Location = new System.Drawing.Point(418, 167);
            this.txtBoxSize.MenuManager = this.rbcbase;
            this.txtBoxSize.Name = "txtBoxSize";
            this.txtBoxSize.Size = new System.Drawing.Size(167, 22);
            this.txtBoxSize.StyleController = this.layoutControlProductInfo;
            this.txtBoxSize.TabIndex = 70;
            // 
            // txtSubCode
            // 
            this.txtSubCode.Location = new System.Drawing.Point(151, 32);
            this.txtSubCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSubCode.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtSubCode.MenuManager = this.rbcbase;
            this.txtSubCode.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(521, 20);
            this.txtSubCode.StyleController = this.layoutControlProductInfo;
            this.txtSubCode.TabIndex = 69;
            // 
            // btnAddPackageType
            // 
            this.btnAddPackageType.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPackageType.ImageOptions.Image")));
            this.btnAddPackageType.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAddPackageType.Location = new System.Drawing.Point(310, 167);
            this.btnAddPackageType.Name = "btnAddPackageType";
            this.btnAddPackageType.Size = new System.Drawing.Size(49, 22);
            this.btnAddPackageType.StyleController = this.layoutControlProductInfo;
            this.btnAddPackageType.TabIndex = 68;
            this.btnAddPackageType.Click += new System.EventHandler(this.btnAddPackageType_Click);
            // 
            // grdHeSoQuyDoi
            // 
            this.grdHeSoQuyDoi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdHeSoQuyDoi.Location = new System.Drawing.Point(695, 429);
            this.grdHeSoQuyDoi.MainView = this.grvHeSoQuyDoi;
            this.grdHeSoQuyDoi.MenuManager = this.rbcbase;
            this.grdHeSoQuyDoi.Name = "grdHeSoQuyDoi";
            this.grdHeSoQuyDoi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_DVT,
            this.repositoryItemSpinEdit1});
            this.grdHeSoQuyDoi.Size = new System.Drawing.Size(377, 172);
            this.grdHeSoQuyDoi.TabIndex = 67;
            this.grdHeSoQuyDoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHeSoQuyDoi});
            // 
            // grvHeSoQuyDoi
            // 
            this.grvHeSoQuyDoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn9,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn10});
            this.grvHeSoQuyDoi.FixedLineWidth = 1;
            this.grvHeSoQuyDoi.GridControl = this.grdHeSoQuyDoi;
            this.grvHeSoQuyDoi.Name = "grvHeSoQuyDoi";
            this.grvHeSoQuyDoi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvHeSoQuyDoi_CellValueChanged);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ProductMeasureID";
            this.gridColumn12.FieldName = "ProductMeasureID";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 93;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "ProductID";
            this.gridColumn13.FieldName = "ProductID";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 93;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Measure";
            this.gridColumn9.ColumnEdit = this.rpi_lke_DVT;
            this.gridColumn9.FieldName = "MeasureID";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 93;
            // 
            // rpi_lke_DVT
            // 
            this.rpi_lke_DVT.AutoHeight = false;
            this.rpi_lke_DVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_DVT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVTID", "ID", 25, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDVT", "ĐVT", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GiaTri", "GiaTri", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_DVT.Name = "rpi_lke_DVT";
            this.rpi_lke_DVT.NullText = "";
            this.rpi_lke_DVT.EditValueChanged += new System.EventHandler(this.rpi_lke_DVT_EditValueChanged);
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "HS";
            this.gridColumn14.DisplayFormat.FormatString = "n4";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "HS";
            this.gridColumn14.MinWidth = 25;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HS", "{0:n4}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 93;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "CreatedTime";
            this.gridColumn15.FieldName = "CreatedTime";
            this.gridColumn15.MinWidth = 25;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 93;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "CreatedBy";
            this.gridColumn10.FieldName = "CreatedBy";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Width = 93;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "n4";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "n4";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Mask.EditMask = "#.####";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // txtEdit_GTIN
            // 
            this.txtEdit_GTIN.Location = new System.Drawing.Point(489, 100);
            this.txtEdit_GTIN.MenuManager = this.rbcbase;
            this.txtEdit_GTIN.Name = "txtEdit_GTIN";
            this.txtEdit_GTIN.Size = new System.Drawing.Size(183, 22);
            this.txtEdit_GTIN.StyleController = this.layoutControlProductInfo;
            this.txtEdit_GTIN.TabIndex = 64;
            // 
            // labelControlStopStrip
            // 
            this.labelControlStopStrip.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.labelControlStopStrip.Appearance.Options.UseBackColor = true;
            this.labelControlStopStrip.Location = new System.Drawing.Point(6, -39);
            this.labelControlStopStrip.MaximumSize = new System.Drawing.Size(5, 730);
            this.labelControlStopStrip.MinimumSize = new System.Drawing.Size(5, 530);
            this.labelControlStopStrip.Name = "labelControlStopStrip";
            this.labelControlStopStrip.Size = new System.Drawing.Size(5, 719);
            this.labelControlStopStrip.StyleController = this.layoutControlProductInfo;
            this.labelControlStopStrip.TabIndex = 63;
            this.labelControlStopStrip.Text = ".";
            // 
            // btnShowERPUOMList
            // 
            this.btnShowERPUOMList.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnShowERPUOMList.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnShowERPUOMList.Appearance.Options.UseBackColor = true;
            this.btnShowERPUOMList.Appearance.Options.UseFont = true;
            this.btnShowERPUOMList.Location = new System.Drawing.Point(1005, 37);
            this.btnShowERPUOMList.Name = "btnShowERPUOMList";
            this.btnShowERPUOMList.Size = new System.Drawing.Size(67, 22);
            this.btnShowERPUOMList.StyleController = this.layoutControlProductInfo;
            this.btnShowERPUOMList.TabIndex = 62;
            this.btnShowERPUOMList.Text = "UOM List";
            this.btnShowERPUOMList.Click += new System.EventHandler(this.btnShowERPUOMList_Click);
            // 
            // imgSld_Products
            // 
            this.imgSld_Products.AutoSlide = DevExpress.XtraEditors.Controls.AutoSlide.Forward;
            trackBarContextButton1.Id = new System.Guid("ed73b0cc-cc83-4023-9731-376903c9c2e8");
            trackBarContextButton1.Name = "trackBarContextButton1";
            trackBarContextButton1.Value = 500;
            this.imgSld_Products.ContextButtons.Add(trackBarContextButton1);
            this.imgSld_Products.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgSld_Products.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Squeeze;
            this.imgSld_Products.Location = new System.Drawing.Point(1095, -36);
            this.imgSld_Products.Name = "imgSld_Products";
            this.imgSld_Products.Size = new System.Drawing.Size(428, 650);
            this.imgSld_Products.StyleController = this.layoutControlProductInfo;
            this.imgSld_Products.TabIndex = 45;
            this.imgSld_Products.Text = "imageSlider1";
            this.imgSld_Products.Click += new System.EventHandler(this.imgSld_Products_Click);
            // 
            // grcProductPackages
            // 
            this.grcProductPackages.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grcProductPackages.Location = new System.Drawing.Point(696, 199);
            this.grcProductPackages.MainView = this.grvProductPackage;
            this.grcProductPackages.MenuManager = this.rbcbase;
            this.grcProductPackages.Name = "grcProductPackages";
            this.grcProductPackages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpi_lke_PackagesList,
            this.rpi_btn_Delete});
            this.grcProductPackages.Size = new System.Drawing.Size(375, 199);
            this.grcProductPackages.TabIndex = 0;
            this.grcProductPackages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProductPackage});
            // 
            // grvProductPackage
            // 
            this.grvProductPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn11,
            this.colDeleteColumn});
            this.grvProductPackage.FixedLineWidth = 1;
            this.grvProductPackage.GridControl = this.grcProductPackages;
            this.grvProductPackage.Name = "grvProductPackage";
            this.grvProductPackage.OptionsView.ShowGroupPanel = false;
            this.grvProductPackage.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvProductPackage_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ERP";
            this.gridColumn1.FieldName = "ERP";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 93;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "UOM";
            this.gridColumn2.FieldName = "UOM";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 68;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Values";
            this.gridColumn3.FieldName = "HS";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 97;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Note";
            this.gridColumn4.FieldName = "Remark";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ProductPackageID";
            this.gridColumn5.FieldName = "ProductPackageID";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 93;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ProductID";
            this.gridColumn6.FieldName = "ProductID";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 93;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Created";
            this.gridColumn7.FieldName = "CreatedBy";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 73;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Time";
            this.gridColumn8.FieldName = "CreatedTime";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 119;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Levels";
            this.gridColumn11.FieldName = "Levels";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 60;
            // 
            // colDeleteColumn
            // 
            this.colDeleteColumn.ColumnEdit = this.rpi_btn_Delete;
            this.colDeleteColumn.MaxWidth = 39;
            this.colDeleteColumn.MinWidth = 39;
            this.colDeleteColumn.Name = "colDeleteColumn";
            this.colDeleteColumn.Visible = true;
            this.colDeleteColumn.VisibleIndex = 5;
            this.colDeleteColumn.Width = 39;
            // 
            // rpi_btn_Delete
            // 
            this.rpi_btn_Delete.AutoHeight = false;
            editorButtonImageOptions1.Image = global::UI.Properties.Resources.cancel_16x16;
            this.rpi_btn_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpi_btn_Delete.Name = "rpi_btn_Delete";
            this.rpi_btn_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpi_btn_Delete.Click += new System.EventHandler(this.rpi_btn_Delete_Click);
            // 
            // rpi_lke_PackagesList
            // 
            this.rpi_lke_PackagesList.AutoHeight = false;
            this.rpi_lke_PackagesList.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.rpi_lke_PackagesList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpi_lke_PackagesList.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.rpi_lke_PackagesList.DisplayMember = "Code";
            this.rpi_lke_PackagesList.DropDownRows = 20;
            this.rpi_lke_PackagesList.Name = "rpi_lke_PackagesList";
            this.rpi_lke_PackagesList.NullText = "";
            this.rpi_lke_PackagesList.ValueMember = "Code";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(595, 636);
            this.btnCancel.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCancel.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 41);
            this.btnCancel.StyleController = this.layoutControlProductInfo;
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStop
            // 
            this.btnStop.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnStop.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnStop.Appearance.Options.UseBackColor = true;
            this.btnStop.Appearance.Options.UseFont = true;
            this.btnStop.AppearanceDisabled.BackColor = System.Drawing.Color.Silver;
            this.btnStop.AppearanceDisabled.Options.UseBackColor = true;
            this.btnStop.Location = new System.Drawing.Point(18, 636);
            this.btnStop.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnStop.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(125, 41);
            this.btnStop.StyleController = this.layoutControlProductInfo;
            this.btnStop.TabIndex = 60;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnCopy.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCopy.Appearance.Options.UseBackColor = true;
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.Location = new System.Drawing.Point(284, 636);
            this.btnCopy.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnCopy.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(125, 41);
            this.btnCopy.StyleController = this.layoutControlProductInfo;
            this.btnCopy.TabIndex = 58;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Location = new System.Drawing.Point(462, 636);
            this.btnEdit.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnEdit.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 41);
            this.btnEdit.StyleController = this.layoutControlProductInfo;
            this.btnEdit.TabIndex = 57;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Location = new System.Drawing.Point(728, 636);
            this.btnDelete.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnDelete.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 41);
            this.btnDelete.StyleController = this.layoutControlProductInfo;
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnProductList
            // 
            this.btnProductList.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnProductList.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnProductList.Appearance.Options.UseBackColor = true;
            this.btnProductList.Appearance.Options.UseFont = true;
            this.btnProductList.Location = new System.Drawing.Point(999, 636);
            this.btnProductList.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnProductList.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Size = new System.Drawing.Size(125, 41);
            this.btnProductList.StyleController = this.layoutControlProductInfo;
            this.btnProductList.TabIndex = 55;
            this.btnProductList.Text = "Show List";
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnUpdateOrder.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdateOrder.Appearance.Options.UseBackColor = true;
            this.btnUpdateOrder.Appearance.Options.UseFont = true;
            this.btnUpdateOrder.Location = new System.Drawing.Point(1132, 636);
            this.btnUpdateOrder.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnUpdateOrder.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(125, 41);
            this.btnUpdateOrder.StyleController = this.layoutControlProductInfo;
            this.btnUpdateOrder.TabIndex = 54;
            this.btnUpdateOrder.Text = "Update Orders";
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // btnPalletInfo
            // 
            this.btnPalletInfo.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnPalletInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnPalletInfo.Appearance.Options.UseBackColor = true;
            this.btnPalletInfo.Appearance.Options.UseFont = true;
            this.btnPalletInfo.Location = new System.Drawing.Point(1265, 636);
            this.btnPalletInfo.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnPalletInfo.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnPalletInfo.Name = "btnPalletInfo";
            this.btnPalletInfo.Size = new System.Drawing.Size(125, 41);
            this.btnPalletInfo.StyleController = this.layoutControlProductInfo;
            this.btnPalletInfo.TabIndex = 53;
            this.btnPalletInfo.Text = "Pallet Info";
            this.btnPalletInfo.Click += new System.EventHandler(this.btnPalletInfo_Click);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.btnNew.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Location = new System.Drawing.Point(151, 636);
            this.btnNew.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnNew.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 41);
            this.btnNew.StyleController = this.layoutControlProductInfo;
            this.btnNew.TabIndex = 52;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1398, 636);
            this.btnClose.MaximumSize = new System.Drawing.Size(125, 41);
            this.btnClose.MinimumSize = new System.Drawing.Size(125, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 41);
            this.btnClose.StyleController = this.layoutControlProductInfo;
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtERP
            // 
            this.txtERP.Location = new System.Drawing.Point(896, 40);
            this.txtERP.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtERP.MenuManager = this.rbcbase;
            this.txtERP.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtERP.Name = "txtERP";
            this.txtERP.Size = new System.Drawing.Size(102, 20);
            this.txtERP.StyleController = this.layoutControlProductInfo;
            this.txtERP.TabIndex = 47;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.txtERP, conditionValidationRule1);
            // 
            // lookUpEdit_WAREHOUSE_NO
            // 
            this.lookUpEdit_WAREHOUSE_NO.Location = new System.Drawing.Point(552, 504);
            this.lookUpEdit_WAREHOUSE_NO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_WAREHOUSE_NO.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_WAREHOUSE_NO.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_WAREHOUSE_NO.Name = "lookUpEdit_WAREHOUSE_NO";
            this.lookUpEdit_WAREHOUSE_NO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_WAREHOUSE_NO.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Warehouse No (Metro)", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_WAREHOUSE_NO.Properties.NullText = "";
            this.lookUpEdit_WAREHOUSE_NO.Size = new System.Drawing.Size(104, 20);
            this.lookUpEdit_WAREHOUSE_NO.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_WAREHOUSE_NO.TabIndex = 43;
            // 
            // chkEdit_Discontinue
            // 
            this.chkEdit_Discontinue.Location = new System.Drawing.Point(104, 593);
            this.chkEdit_Discontinue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEdit_Discontinue.MaximumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_Discontinue.MinimumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_Discontinue.Name = "chkEdit_Discontinue";
            this.chkEdit_Discontinue.Properties.Caption = "";
            this.chkEdit_Discontinue.Size = new System.Drawing.Size(568, 20);
            this.chkEdit_Discontinue.StyleController = this.layoutControlProductInfo;
            this.chkEdit_Discontinue.TabIndex = 42;
            // 
            // lookUpEdit_HomeRoom2
            // 
            this.lookUpEdit_HomeRoom2.Location = new System.Drawing.Point(282, 275);
            this.lookUpEdit_HomeRoom2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_HomeRoom2.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_HomeRoom2.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_HomeRoom2.Name = "lookUpEdit_HomeRoom2";
            this.lookUpEdit_HomeRoom2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_HomeRoom2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNum", "Location", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "Name8", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Name9", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_HomeRoom2.Properties.DisplayMember = "LocationNum";
            this.lookUpEdit_HomeRoom2.Properties.NullText = "";
            this.lookUpEdit_HomeRoom2.Properties.ValueMember = "RoomID";
            this.lookUpEdit_HomeRoom2.Size = new System.Drawing.Size(115, 20);
            this.lookUpEdit_HomeRoom2.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_HomeRoom2.TabIndex = 25;
            // 
            // lookUpEdit_HomeRoom1
            // 
            this.lookUpEdit_HomeRoom1.Location = new System.Drawing.Point(151, 276);
            this.lookUpEdit_HomeRoom1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_HomeRoom1.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_HomeRoom1.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_HomeRoom1.Name = "lookUpEdit_HomeRoom1";
            this.lookUpEdit_HomeRoom1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_HomeRoom1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNum", "Location", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoomID", "RoomID", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "Name6", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_HomeRoom1.Properties.DisplayMember = "LocationNum";
            this.lookUpEdit_HomeRoom1.Properties.NullText = "";
            this.lookUpEdit_HomeRoom1.Properties.ValueMember = "RoomID";
            this.lookUpEdit_HomeRoom1.Size = new System.Drawing.Size(126, 20);
            this.lookUpEdit_HomeRoom1.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_HomeRoom1.TabIndex = 24;
            // 
            // chkEdit_IsWeightingRequire
            // 
            this.chkEdit_IsWeightingRequire.Location = new System.Drawing.Point(896, 146);
            this.chkEdit_IsWeightingRequire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEdit_IsWeightingRequire.MaximumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsWeightingRequire.MinimumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsWeightingRequire.Name = "chkEdit_IsWeightingRequire";
            this.chkEdit_IsWeightingRequire.Properties.Caption = "";
            this.chkEdit_IsWeightingRequire.Size = new System.Drawing.Size(175, 20);
            this.chkEdit_IsWeightingRequire.StyleController = this.layoutControlProductInfo;
            this.chkEdit_IsWeightingRequire.TabIndex = 23;
            // 
            // chkEdit_IsAllowLocationChange
            // 
            this.chkEdit_IsAllowLocationChange.Location = new System.Drawing.Point(610, 276);
            this.chkEdit_IsAllowLocationChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEdit_IsAllowLocationChange.MaximumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsAllowLocationChange.MinimumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsAllowLocationChange.Name = "chkEdit_IsAllowLocationChange";
            this.chkEdit_IsAllowLocationChange.Properties.Caption = "";
            this.chkEdit_IsAllowLocationChange.Size = new System.Drawing.Size(62, 20);
            this.chkEdit_IsAllowLocationChange.StyleController = this.layoutControlProductInfo;
            this.chkEdit_IsAllowLocationChange.TabIndex = 22;
            // 
            // spinEdit_CBM
            // 
            this.spinEdit_CBM.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_CBM.Location = new System.Drawing.Point(530, 204);
            this.spinEdit_CBM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_CBM.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_CBM.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_CBM.Name = "spinEdit_CBM";
            this.spinEdit_CBM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_CBM.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_CBM.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_CBM.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_CBM.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_CBM.Properties.Mask.EditMask = "n0";
            this.spinEdit_CBM.Size = new System.Drawing.Size(142, 20);
            this.spinEdit_CBM.StyleController = this.layoutControlProductInfo;
            this.spinEdit_CBM.TabIndex = 21;
            // 
            // lookUpEdit_CustomerProductGroups
            // 
            this.lookUpEdit_CustomerProductGroups.Location = new System.Drawing.Point(552, 402);
            this.lookUpEdit_CustomerProductGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_CustomerProductGroups.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_CustomerProductGroups.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_CustomerProductGroups.Name = "lookUpEdit_CustomerProductGroups";
            this.lookUpEdit_CustomerProductGroups.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_CustomerProductGroups.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_CustomerProductGroups.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductGroupDescription", "Product Group", 500, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ISDefault", "Default", 167, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductGroupID", "ID", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_CustomerProductGroups.Properties.DisplayMember = "ProductGroupDescription";
            this.lookUpEdit_CustomerProductGroups.Properties.NullText = "";
            this.lookUpEdit_CustomerProductGroups.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lookUpEdit_CustomerProductGroups.Properties.ShowFooter = false;
            this.lookUpEdit_CustomerProductGroups.Properties.ShowHeader = false;
            this.lookUpEdit_CustomerProductGroups.Properties.ValueMember = "ProductGroupID";
            this.lookUpEdit_CustomerProductGroups.Size = new System.Drawing.Size(104, 20);
            this.lookUpEdit_CustomerProductGroups.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_CustomerProductGroups.TabIndex = 20;
            // 
            // spinEdit_Inners
            // 
            this.spinEdit_Inners.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Inners.Location = new System.Drawing.Point(896, 110);
            this.spinEdit_Inners.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_Inners.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_Inners.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_Inners.Name = "spinEdit_Inners";
            this.spinEdit_Inners.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_Inners.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_Inners.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_Inners.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_Inners.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_Inners.Properties.Mask.EditMask = "n0";
            this.spinEdit_Inners.Size = new System.Drawing.Size(175, 20);
            this.spinEdit_Inners.StyleController = this.layoutControlProductInfo;
            this.spinEdit_Inners.TabIndex = 19;
            // 
            // spinEdit_PackagesPerPallet2
            // 
            this.spinEdit_PackagesPerPallet2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_PackagesPerPallet2.Location = new System.Drawing.Point(567, 134);
            this.spinEdit_PackagesPerPallet2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_PackagesPerPallet2.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_PackagesPerPallet2.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_PackagesPerPallet2.Name = "spinEdit_PackagesPerPallet2";
            this.spinEdit_PackagesPerPallet2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_PackagesPerPallet2.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_PackagesPerPallet2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_PackagesPerPallet2.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_PackagesPerPallet2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_PackagesPerPallet2.Properties.Mask.EditMask = "n0";
            this.spinEdit_PackagesPerPallet2.Size = new System.Drawing.Size(105, 20);
            this.spinEdit_PackagesPerPallet2.StyleController = this.layoutControlProductInfo;
            this.spinEdit_PackagesPerPallet2.TabIndex = 18;
            // 
            // spinEdit_PackagesPerPallet
            // 
            this.spinEdit_PackagesPerPallet.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_PackagesPerPallet.Location = new System.Drawing.Point(441, 134);
            this.spinEdit_PackagesPerPallet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_PackagesPerPallet.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_PackagesPerPallet.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_PackagesPerPallet.Name = "spinEdit_PackagesPerPallet";
            this.spinEdit_PackagesPerPallet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_PackagesPerPallet.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_PackagesPerPallet.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_PackagesPerPallet.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_PackagesPerPallet.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_PackagesPerPallet.Properties.Mask.EditMask = "n0";
            this.spinEdit_PackagesPerPallet.Size = new System.Drawing.Size(118, 20);
            this.spinEdit_PackagesPerPallet.StyleController = this.layoutControlProductInfo;
            this.spinEdit_PackagesPerPallet.TabIndex = 17;
            // 
            // lookUpEdit_Packages
            // 
            this.lookUpEdit_Packages.Location = new System.Drawing.Point(896, 6);
            this.lookUpEdit_Packages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_Packages.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_Packages.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_Packages.Name = "lookUpEdit_Packages";
            this.lookUpEdit_Packages.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_Packages.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_Packages.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Packages", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_Packages.Properties.DisplayMember = "Code";
            this.lookUpEdit_Packages.Properties.NullText = "";
            this.lookUpEdit_Packages.Properties.ValueMember = "Code";
            this.lookUpEdit_Packages.Size = new System.Drawing.Size(175, 20);
            this.lookUpEdit_Packages.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_Packages.TabIndex = 16;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.lookUpEdit_Packages, conditionValidationRule2);
            this.lookUpEdit_Packages.EditValueChanged += new System.EventHandler(this.lookUpEdit_Packages_EditValueChanged);
            this.lookUpEdit_Packages.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lookUpEdit_Packages_EditValueChanging);
            // 
            // spinEdit_GrossWeightPerPackage
            // 
            this.spinEdit_GrossWeightPerPackage.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_GrossWeightPerPackage.Location = new System.Drawing.Point(360, 204);
            this.spinEdit_GrossWeightPerPackage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_GrossWeightPerPackage.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_GrossWeightPerPackage.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_GrossWeightPerPackage.Name = "spinEdit_GrossWeightPerPackage";
            this.spinEdit_GrossWeightPerPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_GrossWeightPerPackage.Properties.DisplayFormat.FormatString = "n3";
            this.spinEdit_GrossWeightPerPackage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_GrossWeightPerPackage.Properties.EditFormat.FormatString = "n3";
            this.spinEdit_GrossWeightPerPackage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_GrossWeightPerPackage.Properties.Mask.EditMask = "n3";
            this.spinEdit_GrossWeightPerPackage.Size = new System.Drawing.Size(124, 20);
            this.spinEdit_GrossWeightPerPackage.StyleController = this.layoutControlProductInfo;
            this.spinEdit_GrossWeightPerPackage.TabIndex = 15;
            // 
            // spinEdit_WeightPerPackage
            // 
            this.spinEdit_WeightPerPackage.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_WeightPerPackage.Location = new System.Drawing.Point(444, 240);
            this.spinEdit_WeightPerPackage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_WeightPerPackage.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_WeightPerPackage.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_WeightPerPackage.Name = "spinEdit_WeightPerPackage";
            this.spinEdit_WeightPerPackage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinEdit_WeightPerPackage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.spinEdit_WeightPerPackage.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.spinEdit_WeightPerPackage.Properties.Appearance.Options.UseFont = true;
            this.spinEdit_WeightPerPackage.Properties.Appearance.Options.UseForeColor = true;
            this.spinEdit_WeightPerPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_WeightPerPackage.Properties.DisplayFormat.FormatString = "n3";
            this.spinEdit_WeightPerPackage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_WeightPerPackage.Properties.EditFormat.FormatString = "n3";
            this.spinEdit_WeightPerPackage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_WeightPerPackage.Properties.Mask.EditMask = "n3";
            this.spinEdit_WeightPerPackage.Properties.ReadOnly = true;
            this.spinEdit_WeightPerPackage.Size = new System.Drawing.Size(228, 20);
            this.spinEdit_WeightPerPackage.StyleController = this.layoutControlProductInfo;
            this.spinEdit_WeightPerPackage.TabIndex = 14;
            // 
            // spinEdit_WarningDaysBeforeExpiry
            // 
            this.spinEdit_WarningDaysBeforeExpiry.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_WarningDaysBeforeExpiry.Location = new System.Drawing.Point(234, 402);
            this.spinEdit_WarningDaysBeforeExpiry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_WarningDaysBeforeExpiry.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_WarningDaysBeforeExpiry.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_WarningDaysBeforeExpiry.Name = "spinEdit_WarningDaysBeforeExpiry";
            this.spinEdit_WarningDaysBeforeExpiry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_WarningDaysBeforeExpiry.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_WarningDaysBeforeExpiry.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_WarningDaysBeforeExpiry.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_WarningDaysBeforeExpiry.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_WarningDaysBeforeExpiry.Properties.Mask.EditMask = "n0";
            this.spinEdit_WarningDaysBeforeExpiry.Properties.MaxValue = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.spinEdit_WarningDaysBeforeExpiry.Size = new System.Drawing.Size(144, 20);
            this.spinEdit_WarningDaysBeforeExpiry.StyleController = this.layoutControlProductInfo;
            this.spinEdit_WarningDaysBeforeExpiry.TabIndex = 13;
            // 
            // spinEdit_TemperatureRequire
            // 
            this.spinEdit_TemperatureRequire.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_TemperatureRequire.Location = new System.Drawing.Point(151, 134);
            this.spinEdit_TemperatureRequire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_TemperatureRequire.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_TemperatureRequire.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_TemperatureRequire.Name = "spinEdit_TemperatureRequire";
            this.spinEdit_TemperatureRequire.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinEdit_TemperatureRequire.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_TemperatureRequire.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit_TemperatureRequire.Properties.MinValue = new decimal(new int[] {
            25,
            0,
            0,
            -2147483648});
            this.spinEdit_TemperatureRequire.Size = new System.Drawing.Size(113, 20);
            this.spinEdit_TemperatureRequire.StyleController = this.layoutControlProductInfo;
            this.spinEdit_TemperatureRequire.TabIndex = 12;
            // 
            // lookUpEdit_ProductCategoryID
            // 
            this.lookUpEdit_ProductCategoryID.Location = new System.Drawing.Point(552, 470);
            this.lookUpEdit_ProductCategoryID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_ProductCategoryID.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_ProductCategoryID.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_ProductCategoryID.Name = "lookUpEdit_ProductCategoryID";
            this.lookUpEdit_ProductCategoryID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_ProductCategoryID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_ProductCategoryID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductCategoryDescription", "Product Category", 500, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_ProductCategoryID.Properties.DisplayMember = "ProductCategoryDescription";
            this.lookUpEdit_ProductCategoryID.Properties.NullText = "";
            this.lookUpEdit_ProductCategoryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_ProductCategoryID.Properties.ValueMember = "ProductCategoryID";
            this.lookUpEdit_ProductCategoryID.Size = new System.Drawing.Size(104, 20);
            this.lookUpEdit_ProductCategoryID.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_ProductCategoryID.TabIndex = 11;
            // 
            // txtEdit_Origin
            // 
            this.txtEdit_Origin.Location = new System.Drawing.Point(552, 436);
            this.txtEdit_Origin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_Origin.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_Origin.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_Origin.Name = "txtEdit_Origin";
            this.txtEdit_Origin.Size = new System.Drawing.Size(104, 20);
            this.txtEdit_Origin.StyleController = this.layoutControlProductInfo;
            this.txtEdit_Origin.TabIndex = 10;
            // 
            // txtEdit_ProductNameVN
            // 
            this.txtEdit_ProductNameVN.Location = new System.Drawing.Point(151, 100);
            this.txtEdit_ProductNameVN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_ProductNameVN.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductNameVN.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductNameVN.Name = "txtEdit_ProductNameVN";
            this.txtEdit_ProductNameVN.Properties.MaxLength = 40;
            this.txtEdit_ProductNameVN.Size = new System.Drawing.Size(297, 20);
            this.txtEdit_ProductNameVN.StyleController = this.layoutControlProductInfo;
            this.txtEdit_ProductNameVN.TabIndex = 9;
            compareAgainstControlValidationRule1.ErrorText = "This value is not valid";
            compareAgainstControlValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider.SetValidationRule(this.txtEdit_ProductNameVN, compareAgainstControlValidationRule1);
            // 
            // txtEdit_ProductName
            // 
            this.txtEdit_ProductName.Location = new System.Drawing.Point(151, 66);
            this.txtEdit_ProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_ProductName.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductName.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductName.Name = "txtEdit_ProductName";
            this.txtEdit_ProductName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtEdit_ProductName.Properties.Appearance.Options.UseFont = true;
            this.txtEdit_ProductName.Properties.MaxLength = 100;
            this.txtEdit_ProductName.Size = new System.Drawing.Size(521, 20);
            this.txtEdit_ProductName.StyleController = this.layoutControlProductInfo;
            this.txtEdit_ProductName.TabIndex = 8;
            this.txtEdit_ProductName.ToolTip = "Max lenght 100 characters";
            // 
            // txtEdit_ProductNumber
            // 
            this.txtEdit_ProductNumber.Location = new System.Drawing.Point(246, -2);
            this.txtEdit_ProductNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_ProductNumber.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductNumber.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_ProductNumber.Name = "txtEdit_ProductNumber";
            this.txtEdit_ProductNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtEdit_ProductNumber.Properties.Appearance.Options.UseFont = true;
            this.txtEdit_ProductNumber.Properties.MaxLength = 26;
            this.txtEdit_ProductNumber.Size = new System.Drawing.Size(129, 20);
            this.txtEdit_ProductNumber.StyleController = this.layoutControlProductInfo;
            this.txtEdit_ProductNumber.TabIndex = 7;
            this.txtEdit_ProductNumber.ToolTip = "Max lenght 26 characters";
            // 
            // txtEdit_InitialLabel
            // 
            this.txtEdit_InitialLabel.Location = new System.Drawing.Point(151, -2);
            this.txtEdit_InitialLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_InitialLabel.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_InitialLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_InitialLabel.Name = "txtEdit_InitialLabel";
            this.txtEdit_InitialLabel.Properties.ReadOnly = true;
            this.txtEdit_InitialLabel.Size = new System.Drawing.Size(87, 20);
            this.txtEdit_InitialLabel.StyleController = this.layoutControlProductInfo;
            this.txtEdit_InitialLabel.TabIndex = 6;
            this.txtEdit_InitialLabel.TabStop = false;
            // 
            // txtEdit_CustomerName
            // 
            this.txtEdit_CustomerName.Enabled = false;
            this.txtEdit_CustomerName.Location = new System.Drawing.Point(267, -36);
            this.txtEdit_CustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_CustomerName.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_CustomerName.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_CustomerName.Name = "txtEdit_CustomerName";
            this.txtEdit_CustomerName.Properties.ReadOnly = true;
            this.txtEdit_CustomerName.Size = new System.Drawing.Size(405, 20);
            this.txtEdit_CustomerName.StyleController = this.layoutControlProductInfo;
            this.txtEdit_CustomerName.TabIndex = 5;
            // 
            // lookUpEdit_CustomerID
            // 
            this.lookUpEdit_CustomerID.Location = new System.Drawing.Point(151, -36);
            this.lookUpEdit_CustomerID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_CustomerID.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_CustomerID.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_CustomerID.Name = "lookUpEdit_CustomerID";
            this.lookUpEdit_CustomerID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_CustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_CustomerID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerNumber", "Customer Number", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerName", "Customer Name", 500, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Initial", "Initial", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerMainID", "Name4", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_CustomerID.Properties.DisplayMember = "CustomerNumber";
            this.lookUpEdit_CustomerID.Properties.ImmediatePopup = true;
            this.lookUpEdit_CustomerID.Properties.NullText = "";
            this.lookUpEdit_CustomerID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lookUpEdit_CustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit_CustomerID.Properties.ValueMember = "CustomerID";
            this.lookUpEdit_CustomerID.Size = new System.Drawing.Size(108, 20);
            this.lookUpEdit_CustomerID.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_CustomerID.TabIndex = 4;
            // 
            // radGroup_PickingMethod
            // 
            this.radGroup_PickingMethod.Location = new System.Drawing.Point(151, 310);
            this.radGroup_PickingMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGroup_PickingMethod.MaximumSize = new System.Drawing.Size(0, 33);
            this.radGroup_PickingMethod.MinimumSize = new System.Drawing.Size(200, 24);
            this.radGroup_PickingMethod.Name = "radGroup_PickingMethod";
            this.radGroup_PickingMethod.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.radGroup_PickingMethod.Properties.Appearance.Options.UseBackColor = true;
            this.radGroup_PickingMethod.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Normal"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(-1, "Pick / Replenish")});
            this.radGroup_PickingMethod.Size = new System.Drawing.Size(243, 33);
            this.radGroup_PickingMethod.StyleController = this.layoutControlProductInfo;
            this.radGroup_PickingMethod.TabIndex = 37;
            // 
            // txtEdit_Remark
            // 
            this.txtEdit_Remark.Enabled = false;
            this.txtEdit_Remark.Location = new System.Drawing.Point(151, 559);
            this.txtEdit_Remark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_Remark.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_Remark.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_Remark.Name = "txtEdit_Remark";
            this.txtEdit_Remark.Properties.ReadOnly = true;
            this.txtEdit_Remark.Size = new System.Drawing.Size(521, 20);
            this.txtEdit_Remark.StyleController = this.layoutControlProductInfo;
            this.txtEdit_Remark.TabIndex = 39;
            // 
            // txtEdit_CreatedBy
            // 
            this.txtEdit_CreatedBy.Location = new System.Drawing.Point(101, 508);
            this.txtEdit_CreatedBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdit_CreatedBy.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_CreatedBy.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtEdit_CreatedBy.Name = "txtEdit_CreatedBy";
            this.txtEdit_CreatedBy.Properties.AllowFocused = false;
            this.txtEdit_CreatedBy.Properties.ReadOnly = true;
            this.txtEdit_CreatedBy.Size = new System.Drawing.Size(79, 20);
            this.txtEdit_CreatedBy.StyleController = this.layoutControlProductInfo;
            this.txtEdit_CreatedBy.TabIndex = 40;
            this.txtEdit_CreatedBy.TabStop = false;
            // 
            // dateEdit_CreatedTime
            // 
            this.dateEdit_CreatedTime.EditValue = null;
            this.dateEdit_CreatedTime.Location = new System.Drawing.Point(188, 508);
            this.dateEdit_CreatedTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEdit_CreatedTime.MaximumSize = new System.Drawing.Size(0, 20);
            this.dateEdit_CreatedTime.MinimumSize = new System.Drawing.Size(0, 20);
            this.dateEdit_CreatedTime.Name = "dateEdit_CreatedTime";
            this.dateEdit_CreatedTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.dateEdit_CreatedTime.Properties.CalendarTimeProperties.AllowFocused = false;
            this.dateEdit_CreatedTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_CreatedTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dateEdit_CreatedTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_CreatedTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.dateEdit_CreatedTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_CreatedTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.dateEdit_CreatedTime.Properties.ReadOnly = true;
            this.dateEdit_CreatedTime.Size = new System.Drawing.Size(190, 20);
            this.dateEdit_CreatedTime.StyleController = this.layoutControlProductInfo;
            this.dateEdit_CreatedTime.TabIndex = 41;
            this.dateEdit_CreatedTime.TabStop = false;
            // 
            // lookUpEdit_PickingLocation
            // 
            this.lookUpEdit_PickingLocation.Location = new System.Drawing.Point(402, 310);
            this.lookUpEdit_PickingLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit_PickingLocation.MaximumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_PickingLocation.MinimumSize = new System.Drawing.Size(0, 20);
            this.lookUpEdit_PickingLocation.Name = "lookUpEdit_PickingLocation";
            this.lookUpEdit_PickingLocation.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEdit_PickingLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_PickingLocation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Z", "Location", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumber", "Location Number", 167, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit_PickingLocation.Properties.DisplayMember = "Z";
            this.lookUpEdit_PickingLocation.Properties.NullText = "";
            this.lookUpEdit_PickingLocation.Properties.ValueMember = "LocationID";
            this.lookUpEdit_PickingLocation.Size = new System.Drawing.Size(270, 20);
            this.lookUpEdit_PickingLocation.StyleController = this.layoutControlProductInfo;
            this.lookUpEdit_PickingLocation.TabIndex = 38;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(396, -2);
            this.txtProductID.MaximumSize = new System.Drawing.Size(0, 20);
            this.txtProductID.MenuManager = this.rbcbase;
            this.txtProductID.MinimumSize = new System.Drawing.Size(0, 20);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProductID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtProductID.Properties.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(276, 20);
            this.txtProductID.StyleController = this.layoutControlProductInfo;
            this.txtProductID.TabIndex = 44;
            // 
            // lke_WM_Products
            // 
            this.lke_WM_Products.Location = new System.Drawing.Point(129, 474);
            this.lke_WM_Products.MaximumSize = new System.Drawing.Size(0, 20);
            this.lke_WM_Products.MinimumSize = new System.Drawing.Size(0, 20);
            this.lke_WM_Products.Name = "lke_WM_Products";
            this.lke_WM_Products.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_WM_Products.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_WM_Products.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductID", "Product", 167, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Product", "Product", 250, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9", 1000, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WeightPerPackage", "WeightPerPackage", 100, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Discontinue", "Name18", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tmpRemainQuantity", "tmpRemainQuantity", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_WM_Products.Properties.DisplayMember = "Product";
            this.lke_WM_Products.Properties.DropDownRows = 20;
            this.lke_WM_Products.Properties.ImmediatePopup = true;
            this.lke_WM_Products.Properties.NullText = "";
            this.lke_WM_Products.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lke_WM_Products.Properties.PopupFormMinSize = new System.Drawing.Size(849, 0);
            this.lke_WM_Products.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lke_WM_Products.Properties.PopupWidth = 749;
            this.lke_WM_Products.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.lke_WM_Products.Properties.ShowFooter = false;
            this.lke_WM_Products.Properties.ShowHeader = false;
            this.lke_WM_Products.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lke_WM_Products.Properties.ValueMember = "ProductID";
            this.lke_WM_Products.Size = new System.Drawing.Size(249, 20);
            this.lke_WM_Products.StyleController = this.layoutControlProductInfo;
            this.lke_WM_Products.TabIndex = 2;
            // 
            // spinEdit_SafetyStock
            // 
            this.spinEdit_SafetyStock.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_SafetyStock.Location = new System.Drawing.Point(133, 438);
            this.spinEdit_SafetyStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_SafetyStock.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_SafetyStock.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_SafetyStock.Name = "spinEdit_SafetyStock";
            this.spinEdit_SafetyStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_SafetyStock.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit_SafetyStock.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_SafetyStock.Properties.EditFormat.FormatString = "n0";
            this.spinEdit_SafetyStock.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_SafetyStock.Properties.Mask.EditMask = "n0";
            this.spinEdit_SafetyStock.Size = new System.Drawing.Size(84, 20);
            this.spinEdit_SafetyStock.StyleController = this.layoutControlProductInfo;
            this.spinEdit_SafetyStock.TabIndex = 19;
            // 
            // spPcs
            // 
            this.spPcs.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPcs.Location = new System.Drawing.Point(896, 74);
            this.spPcs.MaximumSize = new System.Drawing.Size(0, 20);
            this.spPcs.MenuManager = this.rbcbase;
            this.spPcs.MinimumSize = new System.Drawing.Size(0, 20);
            this.spPcs.Name = "spPcs";
            this.spPcs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spPcs.Properties.DisplayFormat.FormatString = "n0";
            this.spPcs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spPcs.Properties.EditFormat.FormatString = "n0";
            this.spPcs.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spPcs.Properties.Mask.EditMask = "n0";
            this.spPcs.Properties.MaxValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spPcs.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPcs.Size = new System.Drawing.Size(175, 20);
            this.spPcs.StyleController = this.layoutControlProductInfo;
            this.spPcs.TabIndex = 46;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider.SetValidationRule(this.spPcs, conditionValidationRule3);
            // 
            // spinEdit_SelfLifeDays
            // 
            this.spinEdit_SelfLifeDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_SelfLifeDays.Location = new System.Drawing.Point(299, 438);
            this.spinEdit_SelfLifeDays.MenuManager = this.rbcbase;
            this.spinEdit_SelfLifeDays.Name = "spinEdit_SelfLifeDays";
            this.spinEdit_SelfLifeDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_SelfLifeDays.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEdit_SelfLifeDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinEdit_SelfLifeDays.Size = new System.Drawing.Size(79, 24);
            this.spinEdit_SelfLifeDays.StyleController = this.layoutControlProductInfo;
            this.spinEdit_SelfLifeDays.TabIndex = 65;
            // 
            // lke_PackageTypes
            // 
            this.lke_PackageTypes.Location = new System.Drawing.Point(151, 170);
            this.lke_PackageTypes.MenuManager = this.rbcbase;
            this.lke_PackageTypes.Name = "lke_PackageTypes";
            this.lke_PackageTypes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_PackageTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_PackageTypes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PackageTypeID", "PackageTypeID", 25, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PackageName", "Package Name", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value1", "Value1", 25, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value2", "Value2", 25, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_PackageTypes.Properties.NullText = "";
            this.lke_PackageTypes.Size = new System.Drawing.Size(152, 22);
            this.lke_PackageTypes.StyleController = this.layoutControlProductInfo;
            this.lke_PackageTypes.TabIndex = 66;
            this.lke_PackageTypes.EditValueChanged += new System.EventHandler(this.lke_PackageTypes_EditValueChanged_1);
            // 
            // spinEdit_Net
            // 
            this.spinEdit_Net.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Net.Location = new System.Drawing.Point(149, 204);
            this.spinEdit_Net.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spinEdit_Net.MaximumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_Net.MinimumSize = new System.Drawing.Size(0, 20);
            this.spinEdit_Net.Name = "spinEdit_Net";
            this.spinEdit_Net.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.spinEdit_Net.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_Net.Properties.DisplayFormat.FormatString = "n3";
            this.spinEdit_Net.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_Net.Properties.EditFormat.FormatString = "n3";
            this.spinEdit_Net.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_Net.Properties.Mask.EditMask = "n3";
            this.spinEdit_Net.Properties.ReadOnly = true;
            this.spinEdit_Net.Size = new System.Drawing.Size(154, 20);
            this.spinEdit_Net.StyleController = this.layoutControlProductInfo;
            this.spinEdit_Net.TabIndex = 14;
            this.spinEdit_Net.EditValueChanged += new System.EventHandler(this.spinEdit_Net_EditValueChanged);
            // 
            // chkEdit_IsGetNet
            // 
            this.chkEdit_IsGetNet.Location = new System.Drawing.Point(224, 240);
            this.chkEdit_IsGetNet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEdit_IsGetNet.MaximumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsGetNet.MinimumSize = new System.Drawing.Size(0, 20);
            this.chkEdit_IsGetNet.Name = "chkEdit_IsGetNet";
            this.chkEdit_IsGetNet.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEdit_IsGetNet.Properties.Appearance.Options.UseBackColor = true;
            this.chkEdit_IsGetNet.Properties.Caption = "";
            this.chkEdit_IsGetNet.Size = new System.Drawing.Size(79, 20);
            this.chkEdit_IsGetNet.StyleController = this.layoutControlProductInfo;
            toolTipItem1.Appearance.Options.UseImage = true;
            toolTipItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem1.Text = "Có tick thì xác định sản phẩm được tính theo trọng lượng NET\r\nkhông tick thì xác " +
    "định sản phẩm được tính theo Gross";
            superToolTip1.Items.Add(toolTipItem1);
            this.chkEdit_IsGetNet.SuperTip = superToolTip1;
            this.chkEdit_IsGetNet.TabIndex = 22;
            this.chkEdit_IsGetNet.CheckedChanged += new System.EventHandler(this.chkEdit_IsGetNet_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.layoutControlItem25,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem34,
            this.layoutControlItemPickingLocation,
            this.layoutControlItem26,
            this.layoutControlItem33,
            this.layoutControlItem35,
            this.layoutControlItem39,
            this.layoutControlItem40,
            this.layoutControlItem41,
            this.layoutControlItem42,
            this.layoutControlItem43,
            this.layoutControlItem45,
            this.layoutControlCancelButton,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem12,
            this.layoutControlItem19,
            this.layoutControlItem23,
            this.layoutControlItem36,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem18,
            this.layoutControlGroup2,
            this.layoutControlGroup4,
            this.layoutControlGroup3,
            this.layoutControlItem44,
            this.layoutControlItem46,
            this.emptySpaceItem5,
            this.layoutControlItem27,
            this.layoutControlItem48,
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.layoutControlItem52,
            this.emptySpaceItem6,
            this.layoutControlItem11,
            this.layoutControlItem53,
            this.layoutControlItem55});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1530, 731);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit_CustomerID;
            this.layoutControlItem1.Location = new System.Drawing.Point(11, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(249, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem1.Text = "Customer *";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdit_CustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(413, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem2.Text = "Customer Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEdit_InitialLabel;
            this.layoutControlItem3.Location = new System.Drawing.Point(11, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(228, 34);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem3.Text = "Product Code *";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEdit_ProductNumber;
            this.layoutControlItem4.Location = new System.Drawing.Point(239, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(137, 34);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem4.Text = "Product Code";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtEdit_ProductName;
            this.layoutControlItem5.Location = new System.Drawing.Point(11, 102);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(662, 34);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem5.Text = "Product Name *";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtEdit_ProductNameVN;
            this.layoutControlItem6.Location = new System.Drawing.Point(11, 136);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(438, 34);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem6.Text = "Vietnamese Name";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.spinEdit_TemperatureRequire;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem9.Location = new System.Drawing.Point(11, 170);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(254, 36);
            this.layoutControlItem9.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem9.Text = "Temperature *";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(11, 594);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(1, 1);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(384, 1);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.txtProductID;
            this.layoutControlItem25.Location = new System.Drawing.Point(389, 34);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(284, 34);
            this.layoutControlItem25.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.lookUpEdit_HomeRoom1;
            this.layoutControlItem21.Location = new System.Drawing.Point(11, 312);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(267, 34);
            this.layoutControlItem21.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem21.Text = "Home Room";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.lookUpEdit_HomeRoom2;
            this.layoutControlItem22.Location = new System.Drawing.Point(278, 312);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 5, 5);
            this.layoutControlItem22.Size = new System.Drawing.Size(117, 34);
            this.layoutControlItem22.Text = "Home Room 2";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.radGroup_PickingMethod;
            this.layoutControlItem34.CustomizationFormText = "Picking Method";
            this.layoutControlItem34.Location = new System.Drawing.Point(11, 346);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(384, 50);
            this.layoutControlItem34.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem34.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem34.Text = "Picking Method";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItemPickingLocation
            // 
            this.layoutControlItemPickingLocation.Control = this.lookUpEdit_PickingLocation;
            this.layoutControlItemPickingLocation.CustomizationFormText = "Pick / Replenish";
            this.layoutControlItemPickingLocation.Location = new System.Drawing.Point(395, 346);
            this.layoutControlItemPickingLocation.Name = "layoutControlItemPickingLocation";
            this.layoutControlItemPickingLocation.Size = new System.Drawing.Size(278, 50);
            this.layoutControlItemPickingLocation.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItemPickingLocation.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemPickingLocation.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnClose;
            this.layoutControlItem26.Location = new System.Drawing.Point(1391, 672);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem26.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.btnNew;
            this.layoutControlItem33.Location = new System.Drawing.Point(144, 672);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem33.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.btnPalletInfo;
            this.layoutControlItem35.Location = new System.Drawing.Point(1258, 672);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem35.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.btnUpdateOrder;
            this.layoutControlItem39.Location = new System.Drawing.Point(1125, 672);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem39.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem39.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem39.TextVisible = false;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.btnProductList;
            this.layoutControlItem40.Location = new System.Drawing.Point(992, 672);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem40.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem40.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem40.TextVisible = false;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.btnDelete;
            this.layoutControlItem41.Location = new System.Drawing.Point(721, 672);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem41.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem41.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem41.TextVisible = false;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.btnEdit;
            this.layoutControlItem42.Location = new System.Drawing.Point(455, 672);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem42.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextVisible = false;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.btnCopy;
            this.layoutControlItem43.Location = new System.Drawing.Point(277, 672);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem43.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem43.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem43.TextVisible = false;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.btnStop;
            this.layoutControlItem45.Location = new System.Drawing.Point(11, 672);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(133, 53);
            this.layoutControlItem45.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem45.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem45.TextVisible = false;
            // 
            // layoutControlCancelButton
            // 
            this.layoutControlCancelButton.Control = this.btnCancel;
            this.layoutControlCancelButton.Location = new System.Drawing.Point(588, 672);
            this.layoutControlCancelButton.Name = "layoutControlCancelButton";
            this.layoutControlCancelButton.Size = new System.Drawing.Size(133, 53);
            this.layoutControlCancelButton.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlCancelButton.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlCancelButton.TextVisible = false;
            this.layoutControlCancelButton.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(410, 672);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(45, 53);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(854, 672);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(138, 53);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(376, 34);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(13, 34);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.spinEdit_GrossWeightPerPackage;
            this.layoutControlItem12.Location = new System.Drawing.Point(304, 240);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(181, 36);
            this.layoutControlItem12.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem12.Text = "Gross ";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(36, 16);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.chkEdit_IsAllowLocationChange;
            this.layoutControlItem19.Location = new System.Drawing.Point(395, 312);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(278, 34);
            this.layoutControlItem19.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem19.Text = "Change Home Room Allowed";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.chkEdit_Discontinue;
            this.layoutControlItem23.Location = new System.Drawing.Point(11, 629);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(662, 33);
            this.layoutControlItem23.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem23.Text = "Stop Product";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(73, 16);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.txtEdit_Remark;
            this.layoutControlItem36.CustomizationFormText = "Remark";
            this.layoutControlItem36.Location = new System.Drawing.Point(11, 595);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(662, 34);
            this.layoutControlItem36.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem36.Text = "Remark";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.spinEdit_PackagesPerPallet;
            this.layoutControlItem14.Location = new System.Drawing.Point(265, 170);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(295, 36);
            this.layoutControlItem14.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem14.Text = "Packages per Pallet (L/H) *";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(156, 16);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.spinEdit_PackagesPerPallet2;
            this.layoutControlItem15.Location = new System.Drawing.Point(560, 170);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(113, 36);
            this.layoutControlItem15.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.spinEdit_CBM;
            this.layoutControlItem18.Location = new System.Drawing.Point(485, 240);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(188, 36);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem18.Text = "CBM";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(25, 16);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20,
            this.layoutControlItem16,
            this.layoutControlItem30,
            this.layoutControlItem31,
            this.layoutControlItem13,
            this.layoutControlItemPackageList,
            this.layoutControlItem32,
            this.layoutControlItem49});
            this.layoutControlGroup2.Location = new System.Drawing.Point(673, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(415, 662);
            this.layoutControlGroup2.Text = "Unit of Measurement";
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.chkEdit_IsWeightingRequire;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 140);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(383, 33);
            this.layoutControlItem20.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem20.Text = "Weighting Required";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.spinEdit_Inners;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(383, 36);
            this.layoutControlItem16.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem16.Text = "Inners (Qty pcs per Master Unit) *";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.spPcs;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(383, 36);
            this.layoutControlItem30.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem30.Text = "Pcs (Convert Master to ERP) *";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.txtERP;
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(310, 34);
            this.layoutControlItem31.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem31.Text = "Customer ERP Unit";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.lookUpEdit_Packages;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(383, 34);
            this.layoutControlItem13.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem13.Text = "Packages Master Unit";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItemPackageList
            // 
            this.layoutControlItemPackageList.Control = this.grcProductPackages;
            this.layoutControlItemPackageList.Location = new System.Drawing.Point(0, 173);
            this.layoutControlItemPackageList.Name = "layoutControlItemPackageList";
            this.layoutControlItemPackageList.Size = new System.Drawing.Size(383, 231);
            this.layoutControlItemPackageList.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItemPackageList.Text = "UOM Sales";
            this.layoutControlItemPackageList.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemPackageList.TextSize = new System.Drawing.Size(196, 16);
            this.layoutControlItemPackageList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.btnShowERPUOMList;
            this.layoutControlItem32.Location = new System.Drawing.Point(310, 34);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(73, 34);
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.grdHeSoQuyDoi;
            this.layoutControlItem49.Location = new System.Drawing.Point(0, 404);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(383, 200);
            this.layoutControlItem49.Text = "Hệ Số Quy Đổi";
            this.layoutControlItem49.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem49.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem49.TextSize = new System.Drawing.Size(184, 17);
            this.layoutControlItem49.TextToControlDistance = 5;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10,
            this.layoutControlItem29,
            this.layoutControlItem28,
            this.layoutControlItem37,
            this.layoutControlItem38,
            this.layoutControlItem47});
            this.layoutControlGroup4.Location = new System.Drawing.Point(11, 396);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(384, 198);
            this.layoutControlGroup4.Text = "Stock Management";
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.spinEdit_WarningDaysBeforeExpiry;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(352, 36);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem10.Text = "Warning days before Expiry";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(196, 16);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.spinEdit_SafetyStock;
            this.layoutControlItem29.CustomizationFormText = "Qty Inners (Labels)";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(191, 36);
            this.layoutControlItem29.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem29.Text = "Safety Stock Qty";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(94, 16);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.lke_WM_Products;
            this.layoutControlItem28.CustomizationFormText = "Product";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(352, 34);
            this.layoutControlItem28.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem28.Text = "Product Main ID";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(90, 16);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.txtEdit_CreatedBy;
            this.layoutControlItem37.CustomizationFormText = "Created By";
            this.layoutControlItem37.Location = new System.Drawing.Point(0, 106);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(154, 34);
            this.layoutControlItem37.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem37.Text = "Created By";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(62, 16);
            this.layoutControlItem37.TextToControlDistance = 5;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.dateEdit_CreatedTime;
            this.layoutControlItem38.CustomizationFormText = "Created Time";
            this.layoutControlItem38.Location = new System.Drawing.Point(154, 106);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(198, 34);
            this.layoutControlItem38.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem38.Text = "Created Time";
            this.layoutControlItem38.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem38.TextVisible = false;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.spinEdit_SelfLifeDays;
            this.layoutControlItem47.Location = new System.Drawing.Point(191, 36);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(161, 36);
            this.layoutControlItem47.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem47.Text = "SelfLifeDays";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(69, 16);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem24});
            this.layoutControlGroup3.Location = new System.Drawing.Point(395, 396);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(278, 199);
            this.layoutControlGroup3.Text = "Classifications";
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.lookUpEdit_CustomerProductGroups;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(246, 34);
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem17.Text = "Category";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(129, 16);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtEdit_Origin;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(246, 34);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem7.Text = "Origin";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(129, 16);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lookUpEdit_ProductCategoryID;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(246, 34);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem8.Text = "Product group";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(129, 16);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.lookUpEdit_WAREHOUSE_NO;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(246, 39);
            this.layoutControlItem24.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem24.Text = "Warehouse No (MM)";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(129, 16);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.imgSld_Products;
            this.layoutControlItem44.Location = new System.Drawing.Point(1088, 0);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(436, 662);
            this.layoutControlItem44.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem44.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem44.TextVisible = false;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.labelControlStopStrip;
            this.layoutControlItem46.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(11, 725);
            this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem46.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(11, 662);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(1513, 10);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txtEdit_GTIN;
            this.layoutControlItem27.Location = new System.Drawing.Point(449, 136);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(224, 34);
            this.layoutControlItem27.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 3, 3);
            this.layoutControlItem27.Text = "GTIN";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(28, 16);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.lke_PackageTypes;
            this.layoutControlItem48.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem48.Location = new System.Drawing.Point(11, 206);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(293, 34);
            this.layoutControlItem48.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem48.Text = "Package Type";
            this.layoutControlItem48.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.btnAddPackageType;
            this.layoutControlItem50.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem50.Location = new System.Drawing.Point(304, 206);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(55, 34);
            this.layoutControlItem50.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextToControlDistance = 0;
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.txtSubCode;
            this.layoutControlItem51.Location = new System.Drawing.Point(11, 68);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(662, 34);
            this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem51.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem51.Text = "Sub Code";
            this.layoutControlItem51.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem51.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem51.TextToControlDistance = 5;
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Control = this.txtBoxSize;
            this.layoutControlItem52.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem52.Location = new System.Drawing.Point(359, 206);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(226, 34);
            this.layoutControlItem52.Text = "Box Size";
            this.layoutControlItem52.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem52.TextSize = new System.Drawing.Size(48, 16);
            this.layoutControlItem52.TextToControlDistance = 5;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(585, 206);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(88, 34);
            this.emptySpaceItem6.Text = "(LxWxH)";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(196, 0);
            this.emptySpaceItem6.TextVisible = true;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.BackColor = System.Drawing.Color.Lime;
            this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic);
            this.layoutControlItem11.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.spinEdit_WeightPerPackage;
            this.layoutControlItem11.Location = new System.Drawing.Point(304, 276);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(369, 36);
            this.layoutControlItem11.Spacing = new DevExpress.XtraLayout.Utils.Padding(9, 1, 3, 3);
            this.layoutControlItem11.Text = "Weight Per Package";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.spinEdit_Net;
            this.layoutControlItem53.CustomizationFormText = "Unit Weight - NET";
            this.layoutControlItem53.Location = new System.Drawing.Point(11, 240);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(293, 36);
            this.layoutControlItem53.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 1, 3, 3);
            this.layoutControlItem53.Text = "Unit Weight - NET";
            this.layoutControlItem53.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem53.TextSize = new System.Drawing.Size(120, 16);
            this.layoutControlItem53.TextToControlDistance = 5;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem55.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem55.Control = this.chkEdit_IsGetNet;
            this.layoutControlItem55.CustomizationFormText = "Is Get Net";
            this.layoutControlItem55.Location = new System.Drawing.Point(11, 276);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Size = new System.Drawing.Size(293, 36);
            this.layoutControlItem55.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 1, 3, 3);
            this.layoutControlItem55.Text = "Is get Net";
            this.layoutControlItem55.TextSize = new System.Drawing.Size(196, 16);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 16;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 17;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 18;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem9);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "ribbonPageGroup6";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 19;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 20;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "barButtonItem8";
            this.barButtonItem8.Id = 21;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 22;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btn_P_ProductList);
            this.ribbonPageGroup8.ItemLinks.Add(this.btn_P_UpdateOrder1);
            this.ribbonPageGroup8.ItemLinks.Add(this.btn_P_PalletInfor);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Task";
            // 
            // btn_P_ProductList
            // 
            this.btn_P_ProductList.Caption = "Product list";
            this.btn_P_ProductList.Id = 23;
            this.btn_P_ProductList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_ProductList.ImageOptions.SvgImage")));
            this.btn_P_ProductList.Name = "btn_P_ProductList";
            // 
            // btn_P_UpdateOrder1
            // 
            this.btn_P_UpdateOrder1.Caption = "Update Order";
            this.btn_P_UpdateOrder1.Id = 24;
            this.btn_P_UpdateOrder1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_P_UpdateOrder1.ImageOptions.Image")));
            this.btn_P_UpdateOrder1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_P_UpdateOrder1.ImageOptions.LargeImage")));
            this.btn_P_UpdateOrder1.Name = "btn_P_UpdateOrder1";
            // 
            // btn_P_PalletInfor
            // 
            this.btn_P_PalletInfor.Caption = "Pallet info";
            this.btn_P_PalletInfor.Id = 25;
            this.btn_P_PalletInfor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_PalletInfor.ImageOptions.SvgImage")));
            this.btn_P_PalletInfor.Name = "btn_P_PalletInfor";
            this.btn_P_PalletInfor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btn_P_Close
            // 
            this.btn_P_Close.Caption = "Close";
            this.btn_P_Close.Id = 26;
            this.btn_P_Close.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_P_Close.ImageOptions.LargeImage")));
            this.btn_P_Close.Name = "btn_P_Close";
            // 
            // btn_P_Cancel
            // 
            this.btn_P_Cancel.Caption = "Cancel";
            this.btn_P_Cancel.Id = 27;
            this.btn_P_Cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_Cancel.ImageOptions.SvgImage")));
            this.btn_P_Cancel.Name = "btn_P_Cancel";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup9.ItemLinks.Add(this.btn_P_Close);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "ribbonPageGroup9";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup10.ItemLinks.Add(this.btn_P_StopProduct);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "ribbonPageGroup10";
            // 
            // btn_P_StopProduct
            // 
            this.btn_P_StopProduct.Caption = "STOP";
            this.btn_P_StopProduct.Id = 28;
            this.btn_P_StopProduct.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_P_StopProduct.ImageOptions.SvgImage")));
            this.btn_P_StopProduct.Name = "btn_P_StopProduct";
            this.btn_P_StopProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_P_StopProduct_ItemClick);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.ToolTipController = this.defaultToolTipController1.DefaultController;
            // 
            // defaultToolTipController1
            // 
            // 
            // 
            // 
            this.defaultToolTipController1.DefaultController.AutoPopDelay = 10000;
            this.defaultToolTipController1.DefaultController.KeepWhileHovered = true;
            // 
            // frm_MSS_Products
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 730);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsFixHeightScreen = false;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1165, 506);
            this.Name = "frm_MSS_Products";
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "Product Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_MSS_Products_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.frm_MSS_Products_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_MSS_Products_KeyDown);
            this.Controls.SetChildIndex(this.rbcbase, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rbcbase)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlProductInfo)).EndInit();
            this.layoutControlProductInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHeSoQuyDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHeSoQuyDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_GTIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSld_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcProductPackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProductPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpi_lke_PackagesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtERP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_WAREHOUSE_NO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_Discontinue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_HomeRoom2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_HomeRoom1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsWeightingRequire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsAllowLocationChange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_CBM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_CustomerProductGroups.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Inners.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PackagesPerPallet2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PackagesPerPallet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Packages.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_GrossWeightPerPackage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_WeightPerPackage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_WarningDaysBeforeExpiry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TemperatureRequire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_ProductCategoryID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Origin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductNameVN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_ProductNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_InitialLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_CustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroup_PickingMethod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Remark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_CreatedTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_CreatedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_PickingLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_WM_Products.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SafetyStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPcs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SelfLifeDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_PackageTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Net.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEdit_IsGetNet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPickingLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPackageList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btn_P_New;
        private DevExpress.XtraBars.BarButtonItem btn_P_Copy;
        private DevExpress.XtraBars.BarButtonItem btn_P_Save;
        private DevExpress.XtraBars.BarButtonItem btn_P_Edit;
        private DevExpress.XtraBars.BarButtonItem btn_P_Delete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControlProductInfo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_WAREHOUSE_NO;
        private DevExpress.XtraEditors.CheckEdit chkEdit_Discontinue;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_HomeRoom2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_HomeRoom1;
        private DevExpress.XtraEditors.CheckEdit chkEdit_IsWeightingRequire;
        private DevExpress.XtraEditors.CheckEdit chkEdit_IsAllowLocationChange;
        private DevExpress.XtraEditors.SpinEdit spinEdit_CBM;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_CustomerProductGroups;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Inners;
        private DevExpress.XtraEditors.SpinEdit spinEdit_PackagesPerPallet2;
        private DevExpress.XtraEditors.SpinEdit spinEdit_PackagesPerPallet;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Packages;
        private DevExpress.XtraEditors.SpinEdit spinEdit_GrossWeightPerPackage;
        private DevExpress.XtraEditors.SpinEdit spinEdit_WeightPerPackage;
        private DevExpress.XtraEditors.SpinEdit spinEdit_WarningDaysBeforeExpiry;
        private DevExpress.XtraEditors.SpinEdit spinEdit_TemperatureRequire;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_ProductCategoryID;
        private DevExpress.XtraEditors.TextEdit txtEdit_Origin;
        private DevExpress.XtraEditors.TextEdit txtEdit_ProductNameVN;
        private DevExpress.XtraEditors.TextEdit txtEdit_ProductName;
        private DevExpress.XtraEditors.TextEdit txtEdit_ProductNumber;
        private DevExpress.XtraEditors.TextEdit txtEdit_InitialLabel;
        private DevExpress.XtraEditors.TextEdit txtEdit_CustomerName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_CustomerID;
        private DevExpress.XtraEditors.RadioGroup radGroup_PickingMethod;
        private DevExpress.XtraEditors.TextEdit txtEdit_Remark;
        private DevExpress.XtraEditors.TextEdit txtEdit_CreatedBy;
        private DevExpress.XtraEditors.DateEdit dateEdit_CreatedTime;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_PickingLocation;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpi_btn_Delete;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteColumn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPickingLocation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btn_P_ProductList;
        private DevExpress.XtraBars.BarButtonItem btn_P_UpdateOrder1;
        private DevExpress.XtraBars.BarButtonItem btn_P_PalletInfor;
        private DevExpress.XtraBars.BarButtonItem btn_P_Close;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btn_P_Cancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtProductID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraEditors.Controls.ImageSlider imgSld_Products;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraEditors.LookUpEdit lke_WM_Products;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraBars.BarButtonItem btn_P_StopProduct;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraEditors.SpinEdit spinEdit_SafetyStock;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraEditors.SpinEdit spPcs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraEditors.TextEdit txtERP;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraGrid.GridControl grcProductPackages;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProductPackage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnProductList;
        private DevExpress.XtraEditors.SimpleButton btnUpdateOrder;
        private DevExpress.XtraEditors.SimpleButton btnPalletInfo;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCancelButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPackageList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraEditors.SimpleButton btnShowERPUOMList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraEditors.LabelControl labelControlStopStrip;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_PackagesList;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.TextEdit txtEdit_GTIN;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraEditors.SpinEdit spinEdit_SelfLifeDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraGrid.GridControl grdHeSoQuyDoi;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHeSoQuyDoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpi_lke_DVT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LookUpEdit lke_PackageTypes;
        private DevExpress.XtraEditors.SimpleButton btnAddPackageType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DefaultToolTipController defaultToolTipController1;
        private DevExpress.XtraEditors.TextEdit txtSubCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraEditors.TextEdit txtBoxSize;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Net;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraEditors.CheckEdit chkEdit_IsGetNet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
    }
}