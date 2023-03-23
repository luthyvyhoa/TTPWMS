using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DA.JsonObjects
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Target
    {
        public string os { get; set; }
        public string uri { get; set; }
    }

    public class PotentialAction
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        public string name { get; set; }
        public List<Target> targets { get; set; }
    }

    public class Fact
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Section
    {
        public List<Fact> facts { get; set; }
        public string text { get; set; }
    }

    public class Root
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        [JsonProperty("@type")]
        public string Type { get; set; }
        public List<PotentialAction> potentialAction { get; set; }
        public List<Section> sections { get; set; }
        public string summary { get; set; }
        public string themeColor { get; set; }
        public string title { get; set; }
    }



}
