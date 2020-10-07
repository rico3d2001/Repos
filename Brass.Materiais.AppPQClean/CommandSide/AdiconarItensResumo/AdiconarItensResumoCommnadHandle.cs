using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.AdiconarItensResumo
{
    public class AdiconarItensResumoCommnadHandle : Notifiable, IRequestHandler<AdiconarItensResumoCommnad>
    {
        RepoResumo _repoResumo;
        RepoItemPQ _repoItemPQ;
        RepoPQ _repoPQ;
     
        //BaseMDBRepositorio<ItemPQ> _repoItemPQPlant3d;

  

        public async Task<Unit> Handle(AdiconarItensResumoCommnad command, CancellationToken cancellationToken)
        {
            _repoResumo = new RepoResumo(command.TextoConexao);
            _repoItemPQ = new RepoItemPQ(command.TextoConexao);
            _repoPQ = new RepoPQ(command.TextoConexao);

            DataPQ ultimaPQ = _repoPQ.ObterUltimaPQAtivaDoHub(command.IdentidadePQ.IdentidadeEstado);

            var itens = _repoItemPQ.ObterListaPorResumo(command.Itens);

            if (naoHaPQCadastrada(ultimaPQ))
            {
                var resumoSemPQEncontrado = _repoResumo.ObterResumoAtivoOndePQNaoFoiEmitida(command.IdentidadePQ);
                if(resumoSemPQEncontrado == null)
                {
                    criarResumoSemUsarPQ(command, itens);
                }
                else
                {
                    resumoSemPQEncontrado.AdicionarItens(itens);
                    _repoResumo.Modificar(resumoSemPQEncontrado);
                }
                
            }
            else
            {
                var resumoEncontrado = _repoResumo.ObterResumo(ultimaPQ.IdentidadePQ);

                if (resumoEncontrado == null)
                {
                    criarResumoComBaseNaUltimaPQ(command, ultimaPQ, itens);
                    var versao = new Versao(ultimaPQ.Versao.Numero, "Sincronização", "Acrescimo itens PQ existente", DateTime.Now);
                    resumoEncontrado.SincronizarResumComPQ(versao);

                }
                else if(resumoEncontrado.EstaVinculadoComPQ(ultimaPQ))
                {
                    resumoEncontrado.AdicionarItens(itens);
                    _repoResumo.Modificar(resumoEncontrado);
                }
                else
                {
                    resumoEncontrado.VincularResumoComPQ(ultimaPQ.IdentidadePQ);
                    var versao = new Versao(ultimaPQ.Versao.Numero, "Sincronização", "Acrescimo itens PQ existente", DateTime.Now);
                    resumoEncontrado.SincronizarResumComPQ(versao);
                    _repoResumo.Modificar(resumoEncontrado);
                }
            }

            AtualizarQuantidadesDosItensAdicionadosAoResumo(itens);

            return Unit.Value;

        }

        

        private void criarResumoComBaseNaUltimaPQ(AdiconarItensResumoCommnad command, DataPQ ultimaPQ, List<ItemPQ> itens)
        {
            var identidadePQ = new IdentidadePQ(command.IdentidadePQ.IdentidadeEstado, ultimaPQ.IdentidadePQ.NumeroPQ + 1);
            var resumoNovo = Resumo.CriarResumoComListaSemPQ(identidadePQ, itens);
            _repoResumo.CadastarResumo(resumoNovo);
        }

        private void criarResumoSemUsarPQ(AdiconarItensResumoCommnad command, List<ItemPQ> itens)
        {
            var identidadePQ = new IdentidadePQ(command.IdentidadePQ.IdentidadeEstado, -1);
            var resumoNovo = Resumo.CriarResumoComListaSemPQ(identidadePQ, itens);
            _repoResumo.CadastarResumo(resumoNovo);
        }

        private static bool naoHaPQCadastrada(DataPQ ultimaPQ)
        {
            return ultimaPQ == null;
        }

        private void AtualizarQuantidadesDosItensAdicionadosAoResumo(List<ItemPQ> lista)
        {
            foreach (var item in lista)
            {
                //var itemEncontrado = _repoItemPQ.ObterPorGuid(item.GUID);

                item.SomaValorQuatidade = item.SomaValorQuatidade - item.SomaValorQuatidade;
                //itemEncontrado.ItensModelados = new List<ItemModelado>();
                _repoItemPQ.ModificarItemPQ(item);
            }
        }

        

        //private Resumo CriarResumo(AdiconarItensResumoCommnad command)
        //{
        //    Versao versao = new Versao(0, "Modelo3d", "Inicio Resumo", DateTime.Now);

        //    var resumoNovo = new Resumo(command.GuidProjeto, command.SiglaUsuario, true, false);

        //    resumoNovo.AdicionaPrimeiraListaDeItens(command.Itens);

            
        //}

    }
}
