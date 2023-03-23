using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PurchasingOrderDetail
    {
        public int PartGroupID { get; set; }
        public int PurchasingOrderDetailID { get; set; }
        public int PurchasingOrderID { get; set; }
        public int PartID { get; set; }

        public string UnitPriceUSD { get; set; }
        public string UnitPriceVND { get; set; }
        public string ItemRemark { get; set; }
        public string Remark { get; set; }
        public string DepartmentCategoryID { get; set; }
        public string PropertyCategoryID { get; set; }
        public int Status { get; set; }
        public string ts { get; set; }
        public string OrderQuantity { get; set; }
        public string DeliveryQuantity { get; set; }
        public System.DateTime DeliveryDateDetail { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }

        public string Amount { get; set; }


    }
}
