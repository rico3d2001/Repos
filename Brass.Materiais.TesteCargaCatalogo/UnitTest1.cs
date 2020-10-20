using Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Tubulacao;
using Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoDoSPE;
using Brass.Materiais.AppCatalogoPlant3d.Service;
using Brass.Materiais.AspNetCoreInjecaoDependencia;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using Unity;

namespace Brass.Materiais.TesteCargaCatalogo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Carregar_Catalogo_Com_Itens_Do_SQLite()
        {







            //string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            //string idioma = "Inglês";
            //string pais = "USA";
            //string conexao = "name=DataBaseContext";

            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Valves Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string guidDisciplina = "f8858d95-5eba-4d21-8606-4b813efa568b";

            var command = new CarregaCatalogoCompletoTubulacaoCommand(endereco, idioma, pais, "local", guidDisciplina);
            var handler = new CarregaCatalogoCompletoTubulacaoCommandHandler();
            var teste = handler.Handle(command, CancellationToken.None);

            //var injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, "Local");

            //var itensEngenhariaP3D = capturarItensEngenhariaPlant3d();


        }

        //[TestMethod]
        //public void Carrregar_SPE_Vale_De_Planilha_Excel()
        //{
        //    CarregaCatalogoDoSPECommand command = new CarregaCatalogoDoSPECommand(,)

        //}

        //private List<EngineeringItems> capturarItensEngenhariaPlant3d()
        //{

        //    string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Valves Catalog.pcat";

        //    List<EngineeringItems> listaResult;

        //    using (var dominioService = DIContainer.Instance.AppContainer.Resolve<DominioService<EngineeringItems>>())
        //    {
        //        dominioService.Start(string.Format("Data Source={0};Version=3;", endereco));

        //        listaResult = (List<EngineeringItems>)dominioService.GetAll();


        //    }

        //    return listaResult;

        //}


    }
}
