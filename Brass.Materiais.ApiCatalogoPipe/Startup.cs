using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo;
using Brass.Materiais.AppPQ.QureySide.ObterFamilias;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Brass.Materiais.ApiCatalogoPipe
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "MyPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();

                    //builder.WithOrigins("http://example.com",
                    //"http://localhost:44300",
                    //"http://localhost:4200")
                    //.AllowAnyHeader()
                    //.AllowAnyMethod();
                });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Leituras   
            services.AddMediatR(typeof(ObtemArvoreCatalogoQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItensFamiliaQuery).GetTypeInfo().Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
