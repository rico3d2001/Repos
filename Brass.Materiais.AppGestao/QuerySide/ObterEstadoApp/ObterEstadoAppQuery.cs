using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp
{
    public class ObterEstadoAppQuery : IRequest<EstadoApp>
    {
        public ObterEstadoAppQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, string conectionString)//, string guidDisciplina)
        {
            TextoConexao = conectionString;
            var repoProjetos = new RepoProjetos(conectionString);
            var projeto = repoProjetos.ObterProjeto(guidProjeto);
            IdentidadeEstado = new IdentidadeEstado(projeto, siglaUsuario, guidDisciplina);
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }

        public string TextoConexao { get; set; }
    }
}
