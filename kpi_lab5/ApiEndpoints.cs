using kpi_lab5.Models;
using RA;
using RestSharp;
using RestSharp.Authenticators;

namespace kpi_lab5
{
    public class ApiEndpoints
    {
        public static IRestResponse<UserModel> Login(string username, string password)
        {
            var client = new RestClient(Config.BASE_URL);
            var request = new RestRequest(Config.Auth, Method.POST);
            request.AddJsonBody(new {username, password});
            var response = client.Post<UserModel>(request);
            return response;
        }

        public static IRestResponse<Article> GetArticle(int articleId)
        {
            var client = new RestClient(Config.BASE_URL);
            var request = new RestRequest(Config.Articles + articleId);
            var response = client.Get<Article>(request);
            return response;
        }

        public static IRestResponse<Comment> PostComment(int articleId, string content)
        {
            var authToken = Login(Config.Username, Config.Password).Data.auth_token;
            var header = $"Bearer {authToken}";
            var client = new RestClient(Config.BASE_URL);
            var request = new RestRequest(Config.Comments, Method.POST);
            request.AddJsonBody(new {articleId, content});
            request.AddHeader("Authorization", header);
            var response = client.Post<Comment>(request);
            return response;
        }

        public static IRestResponse<Comment> UpdateComment(int commentId, string content)
        {
            var authToken = Login(Config.Username, Config.Password).Data.auth_token;
            var header = $"Bearer {authToken}";
            var client = new RestClient(Config.BASE_URL);
            var request = new RestRequest(Config.Comments + commentId, Method.PUT);
            request.AddJsonBody(new { content });
            request.AddHeader("Authorization", header);
            var response = client.Put<Comment>(request);
            return response;
        }

        public static IRestResponse<Comment> DeleteComment(int commentId)
        {
            var authToken = Login(Config.Username, Config.Password).Data.auth_token;
            var header = $"Bearer {authToken}";
            var client = new RestClient(Config.BASE_URL);
            var request = new RestRequest(Config.Comments + commentId, Method.DELETE);
            request.AddHeader("Authorization", header);
            var response = client.Delete<Comment>(request);
            return response;
        }


    }
}