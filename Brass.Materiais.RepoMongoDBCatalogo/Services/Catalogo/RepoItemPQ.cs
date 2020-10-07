using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemPQ : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<ItemPQ> _repositorioItemPipePlant3d;
        public RepoItemPQ(string conectionString) : base(conectionString)
        {
            _repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQ>(new ConexaoMongoDb("BIM_TESTE", conectionString), "ItemPQPlant3d");
        }

        public void InserirItem(ItemPQ itemPQ) 
        {
            _repositorioItemPipePlant3d.Inserir(itemPQ);
        }

        public ItemPQ ObterItemPQ(NumeroAtivo numeroAtivo, string descricao)
        {
          var itens =  _repositorioItemPipePlant3d.Encontrar(
                Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.GUID_PROJETO, numeroAtivo.AreaTag.GUID_PROJETO)
              & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.Area, numeroAtivo.AreaTag.Area)
              & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.SubArea, numeroAtivo.AreaTag.SubArea)
              & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.Sigla, numeroAtivo.Sigla)
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

        public List<ItemPQ> Obter(string guidProjeto, string area, string subArea, string ativo)
        {
            return _repositorioItemPipePlant3d
                .Encontrar(Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.GUID_PROJETO, guidProjeto)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.Area, area)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.SubArea, subArea)
                & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.Sigla, ativo)
                );
        }

        public bool NuncaFoiCadastrado(string GUID_PROJETO)
        {
            var itens = _repositorioItemPipePlant3d.Encontrar(
                Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.GUID_PROJETO, GUID_PROJETO));

            return itens.Count > 0 ? false : true;

        }

        public List<ItemPQ> ObterListaPorResumo(List<ItemPQ> itens)
        {
            List<ItemPQ> lista = new List<ItemPQ>();

            foreach (var item in itens)
            {
                lista.Add(_repositorioItemPipePlant3d.Obter(item.GUID));
            }

            return lista;

        }

       
        public List<ItemPQ> ObterItensPQPorProjeto(string guidProjeto)
        {
            return _repositorioItemPipePlant3d.Encontrar(
            Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.NumeroAtivo.AreaTag.GUID_PROJETO, guidProjeto));
        }


        public void ModificarItemPQ(ItemPQ itemPQ)
        {
            _repositorioItemPipePlant3d.Atualizar(itemPQ);
        }

        public ItemPQ ObterPorGuid(string guid)
        {
           return _repositorioItemPipePlant3d.Obter(guid);
        }

      
    }
}
