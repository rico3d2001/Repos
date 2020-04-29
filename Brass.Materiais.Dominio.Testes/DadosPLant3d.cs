using System;
using System.Collections.Generic;
using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Servico.Fabricas;
using Brass.Materiais.Dominio.Servico.Service;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
