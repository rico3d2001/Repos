using Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp;
using Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp;
using Brass.Materiais.DominioPQ.PQ.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiEstadosPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAppController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadoAppController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // EstadoApp/48e9eb46-5a26-4b9c-9a53-163d448336fb
        //[HttpGet("GetEstado/{siglaUsuario}/{guidDisciplina}")]
        [HttpGet("GetEstado/{siglaUsuario}")]
        public Task<EstadoApp> ObterEstadoAppQuery(string siglaUsuario)
        {
            var query = new ObterEstadoAppQuery(siglaUsuario);

            return _mediator.Send(query);

        }


        [HttpPost("Iniciar/{guid}")]
        public async Task<ActionResult> IniciarEstadoApp(string guid, [FromBody] EstadoApp estado)
        {
            var query = new IniciarEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddArea/{guid}")]
        public async Task<ActionResult> AddAreaEstadoApp(string guid, [FromBody] EstadoApp estado)
        {
            var query = new AddAreaEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidPQ/{guid}")]
        public async Task<ActionResult> AddGuidPQEstadoApp(string guid, [FromBody] EstadoApp estado)
        {
            var query = new AddGuidPQEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidResumo/{guid}")]
        public async Task<ActionResult> AddGuidResumoEstadoApp(string guid, [FromBody] EstadoApp estado)
        {
            var query = new AddGuidResumoEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidProjeto/{guid}")]
        public async Task<ActionResult> AddGuidProjeto(string guid, [FromBody] EstadoApp estado)
        {
            var query = new AddGuidProjetoEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidDisciplina/{guid}")]
        public async Task<ActionResult> AddGuidDisciplina(string guid, [FromBody] EstadoApp estado)
        {
            var query = new AddGuidDisciplinaEstadoAppCommand(guid, estado);

            await _mediator.Send(query);

            return Ok();

        }




    }
}
