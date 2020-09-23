using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp
{
    public class ObterEstadoAppQuery : IRequest<EstadoApp>
    {
        public ObterEstadoAppQuery(string guidProjeto, string siglaUsuario, string guidDisciplina)//, string guidDisciplina)
        {
            IdentidadeEstado = new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina);
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }

      
    }
}
