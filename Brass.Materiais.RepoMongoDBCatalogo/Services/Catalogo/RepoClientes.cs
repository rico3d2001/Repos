using Brass.Materiais.DominioPQ.Catalogo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoClientes : RepositorioAbstratoGeral
    {

        BaseMDBRepositorio<Cliente> _repoClientes;
        public RepoClientes(string conectionString) : base(conectionString)
        {
            _repoClientes = new BaseMDBRepositorio<Cliente>(new ConexaoMongoDb("BIM", conectionString), "Clientes");

        }

        public List<Cliente> ObterTodos()
        {
           return  _repoClientes.Obter();
        }

        public void Cadastar(Cliente cliente)
        {
            _repoClientes.Inserir(cliente);
        }


    }
}
