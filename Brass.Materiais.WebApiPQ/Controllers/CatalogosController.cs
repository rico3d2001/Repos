using System.Collections.Generic;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Models;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

        // GET: catalogos/ItensEng/Arvore
        [HttpGet("ItensEng/Arvore")]
        public IEnumerable<RamalEstoque> GetArvore()
        {
            //var repositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
            //var arvoreServiceEstoque = new CriaRamaisEstoque(new RamalEstoqueService(repositorio));

            //return arvoreServiceEstoque.ListaRamaisArvore();

            CriaArvoreCatalogo criaArvoreCatalogo = new CriaArvoreCatalogo();
            return criaArvoreCatalogo.ExtraiArvoreEstoque();
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