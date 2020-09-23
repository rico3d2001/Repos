using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class ItemEngenhariaEstoqueService
    {
        PropriedadesItemServiceSQL _propriedadesItemService;
        BaseMDBRepositorio<ItemTubulacaoEstoque> _repositorio;
        private PropriedadesItemServiceSQL propriedadesItemService;

        public ItemEngenhariaEstoqueService(PropriedadesItemServiceSQL propriedadesItemService)
        {
            this.propriedadesItemService = propriedadesItemService;
        }

        public ItemEngenhariaEstoqueService(PropriedadesItemServiceSQL propriedadesItemService, BaseMDBRepositorio<ItemTubulacaoEstoque> repositorio) //: base("Catalogo", "ItensEstoque")
        {
            _repositorio = repositorio;
            _propriedadesItemService = propriedadesItemService;
        }


        public void InserirItem(ItemTubulacaoEstoque itemTubulacaoEstoque)
        {
            _repositorio.Inserir(itemTubulacaoEstoque);
            //_colecao.InsertOne(itemTubulacaoEstoque);
        }

        public List<ItemTubulacaoEstoque> ObtemItensTubulacaoPorTipoItem(string guidTipoItem)//string guidCatalogo, string guidCategoria, string guidTipoItem)
        {
            List<ItemTubulacaoEstoque> tubulacaoEstoques = new List<ItemTubulacaoEstoque>();

            //var ids = _propriedadesItemService.ObterPropriedadesID(guidCatalogo, guidCategoria, guidTipoItem);

            var filter = Builders<ItemTubulacaoEstoque>.Filter.Eq(x => x.GUID_TIPO_ITEM, guidTipoItem);

            return _repositorio.Encontrar(filter);

            //return _colecao.Find(filter).ToList();

        }

        public void CarregaItensPorTipoItem(string guidCatalogo, string guidCategoria, string guidTipoItem)
        {

            List<ItemTubulacaoEstoque> tubulacaoEstoques = new List<ItemTubulacaoEstoque>();

            var ids = _propriedadesItemService.ObterPropriedadesID(guidCatalogo, guidCategoria, guidTipoItem);

            foreach (var id in ids)
            {

                ItemTubulacaoEstoque itemTubulacaoEstoque = new ItemTubulacaoEstoque(id.PnPID, id.GUID_CATALOG, id.GUID, guidCategoria, guidTipoItem);

                var props = _propriedadesItemService.ObterPropriedadesItemDTO(id, guidCategoria, guidTipoItem);

                foreach (var prop in props)
                {

                    foreach (var item in props)
                    {
                        string valor = item.VALOR_PROPRIEDADE.Replace('"', '¨');
                        itemTubulacaoEstoque.GetType().GetProperty(item.PROPRIEDADE).SetValue(itemTubulacaoEstoque, valor);
                    }


                }

                InserirItem(itemTubulacaoEstoque);

            }
        }



    }
}
