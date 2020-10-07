﻿using Brass.Materiais.DominioPQ.BIM.Coleta;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services
{
    public class BaseMDBRepositorio<TColecao>
    {
        protected IMongoClient _client;
        //protected IMongoDatabase _db;
        protected IMongoCollection<TColecao> _colecao;


        public BaseMDBRepositorio(ConexaoMongoDb conexaoMongo, string colecao)
        {
            IMongoDatabase _db = conexaoMongo.Conectar();

          

            _colecao = _db.GetCollection<TColecao>(colecao);


        }

        public virtual TColecao Obter(string guid)
        {
            var filterGUID = Builders<TColecao>.Filter.Eq("GUID", guid);

            return _colecao.Find(filterGUID).FirstOrDefault();
        }

        public virtual List<TColecao> Obter()
        {
            return _colecao.AsQueryable<TColecao>().ToList();
        }

        public virtual void Inserir(IList<TColecao> lista)
        {
            _colecao.InsertMany(lista);
        }

        public virtual void Inserir(TColecao modelo)
        {
            _colecao.InsertOneAsync(modelo);
        }

        public virtual void Atualizar(TColecao modelo)
        {
            var filtroPorId = Builders<TColecao>.Filter.Eq("_id", modelo.ToBsonDocument().GetElement("_id").Value);
            _colecao.FindOneAndReplace(filtroPorId, modelo);
            //_colecao.UpdateOne(filtroPorId,modelo);//.ReplaceOne(filtroPorId, modelo);
        }

        internal void ApagarVarios(FilterDefinition<TColecao> filtro)
        {
            _colecao.DeleteMany(filtro);
        }

        public virtual void Remover(TColecao modelo)
        {
            var filtroPorId = Builders<TColecao>.Filter.Eq("_id", modelo.ToBsonDocument().GetElement("_id").Value);
            _colecao.DeleteOne(filtroPorId);
        }

     

        public virtual List<TColecao> Encontrar(FilterDefinition<TColecao> filtro)
        {
            return _colecao.Find(filtro).ToList();
        }

        public bool PossuiUmRegistro(FilterDefinition<TColecao> filtro)
        {
            CountOptions countOptions = new CountOptions()
            {
                Limit = 1
            };
            var contagem = _colecao.CountDocuments(filtro, countOptions);

            return contagem > 0 ? true : false;

        }

        public long Contar(FilterDefinition<TColecao> filtro)
        {
            CountOptions countOptions = new CountOptions();

               return _colecao.CountDocuments(filtro, countOptions);
        }

  


    }
}
