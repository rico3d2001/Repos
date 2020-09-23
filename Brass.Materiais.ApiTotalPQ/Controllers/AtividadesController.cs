using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppPQClean.CommandSide.AtivarItens;
using Brass.Materiais.AppPQClean.QuerySide.ObterArvoreAtividades;
using Brass.Materiais.AppPQClean.QuerySide.ObterTabelaAtividades;
using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.PQ.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtividadesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET PQ/xxxx
        [HttpGet("Tabela")]
        public Task<TabelaAtividades> Get()
        {

            var query = new ObterTabelaAtividadesQuery();

            return _mediator.Send(query);

        }

        // GET Atividades/f8858d95-5eba-4d21-8606-4b813efa568b/2a2000fd-b8a3-4619-8b78-2be372851cf9
        [HttpGet("{guidDisciplina}/{guidProjeto}")]
        public Task<RamalArvoreAtividade> Get(string guidDisciplina, string guidProjeto)
        {

            var query = new ObterArvoreAtividadesQuery(guidProjeto, guidDisciplina);

            return _mediator.Send(query);

        }

        ////AtivarItemCommand

        ////  Atividades/AtivarItens
        [HttpPut("AtivarItens")]
        public async Task<ActionResult> AtivarItens([FromBody] List<ItemParaAtivar> listaItens)
        {

            var query = new AtivarItensCommand(listaItens);

            await _mediator.Send(query);

            return Ok();

        }
    }
}
