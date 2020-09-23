using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoItemPQ
    {
        BaseMDBRepositorio<ItemPQ> _repositorioItemPipePlant3d;
        public RepoItemPQ()
        {
            _repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
        }

        public void InserirItem(ItemPQ itemPQ)
        {
            _repositorioItemPipePlant3d.Inserir(itemPQ);
        }

        public ItemPQ ObterItemPQ(string area, string subArea, string descricao)
        {
          var itens =  _repositorioItemPipePlant3d.Encontrar(
              Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.Area, area)
              & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.SubArea, subArea)
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
            Builders<ItemPQ>.Filter.Eq(x => x.GuidProjeto, guidProjeto));
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
