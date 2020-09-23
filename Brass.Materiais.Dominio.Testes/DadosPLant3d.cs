using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Brass.Materiais.Dominio.Testes
{
    [TestClass]
    public class DadosPlant3d
    {
        [TestMethod]
        public void ItemEngenhariaFactory_ObtemPlant3dData_Assertivo()
        {
           


            var itensEngPlant3dService = new CriaItensEngPlant3d(@"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat");

            List<ItemEngenhariaP3D> engineeringItems = itensEngPlant3dService.ObtemPlant3dData();
        }

       



    }
}
