using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemPipe : RepositorioAbstratoGeral
    {

        string _conectionString;
        BaseMDBRepositorio<ItemPipe> _repositorioItemPipe;
        public RepoItemPipe(string conectionString) : base(conectionString)
        {
            _conectionString = conectionString;
            _repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>(new ConexaoMongoDb("Catalogo", _conectionString), "ItemPipe");
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

            var valorTabeladoRepositorio = new BaseMDBRepositorio<ValorTabelado>(new ConexaoMongoDb("Catalogo", _conectionString), "ValorTabelado");
            var propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>(new ConexaoMongoDb("Catalogo", _conectionString), "PropriedadeItem");
            var relacaoPropriedadeItemRepositorio = new BaseMDBRepositorio<RelacaoPropriedadeItem>(new ConexaoMongoDb("Catalogo", _conectionString), "RelacaoPropriedadeItem");

            var valores = valorTabeladoRepositorio.Encontrar(Builders<ValorTabelado>.Filter.Eq(x => x.VALOR, descricao));

            if (valores.Count == 1)
            {
                var valor = valores.First();
                var propriedade = propriedadeItemRepositorio.Encontrar(
               Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_VALOR, valor.GUID)).First();

                var itemRelacionado = relacaoPropriedadeItemRepositorio.Encontrar(
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

        public List<ItemPipe> ObterTodos()
        {
            return _repositorioItemPipe.Obter();
        }

        public ItemPipe ObterPorPnPIDComCatalogo(int pnPID, string catalogoGUID)
        {
            var itens = _repositorioItemPipe.Encontrar(
            Builders<ItemPipe>.Filter.Eq(x => x.PnPID, pnPID)
            & Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, catalogoGUID)).ToList();

            return itens.Count() == 1 ? itens.First() : null;
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

