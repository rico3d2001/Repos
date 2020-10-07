using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public abstract class RepositorioAbstratoGeral
    {
        protected string _conectionString;

        public RepositorioAbstratoGeral(string conectionString)
        {
            _conectionString = conectionString;
        }
    }
}
