﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src;

namespace tests
{
    public class TestStartup
    {
        private readonly Startup inner;

        public TestStartup(IConfiguration configuration)
        {
            inner = new Startup(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            inner.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            inner.Configure(app, env);
        }
    }
}

