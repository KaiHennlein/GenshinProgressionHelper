using SQLite;

namespace GenshinProgressionHelper
{
    public class CharacterDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public CharacterDatabase(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Character>();
        }

        public List<Character> GetAllCharacters()
        {
            Init();
            return conn.Table<Character>().ToList();
        }

        public Character GetCharacterByName(string characterName)
        {
            conn = new SQLiteConnection(_dbPath);
            List<Character> list = conn.Table<Character>().ToList();
            Character character = null;
            foreach (Character c in list)
            {
                if (c.Name == characterName)
                {
                    character = c;
                    break;
                }
            }
            return character;
        }

        public void Add(Character character)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(character);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete<Character>(id);
        }
    }
}
