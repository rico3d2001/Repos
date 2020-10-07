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
        public ObterTodosItensPQQuery(string guidProjeto, int pagina, int limite, string conectionString)
        {
            GuidProjeto = guidProjeto;
            Pagina = pagina;
            Limite = limite;
            TextoConexao = conectionString;
        }

        public string GuidProjeto { get; set; }
        public int Pagina { get; set; }
        public int Limite { get; set; }
        public string TextoConexao { get; set; }
    }
}
