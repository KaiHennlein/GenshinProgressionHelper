using GenshinProgressionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ApiTests
    {


        [Fact]
        public void TestCharacterCount()
        {
            int count = ApiCallsForCharacters.GetCharacterCountFromWebApi();
            Assert.True(count > 0);
        }
        [Fact]
        public void TestGetCharactersFromWebApi()
        {
            var list = ApiCallsForCharacters.GetCharacterListFromWebApi();
            Assert.True(list.Count > 0);
        }
        [Fact]
        public void TestGetWeaponsFromWebApi()
        {
            var list = ApiCallsForWeapons.GetWeaponsFromWebApi();
            Assert.True(list.Count > 0);
        }
    }
}
