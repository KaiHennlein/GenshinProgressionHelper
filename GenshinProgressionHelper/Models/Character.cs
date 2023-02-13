using SQLite;

namespace GenshinProgressionHelper
{
    [Table("characters")]
    public class Character
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        //
        //Character Details
        //
        public string Name { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public int Rarity { get; set; }
        public string Element { get; set; }
        public string Weapontype { get; set; }
        //
        //Links
        //
        public string PortraitLink { get; set; }
        public string IconLink { get; set; }
        public string WikiLink { get; set; }
        //
        //Ascention cost
        //
        public int MoraCount { get; set; }
        //
        public string GemstoneSliver { get; set; }
        public int GemstoneSliverCount { get; set; }
        public string GemstoneFragment { get; set; }
        public int GemstoneFragmentCount { get; set; }
        public string GemstoneChunk { get; set; }
        public int GemstoneChunkCount { get; set; }
        public string Gemstone { get; set; }
        public int GemstoneCount   { get; set; }
        //
        public string LocalSpecialty { get; set; }
        public int LocalSpecialtyCount { get; set; }
        //
        public string EnemyDropTier1 { get; set; }
        public int EnemyDropTier1Count { get; set; }
        public string EnemyDropTier2 { get; set; }
        public int EnemyDropTier2Count { get; set; }
        public string EnemyDropTier3 { get; set; }
        public int EnemyDropTier3Count { get; set; }
        //
        public string BossMaterial { get; set; }
        public int BossMaterialCount { get; set; }
        //
        //Level Up Cost
        //
        public int MoraLevelUpTo80Count
        {
        get { return 4939535; }
        }
        public int MoraLevelUpTo90Count
        {
            get { return 8362650; }
        }
        public int HerosWitTo80Count
        {
            get { return 245; }
        }
        public int HerosWitTo90Count
        {
            get { return 415; }
        }
        //
        //Talent Cost
        //
        public int MoraTalentCountLvl9 { get; set; }
        public int MoraTalentCountLvl10 { get; set; }
        //
        public string TalentTeachingType { get; set; }
        public int TalentTeachingCountLvl9 { get; set; }
        public string TalentGuideType { get; set; }
        public int TalentGuideCountLvl9 { get; set; }
        public string TalentPhilosophyType { get; set; }
        public int TalentPhilosophyCountLvl9 { get; set; }
        public int TalentPhilosophyCountLvl10 { get; set; }
        //
        public string TalentEnemyDropTier1 { get; set; }
        public int TalentEnemyDropTier1Count { get; set; }
        public string TalentEnemyDropTier2 { get; set; }
        public int TalentEnemyDropTier2Count { get; set; }
        public string TalentEnemyDropTier3 { get; set; }
        public int TalentEnemyDropTier3Lvl9Count { get; set; }
        public int TalentEnemyDropTier3Lvl10Count { get; set; }
        //
        public string TalentBossMaterial { get; set; }
        public int TalentBossMaterialCountLvl9 { get; set; }
        public int TalentBossMaterialCountvl10 { get; set; }
        //
        public string TalentDomain { get; set; }
        public string TalentDomainFirstDay { get; set; }
        public string TalentDomainSecondDay { get; set; }
        public string TalentDomainThirdDay { get; set; }
    }
}
