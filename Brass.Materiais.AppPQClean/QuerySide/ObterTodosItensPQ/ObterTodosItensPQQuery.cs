using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterTodosItensPQ
{
    public class ObterTodosItensPQQuery : IRequest<ItemPQ[]>
    {
        public ObterTodosItensPQQuery(string guidProjeto)
        {
            GuidProjeto = guidProjeto;
        }

        public string GuidProjeto { get; set; }
    }
}
