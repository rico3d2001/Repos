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

        


        public async Task<Unit> Handle(AddGuidProjetoEstadoAppCommand command, CancellationToken cancellationToken)
        {
            _repoEstadoApp = new RepoEstadoApp(command.TextoConexao);

            var estado = _repoEstadoApp
                .ObterEstadoPorUsuarioDisciplina(
                command.EstadoApp.IdentidadePQ.IdentidadeEstado.SiglaUsuario,
                command.EstadoApp.IdentidadePQ.IdentidadeEstado.GuidDisciplina);

            estado.IdentidadePQ.IdentidadeEstado.GuidProjeto = command.EstadoApp.IdentidadePQ.IdentidadeEstado.GuidProjeto;

          


            //estado.IdentidadePQ.IdentidadeEstado.Projeto.NomeProjeto = command.EstadoApp.IdentidadePQ.IdentidadeEstado.Projeto.NomeProjeto;
            //estado.IdentidadePQ.IdentidadeEstado.Projeto.Sigla = command.EstadoApp.IdentidadePQ.IdentidadeEstado.Projeto.Sigla;
            //estado.IdentidadePQ.IdentidadeEstado.Projeto.Origem = command.EstadoApp.IdentidadePQ.IdentidadeEstado.Projeto.Origem;
            estado.Operacao = command.EstadoApp.Operacao;
            //estado.IdentidadePQ.IdentidadeEstado.Projeto.Endereco = command.EstadoApp.IdentidadePQ.IdentidadeEstado.Projeto.Endereco;

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
