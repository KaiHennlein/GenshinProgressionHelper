namespace GenshinProgressionHelper
{
    internal class JsonClassForWeapon
    {
        public string name { get; set; }
        public string description { get; set; }
        public string weapontype { get; set; }
        public int rarity { get; set; }
        public int baseatk { get; set; }
        public string substat { get; set; }
        public string subvalue { get; set; }
        public string effectname { get; set; }
        public string effect { get; set; }
        public List<string> r1 { get; set; }
        public List<string> r2 { get; set; }
        public List<string> r3 { get; set; }
        public List<string> r4 { get; set; }
        public List<string> r5 { get; set; }
        public string weaponmaterialtype { get; set; }
        public WeaponCosts costs { get; set; }
        public WeaponImages images { get; set; }
        public WeaponUrl url { get; set; }
        public string version { get; set; }
    }

    internal class WeaponAscend
    {
        public string name { get; set; }
        public int count { get; set; }
    }

    internal class WeaponCosts
    {
        public List<WeaponAscend> ascend1 { get; set; }
        public List<WeaponAscend> ascend2 { get; set; }
        public List<WeaponAscend> ascend3 { get; set; }
        public List<WeaponAscend> ascend4 { get; set; }
        public List<WeaponAscend> ascend5 { get; set; }
        public List<WeaponAscend> ascend6 { get; set; }
    }

    internal class WeaponImages
    {
        public string nameicon { get; set; }
        public string namegacha { get; set; }
        public string icon { get; set; }
        public string nameawakenicon { get; set; }
        public string awakenicon { get; set; }
    }

    internal class WeaponUrl
    {
        public string fandom { get; set; }
    }
}
