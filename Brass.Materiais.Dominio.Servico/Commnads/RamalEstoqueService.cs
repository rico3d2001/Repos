using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class RamalEstoqueService
    {
        //public RamalEstoqueService() : base("Catalogo", "RamalEstoque") { }

        BaseMDBRepositorio<RamalEstoque> _repositorio;

        public RamalEstoqueService(BaseMDBRepositorio<RamalEstoque> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Carregar(List<RamalEstoque> ramais)
        {
            foreach (var ramal in ramais)
            {
                _repositorio.Inserir(ramal);
                //_colecao.InsertOne(ramal);
            }
        }

        public List<RamalEstoque> Listar()
        {
            return _repositorio.Obter(); //_colecao.AsQueryable().ToList();
        }
    }
}
