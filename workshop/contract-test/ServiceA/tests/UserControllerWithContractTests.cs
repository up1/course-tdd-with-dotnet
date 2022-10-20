using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using PactNet.Verifier;
using src;

namespace tests
{
    public class UserControllerWithContractTests : IClassFixture<ApiFixture>
    {

        private readonly ApiFixture fixture;

        public UserControllerWithContractTests(ApiFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Get_User_By_Id_with_contract()
        {
            // Arrange
            var config = new PactVerifierConfig();
            IPactVerifier pactVerifier = new PactVerifier(config);

          
            // Act and Assert
            var pactPath = "/Users/somkiat/data/slide/TDD/2022/NIMBLE/workshop/contract-test/Consumer1/pacts/Consumer1-ServiceA.json";
            pactVerifier
                .ServiceProvider("ServiceA", fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .Verify();
        }
    }
}

