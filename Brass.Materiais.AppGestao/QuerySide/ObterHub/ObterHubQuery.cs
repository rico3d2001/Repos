using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppGestao.QuerySide.ObterHub
{
    public class ObterHubQuery : IRequest<Hub>
    {
        public ObterHubQuery(string siglaUsuario)
        {
            SiglaUsuario = siglaUsuario;
        }

        public string SiglaUsuario { get; set; }
    }
}
