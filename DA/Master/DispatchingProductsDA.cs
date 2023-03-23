using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Master
{
    public class DispatchingProductsDA : DataProcess<DispatchingProducts>
    {
        public List<DispatchingProducts> SelectByDispatchingOrderID(int dispatchingOrderID)
        {
            using (var context = new SwireDBEntities())
            {
                try
                {
                    List<DispatchingProducts> resultsList = null;
                    resultsList = context.DispatchingProducts.Where(a => a.DispatchingOrderID == dispatchingOrderID).ToList();
                    return resultsList;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public void STDispatchingProductInsert_New(int dispatchingOrderID, int productID, int totalQuantity, float weightPerPackage, string dispatchingOrderNumer, string condition, string dispatchingMethod, string dispatchingProductRemark, string dispatchingProductReference, string user)
        {
            using (var context = new SwireDBEntities())
            {
                int result = context.STDispatchingProductInsert_New(dispatchingOrderID, productID, totalQuantity, weightPerPackage, dispatchingOrderNumer, condition, dispatchingMethod, dispatchingProductRemark, dispatchingProductReference, user);
            }
        }

        public void STDispatchingProductInsert1RODetails(int dispatchingOrderID, int productID, int totalQuantity, string productNumber, string productName, float weightPerPackage, string dispatchingOrderNumer, int receivingOrderDetailID, string dispatchingProductRemark, string dispatchingProductReference, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STDispatchingProductInsert1RODetails(dispatchingOrderID, productID, totalQuantity, productNumber, productName, weightPerPackage, dispatchingOrderNumer, receivingOrderDetailID, dispatchingProductRemark, dispatchingProductReference, user);
            }
        }

        public void STDispatchingProductInsertByLocationRandomWeight(int dispatchingOrderID, int productID, Int16 pingkingQuatity, float weightPerPackage, string dispatchingOrderNumer, string condition, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STDispatchingProductInsertByLocationRandomWeight(dispatchingOrderID, productID, pingkingQuatity, weightPerPackage, dispatchingOrderNumer, condition, user);
            }
        }

        public void STDispatchingProductInsertByLocation_New(int dispatchingOrderID, int productID, Int16 pingkingQuatity, float weightPerPackage, string dispatchingOrderNumer, string condition, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STDispatchingProductInsertByLocation_New(dispatchingOrderID, productID, pingkingQuatity, weightPerPackage, dispatchingOrderNumer, condition, user);
            }

        }
    }
}
