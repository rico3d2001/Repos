using System;
using System.ComponentModel;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.GestaoCatalogo.Service.TesteUnit
{
    [TestClass]
    public class UnitTestGestaoCatalogo
    {

        [TestMethod]
        public void InjetaItemCompleto_Local()
        {
            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Inglês";
            string pais = "USA";
            string conexao = "name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }

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
        /*
        [TestMethod]
        public void AlimentaArvoreEstoque()
        {
            ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService();
            ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

            arvoreServiceEstoque.CarregaRamaisEstoque();


        }

        [TestMethod]
        public void RecuperaArvoreEstoque()
        {
            ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService();
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
        */


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
