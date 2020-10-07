using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoRelacaoEntrePropriedades : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<RelacaoEntrePropriedades> _repoRelacaoEntrePropriedades;

        public RepoRelacaoEntrePropriedades(string conectionString) : base(conectionString)
        {
            _repoRelacaoEntrePropriedades = new BaseMDBRepositorio<RelacaoEntrePropriedades>(new ConexaoMongoDb("Catalogo", conectionString), "RelacaoEntrePropriedades");
        }

        public RelacaoEntrePropriedades ObterRelacaoEntrePropriedades(string tipoItem, string nomeTipoPropriedade)
        {
            var filtroRelacaoEntrePropriedades =
                                       Builders<RelacaoEntrePropriedades>.Filter.Eq(x => x.GUID_PNPTABLE, tipoItem)
                                       & Builders<RelacaoEntrePropriedades>.Filter.Eq(x => x.GUID_PROPIEDADE, nomeTipoPropriedade);

            var relacoes = _repoRelacaoEntrePropriedades.Encontrar(filtroRelacaoEntrePropriedades);

            return relacoes.Count() == 1 ? relacoes.First() : null;
        }

        public void Cadastrar(RelacaoEntrePropriedades relacao)
        {
            _repoRelacaoEntrePropriedades.Inserir(relacao);
        }
    }
}
