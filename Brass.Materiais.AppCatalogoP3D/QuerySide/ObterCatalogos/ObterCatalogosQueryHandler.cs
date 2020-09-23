using Brass.Materiais.RepoCataloESQLServer.Data;
using Flunt.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterCatalogos
{
    public class ObterCatalogosQueryHandler : Notifiable, IRequestHandler<ObterCatalogosQuery, CatalogoPlant3d[]>
    {
        //private ItemEngenhariaServiceSQL _itemEngenhariaService;

        __CATALOGO_BRASSContext _cATALOGO_BRASSContext;

        //BIM360DataContext recordContext = new BIM360DataContext(filename);
        //var pipeLineRecordRepositorio = new PipeLineRecordRepositorio(recordContext);

        //var pipelines = pipeLineRecordRepositorio.GetAll();

        public ObterCatalogosQueryHandler()
        {
            //_itemEngenhariaService = new ItemEngenhariaServiceSQL();
            _cATALOGO_BRASSContext = new __CATALOGO_BRASSContext();
        }

        public Task<CatalogoPlant3d[]> Handle(ObterCatalogosQuery request, CancellationToken cancellationToken)
        {
           
            //var catalogos = _itemEngenhariaService.ObterCatalogos();

            var catalogos = _cATALOGO_BRASSContext.CatalogoPlant3d.ToArray();

            return Task.FromResult(catalogos);
        }
    }
}
