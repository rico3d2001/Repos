using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class SchedulesController : ApiController
    {
        // GET: /api/Schedules
        //public IEnumerable<CT_Schedule> Get()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Schedule>(contexto);

        //    var schedules = repositorio.GetTodos().ToList();

        //    return schedules;
        //}

        // GET: api/Schedules/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Schedules
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Schedules/5
        //[Route("api/Schedules/Atualizar")]
        //public void Put([FromBody]CT_Schedule value)
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_Schedule>(contexto);

        //    repositorio.Atualizar(value);

        //    contexto.SaveChanges();

        //}

        // DELETE: api/Schedules/5
        public void Delete(int id)
        {
        }
    }
}
