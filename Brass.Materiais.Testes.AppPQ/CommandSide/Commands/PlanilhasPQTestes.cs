using Brass.Materiais.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.PQ.Dominio.Servico.CommandSide.Commands.CriarPlanilhaPQ;
using Brass.Materiais.PQ.Dominio.Servico.CommandSide.Commands.CriarPQ;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
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
    public class PlanilhasPQTestes
    {
        [TestMethod]
        public void CriarPQConformeVale()
        {

            var itemPQPlant3dRepo = new BaseMDBRepositorio<Resumo>("BIM_TESTE", "ResumoItensPQPlant3d");
            var resumo = itemPQPlant3dRepo.Obter().First();

            //CriarPQValeCommand command2 = new CriarPQValeCommand("Vale", "Tubulacao", resumo.Itens);

            CriarPQValeCommandHandle handle = new CriarPQValeCommandHandle();

            //var request = handle.Handle(command2, CancellationToken.None);
        }
        [TestMethod]
        public void CriarPlanilhaPQConformeVale()
        {



            CriarPlanExcelPQCommand command2 = 
                new CriarPlanExcelPQCommand("61f8207a-97b4-4364-88e5-57bbce3d42dc", "Vale", 
                @"C:\Trabalho\Templates\TemplateVale.xlsx", "M-TUB", "Tubulacao"); //, resumo.Itens);

            CriarPlanExcelPQCommandHandle handle = new CriarPlanExcelPQCommandHandle();

            var request = handle.Handle(command2, CancellationToken.None);
        }
    }
}
