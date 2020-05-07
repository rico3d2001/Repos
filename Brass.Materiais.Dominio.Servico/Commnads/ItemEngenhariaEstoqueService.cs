using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Service;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class ItemEngenhariaEstoqueService
    {
        PropriedadesItemService _propriedadesItemService;
        BaseMDBRepositorio<ItemTubulacaoEstoque> _repositorio;
        private PropriedadesItemService propriedadesItemService;

        public ItemEngenhariaEstoqueService(PropriedadesItemService propriedadesItemService)
        {
            this.propriedadesItemService = propriedadesItemService;
        }

        public ItemEngenhariaEstoqueService(PropriedadesItemService propriedadesItemService, BaseMDBRepositorio<ItemTubulacaoEstoque> repositorio) //: base("Catalogo", "ItensEstoque")
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
