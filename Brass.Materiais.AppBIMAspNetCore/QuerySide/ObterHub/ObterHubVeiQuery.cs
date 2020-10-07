using Brass.Materiais.DominioPQ.BIM.Entities;
using MediatR;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterHub
{
    public class ObterHubVeiQuery : IRequest<Hub>
    {
        public ObterHubVeiQuery(string siglaUsuario, string connectionString)
        {
            SiglaUsuario = siglaUsuario;
            TextoConecxao = connectionString;
        }

        public string SiglaUsuario { get; set; }
        public string TextoConecxao { get; set; }
    }
}
