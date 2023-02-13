using Newtonsoft.Json;

namespace GenshinProgressionHelper
{
    internal class JsonClassForWeaponMaterialTypes
    {
        public string name { get; set; }

        [JsonProperty("2starname")]
        public string _2starname { get; set; }

        [JsonProperty("3starname")]
        public string _3starname { get; set; }

        [JsonProperty("4starname")]
        public string _4starname { get; set; }

        [JsonProperty("5starname")]
        public string _5starname { get; set; }
        public List<string> day { get; set; }
        public string location { get; set; }
        public string region { get; set; }
        public string domainofforgery { get; set; }
        public string version { get; set; }
    }
}
