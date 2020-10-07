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
using System.Security.Cryptography.X509Certificates;
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
        List<ItemPQ> _itensParametro;

 

        public async Task<Unit> Handle(AddResumoParaPQCommand command, CancellationToken cancellationToken)
        {

            _repoPQPipeVale = new RepoPQ(command.TextoConexao); //new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
            _repoAtividade = new RepoAtividade(command.TextoConexao); //new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            _repoItemPQ = new RepoItemPQ(command.TextoConexao);
            _repoResumo = new RepoResumo(command.TextoConexao);



            _itensParametro = command.ItensParametro;

            var dataPQ = _repoPQPipeVale.ObterUltimaPQAtivaDoHub(command.IdentidadePQ.IdentidadeEstado);

            criaListaLinhas(dataPQ);

           

            



            return Unit.Value;
        }

        public void criaListaLinhas(DataPQ dataPQ)
        {

           

            var sequencialItem = 1;

            var ItensAdicicionados = new List<ItemPQ>();

            

            dataPQ.ResetLinhas();

            //var itens = new List<ItemPQ>();

            
                //foreach (var item in itensParametro)
                //{
                //    var itemEncontrado = _repoItemPQ.ObterPorGuid(item.GUID);
                //    itens.Add(itemEncontrado);

                //}
           
               

            

            


            foreach (var itemParametro in _itensParametro)
            {
                var itemGlobal = _repoItemPQ.ObterPorGuid(itemParametro.GUID);

                if (dataPQ.ListaDataPQ == null || dataPQ.ListaDataPQ.Count <= 0)
                {
                    InsereClassificacao(dataPQ, itemGlobal, ItensAdicicionados);
                }
               

                if (ItensAdicicionados.FirstOrDefault(x => x.GUID == itemGlobal.GUID) == null)
                {
                    var atividadePai = dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == itemGlobal.Atividade.GUID_PAI);
                    if (atividadePai != null)
                    {
                        sequencialItem = AdcionarGrupoItens(dataPQ, sequencialItem, ItensAdicicionados);

                    }
                    else
                    {
                       

                        InsereClassificacao(dataPQ, itemGlobal, ItensAdicicionados);

                        sequencialItem = AdcionarGrupoItens(dataPQ, sequencialItem, ItensAdicicionados);
                    }

                }
                

            }

            _repoPQPipeVale.Modificar(dataPQ);

        }

        private int AdcionarGrupoItens(DataPQ dataPQ, int sequencialItem, List<ItemPQ> itensAdicicionados)
        {
            var itens = new List<ItemPQ>();

            foreach (var item in _itensParametro)
            {
                var itemEncontrado = _repoItemPQ.ObterPorGuid(item.GUID);
                itens.Add(itemEncontrado);

            }

            var agrupamento = itens.Where(x => x.Atividade.GUID_PAI == _atividadeVVV.GUID).OrderBy(x => x.Atividade.Codigo).ToList();

           
            foreach (var itemPQ in agrupamento)
            {
                var itemParametro = _itensParametro.First(i => i.GUID == itemPQ.GUID);

                var linhaDataPQ = CriarLinhaVindaDoItem(sequencialItem, itemPQ, (double)itemParametro.SomaValorQuatidade);

                dataPQ.AddItem(linhaDataPQ);
                itensAdicicionados.Add(itemPQ);
                //CadastaraNumeroDoAtivoNoItemPQ(itemParametro.ItemTag.NumeroAtivo.Sigla, itemPQ);
                sequencialItem++;
            }

            return sequencialItem;
        }

        //private void CadastaraNumeroDoAtivoNoItemPQ(string siglaAtivo, ItemPQ itemPQ)
        //{
        //    itemPQ.ItemTag.NumeroAtivo.Sigla = siglaAtivo;
        //    _repoItemPQ.ModificarItemPQ(itemPQ);
        //}

        private LinhaDataPQ CriarLinhaVindaDoItem(int sequencialItem, ItemPQ itemPQ, double somaValorQuatidade)
        {
            return new LinhaDataPQ(
           "1.1.1.1." + sequencialItem,
           itemPQ.ItemTag.NumeroAtivo.AreaTag.Area,
           itemPQ.ItemTag.NumeroAtivo.AreaTag.SubArea,
           itemPQ.ItemTag.NumeroAtivo.Sigla,
            _atividadeK.Codigo,
              _atividadeTT.Codigo,
              _atividadeUU.Codigo,
              _atividadeVVV.Codigo,
           itemPQ.Atividade.Codigo,
           itemPQ.SpecPart,
           "m",
           "CMS",
             _atividadeK.Codigo,
              _atividadeTT.Codigo,
              _atividadeUU.Codigo,
            "000",
            Math.Round(somaValorQuatidade / 1000, 2).ToString(),
            "20%",
            "",
            "",
            "",
            "",
            itemPQ.Atividade.GUID,
            itemPQ.Atividade.GUID_PAI
           );
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