using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemPipe
    {
      
        BaseMDBRepositorio<PropriedadeItem> _propriedadeItemRepositorio;
        BaseMDBRepositorio<ValorTabelado> _valorTabeladoRepositorio;
        BaseMDBRepositorio<RelacaoPropriedadeItem> _relacaoPropriedadeItemRepositorio;
        BaseMDBRepositorio<ItemPipe> _repositorioItemPipe;

        public RepoItemPipe()
        {
            _propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            _valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            _relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");
            _repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
        }

        public void CadastrarItemPipe(ItemPipe item)
        {
            _repositorioItemPipe.Inserir(item);
        }

        public ItemPipe ObterPorGuid(string guid)
        {
            return _repositorioItemPipe.Obter(guid);
        }


        public int Contar()
        {
            return _repositorioItemPipe.Obter().Count();
        }

        
        public ItemPipe ObterPorTipoDeItemNoCatalogo(TipoItemEng tipoItemEng, CatalogoEntidade catalogo)
        {
            var itens = _repositorioItemPipe.Encontrar(
                                  Builders<ItemPipe>.Filter.Eq(x => x.GUID_TIPO_ITEM, tipoItemEng.GUID)
                                  & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, catalogo.GUID));

            return itens.Count() == 1 ? itens.First() : null;
        }


        public ItemPipe ObterPorDescricaoComplexa(string descricao, string guidCatalogo)
        {
            ItemPipe itemPipe = null;

            var valores = _valorTabeladoRepositorio.Encontrar(Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, descricao));

            if (valores.Count == 1)
            {
                var valor = valores.First();
                var propriedade = _propriedadeItemRepositorio.Encontrar(
               Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_VALOR, valor.GUID)).First();

                var itemRelacionado = _relacaoPropriedadeItemRepositorio.Encontrar(
                    Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_PROPRIEDADE, propriedade.GUID)).First();

                itemPipe = _repositorioItemPipe.Obter(itemRelacionado.GUID_ITEM_ENG);
            }
            else if (valores.Count > 1)
            {
                var valor = valores.First();
            }
            else
            {
                valores = null;
            }

            return itemPipe;

        }

        public List<ItemPipe> ObterItensCatalogadosDaFamilia(string guidFamilia)
        {
            return _repositorioItemPipe.Encontrar(Builders<ItemPipe>.Filter.Eq(x => x.GUID_FAMILIA, guidFamilia));
        }

        public List<ItemPipe> ObterTodosDoCatalogo(string guidCatalogo)
        {
            return _repositorioItemPipe.Encontrar(Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));
        }

        public void Modificar(ItemPipe itemPipe)
        {
            _repositorioItemPipe.Atualizar(itemPipe);
        }
    }
}

