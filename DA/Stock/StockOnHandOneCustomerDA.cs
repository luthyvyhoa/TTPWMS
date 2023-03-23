
namespace DA.Stock
{
    public class StockOnHandOneCustomerDA
    {
        /// <summary>
        /// Refresh the products by customer
        /// </summary>
        /// <param name="customerID">int</param>
        /// <returns>int</returns>
        public int STtmpProductRemainUpdate(int customerID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STtmpProductRemainUpdate(customerID);
            }
        }
    }
}
