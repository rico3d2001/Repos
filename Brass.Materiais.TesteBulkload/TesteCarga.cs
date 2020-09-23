using Brass.ExcelLeitura.App.Comandos;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.Spec.Entities;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.TesteBulkload.Templates;
using Brass.Materiais.TesteBulkload.Templates.MontagensXLS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.TesteBulkload
{
    [TestClass]
    public class TesteCarga
    {
       



        [TestMethod]
        public void A_Carga_MaterialBase_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<MaterialBase>("Catalogo", "MaterialBase");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new MaterialBaseXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<MaterialBase>(tagueamentoXLS);


            var materiaisBase = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "Material-Base");

     
            foreach (var materialBase in materiaisBase)
            {
                repositorioEspecificacaoGeral.Inserir(materialBase);
            }



            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<MaterialBase>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);

        }


        [TestMethod]
        public void B_Carga_ClassePressao_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<ClassePressao>("Catalogo", "ClassePressao");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new ClassePressaoXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<ClassePressao>(tagueamentoXLS);


            var classesPressao = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "Classe de Pressao");

            foreach (var classePressao in classesPressao)
            {
                repositorioEspecificacaoGeral.Inserir(classePressao);
            }

            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<ClassePressao>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);

        }



        [TestMethod]
        public void C_Carga_CodigosFluidos_Assertivo()
        {
            var repositorioEspecificacaoGeral = new BaseMDBRepositorio<CodigoFluido>("Catalogo", "CodigoFluido");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var tagueamentoXLS = new CodigoFluidoXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<CodigoFluido>(tagueamentoXLS);


            var codigosFluido = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "FLUIDOS");

            foreach (var codigoFluido in codigosFluido)
            {
                repositorioEspecificacaoGeral.Inserir(codigoFluido);
            }

            var inseridos = repositorioEspecificacaoGeral
                .Encontrar(Builders<CodigoFluido>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);
        }

        
        [TestMethod]
        public void D_Carga_Descritivo_PTBR_Assertivo()
        {
            var repoEstruturaDescricao = new BaseMDBRepositorio<Descritivo>("Catalogo", "Descritivo");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";
            string guidIdioma = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var xls = new DescritivoBrassXLS(guidClienteVALE, versao, guidIdioma,"", 2);

            var leituraArquivo = new LeituraArquivo<Descritivo>(xls);

            var lista = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "DECRITIVOS - PTBR");

            foreach (var item in lista)
            {
                repoEstruturaDescricao.Inserir(item);
            }

            var inseridos = repoEstruturaDescricao
                .Encontrar(Builders<Descritivo>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE)
                            & Builders<Descritivo>.Filter.Eq(x => x.GUID_IDIOMA, guidIdioma));


            Assert.IsTrue(inseridos.Count > 0);


        }
        
        [TestMethod]
        public void E_Carga_DescritivoOutraLinguaXLS_Assertivo()
        {
            var repoEstruturaDescricao = new BaseMDBRepositorio<Descritivo>("Catalogo", "Descritivo");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";
            string guidIdiomaPTBR = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";
            string guidIdiomaENGUSA = "2c69c17k-fe23-4654-bade-6f7fc2eb2b5f";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var decritivosPTBR_VALE = repoEstruturaDescricao
                .Encontrar(Builders<Descritivo>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE)
                            & Builders<Descritivo>.Filter.Eq(x => x.GUID_IDIOMA, guidIdiomaPTBR));

           

           


            var xls = new DescritivoOutraLinguaXLS(guidClienteVALE, versao, guidIdiomaENGUSA, 2, decritivosPTBR_VALE);

            var leituraArquivo = new LeituraArquivo<Descritivo>(xls);

            var lista = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "DECRITIVOS - ENGUSA");

            foreach (var item in lista)
            {
                repoEstruturaDescricao.Inserir(item);
            }

            var inseridos = repoEstruturaDescricao
                .Encontrar(Builders<Descritivo>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE)
                            & Builders<Descritivo>.Filter.Eq(x => x.GUID_IDIOMA, guidIdiomaENGUSA));


            Assert.IsTrue(inseridos.Count > 0);


        }








        [TestMethod]
        public void I_Carga_EAPPlanejada_Assertivo()
        {
            var repoEAPsPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjeto = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var xls = new AreasPlanejadaXLS(2, guidProjeto, versao);

            var leituraArquivo = new LeituraArquivo<AreaPlanejada>(xls);

            string siglaProjeto = "BdB1901";


            var areas = leituraArquivo.Ler(@"C:\Trabalho\EAPs.xlsx", siglaProjeto);

            foreach (var area in areas)
            {
                repoEAPsPlanejadas.Inserir(area);
            }

            var inseridos = repoEAPsPlanejadas
                .Encontrar(Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjeto));


            Assert.IsTrue(inseridos.Count > 0);

        }

        [TestMethod]
        public void J_Carga_NiveisAtividade_Assertivo()
        {



            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var repoNivelAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            var nivelAtividade = new NivelAtividade(guidClienteVALE, versao,0,"K");
            repoNivelAtividade.Inserir(nivelAtividade);

            nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 1, "TT");
            repoNivelAtividade.Inserir(nivelAtividade);

            nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 2, "UU");
            repoNivelAtividade.Inserir(nivelAtividade);

            nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 3, "VVV");
            repoNivelAtividade.Inserir(nivelAtividade);

             nivelAtividade = new NivelAtividade(guidClienteVALE, versao, 4, "WWW");
            repoNivelAtividade.Inserir(nivelAtividade);

        }

        [TestMethod]
        public void K_Carga_MontagemXLS_Assertivo()
        {

            var repoAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            var repoNiveisAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";
            string guidIdiomaPTBR = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";
            string guidDisicplina = "f8858d95-5eba-4d21-8606-4b813efa568b";
            

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);



            var niveisAtividade = repoNiveisAtividade
                .Encontrar(Builders<NivelAtividade>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));

            var atividadesEstoque = repoAtividade.Obter();


            var xls = new MontagemXLS(guidDisicplina, guidClienteVALE, guidIdiomaPTBR, versao, 8, niveisAtividade);

            var leituraArquivo = new LeituraArquivo<Atividade>(xls);

            //var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\PE-F-641_Biblioteca_Atividades_Montagem_Mecanica_Rev_2.xlsx", "Mont e Desm. Eqtos e Mat Mec. ");

            var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\AtividadesAdiconais.xlsx", "Atividade");

            //var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\Atividades.xlsx", "Mont e Desm. Eqtos e Mat Mec. ");



            //foreach (var item in lista)
            //{

            //    repoAtividade.Inserir(item);
            //}

            var inseridos = repoAtividade
                .Encontrar(Builders<Atividade>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE)
                            & Builders<Atividade>.Filter.Eq(x => x.GUID_IDIOMA, guidIdiomaPTBR));


            Assert.IsTrue(inseridos.Count > 0);

            //var leituraArquivo = new LeituraArquivo<Descritivo>(xls);
        }



        [TestMethod]
        public void L_Carga_EstruturaDescricao_Assertivo()
        {
            var repoEstruturaDescricao = new BaseMDBRepositorio<EstruturaDescricao>("Catalogo", "EstruturaDescricao");

            string guidClienteVALE = "2a2000fd-b8a3-4619-8b78-2be372851cf9";

            Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);

            var xls = new EstruturaDescricaoXLS(guidClienteVALE, versao, 2);

            var leituraArquivo = new LeituraArquivo<EstruturaDescricao>(xls);

            var lista = leituraArquivo.Ler(@"C:\Trabalho\SPEC VALE.xlsx", "ESTRUT_DESCR_FLANGES");

            foreach (var item in lista)
            {
                repoEstruturaDescricao.Inserir(item);
            }

            var inseridos = repoEstruturaDescricao
                .Encontrar(Builders<EstruturaDescricao>.Filter.Eq(x => x.GUID_CLIENTE, guidClienteVALE));


            Assert.IsTrue(inseridos.Count > 0);


        }

        [TestMethod]
        public void M_LeituraDecricaoFamilia_Assertivo()
        {

            string guidIdiomaPTBR = "2c69c17b-fe23-4654-bade-6f7fc2eb2b5f";

            var valorSpecRepositorio= new BaseMDBRepositorio<ValorSPEC>("Catalogo", "ValorSPEC");


            var descritivoRepositorio = new BaseMDBRepositorio<Descritivo>("Catalogo", "Descritivo");

            var estruturaDescricaoRepositorio = new BaseMDBRepositorio<EstruturaDescricao>("Catalogo", "EstruturaDescricao");

            //Provisorio tem que filtrar depois pela Realçao com Categoria
            var estruturas = estruturaDescricaoRepositorio.Obter();

            var guidItem = "bb75ebe3-c93f-4fb2-8713-05eba1f4e1f6";

            var nomeTipoPropriedadeRepositorio = new BaseMDBRepositorio<NomeTipoPropriedade>("Catalogo", "NomeTipoPropriedade");

            var partSizeLongDesc = nomeTipoPropriedadeRepositorio
               .Encontrar(Builders<NomeTipoPropriedade>
               .Filter.Eq(x => x.NOME, "PartSizeLongDesc")).First();


            var repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

            var item = repositorioItemPipe.Obter(guidItem);

            //
            var repoRelacaoPropriedadeItem = new BaseMDBRepositorio<RelacaoPropriedadeItem>("Catalogo", "RelacaoPropriedadeItem");

            var repoPropriedadeItem = new BaseMDBRepositorio<PropriedadeItem>("Catalogo", "PropriedadeItem");

            var repoValores = new BaseMDBRepositorio<ValorTabelado>("Catalogo", "ValorTabelado");

            var relacoesPropriedadeItem = repoRelacaoPropriedadeItem
                 .Encontrar(Builders<RelacaoPropriedadeItem>.Filter.Eq(x => x.GUID_ITEM_ENG, item.GUID));

            List<string> textos = new List<string>();

            foreach (var relacao in relacoesPropriedadeItem)
            {
                //relacao.GUID_PROPRIEDADE
                var propriedadesItem = repoPropriedadeItem
                    .Encontrar(Builders<PropriedadeItem>.Filter.Eq(x => x.GUID, relacao.GUID_PROPRIEDADE)
                               & Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, partSizeLongDesc.GUID));

                if (propriedadesItem.Count() == 1)
                {
                    var propriedade = propriedadesItem.First();


                    var valor = repoValores.Obter(propriedade.GUID_VALOR);

                    textos = valor.VALOR.Split(',').ToList();

                    break;
                }


            }

           
            if(textos.Count() > 0)
            {
                for (int i = 0; i < estruturas.Count(); i++)
                {
                    foreach (var relacao in relacoesPropriedadeItem)
                    {
                        //relacao.GUID_PROPRIEDADE
                        var propriedadesItem = repoPropriedadeItem
                            .Encontrar(Builders<PropriedadeItem>.Filter.Eq(x => x.GUID, relacao.GUID_PROPRIEDADE)
                                       & Builders<PropriedadeItem>.Filter.Eq(x => x.GUID_TIPO, estruturas[i].GUID_NOME_PROPRIEDADE));
                    
                        if (propriedadesItem.Count() == 1)
                        {
                            var propriedade = propriedadesItem.First();

                            var valor = repoValores.Obter(propriedade.GUID_VALOR);



                            if(valor.VALOR == textos[i].Trim())
                            {
                                var texto = textos[i].Trim();

                                //teste
                                var textoDivivido = textos[i].Split(' ');

                                var txt = textoDivivido[1].Trim();

                                //var todosDescritivos = descritivoRepositorio.Obter();

                                //

                                var descrivosEncontrados = descritivoRepositorio.Encontrar(
                                    Builders<Descritivo>.Filter.Eq(x => x.SiglaPTBR, txt)
                                    & Builders<Descritivo>.Filter.Eq(x => x.GUID_IDIOMA, guidIdiomaPTBR));


                                //

                                if(descrivosEncontrados.Count() == 1)
                                {
                                    valorSpecRepositorio.Inserir(
                                   new ValorSPEC(valor.GUID, 
                                   descrivosEncontrados.First().GUID,
                                   valor.VALOR, texto)
                                   );
                                }

                               

                                
                            }
                            else
                            {
                                var textoDivivido = textos[i].Split(' ');

                                var descrivosEncontados = descritivoRepositorio.Encontrar(
                                    Builders<Descritivo>.Filter.Eq(x => x.Sigla, textoDivivido[1].Trim()));

                                if(descrivosEncontados.Count() == 1)
                                {
                                    var descritivoEncontrado = descrivosEncontados.First();
                                }

                               

                            }
                        }

                     }
                }

            }
        }

        [TestMethod]
        public void N_Relacao_TipoItemEng_AtividadeVVV()
        {
            var tipoItemDiag = "TUBO";
            var repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
            var repositorioTipoItemEng = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");

            var atividades = repositorioAtividade.Obter();

            var atividades_K = atividades.Where(x => x.Codigo == "M").ToList();

            var atividades_TT = atividades_K.Where(x => x.Codigo == "60").ToList();

            var atividades_UU = atividades_TT.Where(x => x.NivelAtividade == "TT" && x.Codigo == "60").ToList();



            var atividades_VVV = atividades.Where(x => x.NivelAtividade == "VVV").ToList();

            var atividade = atividades_VVV.FirstOrDefault(x => x.Codigo == "010");

            var tipos = repositorioTipoItemEng.Encontrar(Builders<TipoItemEng>.Filter.Eq(x => x.NOME, tipoItemDiag));

            var tipo = tipos.First();

            tipo.AtividadeVVV = atividade;

        }




        [TestMethod]
        public void O_ItemizaAtividades()
        {
           

            var repositorioNivelAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");
            var repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");
           

            var atividades = repositorioAtividade.Obter();
            var niveis = repositorioNivelAtividade.Obter();

            

            


            

            //ItemizaAtividades.Itemizar("1", "MONTAGEM DE EQUIPAMENTOS E COMPONENTES ELETROMECÂNICOS", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1", "MONTAGEM DE TUBULAÇÕES, CONEXÕES E ACESSÓRIOS", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.1", "MONTAGEM DE TUBULAÇÕES", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.1.1", "MONTAGEM DE TUBO, CC, AC", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.2", "MONTAGEM DE VÁLVULAS", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.2.1", "MONTAGEM DE VÁLVULAS BORBOLETA", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.2.2", "MONTAGEM DE VÁLVULA GAVETA", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.2.3", "MONTAGEM DE VÁLVULA GAVETA", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.2.4", "MONTAGEM DE VÁLVULA DE RETENÇÃO", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.5", "MONTAGEM DE ESTRUTURAS METÁLICAS", atividades, niveis, null);
            //ItemizaAtividades.Itemizar("1.1.5.1", "MONTAGEM DE SUPORTE DE TUBULAÇÃO", atividades, niveis, null);
        }

        [TestMethod]
        public void P_DefinirAtividades()
        {

            //var tipoItemDiag = "TUBO";
            //var codigo = "M"; //Codigo para montagem


            //var repositorioTipoItemEng = new BaseMDBRepositorio<TipoItemEng>("Catalogo", "TipoItemEng");
            var repositorioNivelAtividade = new BaseMDBRepositorio<NivelAtividade>("MontagemPQ", "NivelAtividade");
            var repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");

            var atividades = repositorioAtividade.Obter();

            var niveis = repositorioNivelAtividade.Obter();


            //var tipos = repositorioTipoItemEng.Encontrar(Builders<TipoItemEng>.Filter.Eq(x => x.NOME, tipoItemDiag));

     
            var leituraArquivo = new LeituraArquivo<Atividade>(new OrganizaAtividadesXLS(8, niveis, atividades));

            var lista = leituraArquivo.Ler(@"C:\Trabalho\LeituraPlan\Atividades.xlsx", "Mont e Desm. Eqtos e Mat Mec. ");

            foreach (var atividade in lista)
            {
                var atividadeExistente = atividades.FirstOrDefault(x => x.GUID == atividade.GUID);
                if (atividadeExistente == null)
                {
                    repositorioAtividade.Inserir(atividade);
                }
                else
                {
                    repositorioAtividade.Atualizar(atividadeExistente);
                }
            }





        }








    }
}
