using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterListaPQs
{
    public class ObterListaPQsQuery : IRequest<List<EstadoApp>>
    {
        public ObterListaPQsQuery(string siglaUsuario, string guidProjeto, string guidDiscilina)
        {
            IdentidadeEstado = new IdentidadeEstado(guidProjeto, siglaUsuario, guidDiscilina);
         }

        public IdentidadeEstado IdentidadeEstado { get; set; }
    }
}
