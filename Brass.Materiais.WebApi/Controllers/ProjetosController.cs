using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Dominio.Servico.Handlers.Request;
using Brass.Materiais.PQ.Entities;
using Brass.Materiais.PQ.RepoIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class ProjetosController : ApiController
    {
        // GET: api/Projetos
        public CommandResult<Projeto> Get()
        {
            var handler = new HandlerProjetosRequest();
            var request = new RequestIO();
            var command = new CriaProjetosRequest(request);
            return (CommandResult<Projeto>)handler.Handle(command);
        }

        // GET: api/Projetos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Projetos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Projetos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Projetos/5
        public void Delete(int id)
        {
        }
    }
}
