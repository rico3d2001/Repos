using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoIdioma : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Idioma> _idiomaMDBRepositorio;
        public RepoIdioma(string conectionString) : base(conectionString)
        {
            _idiomaMDBRepositorio = new BaseMDBRepositorio<Idioma>(new ConexaoMongoDb("Catalogo", conectionString), "Idioma");
        }

        public Idioma ObterIdiomaPorLinguaPais(string lingua, string pais)
        {
            var idiomas = _idiomaMDBRepositorio.Encontrar(
                Builders<Idioma>.Filter.Eq(x => x.IDIOMA, lingua) 
                & Builders<Idioma>.Filter.Eq(x => x.PAIS, pais));

            return idiomas.Count() == 1 ? idiomas.First() : null;
        }

        public void CadastrarIdioma(Idioma idioma)
        {
            _idiomaMDBRepositorio.Inserir(idioma);
        }

        public Idioma ObterPorIdiomaComPais(string idioma, string pais)
        {
          var idiomas =  _idiomaMDBRepositorio.Encontrar(Builders<Idioma>.Filter.Eq(x => x.IDIOMA, idioma) & Builders<Idioma>.Filter.Eq(x => x.PAIS, pais));

            return idiomas.Count() == 1 ? idiomas.First() : null;
        }

        public void Cadastrar(Idioma idioma)
        {
            _idiomaMDBRepositorio.Inserir(idioma);
        }
    }
}
