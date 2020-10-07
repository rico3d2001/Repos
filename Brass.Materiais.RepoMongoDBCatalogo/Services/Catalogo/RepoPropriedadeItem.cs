using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoPropriedadeItem : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<PropriedadeItem> _propriedadeItemRepositorio;
        BaseMDBRepositorio<NomeTipoPropriedade> _nomeTipoPropriedadeRepositorio;

        public RepoPropriedadeItem(string conectionString) : base(conectionString)
        {
            _propriedadeItemRepositorio = new BaseMDBRepositorio<PropriedadeItem>(new ConexaoMongoDb("Catalogo", conectionString), "PropriedadeItem");
            _nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>(new ConexaoMongoDb("Catalogo", conectionString), "NomeTipoPropriedade");
        }
        public List<PropriedadeItem> ObterPropriedadesDisponiveis(string nomePropriedade)
        {
            string guidNomePropriedade = obtemGuidDePropriedade(nomePropriedade);
            return _propriedadeItemRepositorio.Encontrar(
                Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, guidNomePropriedade));
        }

        private string obtemGuidDePropriedade(string nomePropriedade)
        {
            return _nomeTipoPropriedadeRepositorio
               .Encontrar(Builders<NomeTipoPropriedade>
               .Filter.Eq(x => x.NOME, nomePropriedade)).First().GUID;
        }

        public PropriedadeItem ObterPorTipoMaisValor(string guidTipo, string guidValor)
        {
            var propriedades = _propriedadeItemRepositorio.Encontrar(
                Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, guidTipo)
                & Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_VALOR, guidValor));

            return propriedades.Count() == 1 ? propriedades.First() : null;
        }

        

        public void Cadastrar(PropriedadeItem propriedade)
        {
            _propriedadeItemRepositorio.Inserir(propriedade);
        }
    }
}
