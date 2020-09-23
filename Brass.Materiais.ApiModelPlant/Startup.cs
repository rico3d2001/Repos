using Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360;
using Brass.Materiais.AppBIM360.QuerySide.ObterAreasTagsQueryBIM360;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterFamiliaParaAdicao;
using Brass.Materiais.AppPQClean.QuerySide.ObterTodosItensPQ;
using Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe;
using Brass.Materiais.AppVPN.QuerySide.ObterAreasTags;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Brass.Materiais.ApiModelPlant
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
                    //builder.WithOrigins("http://localhost:4200")
                    //     .AllowAnyHeader()
                    //     .AllowAnyMethod();
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Leituras   
            services.AddMediatR(typeof(ObterAreasTagsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterAreasTagsQueryBIM360Query).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterFamiliaParaAdicaoQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterTodosItensPQQuery).GetTypeInfo().Assembly);



            //Comandos  
            services.AddMediatR(typeof(CarregarItensPQPipeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CargaItensP3DBIM360Command).GetTypeInfo().Assembly);



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
