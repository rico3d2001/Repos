using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Models;
using Brass.Materiais.RepoSQLServerDapper.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace Brass.Materiais.WebApi.Controllers
{
    public class ItensEngController : ApiController
    {
        private ItemEngenhariaService _itemEngenhariaService;
        public ItensEngController()
        {
            _itemEngenhariaService = new ItemEngenhariaService();
        }

        // GET: /api/catalogos
        [Route("api/catalogos")]
        public IEnumerable<CatalogoDTO> GetCatalogos()
        {
            return _itemEngenhariaService.ObterCatalogos();
        }

        // GET: /api/categorias/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8
        [Route("api/categorias/guidCatalogo")]
        public IEnumerable<CategoriaDTO> GetCategorias(string guidCatalogo)
        {
            return _itemEngenhariaService.ObterCategorias(guidCatalogo);
        }


        // GET: /api/propriedades/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8/0551cde6-c249-43b0-83d4-161ac9178b35
        [Route("api/propriedades/guidCatalogo/guidCategoria")]
        public IEnumerable<TiposItemDTO> GetPropriedades(string guidCatalogo, string guidCategoria)
        {
            return _itemEngenhariaService.ObterTiposItem(guidCatalogo, guidCategoria);
        }

        // GET: /api/ItensEng/000422cb-23a2-448d-9d4b-d9c5df0ddc1b    ////000422cb-23a2-448d-9d4b-d9c5df0ddc1b
        [Route("api/ItensEng/{id_item}")]
        public IEnumerable<ItemEngenhariaDTO> GetItem(string id_item)
        {
            return _itemEngenhariaService.ObterPorId(id_item);
        }

        // GET: /api/ItensEng/Arvore
        [Route("api/ItensEng/Arvore")]
        public IEnumerable<RamalEstoque> GetArvore()
        {
            var repositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
            var arvoreServiceEstoque = new CriaRamaisEstoque(new RamalEstoqueService(repositorio));

            return arvoreServiceEstoque.ListaRamaisArvore();
        }



        // GET: /api/ItensEng/Tabela/9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8/0551cde6-c249-43b0-83d4-161ac9178b35/0154689d-a6af-4504-a5c2-5552d2522f70
        //[Route("api/ItensEng/Tabela/{guidCatalogo}/{guidCategoria}/{guidTipoItem}")]
        //public IEnumerable<Ramal> GetTabela(string guidCatalogo, string guidCategoria, string guidTipoItem)
        //{
        //    return new TabelaService().ObterPropiredades(guidCatalogo, guidCategoria, guidTipoItem);//new ArvoresService().Arvore;
        //}

        // GET: /api/ItensEng/Colunas/0551cde6-c249-43b0-83d4-161ac9178b35/0154689d-a6af-4504-a5c2-5552d2522f70
        [Route("api/ItensEng/Colunas/{guidCategoria}/{guidTipoItem}")]
        public IEnumerable<string> GetColunas(string guidCategoria, string guidTipoItem)
        {

            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            var lista = propriedadesItemService.ObterColunas(guidCategoria, guidTipoItem);

            return lista;

        }

        // GET: /api/ItensEng/Linhas/20/0/0551cde6-c249-43b0-83d4-161ac9178b35/0154689d-a6af-4504-a5c2-5552d2522f70
        //[Route("api/ItensEng/Linhas/{intervalo}/{ultimoPnPID}/{guidCategoria}/{guidTipoItem}")]
        //public HttpResponseMessage GetLinhas(int intervalo, int ultimoPnPID, string guidCategoria, string guidTipoItem)

        // GET: /api/ItensEng/Linhas/0154689d-a6af-4504-a5c2-5552d2522f70
        [Route("api/ItensEng/Linhas/{guidTipoItem}")]
        public IEnumerable<ItemTubulacaoEstoque> GetLinhas(string guidTipoItem)
        {

            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            var lista = itemEngenhariaEstoqueService.ObtemItensTubulacaoPorTipoItem(guidTipoItem);

            //string linhaJson = propriedadesItemService.ObterLinhasTabela(intervalo, ultimoPnPID, guidCategoria, guidTipoItem);


            //var response = this.Request.CreateResponse(HttpStatusCode.OK);
            //response.Content = new StringContent(linhaJson, Encoding.UTF8, "application/json");
            //return response;
            return lista;

        }




        ////GET: /api/Tipos
        //[Route("api/Tipos")]
        //public IEnumerable<CT_PnPTables> GetTiposItensEngenharia()
        //{
        //    DataBaseContext contexto = new DataBaseContext();

        //    var repositorio = new Repositorio<CT_PnPTables>(contexto);

        //    var tabelas = repositorio.GetTodos().ToList();

        //    return tabelas;
        //}

        // GET: api/ItensEng/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItensEng
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItensEng/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItensEng/5
        public void Delete(int id)
        {
        }
    }
}
