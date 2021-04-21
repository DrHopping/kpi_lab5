using System;
using System.Net;
using System.Threading.Channels;
using RA;
using Xunit;

namespace kpi_lab5
{
    public class AppTests
    {
        //GET
        [Fact]
        public void GetArticleWithExistingIdShouldReturn200()
        {
            var response = ApiEndpoints.GetArticle(1);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //GET
        [Fact]
        public void GetArticleWithNotExistingIdShouldReturn404()
        {
            var response = ApiEndpoints.GetArticle(999);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        //POST
        [Fact]
        public void LoginWithCorrectUsernameAndPassword()
        {
            var response = ApiEndpoints.Login(Config.Username, Config.Password);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        //POST
        [Fact]
        public void CreateNewComment()
        {
            var content = "Test Comment";
            var articleId = 1;
            var response = ApiEndpoints.PostComment(articleId, content);
            Assert.Equal(content, response.Data.Content);
        }

        //PUT
        [Fact]
        public void UpdateComment()
        {
            //Create comment
            var content = "Test Comment";
            var articleId = 1;
            var createdCommentId = ApiEndpoints.PostComment(articleId, content).Data.Id;

            //Update comment
            var contentUpdate = "Test Comment Updated";
            var response = ApiEndpoints.UpdateComment(createdCommentId, contentUpdate);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        //DELETE
        [Fact]
        public void DeleteComment()
        {
            //Create comment
            var content = "Test Comment";
            var articleId = 1;
            var createdCommentId = ApiEndpoints.PostComment(articleId, content).Data.Id;

            //Delete comment
            var response = ApiEndpoints.DeleteComment(createdCommentId);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
