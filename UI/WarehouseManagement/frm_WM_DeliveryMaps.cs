//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Common.Controls;
//using System.Security.Permissions;
//using DevExpress.XtraMap;

//namespace UI.WarehouseManagement
//{
//    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
//    public partial class frm_WM_DeliveryMaps : frmBaseForm
//    {
//        public frm_WM_DeliveryMaps()
//        {
//            InitializeComponent();
//        }

//        private void frm_WM_DeliveryMaps_Load(object sender, EventArgs e)
//        {
//            // Specify the map position on the form.           
//            mapControl1.Dock = DockStyle.Fill;

//            // Create a layer.
//            ImageLayer layer = new ImageLayer();
//            mapControl1.Layers.Add(layer);

//            // Create a data provider.
//            OpenStreetMapDataProvider provider = new OpenStreetMapDataProvider();
//            layer.DataProvider = provider;

//            // Specify the map zoom level and center point. 
//            mapControl1.ZoomLevel = 13;
//            mapControl1.CenterPoint = new GeoPoint(10.9, 106.8);
//        }
//    }
//}
