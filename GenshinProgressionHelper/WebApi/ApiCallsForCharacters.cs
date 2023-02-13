using Newtonsoft.Json;

namespace GenshinProgressionHelper
{
    public class ApiCallsForCharacters
    {
        static HttpClient client = new HttpClient();
        
        public static int GetCharacterCountFromWebApi()
        {
            return GetCharacterCountAsync().GetAwaiter().GetResult();
        }

        private static async Task<int> GetCharacterCountAsync()
        {
            List<string> characterNameList = new List<string>();
            try
            {
                characterNameList = await GetCharactersAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return characterNameList.Count - 2;
        }
        
        public static List<Character> GetCharacterListFromWebApi()
        {
            return GetCharacterListAsync().GetAwaiter().GetResult();
        }

        private static async Task<List<Character>> GetCharacterListAsync()
        {
            List<string> characterNameList = new List<string>();
            List<JsonClassForCharacter> characterDetailsList = new List<JsonClassForCharacter>();
            List<JsonClassforCharacterTalents> characterTalentsList = new List<JsonClassforCharacterTalents>();
            List<Character> characterList = new List<Character>();

            try
            {
                //Gets a list of all characters from an WebApi
                characterNameList = await GetCharactersAsync();
                //Gets the detailed information about every character
                characterDetailsList = await GetCharacterDetailsAsync(characterNameList);
                //Gets the talents with costs for all characters
                characterTalentsList = await GetCharacterTalentsAsync(characterNameList);
                //Combines character details and talents as well as dump all unnesscary values 
                var talentMaterials = ApiCallsForCharacters.GetTalentMaterialTypes();
                characterList = ListFunctions.MergeCharacterLists(characterDetailsList, characterTalentsList, talentMaterials);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return characterList;
        }

        private static async Task<List<string>>  GetCharactersAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://genshin-db-api.vercel.app/api/characters?query=names&matchCategories=true");
            List<string> contend = await response.Content.ReadAsAsync<List<string>>();

            return contend;
        }

        private static async Task<List<JsonClassForCharacter>> GetCharacterDetailsAsync(List<string> characters)
        {
            string baseUrl = "https://genshin-db-api.vercel.app/api/characters?query=";

            List<JsonClassForCharacter> characterList = new List<JsonClassForCharacter>();

            foreach (string c in characters)
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + c);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonClassForCharacter characterDetails = JsonConvert.DeserializeObject<JsonClassForCharacter>(jsonString);
                characterList.Add(characterDetails);
            }

            return characterList;
        }

        private static async Task<List<JsonClassforCharacterTalents>> GetCharacterTalentsAsync(List<string> characters)
        {
            string baseUrl = "https://genshin-db-api.vercel.app/api/talents?query=";

            List<JsonClassforCharacterTalents> characterTalentsList = new List<JsonClassforCharacterTalents>();

            foreach (string c in characters)
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + c);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonClassforCharacterTalents characterTalents = JsonConvert.DeserializeObject<JsonClassforCharacterTalents>(jsonString);
                characterTalentsList.Add(characterTalents);
            }

            return characterTalentsList;
        }

        internal static List<JsonClassForTalentMaterialTypes> GetTalentMaterialTypes()
        {
            return GetTalentMaterialTypesAsync().GetAwaiter().GetResult();
        }

        private static async Task<List<JsonClassForTalentMaterialTypes>> GetTalentMaterialTypesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("https://genshin-db-api.vercel.app/api/talentmaterialtypes?query=names&matchCategories=true");
            List<string> contend = await response.Content.ReadAsAsync<List<string>>();

            string baseUrl = "https://genshin-db-api.vercel.app/api/talentmaterialtypes?query=";

            var talentMaterialTypes = new List<JsonClassForTalentMaterialTypes>();

            foreach (string w in contend)
            {
                HttpResponseMessage response2 = await client.GetAsync(baseUrl + w);
                string jsonString = await response2.Content.ReadAsStringAsync();
                JsonClassForTalentMaterialTypes talentMaterialType = JsonConvert.DeserializeObject<JsonClassForTalentMaterialTypes>(jsonString);
                talentMaterialTypes.Add(talentMaterialType);
            }

            return talentMaterialTypes;
        }

    }
}
