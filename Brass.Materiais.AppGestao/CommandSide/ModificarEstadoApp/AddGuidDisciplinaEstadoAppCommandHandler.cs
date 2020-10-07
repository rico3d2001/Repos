using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp
{
    public class AddGuidDisciplinaEstadoAppCommandHandler : Notifiable, IRequestHandler<AddGuidDisciplinaEstadoAppCommand>
    {
        RepoEstadoApp _repoEstadoApp;

      


        public async Task<Unit> Handle(AddGuidDisciplinaEstadoAppCommand command, CancellationToken cancellationToken)
        {

            _repoEstadoApp = new RepoEstadoApp(command.TextoConexao);

            var estado = _repoEstadoApp.ObterEstadoPorUsuario(command.IdentidadeEstado.SiglaUsuario);

            estado.IdentidadePQ.IdentidadeEstado.GuidDisciplina = command.IdentidadeEstado.GuidDisciplina;

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
