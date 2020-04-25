using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class FabricacoesController : ApiController
    {
        // GET: /api/Fabricacoes
        //public IEnumerable<CT_Fabricacao> Get()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Fabricacao>(contexto);

        //    var schedules = repositorio.GetTodos().ToList();

        //    return schedules;
        //}

        // GET: api/Fabricacoes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fabricacoes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fabricacoes/5
        //[Route("api/Fabricacoes/Atualizar")]
        //public void Put([FromBody]CT_Fabricacao value)
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Fabricacao>(contexto);

        //    repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/Fabricacoes/5
        public void Delete(int id)
        {
        }
    }
}
