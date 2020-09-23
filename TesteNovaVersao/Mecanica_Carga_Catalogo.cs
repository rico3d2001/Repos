using Brass.Materiais.AppCatalogoPlant3d.CommandSide.CarregaCatalogoCompleto.Mecanica;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TesteNovaVersao
{
    [TestClass]
    public class Mecanica_Carga_Catalogo
    {
        [TestMethod]
        public void MEC_Mongo_InjetaValoresTabelados()
        {

            string nomeCatalogo = "BdB1922";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "";
            string guidDisciplina = "ee720acb-5be3-4e5d-a1f3-51eafe5e6422";

            var command = new CarregaCatalogoCompletoMecanicaCommand(nomeCatalogo, idioma, pais, conexao, guidDisciplina);
            var handler = new CarregaCatalogoCompletoMecanicaCommandHandler();

            var result = handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Obter_PnPTables_VPN_SQLServer()
        {
            var collection = PnPTablesSQL.GetAllPnPTables();

            foreach (var item in collection)
            {
                string oBaseTable = item["BaseTable"] == null ? "" : item["BaseTable"].ToString();
                string oAbstract = item["Abstract"] == null ? "" : item["Abstract"].ToString();
                string oPhysicalName = item["PhysicalName"] == null ? "" : item["PhysicalName"].ToString();
                string oRevision = item["Revision"] == null ? "" : item["Revision"].ToString();
                string oSyncTimestamp = item["SyncTimestamp"] == null ? "" : item["SyncTimestamp"].ToString();

                if(oBaseTable == "Equipment")
                {

                }


            }

        }

        [TestMethod]
        public void CriarDisciplinas()
        {
            RepoDisciplinas repoDisciplinas = new RepoDisciplinas();

            var mecanica = new Disciplina("Mecânica");
            repoDisciplinas.Cadastrar(mecanica);
            var em = new Disciplina("Estruturas Metálicas");
            repoDisciplinas.Cadastrar(em);

        }

        [TestMethod]
        public void AcrecentarProjetoNoHub()
        {
            RepoHub repoHub = new RepoHub();
            string guidHub = "d8b011a0-54c4-4608-8e2d-eb2f249e4e8a";
            var hub = repoHub.ObterPorGuid(guidHub);
            string guidCliente = "89624309-b026-4c17-bab1-8c4f4d9cbc90";
            string nomeProjeto = "CBMM";
            string siglaProjeto = "BdB2009";
            string origem = "BIM360";
            Projeto projeto = new Projeto(guidCliente, nomeProjeto, siglaProjeto, origem);

            repoHub.AdicionarProjeto(projeto,hub);

        }

       


    }
}
