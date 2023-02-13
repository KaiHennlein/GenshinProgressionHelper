namespace GenshinProgressionHelper
{
    internal class Functions
    {
        //Character Database Functions
        public static void FillCharacterDatabase()
        {
            ClearCharacterDatabase();
            List<Character> characters = ApiCallsForCharacters.GetCharacterListFromWebApi();

            foreach (Character character in characters)
            {
                App.CharacterDatabase.Add(character);
            }
        }

        private static void ClearCharacterDatabase()
        {
            List<Character> characters = App.CharacterDatabase.GetAllCharacters();
            foreach (Character character in characters)
            {
                App.CharacterDatabase.Delete(character.Id);
            }
        }

        //Weapon Database Functions
        public static void FillWeaponDatabase()
        {
            ClearWeaponDatabase();
            List<Weapon> weapons = ApiCallsForWeapons.GetWeaponsFromWebApi();
            foreach (Weapon weapon in weapons)
            {
                App.WeaponDatabase.Add(weapon);
            }
        }

        private static void ClearWeaponDatabase()
        {
            List<Weapon> weapons = App.WeaponDatabase.GetAllWeapons();
            foreach (Weapon weapon in weapons)
            {
                App.WeaponDatabase.Delete(weapon.Id);
            }
        }

        //User Database Functions
        private static void ClearUserDatabase()
        {
            List<UserEntry> userEntries = App.UserDatabase.GetAllEntries();
            foreach (UserEntry userEntry in userEntries)
            {
                App.UserDatabase.Delete(userEntry.Id);
            }
        }

        public static bool DoesEntryAlreadyExist(string characterName)
        {
            List<UserEntry> userEntries = App.UserDatabase.GetAllEntries();
            return userEntries.Any<UserEntry>(item => item.CharacterName == characterName); 
        }

        //Clears all databases for debug purposes
        public static void ClearAllDatabases()
        {
            ClearCharacterDatabase();
            ClearWeaponDatabase();
            ClearUserDatabase();
        }

        /*
        public static async Task CheckDatabaseForUpdates()
        {
            int dbCount = App.CharacterDatabase.GetAllCharacters().Count;
            await Task.Run(() => ApiCallsForCharacters.GetCharacterCountFromWebApi()).ContinueWith(c =>
            {
                if (dbCount != c.Result)
                {
                    Functions.FillCharacterDatabase();
                    Functions.FillWeaponDatabase();
                }
            });
        }
        */

        //Checks for new Characters on the start of the App
        public static void CheckDatabaseForUpdates(string dbPathCharacters, string dbPathWeapons)
        {
            CharacterDatabase characterDatabase = new CharacterDatabase(dbPathCharacters);
            WeaponDatabase weaponDatabase = new WeaponDatabase(dbPathWeapons);
            int dbCountC = characterDatabase.GetAllCharacters().Count();
            int dbCountW = weaponDatabase.GetAllWeapons().Count();
            
            Task.Run(async () =>
            {
                await Task.Run(() => ApiCallsForCharacters.GetCharacterCountFromWebApi()).ContinueWith(c =>
                {
                    if (dbCountC != c.Result)
                    {
                        List<Character> characters = new List<Character>();
                        List<Weapon> weapons = new List<Weapon>();

                        //Clear old Entries
                        characters = characterDatabase.GetAllCharacters();
                        weapons = weaponDatabase.GetAllWeapons();

                        foreach (Character character in characters)
                        {
                            characterDatabase.Delete(character.Id);
                        }

                        foreach (Weapon weapon in weapons)
                        {
                            weaponDatabase.Delete(weapon.Id);
                        }

                        //Create new Entries
                        characters = ApiCallsForCharacters.GetCharacterListFromWebApi();
                        weapons = ApiCallsForWeapons.GetWeaponsFromWebApi();

                        foreach (Character character in characters)
                        {
                            characterDatabase.Add(character);
                        }

                        foreach (Weapon weapon in weapons)
                        {
                            weaponDatabase.Add(weapon);
                        }
                    }
                });
            }).Wait();
        }
    }
}
