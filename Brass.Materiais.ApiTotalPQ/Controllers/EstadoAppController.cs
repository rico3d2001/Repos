using Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp;
using Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp;
using Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAppController : GeralController
    {
        private readonly IMediator _mediator;

        public EstadoAppController(IMediator mediator)
        {
            //_conectStringMongo = "testeAtlas";
            _mediator = mediator;
        }

        // EstadoApp/48e9eb46-5a26-4b9c-9a53-163d448336fb
        //[HttpGet("GetEstado/{siglaUsuario}/{guidDisciplina}")]
        [HttpGet("GetEstado/{guidProjeto}/{siglaUsuario}/{guidDisciplina}")]
        public Task<EstadoApp> ObterEstadoAppQuery(string guidProjeto,string siglaUsuario, string guidDisciplina)
        {
            var query = new ObterEstadoAppQuery(guidProjeto, siglaUsuario, guidDisciplina, _conectStringMongo);  //, guidDisciplina);

            return _mediator.Send(query);

        }


        [HttpPost("Iniciar")]
        public async Task<ActionResult> IniciarEstadoApp([FromBody] IdentidadeEstado identidadeEstado)
        {
            var query = new IniciarEstadoAppCommand(identidadeEstado, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddArea/{area}/{subArea}/{ativo}")]
        public async Task<ActionResult> AddAreaEstadoApp(string area, string subArea,string ativo, [FromBody] IdentidadeEstado identidadeEstado)
        {
            var query = new AddAreaEstadoAppCommand(area, subArea, ativo, identidadeEstado, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidPQ/{numeroPQ}")]
        public async Task<ActionResult> AddGuidPQEstadoApp(int numeroPQ, [FromBody] IdentidadePQ identidadePQ)
        {
            var query = new AddGuidPQEstadoAppCommand(identidadePQ, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidResumo/{numeroPQ}")]
        public async Task<ActionResult> AddGuidResumoEstadoApp([FromBody] IdentidadePQ identidadePQ)
        {
            var query = new AddGuidResumoEstadoAppCommand(identidadePQ, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidProjeto")]
        public async Task<ActionResult> AddGuidProjeto([FromBody] EstadoApp estado)
        {
            var query = new AddGuidProjetoEstadoAppCommand(estado, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        [HttpPut("AddGuidDisciplina/{guid}")]
        public async Task<ActionResult> AddGuidDisciplina([FromBody] IdentidadeEstado identidadeEstado)
        {
            var query = new AddGuidDisciplinaEstadoAppCommand(identidadeEstado, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }




    }
}
