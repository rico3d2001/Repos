using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
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


       

        public async Task<Unit> Handle(AddAreaEstadoAppCommand command, CancellationToken cancellationToken)
        {
            _repoEstadoApp = new RepoEstadoApp(command.TextoConexao);

            var estado = _repoEstadoApp.ObterEstadoPorIdentidadePQ(command.IdentidadeEstado);
            AreaTag areaTag = AreaTag.ObterDoTag(command.IdentidadeEstado.GuidProjeto, command.Area + command.SubArea + command.Ativo);
            TipoAtivo tipoAtivo = TipoAtivo.ObterDaSigla(command.Ativo);
            estado.NumeroAtivo = new NumeroAtivo(areaTag, tipoAtivo);

            _repoEstadoApp.Modificar(estado);

            return Unit.Value;
        }
    }
}
