using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterResumoPipe
{
    public class ObterResumoPipeQuery : IRequest<ResumoViewModel>
    {
        public ObterResumoPipeQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ)
        {
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina), numeroPQ);
        }

        public IdentidadePQ IdentidadePQ { get; set; }
    }
}
