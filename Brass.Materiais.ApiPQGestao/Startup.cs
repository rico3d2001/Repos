﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp;
using Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterClientes;
using Brass.Materiais.AppGestao.QuerySide.ObterDisciplinas;
using Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterHub;
using Brass.Materiais.AppGestao.QuerySide.ObterProjetos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Brass.Materiais.ApiPQGestao
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
            services.AddMediatR(typeof(ObterProjectosQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterHubQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterEstadoAppQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ObterDisciplinasQuery).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(ObterClientesQuery).GetTypeInfo().Assembly);

            //Comandos  
            services.AddMediatR(typeof(IniciarEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddAreaEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidPQEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidResumoEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidProjetoEstadoAppCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddGuidDisciplinaEstadoAppCommand).GetTypeInfo().Assembly);


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
