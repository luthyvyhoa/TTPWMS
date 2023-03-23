using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.API
{
    public class CarSignal
    {
        public int CarID { get; set; }
        public byte Speed { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public int SecondNumber { get; set; }
        public byte Status { get; set; }
        public DateTime RealTime { get; set; }
        public byte Sensor { get; set; }
        public string Address { get; set; }
    }
}
