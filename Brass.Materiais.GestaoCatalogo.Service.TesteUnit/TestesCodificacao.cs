using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Handlers.Commnads;
using Brass.Materiais.Dominio.Servico.Handlers.Queries;
using Brass.Materiais.Dominio.Servico.Handlers.Request;
using Brass.Materiais.Dominio.ValueObjects.Siglas;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.GestaoCatalogo.Service.TesteUnit
{
    [TestClass]
    public class TestesCodificacao
    {
        [TestMethod]
        public void CriaCliente_Assertivo()
        {


            //INSERE
            var repositorio = new BaseMDBRepositorio<Cliente>("Catalogo", "Clientes");
            var handleCreateCliente = new HandleCreateCliente(repositorio);

            var command1 = new CreateClienteCommand("NEXA", "Nexa");
            var result1 = (CommandResult<Cliente>)handleCreateCliente.Handle(command1);

            var command2 = new CreateClienteCommand("VALE", "Vale");
            var result2 = (CommandResult<Cliente>)handleCreateCliente.Handle(command2);


            //RECUPERA
            HandlerClientesRequest handlerClientesRequest = new HandlerClientesRequest(repositorio);
            var command3 = new RecuperaClientesRequest();

            var result3 = (CommandResult<Cliente>)handlerClientesRequest.Handle(command3);

            var lista = result3.Result;



            Assert.AreEqual(lista[1].Nome.Texto, result2.Result.First().Nome.Texto);

        }

        [TestMethod]
        public void ObtemPropriedadesColunas()
        {
            var repositorio = new BaseMDBRepositorio<Cliente>("Catalogo", "Clientes");
        }

        [TestMethod]
        public void ObtemPropriedadesCodificaves()
        {

            

            string GUID_CLIENTE_Vale = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            //PartSizeLongDesc
            var repositorioNomeTipoPropriedade = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            var repositorioPropriedadeItem = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");
            var repositorioValorTabelado = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            var repositorioCodigoPipeCatalogo = new BaseMDBRepositorio<Codigo>("Catalogo", "CodigoPipeCatalogo");

            var nomesCodificaves = repositorioNomeTipoPropriedade
                .Encontrar(Builders<NomeTipoPropriedade>.Filter.Eq(x => x.CODIFICAVEL, true));

            //var nomeCodificavel = nomesCodificaves[0];

            

            foreach (var nomeCodificavel in nomesCodificaves)
            {
                var propriedades = repositorioPropriedadeItem
               .Encontrar(Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, nomeCodificavel.GUID));

                foreach (var propriedade in propriedades)
                {
                    var valores = repositorioValorTabelado
                   .Encontrar(Builders<ValorTabelado>.Filter.Eq(x => x.GUID, propriedade.GUID_VALOR));

                    if (valores.Count() == 1)
                    {
                        var codigo = new Codigo(
                               GUID_CLIENTE_Vale,
                               propriedade.GUID,
                               nomeCodificavel.GUID,
                               nomeCodificavel.NOME,
                               valores.First().GUID,
                               valores.First().VALOR,
                               Guid.NewGuid().ToString(),
                               false);

                        repositorioCodigoPipeCatalogo.Inserir(codigo);

                    }

                }
            }

            var listaCodigos = repositorioCodigoPipeCatalogo.Obter();


            Assert.IsTrue(listaCodigos.Count() > 0);

        }

        [TestMethod]
        public void Mongo_ObterValorTextoPorItem()
        {
            //Repositorios usados
            var repositorioNomeTipoPropriedade = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");
            var repositorioValorTabelado = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");
            var repositorioPropriedadeItem = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");


            var tiposPropriedade = repositorioNomeTipoPropriedade
                .Encontrar(Builders<NomeTipoPropriedade>.Filter.Eq(x => x.NOME, "PartSizeLongDesc"));

            var tipo = tiposPropriedade.First();

            var propriedades = repositorioPropriedadeItem
                .Encontrar(Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, tipo.GUID));

            var propriedade = propriedades.First();

            var valorEncontrado = repositorioValorTabelado
            .Encontrar(Builders<ValorTabelado>.Filter.Eq(x => x.GUID, propriedade.GUID_VALOR));

            List<string> textosSeparados = valorEncontrado.First().VALOR.Split(',').ToList();






        }



        [TestMethod]
        public void InserirSiglaValeSpecMaterialBase()
        {
            var repositorioSiglaClassificacaoFluidos = new BaseMDBRepositorio<Siglas>("Catalogo", "SiglaCodigo");

            Siglas siglas = new Siglas("Material-Base Spec", "2a2000fd-b8a3-4619-8b78-2be372851cf9");

            siglas.AdicionaSigla(new SiglaCodigo("A", 1, true, true, "Alumínio e suas ligas"));
            siglas.AdicionaSigla(new SiglaCodigo("B", 1, true, true, "Cobre e suas ligas"));
            siglas.AdicionaSigla(new SiglaCodigo("C", 1, true, true, "Aço Carbono"));
            siglas.AdicionaSigla(new SiglaCodigo("D", 1, true, true, "Ferro Fundido Dúctil e outros"));
            siglas.AdicionaSigla(new SiglaCodigo("F", 1, true, true, "Fibra de Vidro - FRP, PRFV, RPVC"));
            siglas.AdicionaSigla(new SiglaCodigo("G", 1, true, true, "Aço Carbono Galvanizado"));
            siglas.AdicionaSigla(new SiglaCodigo("K", 1, true, true, "Aços Ligas"));
            siglas.AdicionaSigla(new SiglaCodigo("L", 1, true, true, "Aço Carbono Revestido"));
            siglas.AdicionaSigla(new SiglaCodigo("N", 1, true, true, "Níquel e suas Ligas"));
            siglas.AdicionaSigla(new SiglaCodigo("P", 1, true, true, "Plásticos - PP, PEAD, PVC, CPVC"));
            siglas.AdicionaSigla(new SiglaCodigo("S", 1, true, true, "Aço Inoxidável"));
            siglas.AdicionaSigla(new SiglaCodigo("T", 1, true, true, "Titânio e suas Ligas"));


            repositorioSiglaClassificacaoFluidos.Inserir(siglas);

        }

        [TestMethod]
        public void InserirSiglaValeSpecClassePressao()
        {
            var repositorioSiglaClassificacaoFluidos = new BaseMDBRepositorio<Siglas>("Catalogo", "SiglaCodigo");

            Siglas siglas = new Siglas("Classe de Pressão Spec", "2a2000fd-b8a3-4619-8b78-2be372851cf9");

            siglas.AdicionaSigla(new SiglaCodigo("0", 1, true, true, "Não Aplicável"));
            siglas.AdicionaSigla(new SiglaCodigo("1", 1, true, true, "ASME 125 ASME 150"));
            siglas.AdicionaSigla(new SiglaCodigo("3", 1, true, true, "ASME 250 ASME 300"));
            siglas.AdicionaSigla(new SiglaCodigo("4", 1, true, true, "ASME 400"));
            siglas.AdicionaSigla(new SiglaCodigo("6", 1, true, true, "ASME 600"));
            siglas.AdicionaSigla(new SiglaCodigo("9", 1, true, true, "ASME 900"));
            siglas.AdicionaSigla(new SiglaCodigo("A", 1, true, true, "ASME 25"));
            siglas.AdicionaSigla(new SiglaCodigo("B", 1, true, true, "ASME 50"));
            siglas.AdicionaSigla(new SiglaCodigo("C", 1, true, true, "ASME 75"));
            siglas.AdicionaSigla(new SiglaCodigo("D", 1, true, true, "ASME 100"));
            siglas.AdicionaSigla(new SiglaCodigo("F", 1, true, true, "ASME 1500"));
            siglas.AdicionaSigla(new SiglaCodigo("G", 1, true, true, "ASME 2500"));
            siglas.AdicionaSigla(new SiglaCodigo("H", 1, true, true, "ISO PN6"));
            siglas.AdicionaSigla(new SiglaCodigo("K", 1, true, true, "ISO PN8"));
            siglas.AdicionaSigla(new SiglaCodigo("L", 1, true, true, "ISO PN10"));
            siglas.AdicionaSigla(new SiglaCodigo("M", 1, true, true, "ISO PN12.5"));
            siglas.AdicionaSigla(new SiglaCodigo("N", 1, true, true, "ISO PN 16"));
            siglas.AdicionaSigla(new SiglaCodigo("O", 1, true, true, "ISO PN20"));



            repositorioSiglaClassificacaoFluidos.Inserir(siglas);

        }


        [TestMethod]
        public void InserirSiglaClassificacaoFluidosVale()
        {
            var repositorioSiglaClassificacaoFluidos = new BaseMDBRepositorio<Siglas>("Catalogo", "SiglaCodigo");

            Siglas siglas = new Siglas("Classificacao Fluidos", "2a2000fd-b8a3-4619-8b78-2be372851cf9");

            siglas.AdicionaSigla(new SiglaCodigo("A", 1, true, false, "Água e ar"));
            siglas.AdicionaSigla(new SiglaCodigo("B", 1, true, false, "Bases - sais"));
            siglas.AdicionaSigla(new SiglaCodigo("C", 1, true, false, "Condensados"));
            siglas.AdicionaSigla(new SiglaCodigo("E", 1, true, false, "Efluentes"));
            siglas.AdicionaSigla(new SiglaCodigo("G", 1, true, false, "Gases"));
            siglas.AdicionaSigla(new SiglaCodigo("H", 1, true, false, "Ácidos"));
            siglas.AdicionaSigla(new SiglaCodigo("O", 1, true, false,
                "Combustíveis líquidos em geral, óleos combustíveis, lubrificantes, graxas ... e hidrocarbonetos em geral"));
            siglas.AdicionaSigla(new SiglaCodigo("P", 1, true, false, "Polpas"));
            siglas.AdicionaSigla(new SiglaCodigo("Q", 1, true, false, "Produtos químicos diversos: eletrólitos, extratantes, espumantes, floculantes etc"));
            siglas.AdicionaSigla(new SiglaCodigo("R", 1, true, false, "Rejeitos"));
            siglas.AdicionaSigla(new SiglaCodigo("S", 1, true, false, "Soluções em geral e produtos em suspensão"));
            siglas.AdicionaSigla(new SiglaCodigo("V", 1, true, false, "Vapor d'água/vácuo"));
            siglas.AdicionaSigla(new SiglaCodigo("X", 1, true, false, "Outros"));


            repositorioSiglaClassificacaoFluidos.Inserir(siglas);

        }







    }
}
