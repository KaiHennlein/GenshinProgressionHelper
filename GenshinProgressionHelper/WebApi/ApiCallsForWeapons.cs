using Newtonsoft.Json;

namespace GenshinProgressionHelper
{
    public class ApiCallsForWeapons
    {
        static HttpClient client = new HttpClient();

        public static List<Weapon> GetWeaponsFromWebApi()
        {
            var weaponsList = GetWeaponDetailsAsync().GetAwaiter().GetResult();
            var weaponMaterialTypes = GetWeaponMaterialTypesAsync().GetAwaiter().GetResult();
            return ListFunctions.ConvertWeaponList(weaponsList, weaponMaterialTypes);
        }

        private static async Task<List<JsonClassForWeapon>> GetWeaponDetailsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://genshin-db-api.vercel.app/api/weapons?query=names&matchCategories=true");
            List<string> contend = await response.Content.ReadAsAsync<List<string>>();

            string baseUrl = "https://genshin-db-api.vercel.app/api/weapons?query=";

            var weaponList = new List<JsonClassForWeapon>();

            try
            {
                foreach (string w in contend)
                {
                    HttpResponseMessage response2 = await client.GetAsync(baseUrl + w);
                    string jsonString = await response2.Content.ReadAsStringAsync();
                    JsonClassForWeapon weaponDetails = JsonConvert.DeserializeObject<JsonClassForWeapon>(jsonString);
                    weaponList.Add(weaponDetails);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return weaponList;
        }

        private static async Task<List<JsonClassForWeaponMaterialTypes>> GetWeaponMaterialTypesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://genshin-db-api.vercel.app/api/weaponmaterialtypes?query=names&matchCategories=true");
            List<string> contend = await response.Content.ReadAsAsync<List<string>>();

            string baseUrl = "https://genshin-db-api.vercel.app/api/weaponmaterialtypes?query=";

            var weaponMaterialTypes = new List<JsonClassForWeaponMaterialTypes>();

            try
            {
                foreach (string w in contend)
                {
                    HttpResponseMessage response2 = await client.GetAsync(baseUrl + w);
                    string jsonString = await response2.Content.ReadAsStringAsync();
                    JsonClassForWeaponMaterialTypes weaponMaterialType = JsonConvert.DeserializeObject<JsonClassForWeaponMaterialTypes>(jsonString);
                    weaponMaterialTypes.Add(weaponMaterialType);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return weaponMaterialTypes;
        }
    }
}
