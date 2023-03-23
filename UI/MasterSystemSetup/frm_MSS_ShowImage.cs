using System.Windows.Forms;
using Common.Controls;
using System.Drawing;
namespace UI.MasterSystemSetup
{
    public partial class frm_MSS_ShowImage : frmBaseForm
    {
        private Image img;
        public frm_MSS_ShowImage( Image img)
        {
            InitializeComponent();

            this.img = img;
            this.pictureEdit1.Image = img;
        }
    }
}
