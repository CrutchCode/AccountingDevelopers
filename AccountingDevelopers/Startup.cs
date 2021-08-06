using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using DevelopersAccountingDatabase;
using Microsoft.EntityFrameworkCore;
using DevelopersAccountingDatabase.Models;
using Microsoft.AspNetCore.Identity;
using DevelopersAccountingDatabase.Repositories;
using DevelopersAccountingDatabase.Interfaces;
using AccountingDevelopersCore.Infrastructure;
using AutoMapper;
using AccountingDevelopersCore.MappingProfile;
using AccountingDevelopers.Models;

namespace AccountingDevelopers
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
            services.AddDbContext<DevelopersAccountingDbContex>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDbConnection"), 
                        m => m.MigrationsAssembly("DevelopersAccountingDatabase"));
            });
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<DevelopersAccountingDbContex>();
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<DataManager>();
            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfileModel));
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa => 
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
