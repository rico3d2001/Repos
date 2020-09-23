using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Brass.Materiais.Testes.AppPQ.QuerySide.Queries
{
    [TestClass]
    public class ArvoreAtividade_Testes
    {

        [TestMethod]
        public void A_ObtemArvoreAtividade_Assertivo()
        {

            string guidDisciplina = "f8858d95-5eba-4d21-8606-4b813efa568b";
            string guidCliente = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            var query = new ObterArvoreAtividadesQuery(guidCliente, guidDisciplina);
            var handler = new ObterArvoreAtividadesQueryHandle();
            
            var result =  handler.Handle(query, CancellationToken.None);

            //Assert.IsTrue(result.Count() == 19);

            Assert.IsNotNull(result);

        }


    }
}
