using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterHub
{
    public class ObterHubQueryHandle : Notifiable, IRequestHandler<ObterHubQuery, Hub>
    {


        public Task<Hub> Handle(ObterHubQuery request, CancellationToken cancellationToken)
        {
            var hubRepositorio = new RepoHub(request.TextoConexao);

            var hub = hubRepositorio.ObterDaSiglaDoUsuario(request.SiglaUsuario);

            return Task.FromResult(hub);
        }
    }
}
