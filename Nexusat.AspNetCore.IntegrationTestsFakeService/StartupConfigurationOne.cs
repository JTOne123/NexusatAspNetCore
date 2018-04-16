﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nexusat.AspNetCore.IntegrationTestsFakeService
{
    public class StartupConfigurationOne
    {
        public StartupConfigurationOne(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddNexusatAspNetCore(c =>
                {
                    c.EnableRuntimeProfilation();
                    c.SetDefaultOkStatus("OK_TEST_DEFAULT");
                    c.SetDefaultKoStatus("KO_TEST_DEDFAULT");

                    c.SetPaginationPageSizeName("p_sz");
                    c.SetPaginationPageIndexName("p_ix");
                    c.SetPaginationDefaultPageSize(6);
                    c.SetPaginationDefaultMaxPageSize(66);
                    c.SetPaginationDefaultBadRequestOnPageSizeOverflow(true);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseNexusatAspNetCoreExceptionHandling();
            app.UseMvc();
            app.UseNexusatAspNetCore();
        }
    }
}
