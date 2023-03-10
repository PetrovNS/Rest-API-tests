using REST_API.APIUtils;
using REST_API.DataModels;
using RestSharp;

namespace REST_API.Utils
{
    public static class RestUtils
    {
        private static IRestClient restClient = new RestClient(APIDataManager.mainURL);

        public static IRestResponse<List<PostUserDataModel>> GetAllPosts()
        {
            IRestRequest restRequest = new RestRequest(APIDataManager.getAllPosts);
            return restClient.Get<List<PostUserDataModel>>(restRequest);
        }
        public static IRestResponse<PostUserDataModel> GetCertainPost(string postNumber)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.getPost, postNumber));
            return restClient.Get<PostUserDataModel>(restRequest);
        }
        public static IRestResponse PostNewUser(PostUserDataModel userData)
        {
            IRestRequest restRequest = new RestRequest(APIDataManager.getAllPosts);
            restRequest.AddJsonBody(userData);
            return restClient.Post(restRequest);
        }
        public static IRestResponse<List<GetUserRoot>> GetUserDataFromList()
        {
            IRestRequest restRequest = new RestRequest(APIDataManager.getAllUsers);
            return restClient.Get<List<GetUserRoot>>(restRequest);
        }
        public static IRestResponse<GetUserRoot> GetUserData(string userNumber)
        {
            IRestRequest restRequest = new RestRequest(string.Format(APIDataManager.getUser, userNumber));
            return restClient.Get<GetUserRoot>(restRequest);
        }
    }
}