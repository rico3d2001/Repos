using Brass.ExcelLeitura.App.Comandos;
using Brass.Materiais.Dominio.Spec.Entidades;
using Brass.Materiais.Dominio.ValueObjects.Versionamentos;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.TesteBulkload.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;

namespace Brass.Materiais.TesteBulkload
{
    [TestClass]
    public class TesteCarga
    {
       



        [TestMethod]
        public void A_Carga_MaterialBase_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<MaterialBase>("Catalogo", "MaterialBase");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new MaterialBaseXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<MaterialBase>(tagueamentoXLS);


            var materiaisBase = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "Material-Base");

     
            foreach (var materialBase in materiaisBase)
            {
                repositorioEspecificacaoGeral.Inserir(materialBase);
            }



            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<MaterialBase>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);

        }


        [TestMethod]
        public void B_Carga_ClassePressao_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<ClassePressao>("Catalogo", "ClassePressao");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new ClassePressaoXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<ClassePressao>(tagueamentoXLS);


            var classesPressao = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "Classe de Pressao");

            foreach (var classePressao in classesPressao)
            {
                repositorioEspecificacaoGeral.Inserir(classePressao);
            }

            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<ClassePressao>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);

        }



        [TestMethod]
        public void C_Carga_CodigosFluidos_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<CodigoFluido>("Catalogo", "CodigoFluido");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new CodigoFluidoXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<CodigoFluido>(tagueamentoXLS);


            var codigosFluido = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "FLUIDOS");

            foreach (var codigoFluido in codigosFluido)
            {
                repositorioEspecificacaoGeral.Inserir(codigoFluido);
            }

            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<CodigoFluido>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);
        }

        //[TestMethod]
        //public void Carga_CodigoMaterial_Assertivo()
        //{

        //}



        




    }
}
