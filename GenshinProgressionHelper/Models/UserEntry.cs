using SQLite;

namespace GenshinProgressionHelper
{
    [Table("userEntries")]
    public class UserEntry
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string WeapponName { get; set; }
        public DateTime LastFarmingDate { get; set; }
    }
}
