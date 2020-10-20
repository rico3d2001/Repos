using Brass.Materiais.AppPQClean.CommandSide.AdiconarItensResumo;
using Brass.Materiais.AppPQClean.ViewModel;
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


        SequencialItem _sequencialItem;
        AtividadesPQ _atividadesPQ;
        string _conexao;
        RepoNivelAtividade _repoNivelAtividade;
        RepoSPE _repoSPE;

        public AddResumoParaPQCommandHandle()
        {
            
        }

        public async Task<Unit> Handle(AddResumoParaPQCommand command, CancellationToken cancellationToken)
        {
            _repoNivelAtividade = new RepoNivelAtividade(command.TextoConexao);
            _repoSPE = new RepoSPE(command.TextoConexao);
            _conexao = command.TextoConexao;

            var repoPQPipeVale = new RepoPQ(command.TextoConexao);
            var repoItemPQ = new RepoItemPQ(command.TextoConexao);


            var dataPQ = repoPQPipeVale.ObterUltimaPQAtivaDoHub(command.IdentidadePQ.IdentidadeEstado);

            _sequencialItem = new SequencialItem(4);

            dataPQ.ResetLinhas();

            var itensComSomatoriaDePesoCorridigida = RetornaItensComSomatoriaDePesoCorridigida(command.ItensParametro);

            var itensAdicicionados = new List<ItemPQ>();

            foreach (var itemCorrigido in itensComSomatoriaDePesoCorridigida)
            {

                _atividadesPQ = new AtividadesPQ(itemCorrigido, _conexao);

                //if (dataPQ.ListaDataPQ == null || dataPQ.ListaDataPQ.Count <= 0)
                //{

                //    InsereClassificacao(dataPQ, atividadesPQ);
                //}


                if (itensAdicicionados.FirstOrDefault(x => x.GUID == itemCorrigido.GUID) == null)
                {



                    var atividadePai = dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == itemCorrigido.Atividade.GUID_PAI);
                    if (atividadePai != null)
                    {

                        //InsereClassificacao(dataPQ, atividadesPQ);

                        _sequencialItem.IniciaSequencia();

                        var agrupamento = itensComSomatoriaDePesoCorridigida.Where(x => x.Atividade.GUID_PAI == _atividadesPQ.VVV.GUID).OrderBy(x => x.Atividade.Codigo).ToList();


                        foreach (var itemPQ in agrupamento)
                        {
                            _sequencialItem.Soma();

                            var linhaDataPQ = CriarLinhaVindaDoItem(itemPQ);

                            dataPQ.AddItem(linhaDataPQ);
                            itensAdicicionados.Add(itemPQ);

                        }



                    }
                    else
                    {


                        InsereClassificacao(dataPQ);

                        _sequencialItem.IniciaSequencia();

                        var agrupamento = itensComSomatoriaDePesoCorridigida
                                                     .Where(x => x.Atividade.GUID_PAI == _atividadesPQ.VVV.GUID)
                                                     .OrderBy(x => x.Atividade.Codigo).ToList();


                        foreach (var itemPQ in agrupamento)
                        {
                            _sequencialItem.Soma();

                            var linhaDataPQ = CriarLinhaVindaDoItem(itemPQ);

                            dataPQ.AddItem(linhaDataPQ);
                            itensAdicicionados.Add(itemPQ);

                        }


                    }

                }


            }

            repoPQPipeVale.Modificar(dataPQ);

            return Unit.Value;
        }

        private List<ItemPQ> RetornaItensComSomatoriaDePesoCorridigida(List<ItemPQ> itensParametro)
        {

            var itens = new List<ItemPQ>();

            var repoItemPQ = new RepoItemPQ(_conexao);

            foreach (var item in itensParametro)
            {
                var itemEncontrado = repoItemPQ.ObterPorGuid(item.GUID);
                itemEncontrado.SomaValorQuatidade = item.SomaValorQuatidade;
                itens.Add(itemEncontrado);

            }

            return itens;
        }




        private LinhaDataPQ CriarLinhaVindaDoItem(ItemPQ itemCorrigido) //, double somaValorQuatidade)
        {

            var quantidade = itemCorrigido.SomaValorQuatidade;




            string unidade = itemCorrigido.Unidade;
            if (itemCorrigido.Atividade != null && itemCorrigido.Atividade.Unidade != "")
            {
                unidade = itemCorrigido.Atividade.Unidade;

                if (itemCorrigido.Unidade == "unid." && unidade == "t")
                {
                    quantidade = (int)(quantidade * itemCorrigido.PesoUnidade / 1000);
                }

            }

            


            string descricao = itemCorrigido.SpecPart;

            if ((_atividadesPQ.K.Codigo == "M" || _atividadesPQ.K.Codigo == "D") &&  descricao.Split(',')[0].Trim() == "TUBO")
            {
                if(itemCorrigido.NominalDiameter <= 8)
                {
                    descricao = descricao + " INCLUSIVE VÁLVULAS E CONEXÕES .";
                }
                else
                {
                    descricao = descricao + " INCLUSIVE CONEXÕES .";
                }
            }



            if(itemCorrigido.Unidade == "unid.")
            {
                return new LinhaDataPQ(
                         _sequencialItem.Escrita,
                         itemCorrigido.ItemTag.NumeroAtivo.AreaTag.Area,
                         itemCorrigido.ItemTag.NumeroAtivo.AreaTag.SubArea,
                         itemCorrigido.ItemTag.NumeroAtivo.Sigla,
                          _atividadesPQ.K.Codigo,
                            _atividadesPQ.TT.Codigo,
                            _atividadesPQ.UU.Codigo,
                            _atividadesPQ.VVV.Codigo,
                         itemCorrigido.Atividade.Codigo,
                         descricao,
                         unidade == "unid." ? "un" : unidade,
                         "CMS",
                           _atividadesPQ.K.Codigo,
                            _atividadesPQ.TT.Codigo,
                            _atividadesPQ.UU.Codigo,
                          "000",
                          quantidade.ToString(),
                          "20%",
                          "",
                          "",
                          "",
                          "",
                          itemCorrigido.Atividade.GUID,
                          itemCorrigido.Atividade.GUID_PAI
                         );
            }
            else
            {
                return new LinhaDataPQ(
                         _sequencialItem.Escrita,
                         itemCorrigido.ItemTag.NumeroAtivo.AreaTag.Area,
                         itemCorrigido.ItemTag.NumeroAtivo.AreaTag.SubArea,
                         itemCorrigido.ItemTag.NumeroAtivo.Sigla,
                          _atividadesPQ.K.Codigo,
                            _atividadesPQ.TT.Codigo,
                            _atividadesPQ.UU.Codigo,
                            _atividadesPQ.VVV.Codigo,
                         itemCorrigido.Atividade.Codigo,
                         descricao,
                         unidade == "mm" ? "m" : unidade,
                         "CMS",
                           _atividadesPQ.K.Codigo,
                            _atividadesPQ.TT.Codigo,
                            _atividadesPQ.UU.Codigo,
                          "000",
                          Math.Round((double)quantidade / 1000, 2).ToString(),
                          "20%",
                          "",
                          "",
                          "",
                          "",
                          itemCorrigido.Atividade.GUID,
                          itemCorrigido.Atividade.GUID_PAI
                         );
            }

          
        }

        private void InsereClassificacao(DataPQ dataPQ)
        {

            int indiceParametro = 1;

            if (SeNovaEmRealacaoA(_atividadesPQ.K, dataPQ))
            {

                if (_sequencialItem.EstaEmReinicio())
                {
                    _sequencialItem.Reincia();
                }
                else if (_sequencialItem.EstaAvancado(indiceParametro))
                {

                    _sequencialItem.Recua(indiceParametro);
                }
                else
                {
                    _sequencialItem.Avanca();
                }



                var linhaK = CriaLinha(_atividadesPQ.K, indiceParametro);

                dataPQ.AddItem(linhaK);



            }


            indiceParametro++;

            if (SeNovaEmRealacaoA(_atividadesPQ.TT, dataPQ))
            {

                if (_sequencialItem.EstaAvancado(indiceParametro))
                {
                    _sequencialItem.Recua(indiceParametro);
                }
                else
                {
                    _sequencialItem.Avanca();
                }




                var linhaTT = CriaLinha(_atividadesPQ.TT, indiceParametro);

                dataPQ.AddItem(linhaTT);
            }


            indiceParametro++;


            if (SeNovaEmRealacaoA(_atividadesPQ.UU, dataPQ))
            {
                if (_sequencialItem.EstaAvancado(indiceParametro))
                {
                    _sequencialItem.Recua(indiceParametro);
                }
                else
                {
                    _sequencialItem.Avanca();
                }



                var linhaUU = CriaLinha(_atividadesPQ.UU, indiceParametro);

                dataPQ.AddItem(linhaUU);
            }

            indiceParametro++;

            if (SeNovaEmRealacaoA(_atividadesPQ.VVV, dataPQ))
            {


                if (_sequencialItem.EstaAvancado(indiceParametro))
                {
                    _sequencialItem.Recua(indiceParametro);
                }
                else
                {
                    _sequencialItem.Avanca();
                }



                LinhaDataPQ linhaVVV = CriaLinha(_atividadesPQ.VVV, indiceParametro);

                dataPQ.AddItem(linhaVVV);
            }

        }

        private bool SeNovaEmRealacaoA(Atividade atividade, DataPQ dataPQ)
        {
            return dataPQ.ListaDataPQ.LastOrDefault(x => x.GuidAtividade == atividade.GUID) == null;
        }



        private LinhaDataPQ CriaLinha(Atividade atividade, int indiceParametro)
        {

            //var nivelAtividade = _repoNivelAtividade.ObterPorNomeDoNivel(atividade.NivelAtividade);

            //var ordenador = nivelAtividade.Oredenador;

            string cor = "mat-grid-tile-" + atividade.NivelAtividade;

            var k = 0 <= (indiceParametro - 1) ? _atividadesPQ.K.Codigo : "0";
            //ordenador++;
            var tt = 1 <= (indiceParametro - 1) ? _atividadesPQ.TT.Codigo : "00";
            //ordenador++;
            var uu = 2 <= (indiceParametro - 1) ? _atividadesPQ.UU.Codigo : "000";
            //ordenador++;
            var vvv = 3 <= (indiceParametro - 1) ? _atividadesPQ.VVV.Codigo : "000";

            return new LinhaDataPQ(
                             _sequencialItem.Escrita,
                             "",
                             "",
                             "",
                             k,
                             tt,
                             uu,
                             vvv,
                              "000",
                             atividade.Descricao,
                             "", "", "", "", "", "", "", "", "", "", "",
                             cor,
                             atividade.GUID,
                             atividade.GUID_PAI); ;

        }
    }
}


