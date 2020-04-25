using AutoMapper;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Interfaces;
using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.Dominio.ValueObjects.Plant3D;
using Brass.Materiais.InjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using Brass.Materiais.RepositorioSQLitePlant.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
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
        public void Tabelas_Teste()
        {

            string endereco = @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string conexao = "name=DataBaseContext";

            ConexaoSQLite.BuildConnectionString(endereco);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<PnPTables, TabelaP3D>());

            //teste
            config.AssertConfigurationIsValid();

            List<TabelaP3D> tabelas;
            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<PnPTables>>())
            {
                dominioService.Start(Storage.ConnectionString);

                tabelas = (List<TabelaP3D>)dominioService.GetAll();
            }

            Assert.IsTrue(tabelas.Count > 0);


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
