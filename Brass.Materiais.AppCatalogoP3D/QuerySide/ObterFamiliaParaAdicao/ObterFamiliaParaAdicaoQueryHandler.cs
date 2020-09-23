using Brass.Materiais.AppCatalogoP3D.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoP3D.QuerySide.ObterFamiliaParaAdicao
{
    public class ObterFamiliaParaAdicaoQueryHandler : Notifiable, IRequestHandler<ObterFamiliaParaAdicaoQuery, ItemParaAdicionar[]>
    {

        RepoItemPipe _repoItemPipe;


        public ObterFamiliaParaAdicaoQueryHandler()
        {
            _repoItemPipe = new RepoItemPipe();
        }

        public Task<ItemParaAdicionar[]> Handle(ObterFamiliaParaAdicaoQuery request, CancellationToken cancellationToken)
        {

            var listaDeItemParaAdicionar = new List<ItemParaAdicionar>();

            var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(request.GuidFamilia);

            foreach (var itemDaFamilia in itensCatalogoDaFamilia)
            {

                var descricao = RepoValores.InstanciaPorPropriedadeDefinida("PartSizeLongDesc").ObterPorItemPipe(itemDaFamilia);

                listaDeItemParaAdicionar
                    .Add(new ItemParaAdicionar(itemDaFamilia.GUID, descricao));
            }


            return Task.FromResult(listaDeItemParaAdicionar.ToArray());
        }
    }
}
