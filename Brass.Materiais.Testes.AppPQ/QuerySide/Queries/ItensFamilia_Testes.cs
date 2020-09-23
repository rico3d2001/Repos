using Brass.Materiais.AppBIM.QuerySide.ObterEAP;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObterFamilias;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace Brass.Materiais.Testes.AppPQ.QuerySide.Queries
{

    [TestClass]
    public class ItensFamilia_Testes
    {
        [TestMethod]
        public async void ObtemItensFamilia()
        {

            ObterItensFamiliaQuery query = new ObterItensFamiliaQuery("764398e4-1de1-40a4-9fb1-2f66c39d5ec2","");
         
            var handler = new ObterItensFamiliaQueryHandler();
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.IsTrue(result.Count() == 19);
        }

        //ObterEAPVolumetricaQueryHandle

        [TestMethod]
        public void ObterEAPVolumetricaQueryHandle()
        {
            string guidProjeto = "BdB1922";
            //string tipo = "Volumetrica";

            var query = new ObterEAPQuery(guidProjeto, "BIM", "EAPTubulacaoModel"); //tipo, "BIM", "EAPTubulacaoModel");

            var handler = new ObterEAPQueryHandle();
            var result = handler.Handle(query, CancellationToken.None);

            //Assert.IsTrue(result.ToList().Count() > 0);
        }
    }
}
