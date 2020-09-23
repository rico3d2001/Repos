using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCatalogos;
using Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCatalogos.ViewModel;
using Brass.Materiais.RepoCataloESQLServer.Data;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Brass.Materiais.ApiCatalogoPlant3d.Controllers
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

        // GET: /api/catalogos  CatalogoDTO
        [HttpGet]
        public Task<CatalogoPlant3d[]> Get(string siglaUsuario)
        {

            var query = new ObterCatalogosQuery();

            return _mediator.Send(query);

        }

        // GET: /api/catalogos/categorias/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8
        [HttpGet("categorias/{guidCatalogo}")]


        //public IEnumerable<CategoriaDTO> GetByGuid(string guidCatalogo)
        //{
        //    //return _itemEngenhariaService.ObterCategorias(guidCatalogo);
        //}

        //// GET: /api/catalogos/propriedades/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8/0551cde6-c249-43b0-83d4-161ac9178b35

        //[HttpGet("propriedades/guidCatalogo/guidCategoria")]
        //public IEnumerable<TiposItemDTO> GetPropriedades(string guidCatalogo, string guidCategoria)
        //{
        //    return _itemEngenhariaService.ObterTiposItem(guidCatalogo, guidCategoria);
        //}

        //// GET: /api/catalogos/ItensEng/000422cb-23a2-448d-9d4b-d9c5df0ddc1b    ////000422cb-23a2-448d-9d4b-d9c5df0ddc1b
        //[HttpGet("ItensEng/{id_item}")]
        //public IEnumerable<ItemEngenhariaDTO> GetItem(string id_item)
        //{
        //    return _itemEngenhariaService.ObterPorId(id_item);
        //}




        ////
        //// GET: catalogos/Familias/1f13670d-499c-4a9d-bcbf-23707ec4761e
        //[HttpGet("Familias/{id_categoria}")]
        //public IEnumerable<Familia> GetFamilias(string id_categoria)
        //{
        //    CriaNomesPropriedades criaNomesPropriedades = new CriaNomesPropriedades();
        //    return criaNomesPropriedades.ObtemFamilias(id_categoria);
        //}


        //// GET: catalogos/ItensEng/Arvore
        //[HttpGet("ItensEng/Arvore")]
        //public Task<RamalArvoreCatalogo[]> GetArvore()//IEnumerable<RamalEstoque> GetArvore()
        //{

        //    var query = new ObtemArvoreCatalogoQuery();

        //    return _mediator.Send(query);


        //}



        //// GET: catalogos/Dimensoes/a3bc03da-c013-4a19-b328-fc46c06d699d/ef0179fc-76e9-4e60-a9b1-bfab57139d8e
        //[HttpGet("Dimensoes/{guid_familia}/{guid_Atividade}")]
        //public Task<ItemParaAtivar[]> GetDimensoes(string guid_familia, string guid_Atividade)
        //{
        //    var query = new ObterItensFamiliaQuery(guid_familia, guid_Atividade);

        //    return _mediator.Send(query);
        //}



        //// GET: catalogos/Ramal/Familias/1f13670d-499c-4a9d-bcbf-23707ec4761e
        //[HttpGet("Ramal/Familias/{id_item}")]
        //public IEnumerable<RamalArvoreCatalogo> GetDimensoesFamilia(string id_item)
        //{
        //    CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
        //    return criaArvoreCatalogo.ObtemRamalFamilias(id_item);
        //}

        //// GET: ItensEng/Linhas/0154689d-a6af-4504-a5c2-5552d2522f70
        ////    catalogos/ItensEng/Linhas/9dcd21a8-43f0-4875-bf95-04255f7b2e68
        //[HttpGet("ItensEng/Linhas/{guidTipoItem}")]
        //public IEnumerable<Familia> GetLinhas(string guidTipoItem)
        //{
        //    CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
        //    return criaArvoreCatalogo.ExtraiItensCategoria("532f43f4-59eb-4962-a4a9-edf7cee699a5", guidTipoItem);



        //}


    }
}
