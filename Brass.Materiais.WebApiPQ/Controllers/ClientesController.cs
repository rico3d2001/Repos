using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Handlers.Request;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.WebApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
       
        public ClientesController()
        {
       
        }

        // GET: api/clientes
        [HttpGet]
        public ActionResult<CommandResult<Cliente>> Get()
        {
            //var lista = _clientesCommnad.ObterTodosClientes();
            //return _clientesCommnad.ObterTodosClientes(); 
            var repositorio = new BaseMDBRepositorio<Cliente>("Catalogo", "Clientes");

            HandlerClientesRequest handlerClientesRequest = new HandlerClientesRequest(repositorio);
            var command3 = new RecuperaClientesRequest();
            var teste = (CommandResult<Cliente>)handlerClientesRequest.Handle(command3);
           return teste;


        }
    }
}