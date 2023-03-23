using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class TransactionDAC
    {
        public void STTransactionInsert(int receivingOrderID, string receivingOrderNumber, string user, string customerNumber)
        {
            using (var context = new SwireDBEntities())
            {
                context.STTransactionInsert(receivingOrderID, receivingOrderNumber, user, customerNumber);
            }
        }

        public void STConfirmOne(int transactionID, byte transactionType, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STConfirmOne(transactionID, transactionType, user);
            }
        }

        public void STTransactionInsertAll(int receivingOrderID, string receivingOrderNumber, string user, string customerNumber)
        {
            using (var context = new SwireDBEntities())
            {
                context.STTransactionInsertAll(receivingOrderID, receivingOrderNumber, user, customerNumber);
            }
        }

        public void STTransactionDelete(int receivingOrderID, int transactionID, bool transactionType, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STTransactionDelete(receivingOrderID, transactionID, transactionType, user);
            }
        }

        public void STTransactionDeleteAll(int receivingOrderID, bool transactionType, string user)
        {
            using (var context = new SwireDBEntities())
            {
                context.STTransactionDeleteAll(receivingOrderID, transactionType, user);
            }
        }

        public int STBarcodeScan_OrderDetailInsert(Nullable<int> palletID, string orderNumber, string userID, ObjectParameter barcodeScanDetailID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STBarcodeScan_OrderDetailInsert(palletID, orderNumber, userID, barcodeScanDetailID);
            }
        }
    }
}
