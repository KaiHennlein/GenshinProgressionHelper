using SQLite;

namespace GenshinProgressionHelper
{
    public class UserDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public UserDatabase(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<UserEntry>();
        }

        public List<UserEntry> GetAllEntries()
        {
            Init();
            return conn.Table<UserEntry>().ToList();
        }

        public void Add(UserEntry userEntries)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(userEntries);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete<UserEntry>(id);
        }

        public UserEntry GetByCharacterName(string characterName) 
        {
            conn = new SQLiteConnection(_dbPath);
            List<UserEntry> list = conn.Table<UserEntry>().ToList();
            UserEntry entry = null;
            foreach (UserEntry userEntry in list)
            {
                if (userEntry.CharacterName == characterName)
                {
                    entry = userEntry;
                    break;
                }
            }
            return entry;
        }

        public void Update(UserEntry userEntries)
        {
            conn= new SQLiteConnection(_dbPath);
            conn.Update(userEntries);
        }
    }
}
