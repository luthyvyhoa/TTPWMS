using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;

namespace Common.Controls
{
    [UserRepositoryItem("RegisterWMSLookUpEdit")]
    public class RepositoryItemWMSLookUpEdit : RepositoryItemLookUpEdit {
        static RepositoryItemWMSLookUpEdit() {
            RegisterCustomEdit1();
        }

        public const string CustomEditName = "WMSLookUpEdit";

        public RepositoryItemWMSLookUpEdit() {
        }

        public override string EditorTypeName {
            get {
                return CustomEditName;
            }
        }

        public static void RegisterCustomEdit1() {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(WMSLookUpEdit), typeof(RepositoryItemWMSLookUpEdit), typeof(CustomEdit1ViewInfo), new CustomEdit1Painter(), true, img));
        }

        public override void Assign(RepositoryItem item) {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemWMSLookUpEdit source = item as RepositoryItemWMSLookUpEdit;
                if(source == null) return;
                //
            } finally {
                EndUpdate();
            }
        }
    }

    [ToolboxItem(true)]
    public class WMSLookUpEdit : LookUpEdit {
        static WMSLookUpEdit() {
            RepositoryItemWMSLookUpEdit.RegisterCustomEdit1();
        }

        public WMSLookUpEdit() {
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemWMSLookUpEdit Properties {
            get {
                return base.Properties as RepositoryItemWMSLookUpEdit;
            }
        }

        public override string EditorTypeName {
            get {
                return RepositoryItemWMSLookUpEdit.CustomEditName;
            }
        }


        protected override int FindItem(string text, bool partialSearch, int startIndex) {
            return -1;
        }

        protected override PopupBaseForm CreatePopupForm() {
            return new CustomEdit1PopupForm(this);
        }
    }

    public class CustomEdit1ViewInfo : LookUpEditViewInfo {
        public CustomEdit1ViewInfo(RepositoryItem item)
            : base(item) {
        }
    }

    public class CustomEdit1Painter : ButtonEditPainter {
        public CustomEdit1Painter() {
        }
    }

    public class CustomEdit1PopupForm : PopupLookUpEditForm {
        public CustomEdit1PopupForm(WMSLookUpEdit ownerEdit)
            : base(ownerEdit) {
        }
    }
}
