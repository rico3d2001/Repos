using Brass.Materiais.RepoMongoDBCatalogo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoRamalEstoque : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<RamalArvoreCatalogo> _ramalRepo;

        public RepoRamalEstoque(string conectionString) : base(conectionString)
        {
            _ramalRepo = new BaseMDBRepositorio<RamalArvoreCatalogo>(new ConexaoMongoDb("Catalogo", conectionString), "RamalEstoque");
        }
    }
}
