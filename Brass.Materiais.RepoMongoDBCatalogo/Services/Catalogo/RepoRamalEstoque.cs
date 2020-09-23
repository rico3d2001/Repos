using Brass.Materiais.RepoMongoDBCatalogo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoRamalEstoque
    {
        BaseMDBRepositorio<RamalArvoreCatalogo> _ramalRepo;

        public RepoRamalEstoque()
        {
            var _ramalRepo = new BaseMDBRepositorio<RamalArvoreCatalogo>("Catalogo", "RamalEstoque");
        }
    }
}
