using Brass.Materiais.AppPQ.QureySide.ObterItensModeladosPipePlant3d.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQ.QureySide.ObterItensModeladosPipePlant3d
{
    public class ObterItensModeladosPipePlant3dQuery : IRequest<ItemPipeModelado[]>
    {
        public ObterItensModeladosPipePlant3dQuery(string specPart)
        {
            SpecPart = specPart;
        }

        public string SpecPart { get; set; }
    }
}
