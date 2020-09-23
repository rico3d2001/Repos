using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarQuantificadoPipe
{
    public class CriarQuantificadoPipeCommandHandle : Notifiable, IRequestHandler<CriarQuantificadoPipeCommand>
    {

        BaseMDBRepositorio<ItemPQ> _repoItemPQPlant3d;
        BaseMDBRepositorio<ItemPQ> _repoQuantidadesPQPlant3d;

        public CriarQuantificadoPipeCommandHandle()
        {
            _repoItemPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
            _repoQuantidadesPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "QuantidadesPQPlant3d");
        }

        public async Task<Unit> Handle(CriarQuantificadoPipeCommand command, CancellationToken cancellationToken)
        {

            var itemPQ = _repoItemPQPlant3d.Obter(command.GuidItemPQ);

            _repoQuantidadesPQPlant3d.Inserir(itemPQ);

            return Unit.Value;


        }
    }
}
