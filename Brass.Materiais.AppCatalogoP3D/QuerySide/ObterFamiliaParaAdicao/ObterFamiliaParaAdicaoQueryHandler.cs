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


        

        public Task<ItemParaAdicionar[]> Handle(ObterFamiliaParaAdicaoQuery request, CancellationToken cancellationToken)
        {

            _repoItemPipe = new RepoItemPipe(request.TextoConexao);

            var listaDeItemParaAdicionar = new List<ItemParaAdicionar>();

            var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(request.GuidFamilia);

            foreach (var itemDaFamilia in itensCatalogoDaFamilia)
            {

                var descricao = RepoValores.InstanciaPorPropriedadeDefinida("PartSizeLongDesc", request.TextoConexao).ObterPorItemPipe(itemDaFamilia);

                listaDeItemParaAdicionar
                    .Add(new ItemParaAdicionar(itemDaFamilia.GUID, descricao));
            }


            return Task.FromResult(listaDeItemParaAdicionar.ToArray());
        }
    }
}
