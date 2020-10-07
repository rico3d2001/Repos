using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterPQAtiva
{
    public class ObterPQAtivaQuery : IRequest<DataPQ>
    {
        

        public ObterPQAtivaQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ, string conectionString)
        {
            TextoConexao = conectionString;
            var repoProjetos = new RepoProjetos(conectionString);
            var projeto = repoProjetos.ObterProjeto(guidProjeto);
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(projeto, siglaUsuario, guidDisciplina), numeroPQ);
        }

        public IdentidadePQ IdentidadePQ { get; set; }
        public string TextoConexao { get; set; }

    }
}
