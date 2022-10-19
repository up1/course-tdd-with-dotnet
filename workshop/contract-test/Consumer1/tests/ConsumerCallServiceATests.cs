using System;
using System.Net;
using PactNet;
using src;

namespace tests
{
    public class ConsumerCallServiceATests
    {

        private readonly IPactBuilderV3 pactBuilder;

        public ConsumerCallServiceATests()
        {
            // Use default pact directory ..\..\pacts and default log
            // directory ..\..\logs
            var pact = Pact.V3("Consuner 1", "Service A", new PactConfig());

            // or specify custom log and pact directories
            pact = Pact.V3("Consuner 1", "Service A", new PactConfig
            {
                PactDir = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}{Path.DirectorySeparatorChar}pacts"
            });

            // Initialize Rust backend
            this.pactBuilder = pact.WithHttpInteractions();
        }

        [Fact]
        public async Task GetSomething_WhenTheTesterSomethingExists_ReturnsTheSomething()
        {
            // Arrange
            this.pactBuilder
                .UponReceiving("A GET request to get user")
                    .Given("Get user by id '1'")
                    .WithRequest(HttpMethod.Get, "/api/user/1")
                .WillRespond()
                    .WithStatus(HttpStatusCode.OK)
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithJsonBody(new 
                    {
                        Id = 1,
                        Name = "Mock name",
                        Age = 99
                    });

            await this.pactBuilder.VerifyAsync(async ctx =>
            {
                // Act
                var client = new ServiceAGateway(ctx.MockServerUri.ToString());
                var response = await client.CallApi(1);

                // Assert
                response.EnsureSuccessStatusCode();
                var contentType = response.Content.Headers.ContentType!.MediaType;
                Assert.Equal("application/json", contentType);

                var json = await response.Content.ReadAsStreamAsync();
                User? user = await System.Text.Json.JsonSerializer.DeserializeAsync<User>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Assert.Equal(1, user!.Id);
                Assert.Equal("Mock name", user.Name);
                Assert.Equal(99, user.Age);
            });
        }


    }
}

