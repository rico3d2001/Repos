using System;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.CarregarMongoDB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Carregar()
        {

            ItemEngenhariaService itemEngenhariaService = new ItemEngenhariaService();

            var catalogos = itemEngenhariaService.ObterCatalogos();

            RamalEstoqueService ramalEstoqueService = new RamalEstoqueService();

        }
    }
}
