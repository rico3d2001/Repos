using Brass.Materiais.DominioPQ.Catalogo.Entities;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterClientes
{
    public class ObterClientesQuery : IRequest<Cliente[]>
    {
        public ObterClientesQuery(string conectionString)
        {
            TextoConexao = conectionString;
        }

        public string TextoConexao { get; set; }
    }
}
