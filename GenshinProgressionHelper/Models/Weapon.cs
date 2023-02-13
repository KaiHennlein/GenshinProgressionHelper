using SQLite;

namespace GenshinProgressionHelper
{
    [Table("weapons")]
    public class Weapon
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //
        //Weapon details
        //
        public string Name { get; set; }
        public string Weapontype { get; set; }
        public int Rarity  { get; set; }
        public int BaseAtk { get; set; }
        public string SubStat { get; set; }
        //
        //Links
        //
        public string IconLink { get; set; }
        public string AwakenIconLink { get; set; }
        public string WikiLink { get; set; }
        //
        //Weapon level up cost
        //
        public int MoraCount { get; set; }
        public int MysticOreCount { get; set; }
        //
        //Weapon ascention cost
        //
        public int AscentionMoraCost { get; set; }
        //
        public string WeaponMaterialType { get; set; }
        public string WeaponDomain { get; set; }
        public string WeaponDomainFirstDay { get; set; }
        public string WeaponDomainSecondDay { get; set; }
        public string WeaponDomainThirdDay { get; set; }
        //
        public string WeaponDomainTier2 { get; set; }
        public int WeaponDomainTier2Cost { get; set; }
        public string WeaponDomainTier3 { get; set; }
        public int WeaponDomainTier3Cost { get; set; }
        public string WeaponDomainTier4 { get; set; }
        public int WeaponDomainTier4Cost { get; set; }
        public string WeaponDomainTier5 { get; set; }
        public int WeaponDomainTier5Cost { get; set; }
        //
        public string FirstEnemyDropTier2 { get; set; }
        public int FirstEnemyDropTier2Cost { get; set; }
        public string FirstEnemyDropTier3 { get; set; }
        public int FirstEnemyDropTier3Cost { get; set; }
        public string FirstEnemyDropTier4 { get; set; }
        public int FirstEnemyDropTier4Cost { get; set; }
        //
        public string SecondEnemyDropTier1 { get; set; }
        public int SecondEnemyDropTier1Cost { get; set; }
        public string SecondEnemyDropTier2 { get; set; }
        public int SecondEnemyDropTier2Cost { get; set; }
        public string SecondEnemyDropTier3 { get; set; }
        public int SecondEnemyDropTier3Cost { get; set; }
    }
}
