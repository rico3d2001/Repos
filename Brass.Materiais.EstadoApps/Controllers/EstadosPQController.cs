using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.ApiPQGestao.Controllers.Model;
using Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.EstadoApps.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosPQController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadosPQController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddGuidProjeto")]
        public async Task<ActionResult> AddGuidProjeto([FromBody] Guids guids)
        {
          
            var query = new AddGuidProjetoEstadoAppCommand("",null);

            await _mediator.Send(query);

            return Ok();

        }


    }
}
