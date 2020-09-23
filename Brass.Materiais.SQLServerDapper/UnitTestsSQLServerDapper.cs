using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.SQLServerDapper
{
    [TestClass]
    public class UnitTestsSQLServerDapper
    {
        [TestMethod]
        public void ItemEngenhariaService_Assertivo()
        {
            string itemEngenhariaGUID = "000be1a9-1cca-4cdc-8def-e5b11468f5f6";
            //string tipoItemGUID = "074fbfe5-5149-4863-8f1b-e298eac2f469";
            //string catalogoPlant3dGUID = "adb0167e-3362-4a34-bce9-2c06bdf1ee36";

            ItemEngenhariaServiceSQL itemEngenhariaService = new ItemEngenhariaServiceSQL();

            var propriedades = itemEngenhariaService.ObterPorId(itemEngenhariaGUID);

            Assert.IsTrue(propriedades.Count > 0);

        }

        [TestMethod]
        public void LinhasPipe_Assertivo()
        {
            var arquivo = @"O:\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\Plant 3D Models\0100 - Mina Subterrânea Geral\0100 - Mina Subterrânea.dwg";
            LinhasPipeSQL.GetLinhas(arquivo, "_bdb1922_Piping");
        }

        //[TestMethod]
        //public void GetTubosSQLServer_Assertivo()
        //{

        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPipePlant3d>("BIM", "ItemPipePlant3d");

        //    //List<ItemPipePlant3d> listaItens = new List<ItemPipePlant3d>();
        //    var arquivo = @"O:\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\Plant 3D Models\0100 - Mina Subterrânea Geral\0100 - Mina Subterrânea.dwg";
        //    var database = "_bdb1922_PnId";


        //    var collection = LinhasPipe.GetTubosSQLServer(arquivo, database);

        //    foreach (var item in collection)
        //    {

        //        var listaValores = item.Values.ToList();

        //        repositorioItemPipePlant3d.Inserir(new ItemPipePlant3d(
        //               listaValores.ElementAt(0).ToString(),
        //               listaValores.ElementAt(1).ToString(),
        //               listaValores.ElementAt(2).ToString(),
        //               listaValores.ElementAt(3).ToString(),
        //               listaValores.ElementAt(4).ToString()));



        //        //foreach (var valor in item.Values.ToList())
        //        //{
        //        //    var area = valor.ToString();
        //        //}
        //        //ItemPipePlant3d itemPipe = new ItemPipePlant3d(
        //        //       item.Values.ToString()
        //        //    ); 
        //    }

        //}

        //[TestMethod]
        //public void ObterItensTubulacaoArquivo_Estoque_Assertivo()
        //{
        //    var database = "_bdb1922_PnId";
        //    var arquivo = @"O:\Ativos\BdB1922_NEXA_BONSUCESSO\3D\PLANT3D\BdB1922\PID DWG\0101 - Rampa Sul\H - Hidraulica\BdB1922-0000-H-FE0003.dwg";

        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPipePlant3d>("BIM", "ItemPipePlant3d");

        //    repositorioItemPipePlant3d.Encontrar(Builders<ItemPipePlant3d>.Filter.Eq(x => x.GUID_CATALOGO, guidCatalogo));

        //}


    }
}
