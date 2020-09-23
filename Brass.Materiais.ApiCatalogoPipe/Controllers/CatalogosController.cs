using Brass.Materiais.AppPQ.CommandSide.AtivarItens.ViewModel;
using Brass.Materiais.AppPQ.QureySide.ObterArvoreCatalogo;
using Brass.Materiais.AppPQ.QureySide.ObterArvoreCatalogo.ViewModel;
using Brass.Materiais.AppPQ.QureySide.ObterCategoria;
using Brass.Materiais.AppPQ.QureySide.ObterFamilias;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiCatalogoPipe.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CatalogosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: catalogos/ItensEng/Arvore
        [HttpGet("ItensEng/Arvore")]
        public Task<RamalArvoreCatalogo[]> GetArvore()//IEnumerable<RamalEstoque> GetArvore()
        {

            var query = new ObtemArvoreCatalogoQuery();

            return _mediator.Send(query);


        }


        //GET: catalogos/Dimensoes/a3bc03da-c013-4a19-b328-fc46c06d699d/ef0179fc-76e9-4e60-a9b1-bfab57139d8e
       [HttpGet("Dimensoes/{guid_familia}/{guid_Atividade}")]
        public Task<ItemParaAtivar[]> GetDimensoes(string guid_familia, string guid_Atividade)
        {
            var query = new ObterItensFamiliaQuery(guid_familia, guid_Atividade);

            return _mediator.Send(query);
        }


        



    }
}
