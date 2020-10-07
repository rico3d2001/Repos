using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.VinculaPQEmResumo
{
    public class VinculaPQEmResumoCommandHandler : Notifiable, IRequestHandler<VinculaPQEmResumoCommand>
    {


        public async Task<Unit> Handle(VinculaPQEmResumoCommand command, CancellationToken cancellationToken)
        {

            var repoResumo = new RepoResumo(command.Conexao);

            var resumo  = repoResumo.ObterPorGuid(command.GuidResumo);

            resumo.GuidPQ = command.GuidPQ;

            repoResumo.Modificar(resumo);

            return Unit.Value;
        }
    }
}
