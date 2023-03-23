using System.Windows.Forms;

namespace UI.MasterSystemSetup
{
    public partial class urc_MSS_CustomerRequirementsViewContend : UserControl
    {
        public urc_MSS_CustomerRequirementsViewContend()
        {
            InitializeComponent();
        }

        public string UpdateBy
        {
            get
            {
                return this.lbl_MSS_UpdateBy.Text;
            }
            set
            {
                this.lbl_MSS_UpdateBy.Text = value;
            }
        }

        public string Time
        {
            get
            {
                return this.lbl_MSS_Time.Text;
            }
            set
            {
                this.lbl_MSS_Time.Text = value;
            }
        }

        public string RequirementContent
        {
            get
            {
                return this.mm_MSS_Notes.Text;
            }
            set
            {
                this.mm_MSS_Notes.EditValue = value;
            }
        }
    }
}
