using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Warehouse
{
    public class AttachmentDA : DataProcess<Attachments>
    {
        public int STAttachmentUpdate(int attachmentID, string orderNumber, string attachmentDescription, string attachmentFile, DateTime attachmentDate, string attachmentUser, short flag, int attachmentFileSize, int confidentialLevel, string originalFileName)
        {
            using (var context  = new SwireDBEntities())
            {
                return context.STAttachmentUpdate(attachmentID, orderNumber, attachmentDescription, attachmentFile, attachmentDate, attachmentUser, flag, attachmentFileSize, confidentialLevel, originalFileName);
            }
        }
    }
}
