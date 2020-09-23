using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Resumo : Entidade
    {
        private Resumo(IdentidadePQ identidadePQ)
        {
            IdentidadePQ = identidadePQ;
            Itens = new List<ItemPQ>();
        }

        public Resumo()
        {

        }

        public Resumo(IdentidadePQ identidadePQ, List<ItemPQ> itens)
        {
            IdentidadePQ = identidadePQ;
            Itens = itens;
        }

        public void SincronizarResumComPQ(Versao versao)
        {
            if (VersoesEstaoDierentes(versao) && versaoDaPQSuperiorAoResumo(versao))
            {
                Versao = versao;
            }


        }

        private bool VersoesEstaoDierentes(Versao versao)
        {
            return !versao.Equals(this.Versao);
        }

        private bool versaoDaPQSuperiorAoResumo(Versao versao)
        {
            return versao.Numero > this.Versao.Numero ? true : false;
        }

        public void VincularResumoComPQ(IdentidadePQ identidadePQ)
        {
            this.IdentidadePQ.NumeroPQ = identidadePQ.NumeroPQ;
        }


        //public static Resumo CriarResumoSemPQComLista(string guidProjeto, string siglaUsuario)
        //{
        //    var resumo = new Resumo(guidProjeto, siglaUsuario);

        //    resumo.Versao = primeiraVersaoSemPQ();
        //    resumo.Itens = new List<ItemPQ>();
        //    resumo.EstaAtivo = true;
        //    resumo. PQEstaEmitida = false;

        //    return resumo;
        //}





        public static Resumo CriarResumoVazioComPQ(IdentidadePQ identidadePQ)
        {


            var resumo = new Resumo(identidadePQ);


            //resumo.GuidPQ = dataPQ.GUID;

            resumo.Versao = new Versao(0, "resumoVazioComPQ", "resumoVazioComPQ", DateTime.Now);
            resumo.Itens = new List<ItemPQ>();
            resumo.EstaAtivo = true;
            resumo.PQEstaEmitida = false;

            return resumo;

        }

        //public void VinculaResumoPQ(IdentidadePQ identidadePQ)
        //{
        //    Versao = new Versao(Versao.Numero + 1, identidadePQ.IdentidadeEstado.SiglaUsuario, "Vincula resumo a PQ", DateTime.Now);
        //    IdentidadePQ = identidadePQ;
        //}

        public void AdicionarItens(List<ItemPQ> itens)
        {
            adicionaListaDeItens(itens);
        }

        public bool EstaVinculadoComPQ(DataPQ dataPQ)
        {
            return this.IdentidadePQ.Equals(dataPQ.IdentidadePQ) ? true : false;
        }

        public static Resumo CriarResumoComListaSemPQ(IdentidadePQ identidadePQ, List<ItemPQ> itens)
        {

            //string guidProjeto, string siglaUsuario,string guidDisciplina, List< ItemPQ > itens, int numeroPQ)
            var resumo = new Resumo(identidadePQ);
            resumo.EstaAtivo = true;
            resumo.PQEstaEmitida = false;

            resumo.Versao = new Versao(0, "Modelo3d", "Inicio Resumo sem PQ", DateTime.Now);

            resumo.IncluirListaDeItens(itens);

            return resumo;

            //private Resumo CriarResumo(AdiconarItensResumoCommnad command)
            //{
            //    

            //    var resumoNovo = new Resumo(command.GuidProjeto, command.SiglaUsuario, true, false);

            //    resumoNovo.AdicionaPrimeiraListaDeItens(command.Itens);


            //}
        }

        public IdentidadePQ IdentidadePQ { get; set; }
        public List<ItemPQ> Itens { get; set; }
        public Versao Versao { get; set; }


        //private static Versao primeiraVersaoSemPQ()
        //{
        //    return new Versao(0, "Modelo3d", "Inicio Resumo", DateTime.Now);
        //}



        private void adicionaItem(ItemPQ itemPQPlant3)
        {

            Itens.Add(itemPQPlant3);
        }

        private void adicionaListaDeItens(List<ItemPQ> itens)
        {
            foreach (var item in itens)
            {
                if (itemNaoFoiCarregado(item))
                {
                    adicionaItem(item);
                }
            }
        }

        private bool itemNaoFoiCarregado(ItemPQ item)
        {
            return Itens.FirstOrDefault(x => x.GUID == item.GUID) == null ? true : false;
        }

        public void IncluirListaDeItens(List<ItemPQ> itens)
        {
            //Versao.Numero = Versao.Numero + 1;

            adicionaListaDeItens(itens);
        }

        public void ReplaceItem(ItemPQ itemPQPlant3)
        {
            Itens[Itens.FindIndex(x => x.GUID == itemPQPlant3.GUID)] = itemPQPlant3;
        }

        public string GuidPQ { get; set; }

        public bool PQEstaEmitida { get; set; }
        public bool EstaAtivo { get; set; }

    }
}
