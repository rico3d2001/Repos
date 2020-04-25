using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class MateriaisController : ApiController
    {
        // GET: /api/Materiais
        //public IEnumerable<CT_Materiais> Get()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Materiais>(contexto);

        //    var materiais = repositorio.GetTodos().ToList();

        //    return materiais;
        //}

        // GET: api/Materiais/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Materiais
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Materiais/5
        //[Route("api/Materiais/Atualizar")]
        //public void Put([FromBody]CT_Materiais value)
        //{
        //    //DataBaseContext contexto = new DataBaseContext();

        //    //var repositorio = new Repositorio<CT_Materiais>(contexto);

        //    //repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/Materiais/5
        public void Delete(int id)
        {
        }
    }
}
