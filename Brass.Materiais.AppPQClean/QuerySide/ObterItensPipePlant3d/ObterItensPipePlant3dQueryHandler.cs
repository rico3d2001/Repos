using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensPipePlant3d
{
    public class ObterItensPipePlant3dQueryHandler : Notifiable, IRequestHandler<ObterItensPipePlant3dQuery, ItemPQ[]>
    {

        public Task<ItemPQ[]> Handle(ObterItensPipePlant3dQuery request, CancellationToken cancellationToken)
        {


            var repositorioItemPipe = new RepoItemPipe(request.TextoConexao);
            var repositorioItemPQPlant3d = new RepoItemPQ(request.TextoConexao);
            var itensPQ = ObterItensOrdenadosPorDescricao(request, repositorioItemPQPlant3d);

            foreach (var itemPQ in itensPQ)
            {

                if (itemPQEstaCatalogado(itemPQ))
                {
                    if (itemPQNaoPossuiAtividadeDefinida(itemPQ))
                    {
                        var itemPipe = repositorioItemPipe.ObterPorGuid(itemPQ.ItemPipe.GUID);

                        if (atividadeEstaCadastrada(itemPipe))
                        {
                            RepoAtividade repositorioAtividade = new RepoAtividade(request.TextoConexao);

                            var atividade = repositorioAtividade.ObterPorGuid(itemPipe.GUID_ATIVIDADE);
                            itemPQ.Atividade = atividade;
                            repositorioItemPQPlant3d.ModificarItemPQ(itemPQ);
                        }

                    }

                }


            }





            var result = itensPQ
                          .Skip((request.Pagina - 1) * request.Limite)
                          .Take(request.Limite)
                          .ToArray();

            return Task.FromResult(result);
        }

        private static IOrderedEnumerable<ItemPQ> ObterItensOrdenadosPorDescricao(ObterItensPipePlant3dQuery request, RepoItemPQ repositorioItemPQPlant3d)
        {
            return repositorioItemPQPlant3d.Obter(request.GuidProjeto, request.Area, request.SubArea, request.Ativo).OrderBy(x => x.SpecPart);
        }

        

        private static bool itemPQNaoPossuiAtividadeDefinida(ItemPQ itemPQ)
        {
            return itemPQ.Atividade == null;
        }

        private static bool itemPQEstaCatalogado(ItemPQ itemPQ)
        {
            return itemPQ.ItemPipe != null;
        }

        

        private static bool atividadeEstaCadastrada(ItemPipe itemPipe)
        {
            return !(itemPipe.GUID_ATIVIDADE == null || itemPipe.GUID_ATIVIDADE == "");
        }
    }
}
