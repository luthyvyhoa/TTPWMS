using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Master
{
    public class ProductDA
    {
        public int DeleteProduct(int productId, ObjectParameter delete)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STProductDelete(productId, delete);
            }
        }

        public int UpdateOrder(int productId,string userId)
        {
            using (var context = new SwireDBEntities())
            {
                return context.ST_WMS_tmpUpdateRODO(productId, userId);
            }
        }

        public int ExecSQLString(string i_SQL)
        {
            using (var context = new SwireDBEntities())
            {
                return context.ST_WMS_ExecSQLString(i_SQL);
            }
        }

        public int STProductUpdate(int varProductID, string varOrderNumberStrR, string varOrderNumberStrD, string updatedBy)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STProductUpdate(varProductID, varOrderNumberStrR, varOrderNumberStrD, updatedBy);
            }
        }

        public int STProductChangeHomeLocations(int customerID, string homeRoom1, string homeRoom2)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STProductChangeHomeLocations(customerID, homeRoom1, homeRoom2);
            }
        }
    }
}
