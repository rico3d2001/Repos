using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoLinhas : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<Linha> _repoLinhas;

        public RepoLinhas(string conectionString) : base(conectionString)
        {
            _repoLinhas = new BaseMDBRepositorio<Linha>(new ConexaoMongoDb("Coletados", conectionString), "Linhas");
        }

        public void Cadastrar(Linha linha)
        {
            _repoLinhas.Inserir(linha);
        }

        public List<Linha> ObterDoNumeroAtivo(NumeroAtivo numeroAtivo)
        {
            return _repoLinhas.Encontrar(
                         Builders<Linha>.Filter.Eq(x => x.NumeroAtivo.AreaTag.Area, numeroAtivo.AreaTag.Area)
                         & Builders<Linha>.Filter.Eq(x => x.NumeroAtivo.AreaTag.SubArea, numeroAtivo.AreaTag.SubArea)
                         & Builders<Linha>.Filter.Eq(x => x.NumeroAtivo.Sigla, numeroAtivo.Sigla));
        }

        public void ApagarDoProjeto(string guidProjeto)
        {
            _repoLinhas.ApagarVarios(Builders<Linha>.Filter.Eq(x => x.NumeroAtivo.AreaTag.GUID_PROJETO, guidProjeto));
        }
    }
}
