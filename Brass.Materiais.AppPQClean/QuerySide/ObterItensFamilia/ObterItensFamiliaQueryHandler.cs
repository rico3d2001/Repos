using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItensFamilia
{
    public class ObterItensFamiliaQueryHandler : Notifiable, IRequestHandler<ObterItensFamiliaQuery, ItemParaAtivar[]>
    {

        RepoItemPipe _repoItemPipe;
        RepoSPE _repoSPE;

  


        public Task<ItemParaAtivar[]> Handle(ObterItensFamiliaQuery query, CancellationToken cancellationToken)
        {
            _repoItemPipe = new RepoItemPipe(query.TextoConexao);
            _repoSPE = new RepoSPE(query.TextoConexao);


            var listaDeItensParaAtivar = new List<ItemParaAtivar>();



            var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(query.GuidFamilia);

            var itensSPEencontrados = _repoSPE.ObterAtividadesPorCodigos(query.GuidAtividade);
            int indice = 0;
            foreach (var itemDaFamilia in itensCatalogoDaFamilia)
            {

                var atividade = new RepoAtividade(query.TextoConexao).ObterDoItemCatalogado(itemDaFamilia);

                var descricao = RepoValores.InstanciaPorPropriedadeDefinida("PartSizeLongDesc",query.TextoConexao).ObterPorItemPipe(itemDaFamilia);

                var itemAtivar = new ItemParaAtivar(itemDaFamilia.GUID, atividade, descricao);

                if (atividade != null)
                {
                    itemAtivar.Ativado = true;

                    var itemSPE = itensSPEencontrados.FirstOrDefault(x => x.Nivel_WWW == atividade.Codigo);
                    if (itemSPE != null)
                    {
                        itemAtivar.SPE_Descricao = itemSPE.Descricao;
                        itemAtivar.SPE_Codigo_WWW = itemSPE.Nivel_WWW;
                    }
                    else if (BateComDescricaoDoSPE(itensSPEencontrados, descricao))
                    {
                        itemSPE = itensSPEencontrados.FirstOrDefault(x => x.Descricao == descricao);
                        itemAtivar.SPE_Descricao = itemSPE.Descricao;
                        itemAtivar.SPE_Codigo_WWW = itemSPE.Nivel_WWW;
                    }
                    else if (itensSPEencontrados.Count() >= indice + 1)
                    {
                        itemSPE = itensSPEencontrados[indice];
                        itemAtivar.SPE_Descricao = itemSPE.Descricao;
                        itemAtivar.SPE_Codigo_WWW = itemSPE.Nivel_WWW;


                        indice++;

                    }
                }
                else if (BateComDescricaoDoSPE(itensSPEencontrados, descricao))
                {
                    var itemSPE = itensSPEencontrados.FirstOrDefault(x => x.Descricao == descricao);
                    itemAtivar.SPE_Descricao = itemSPE.Descricao;
                    itemAtivar.SPE_Codigo_WWW = itemSPE.Nivel_WWW;
                }
                else if (itensSPEencontrados.Count() >= indice + 1)
                {
                    var itemSPE = itensSPEencontrados[indice];
                    itemAtivar.SPE_Descricao = itemSPE.Descricao;
                    itemAtivar.SPE_Codigo_WWW = itemSPE.Nivel_WWW;

                    indice++;

                }


                listaDeItensParaAtivar.Add(itemAtivar);
            }

            return Task.FromResult(listaDeItensParaAtivar.ToArray());

        }

        private static bool BateComDescricaoDoSPE(List<ItemSPE> itensSPEencontrados, string descricao)
        {
            return itensSPEencontrados.FirstOrDefault(x => x.Descricao == descricao) != null;
        }

    }
}
