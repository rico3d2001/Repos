using Brass.Materiais.Dominio.Servico.CommandSide.Commands.CarregaCatalogoCompleto.Tubulacao;
using Brass.Materiais.Dominio.Servico.CommandSide.Commands.CarregaValoresTabelasDoArquivoCatalogo.Tubulacao;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.PQ.Dominio.Servico.Commands.Requests;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoSQLServerDapper.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.ComponentModel;
using System.Threading;

namespace Brass.Materiais.GestaoCatalogo.Service.TesteUnit
{
    [TestClass]
    public class TestesCatalogo
    {
        
      

        [TestMethod]
        public void A_Mongo_InjetaItemCompleto_SPE()
        {

           // var repoNiveisAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");

           // string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";
           // string guidIdiomaPTBR = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";
           // string guidDisicplina = "f8858d95-5eba-4d21-8606-4b813efa568b";

           // var niveisAtividade = repoNiveisAtividade
           //.Encontrar(Builders<NivelAtividade>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


           // Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

           // var xls = new MontagemXLS(guidDisicplina, guidClienteVALE, guidIdiomaPTBR, versao, 8, niveisAtividade);

           // var leituraArquivo = new LeituraArquivo<Atividade>(xls);

          

           // var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\CATALOG_SPE_MEC_TUB_EST.xlsx", "Atividade");













           // string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
           // string idioma = "Portugues";
           // string pais = "Brasil";
           // string conexao = "Local";
           // string guidDisciplina = "ee720acb-5be3-4e5d-a1f3-51eafe5e6422";





           // var command = new CarregaCatalogoCompletoTubulacaoCommand(endereco, idioma, pais, conexao, guidDisciplina);
           // var handler = new CarregaCatalogoCompletoTubulacaoCommandHandler();

           // var result = handler.Handle(command, CancellationToken.None);

            //Assert.IsNotNull(result);





        }



        [TestMethod]
        public void Mongo_InjetaValoresTabelados()
        {

        
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";
            string guidDisciplina = "909e5882-0b5e-414f-b37c-79514ac6f69f";
            var command = new CarregaValoresTabeladosTubulacaoCommand(endereco, idioma, pais, conexao, guidDisciplina);
            var handler = new CarregaValoresTabeladosTubulacaoCommandHandle();

            var result = handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
        }

        

        [TestMethod]
        public void B_Mongo_InjetaItemCompleto()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";
            string guidDisciplina = "909e5882-0b5e-414f-b37c-79514ac6f69f";
            //BackgroundWorker backgroundWorker = new BackgroundWorker();
            //var injetaPropriedade = new OrganizaCatalogoSQLiteMongoDB(endereco);
            //injetaPropriedade.Injetar();




            var command = new CarregaCatalogoCompletoTubulacaoCommand(endereco, idioma, pais, conexao, guidDisciplina);
            var handler = new CarregaCatalogoCompletoTubulacaoCommandHandler();

            var result = handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);





        }

        [TestMethod]
        public void Mongo_Injeta_CategoriaCatalogo()
        {
            var guidCatalogo = "532f43f4-59eb-4962-a4a9-edf7cee699a5";

            CriaCategorias criaCategorias = new CriaCategorias();
            criaCategorias.Injetar(guidCatalogo);

        }

        

        [TestMethod]
        public void Mongo_CriaNomesPropriedades()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var propriedades = criaArvoreCatalogo.ExtraiNomes();

        }


        [TestMethod]
        public void Mongo_ExtraiItensCategoria()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            criaArvoreCatalogo.ExtraiItensCategoria("532f43f4-59eb-4962-a4a9-edf7cee699a5", "9dcd21a8-43f0-4875-bf95-04255f7b2e68");
        }

        [TestMethod]
        public void Mongo_ExtraiTroncoArvoreCatalogo()
        {

            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var lista = criaArvoreCatalogo.ExtraiTroncoCatalogo();
            Assert.IsTrue(lista.Count > 0);
        }


        [TestMethod]
        public void Mongo_CriaFamilias()
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            criaArvoreCatalogo.CriaFamilias("532f43f4-59eb-4962-a4a9-edf7cee699a5");
        }

        [TestMethod]
        public void Mongo_ObtemRamalFamilias()
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var familias = criaArvoreCatalogo.ObtemRamalFamilias("1f13670d-499c-4a9d-bcbf-23707ec4761e");
        }

        

        [TestMethod]
        public void Mongo_ObtemClientes()
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var propriedades = criaArvoreCatalogo
                .ObtemPropriedades("bb75ebe3-c93f-4fb2-8713-05eba1f4e1f6");
            Assert.IsTrue(propriedades.Count == 189);
        }

        [TestMethod]
        public void Mongo_ObtemPropriedades()
        {
            CriaNomesPropriedades criaArvoreCatalogo = new CriaNomesPropriedades();
            var propriedades = criaArvoreCatalogo
                .ObtemPropriedades("bb75ebe3-c93f-4fb2-8713-05eba1f4e1f6");
            Assert.IsTrue(propriedades.Count == 189);
        }


        [TestMethod]
        public void Mongo_PegaTiposItens()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";//"name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            //var injetaPropriedade = new OrganizaCatalogoSQLiteMongoDB(endereco, idioma, pais, conexao);
            //injetaPropriedade.PegaTipos();
        }

        [TestMethod]
        public void InjetaItemCompleto_Local()
        {
            string endereco = @"C:\Trabalho\CatalogosAtuais\BRASS_ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Portugues";
            string pais = "Brasil";
            string conexao = "Local";//"name=DataBaseContext";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }
        /*
        [TestMethod]
        public void InjetaItemCompleto_Azure()
        {
            string endereco = @"C:\AutoCAD Plant 3D 2020 Content\CPak ASME\ASME Pipes and Fittings Catalog.pcat"; //ASME Pipes and Fittings Catalog.pcat//BRASS_ASME Pipes and Fittings Catalog.pcat";
            string idioma = "Inglês";
            string pais = "USA";
            string conexao = "name=CatalogoBRASSEntities";
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais, conexao);
            injetaPropriedade.Injetar();
        }
        */

        //Armazen
        //[TestMethod]
        //public void AlimentaArvoreEstoque()
        //{
        //    ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
        //    var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
        //    RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
        //    ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

        //    arvoreServiceEstoque.CarregaRamaisEstoque();


        //}

        //Armazen
        //[TestMethod]
        //public void DoEstoqueAlimentaArvoreEstoque()
        //{
        //    ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
        //    var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
        //    RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
        //    ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

        //    arvoreServiceEstoque.CarregaRamaisEstoque();


        //}

        //Armazen
        //[TestMethod]
        //public void RecuperaArvoreEstoque()
        //{
        //    ArvoresServiceAramazen arvoresServiceAramazen = new ArvoresServiceAramazen();
        //    var baseMDBRepositorio = new BaseMDBRepositorio<RamalEstoque>("Catalogo", "RamalEstoque");
        //    RamalEstoqueService ramalEstoqueService = new RamalEstoqueService(baseMDBRepositorio);
        //    ArvoreServiceEstoque arvoreServiceEstoque = new ArvoreServiceEstoque(arvoresServiceAramazen, ramalEstoqueService);

        //    var lista = arvoreServiceEstoque.ListaRamaisArvore();
        //}

        [TestMethod]
        public void AlimentaTabelaEstoque()
        {
            PropriedadesItemServiceSQL propriedadesItemService = new PropriedadesItemServiceSQL();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            int intervalo = 1;
            int ultimoPnPID = 0;
            string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";

            //itemEngenhariaEstoqueService.CarregaItensPorTipoItem(guidCatalogo, guidCategoria, guidTipoItem);

        }

        [TestMethod]
        public void AlimentaTodasTabelasEstoque()
        {
            PropriedadesItemServiceSQL propriedadesItemService = new PropriedadesItemServiceSQL();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            ItemEngenhariaServiceSQL itemEngenhariaService = new ItemEngenhariaServiceSQL();


            var catalogos = itemEngenhariaService.ObterCatalogos();

            foreach (var catalogo in catalogos)
            {
                var categorias = itemEngenhariaService.ObterCategorias(catalogo.GUID);

                foreach (var categoria in categorias)
                {
                    var tipos = itemEngenhariaService.ObterTiposItem(catalogo.GUID, categoria.GUID);

                    foreach (var tipo in tipos)
                    {
                        //itemEngenhariaEstoqueService.CarregaItensPorTipoItem(catalogo.GUID, categoria.GUID, tipo.GUID);
                    }
                }
            }


            //string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            //string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            //string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";




            

        }



        [TestMethod]
        public void RecuperaTabelaEstoque()
        {
            PropriedadesItemServiceSQL propriedadesItemService = new PropriedadesItemServiceSQL();

            ItemEngenhariaEstoqueService itemEngenhariaEstoqueService = new ItemEngenhariaEstoqueService(propriedadesItemService);

            int intervalo = 1;
            int ultimoPnPID = 0;
            string guidCatalogo = "9e4b51eb-5d1a-4fd6-8970-7545cc5f5ab8";
            string guidCategoria = "0551cde6-c249-43b0-83d4-161ac9178b35";
            string guidTipoItem = "0154689d-a6af-4504-a5c2-5552d2522f70";

           

            var lista = itemEngenhariaEstoqueService.ObtemItensTubulacaoPorTipoItem(guidTipoItem);

            Assert.IsTrue(lista.Count > 0);


        }

        

        //[TestMethod]
        //public void Corrigir()
        //{
        //    string endereco = @"C:\Trabalho\CatalogosPlant3d\BRASS_ASME Pipes and Fittings Catalog.pcat";
        //    string idioma = "Portugues";
        //    string pais = "Brasil";
        //    InjetaItemCompleto injetaPropriedade = new InjetaItemCompleto(endereco, idioma, pais);
        //    injetaPropriedade.Corrigir();
        //}
    }
}
