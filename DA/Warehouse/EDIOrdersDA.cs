using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class EDIOrdersDA
    {
        
        public int STCustomerClientsInsert(int i_CustomerID, string i_CustomerClientCode,string i_CustomerClientName,string i_CustomerClientAddress,string i_CreatedBy , ObjectParameter i_newCustomerClientID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STCustomerClientsInsert(i_CustomerID, i_CustomerClientCode,i_CustomerClientName,i_CustomerClientAddress,i_CreatedBy, i_newCustomerClientID);
            }
        }

        public int ExecSQLString(string i_SQL)
        {
            using (var context = new SwireDBEntities())
            {
                return context.ST_WMS_ExecSQLString(i_SQL);
            }
        }
       
        public int STEDI_ProcessDispatchingOrder_Main(int i_varEDI_OrderID, string i_varUser, int i_varPickSequence)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProcessDispatchingOrder_Main(i_varEDI_OrderID, i_varUser, i_varPickSequence);
            }
        }
        public int STEDI_ProcessDispatchingOrder_Main_PickSequence(int i_varEDI_OrderID, string i_varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProcessDispatchingOrder_Main_PickSequence(i_varEDI_OrderID, i_varUser);
            }
        }

        public int STEDI_ProcessDispatchingOrder_PickSequence(int i_varEDI_OrderID, string i_varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProcessDispatchingOrder_PickSequence(i_varEDI_OrderID, i_varUser);
            }
        }


        public int STEDI_ProcessDispatchingOrder(int i_varEDI_OrderID, string i_varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProcessDispatchingOrder(i_varEDI_OrderID, i_varUser);
            }
        }

        public int STEDI_ProcessReceivingOrder(int i_varEDI_OrderID, string i_varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProcessReceivingOrder(i_varEDI_OrderID, i_varUser);
            }
        }

        public int STEDI_ProductRemainUpdate(int i_varCustomerMainID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STEDI_ProductRemainUpdate(i_varCustomerMainID);
            }
        }

        
    }
}
