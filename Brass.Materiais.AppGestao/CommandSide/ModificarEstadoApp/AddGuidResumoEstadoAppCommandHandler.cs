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
    public class AddGuidResumoEstadoAppCommandHandler : Notifiable, IRequestHandler<AddGuidResumoEstadoAppCommand>
    {
        RepoResumo _repoResumo;

    


        public async Task<Unit> Handle(AddGuidResumoEstadoAppCommand command, CancellationToken cancellationToken)
        {
            _repoResumo = new RepoResumo(command.TextoConexao);

            var resumo = _repoResumo.ObterResumo(command.IdentidadePQ);

            resumo.IdentidadePQ.NumeroPQ = command.IdentidadePQ.NumeroPQ;

            _repoResumo.Modificar(resumo);

            //_repoEstadoApp
            //.ObterEstadoPorProjetoUsuarioDisciplina(
            //command.IdentidadeEstado.GuidProjeto,command.IdentidadeEstado.SiglaUsuario, command.IdentidadeEstado.GuidDisciplina);

            //estado.IdentidadeEstado.NumeroPQ = command.NumeroPQ;

            //_repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
