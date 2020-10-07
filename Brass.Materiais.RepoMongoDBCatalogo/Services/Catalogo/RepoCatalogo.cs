using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoCatalogo : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<CatalogoEntidade> _catalogosMDBRepositorio;
        public RepoCatalogo(string conectionString) : base(conectionString)
        {
            _catalogosMDBRepositorio = new BaseMDBRepositorio<CatalogoEntidade>(new ConexaoMongoDb("Catalogo", conectionString), "Catalogo");
        }

        public CatalogoEntidade ObterPorNome(string nomeCatalogo)
        {
          var catalogos =  _catalogosMDBRepositorio.Encontrar(Builders<CatalogoEntidade>.Filter.Eq(x => x.NOME, nomeCatalogo));

            return catalogos.Count == 1 ? catalogos.First() : null;
            
        }

      

        public List<CatalogoEntidade> ObterPorGuidDisciplina(string guidDisciplina)
        {
            return _catalogosMDBRepositorio.Encontrar(Builders<CatalogoEntidade>.Filter.Eq(x => x.GUID_DISCIPLINA, guidDisciplina));
        }

        public void CadastrarCatalogo(CatalogoEntidade catalogo)
        {
            _catalogosMDBRepositorio.Inserir(catalogo);
        }
    }
}
