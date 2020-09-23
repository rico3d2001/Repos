using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppPQClean.CommandSide.AddResumoParaPQ;
using Brass.Materiais.AppPQClean.CommandSide.CriarPlanilhaPQ;
using Brass.Materiais.AppPQClean.CommandSide.CriarPQ;
using Brass.Materiais.AppPQClean.CommandSide.EmitirPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterListaPQs;
using Brass.Materiais.AppPQClean.QuerySide.ObterPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterPQAtiva;
using Brass.Materiais.DominioPQ.BIM.Entities;
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
    public class PQController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PQController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET PQ/IdsResumos/RRP/48e9eb46-5a26-4b9c-9a53-163d448336fb
        [HttpGet("IdsResumos/{guidProjeto}/{siglaUsuario}/{guidDisciplina}")]
        public Task<List<EstadoApp>> IdsResumos(string siglaUsuario, string guidProjeto,string guidDisciplina)
        {

            var query = new ObterListaPQsQuery(siglaUsuario, guidProjeto, guidDisciplina);

            return _mediator.Send(query);

        }


        // GET PQ/PQAtiva/RRP/48e9eb46-5a26-4b9c-9a53-163d448336fb
        [HttpGet("PQAtiva/{guidProjeto}/{siglaUsuario}/{guidDisciplina}/{numeroPQ}")]
        public Task<DataPQ> GetPQAtiva(string siglaUsuario, string guidProjeto,string guidDisciplina, int numeroPQ)
        {

            var query = new ObterPQAtivaQuery(siglaUsuario, guidProjeto, guidDisciplina, numeroPQ);

            return _mediator.Send(query);

        }

        // GET PQ/xxxx
        [HttpGet("{guidProjeto}/{siglaUsuario}/{guidDisciplina}/{numeroPQ}")]
        public Task<DataPQ> Get(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ)
        {

            var query = new ObterPQQuery(guidProjeto, siglaUsuario, guidDisciplina, numeroPQ);

            return _mediator.Send(query);

        }

        //  PQ/SalvarPQ/
        [HttpPost("SalvarPQ")]
        public async Task<ActionResult> SalvarPQ([FromBody] DataPQ dataPQ)
        {
            var query = new CriarPQValeCommand(dataPQ);

            await _mediator.Send(query);

            return Ok();

        }

        //  PQ/EmitirPQ/xxxxxxx
        [HttpPut("EmitirPQ")]
        public async Task<ActionResult> EmitirPQ([FromBody] DataPQ dataPQ)
        {

            var command = new EmitirPQCommand(dataPQ);

            await _mediator.Send(command);

            return Ok();

        }

        //  PQ/AddResumoParaPQ/{guidPQ}
        [HttpPut("AddResumoParaPQ/{guidProjeto}/{siglaUsuario}/{guidDisciplina}/{numeroPQ}")]
        public async Task<ActionResult> AddResumoParaPQ(string guidProjeto,string siglaUsuario,string guidDisciplina,int numeroPQ, [FromBody] List<ItemPQ> listaItens)
        {

            //string guidPQ, List<ItemPQPlant3d> itens

            var command = new AddResumoParaPQCommand(guidProjeto, siglaUsuario, guidDisciplina, numeroPQ, listaItens);

            await _mediator.Send(command);

            return Ok();

        }

        //  PQ/ImprimirPQ/61f8207a-97b4-4364-88e5-57bbce3d42dc
        [HttpPut("ImprimirPQ/{guidProjeto}/{siglaUsuario}/{guidDisciplina}/{numeroPQ}")]
        public async Task<ActionResult> ImprimirPQ(string guidPQ)
        {

            var command = new CriarPlanExcelPQCommand(guidPQ, "Vale", @"C:\Trabalho\Templates\TemplateVale.xlsx", "M-TUB", "Tubulacao");

            await _mediator.Send(command);

            return Ok();

        }

    }
}
