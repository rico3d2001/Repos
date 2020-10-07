using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.QuerySide.ObterHub;
using Brass.Materiais.AppGestao.QuerySide.ObterUmProjeto;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : GeralController
    {
        private readonly IMediator _mediator;

        public HubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/Hub/RRP
        [HttpGet("{siglaUsuario}")]
        public Task<Hub> Get(string siglaUsuario)
        {

            var query = new ObterHubQuery(siglaUsuario, _conectStringMongo);

            return _mediator.Send(query);

        }

        [HttpGet("{siglaUsuario}/{guidProjeto}")]
        public Task<Projeto> Get(string siglaUsuario, string guidProjeto)
        {

            var query = new ObterUmProjetoQuery(siglaUsuario, guidProjeto, _conectStringMongo);

            return _mediator.Send(query);

        }
    }
}
