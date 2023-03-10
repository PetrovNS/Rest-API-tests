using Newtonsoft.Json;

namespace REST_API.DataModels
{
    public class PostUserDataModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        public PostUserDataModel(int userId, string title, string body)
        {
            this.UserId = userId;
            this.Title = title;
            this.Body = body;
        }
        public PostUserDataModel() { }
    }
}


