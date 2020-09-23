using Brass.Materiais.AppBIM.QuerySide.ObterEAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIM.Testes
{
    [TestClass]
    public class Query_AppBIMTestes
    {
        [TestMethod]
        public void A_ObterEAPQueryHandle_Assertivo()
        {
            var guidProjeto = "48e9eb46-5a26-4b9c-9a53-163d448336fb";
            //var tipoEAP = "Processo";
            var obterEAPQuery = new ObterEAPQuery(guidProjeto, "BIM", "EAPTubulacao"); //tipoEAP, "BIM", "EAPTubulacao");

            var obterEAPQueryHandle = new ObterEAPQueryHandle();

            obterEAPQueryHandle.Handle(obterEAPQuery, CancellationToken.None);

        }

        ////ObterItensModeladosPipePlant3dQueryHandle
        //[TestMethod]
        //public void B_ObterItensModeladosPipePlant3dQueryHandle_Assertivo()
        //{

        //    string 

        //    var obterEAPQuery = new ObterItensModeladosPipePlant3dQuery(guidProjeto, tipoEAP);

        //    var obterEAPQueryHandle = new ObterEAPQueryHandle();

        //    obterEAPQueryHandle.Handle(obterEAPQuery, CancellationToken.None);

        //}

    }
}
