using AutoMapper;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.Catalogo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace Brass.Materiais.RepositorioSQLitePlant.Teste
{
    [TestClass]
    public class UnitTestSQLite
    {
        [TestMethod]
        public void EngineeringItems_ConsultaTodos()
        {

            string endereco = @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";
            ConexaoSQLite.BuildConnectionString(endereco);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EngineeringItems, ItemEngenhariaP3D>());

            //teste
            config.AssertConfigurationIsValid();

            List<ItemEngenhariaP3D> itemEngenhariaP3Ds;
            using(var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(Storage.ConnectionString);

                itemEngenhariaP3Ds = (List<ItemEngenhariaP3D>)dominioService.GetAll();
            }

            Assert.IsTrue(itemEngenhariaP3Ds.Count > 0);


        }

        [TestMethod]
        public void Tabelas_Testex()
        {

            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";

            ConexaoSQLite.BuildConnectionString(endereco);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PnPTables, TabelaP3D>());

            //teste
            config.AssertConfigurationIsValid();

            List<TabelaP3D> tabelas;
            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<PnPTables>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var tabelasx = dominioService.GetAll();
            }

            //Assert.IsTrue(tabelas.Count > 0);


        }

       

        [TestMethod]
        public void AtualizaItemCode()
        {

            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";

            ConexaoSQLite.BuildConnectionString(endereco);

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<PnPTables, TabelaP3D>());

            //teste
            //config.AssertConfigurationIsValid();

            //List<TabelaP3D> tabelas;

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var collection = dominioService.GetAll();

                foreach (var item in collection)
                {
                    var guid = Guid.NewGuid().ToString();
                    item.ItemCode = guid;

                    dominioService.Update(item);
                }
            }

            //Assert.IsTrue(tabelas.Count > 0);


        }

        //  var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
        [TestMethod]
        public void Buscar_PartFamilyId_Para_Itens()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
     
            ConexaoSQLite.BuildConnectionString(endereco);


            List<ItemPipe> itensModificados = new List<ItemPipe>();

            var guidCatalogo = "532f43f4-59eb-4962-a4a9-edf7cee699a5";

            RepoItemPipe repoItemPipe = new RepoItemPipe();
          


            //var itensPipe = repoItemPipe.ObterTodosDoCatalogo(guidCatalogo);
                //.Encontrar(Builders<ItemPipe>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var collection = dominioService.GetAll();

                foreach (var item in collection)
                {
                 
                   


                    string partFamilyId = item.PartFamilyId.ToString();
                    if (itensModificados.FirstOrDefault(x => x.PartFamilyId == partFamilyId) == null)
                    {
                        var descricaoSize = item.PartSizeLongDesc;

                        var itemParaModificar = repoItemPipe.ObterPorDescricaoComplexa(descricaoSize, guidCatalogo);



                        itemParaModificar.PartFamilyId = partFamilyId;

                        repoItemPipe.Modificar(itemParaModificar);

                        itensModificados.Add(itemParaModificar);

                    }

                    //familia.PartFamilyId = 
                }
            }

            
        }

        [TestMethod]
        public void Buscar_PartFamilyId_Para_Familias()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";

            ConexaoSQLite.BuildConnectionString(endereco);


            List<Familia> familiasModificadas = new List<Familia>();

            var guidCatalogo = "532f43f4-59eb-4962-a4a9-edf7cee699a5";


            var familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");

            var familias = familiasRepositorio
                .Encontrar(Builders<Familia>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(Storage.ConnectionString);

                var collection = dominioService.GetAll();

                foreach (var item in collection)
                {
                    string partFamilyId = item.PartFamilyId.ToString();
                    if (familiasModificadas.FirstOrDefault(x => x.PartFamilyId == partFamilyId) == null)
                    {
                        var descricao = item.PartFamilyLongDesc;
                        var familiaParaModificar = familias.FirstOrDefault(x => x.PartFamilyLongDesc.VALOR == descricao);

                        familiaParaModificar.PartFamilyId = partFamilyId;

                        familiasRepositorio.Atualizar(familiaParaModificar);

                    }

                    //familia.PartFamilyId = 
                }
            }


        }



        [TestMethod]
        public void Insere_GUID_ITEM()
        {

            string endereco = @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";
            ConexaoSQLite.BuildConnectionString(endereco);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EngineeringItems, ItemEngenhariaP3D>());

            //teste
            config.AssertConfigurationIsValid();

            List<ItemEngenhariaP3D> itemEngenhariaP3Ds;
            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(Storage.ConnectionString);

                itemEngenhariaP3Ds = (List<ItemEngenhariaP3D>)dominioService.GetAll();
            }

            Assert.IsTrue(itemEngenhariaP3Ds.Count > 0);


        }



    }
}
