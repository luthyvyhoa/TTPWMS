using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class DispatchingOrderDetailsDA : DataProcess<DispatchingOrderDetails>
    {
        public int STDispatchingOrderDetailsDelete(int doDetailID, short quantity)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STDispatchingOrderDetailDelete(doDetailID, quantity);
            }
        }

        public int STDispatchingOrderDetailBreakLine(Nullable<int> dispatchingOrderDetailID, Nullable<short> newQuantityOfPackages, string currentUser, Nullable<decimal> weightPerPackage, Nullable<short> inners)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STDispatchingOrderDetailBreakLine(dispatchingOrderDetailID, newQuantityOfPackages, currentUser, weightPerPackage, inners);
            }
        }

        public int STDispatchingCartonScanCheck(int dispatchingOrderID, int transactionID, ObjectParameter hasDifference)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STDispatchingCartonScanCheck(dispatchingOrderID, transactionID, hasDifference);
            }
        }
    }
}
