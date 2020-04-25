using Brass.Materiais.Dominio.Servico.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services
{
    public class RamalEstoqueService : BaseRepositorio<RamalEstoque>
    {
        public RamalEstoqueService() : base("Catalogo", "RamalEstoque") { }

        public void Carregar(List<RamalEstoque> ramais)
        {
            foreach (var ramal in ramais)
            {
                _colecao.InsertOne(ramal);
            }
        }

        public List<RamalEstoque> Listar()
        {
            return _colecao.AsQueryable().ToList();
        }
    }
}
