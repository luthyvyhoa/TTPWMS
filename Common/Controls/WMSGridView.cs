using DevExpress.Utils;

namespace Common.Controls
{
    public class WMSGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        private const string PAINT_STYLE_NAME = "Skin";
        private System.Drawing.Font fontFooter;
        public WMSGridView()
        {
            this.PaintStyleName = PAINT_STYLE_NAME;
            this.fontFooter = new System.Drawing.Font("Tomato", 8.25f, System.Drawing.FontStyle.Bold);
            this.Appearance.FooterPanel.Font = this.fontFooter;
            this.OptionsClipboard.AllowCopy = DefaultBoolean.True;
            this.OptionsSelection.MultiSelect = true;
            this.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.CustomDrawColumnHeader += WMSGridControl_CustomDrawColumnHeader;
            this.CustomDrawFooterCell += WMSGridView_CustomDrawFooterCell;
            this.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Teal;
            this.Appearance.FooterPanel.BackColor = System.Drawing.Color.RosyBrown;
            //this.CustomDrawRowFooter += WMSGridView_CustomDrawRowFooter;
            this.MouseWheel += WMSGridView_MouseWheel;
        }

        void WMSGridView_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.CloseEditor();
        }

        void WMSGridView_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }
        void WMSGridControl_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            e.Info.Caption = e.Info.Caption.ToUpper();
            this.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
        }

        void WMSGridView_CustomDrawRowFooter(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            e.Handled = true;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // WMSGridView
            // 
            this.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Appearance.Row.ForeColor = System.Drawing.Color.Red;
            this.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
