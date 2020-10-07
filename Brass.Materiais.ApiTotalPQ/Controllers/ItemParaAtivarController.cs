using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppPQClean.CommandSide.AtivarItens;
using Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ;
using Brass.Materiais.AppPQClean.QuerySide.ObterItensFamilia;
using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiTotalPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemParaAtivarController : GeralController
    {

        private readonly IMediator _mediator;

        public ItemParaAtivarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: catalogos/Dimensoes/a3bc03da-c013-4a19-b328-fc46c06d699d/ef0179fc-76e9-4e60-a9b1-bfab57139d8e
        [HttpGet("Dimensoes/{guid_familia}/{guid_Atividade}")]
        public Task<ItemParaAtivar[]> GetDimensoes(string guid_familia, string guid_Atividade)
        {
            var query = new ObterItensFamiliaQuery(guid_familia, guid_Atividade, _conectStringMongo);

            return _mediator.Send(query);
        }

        // GET: Atividades/ItensPorItem/22dc4cfb-919e-49d7-924b-6b669cebbdb7
        [HttpGet("ItensPorItem/{guid_itemPQ}/{guid_AtividadePai}")]
        public Task<ItemParaAtivar[]> GetItensParaAtivar(string guid_itemPQ, string guid_AtividadePai)
        {
            var query = new ObterItenParaAtivarDeItemPQQuery(guid_itemPQ, guid_AtividadePai, _conectStringMongo);

            return _mediator.Send(query);
        }

        [HttpPut("AtivarItens")]
        public async Task<ActionResult> AtivarItens([FromBody] List<ItemParaAtivar> listaItens)
        {

            var query = new AtivarItensCommand(listaItens, _conectStringMongo);

            await _mediator.Send(query);

            return Ok();

        }

        //// GET: ItensParaAtivar/ItensPorItem/22dc4cfb-919e-49d7-924b-6b669cebbdb7
        //[HttpGet("ItensPorItem/{guid_itemPQ}/{guid_AtividadePai}")]
        //public Task<ItemParaAtivar[]> GetItensParaAtivar(string guid_itemPQ, string guid_AtividadePai)
        //{
        //    var query = new ObterItenParaAtivarDeItemPQQuery(guid_itemPQ, guid_AtividadePai);

        //    return _mediator.Send(query);
        //}

       




    }
}
