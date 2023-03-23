using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class PalletDA
    {
        public int STPalletBreakReturnNewPalletID(int i_VarPalletID,short i_VarNewQuantity,string i_CurrentUser, ObjectParameter i_VarNewPalletID)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STPalletBreakReturnNewPalletID(i_VarPalletID, i_VarNewQuantity, i_CurrentUser, i_VarNewPalletID);
            }
        }
        public int ExecSQLString(string i_SQL)
        {
            using (var context = new SwireDBEntities())
            {
                return context.ST_WMS_ExecSQLString(i_SQL);
            }
        }

        public int STPalletInfo_Locations_UpdatePalletStatus(int i_PalletID, byte i_PalletStatus, string i_UserId)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STPalletInfo_Locations_UpdatePalletStatus(i_PalletID, i_PalletStatus, i_UserId);
            }
        }

        public int STProductDeleteAndChange(int vaOldrProductID, int varNewProductID, string varUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STProductDeleteAndChange(vaOldrProductID, varNewProductID, varUser);
            }
        }

        public int STQuarantineUpdate1Pallet(int vaPalletID, int varFlag, string varHoldDescription, string varCurrentUser)
        {
            using (var context = new SwireDBEntities())
            {
                return context.STQuarantineUpdate1Pallet(vaPalletID, varFlag, varHoldDescription, varCurrentUser);
            }
        }

    }
}
