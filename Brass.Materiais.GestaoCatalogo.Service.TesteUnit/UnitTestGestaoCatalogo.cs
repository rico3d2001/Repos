using System;
using System.Collections.Generic;
using System.ComponentModel;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.Servico.Models;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Models;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.GestaoCatalogo.Service.TesteUnit
{
    [TestClass]
    public class UnitTestGestaoCatalogo
    {

        [TestMethod]
        public void Mongo_InjetaItemCompleto()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";//"name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            var injetaPropriedade = new InjetaItemCompletoEstoque(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }

        [TestMethod]
        public void Mongo_Injeta_CategoriaCatalogo()
        {
            var guidCatalogo = "532f43f4-59eb-4962-a4a9-edf7cee699a5";

            CriaCategorias criaCategorias = new CriaCategorias();
            criaCategorias.Injetar(guidCatalogo);

        }

        [TestMethod]
        public void Mongo_Cria_ArvoreCatalogo()
        {

            CriaArvoreCatalogo criaArvoreCatalogo = new CriaArvoreCatalogo();
            criaArvoreCatalogo.ExtraiArvoreEstoque();
        }

        [TestMethod]
        public void Mongo_CriaNomesPropriedades()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var propriedades = criaArvoreCatalogo.ExtraiNomes();

        }


        [TestMethod]
        public void Mongo_ExtraiItensCategoria()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            criaArvoreCatalogo.ExtraiItensCategoria("532f43f4-59eb-4962-a4a9-edf7cee699a5", "9dcd21a8-43f0-4875-bf95-04255f7b2e68");
        }

        [TestMethod]
        public void Mongo_ExtraiOTroncoArvoreCatalogo()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            criaArvoreCatalogo.ExtraiTroncoCatalogo("532f43f4-59eb-4962-a4a9-edf7cee699a5");
        }


        [TestMethod]
        public void Mongo_CriaFamilias()
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            criaArvoreCatalogo.CriaFamilias("532f43f4-59eb-4962-a4a9-edf7cee699a5");
        }



        [TestMethod]
        public void Mongo_PegaTiposItens()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";//"name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            var injetaPropriedade = new InjetaItemCompletoEstoque(endereco, idioma, pais, conexao);
            injetaPropriedade.PegaTipos();
        }

        [TestMethod]
        public void InjetaItemCompleto_Local()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";//"name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }
        /*
        [TestMethod]
        public void InjetaItemCompleto_Azure()
        {
            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Inglês";
            string pais = "USA";
            string conexao = "name=CatalogoBRASSEntities";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }
        */
        [TestMethod]
        public void AlimentaArvoreEstoque()
        {
            ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
            var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
            ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

            arvoreServiceEstoque.CarregaRamaisEstoque();


        }

        [TestMethod]
        public void DoEstoqueAlimentaArvoreEstoque()
        {
            ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
            var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
            ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

            arvoreServiceEstoque.CarregaRamaisEstoque();


        }

        [TestMethod]
        public void RecuperaArvoreEstoque()
        {
            ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
            var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
            ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

            var lista = arvoreServiceEstoque.ListaRamaisArvore();
        }

        [TestMethod]
        public void AlimentaTabelaEstoque()
        {
            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            int intervalo = 1;
            int ultimoPnPID = 0;
            string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";

            //itemEngenhariaEstoqueService.CarregaItensPorTipoItem(guidCatalogo, guidCategoria, guidTipoItem);

        }

        [TestMethod]
        public void AlimentaTodasTabelasEstoque()
        {
            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            ItemEngenhariaService itemEngenhariaService = new ItemEngenhariaService();


            var catalogos = itemEngenhariaService.ObterCatalogos();

            foreach (var catalogo in catalogos)
            {
                var categorias = itemEngenhariaService.ObterCategorias(catalogo.GUID);

                foreach (var categoria in categorias)
                {
                    var tipos = itemEngenhariaService.ObterTiposItem(catalogo.GUID, categoria.GUID);

                    foreach (var tipo in tipos)
                    {
                        //itemEngenhariaEstoqueService.CarregaItensPorTipoItem(catalogo.GUID, categoria.GUID, tipo.GUID);
                    }
                }
            }


            //string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            //string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            //string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";




            

        }



        [TestMethod]
        public void RecuperaTabelaEstoque()
        {
            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            int intervalo = 1;
            int ultimoPnPID = 0;
            string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";

           

            var lista = itemEngenhariaEstoqueService.ObtemItensTubulacaoPorTipoItem(guidTipoItem);

            Assert.IsTrue(lista.Count > 0);


        }



        //[TestMethod]
        //public void Corrigir()
        //{
        //    string endereco = @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat";
        //    string idioma = "Portugues";
        //    string pais = "Brasil";
        //    InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais);
        //    injetaPropriedade.Corrigir();
        //}
    }
}
