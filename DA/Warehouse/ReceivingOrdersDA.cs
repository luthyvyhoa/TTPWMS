using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class ReceivingOrdersDA : DataProcess<ReceivingOrders>
    {
        /// <summary>
        /// Get employee by date number
        /// </summary>
        /// <param name="day">int</param>
        /// <returns>IList<ReceivingOrders></returns>
        public IList<ReceivingOrders> SelectByDateNumber(int day)
        {
            DateTime fromDate = this.GetDate().AddDays(-day);
            return this.Select(a => a.ReceivingOrderDate >= fromDate).OrderBy(o => o.ReceivingOrderID).ToList();
        }

        public void STReceivingPalletCartonWeightingChecking(int receivingOrderID, ObjectParameter weightted)
        {
            using (var context = new SwireDBEntities())
            {
                context.STReceivingPalletCartonWeightingChecking(receivingOrderID, weightted);
            }
        }

        /// <summary>
        /// Update receiving Order detail
        /// </summary>
        /// <param name="receivingOrderDetailID"></param>
        /// <returns></returns>
        public int UpdateQuantityReceivingOrderDetail(int receivingOrderDetailID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STReceivingOrderDetailUpdateQty(receivingOrderDetailID);
            }
        }

        /// <summary>
        /// Change product id
        /// </summary>
        /// <param name="productID">int</param>
        /// <param name="rODetailID">int</param>
        /// <param name="user">string</param>
        public void ChangeProductID(int productID, int rODetailID, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STVSReceivingOrderDetailChangeProductID(productID, rODetailID, user);
            }
        }

        /// <summary>
        /// Define customer requirement is remaind
        /// </summary>
        /// <param name="customerMainID">int</param>
        /// <param name="loginName">string</param>
        /// <param name="orderType">string</param>
        /// <param name="result">ObjectParameter</param>
        /// <returns>int</returns>
        public int STCustomerRequirementRemind(int customerMainID, string loginName, string orderType, System.Data.Entity.Core.Objects.ObjectParameter result)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STCustomerRequirementRemind(customerMainID, loginName, orderType, result);
            }
        }

        /// <summary>
        /// Delete RO Detail
        /// </summary>
        /// <param name="customerMainID">int</param>
        /// <param name="loginName">string</param>
        /// <param name="orderType">string</param>
        /// <param name="result">ObjectParameter</param>
        /// <returns>int</returns>
        public int STReceivingOrderDetailDelete(int roDetailID, string loginName)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STReceivingOrderDetailDelete(roDetailID, loginName);
            }
        }

        /// <summary>
        /// Delete Receiving Order
        /// </summary>
        /// <param name="roID"></param>
        /// <returns></returns>
        public int STOrderDelete(string roID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STOrdersDelete(roID);
            }
        }

        /// <summary>
        /// Break Current Receiving Order Detail
        /// </summary>
        /// <param name="roDetailID"></param>
        /// <param name="quantity"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int STReceivingOrderDetailBreak(int roDetailID, short quantity, string userName)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STReceivingOrderDetailBreak(roDetailID, quantity, userName);
            }
        }
    }
}
