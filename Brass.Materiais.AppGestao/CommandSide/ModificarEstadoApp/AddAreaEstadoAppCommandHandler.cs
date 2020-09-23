using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp
{
    public class AddAreaEstadoAppCommandHandler : Notifiable, IRequestHandler<AddAreaEstadoAppCommand>
    {
        RepoEstadoApp _repoEstadoApp;

        public AddAreaEstadoAppCommandHandler()
        {

            _repoEstadoApp = new RepoEstadoApp();

        }

        public async Task<Unit> Handle(AddAreaEstadoAppCommand command, CancellationToken cancellationToken)
        {

            var estado = _repoEstadoApp.ObterEstadoPorIdentidadePQ(command.IdentidadeEstado);

            estado.NumeroArea = command.Area;
            estado.NumeroSubArea = command.SubArea;

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
