using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieRecordsManagement.DAL.Domains;
using MovieRecordsManagement.DAL.Repositories;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;

namespace MovieRecordsManagement.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(MovieRecordInMemoryRepository.getInstance());
            services.AddMvc();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;
                options.ClientId = "mvc";
                options.Scope.Add("roles");
                options.SaveTokens = true;                
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanReadAndEditMovie", policy => policy.RequireClaim("role", User.ROLE_CONST.MANAGER, User.ROLE_CONST.TEAM_LEADER, User.ROLE_CONST.FLOOR_STAFF));
                options.AddPolicy("CanDeleteMovie", policy => policy.RequireClaim("role",User.ROLE_CONST.MANAGER));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Movie}/{action=Index}");
            });            
        }
    }
}
