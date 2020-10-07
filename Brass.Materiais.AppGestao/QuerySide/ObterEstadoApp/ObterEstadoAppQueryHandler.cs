using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.QuerySide.ObterEstadoApp
{
    public class ObterEstadoAppQueryHandler : Notifiable, IRequestHandler<ObterEstadoAppQuery, EstadoApp>
    {
        RepoEstadoApp _repoEstadoApp;
       



        public Task<EstadoApp> Handle(ObterEstadoAppQuery request, CancellationToken cancellationToken)
        {
            _repoEstadoApp = new RepoEstadoApp(request.TextoConexao);

            var estado = _repoEstadoApp.ObterEstadoPorIdentidadePQ(request.IdentidadeEstado);


            return Task.FromResult(estado);
        }
    }
}
