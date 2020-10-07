using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterArvoreCatalogo;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCategoria;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterFamiliaParaAdicao;
using Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp;
using Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterUmProjeto;
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
using Brass.Materiais.AppPQClean.QuerySide.ObterTodosItensPQ;
using Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Brass.Materiais.ApiTotalPQ
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
            services.AddMediatR(typeof(ObtemArvoreCatalogoQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterCategoriasQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterEstadoAppQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ObterAreasTagsQuery).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(ObterAreasTagsQueryBIM360Query).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterFamiliaParaAdicaoQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterTodosItensPQQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItensFamiliaQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItenParaAtivarDeItemPQQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterEAPQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterTabelaAtividadesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterArvoreAtividadesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterItensPipePlant3dQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterListaPQsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterPQAtivaQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterPQQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterUmProjetoQuery).GetTypeInfo().Assembly);

            //Comandos  
            services.AddMediatR(typeof(IniciarEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddAreaEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidPQEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidResumoEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidProjetoEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidDisciplinaEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CarregarItensPQPipeCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(CargaItensP3DBIM360Command).GetTypeInfo().Assembly);
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
