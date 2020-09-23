using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.CommandSide.IniciarEstadoApp
{
    public class IniciarEstadoAppCommandHandler : Notifiable, IRequestHandler<IniciarEstadoAppCommand>
    {
        RepoEstadoApp _repoEstadoApp;

        public IniciarEstadoAppCommandHandler()
        {

            _repoEstadoApp = new RepoEstadoApp();

        }

        public async Task<Unit> Handle(IniciarEstadoAppCommand command, CancellationToken cancellationToken)
        {
            
            if (NaoFoiCadastradoEstado(command.IdentidadeEstado))
            {
                CriarEstado(command);
            }
            else
            {
                ReiniciarEstado(command.IdentidadeEstado);
            }

            return Unit.Value;
        }

        private void ReiniciarEstado(IdentidadeEstado identidadeEstado)
        {
            var estado = _repoEstadoApp.ObterEstadoPorUsuarioDisciplina(identidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina);
            estado.Reset(identidadeEstado);
            _repoEstadoApp.Modificar(estado);
        }

        private void CriarEstado(IniciarEstadoAppCommand command)
        {
            EstadoApp estadoApp = new EstadoApp(command.IdentidadeEstado.SiglaUsuario, command.IdentidadeEstado.GuidDisciplina);
            _repoEstadoApp.CadastrarEstado(estadoApp);
        }

        private bool NaoFoiCadastradoEstado(IdentidadeEstado identidadeEstado)
        {
            var estado = _repoEstadoApp.ObterEstadoPorUsuarioDisciplina(identidadeEstado.SiglaUsuario, identidadeEstado.GuidDisciplina);
            return estado == null ? true : false;
        }
    }
}
