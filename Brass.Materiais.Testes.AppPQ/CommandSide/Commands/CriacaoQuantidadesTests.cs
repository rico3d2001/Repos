using Brass.Materiais.PQ.Dominio.Servico.CommandSide.Commands.CriarQuantificadoPipe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.Testes.AppPQ.CommandSide.Commands
{
    [TestClass]
    public class CriacaoQuantidadesTests
    {
        [TestMethod]
        public void Handle_DeveCriarQuantidades()
        {
            string guidItemPQ = "338d7902-f0f3-4526-807b-98f1afde6027";

            var quantificadoPipeCommand = new CriarQuantificadoPipeCommand(guidItemPQ);

            var handle = new CriarQuantificadoPipeCommandHandle();

            var teste = handle.Handle(quantificadoPipeCommand, CancellationToken.None);


        }

        

    }
}
