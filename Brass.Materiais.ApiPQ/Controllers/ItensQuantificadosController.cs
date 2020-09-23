using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brass.Materiais.AppPQClean.CommandSide.CriarQuantificadoPipe;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brass.Materiais.ApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItensQuantificadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItensQuantificadosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //  ItensQuantificados/AddItemQuantificado/338d7902-f0f3-4526-807b-98f1afde6027
        [HttpPost("AddItemQuantificado/{guid}")]
        public async Task<ActionResult> SetItemQuantificado(string guid)
        {
            var query = new CriarQuantificadoPipeCommand(guid);

            await _mediator.Send(query);

            return Ok();

        }

        //// GET Plant3d/Quantificados/BdB1922-0000-H-FE0003.dwg
        //[HttpGet("Quantificados/{descricao}")]
        //public Task<ItemPQPlant3d[]> GetQuatificadosPorItem(string descricao)
        //{
        //    var query = new ObterItensPipePlant3dQuery(descricao);

        //    return _mediator.Send(query);

        //}
    }
}
