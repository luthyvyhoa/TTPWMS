using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.API
{
    public class CarInfo
    {
        public int CarID { get; set; }
        public string CarPlate { get; set; }
        public byte Speed { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public bool NoSignal { get; set; }
        public bool NoGPS { get; set; }
        public int SecondNumber { get; set; }
        public string Address { get; set; }
        public DateTime LastTime { get; set; }
        public byte Sensor { get; set; }
        public byte Temp { get; set; }
    }
}
