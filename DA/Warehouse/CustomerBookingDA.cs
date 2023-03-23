using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class CustomerBookingDA : DataProcess<CustomerBookings>
    {
        public int STCustomerBookingImportToOrder(string bookingNumber, Nullable<int> customerID, string customerNumber, Nullable<System.DateTime> orderDate, string owner, string specialRequirement, string orderType, ObjectParameter orderID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STCustomerBookingImportToOrder(bookingNumber, customerID, customerNumber, orderDate, owner, specialRequirement, orderType,orderID);
            }
        }
    }
}
