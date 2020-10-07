using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarPQ
{
    public class CriarPQValeCommandHandle : Notifiable, IRequestHandler<CriarPQValeCommand>
    {


        RepoPQ _repoPQPipeVale;
        RepoResumo _repoResumos;
        RepoEstadoApp _repoEstado;
        RepoItemPQ _repoItemPQ;
        RepoAtividade _repoAtividade;
        Atividade _atividadeVVV;
        Atividade _atividadeUU;
        Atividade _atividadeTT;
        Atividade _atividadeK;

  
            

        public async Task<Unit> Handle(CriarPQValeCommand command, CancellationToken cancellationToken)
        {

                _repoPQPipeVale = new RepoPQ(command.TextoConexao); //new BaseMDBRepositorio<DataPQ>("BIM_TESTE", "PQPipeVale");
            _repoResumos = new RepoResumo(command.TextoConexao);
            _repoEstado = new RepoEstadoApp(command.TextoConexao);
            _repoItemPQ = new RepoItemPQ(command.TextoConexao);
            _repoAtividade = new RepoAtividade(command.TextoConexao);
        

            var identidadeNovaPQ = obtemIdentificadorNovaPQ(command.DataPQ);

           

            if(naoExistePQAtivaSemResumo(command.DataPQ.IdentidadePQ.IdentidadeEstado))
            {
                var resumoSemPQEncontrado = _repoResumos.ObterResumoDoProjetoSemPQ(command.DataPQ.IdentidadePQ);

                

                if (resumoSemPQEncontrado != null)
                {
                    criaPQComResumoEncontrado(resumoSemPQEncontrado, identidadeNovaPQ);
                    var novaPQ = new DataPQ(identidadeNovaPQ, command.DataPQ.Versao, command.DataPQ.CabecalhoPQ);
                    _repoPQPipeVale.CadastrarPQ(novaPQ);
                    criaListaLinhas(resumoSemPQEncontrado.Itens, novaPQ);

                }
                else
                {
                    CriaPQjuntoComResumo(identidadeNovaPQ);

                }

                _repoEstado.AtivaResumoDoEstado(identidadeNovaPQ);

                

                

            }



            return Unit.Value;
        }

        private bool naoExistePQAtivaSemResumo(IdentidadeEstado identidadeEstado)
        {
            var pqAtivaSemResumo = _repoPQPipeVale.ObterUltimaPQAtivaDoHub(identidadeEstado);

            return pqAtivaSemResumo == null ? true : false;
        }

        private void CriaPQjuntoComResumo(IdentidadePQ identidadePQ)
        {

            var resumoVazioComPQ = Resumo.CriarResumoVazioComPQ(identidadePQ);

            _repoResumos.CadastarResumo(resumoVazioComPQ);

          

        }

        private void criaPQComResumoEncontrado(Resumo resumoSemPQEncontrado, IdentidadePQ identidadeNovaPQ)
        {
            resumoSemPQEncontrado.VincularResumoComPQ(identidadeNovaPQ);
            var versao = new Versao(identidadeNovaPQ.NumeroPQ, "Sincronização", "Criacao PQ apos Resumo", DateTime.Now);
            resumoSemPQEncontrado.SincronizarResumComPQ(versao);
            _repoResumos.Modificar(resumoSemPQEncontrado);
        }

        private IdentidadePQ obtemIdentificadorNovaPQ(DataPQ dataPQ)
        {
            var ultimaPQEmitida = _repoPQPipeVale.ObterUlitmaPQEmitida(dataPQ.IdentidadePQ.IdentidadeEstado);



            if (ultimaPQEmitida == null)
            {
                return dataPQ.IdentidadePQ;
            }
            else
            {
                return new IdentidadePQ(dataPQ.IdentidadePQ.IdentidadeEstado, ultimaPQEmitida.IdentidadePQ.NumeroPQ + 1);
            }

        }

        public void criaListaLinhas(List<ItemPQ> itens, DataPQ dataPQ)
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
               item.ItemTag.NumeroAtivo.AreaTag.Area,
               item.ItemTag.NumeroAtivo.AreaTag.SubArea,
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


            if (dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == _atividadeK.GUID) == null)
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
