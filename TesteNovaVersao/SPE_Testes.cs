using Brass.Materiais.Dominio.Servico.CommandSide.Commands.CarregaCatalogoDoSPE;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
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

            //var repoBookSPE = new BaseMDBRepositorio<SPEBook>("Catalogo", "SPEBooks");

            //string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";


            //var bookSPE = new SPEBook("SPE_TUB_MEC_EST_VALE", guidClienteVALE,
            //    new Versao(0, "PE-F-641_REV2", "BIBLIOTECA PARA ATIVIDADES DE MONTAGEM DESMONTAGEM DE EQUIPAMENTOS E MATERIAIS MECÂNICOS",DateTime.Now));

            //repoBookSPE.Inserir(bookSPE);

            //Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            //var xls = new IntensObitidosSPEXLS(8, bookSPE);

            //var leituraArquivo = new LeituraArquivo<ItemSPE>(xls);



            //var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\CATALOG_SPE_MEC_TUB_EST.xlsx", "XXX");


 

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
