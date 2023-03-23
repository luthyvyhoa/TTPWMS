using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Helper
{
    public class WMSDOSelectProductQuickly
    {
        int? productID = 0;
        string productNumber = "";
        string productName = "";
        string customerRef = "";
        Int32 qty = 0;
        Int32 dOQty = 0;
        decimal? weightPerPackage = 0;
        int? packagesPerPallet = 0;
        Int32 receivingOrderDetailID = 0;

        public int? ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductNumber
        {
            get { return productNumber; }
            set { productNumber = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string CustomerRef
        {
            get { return customerRef; }
            set { customerRef = value; }
        }

        public Int32 Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public Int32 DOQty
        {
            get { return dOQty; }
            set { dOQty = value; }
        }

        public Decimal? WeightPerPackage
        {
            get { return weightPerPackage; }
            set { weightPerPackage = value; }
        }

        public int? PackagesPerPallet
        {
            get { return packagesPerPallet; }
            set { packagesPerPallet = value; }
        }

        public Int32 ReceivingOrderDetailID
        {
            get { return receivingOrderDetailID; }
            set { receivingOrderDetailID = value; }
        }
        public string ReceivingOrderNumber { get; set; }
        public Nullable<System.DateTime> ReceivingOrderDate { get; set; }
        public string SpecialRequirement { get; set; }
        public string Remark { get; set; }
        public Nullable<byte> PalletStatus { get; set; }
        public bool? OnHold { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<System.DateTime> UseByDate { get; set; }
        public string PalletStatusDescription { get; internal set; }
        public int? Plts { get; internal set; }
        public Boolean Checked { get; set; }
        public string LocationNumber { get; set; }
        public string Packages { get; set; }
        public int? Pcs { get; set; }
        public Nullable<int> PalletID { get; set; }

        public WMSDOSelectProductQuickly()
        {
        }
        public WMSDOSelectProductQuickly(int _id, string _code, string _name, int _qty, int _dOQty, decimal _weightPerPackage, int _packagesPerPallet, int _receivingOrderDetailID)
        {
            productID = _id;
            productNumber = _code;
            productName = _name;
            qty = _qty;
            dOQty = _dOQty;
            weightPerPackage = _weightPerPackage;
            packagesPerPallet = _packagesPerPallet;
            receivingOrderDetailID = _receivingOrderDetailID;
        }
    }
}
