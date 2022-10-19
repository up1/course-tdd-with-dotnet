using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using src;

namespace tests
{
    public class UserControllerTests
    {

        [Fact]
        public async Task Get_User_By_Id()
        {
            // Arrange
            var application = new TestApplication();
            var client = application.CreateClient();
            // Act
            var response = await client.GetAsync("/api/user/1");
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            var contentType = response.Content.Headers.ContentType!.MediaType;
            Assert.Equal("application/json", contentType);

            var json = await response.Content.ReadAsStreamAsync();
            User? user = await System.Text.Json.JsonSerializer.DeserializeAsync<User>(json, new System.Text.Json.JsonSerializerOptions {PropertyNameCaseInsensitive = true });
            Assert.Equal(1, user!.Id);
            Assert.Equal("Somkiat", user.Name);
            Assert.Equal(30, user.Age);
        }
    }
}

