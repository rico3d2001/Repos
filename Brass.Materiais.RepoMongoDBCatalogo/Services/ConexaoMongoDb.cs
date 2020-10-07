using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services
{
    public class ConexaoMongoDb
    {
        string _dbNome;
        string _conectionString;
        IMongoClient _client;
        IMongoDatabase _db;


        public ConexaoMongoDb(string dbNome, string conectionString)
        {
            _dbNome = dbNome;
            _conectionString = conectionString;
        }

        public IMongoDatabase Conectar()
        {
            switch (_conectionString)
            {
                case "local":
                    _client = new MongoClient("mongodb://localhost");
                    return _client.GetDatabase(_dbNome);
                case "testeAtlas":
                    _client = new MongoClient($"mongodb+srv://rico3d:umsamija45@cluster0.4qsho.mongodb.net/PQBrass?retryWrites=true&w=majority");
                    return _client.GetDatabase(_dbNome);
                default:
                    _client = new MongoClient(_conectionString);
                    return _client.GetDatabase(_dbNome);

            }

            
        }

     

    }
}
