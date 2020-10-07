﻿using Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d;
using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItensColetadosController : GeralController
    {
        private readonly IMediator _mediator;

        public ItensColetadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET ItensColetados/ItensTubulacao/48e9eb46-5a26-4b9c-9a53-163d448336fb/RRP/01/00
        [HttpGet("ItensTubulacao/{guidProjeto}/{area}/{subarea}/{ativo}/{pagina}/{limite}")]
        public Task<ItemPQ[]> GetItensTubulacao(string guidProjeto, string area, string subarea, string ativo, int pagina, int limite)
        {
            var query = new ObterItensPipePlant3dQuery(guidProjeto, area, subarea, ativo, pagina, limite, _conectStringMongo);

            return _mediator.Send(query);

        }
    }
}