using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.API
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root
    {
        public string Type { get; set; }
        public string Context { get; set; }
        public string themeColor { get; set; }
        public string summary { get; set; }
        public List<Section> sections { get; set; }
        public List<PotentialAction> potentialAction { get; set; }
    }
    public class Section
    {
        public string activityTitle { get; set; }
        public string activitySubtitle { get; set; }
        public string activityImage { get; set; }
        public List<Fact> facts { get; set; }
        public bool markdown { get; set; }
    }
    public class Fact
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class PotentialAction
    {
        public string Type { get; set; }
        public string name { get; set; }
        public List<Input> inputs { get; set; }
        public List<Action> actions { get; set; }
    }
    public class Input
    {
        public string Type { get; set; }
        public string id { get; set; }
        public bool isMultiline { get; set; }
        public string title { get; set; }
        public string isMultiSelect { get; set; }
        public List<Choice> choices { get; set; }
    }
    public class Choice
    {
        public string display { get; set; }
        public string value { get; set; }
    }
    public class Action
    {
        public string Type { get; set; }
        public string name { get; set; }
        public string target { get; set; }
    }



}
