using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterTabelaAtividades
{
    public class ObterTabelaAtividadesQueryHandle : Notifiable, IRequestHandler<ObterTabelaAtividadesQuery, TabelaAtividades>
    {

        public Task<TabelaAtividades> Handle(ObterTabelaAtividadesQuery request, CancellationToken cancellationToken)
        {
            var atividadesRepositorio = new RepoAtividade(request.TextoConexao);

            var atividades = atividadesRepositorio.ObterTodas();

            var tabela = obterLinhas(atividades);



            return Task.FromResult(tabela);
        }

       

        public TabelaAtividades obterLinhas(List<Atividade> atividadesParam)
        {

            var atividadesWWW = atividadesParam.Where(x => x.NivelAtividade == "WWW");

            TabelaAtividades tabela = new TabelaAtividades("", "", null, null);


            Atividade atividadeVVV = null;
            Atividade atividadeUU = null;
            Atividade atividadeTT = null;
            Atividade atividadeK = null;

            var sequencialItem = 1;

            var atividadesAdicicionadas = new List<Atividade>();




            foreach (var atividadeWWW in atividadesWWW)
            {

                
                
                    atividadeVVV = atividadesParam.First(x => x.GUID == atividadeWWW.GUID_PAI);
                    atividadeUU = atividadesParam.First(x => x.GUID == atividadeVVV.GUID_PAI);
                    atividadeTT = atividadesParam.First(x => x.GUID == atividadeUU.GUID_PAI);
                    atividadeK = atividadesParam.First(x => x.GUID == atividadeTT.GUID_PAI);

                    var linhaK = new LinhaDataPQ(
                        "1",
                        "", "", "",
                        atividadeK.Codigo,
                        "00", "00", "000", "000",
                        atividadeK.Descricao,
                        "", "", "", "", "", "", "", "", "", "", "",
                        "mat-grid-tile-K",
                        atividadeK.GUID,
                        atividadeK.GUID_PAI);
                    tabela.AddItem(linhaK);

                    var linhaTT = new LinhaDataPQ(
                        "1.1",
                        "", "", "",
                        atividadeK.Codigo,
                        atividadeTT.Codigo,
                        "00", "000", "000",
                        atividadeTT.Descricao,
                        "", "", "", "", "", "", "", "", "", "", "",
                        "mat-grid-tile-TT",
                        atividadeTT.GUID,
                        atividadeK.GUID);
                    tabela.AddItem(linhaTT);

                    var linhaUU = new LinhaDataPQ(
                        "1.1.1",
                        "", "", "",
                        atividadeK.Codigo,
                        atividadeTT.Codigo,
                        atividadeUU.Codigo,
                        "000", "000",
                        atividadeUU.Descricao,
                        "", "", "", "", "", "", "", "", "", "", "",
                        "mat-grid-tile-UU",
                        atividadeUU.GUID,
                        atividadeTT.GUID);
                    tabela.AddItem(linhaUU);

                    var linhaVVV = new LinhaDataPQ(
                       "1.1.1.1",
                       "", "", "",
                       atividadeK.Codigo,
                       atividadeTT.Codigo,
                       atividadeUU.Codigo,
                       atividadeVVV.Codigo,
                       "000",
                       atividadeVVV.Descricao,
                       "", "", "", "", "", "", "", "", "", "", "",
                       "mat-grid-tile-VVV",
                       atividadeVVV.GUID,
                        atividadeUU.GUID);
                    tabela.AddItem(linhaVVV);
                


                if (atividadesAdicicionadas.FirstOrDefault(x => x.GUID == atividadeWWW.GUID) == null)
                {
                    var agrupamento = atividadesWWW.Where(x => x.GUID_PAI == atividadeVVV.GUID).OrderBy(x => x.Codigo).ToList();

                    foreach (var atividade in agrupamento)
                    {
                        var linhaDataPQ = new LinhaDataPQ(
                       "1.1.1.1." + sequencialItem,
                       "",
                       "",
                       "",
                        atividadeK.Codigo,
                          atividadeTT.Codigo,
                          atividadeUU.Codigo,
                          atividadeVVV.Codigo,
                       atividade.Codigo,
                       atividade.Descricao,
                       "m",
                       "CMS",
                         atividadeK.Codigo,
                          atividadeTT.Codigo,
                          atividadeUU.Codigo,
                        "000",
                        "",
                        "20%",
                        "",
                        "",
                        "",
                        "",
                        atividade.GUID,
                        atividade.GUID_PAI
                       );

                        tabela.AddItem(linhaDataPQ);
                        atividadesAdicicionadas.Add(atividade);
                        sequencialItem++;
                    }
                }

            }

            return tabela;

        }





    }
}
