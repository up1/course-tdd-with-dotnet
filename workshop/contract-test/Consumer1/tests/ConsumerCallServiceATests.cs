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
            var pact = Pact.V3("Consumer-Somkiat", "ServiceA", new PactConfig());

            // or specify custom log and pact directories
            pact = Pact.V3("Consumer-Somkiat", "ServiceA", new PactConfig
            {
                PactDir = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}{Path.DirectorySeparatorChar}pacts"
            });

            // Initialize Rust backend
            this.pactBuilder = pact.WithHttpInteractions();
        }

        [Fact]
        public async Task User_Found_With_Id_1()
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
                        id = 1,
                        name = "Mock name",
                        age = 99
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

        [Fact]
        public async Task User_Not_Found_With_Id_2()
        {
            // Arrange
            this.pactBuilder
                .UponReceiving("User not found")
                    .Given("User not found")
                    .WithRequest(HttpMethod.Get, "/api/user/2")
                .WillRespond()
                    .WithStatus(HttpStatusCode.NotFound);

            await this.pactBuilder.VerifyAsync(async ctx =>
            {
                // Act
                var client = new ServiceAGateway(ctx.MockServerUri.ToString());
                var response = await client.CallApi(2);
                // Assert
                Assert.Equal(404, ((int)response.StatusCode));
            });
        }


    }
}

