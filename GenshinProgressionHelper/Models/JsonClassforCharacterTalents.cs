using Newtonsoft.Json;

namespace GenshinProgressionHelper
{
    internal class JsonClassforCharacterTalents
    {
        public string name { get; set; }

        [JsonIgnore]
        public Combat1 combat1 { get; set; }

        [JsonIgnore]
        public Combat2 combat2 { get; set; }

        [JsonIgnore]
        public Combat3 combat3 { get; set; }

        [JsonIgnore]
        public Passive1 passive1 { get; set; }

        [JsonIgnore]
        public Passive2 passive2 { get; set; }

        [JsonIgnore]
        public Passive3 passive3 { get; set; }
    
        public TalentCosts costs { get; set; }
        public TalentImages images { get; set; }

        [JsonIgnore]
        public string version { get; set; }
    }

    internal class Parameters
    {
        public List<double> param1 { get; set; }
        public List<double> param2 { get; set; }
        public List<double> param3 { get; set; }
        public List<double> param4 { get; set; }
        public List<double> param5 { get; set; }
        public List<double> param6 { get; set; }
        public List<double> param7 { get; set; }
        public List<double> param8 { get; set; }
        public List<double> param9 { get; set; }
        public List<double> param10 { get; set; }
    }

    internal class Attributes
    {
        public List<string> labels { get; set; }
        public Parameters parameters { get; set; }
    }

    internal class Combat1
    {
        public string name { get; set; }
        public string info { get; set; }
        public Attributes attributes { get; set; }
    }

    internal class Combat2
    {
        public string name { get; set; }
        public string info { get; set; }
        public string description { get; set; }
        public Attributes attributes { get; set; }
    }

    internal class Combat3
    {
        public string name { get; set; }
        public string info { get; set; }
        public string description { get; set; }
        public Attributes attributes { get; set; }
    }

    internal class Passive1
    {
        public string name { get; set; }
        public string info { get; set; }
    }

    internal class Passive2
    {
        public string name { get; set; }
        public string info { get; set; }
    }

    internal class Passive3
    {
        public string name { get; set; }
        public string info { get; set; }
    }

    internal class TalentCosts
    {
        public List<Lvl> lvl2 { get; set; }
        public List<Lvl> lvl3 { get; set; }
        public List<Lvl> lvl4 { get; set; }
        public List<Lvl> lvl5 { get; set; }
        public List<Lvl> lvl6 { get; set; }
        public List<Lvl> lvl7 { get; set; }
        public List<Lvl> lvl8 { get; set; }
        public List<Lvl> lvl9 { get; set; }
        public List<Lvl> lvl10 { get; set; }
    }

    internal class TalentImages
    {
        public string combat1 { get; set; }
        public string combat2 { get; set; }
        public string combat3 { get; set; }
        public string passive1 { get; set; }
        public string passive2 { get; set; }
        public string passive3 { get; set; }
    }

    internal class Lvl
    {
        public string name { get; set; }
        public int count { get; set; }
    }
}
