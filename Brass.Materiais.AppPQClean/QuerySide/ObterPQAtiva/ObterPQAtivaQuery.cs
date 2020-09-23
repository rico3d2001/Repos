using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
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
        public ObterPQAtivaQuery(string guidProjeto, string siglaUsuario, string guidDisciplina, int numeroPQ)
        {
            IdentidadePQ = new IdentidadePQ(new IdentidadeEstado(guidProjeto, siglaUsuario, guidDisciplina), numeroPQ);
        }

        public IdentidadePQ IdentidadePQ { get; set; }

    }
}
