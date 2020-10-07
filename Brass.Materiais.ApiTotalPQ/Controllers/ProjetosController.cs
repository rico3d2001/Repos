using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppGestao.QuerySide.ObterProjetos;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : GeralController
    {
        private readonly IMediator _mediator;

        public ProjetosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/projetos/VPN
        [HttpGet]
        public Task<Projeto[]> Get()
        {

            var query = new ObterProjectosQuery(_conectStringMongo);

            return _mediator.Send(query);

        }

       
    }
}
