using Brass.Materiais.AppPQClean.QuerySide.ObterTodosItensPQ;
using Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe;
using Brass.Materiais.DominioPQ.BIM.Entities;
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
    public class CargaPipesPlant3dController : GeralController
    {
        private readonly IMediator _mediator;

        public CargaPipesPlant3dController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //ProjetoNexa
        //  CargaPipesPlant3d/48e9eb46-5a26-4b9c-9a53-163d448336fb
        
        [HttpPost]
        public async Task<ActionResult> CargaPipesPlant3d([FromBody] IdentidadeEstado identidadeEstado)
        {
            

            //switch (identidadeEstado.Projeto.Origem)
            //{

            //    case "VPN":
            //        {
                        var command = new CarregarItensPQPipeCommand(identidadeEstado, _conectStringMongo);
                        await _mediator.Send(command);
                        return Ok();
                //    }
                //case "BIM360":
                //    {
                //        var command = new CargaItensP3DBIM360Command(identidadeEstado);
                //        await _mediator.Send(command);
                //        return Ok();
                //    }
                //default:
                //    {
                //        var command = new CarregarItensPQPipeCommand(identidadeEstado);
                //        await _mediator.Send(command);
                //        return Ok();
                //    }
                    
            
            //}


          

        }

        // GET api/CargaPipesPlant3d/48e9eb46-5a26-4b9c-9a53-163d448336fb 
        [HttpGet("{guid_projeto}/{pagina}/{limite}")]
        public Task<ItemPQ[]> Get(string guid_projeto, int pagina, int limite)
        {

            var query = new ObterTodosItensPQQuery(guid_projeto, pagina, limite, _conectStringMongo);

            return _mediator.Send(query);

        }



    }
}
