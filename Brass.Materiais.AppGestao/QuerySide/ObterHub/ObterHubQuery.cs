using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterHub
{
    public class ObterHubQuery : IRequest<Hub>
    {
        public ObterHubQuery(string siglaUsuario, string conectionString)
        {
            TextoConexao = conectionString;
            SiglaUsuario = siglaUsuario;
        }

        public string SiglaUsuario { get; set; }
        public string TextoConexao { get; set; }
    }
}
