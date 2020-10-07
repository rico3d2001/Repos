using Brass.Materiais.AppPQClean.ViewModel;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ
{
    public class ObterItenParaAtivarDeItemPQQueryHandle : Notifiable, IRequestHandler<ObterItenParaAtivarDeItemPQQuery, ItemParaAtivar[]>
    {

      
        RepoItemPQ _repositorioItemPQ;
        RepoFamilia _repoFamilia;
        RepoItemPipe _repoItemPipe;
        RepoSPE _repoSPE;
      

       



        public Task<ItemParaAtivar[]> Handle(ObterItenParaAtivarDeItemPQQuery query, CancellationToken cancellationToken)
        {

            _repositorioItemPQ =  new RepoItemPQ(query.TextoConexao);
            _repoFamilia = new RepoFamilia(query.TextoConexao);
            _repoItemPipe = new RepoItemPipe(query.TextoConexao);
            _repoSPE = new RepoSPE(query.TextoConexao);
        


            var itemPQ = _repositorioItemPQ.ObterPorGuid(query.GuidItem);

      

            var itemPipe = _repoItemPipe.ObterPorDescricaoComplexa(itemPQ.SpecPart, "532f43f4-59eb-4962-a4a9-edf7cee699a5");
            if (itemPipe != null)
            {
                var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(itemPipe.GUID_FAMILIA);

                var listaDeItensParaAtivar = coletarItensParaAtivar(itensCatalogoDaFamilia, query.TextoConexao);

                return Task.FromResult(listaDeItensParaAtivar.ToArray());
            }
            else
            {

                var descricaoFamilia = TransformaEmDescricaoDeFamilia(itemPQ.SpecPart);

                var familia = _repoFamilia.ObterFamiliaPorDescricao(descricaoFamilia);
                if (familia != null)
                {
                    var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(familia.GUID);

                    var listaDeItensParaAtivar = coletarItensParaAtivar(itensCatalogoDaFamilia, query.TextoConexao);

                    return Task.FromResult(listaDeItensParaAtivar.ToArray());
                }
                else
                {
                   

                    var todasAtividadesSPE = _repoSPE.ObterAtividadesPorCodigos(query.GuidAtividadePai);

                    var atividades = todasAtividadesSPE.Where(x => x.Nivel_WWW != "000").ToList();


                }

                return Task.FromResult(new List<ItemParaAtivar>().ToArray());



            }




        }

        private static List<ItemParaAtivar> coletarItensParaAtivar(List<ItemPipe> itensCatalogoDaFamilia, string conexao)
        {
            var listaDeItensParaAtivar = new List<ItemParaAtivar>();

            foreach (var itemDaFamilia in itensCatalogoDaFamilia)
            {

                var atividade = new RepoAtividade(conexao).ObterDoItemCatalogado(itemDaFamilia);

                var descricao = RepoValores.InstanciaPorPropriedadeDefinida("PartSizeLongDesc", conexao).ObterPorItemPipe(itemDaFamilia);

                var item = new ItemParaAtivar(itemDaFamilia.GUID, atividade, descricao);

                item.Ativado = true;


                listaDeItensParaAtivar.Add(item);
            }

            return listaDeItensParaAtivar;
        }

     

        private static string TransformaEmDescricaoDeFamilia(string specPart)
        {
            var array = specPart.Split('-');

            var dimensao = array.Last();

            var resposta = specPart.TrimEnd(dimensao.ToCharArray());

            return resposta.TrimEnd('-').Trim();

        }
    }
}
