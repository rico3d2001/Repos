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
    public class AddGuidPQEstadoAppCommandHandler : Notifiable, IRequestHandler<AddGuidPQEstadoAppCommand>
    {

        RepoEstadoApp _repoEstadoApp;
        RepoResumo _repoResumo;

        public AddGuidPQEstadoAppCommandHandler()
        {

            _repoEstadoApp = new RepoEstadoApp();
            _repoResumo = new RepoResumo();
        }


        public async Task<Unit> Handle(AddGuidPQEstadoAppCommand command, CancellationToken cancellationToken)
        {
            var resumo =  _repoResumo.ObterResumo(command.IdentidadePQ);

            var estado = _repoEstadoApp.ObterEstadoPorProjetoUsuarioDisciplina(command.IdentidadePQ.IdentidadeEstado);

            estado.IdentidadePQ.NumeroPQ = command.IdentidadePQ.NumeroPQ;
            estado.ResumoAtivo = resumo.EstaAtivo;
            estado.PQEstaEmitida = resumo.EstaAtivo ? false : true;

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
