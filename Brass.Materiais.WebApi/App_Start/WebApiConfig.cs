using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Brass.Materiais.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //para produção
            //var cors = new EnableCorsAttribute("http://192.168.20.234", "*", "*"); 

            //para debug
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");


            //var cors = new EnableCorsAttribute("https://brassrico3d.z15.web.core.windows.net", "*", "*");


            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
