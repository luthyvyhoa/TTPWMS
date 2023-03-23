using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.API
{
    public class Navi_ACKRespond
    {
        [JsonIgnore]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Sync_ID")]
        public string Sync_ID { get; set; }
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "Reason")]
        public string Reason { get; set; }
        [JsonIgnore]
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
