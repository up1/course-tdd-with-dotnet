using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace tests
{
    public class ApiFixture : IDisposable
    {
        private readonly IHost server;
        public Uri ServerUri { get; }

        public ApiFixture()
        {
            ServerUri = new Uri("http://localhost:9001");
            server = Host.CreateDefaultBuilder()
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseUrls(ServerUri.ToString());
                                webBuilder.UseStartup<TestStartup>();
                            })
                            .Build();
            server.Start();
        }

        public void Dispose()
        {
            server.Dispose();
            foreach (var dataFile in Directory.GetFiles(Path.Combine("..", "..", "..", "data")))
            {
                File.Delete(dataFile);
            }
        }
    }
}

