using Brass.Materiais.RepositorioSQLServer;
using Brass.Materiais.RepositorioSQLServer.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class DiametrosTubosController : ApiController
    {
        // GET: /api/DiametrosTubos
        public IEnumerable<Valores> Get()
        {

            List<Valores> codigosDiametros = new List<Valores>();

            using (var repositorio = new Repositorio<Valores>())
            {
                codigosDiametros = repositorio.Query().ToList();
            }

                

            return codigosDiametros;
        }

        // GET: api/DiametrosTubos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DiametrosTubos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DiametrosTubos/5
        //[Route("api/DiametrosTubos/Atualizar")]
        //public void Put([FromBody]CT_CodigoDiametro value)
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_CodigoDiametro>(contexto);

        //    repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/DiametrosTubos/5
        public void Delete(int id)
        {
        }
    }
}
