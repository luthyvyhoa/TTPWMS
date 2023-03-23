using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Helper
{
    public class WMSDOSelectPPallets
    {
        Int32 qty = 0;
        Int32 dOQty = 0;
        Int32 receivingOrderID = 0;
        string rO = "";
        string location = "";
        Int32 palletID = 0;
        Nullable<DateTime> productionDate = null;
        Nullable<DateTime> useByDate =null;
        string remark = "";
        string reference = "";


        public Int32 ReceivingOrderlID
        {
            get { return receivingOrderID; }
            set { receivingOrderID = value; }
        }

        public string RO
        {
            get { return rO; }
            set { rO = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public Int32 PalletID
        {
            get { return palletID; }
            set { palletID = value; }
        }

        public Nullable<DateTime> ProductionDate
        {
            get { return productionDate; }
            set { productionDate = value; }
        }

        public Nullable<DateTime> UseByDate
        {
            get { return useByDate; }
            set { useByDate = value; }
        }

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
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

        public WMSDOSelectPPallets()
        {
        }
    }
}
