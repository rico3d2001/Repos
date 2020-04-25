using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class RevestimentosController : ApiController
    {
        // GET: /api/Revestimentos
        //public IEnumerable<CT_Revestimento> Get()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Revestimento>(contexto);

        //    var revestimentos = repositorio.GetTodos().ToList();

        //    return revestimentos;
        //}

        // GET: api/Revestimentos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Revestimentos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Revestimentos/5
        //[Route("api/Revestimentos/Atualizar")]
        //public void Put([FromBody]CT_Revestimento value)
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Revestimento>(contexto);

        //    repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/Revestimentos/5
        public void Delete(int id)
        {
        }
    }
}
