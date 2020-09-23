using Brass.Materiais.DominioPQ.Catalogo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoClientes
    {

        BaseMDBRepositorio<Cliente> _repoAreasDiagramas;
        public RepoClientes()
        {
            _repoAreasDiagramas = new BaseMDBRepositorio<Cliente>("BIM", "Clientes");
        }


    }
}
