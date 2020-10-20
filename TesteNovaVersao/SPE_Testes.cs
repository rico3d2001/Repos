using Brass.Materiais.AppBulkLoad.Models;
using Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoDoSPE;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.InterfaceExcel.Comandos;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace TesteNovaVersao
{
    [TestClass]
    public class SPE_Testes
    {
        [TestMethod]
        public void Carregar_SPE_Vale()
        {
            var conexao = "local";
            var repoBookSPE = new RepoSPEBook(conexao);

            string guidClienteVALE = "8e346a61-2623-448b-b4bd-62232b9f55da";


            var bookSPE = new SPEBook("SPE_TUB_MEC_EST_VALE_FORNECIMENTO", guidClienteVALE,
                new Versao(0, "PE-F-639_REV2", "BIBLIOTECA PARA ATIVIDADES DE FORNECIMENTO DE EQUIPAMENTOS E MATERIAIS MECÂNICOS", DateTime.Now));

           

            repoBookSPE.Cadastrar(bookSPE);

            var teste = repoBookSPE.ObterTodos();

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var xls = new SPEBulkLoad(8, bookSPE, conexao);

            var leituraArquivo = new LeituraArquivo<ItemSPE>(xls);



            //var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\CATALOG_SPE_MEC_TUB_EST.xlsx", "XXX");
            var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\TESTE-PE-F-639_Bibliot_Fornec_Equip_Materiais_Mecanicos_Rev_2.xlsx", "Fornecim. Eqtos e Mat Mecan. ");


            RepoSPE repoSPE = new RepoSPE(conexao);
            foreach (var item in lista)
            {
                repoSPE.Cadastrar(item);
            }

        }


        [TestMethod]
        public void CorrigirSPE()
        {
            var conexao = "local";
            var repoBookSPE = new RepoSPEBook(conexao);
            var bookSPE = repoBookSPE.ObterPorGuid("408ad6a8-bee7-4f31-aaed-5b39c68e43e2");

            var xls = new SPEBulkLoad(8, bookSPE, conexao);

            var leituraArquivo = new LeituraArquivo<ItemSPE>(xls);

            var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\TESTE-PE-F-639_Bibliot_Fornec_Equip_Materiais_Mecanicos_Rev_2.xlsx", "Fornecim. Eqtos e Mat Mecan. ");


            RepoSPE repoSPE = new RepoSPE(conexao);
            foreach (var item in lista)
            {
                var speLinha = repoSPE.ObterPorNiveis(item.Nivel_K, item.Nivel_TT, item.Nivel_UU, item.Nivel_VVV, item.Nivel_WWW);

                repoSPE.Modificar(speLinha);
            }


        }

        [TestMethod]
        public void ItensDoSPE()
        {
            string nome = @"SPE_TUB_MEC_EST_VALE";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";
            string guidDisciplina = "909e5882-0b5e-414f-b37c-79514ac6f69f";

            var command = new CarregaCatalogoDoSPECommand(nome, idioma, pais, conexao, guidDisciplina);
            var handler = new CarregaCatalogoDoSPECommandHandler();

            var result = handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
        }




    }
}
