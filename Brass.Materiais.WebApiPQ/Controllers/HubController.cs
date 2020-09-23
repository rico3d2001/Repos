using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppBIM.QuerySide.ObterHub;
using Brass.Materiais.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.WebApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET Hub/RRP
        [HttpGet("{siglaUsuario}")]
        public Task<Hub> Get(string siglaUsuario)
        {

            var query = new ObterHubVeiQuery(siglaUsuario);

            return _mediator.Send(query);

        }
    }
}
