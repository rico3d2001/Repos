using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.EmitirPQ
{
    public class EmitirPQCommandHandler : Notifiable, IRequestHandler<EmitirPQCommand>
    {
        public async Task<Unit> Handle(EmitirPQCommand command, CancellationToken cancellationToken)
        {

            RepoPQ repoPQ = new RepoPQ();

            repoPQ.EmitirPQ(command.DataPQ);

            return Unit.Value;
        }
    }
}
