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
    
    public partial class Trips
    {
        public int TripID { get; set; }
        public string TripNumber { get; set; }
        public System.DateTime TripDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<int> RouteID { get; set; }
        public Nullable<System.DateTime> TripConfirmedTime { get; set; }
        public bool TripConfirmed { get; set; }
        public string TripRemark { get; set; }
        public string SealNumber { get; set; }
        public byte[] TS { get; set; }
        public Nullable<System.DateTime> StartWorkingTime { get; set; }
        public Nullable<System.DateTime> EndWorkingTime { get; set; }
        public string DockNumber { get; set; }
        public Nullable<short> HandlingOvertimeCategoryID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Temperature { get; set; }
        public string InternalRemark { get; set; }
        public Nullable<byte> DispatchingOrderProgress { get; set; }
        public Nullable<int> DestinationPortID { get; set; }
        public Nullable<bool> IsAttachment { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string VehicleNumber { get; set; }
        public Nullable<int> TimeSlotID { get; set; }
        public Nullable<int> DockDoorID { get; set; }
        public Nullable<int> TransporterID { get; set; }
        public Nullable<int> TransportTripID { get; set; }
        public Nullable<double> PickingPercentage { get; set; }
        public Nullable<double> ProgressPercentage { get; set; }
        public Nullable<byte> TripOrderProgress { get; set; }
        public Nullable<System.DateTime> OnRoadStartTime { get; set; }
        public Nullable<System.DateTime> OnRoadEndTime { get; set; }
    }
}