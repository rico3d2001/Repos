using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class TiposController : ApiController
    {
        // GET: /api/Tipos
        //public IEnumerable<CT_PnPTables> Get()
        //{

        //    List<CT_PnPTables> tabelas = new List<CT_PnPTables>();

        //    using (var repositorio = new Repositorio<CT_PnPTables>())
        //    {
        //        tabelas = repositorio.Query().ToList();
        //    }

        //    return tabelas;
        //}

        // GET: api/Tipos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tipos
        //public void Post([FromBody]CT_PnPTables value)
        //{
        //    using (var repositorio = new Repositorio<CT_PnPTables>())
        //    {

        //    }
        //}

        // PUT: api/Tipos/5
        ////[Route("api/Tipos/Atualizar")]
        ////public void Put([FromBody]CT_PnPTables value)
        ////{
            

        ////    using (var repositorio = new Repositorio<CT_PnPTables>())
        ////    {
        ////       bool p = repositorio.Edit(value);
        ////    }

        ////}

        // DELETE: api/Tipos/5
        public void Delete(int id)
        {
        }
    }
}
