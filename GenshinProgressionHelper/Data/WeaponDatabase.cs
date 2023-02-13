using SQLite;

namespace GenshinProgressionHelper
{
    public class WeaponDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public WeaponDatabase(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Weapon>();
        }

        public List<Weapon> GetAllWeapons()
        {
            Init();
            return conn.Table<Weapon>().ToList();
        }

        public Weapon GetWeaponByName(string weaponName)
        {
            conn = new SQLiteConnection(_dbPath);
            List<Weapon> list = conn.Table<Weapon>().ToList();
            Weapon weapon = null;
            foreach (Weapon w in list)
            {
                if (w.Name == weaponName)
                {
                    weapon = w;
                    break;
                }
            }
            return weapon;
        }

        public void Add(Weapon weapon)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(weapon);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete<Weapon>(id);
        }
    }
}
