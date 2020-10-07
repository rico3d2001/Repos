using Brass.Materiais.DominioPQ.PQ.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterTabelaAtividades
{
    public class ObterTabelaAtividadesQuery : IRequest<TabelaAtividades>
    {
        public ObterTabelaAtividadesQuery(string conectionString)
        {
            TextoConexao = conectionString;
        }

        public string TextoConexao { get; set; }
    }
}
