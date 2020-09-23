using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.AddResumoParaPQ
{
    public class AddResumoParaPQCommandHandle : Notifiable, IRequestHandler<AddResumoParaPQCommand>
    {
        RepoPQ _repoPQPipeVale;
        RepoAtividade _repoAtividade;
        RepoItemPQ _repoItemPQ;
        RepoResumo _repoResumo;
        Atividade _atividadeVVV;
        Atividade _atividadeUU;
        Atividade _atividadeTT;
        Atividade _atividadeK;

        public AddResumoParaPQCommandHandle()
        {
            _repoPQPipeVale = new RepoPQ(); //new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
            _repoAtividade = new RepoAtividade(); //new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            _repoItemPQ = new RepoItemPQ();
            _repoResumo = new RepoResumo();
        }

        public async Task<Unit> Handle(AddResumoParaPQCommand command, CancellationToken cancellationToken)
        {

            var dataPQ = _repoPQPipeVale.ObterUltimaPQAtivaDoHub(command.IdentidadePQ.IdentidadeEstado);

            criaListaLinhas(command.Itens, dataPQ);

           

            



            return Unit.Value;
        }

        public void criaListaLinhas(List<ItemPQ> itensParametro, DataPQ dataPQ)
        {

           

            var sequencialItem = 1;

            var ItensAdicicionados = new List<ItemPQ>();

            

            dataPQ.ResetLinhas();

            var itens = new List<ItemPQ>();

            
                foreach (var item in itensParametro)
                {
                    var itemEncontrado = _repoItemPQ.ObterPorGuid(item.GUID);
                    itens.Add(itemEncontrado);

                }
           
               

            

            


            foreach (var itemGlobal in itens)
            {

                if (dataPQ.ListaDataPQ == null || dataPQ.ListaDataPQ.Count <= 0)
                {
                    InsereClassificacao(dataPQ, itemGlobal, ItensAdicicionados);
                }
               

                if (ItensAdicicionados.FirstOrDefault(x => x.GUID == itemGlobal.GUID) == null)
                {
                    var atividadePai = dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == itemGlobal.Atividade.GUID_PAI);
                    if (atividadePai != null)
                    {
                        sequencialItem = AdcionarGrupoItens(itens, dataPQ, sequencialItem, ItensAdicicionados);

                    }
                    else
                    {
                       

                        InsereClassificacao(dataPQ, itemGlobal, ItensAdicicionados);

                        sequencialItem = AdcionarGrupoItens(itens, dataPQ, sequencialItem, ItensAdicicionados);
                    }

                }
                

            }

            _repoPQPipeVale.Modificar(dataPQ);

        }

        private int AdcionarGrupoItens(List<ItemPQ> itens, DataPQ dataPQ, int sequencialItem, List<ItemPQ> ItensAdicicionados)
        {
            var agrupamento = itens.Where(x => x.Atividade.GUID_PAI == _atividadeVVV.GUID).OrderBy(x => x.Atividade.Codigo).ToList();

            foreach (var item in agrupamento)
            {
                var linhaDataPQ = new LinhaDataPQ(
               "1.1.1.1." + sequencialItem,
               item.ItemTag.AreaDesenho.Area,
               item.ItemTag.AreaDesenho.SubArea,
               "",
                _atividadeK.Codigo,
                  _atividadeTT.Codigo,
                  _atividadeUU.Codigo,
                  _atividadeVVV.Codigo,
               item.Atividade.Codigo,
               item.SpecPart,
               "m",
               "CMS",
                 _atividadeK.Codigo,
                  _atividadeTT.Codigo,
                  _atividadeUU.Codigo,
                "000",
                Math.Round((double)item.SomaValorQuatidade / 1000, 2).ToString(),
                "20%",
                "",
                "",
                "",
                "",
                item.Atividade.GUID,
                item.Atividade.GUID_PAI
               );

                dataPQ.AddItem(linhaDataPQ);
                ItensAdicicionados.Add(item);
                sequencialItem++;
            }

            return sequencialItem;
        }

        private void InsereClassificacao(DataPQ dataPQ, ItemPQ itemGlobal, List<ItemPQ> itensAdiconados)
        {
            


            _atividadeVVV = _repoAtividade.ObterPorGuid(itemGlobal.Atividade.GUID_PAI);
            _atividadeUU = _repoAtividade.ObterPorGuid(_atividadeVVV.GUID_PAI);
            _atividadeTT = _repoAtividade.ObterPorGuid(_atividadeUU.GUID_PAI);
            _atividadeK = _repoAtividade.ObterPorGuid(_atividadeTT.GUID_PAI);


            if(dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == _atividadeK.GUID) == null)
            {
                var linhaK = new LinhaDataPQ(
                "1",
                "", "", "",
                _atividadeK.Codigo,
                "00", "00", "000", "000",
                _atividadeK.Descricao,
                "", "", "", "", "", "", "", "", "", "", "",
                "mat-grid-tile-K",
                _atividadeK.GUID,
                _atividadeK.GUID_PAI);
                dataPQ.AddItem(linhaK);
            }


            if (dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == _atividadeTT.GUID) == null)
            {
                var linhaTT = new LinhaDataPQ(
                "1.1",
                "", "", "",
                _atividadeK.Codigo,
                _atividadeTT.Codigo,
                "00", "000", "000",
                _atividadeTT.Descricao,
                "", "", "", "", "", "", "", "", "", "", "",
                "mat-grid-tile-TT",
                _atividadeTT.GUID,
                _atividadeK.GUID);
                dataPQ.AddItem(linhaTT);
            }

            if (dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == _atividadeUU.GUID) == null)
            {
                var linhaUU = new LinhaDataPQ(
                "1.1.1",
                "", "", "",
                _atividadeK.Codigo,
                _atividadeTT.Codigo,
                _atividadeUU.Codigo,
                "000", "000",
                _atividadeUU.Descricao,
                "", "", "", "", "", "", "", "", "", "", "",
                "mat-grid-tile-UU",
                _atividadeUU.GUID,
                _atividadeTT.GUID);
                dataPQ.AddItem(linhaUU);
            }

            if (dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == _atividadeVVV.GUID) == null)
            {
                var linhaVVV = new LinhaDataPQ(
             "1.1.1.1",
             "", "", "",
             _atividadeK.Codigo,
             _atividadeTT.Codigo,
             _atividadeUU.Codigo,
             _atividadeVVV.Codigo,
             "000",
             _atividadeVVV.Descricao,
             "", "", "", "", "", "", "", "", "", "", "",
             "mat-grid-tile-VVV",
              _atividadeVVV.GUID,
              _atividadeUU.GUID);
                dataPQ.AddItem(linhaVVV);
            }
              
        }
    }
}


//public void criaListaLinhas(List<ItemPQPlant3d> itens)
//{
//    //PlanilhaVale planilhaVale = new PlanMECVale();

//    DataPQ dataPQ = new DataPQ(
//        new Versao(0, "Resumo", "Primeiro PQ", DateTime.Now),
//        new CabecalhoPQ(
//            "BdB181119-0000-L-PQ0001",
//            "PQ-1860CC-T-21853",
//            "RESTRITA",
//            0, 
//            "0",
//            "PROJETO DETALHADO",
//            "SISTEMA DE CAPTAÇÃO DE ÁGUA RIO DO PEIXE",
//            "PLANILHA DE QUANTIDADES - MONTAGEM"
//        ));





//    var sequencialItem = 1;


//    foreach (var item in itens)
//    {

//        LinhaDataPQ linhaDataPQ = new LinhaDataPQ(
//            "1.1.1.1." + sequencialItem,
//            item.ItemTag.AreaDesenho.Area,
//            item.ItemTag.AreaDesenho.SubArea,
//            "",
//            "M",
//            "60",
//            "10",
//            "010",
//            "001",
//            item.SpecPart,
//            "m",
//            "CMS",
//             "M",
//             "60",
//             "10",
//             "000",
//             Math.Round((double)item.SomaValorQuatidade / 1000, 2).ToString(),
//             "20%",
//             "",
//             "",
//             ""
//            );


//        dataPQ.AddItem(linhaDataPQ);

//        //planilha.AddLinha(linhaValeItem);

//        //sequencialItem++;
//    }




//    _repoPQPipeVale.Inserir(dataPQ);


//}