using System;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace DA.Warehouse
{
    public class TripDA : DataProcess<Trips>
    {
        public int STNumberToText(int number, ObjectParameter text)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STNumberToText(number, text);
            }
        }
    }
}
