using Newtonsoft.Json.Linq;
using REST_API.DataModels;

namespace REST_API.Utils
{
    public static class JObjectUtil
    {
        public static bool ComparisonTwoJObjects(GetUserRoot object1, GetUserRoot object2) => JToken.DeepEquals(JToken.FromObject(object1), JToken.FromObject(object2));
    }
}