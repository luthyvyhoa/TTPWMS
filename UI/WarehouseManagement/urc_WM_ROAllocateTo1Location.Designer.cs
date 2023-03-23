namespace UI.WarehouseManagement
{
    partial class urc_WM_ROAllocateTo1Location
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lke_LocationID = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditLocationNumber = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lke_LocationID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLocationNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lke_LocationID
            // 
            this.lke_LocationID.Location = new System.Drawing.Point(19, 22);
            this.lke_LocationID.MinimumSize = new System.Drawing.Size(0, 24);
            this.lke_LocationID.Name = "lke_LocationID";
            this.lke_LocationID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lke_LocationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lke_LocationID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationID", "LocationID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("X", "Location Number Short", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationNumber", "LocationNumber", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lke_LocationID.Properties.DropDownRows = 20;
            this.lke_LocationID.Properties.NullText = "";
            this.lke_LocationID.Properties.PopupWidth = 170;
            this.lke_LocationID.Size = new System.Drawing.Size(116, 22);
            this.lke_LocationID.TabIndex = 0;
            this.lke_LocationID.EditValueChanged += new System.EventHandler(this.lke_LocationID_EditValueChanged);
            // 
            // textEditLocationNumber
            // 
            this.textEditLocationNumber.Location = new System.Drawing.Point(155, 22);
            this.textEditLocationNumber.MinimumSize = new System.Drawing.Size(0, 24);
            this.textEditLocationNumber.Name = "textEditLocationNumber";
            this.textEditLocationNumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.textEditLocationNumber.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.textEditLocationNumber.Properties.ReadOnly = true;
            this.textEditLocationNumber.Size = new System.Drawing.Size(164, 22);
            this.textEditLocationNumber.TabIndex = 3;
            // 
            // urc_WM_ROAllocateTo1Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditLocationNumber);
            this.Controls.Add(this.lke_LocationID);
            this.Name = "urc_WM_ROAllocateTo1Location";
            this.Size = new System.Drawing.Size(340, 67);
            ((System.ComponentModel.ISupportInitialize)(this.lke_LocationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLocationNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lke_LocationID;
        private DevExpress.XtraEditors.TextEdit textEditLocationNumber;
    }
}
