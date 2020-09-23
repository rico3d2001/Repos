using Brass.Materiais.BIM.Entities;
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
    public class AreasController : ApiController
    {
        // GET: api/Areas
        public CommandResult<Area> Get()
        {
            var handler = new HandlerEAPRequest();
            var request = new RequestIO();
            var command = new CriaEAPRequest(request);
            return (CommandResult<Area>)handler.Handle(command);
        }

        // GET: api/Areas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Areas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Areas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Areas/5
        public void Delete(int id)
        {
        }
    }
}
