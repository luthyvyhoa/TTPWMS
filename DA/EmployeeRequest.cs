using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class EmployeeRequest
    {
        public int EmployeeRequestID { get; set; }

        public string EmployeeRequestNumber { get; set; }

        public DateTime EmployeeRequestDate { get; set; }

        public int EmployeeID { get; set; }

        public int SupervisorID { get; set; }

        public string EmployeeRequestRemark { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string ConfirmedBy { get; set; }

        public DateTime? ConfirmedTime { get; set; }

        public int EmployeeRequestType { get; set; }

        public DateTime? EmployeeRequestFrom { get; set; }

        public DateTime? EmployeeRequestTo { get; set; }

        public string EmployeeRequestFeedback { get; set; }

        public byte EmployeeRequestStatus { get; set; }

        public string DeparturePlace { get; set; }

        public string DestinationPlace { get; set; }

        public string UseCar { get; set; }

        public string UseHotel { get; set; }

    }

}
