using Brass.Materiais.AppBulkLoad.Models;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.InterfaceExcel.Comandos;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Brass.Materiais.UTCargaAtlas
{

    [TestClass]
    public class UTCargasAtividades
    {
        //public void Carga_de_Niveis()
        //{
        //    Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

        //    var repoNivelAtividade = new RepoNivelAtividade("local");

        //    string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

        //    var nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 0, "K");
        //    repoNivelAtividade.Cadastar(nivelAtividade);

        //    nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 1, "TT");
        //    repoNivelAtividade.Cadastar(nivelAtividade);

        //    nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 2, "UU");
        //    repoNivelAtividade.Cadastar(nivelAtividade);

        //    nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 3, "VVV");
        //    repoNivelAtividade.Cadastar(nivelAtividade);

        //    nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 4, "WWW");
        //    repoNivelAtividade.Cadastar(nivelAtividade);
        //}


        [TestMethod]
        public void Carga_de_Atividades_Atraves_de_BulkLoad()
        {

            string connectionString = "local";

            var repoAtividade = new RepoAtividade(connectionString);
            var repoNiveisAtividade = new RepoNivelAtividade(connectionString);
            var repoCliente = new RepoClientes(connectionString);
        

            string guidClienteVALE = "8e346a61-2623-448b-b4bd-62232b9f55da";
            string guidIdiomaPTBR = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";
            string guidDisicplina = "f8858d95-5eba-4d21-8606-4b813efa568b";


            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);


            var cliente = repoCliente.ObterDoGuid(guidClienteVALE); 
            var niveisAtividade = repoNiveisAtividade.ObterListaDoCliente(cliente);
                
           


            IdentidadeAtividade identidadeAtividade = new IdentidadeAtividade(guidClienteVALE, guidDisicplina, guidIdiomaPTBR);

            var xls = new AtividadeBulkLoad(identidadeAtividade, versao, niveisAtividade, connectionString, 8);

            var leituraArquivo = new LeituraArquivo<Atividade>(xls);

            //var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\AtividadesAdiconais.xlsx", "Atividade");
            //PE-F-639_Bibliot_Fornec_Equip_Materiais_Mecanicos_Rev_2
            var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\PE-F-639_Bibliot_Fornec_Equip_Materiais_Mecanicos_Rev_2.xlsx", "Fornecim. Eqtos e Mat Mecan. ");

            var inseridos = repoAtividade.ObterListaPorIdentidade(identidadeAtividade);
                
            Assert.IsTrue(inseridos.Count > 0);

        }


        [TestMethod]
        public void CorrigirAtividade()
        {
            string connectionString = "local";
            RepoSPE repoSPE = new RepoSPE(connectionString);
            RepoAtividade repoAtividade = new RepoAtividade(connectionString);

            var atividades = repoAtividade.ObterTodas();

            foreach (var atividade in atividades)
            {
                if(atividade.NivelAtividade == "WWW")
                {
                    var atividadeVVV = repoAtividade.ObterPorGuid(atividade.GUID_PAI);
                    var atividadeUU = repoAtividade.ObterPorGuid(atividadeVVV.GUID_PAI);
                    var atividadeTT = repoAtividade.ObterPorGuid(atividadeUU.GUID_PAI);
                    var atividadeK = repoAtividade.ObterPorGuid(atividadeTT.GUID_PAI);

                    var spe = repoSPE.ObterPorNiveisAteVVV(atividadeK.Codigo, atividadeTT.Codigo, atividadeUU.Codigo, atividadeVVV.Codigo);

                    if (spe != null)
                    {
                        atividade.Unidade = spe.Unidade;
                        repoAtividade.Modificar(atividade);
                    }
                }

                


            }
        }

    }
}
