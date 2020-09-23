using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterHub
{
    public class ObterHubVeiQuery : IRequest<Hub>
    {
        public ObterHubVeiQuery(string siglaUsuario)
        {
            SiglaUsuario = siglaUsuario;
        }

        public string SiglaUsuario { get; set; }
    }
}
