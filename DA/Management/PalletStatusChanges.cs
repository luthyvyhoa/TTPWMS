using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Management
{
    public class PalletStatusChanges
    {
        public int PalletStatusChangeID { get; set; }
        public string PalletStatusChangeNumber { get; set; }
        public DateTime PalletStatusChangeDate { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public int CustomerID { get; set; }
        public string PalletStatusChangeRemark { get; set; }
        public string AuthorisedBy { get; set; }
        public string ConfirmedBy { get; set; }
        public DateTime? ConfirmedTime { get; set; }
        public string PalletStatusChangeCategory { get; set; }
        public byte? NewStatus { get; set; }
        public string RequestedBatchNumber { get; set; }
        public DateTime? RequestedUsedByDate { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string RequestedOldStatus { get; set; }
        public string RequestedNewStatus { get; set; }
        public DateTime? EDIMessageSentTime { get; set; }
        public int EDI_OrderDetailID { get; set; }
        public string RequestedProductNumber { get; set; }
        public string RequestedProductName { get; set; }
        public Nullable<int> RequestedQuantity { get; set; }
    }

}
