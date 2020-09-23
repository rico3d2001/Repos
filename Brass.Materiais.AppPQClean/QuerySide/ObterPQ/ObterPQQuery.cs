using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterPQ
{
    public class ObterPQQuery : IRequest<DataPQ>
    {
        PlanilhaPQ<LinhaVale> _planilhaVale;

        public ObterPQQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ)
        {
 
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina), numeroPQ);
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

    }
}
