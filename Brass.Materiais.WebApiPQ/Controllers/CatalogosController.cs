using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.ValueObjects.Dimensoes;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObtemArvoreCatalogo;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterFamilias;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Models;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Brass.Materiais.WebApiPQ.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private ItemEngenhariaService _itemEngenhariaService;

        public CatalogosController()
        {
            _itemEngenhariaService = new ItemEngenhariaService();
        }

        // GET: /api/catalogos  CatalogoDTO
        [HttpGet]
        public IEnumerable<CatalogoDTO> Get()
        {
            return _itemEngenhariaService.ObterCatalogos();
        }

        // GET: /api/catalogos/categorias/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8
        [HttpGet("categorias/{guidCatalogo}")]
        public IEnumerable<CategoriaDTO> GetByGuid(string guidCatalogo)
        {
            return _itemEngenhariaService.ObterCategorias(guidCatalogo);
        }

        // GET: /api/catalogos/propriedades/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8/0551cde6-c249-43b0-83d4-161ac9178b35

        [HttpGet("propriedades/guidCatalogo/guidCategoria")]
        public IEnumerable<TiposItemDTO> GetPropriedades(string guidCatalogo, string guidCategoria)
        {
            return _itemEngenhariaService.ObterTiposItem(guidCatalogo, guidCategoria);
        }

        // GET: /api/catalogos/ItensEng/000422cb-23a2-448d-9d4b-d9c5df0ddc1b    ////000422cb-23a2-448d-9d4b-d9c5df0ddc1b
        [HttpGet("ItensEng/{id_item}")]
        public IEnumerable<ItemEngenhariaDTO> GetItem(string id_item)
        {
            return _itemEngenhariaService.ObterPorId(id_item);
        }




        //
        // GET: catalogos/Familias/1f13670d-499c-4a9d-bcbf-23707ec4761e
        [HttpGet("Familias/{id_categoria}")]
        public IEnumerable<Familia> GetFamilias(string id_categoria)
        {
            CriaNomesPropriedades criaNomesPropriedades = new CriaNomesPropriedades();
            return criaNomesPropriedades.ObtemFamilias(id_categoria);
        }


        // GET: catalogos/ItensEng/Arvore
        [HttpGet("ItensEng/Arvore")]
        public IEnumerable<RamalArvoreCatalogo> GetArvore()//IEnumerable<RamalEstoque> GetArvore()
        {
           
            ObtemArvoreCatalogoQuery obtemArvoreCatalogoQuery = new ObtemArvoreCatalogoQuery();
            BaseMDBRepositorio<RamalArvoreCatalogo> ramalEstoqueRepositorio = new BaseMDBRepositorio<RamalArvoreCatalogo>("Catalogo", "RamalEstoque");
            ObtemArvoreCatalogoQueryHandler handler = new ObtemArvoreCatalogoQueryHandler(ramalEstoqueRepositorio);

            var result = handler.Handle(obtemArvoreCatalogoQuery);


            return result.Result;

   

        }

        //// GET: catalogos/Ramal/Familias/1f13670d-499c-4a9d-bcbf-23707ec4761e
        //[HttpGet("Ramal/Familias/{id_item}")]
        //public IEnumerable<RamalArvoreCatalogo> GetRamalFamilias(string id_item)
        //{
        //    CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
        //    return criaArvoreCatalogo.ObtemRamalFamilias(id_item);
        //}

        // GET: catalogos/Dimensoes/764398e4-1de1-40a4-9fb1-2f66c39d5ec2
        [HttpGet("Dimensoes/{guid_familia}")]
        public IEnumerable<DimensaoFamilia> GetDimensoes(string guid_familia)
        {
            //CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            //return criaArvoreCatalogo.ObtemItensFamilia(guid_familia);
            ObterItensFamiliaQuery query = new ObterItensFamiliaQuery(guid_familia);
            var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            ObterItensFamiliaQueryHandler handler = new ObterItensFamiliaQueryHandler(familiaItemRepositorio);
            var result = handler.Handle(query);


            return result.Result;
        }

       

        // GET: catalogos/Ramal/Familias/1f13670d-499c-4a9d-bcbf-23707ec4761e
        [HttpGet("Ramal/Familias/{id_item}")]
        public IEnumerable<RamalArvoreCatalogo> GetDimensoesFamilia(string id_item)
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            return criaArvoreCatalogo.ObtemRamalFamilias(id_item);
        }

        // GET: ItensEng/Linhas/0154689d-a6af-4504-a5c2-5552d2522f70
        //    catalogos/ItensEng/Linhas/9dcd21a8-43f0-4875-bf95-04255f7b2e68
        [HttpGet("ItensEng/Linhas/{guidTipoItem}")]
        public IEnumerable<Familia> GetLinhas(string guidTipoItem)
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            return criaArvoreCatalogo.ExtraiItensCategoria("532f43f4-59eb-4962-a4a9-edf7cee699a5", guidTipoItem);

            /*
            var repositorio = new BaseMDBRepositorio<ItemTubulacaoEstoque>("Catalogo", "ItensEstoque");
            var propriedadesItemService = new PropriedadesItemService();

            var itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService, repositorio);

            var lista = itemEngenhariaEstoqueService.ObtemItensTubulacaoPorTipoItem(guidTipoItem);

      
            return lista;*/

        }


    }
}