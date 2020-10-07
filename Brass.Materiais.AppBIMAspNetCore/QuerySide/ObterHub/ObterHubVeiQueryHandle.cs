using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIMAspNetCore.QuerySide.ObterHub
{
    public class ObterHubVeiQueryHandle : Notifiable, IRequestHandler<ObterHubVeiQuery, Hub>
    {

      

        public Task<Hub> Handle(ObterHubVeiQuery request, CancellationToken cancellationToken)
        {
            var hubRepositorio = new RepoHub(request.TextoConecxao);

            var hub = hubRepositorio.ObterDaSiglaDoUsuario(request.SiglaUsuario);
               

            return Task.FromResult(hub);
        }
    }
}
