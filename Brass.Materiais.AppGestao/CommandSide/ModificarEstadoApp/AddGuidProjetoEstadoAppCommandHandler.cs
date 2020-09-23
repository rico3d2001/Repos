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
    public class AddGuidProjetoEstadoAppCommandHandler : Notifiable, IRequestHandler<AddGuidProjetoEstadoAppCommand>
    {
        RepoEstadoApp _repoEstadoApp;
        RepoProjetos _repoProjetos;

        public AddGuidProjetoEstadoAppCommandHandler()
        {

            _repoEstadoApp = new RepoEstadoApp();

        }


        public async Task<Unit> Handle(AddGuidProjetoEstadoAppCommand command, CancellationToken cancellationToken)
        {
            var estado = _repoEstadoApp
                .ObterEstadoPorUsuarioDisciplina(
                command.EstadoApp.IdentidadePQ.IdentidadeEstado.SiglaUsuario,
                command.EstadoApp.IdentidadePQ.IdentidadeEstado.GuidDisciplina);

            estado.IdentidadePQ.IdentidadeEstado.GuidProjeto = command.EstadoApp.IdentidadePQ.IdentidadeEstado.GuidProjeto;

          


            estado.NomeProjeto = command.EstadoApp.NomeProjeto;
            estado.SiglaProjeto = command.EstadoApp.SiglaProjeto;
            estado.Origem = command.EstadoApp.Origem;
            estado.Operacao = command.EstadoApp.Operacao;
            estado.Endereco = command.EstadoApp.Endereco;

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
