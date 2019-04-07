﻿using IdentityServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentityServer()
                    .AddInMemoryClients(Clients.Get())
                    .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                    .AddInMemoryApiResources(Resources.GetApiResources())
                    .AddTestUsers(Users.Get())
                    .AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is the IdentityServer!");
            });
        }
    }
}
