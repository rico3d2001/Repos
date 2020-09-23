using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoRelacaoPropriedadeItem
    {
        BaseMDBRepositorio<RelacaoPropriedadeItem> _relacaoPropriedadeItemRepositorio;

        public RepoRelacaoPropriedadeItem()
        {
            _relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
        }
        public List<RelacaoPropriedadeItem> ObterRelacoesEntrePropriedadeItem(ItemPipe itemDaFamilia)
        {
            return _relacaoPropriedadeItemRepositorio.Encontrar(
                   Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, itemDaFamilia.GUID));
        }

        public void Cadastrar(RelacaoPropriedadeItem relacaoPropriedadeItem)
        {
            _relacaoPropriedadeItemRepositorio.Inserir(relacaoPropriedadeItem);
        }

        public RelacaoPropriedadeItem ObterRelacao(PropriedadeItem propriedadeDoItem, ItemPipe itemPipeEstoque)
        {
            var relacoes = _relacaoPropriedadeItemRepositorio.Encontrar(
                   Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, itemPipeEstoque.GUID)
                   & Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, propriedadeDoItem.GUID));

            return relacoes.Count() == 1 ? relacoes.First() : null;
        }
    }
}
