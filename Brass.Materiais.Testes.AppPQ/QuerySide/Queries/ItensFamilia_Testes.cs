using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterFamilias;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Testes.AppPQ.QuerySide.Queries
{

    [TestClass]
    public class ItensFamilia_Testes
    {
        [TestMethod]
        public void ObtemItensFamilia()
        {

            

            ObterItensFamiliaQuery query = new ObterItensFamiliaQuery("764398e4-1de1-40a4-9fb1-2f66c39d5ec2");
            var familiaItemRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            ObterItensFamiliaQueryHandler handler = new ObterItensFamiliaQueryHandler(familiaItemRepositorio);
            var result = handler.Handle(query);


            var familias = result.Result;

            Assert.IsTrue(familias.Count == 19);
        }
    }
}
