using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemDiagramasPlant3d : RepositorioAbstratoGeral
    {

        BaseMDBRepositorio<ItemPQ> _repositorioItemPipePlant3d;

        public RepoItemDiagramasPlant3d(string conectionString) : base(conectionString)
        {
            _repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQ>(new ConexaoMongoDb("BIM_TESTE", conectionString), "ItemDiagramasPlant3d");
        }

        public void InserirItemDiagramaPlant3d(ItemPQ itemPQ)
        {
            _repositorioItemPipePlant3d.Inserir(itemPQ);
        }

        public ItemPQ ObterItemPQ(string area, string subArea, string ativo, string descricao)
        {
            var itens = _repositorioItemPipePlant3d.Encontrar(
                Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.Area, area)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.SubArea, subArea)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.Sigla, ativo)
                & Builders<ItemPQ>.Filter.Eq(x => x.SpecPart, descricao));

            if (itens.Count == 1)
            {
                return itens.First();
            }
            else if (itens.Count > 1)
            {
                throw new Exception("Existem mais de um item de diagrama para a mesma subaarea");
            }

            return null;
        }

        public List<ItemPQ> ObterItensPQPorProjeto(string guidProjeto)
        {
            return _repositorioItemPipePlant3d.Encontrar(
            Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.GUID_PROJETO, guidProjeto));
        }

    }
}
