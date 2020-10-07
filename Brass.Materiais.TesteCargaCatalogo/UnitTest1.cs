using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.AspNetCoreInjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Unity;

namespace Brass.Materiais.TesteCargaCatalogo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Carrregar()
        {

            
           

         


            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Inglês";
            string pais = "USA";
            //string conexao = "name=DataBaseContext";






            var injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, "");

            var itensEngenhariaP3D = capturarItensEngenhariaPlant3d();


        }

        private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        {

            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat";

            List<EngineeringItems> listaResult;

            using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
            {
                dominioService.Start(string.Format("Data Source={0};Version=3;", endereco));

                listaResult = (List<EngineeringItems>)dominioService.GetAll();


            }

            return listaResult;

        }


    }
}
