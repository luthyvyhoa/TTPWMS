using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Stock
{
    public class StockMovementDA
    {
        public int ExecSQLString(string i_SQL)
        {
            using (var context = new SwireDBEntities())
            {
                return context.ST_WMS_ExecSQLString(i_SQL);
            }
        }

        public int STStockMovementLocationIDChange(int i_VarLocationID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STStockMovementLocationIDChange(i_VarLocationID);
            }
        }

        public int STStockMovementInsert(
            int i_varSourceLocationID
            ,string i_varSourceLocationNumber
            ,int i_varDestinationLocationID
            , string i_varDestinationLocationNumber
            , string i_varReason
            , int i_varEmployeeID
            ,string i_varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STStockMovementInsert(i_varSourceLocationID,i_varSourceLocationNumber,i_varDestinationLocationID,i_varDestinationLocationNumber, i_varReason, i_varEmployeeID, i_varUser);
            }
        }

        public int STStockMovementInsertReversed(
            int i_varSourceLocationID,
            string i_varSourceLocationNumber, 
            int i_varDestinationLocationID, 
            string i_varDestinationLocationNumber, 
            string i_varReason, 
            int i_varEmployeeID,
            string i_varUser )
        {
            using (var context = new SwireDBEntities())
            {
                return context.STStockMovementInsertReversed(i_varSourceLocationID, i_varSourceLocationNumber, i_varDestinationLocationID, i_varDestinationLocationNumber, i_varReason, i_varEmployeeID, i_varUser);
            }
        }


        //public int STPalletInfo_Locations_UpdatePalletStatus(int i_PalletID, byte i_PalletStatus, string i_UserId)
        //{
        //    using (var context = new SwireDBEntities())
        //    {
        //        return context.STPalletInfo_Locations_UpdatePalletStatus(i_PalletID, i_PalletStatus, i_UserId);
        //    }
        //}

        //public int STProductDeleteAndChange(int vaOldrProductID, int varNewProductID, string varUser)
        //{
        //    using (var context = new SwireDBEntities())
        //    {
        //        return context.STProductDeleteAndChange(vaOldrProductID, varNewProductID, varUser);
        //    }
        //}

        //public int STQuarantineUpdate1Pallet(int vaPalletID, int varFlag, string varHoldDescription, string varCurrentUser)
        //{
        //    using (var context = new SwireDBEntities())
        //    {
        //        return context.STQuarantineUpdate1Pallet(vaPalletID, varFlag, varHoldDescription, varCurrentUser);
        //    }
        //}

    }
}
