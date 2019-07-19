using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using KB.Application;
using KB.Web.Host.Controllers;
using KB.Web.Host.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KB.Web.Host
{
    public class Startup
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            var express = new AutoMapper.Configuration.MapperConfigurationExpression();
            express.AddProfile<DtoMappings>();
            Mapper.Initialize(express);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Setup component model contributors for making windsor services available to IServiceProvider
            Container.AddFacility<AspNetCoreFacility>(f => f.CrossWiresInto(services));

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

   
            RegisterApplicationComponents(services);

            services.AddCors(optiosn =>
            {
                optiosn.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services.AddWindsor(Container,
                 opts => opts.UseEntryAssembly(typeof(HomeController).Assembly), // <- Recommended
                 () => services.BuildServiceProvider(validateScopes: false));

            //return new ServiceResolver(services);
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



            Container.GetFacility<AspNetCoreFacility>().RegistersMiddlewareInto(app);

            // Add custom middleware, do this if your middleware uses DI from Windsor
       
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Article}/{action=Index}/{id?}");
            });
        }
        private void RegisterApplicationComponents(IServiceCollection services)
        {
            // Application components
            Container.Register(Component.For<IHttpContextAccessor>().ImplementedBy<HttpContextAccessor>());
            Container.Install(new KBInstaller());

        }
    }
}
