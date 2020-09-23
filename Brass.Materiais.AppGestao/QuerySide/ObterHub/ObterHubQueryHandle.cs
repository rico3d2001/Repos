using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
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

        BaseMDBRepositorio<Hub> _hubRepositorio;

        public ObterHubQueryHandle()
        {
            _hubRepositorio = new BaseMDBRepositorio<Hub>("BIM", "Hubs");
        }

        public Task<Hub> Handle(ObterHubQuery request, CancellationToken cancellationToken)
        {
            var hub = _hubRepositorio.Encontrar(
                   Builders<Hub>.Filter.Eq(x => x.Usuario.Sigla, request.SiglaUsuario)).First();

            return Task.FromResult(hub);
        }
    }
}
