using REST_API.DataModels;

namespace REST_API.Utils
{
    public static class ListUtil
    {
        public static List<int> ActualListId(List<PostUserDataModel> list) => list.Select(x => x.Id).ToList();

        public static List<int> AscendListId(List<int> list) => list.OrderBy(x => x).ToList();
    }
}
