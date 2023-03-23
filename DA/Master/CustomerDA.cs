using System;

namespace DA.Master
{
    public class CustomerDA : DataProcess<Customers>
    {

        /// <summary>
        /// Insert new CustomerProductGroups
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public int InsertNewCustomerProductGroup(int customerID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STCustomerProductGroupInsertNew(customerID);
            }
        }

        /// <summary>
        /// Update Customer Information
        /// </summary>
        /// <param name="customerID"></param>
        /// /// <param name="customerMainID"></param>
        /// <returns></returns>
        public int UpdateCustomerInfo(int customerID, int customerMainID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STCustomerInfoUpdate(customerID, customerMainID);
            }
        }

        //public int UpdateCustomerInListByMainIDfo(int customerID, int customerDiscontinued)
        //{
        //    using (var context = new SwireDBEntities())
        //    {
        //        return context.STVSCustomerListByMainID(customerID, customerDiscontinued);
        //    }
        //}
    }
}
