using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class SP_LoadContractCommitData
    {
        public int ContractCommitmentID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public string RoomID { get; set; }
        public int NumberOfLocations { get; set; }
        public string LocationType { get; set; }
        public bool isMain { get; set; }
        public string CDCRemark { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public bool isDeleted { get; set; }
        public int StoreID { get; set; }
        public string StoreDescription { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> PalletBilled { get; set; }
        public Nullable<int> Pallets { get; set; }
    }
}
