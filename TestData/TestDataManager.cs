using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using REST_API.DataModels;

namespace REST_API.TestData
{
    public static class TestDataManager
    {
        private static string pathToMainData = File.ReadAllText("Resources\\MainData.json");
        public static JObject testData = JObject.Parse(pathToMainData);
        public static int userId = (int)testData["userId"];
        public static int Id = (int)testData["Id"];
        public static string pathToGetUserData = File.ReadAllText((string)testData["pathToGetUserData"]);
        public static GetUserRoot getUserData = JsonConvert.DeserializeObject<GetUserRoot>(pathToGetUserData);
    }
}