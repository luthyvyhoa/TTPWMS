using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class DispatchingLocationDA : DataProcess<DispatchingLocations>
    {
        public int STDispatchingLocationDelete(Nullable<int> varDispatchingLocationID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STDispatchingLocationDelete(varDispatchingLocationID);
            }
        }
    }
}
