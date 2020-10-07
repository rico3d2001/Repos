using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterResumoPipe
{
    public class ObterResumoPipeQuery : IRequest<ResumoViewModel>
    {
        public ObterResumoPipeQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ, string connectionString)
        {
            TextoConexao = connectionString;
            var repoProjetos = new RepoProjetos(TextoConexao);
            var projeto = repoProjetos.ObterProjeto(guidProjeto);
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(projeto, siglaUsuario, guidDisciplina), numeroPQ);
        }

        public IdentidadePQ IdentidadePQ { get; set; }
        public string TextoConexao { get; set; }
    }
}
