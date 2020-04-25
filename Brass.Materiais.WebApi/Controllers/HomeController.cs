using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Brass.Materiais.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public ActionResult TesteMudarSiglaTipo()
        //{
        //    CT_PnPTables valor = new CT_PnPTables()
        //    {
        //        GUID = "59f9a374-1216-41f7-9f54-1562f784d675",
        //        TableName = "tabela",
        //        BaseTable = "base",
        //        Abstract = "TRUE",
        //        PhysicalName = "fisico",
        //        Revision = 1,
        //        SyncTimestamp = 1,
        //        Sigla_BRASS = "GD"
        //    };

        //    string baseURL = "https://localhost:44320/";
        //    string api = "api/Tipos/Atualizar";
        //    var hndlr = new HttpClientHandler();
        //    hndlr.UseDefaultCredentials = true;

        //    using (var client = new HttpClient(hndlr))
        //    {
        //        client.BaseAddress = new Uri(baseURL);

        //        client.DefaultRequestHeaders.Clear();

        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var responseTask = client.PutAsJsonAsync(api, valor);

        //        responseTask.Wait();

        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsStringAsync();
        //            readTask.Wait();

        //            var str = readTask.Result;

        //        }
        //    }

        //    return View(valor);
        //}


    }
}
