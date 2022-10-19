using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace tests
{
    public class TestApplication: WebApplicationFactory<Program>
    {

        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder);
        }

    }
}

