using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppPQClean.CommandSide.AdiconarItensResumo;
using Brass.Materiais.AppPQClean.CommandSide.VinculaPQEmResumo;
using Brass.Materiais.AppPQClean.QuerySide.ObterResumoPipe;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ResumoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  Resumo/SetItensResumo/338d7902-f0f3-4526-807b-98f1afde6027
        [HttpPost("SetItensResumo")]
        public async Task<ActionResult> SetItensResumo([FromBody] Resumo resumo)//List<ItemPQ> listaItens)
        {
            var query = new AdiconarItensResumoCommnad(resumo);

            await _mediator.Send(query);

            return Ok();

        }

        //  Resumo/VinculaPQResumo/233f2ed6-3b14-44b6-a566-30f854e9bb72/bc410cf8-760e-45d4-a286-f159bacfa9d3
        //[HttpPut("VinculaPQResumo/{guidResumo}/{guidPQ}")]
        //public async Task<ActionResult> VinculaPQResumo(string guidResumo, string guidPQ)
        //{
        //    var query = new VinculaPQEmResumoCommand(guidResumo, guidPQ);

        //    await _mediator.Send(query);

        //    return Ok();

        //}



        // Resumo/GetItensResumo/c46d7661-f5e2-444d-804e-cad7809de3d3/RRP
        [HttpGet("GetItensResumo/{guidProjeto}/{siglaUsuario}/{guidDisciplina}")]
        public Task<Resumo> GetItensResumo(string guidProjeto, string siglaUsuario,string guidDisciplina)
        {
            var query = new ObterResumoPipeQuery(guidProjeto, siglaUsuario,guidDisciplina);

            return _mediator.Send(query);

        }


    }
}
