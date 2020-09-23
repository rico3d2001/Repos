using Brass.Materiais.RepoCataloESQLServer.Data;
using MediatR;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCatalogos
{


    public class ObterCatalogosQuery : IRequest<CatalogoPlant3d[]>
    {
    }
}
