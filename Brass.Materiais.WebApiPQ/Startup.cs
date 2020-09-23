using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo;
using Brass.Materiais.AppPQClean.CommandSide.AtivarItens;
using Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterItensFamilia;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Brass.Materiais.WebApiPQ
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
            services.AddMediatR(typeof(ObterItensFamiliaQuery).GetTypeInfo().Assembly);
      
           
    
   
   
            services.AddMediatR(typeof(ObtemArvoreCatalogoQuery).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(ObterItenParaAtivarDeItemPQQuery).GetTypeInfo().Assembly);
        
        
        
            //Comandos  
   
      
       
            
            services.AddMediatR(typeof(AtivarItensCommand).GetTypeInfo().Assembly);
          
    


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors(MyAllowSpecificOrigins);
        }
    }
}
