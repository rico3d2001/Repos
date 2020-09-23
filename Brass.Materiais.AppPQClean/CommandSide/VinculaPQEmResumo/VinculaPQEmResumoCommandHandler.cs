using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.VinculaPQEmResumo
{
    public class VinculaPQEmResumoCommandHandler : Notifiable, IRequestHandler<VinculaPQEmResumoCommand>
    {

        BaseMDBRepositorio<Resumo> _repoResumo;
       

        public VinculaPQEmResumoCommandHandler()
        {
            _repoResumo = new BaseMDBRepositorio<Resumo>("BIM_TESTE", "ResumoItensPQPlant3d");
            
        }


        public async Task<Unit> Handle(VinculaPQEmResumoCommand command, CancellationToken cancellationToken)
        {

             var resumo  = _repoResumo.Obter(command.GuidResumo);

            resumo.GuidPQ = command.GuidPQ;

            _repoResumo.Atualizar(resumo);

            return Unit.Value;
        }
    }
}
