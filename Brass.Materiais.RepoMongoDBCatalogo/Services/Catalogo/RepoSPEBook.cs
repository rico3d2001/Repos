using Brass.Materiais.DominioPQ.Catalogo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoSPEBook : RepositorioAbstratoGeral
    {

        BaseMDBRepositorio<SPEBook> _repoBookSPE;

        public RepoSPEBook(string conectionString) : base(conectionString)
        {
            _repoBookSPE = new BaseMDBRepositorio<SPEBook>(new ConexaoMongoDb("Catalogo", conectionString), "SPEBooks");
        }

        public void Cadastrar(SPEBook bookSPE)
        {
            _repoBookSPE.Inserir(bookSPE);
        }

        public object ObterTodos()
        {
           return  _repoBookSPE.Obter();
        }

        public SPEBook ObterPorGuid(string guid)
        {
            return _repoBookSPE.Obter(guid);
        }
    }
}
