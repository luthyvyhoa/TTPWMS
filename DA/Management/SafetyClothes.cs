using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class SafetyClothes
    {
        public int SafetyClothesEnquiryID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime EnquiryDate { get; set; }
        public string EnquiryRemark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string Confirmed { get; set; }
        public int StoreID { get; set; }
    }
}
