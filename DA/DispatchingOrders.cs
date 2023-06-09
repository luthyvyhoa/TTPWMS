//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public partial class DispatchingOrders
    {
        public DispatchingOrders()
        {
            this.DispatchingProducts = new HashSet<DispatchingProducts>();
        }

        public int DispatchingOrderID { get; set; }
        public string DispatchingOrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime DispatchingOrderDate { get; set; }
        public string SpecialRequirement { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> DispatchingCreatedTime { get; set; }
        public string Owner { get; set; }
        public string Temperature { get; set; }
        public string SealNumber { get; set; }
        public string DockNumber { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<byte> DispatchingOrderProgress { get; set; }
        public Nullable<int> CustomerClientID { get; set; }
        public byte[] TS { get; set; }
        public Nullable<byte> OrderHandlingCategoryID { get; set; }
        public Nullable<int> DestinationPortID { get; set; }
        public Nullable<short> HandlingOvertimeCategoryID { get; set; }
        public string InternalRemark { get; set; }
        public Nullable<bool> Electricity { get; set; }
        public Nullable<double> ProgressPercentage { get; set; }
        public Nullable<bool> IsAttachment { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string VehicleNumber { get; set; }
        public Nullable<int> TimeSlotID { get; set; }
        public Nullable<int> DockDoorID { get; set; }
        public Nullable<double> PickingPercentage { get; set; }
        public Nullable<byte> ProcessingStatus { get; set; }
        public string CustomerOrderNumber2 { get; set; }

        public Nullable<System.DateTime> EDIMessageSentTime { get; set; }
        public Nullable<int> WorkTypeCode { get; set; }
        public virtual Customers Customers { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<DispatchingProducts> DispatchingProducts { get; set; }
    }
}
