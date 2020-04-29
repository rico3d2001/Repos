using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Dominio.Servico.Handlers.Request;
using Brass.Materiais.PQ.Entities;
using Brass.Materiais.PQ.RepoIO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.WebApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        // GET api/projetos
        [HttpGet]
        public ActionResult<CommandResult<Projeto>> Get()
        {
            var handler = new HandlerProjetosRequest();
            var request = new RequestIO();
            var command = new CriaProjetosRequest(request);
            return (CommandResult<Projeto>)handler.Handle(command);

        }
    }
}