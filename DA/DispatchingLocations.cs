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

    public partial class DispatchingLocations
    {
        public DispatchingLocations()
        {
            this.DispatchingOrderDetails = new HashSet<DispatchingOrderDetails>();
        }

        public int DispatchingLocationID { get; set; }
        public int DispatchingProductID { get; set; }
        public int LocationID { get; set; }
        public string Label { get; set; }
        public short QuantityOfPackages { get; set; }
        public string DispatchingLocationRemark { get; set; }
        public bool DispatchingLocationStatus { get; set; }
        public byte[] TS { get; set; }

        public virtual DispatchingProducts DispatchingProducts { get; set; }
        public virtual Locations Locations { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<DispatchingOrderDetails> DispatchingOrderDetails { get; set; }
    }
}
