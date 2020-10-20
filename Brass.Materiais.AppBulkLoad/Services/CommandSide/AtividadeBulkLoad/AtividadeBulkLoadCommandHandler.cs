using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBulkLoad.Services.CommandSide.AtividadeBulkLoad
{
    public class AtividadeBulkLoadCommandHandler : Notifiable, IRequestHandler<AtividadeBulkLoadCommand>
    {
        public Task<Unit> Handle(AtividadeBulkLoadCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
