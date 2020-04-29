using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Dominio.Servico.Handlers.Request;
using Brass.Materiais.PQ.Entities;
using Brass.Materiais.PQ.RepoIO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.WebApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        // GET api/areas
        [HttpGet]
        public ActionResult<CommandResult<Area>> Get()
        {
            var handler = new HandlerEAPRequest();
            var request = new RequestIO();
            var command = new CriaEAPRequest(request);
            return (CommandResult<Area>)handler.Handle(command);

        }
    }
}