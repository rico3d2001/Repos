using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterPQ
{
    public class ObterPQQuery : IRequest<DataPQ>
    {
        PlanilhaPQ<LinhaVale> _planilhaVale;

        public ObterPQQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ, string conectionString)
        {
            TextoConexao = conectionString;
            var repoProjetos = new RepoProjetos(TextoConexao);
            var projeto = repoProjetos.ObterProjeto(guidProjeto);
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(projeto, siglaUsuario, guidDisciplina), numeroPQ);
        }



       public IdentidadePQ IdentidadePQ { get; set; }

        private void selectPlanilha(string disciplina)
        {
            switch (disciplina)
            {
                case "Tubulacao":
                    _planilhaVale = new PlanPIPEVale();
                    break;
            }
        }

        public PlanilhaPQ<LinhaVale> Planilha { get => _planilhaVale; }
        public string TextoConexao { get; set; }

    }
}
