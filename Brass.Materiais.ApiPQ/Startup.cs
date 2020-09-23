using Brass.Materiais.AppPQClean.CommandSide.AddResumoParaPQ;
using Brass.Materiais.AppPQClean.CommandSide.AdiconarItensResumo;
using Brass.Materiais.AppPQClean.CommandSide.AtivarItens;
using Brass.Materiais.AppPQClean.CommandSide.CriarPlanilhaPQ;
using Brass.Materiais.AppPQClean.CommandSide.CriarPQ;
using Brass.Materiais.AppPQClean.CommandSide.EmitirPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterArvoreAtividades;
using Brass.Materiais.AppPQClean.QuerySide.ObterEAP;
using Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterItensFamilia;
using Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d;
using Brass.Materiais.AppPQClean.QuerySide.ObterListaPQs;
using Brass.Materiais.AppPQClean.QuerySide.ObterPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterPQAtiva;
using Brass.Materiais.AppPQClean.QuerySide.ObterTabelaAtividades;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Brass.Materiais.ApiPQ
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
                    //       .AllowAnyHeader()
                    //       .AllowAnyMethod();

                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Leituras   
            services.AddMediatR(typeof(ObterItensFamiliaQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItenParaAtivarDeItemPQQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterEAPQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterTabelaAtividadesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterArvoreAtividadesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItensPipePlant3dQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterListaPQsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterPQAtivaQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterPQQuery).GetTypeInfo().Assembly);

            //Comandos  
            services.AddMediatR(typeof(AtivarItensCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CriarPQValeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(EmitirPQCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddResumoParaPQCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CriarPlanExcelPQCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AdiconarItensResumoCommnad).GetTypeInfo().Assembly);

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
