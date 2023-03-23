using Common.Controls;
using DA;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WarehouseManagement
{
    public partial class frm_WM_DialogFindStock : frmBaseForm
    {
        public frm_WM_DialogFindStock(int CustomerID, string Ref,int optionFiter)
        {
            InitializeComponent();
            LoadData(CustomerID,Ref, optionFiter);
        }
        private void InitColumn()
        {
            GridColumn colCustomerID = new GridColumn();
            colCustomerID.FieldName = "CustomerID";
            colCustomerID.Caption = "CustomerID";
            colCustomerID.Visible = true;


            GridColumn colCustomerNumber = new GridColumn();
            colCustomerNumber.FieldName = "CustomerNumber";
            colCustomerNumber.Caption = "CustomerNumber";
            colCustomerNumber.Visible = true;


            GridColumn colCustomerName = new GridColumn();
            colCustomerName.FieldName = "CustomerName";
            colCustomerName.Caption = "CustomerName";
            colCustomerName.Visible = true;

            GridColumn colProductName = new GridColumn();
            colProductName.FieldName = "ProductName";
            colProductName.Caption = "ProductName";
            colProductName.Visible = true;

            GridColumn colProductNumber = new GridColumn();
            colProductNumber.FieldName = "ProductNumber";
            colProductNumber.Caption = "ProductNumber";
            colProductNumber.Visible = true;

            GridColumn colWeightPerPackage = new GridColumn();
            colWeightPerPackage.FieldName = "WeightPerPackage";
            colWeightPerPackage.Caption = "WeightPerPackage";
            colWeightPerPackage.Visible = true;
            colWeightPerPackage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.None,"","Total:")
                    });

            GridColumn colSumOfCurrentQuantity = new GridColumn();
            colSumOfCurrentQuantity.FieldName = "SumOfCurrentQuantity";
            colSumOfCurrentQuantity.Caption = "SumOfCurrentQuantity";
            colSumOfCurrentQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"SumOfCurrentQuantity","")
                    });

            colSumOfCurrentQuantity.Visible = true;


            GridColumn colTotalPackages = new GridColumn();
            colTotalPackages.FieldName = "TotalPackages";
            colTotalPackages.Caption = "TotalPackages";
            colTotalPackages.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"TotalPackages","")
                    });
            colTotalPackages.Visible = true;

            GridColumn colCustomerRef = new GridColumn();
            colCustomerRef.FieldName = "CustomerRef";
            colCustomerRef.Caption = "CustomerRef";
            colCustomerRef.Visible = true;

            GridColumn colReceivingOrderNumber = new GridColumn();
            colReceivingOrderNumber.FieldName = "ReceivingOrderNumber";
            colReceivingOrderNumber.Caption = "ReceivingOrderNumber";
            colReceivingOrderNumber.Visible = true;



            GridColumn colReceivingOrderDate = new GridColumn();
            colReceivingOrderDate.FieldName = "ReceivingOrderDate";
            colReceivingOrderDate.Caption = "ReceivingOrderDate";
            colReceivingOrderDate.Visible = true;


            GridColumn colRemark = new GridColumn();
            colRemark.FieldName = "Remark";
            colRemark.Caption = "Remark";
            colRemark.Visible = true;


            GridColumn colProductionDate = new GridColumn();
            colProductionDate.FieldName = "ProductionDate";
            colProductionDate.Caption = "ProductionDate";
            colProductionDate.Visible = true;

            GridColumn colUseByDate = new GridColumn();
            colUseByDate.FieldName = "UseByDate";
            colUseByDate.Caption = "UseByDate";
            colUseByDate.Visible = true;

            GridColumn colSpecialRequirement = new GridColumn();
            colSpecialRequirement.FieldName = "SpecialRequirement";
            colSpecialRequirement.Caption = "SpecialRequirement";
            colSpecialRequirement.Visible = true;

            grvDataFind.Columns.AddRange(new GridColumn[] { colCustomerID, colCustomerNumber, colCustomerName, colProductNumber, colProductName, colWeightPerPackage, colSumOfCurrentQuantity, colTotalPackages, colReceivingOrderDate, colReceivingOrderNumber, colCustomerRef, colRemark, colSpecialRequirement, colProductionDate, colUseByDate });
        }
        private void LoadData(int CustomerID, string Ref, int optionFiter)
        {
            InitColumn();
            if (optionFiter == 1)
            {
                try
                {
                   
                    grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",'" + Ref + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (optionFiter == 2)
            {
                try
                {
                   
                    grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",NULL,'" + Ref + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (optionFiter == 3)
            {
                try
                {
                  
                    grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",NULL,NULL,'" + Ref + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (optionFiter == 5)
            {
                try
                {
                   
                    grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",NULL,NULL,NULL,NULL,'" + Ref + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (optionFiter == 4)
            {
                try
                {
                   
                    grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",NULL,NULL,NULL,'" + Ref + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                grdDataFind.DataSource = FileProcess.LoadTable("STStockOnHandByLotFindReport " + CustomerID + ",NULL,NULL,NULL,NULL,NULL,'" + Ref + "'");

            }
        }
    }
}
