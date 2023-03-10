using Newtonsoft.Json;
using REST_API.APIUtils;
using REST_API.DataModels;
using REST_API.TestData;
using REST_API.Utils;
using System.Net;

namespace REST_API
{
    public class RestAPITests
    {
        private const int UserNumber = 4;
        private const int EmptyPostLength = 2;
        private const string Post99 = "99";
        private const string Post150 = "150";
        private const string User5 = "5";
        private const int LengthRandomString = 6;
        private const int UserId = 1;
        [Test]
        public void GetAllPosts()
        {
            Logger.LogInfo("GetAllPosts test begins");
            var response = RestUtils.GetAllPosts();
            Logger.LogInfo("Response was received from server");
            Assert.AreEqual((int)HttpStatusCode.OK, (int)response.StatusCode, "Status code is not 200");
            StringAssert.Contains(APIDataManager.contentType, response.ContentType, "This is not a list of jsons");
            Assert.AreEqual(ListUtil.AscendListId(ListUtil.ActualListId(response.Data)),
            ListUtil.ActualListId(response.Data), "The Ids are not in ascending order");
        }
        [Test]
        public void Get99Post()
        {
            Logger.LogInfo("Get99Post test begins");
            var response = RestUtils.GetCertainPost(Post99);
            Logger.LogInfo("Response was received from server");
            Assert.AreEqual((int)HttpStatusCode.OK, (int)response.StatusCode, "Status code is not 200");
            Assert.AreEqual(TestDataManager.userId, response.Data.UserId, "incorrect userId");
            Assert.AreEqual(TestDataManager.Id, response.Data.Id, "incorrect Id");
            Assert.IsNotEmpty(response.Data.Title, "title is empty");
            Assert.IsNotEmpty(response.Data.Body, "body is empty");
        }
        [Test]
        public void Get150Post()
        {
            Logger.LogInfo("Get150Post test begins");
            var response = RestUtils.GetCertainPost(Post150);
            Logger.LogInfo("Response was received from server");
            Assert.AreEqual((int)HttpStatusCode.NotFound, (int)response.StatusCode, "Status code is not 404");
            Assert.IsTrue(BoolUtil.StringthLengthLessThanNumber(response.Content, EmptyPostLength), "body is not empty");
        }
        [Test]
        public void PostNewUser()
        {
            Logger.LogInfo("PostNewUser test begins");
            var postModel = new PostUserDataModel(UserId, RandomGenerator.RandomString(LengthRandomString), RandomGenerator.RandomString(LengthRandomString));
            var response = RestUtils.PostNewUser(postModel);
            Logger.LogInfo("Response was received from server");
            var responseObject = JsonConvert.DeserializeObject<PostUserDataModel>(response.Content);
            Assert.AreEqual((int)HttpStatusCode.Created, (int)response.StatusCode, "Status code is not 201");
            Assert.AreEqual(postModel.Body, responseObject.Body, "Bodies are different");
            Assert.AreEqual(postModel.Title, responseObject.Title, "Titles are different");
            Assert.AreEqual(postModel.UserId, responseObject.UserId, "UserIds are different");
            Assert.IsNotNull(postModel.Id, "id is not present");
        }
        [Test]
        public void ComparisonUserDataFromList()
        {
            Logger.LogInfo("ComparisonUserDataFromList test begins");
            var response = RestUtils.GetUserDataFromList();
            Logger.LogInfo("Response was received from server");
            Assert.AreEqual((int)HttpStatusCode.OK, (int)response.StatusCode, "Status code is not 200");
            StringAssert.Contains(APIDataManager.contentType, response.ContentType, "This is not a list of jsons");
            Assert.IsTrue(JObjectUtil.ComparisonTwoJObjects(TestDataManager.getUserData, response.Data[UserNumber]), "Users are different");
        }
        [Test]
        public void ComparisonUserData()
        {
            Logger.LogInfo("ComparisonUserData test begins");
            var response = RestUtils.GetUserData(User5);
            Logger.LogInfo("Response was received from server");
            Assert.AreEqual((int)HttpStatusCode.OK, (int)response.StatusCode, "Status code is not 200");
            Assert.IsTrue(JObjectUtil.ComparisonTwoJObjects(TestDataManager.getUserData, JsonConvert.DeserializeObject<GetUserRoot>(response.Content)), "Users are different");
        }
    }
}