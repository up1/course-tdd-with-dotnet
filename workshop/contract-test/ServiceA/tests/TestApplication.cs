using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using src;

namespace tests
    {
        public class TestApplication: WebApplicationFactory<Program>
        {
            public Uri serverUri { get; set; }

            public TestApplication()
            {
                    this.serverUri = new Uri("http://localhost:9005");
            }

            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                builder.UseSetting("urls", this.serverUri.ToString());
                //builder.UseSetting("https_port", "9005");
            }

            protected override IHost CreateHost(IHostBuilder builder)
            {
                return base.CreateHost(builder);
            }

        }
    }

