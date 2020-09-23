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

        //BaseMDBRepositorio<ItemPipe> _repositorioItemPipe;
        BaseMDBRepositorio<ItemPQ> _repositorioItemPQ;
        RepoFamilia _repoFamilia;
        RepoItemPipe _repoItemPipe;
        RepoSPE _repoSPE;
        RepoAtividade _repoAtividade;

        public ObterItenParaAtivarDeItemPQQueryHandle()
        {
            //_repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");
            _repositorioItemPQ = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
            _repoFamilia = new RepoFamilia();
            _repoItemPipe = new RepoItemPipe();
            _repoSPE = new RepoSPE();
            _repoAtividade = new RepoAtividade();
        }



        public Task<ItemParaAtivar[]> Handle(ObterItenParaAtivarDeItemPQQuery query, CancellationToken cancellationToken)
        {
            

            

            var itemPQ = _repositorioItemPQ.Obter(query.GuidItem);

            

            //var collection = _repositorioItemPQ.Obter();

            //foreach (var itemPQ in collection)
            //{




            var itemPipe = _repoItemPipe.ObterPorDescricaoComplexa(itemPQ.SpecPart, "532f43f4-59eb-4962-a4a9-edf7cee699a5");
            if (itemPipe != null)
            {
                var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(itemPipe.GUID_FAMILIA);

                var listaDeItensParaAtivar = coletarItensParaAtivar(itensCatalogoDaFamilia);

                return Task.FromResult(listaDeItensParaAtivar.ToArray());
            }
            else
            {

                var descricaoFamilia = TransformaEmDescricaoDeFamilia(itemPQ.SpecPart);

                //descricaoFamilia = "FLANGE SOLTO, AFO ASTM A-105, CL 1500, FP, CONF. ASME B16.5";

                var familia = _repoFamilia.ObterFamiliaPorDescricao(descricaoFamilia);
                if (familia != null)
                {
                    var itensCatalogoDaFamilia = _repoItemPipe.ObterItensCatalogadosDaFamilia(familia.GUID);

                    var listaDeItensParaAtivar = coletarItensParaAtivar(itensCatalogoDaFamilia);

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

        private static List<ItemParaAtivar> coletarItensParaAtivar(List<ItemPipe> itensCatalogoDaFamilia)
        {
            var listaDeItensParaAtivar = new List<ItemParaAtivar>();

            foreach (var itemDaFamilia in itensCatalogoDaFamilia)
            {

                var atividade = new RepoAtividade().ObterDoItemCatalogado(itemDaFamilia);

                var descricao = RepoValores.InstanciaPorPropriedadeDefinida("PartSizeLongDesc").ObterPorItemPipe(itemDaFamilia);

                var item = new ItemParaAtivar(itemDaFamilia.GUID, atividade, descricao);

                item.Ativado = true;


                listaDeItensParaAtivar.Add(item);
            }

            return listaDeItensParaAtivar;
        }

        //private static string TransformaEmDescricaoDeFamilia(string specPart)
        //{
        //    var array = specPart.Split('-');

        //    var descricaoFamilia = array[0];

        //    for (int i = 1; i < array.Length - 1; i++)
        //    {
        //        descricaoFamilia = descricaoFamilia + "-" + array[i];
        //    }

        //    return descricaoFamilia.Trim();
        //}

        private static string TransformaEmDescricaoDeFamilia(string specPart)
        {
            var array = specPart.Split('-');

            var dimensao = array.Last();

            var resposta = specPart.TrimEnd(dimensao.ToCharArray());

            return resposta.TrimEnd('-').Trim();

        }
    }
}
