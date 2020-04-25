using System;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.SQLServerDapper
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemEngenhariaService_Assertivo()
        {
            string itemEngenhariaGUID = "000be1a9-1cca-4cdc-8def-e5b11468f5f6";
            //string tipoItemGUID = "074fbfe5-5149-4863-8f1b-e298eac2f469";
            //string catalogoPlant3dGUID = "adb0167e-3362-4a34-bce9-2c06bdf1ee36";

            ItemEngenhariaService itemEngenhariaService = new ItemEngenhariaService();

            var propriedades = itemEngenhariaService.ObterPorId(itemEngenhariaGUID);

            Assert.IsTrue(propriedades.Count > 0);

        }
    }
}
