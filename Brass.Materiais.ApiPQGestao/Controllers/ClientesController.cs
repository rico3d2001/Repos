using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.QuerySide.ObterClientes;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiPQGestao.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET api/clientes
        [HttpGet]
        public Task<Cliente[]> Get()
        {

            var query = new ObterClientesQuery();

            return _mediator.Send(query);

        }

        ////ObterClientesQuery
        //// GET: api/clientes
        //[HttpGet]
        //public ActionResult<CommandResult<Cliente>> Get()
        //{
        //    //var lista = _clientesCommnad.ObterTodosClientes();
        //    //return _clientesCommnad.ObterTodosClientes(); 
        //    var repositorio = new BaseMDBRepositorio<Cliente>("Catalogo", "Clientes");

        //    HandlerClientesRequest handlerClientesRequest = new HandlerClientesRequest(repositorio);
        //    var command3 = new RecuperaClientesRequest();
        //    var teste = (CommandResult<Cliente>)handlerClientesRequest.Handle(command3);
        //   return teste;


        //}


    }
}
