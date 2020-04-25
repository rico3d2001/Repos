using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class ExtremidadesController : ApiController
    {
        // GET: /api/Extremidades
        //public IEnumerable<CT_Extremidade> Get()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Extremidade>(contexto);

        //    var schedules = repositorio.GetTodos().ToList();

        //    return schedules;
        //}

        // GET: api/Extremidades/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Extremidades
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Extremidades/5
        //[Route("api/Extremidades/Atualizar")]
        //public void Put([FromBody]CT_Extremidade value)
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Extremidade>(contexto);

        //    repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/Extremidades/5
        public void Delete(int id)
        {
        }
    }
}
