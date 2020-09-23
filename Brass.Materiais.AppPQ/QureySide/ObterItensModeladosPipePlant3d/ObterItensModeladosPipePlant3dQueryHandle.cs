using Brass.Materiais.AppPQ.QureySide.ObterItensModeladosPipePlant3d.ViewModel;
using Flunt.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQ.QureySide.ObterItensModeladosPipePlant3d
{
    public class ObterItensModeladosPipePlant3dQueryHandle :
        Notifiable, IRequestHandler<ObterItensModeladosPipePlant3dQuery, ItemPipeModelado[]>
    {
        public Task<ItemPipeModelado[]> Handle(ObterItensModeladosPipePlant3dQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
