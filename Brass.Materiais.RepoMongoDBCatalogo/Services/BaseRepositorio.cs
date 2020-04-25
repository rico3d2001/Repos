using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services
{
    public class BaseRepositorio<TColecao>
    {
        protected IMongoClient _client;
        protected IMongoDatabase _db;
        protected IMongoCollection<TColecao> _colecao;

        public BaseRepositorio(string db, string colecao)
        {
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase(db);
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
            _colecao.InsertOne(modelo);
        }

        public virtual void Atualizar(TColecao modelo)
        {
            var filtroPorId = Builders<TColecao>.Filter.Eq("_id", modelo.ToBsonDocument().GetElement("_id").Value);
            _colecao.ReplaceOne(filtroPorId, modelo);
        }

        public virtual void Remover(TColecao modelo)
        {
            var filtroPorId = Builders<TColecao>.Filter.Eq("_id", modelo.ToBsonDocument().GetElement("_id").Value);
            _colecao.DeleteOne(filtroPorId);
        }


    }
}
