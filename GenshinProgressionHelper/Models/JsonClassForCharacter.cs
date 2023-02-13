using Newtonsoft.Json;

namespace GenshinProgressionHelper
{
    internal class JsonClassForCharacter
    {
        public string name { get; set; }
        public string fullname { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int rarity { get; set; }
        public string element { get; set; }
        public string weapontype { get; set; }
        public string substat { get; set; }
        public string gender { get; set; }
        public string body { get; set; }
        public string association { get; set; }
        public string region { get; set; }

        [JsonIgnore]
        public string affiliation { get; set; }

        [JsonIgnore]
        public string birthdaymmdd { get; set; }

        [JsonIgnore]
        public string birthday { get; set; }

        [JsonIgnore]
        public string constellation { get; set; }

        [JsonIgnore]
        public Cv cv { get; set; }

        public Costs costs { get; set; }
        public Images images { get; set; }
        public Url url { get; set; }

        [JsonIgnore]
        public string version { get; set; }
    }

    internal class Cv
    {
        public string english { get; set; }
        public string chinese { get; set; }
        public string japanese { get; set; }
        public string korean { get; set; }
    }

    internal class Costs
    {
        public List<Ascend> ascend1 { get; set; }
        public List<Ascend> ascend2 { get; set; }
        public List<Ascend> ascend3 { get; set; }
        public List<Ascend> ascend4 { get; set; }
        public List<Ascend> ascend5 { get; set; }
        public List<Ascend> ascend6 { get; set; }
    }

    internal class Ascend
    {
        public string name { get; set; }
        public int count { get; set; }
    }

    internal class Images
    {
        public string card { get; set; }
        public string portrait { get; set; }
        public string icon { get; set; }
        public string sideicon { get; set; }
        public string cover1 { get; set; }
        public string cover2 { get; set; }

        [JsonProperty("hoyolab-avatar")]
        public string hoyolabavatar { get; set; }
        public string nameicon { get; set; }
        public string nameiconcard { get; set; }
        public string namegachasplash { get; set; }
        public string namegachaslice { get; set; }
        public string namesideicon { get; set; }
    }
    internal class Url
    {
        public string fandom { get; set; }
    }
}
