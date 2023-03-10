using Newtonsoft.Json.Linq;

namespace REST_API.APIUtils
{
    public static class APIDataManager
    {
        private static string pathToAPIData = File.ReadAllText("Resources\\APIData.json");
        public static JObject APIData = JObject.Parse(pathToAPIData);
        public static string mainURL = (string)APIData["MainUrl"];
        public static string getAllPosts = (string)APIData["GetAllPosts"];
        public static string getAllUsers = (string)APIData["GetAllUsers"];
        public static string getPost = (string)APIData["GetPost"];
        public static string getUser = (string)APIData["GetUser"];
        public static string contentType = (string)APIData["ContentType"];
    }
}
