using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using EShop;
using EShop.MAdmin;
using System.Reflection;
using EShop.Models;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.StaticFiles;

namespace EShop
{
    public class Startup
    {
  
        private static List<CommonHandler> Handlers = new List<CommonHandler>();
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EShopContext>();
            services.AddSingleton<IJWTHandler, JWTHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var sp = services.BuildServiceProvider();
            var JWTHandler = sp.GetRequiredService<IJWTHandler>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ExceptionResponseAttribute()); // an instance
                options.Filters.Add(new AuthenticationFilter(Configuration, JWTHandler));
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            });
            services.Scan(scan => scan
                .FromAssemblyOf<ITransientService>()
                    .AddClasses(classes => classes.AssignableTo<ITransientService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IScopedService>())
                        .As<IScopedService>()
                        .WithScopedLifetime());
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            using (var IisUrlRewriteStreamReader =
                File.OpenText("IISUrlRewrite.xml"))
            {
                var Options = new RewriteOptions()
                    .AddIISUrlRewrite(IisUrlRewriteStreamReader);
                app.UseRewriter(Options);
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Views")),
                RequestPath = "/Views"
            });

            var imageProvider = new FileExtensionContentTypeProvider();
            imageProvider.Mappings.Clear();
            imageProvider.Mappings[".png"] = "image/png";
            imageProvider.Mappings[".jpeg"] = "image/jpeg";
            imageProvider.Mappings[".jpg"] = "image/jpg";

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Files")),
                RequestPath = "/Files",
                ContentTypeProvider = imageProvider
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Files")),
                RequestPath = "/Files"
            });
        }

        protected void Application_End()
        {
        }
    }
}