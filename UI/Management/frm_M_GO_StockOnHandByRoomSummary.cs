using Common.Controls;
using DA;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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

namespace UI.Management
{
    public partial class frm_M_GO_StockOnHandByRoomSummary : frmBaseForm
    {
        public frm_M_GO_StockOnHandByRoomSummary()
        {
            InitializeComponent();

            InitDataForGrid();
        }

        private void InitDataForGrid()
        {
            var dataSource = FileProcess.LoadTable("STStockOnHandByRoomCrosstab @varStoreID=" + AppSetting.StoreID);
            grdStockOnHandByRoomSummary.DataSource = dataSource;
        }

        private void grdStockOnHandByRoomSummary_Paint(object sender, PaintEventArgs e)
        {
            //GridControl grid = sender as GridControl;
            //GridView view = grid.FocusedView as GridView;
            //GridViewInfo info = view.GetViewInfo() as GridViewInfo;

            //Rectangle colRect1 = info.ColumnsInfo[grvStockOnHandByRoomSummary.Columns[8]].Bounds;
            //Rectangle lineRect1 = new Rectangle(colRect1.Right - 3, colRect1.Y, 3, info.ViewRects.Rows.Height + colRect1.Height);
            //e.Graphics.FillRectangle(Brushes.Red, lineRect1);

            //Rectangle colRect2 = info.ColumnsInfo[grvStockOnHandByRoomSummary.Columns[14]].Bounds;
            //Rectangle lineRect2 = new Rectangle(colRect2.Right - 3, colRect2.Y, 3, info.ViewRects.Rows.Height + colRect2.Height);
            //e.Graphics.FillRectangle(Brushes.Red, lineRect2);
        }
    }
}
