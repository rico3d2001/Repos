using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.Nucleo.Entities;
using Brass.Materiais.Plant3dDiagramas.RepoSQLServerDapper.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.AppBIM.Testes
{
    [TestClass]
    public class Carga_AppBIMTestes
    {
        [TestMethod]
        public void A_Carga_Disiciplina_Assertivo()
        {



            var repoDisciplina = new BaseMDBRepositorio<Disciplina>("BIM", "Disciplinas");

            Disciplina pipe = new Disciplina("Tubulação");
            repoDisciplina.Inserir(pipe);

            Disciplina mecanica = new Disciplina("Mecanica");
            repoDisciplina.Inserir(mecanica);



        }

        [TestMethod]
        public void B_Carga_Cliente_Assertivo()
        {

            var repoDisciplina = new BaseMDBRepositorio<Cliente>("BIM", "Clientes");

            var nexa = new Cliente("NEXA", "Nexa");
            repoDisciplina.Inserir(nexa);

            var vale = new Cliente("VALE", "Vale");
            repoDisciplina.Inserir(vale);

        }


        [TestMethod]
        public void C_Carga_Projetos_Assertivo()
        {
            var repoProjeto = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");

            var lista = repoProjeto.Obter();

            var listaRealacional = ProjetosSQL.GetProjetos();



            foreach (var item in listaRealacional)
            {
                var databaseNome = item["name"].ToString();
                if (databaseNome.Contains("_bdb"))
                {

                    if (nomeAdequadoParaDataBase(databaseNome))
                    {
                        var sigla = "BdB" + databaseNome.Substring(1).Split('_')[0].Substring(3);

                        var existente = lista.FirstOrDefault(x => x.Sigla == sigla);
                        if (existente == null)
                        {
                            var nomeProjeto = ProjetosSQL.GetTabelaProjeto(databaseNome).First()["Project_Description"].ToString();
                            var projeto = new Projeto("", nomeProjeto, sigla,"VPN");
                            repoProjeto.Inserir(projeto);
                            lista.Add(new Projeto("", nomeProjeto, sigla,"VPN"));
                        }
                    }




                }
            }

            //var testeR = listaRealacional.Where(x => x.Values.Contains("bdb"));

            //var tesew = testeR["name"].ToString();

            //O:\Ativos\BdB1901_VALE_Guarda Chuva\BdB190101_VALE_DET_CAVA_TBO\3D\PLANT3D\BdB190101_REC0

            // Versao versao = new Versao(0, "SPE Vale - EG-T-401 Rev.11", "Inicio do banco de dados", DateTime.Now);



            //var tipo = TipoProjeto.VPN_TRIDIMENSIONAL;
            //Projeto projetoBdB1922 = new Projeto("48e9eb46-5a26-4b9c-9a53-163d448336fb", "NEXA_BONSUCESSO", "BdB1922");
            //Projeto projetoBdB1901 = new Projeto("a050dc55-009d-4f19-b867-4bdbe0ee3523", "VALE_DET_CAVA_TBO", "BdB1901", TipoProjeto.VPN_TRIDIMENSIONAL);

            //projetoBdB1922.GUID_EAP = "1cf31723-7a8f-487a-8087-b87bb3f62c00";
            //projetoBdB1922.PastaPlant3d = @"O:\Ativos\BdB1901_VALE_Guarda Chuva\BdB190101_VALE_DET_CAVA_TBO\3D\PLANT3D\BdB190101_REC0";

            //repoProjeto.Inserir(projetoBdB1922);


            //Projeto projetoBdB1922 = new Projeto("BdB1922", "");
            //repoProjeto.Inserir(projetoBdB1922);


        }

        private bool nomeAdequadoParaDataBase(string databaseNome)
        {
            var comprimento = databaseNome.Split('_').Length;

           if (comprimento != 3)
            {
                return false;
            }

            var siglaPnPid = databaseNome.Split('_').Last();
            bool teste1 = siglaPnPid == "PnId" ? true : false;

            if (!teste1)
            {
                return false;
            }

            var meio = databaseNome.Substring(1).Split('_')[0].Substring(3);

            bool teste2 = !(meio.Contains('.'));

            return (teste1 && teste2);
        }

        [TestMethod]
        public void D_Carga_EAP_NEXA_Tubulacao_Assertivo()
        {

            var conexao = "Plant3d_Diagramas"; // "Plant3d_Model3D"; //
            var caminho = new List<string>();
            EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));

            string siglaProjeto = "BdB1922";

            string nomeProjeto = "NEXA_BONSUCESSO";

            //var database = "_bdb1922_PnId";
            var tipo = "Processo";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacao");

            var pnPDrawings = GetPnPDrawings.GetItens(siglaProjeto, tipo);

            //using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao, siglaProjeto))
            //{
            //var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);

            Area novaArea = null;
            //var paths = pnPDrawings.First().Path.Split('\\');
            eap = new EAP(siglaProjeto, nomeProjeto);

            foreach (var pnPDrawing in pnPDrawings)
            {
                var paths = pnPDrawing["Path"].ToString().Split('\\'); //pnPDrawing.Path.Split('\\');

                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    if (areaPlanejada != null)
                    {
                        novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                        if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                        {
                            var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                            areaSuperior.AdicionaArea(novaArea);
                        }
                        else
                        {
                            eap.AdicionaArea(novaArea);
                        }


                    }

                }
                else
                {
                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    //var areaPlanejada = areasPlanejadasProjeto
                    //.FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    //if (areaPlanejada != null)
                    //{




                    if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                    {
                        var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);

                        novaArea = new Area(paths.Last(), "Processo", areaSuperior.NumeroArea, areaSuperior.NumeroSubArea, areaSuperior.NomeArea);

                        areaSuperior.AdicionaArea(novaArea);
                    }



                    //}
                }


                listaAreas.Add(novaArea);







            }



            //}



            repoEAP.Inserir(eap);



            //Projeto disciplina = new Projeto("Tubulação");

            //repoDisciplina.Inserir(disciplina);
        }

        [TestMethod]
        public void E_VALE_DET_CAVA_TBO_Carga_EAPTubulacao_Assertivo()
        {

            var conexao = "Plant3d_Diagramas";
            var caminho = new List<string>();
            EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjetoValeTombopeba = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoValeTombopeba));

            var siglaProjeto = "BdB190101";
            string nomeProjeto = "VALE_DET_CAVA_TBO";
            var tipo = "Processo";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacao");

            //using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao, siglaProjeto))
            //{
            //var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);
            var pnPDrawings = GetPnPDrawings.GetItens(siglaProjeto, tipo);


            Area novaArea = null;
            //var paths = pnPDrawings.First().Path.Split('\\');
            eap = new EAP(siglaProjeto, nomeProjeto);

            foreach (var pnPDrawing in pnPDrawings)
            {
                //var paths = pnPDrawing.Path.Split('\\');
                var paths = pnPDrawing["Path"].ToString().Split('\\');


                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    if (areaPlanejada != null)
                    {
                        novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                        if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                        {
                            var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                            areaSuperior.AdicionaArea(novaArea);
                        }
                        else
                        {
                            eap.AdicionaArea(novaArea);
                        }


                    }

                }
                else
                {
                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    //var areaPlanejada = areasPlanejadasProjeto
                    //.FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    //if (areaPlanejada != null)
                    //{




                    if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                    {
                        var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);

                        novaArea = new Area(paths.Last(), "Processo", areaSuperior.NumeroArea, areaSuperior.NumeroSubArea, areaSuperior.NomeArea);

                        areaSuperior.AdicionaArea(novaArea);
                    }



                    //}
                }


                listaAreas.Add(novaArea);







            }



            //}



            repoEAP.Inserir(eap);



            //Projeto disciplina = new Projeto("Tubulação");

            //repoDisciplina.Inserir(disciplina);
        }

        [TestMethod]
        public void F_Carga_EAP_NEXA_Model_plant3d_Assertivo()
        {

            //var conexao = "Plant3d_Diagramas"; // "Plant3d_Model3D"; //
            var caminho = new List<string>();
            EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));

            string siglaProjeto = "BdB1922";
            string nomeProjeto = "NEXA_BONSUCESSO";

            //var database = "_bdb1922_PnId";
            var tipo = "Volumetrica";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacaoModel");

            var pnPDrawings = GetPnPDrawings.GetItens(siglaProjeto, tipo);

            //using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao, siglaProjeto))
            //{
            //var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);

            Area novaArea = null;
            //var paths = pnPDrawings.First().Path.Split('\\');
            eap = new EAP(siglaProjeto, nomeProjeto);

            foreach (var pnPDrawing in pnPDrawings)
            {
                var paths = pnPDrawing["Path"].ToString().Split('\\'); //pnPDrawing.Path.Split('\\');

                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    if (areaPlanejada != null)
                    {
                        novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                        if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                        {
                            var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                            areaSuperior.AdicionaArea(novaArea);
                        }
                        else
                        {
                            eap.AdicionaArea(novaArea);
                        }


                    }

                }
                else
                {
                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    //var areaPlanejada = areasPlanejadasProjeto
                    //.FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    //if (areaPlanejada != null)
                    //{




                    if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                    {
                        var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);

                        novaArea = new Area(paths.Last(), "Processo", areaSuperior.NumeroArea, areaSuperior.NumeroSubArea, areaSuperior.NomeArea);

                        areaSuperior.AdicionaArea(novaArea);
                    }



                    //}
                }


                listaAreas.Add(novaArea);







            }



            //}



            repoEAP.Inserir(eap);



            //Projeto disciplina = new Projeto("Tubulação");

            //repoDisciplina.Inserir(disciplina);
        }


        [TestMethod]
        public void G_VALE_DET_CAVA_TBO_Carga_EAP_Model_Assertivo()
        {

            var conexao = "Plant3d_Diagramas";
            var caminho = new List<string>();
            EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjetoValeTombopeba = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoValeTombopeba));

            var siglaProjeto = "BdB190101";
            string nomeProjeto = "VALE_DET_CAVA_TBO";
            var tipo = "Volumetrica";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacaoModel");

            //using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao, siglaProjeto))
            //{
            //var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);
            var pnPDrawings = GetPnPDrawings.GetItens(siglaProjeto, tipo);


            Area novaArea = null;
            //var paths = pnPDrawings.First().Path.Split('\\');
            eap = new EAP(siglaProjeto, nomeProjeto);

            foreach (var pnPDrawing in pnPDrawings)
            {
                //var paths = pnPDrawing.Path.Split('\\');
                var paths = pnPDrawing["Path"].ToString().Split('\\');


                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    if (areaPlanejada != null)
                    {
                        novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                        if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                        {
                            var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                            areaSuperior.AdicionaArea(novaArea);
                        }
                        else
                        {
                            eap.AdicionaArea(novaArea);
                        }


                    }

                }
                else
                {
                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    //var areaPlanejada = areasPlanejadasProjeto
                    //.FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    //if (areaPlanejada != null)
                    //{




                    if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                    {
                        var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);

                        novaArea = new Area(paths.Last(), "Processo", areaSuperior.NumeroArea, areaSuperior.NumeroSubArea, areaSuperior.NomeArea);

                        areaSuperior.AdicionaArea(novaArea);
                    }



                    //}
                }


                listaAreas.Add(novaArea);







            }



            //}



            repoEAP.Inserir(eap);



            //Projeto disciplina = new Projeto("Tubulação");

            //repoDisciplina.Inserir(disciplina);
        }


        [TestMethod]
        public void H_Carga_EAP_Geral_Assertivo()
        {

            var conexao = "Plant3d_Diagramas"; // "Plant3d_Model3D"; //
            var caminho = new List<string>();
            EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            var repoDWGs = new BaseMDBRepositorio<ItemTag>("BIM", "DWGs");

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            //string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";
            string guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoVale));

            //string siglaProjetoNexa = "BdB1922";
            string siglaProjetoVale = "BdB190101";

            string nomeProjetoVale = "VALE_DET_CAVA_TBO";

            //var database = "_bdb1922_PnId";
            var tipoProcesso = "Processo";
            //var tipoVolumetrica = "Volumetrica";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPGeral");

            var pnPDrawingsProcesso = GetPnPDrawings.GetItens(siglaProjetoVale, tipoProcesso);



            Area novaArea = null;

            eap = new EAP(guidProjetoVale, nomeProjetoVale);

            foreach (var pnPDrawing in pnPDrawingsProcesso)
            {
                var paths = pnPDrawing["Path"].ToString().Split('\\'); //pnPDrawing.Path.Split('\\');

                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    if (areaPlanejada != null)
                    {
                        novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                        if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                        {
                            var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                            areaSuperior.AdicionaArea(novaArea);
                        }
                        else
                        {
                            eap.AdicionaArea(novaArea);
                        }

                        listaAreas.Add(novaArea);
                    }

                }
                else if (paths.Last().Split('.').Last() == "dwg")
                {
                    bool contemStr = false;
                    foreach (var a in areasPlanejadasProjeto)
                    {
                        var end = pnPDrawing["Path"].ToString();
                        var teste = a.Area + a.SubArea;

                        contemStr = end.Contains(teste);
                        if (contemStr)
                        {
                            var pathsReverse = paths.Reverse();

                            foreach (var item in pathsReverse)
                            {
                                var areaSubArea = item.Split('-').First().Trim();
                                var localizado = areasPlanejadasProjeto.FirstOrDefault(x => x.Area + x.SubArea == areaSubArea);
                                if (localizado != null)
                                {
                                    //var inseredwg = new DwgFile(
                                    //    guidProjetoVale,
                                    //    areaSubArea.Substring(0, 2),
                                    //    areaSubArea.Substring(2, 2),
                                    //    areaSubArea.Substring(4, 2),
                                    //    tipoProcesso,
                                    //    pnPDrawing["Path"].ToString().Split('\\').Last(),
                                    //    pnPDrawing["Path"].ToString(),
                                    //    localizado.GUID,
                                    //    OrigemDWG.DP3D);
                                    //repoDWGs.Inserir(inseredwg);
                                    break;
                                }
                            }

                            break;
                        }
                    }




                }

            }

            repoEAP.Inserir(eap);

        }


        [TestMethod]
        public void I_Carga_Model_Dwgs__Assertivo()
        {

            //var conexao = "Plant3d_Model3D"; // "Plant3d_Model3D"; //
            var caminho = new List<string>();
            //EAP eap = null;
            //var dwgs = new List<DwgFile>();
            var listaAreas = new List<Area>();

            var repoDWGs = new BaseMDBRepositorio<ItemTag>("BIM", "DWGs");



            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";
            //string guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            //repoDWGs.Encontrar(Builders<DwgFile>
            //    .Filter.Eq(x => x.GuidProjeto, guidProjetoNexa));

            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));

            string siglaProjetoNexa = "BdB1922";
            //string siglaProjetoVale = "BdB190101";

            //var database = "_bdb1922_PnId";

            var tipoVolumetrica = "Volumetrica";

            var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPGeral");
            var eapExistenteDiagrama = repoEAP.Encontrar(
                   Builders<EAP>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa)).First();
            //var listaAreasEAPExistente = eapExistenteDiagrama.First().Areas;

            var pnPDrawingsVolumetrica = GetPnPDrawings.GetItens(siglaProjetoNexa, tipoVolumetrica);



            Area novaArea = null;

            //EAP eap = repoEAP.

            foreach (var pnPDrawing in pnPDrawingsVolumetrica)
            {
                var paths = pnPDrawing["Path"].ToString().Split('\\'); //pnPDrawing.Path.Split('\\');

                //var nome = paths.Last().ToString().Split('-')[1].Trim();
                var numero = paths.Last().ToString().Split('-')[0].Trim();
                int result = 0;

                if (numero.Length == 4 && int.TryParse(numero, out result))
                {
                    var numeroArea = numero.Substring(0, 2);
                    var numeroSubArea = numero.Substring(2, 2);

                    var areaExistente = eapExistenteDiagrama.Areas
                        .Find(x => x.NumeroArea == numeroArea && x.NumeroSubArea == numeroSubArea);

                    if (areaExistente == null)
                    {
                        var nomePastaSuperior = paths.Reverse().ElementAt(1);

                        var areaPlanejada = areasPlanejadasProjeto
                            .FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                        if (areaPlanejada != null)
                        {
                            novaArea = new Area(paths.Last(), "Processo", numeroArea, numeroSubArea, "");



                            if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                            {
                                var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                                areaSuperior.AdicionaArea(novaArea);
                            }
                            else
                            {
                                eapExistenteDiagrama.AdicionaArea(novaArea);
                                //eap.AdicionaArea(novaArea);
                            }

                            listaAreas.Add(novaArea);
                        }
                    }


                }
                else if (paths.Last().Split('.').Last() == "dwg")
                {
                    bool contemStr = false;
                    foreach (var a in areasPlanejadasProjeto)
                    {
                        var end = pnPDrawing["Path"].ToString();
                        var teste = a.Area + a.SubArea;

                        contemStr = end.Contains(teste);
                        if (contemStr)
                        {
                            var pathsReverse = paths.Reverse();

                            foreach (var item in pathsReverse)
                            {
                                var areaSubArea = item.Split('-').First().Trim();
                                var localizado = areasPlanejadasProjeto.FirstOrDefault(x => x.Area + x.SubArea == areaSubArea);
                                if (localizado != null)
                                {
                                    //var inseredwg = new DwgFile(
                                    //   guidProjetoNexa,
                                    //   areaSubArea.Substring(0, 2),
                                    //   areaSubArea.Substring(2, 2),
                                    //   areaSubArea.Substring(4, 2),
                                    //   tipoVolumetrica,
                                    //    pnPDrawing["Path"].ToString().Split('\\').Last(),
                                    //   pnPDrawing["Path"].ToString(),
                                    //   "",
                                    //   OrigemDWG.MP3D);
                                    //repoDWGs.Inserir(inseredwg);
                                    break;
                                }
                            }

                            break;
                        }
                    }




                }

            }

            //repoEAP.Inserir(eap);

        }



        [TestMethod]
        public void J_Carga_ItemPQPlant3d_Diagramas_Assertivo()
        {
            //var databaseVale = "_bdb190101_PnId";
            //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var databaseNexa = "_bdb1922_PnId";
            var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";





            var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemDiagramasPlant3d");



            List<AreaTag> areasDesenhosDiagrama = new List<AreaTag>();

            var repoAreasDesenhos = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasDiagrama");



            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));



            var collection = LinhasPipeSQL.GetItens(databaseNexa);

            AreaTag areaDesenhoDiagrama = null;

            foreach (var item in collection)
            {

                string path = item["Path"] == null ? "" : item["Path"].ToString();
                string area = item["Area"] == null ? "" : item["Area"].ToString();
                string tag = item["Tag"] == null ? "" : item["Tag"].ToString();

                string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();
                string specPart = item["Spec Part"] == null ? "" : item["Spec Part"].ToString();

                var tagSeperado = tag.Split('-');

                foreach (var parteTitulo in tagSeperado)
                {
                    var areaSubArea = parteTitulo.Trim();



                    if (areaSubArea.Length == 6)
                    {

                        var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == areaSubArea.Substring(0, 2)
                        && x.SubArea == areaSubArea.Substring(2, 2));

                        if (areaPlanejada != null)
                        {


                            areaDesenhoDiagrama = AreaTag.Criar(areaPlanejada, tag);




                            areasDesenhosDiagrama.Add(areaDesenhoDiagrama);

                            break;
                        }


                    }
                    else if (areaSubArea.Length == 4)
                    {
                        var areaPlanejada = areasPlanejadasProjeto
                        .FirstOrDefault(x => x.Area == areaSubArea.Substring(0, 2)
                        && x.SubArea == areaSubArea.Substring(2, 2));

                        if (areaPlanejada != null)
                        {



                            areaDesenhoDiagrama = AreaTag.Criar(areaPlanejada, tag);



                            areasDesenhosDiagrama.Add(areaDesenhoDiagrama);


                            break;
                        }

                    }



                }



                //ItemTag itemTag = new ItemTag(guidProjetoNexa, areaDesenhoDiagrama, "Diagrama", tag, "");

                //var itemPipe = new ItemPQ(guidProjetoNexa, "RRP", itemTag, pnPID, specPart, null);


                //repositorioItemPipePlant3d.Inserir(itemPipe);




            }


        }














        //[TestMethod]
        //public void K_Carga_ItemPlant3d_Assertivo()
        //{

        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemDiagramaPlant3d>("BIM", "ItensPlant3d");

        //    //var database = "_bdb190101_PnId";
        //    //var guidProjeto = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

        //    var database = "_bdb1922_PnId";
        //    var guidProjeto = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var collection = LinhasPipe.GetItens(database);

        //    foreach (var item in collection)
        //    {

        //        var listaValores = item.Values.ToList();

        //        var itemPipe = new ItemDiagramaPlant3d(
        //               guidProjeto,
        //               listaValores.ElementAt(0).ToString(),
        //               listaValores.ElementAt(1).ToString(),
        //               listaValores.ElementAt(2).ToString(),
        //               listaValores.ElementAt(3).ToString(),
        //               listaValores.ElementAt(4).ToString());

        //        repositorioItemPipePlant3d.Inserir(itemPipe);

        //    }

        //}

        //[TestMethod]
        //public void L_Carga_ItemModelado_Plant3d_Assertivo()
        //{

        //    var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM", "ItensModelados");

        //    var databaseVale = "_bdb190101_Piping";
        //    var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

        //    //var databaseNexa = "_bdb1922_Piping";
        //    //var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var collection = ModelEngineeringItems.GetItens(databaseVale);

        //    foreach (var item in collection)
        //    {



        //        ItemModelado itemModel = null;


        //        string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();
        //        string descricaoLonga = item["PartFamilyLongDesc"] == null ? "" : item["PartFamilyLongDesc"].ToString();
        //        string descricaoLongaDimensionada = item["PartSizeLongDesc"] == null ? "" : item["PartSizeLongDesc"].ToString();

        //        var tipoItem = descricaoLongaDimensionada
        //            .Split('-').First()
        //            .Split(',').First()
        //            .Split(' ').First()
        //            .Trim();

        //        bool topic = false; ;

        //        switch (tipoItem)
        //        {
        //            case "Nozzle":
        //                topic = true;
        //                break;
        //            case "TANQUE":
        //                topic = true;
        //                break;
        //            case "TUBO":
        //                topic = true;
        //                break;
        //            default:
        //                topic = false;
        //                break;
        //        }

        //        if (topic)
        //        {
        //            if (tipoItem != "Nozzle")
        //            {
        //                if (tipoItem == "TUBO")
        //                {


        //                    var view = Totais.GetView(databaseVale, "Pipe");

        //                    var tubo = view.FirstOrDefault(x => x["pnPID"].ToString() == pnPID);

        //                    if (tubo != null)
        //                    {
        //                        double comprimento = tubo["Length"] == null ? 0.0 : double.Parse(tubo["Length"].ToString());

        //                        QtdLinear qtdLinear = new QtdLinear(comprimento);


        //                        itemModel = new ItemModelado(guidProjetoVale, pnPID, descricaoLonga, descricaoLongaDimensionada);

        //                    }




        //                }

        //            }

        //        }

        //        //var itemModel = new ItemModelado(guidProjetoVale, pnPID, descricaoLonga, descricaoLongaDimensionada);



        //        //repositorioItemModelado.Inserir(itemModel);

        //    }

        //}

        //[TestMethod]
        //public void L_Carga_ItemModelado_Plant3d_Assertivo()
        //{

        //    var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM", "ItensModelados");

        //    var databaseVale = "_bdb190101_Piping";
        //    var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

        //    //var databaseNexa = "_bdb1922_Piping";
        //    //var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    //var collection = ModelEngineeringItems.GetItens(databaseVale);





        //    ItemModelado itemModel = null;


        //    List<string> tiposViews = new List<string>()
        //        {
        //            "Pipe"
        //        };


        //    foreach (var tipo in tiposViews)
        //    {

        //        if (tipo == "Pipe")
        //        {
        //            var tubos = Totais.GetView(databaseVale, "Pipe");

        //            foreach (var tubo in tubos)
        //            {
        //                string pnPID = tubo["PnPID"] == null ? "" : tubo["PnPID"].ToString();
        //                double comprimento = tubo["Length"] == null ? 0.0 : double.Parse(tubo["Length"].ToString());
        //                string descricaoLonga = tubo["PartFamilyLongDesc"] == null ? "" : tubo["PartFamilyLongDesc"].ToString();
        //                string descricaoLongaDimensionada = tubo["PartSizeLongDesc"] == null ? "" : tubo["PartSizeLongDesc"].ToString();




        //                itemModel = new ItemModelado(guidProjetoVale, pnPID, descricaoLonga, 
        //                    descricaoLongaDimensionada, "QtdLinear");
        //                itemModel.Comprimento = comprimento;

        //                repositorioItemModelado.Inserir(itemModel);

        //            }


        //        }
















        //        //var itemModel = new ItemModelado(guidProjetoVale, pnPID, descricaoLonga, descricaoLongaDimensionada);



        //        //repositorioItemModelado.Inserir(itemModel);

        //    }

        //}

        //[TestMethod]
        //public void L_Carga_ItemModeladoTageado_Plant3d_Assertivo()
        //{

        //    var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM_TESTE", "ItensModelados");

        //    //var databaseVale = "_bdb190101_Piping";
        //    //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

        //    var databaseNexa = "_bdb1922_Piping";
        //    var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    //var collection = ModelEngineeringItems.GetItens(databaseVale);





        //    ItemModelado itemModel = null;


        //    List<string> tiposViews = new List<string>()
        //        {
        //            "Pipe"
        //        };


        //    foreach (var tipo in tiposViews)
        //    {

        //        if (tipo == "Pipe")
        //        {
        //            var tubos = Totais.GetView(databaseNexa, "Pipe");

        //            foreach (var tubo in tubos)
        //            {
        //                string tag = tubo["LineNumberTag"] == null ? "" : tubo["LineNumberTag"].ToString();
        //                string pnPID = tubo["PnPID"] == null ? "" : tubo["PnPID"].ToString();
        //                double comprimento = tubo["Length"] == null ? 0.0 : double.Parse(tubo["Length"].ToString());
        //                string descricaoLonga = tubo["PartFamilyLongDesc"] == null ? "" : tubo["PartFamilyLongDesc"].ToString();
        //                string descricaoLongaDimensionada = tubo["PartSizeLongDesc"] == null ? "" : tubo["PartSizeLongDesc"].ToString();


        //                ItemTag itemTag = new ItemTag()

        //                itemModel = new ItemModelado(tag, guidProjetoNexa, pnPID, descricaoLonga,
        //                    descricaoLongaDimensionada, "QtdLinear", 0, comprimento, 0, 0);
        //                itemModel.Comprimento = comprimento;

        //                repositorioItemModelado.Inserir(itemModel);

        //            }


        //        }
















        //        //var itemModel = new ItemModelado(guidProjetoVale, pnPID, descricaoLonga, descricaoLongaDimensionada);



        //        //repositorioItemModelado.Inserir(itemModel);

        //    }

        //}


        //[TestMethod]
        //public void M_Carga_TagsModel_Separado_Assertivo()
        //{
        //    var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";
        //    //var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var repoAreasDesenhos = new BaseMDBRepositorio<AreaDesenho>("BIM", "AreasModelo3D");


        //   //string siglaProjetoNexa = "BdB1922";
        //   string siglaProjetoVale = "BdB190101";

        //    var tipoConsultaVolumetrica = "Volumetrica";

        //    List<AreaDesenho> areasDesenhosModelo3d = new List<AreaDesenho>();

        //    var pnPDrawingsModel3d= GetPnPDrawings.GetItens(siglaProjetoVale, tipoConsultaVolumetrica);

        //    var repoDWGs = new BaseMDBRepositorio<BIM.Entities.ItemTag>("BIM", "DWGsModel3D");

        //    foreach (var pnPDrawing in pnPDrawingsModel3d)
        //    {

        //        var dwgNome = pnPDrawing["Dwg Name"];

        //        var TipoDWG = dwgNome.ToString().Split('.').Last() == "dwg";

        //        if (TipoDWG)
        //        {

        //            AreaDesenho areaDesenhoModelo3d = null;

        //            var paths = pnPDrawing["Path"].ToString().Split('\\');
        //            var pathsReverse = paths.Reverse();

        //            foreach (var item in pathsReverse)
        //            {

        //                var tituloPicado = item.Split('-');

        //                foreach (var parteTitulo in tituloPicado)
        //                {
        //                    var areaSubArea = parteTitulo.Trim();

        //                    if (areaSubArea.Length == 6)
        //                    {
        //                        areaDesenhoModelo3d = areasDesenhosModelo3d.FirstOrDefault(x =>
        //                     x.Area == areaSubArea.Substring(0, 2)
        //                     && x.SubArea == areaSubArea.Substring(2, 2)
        //                     && x.SiglaProjeto == areaSubArea.Substring(4, 2));

        //                        if (areaDesenhoModelo3d == null)
        //                        {
        //                            areaDesenhoModelo3d = new AreaDesenho(
        //                                 guidProjetoVale,
        //                                 areaSubArea.Substring(0, 2),
        //                                 areaSubArea.Substring(2, 2),
        //                                 areaSubArea.Substring(4, 2),
        //                                 ""
        //                               );

        //                            areasDesenhosModelo3d.Add(areaDesenhoModelo3d);

        //                            repoAreasDesenhos.Inserir(areaDesenhoModelo3d);
        //                        }

        //                        break;

        //                    }
        //                    else if (areaSubArea.Length == 4)
        //                    {
        //                        areaDesenhoModelo3d = areasDesenhosModelo3d.FirstOrDefault(x =>
        //                     x.Area == areaSubArea.Substring(0, 2)
        //                     && x.SubArea == areaSubArea.Substring(2, 2)
        //                     && x.SiglaProjeto == "");

        //                        if (areaDesenhoModelo3d == null)
        //                        {
        //                            areaDesenhoModelo3d = new AreaDesenho(
        //                                 guidProjetoVale,
        //                                 areaSubArea.Substring(0, 2),
        //                                 areaSubArea.Substring(2, 2),
        //                                 "",
        //                                 ""
        //                               );

        //                            areasDesenhosModelo3d.Add(areaDesenhoModelo3d);

        //                            repoAreasDesenhos.Inserir(areaDesenhoModelo3d);
        //                        }

        //                        break;

        //                    }



        //                }

        //                break;
        //            }

        //            var inseredwg = new ItemTag(
        //                    guidProjetoVale,
        //                    areaDesenhoModelo3d,
        //                    tipoConsultaVolumetrica,
        //                    pnPDrawing["Path"].ToString().Split('\\').Last(),
        //                    pnPDrawing["Path"].ToString(),
        //                    ArquivoOrigem.MP3D);
        //            repoDWGs.Inserir(inseredwg);
        //        }


        //    }
        //}

        //[TestMethod]
        //public void N_Carga_DWGDiagrama_Separado_Assertivo()
        //{
        //    //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";
        //    var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var repoAreasDesenhos = new BaseMDBRepositorio<AreaDesenho>("BIM", "AreasDiagrama");


        //    string siglaProjetoNexa = "BdB1922";
        //    //string siglaProjetoVale = "BdB190101";

        //    var tipoConsultaProcesso = "Processo";

        //    List<AreaDesenho> areasDesenhosModelo3d = new List<AreaDesenho>();

        //    var pnPDrawingsProcesso = GetPnPDrawings.GetItens(siglaProjetoNexa, tipoConsultaProcesso);

        //    var repoDWGs = new BaseMDBRepositorio<BIM.Entities.ItemTag>("BIM", "DWGsDiagramas");

        //    foreach (var pnPDrawing in pnPDrawingsProcesso)
        //    {

        //        var dwgNome = pnPDrawing["Dwg Name"];

        //        var TipoDWG = dwgNome.ToString().Split('.').Last() == "dwg";

        //        if (TipoDWG)
        //        {

        //            AreaDesenho areaDesenhoDiagrama = null;

        //            var paths = pnPDrawing["Path"].ToString().Split('\\');
        //            var pathsReverse = paths.Reverse();

        //            foreach (var item in pathsReverse)
        //            {

        //                var tituloPicado = item.Split('-');

        //                foreach (var parteTitulo in tituloPicado)
        //                {
        //                    var areaSubArea = parteTitulo.Trim();

        //                    if (areaSubArea.Length == 6)
        //                    {
        //                        areaDesenhoDiagrama = areasDesenhosModelo3d.FirstOrDefault(x =>
        //                     x.Area == areaSubArea.Substring(0, 2)
        //                     && x.SubArea == areaSubArea.Substring(2, 2)
        //                     && x.SiglaProjeto == areaSubArea.Substring(4, 2));

        //                        if (areaDesenhoDiagrama == null)
        //                        {
        //                            areaDesenhoDiagrama = new AreaDesenho(
        //                                 guidProjetoNexa,
        //                                 areaSubArea.Substring(0, 2),
        //                                 areaSubArea.Substring(2, 2),
        //                                 areaSubArea.Substring(4, 2),
        //                                 ""
        //                               );

        //                            areasDesenhosModelo3d.Add(areaDesenhoDiagrama);

        //                            repoAreasDesenhos.Inserir(areaDesenhoDiagrama);
        //                        }

        //                        break;

        //                    }
        //                    else if (areaSubArea.Length == 4)
        //                    {
        //                        areaDesenhoDiagrama = areasDesenhosModelo3d.FirstOrDefault(x =>
        //                     x.Area == areaSubArea.Substring(0, 2)
        //                     && x.SubArea == areaSubArea.Substring(2, 2)
        //                     && x.SiglaProjeto == "");

        //                        if (areaDesenhoDiagrama == null)
        //                        {
        //                            areaDesenhoDiagrama = new AreaDesenho(
        //                                 guidProjetoNexa,
        //                                 areaSubArea.Substring(0, 2),
        //                                 areaSubArea.Substring(2, 2),
        //                                 "",
        //                                 ""
        //                               );

        //                            areasDesenhosModelo3d.Add(areaDesenhoDiagrama);

        //                            repoAreasDesenhos.Inserir(areaDesenhoDiagrama);
        //                        }

        //                        break;

        //                    }



        //                }

        //                break;
        //            }

        //            var inseredwg = new BIM.Entities.ItemTag(
        //                    guidProjetoNexa,
        //                    areaDesenhoDiagrama,
        //                    tipoConsultaProcesso,
        //                    pnPDrawing["Path"].ToString().Split('\\').Last(),
        //                    pnPDrawing["Path"].ToString(),
        //                    ArquivoOrigem.MP3D);
        //            repoDWGs.Inserir(inseredwg);
        //        }


        //    }
        //}


        //[TestMethod]
        //public void O_Atualizacao_ItensPlant3d_Assertivo()
        //{

        //    List<ItemPQPlant3d> listaItensDiagrama = new List<ItemPQPlant3d>();
        //    List<Quantidade> listaQuantidadesPipe = new List<Quantidade>();

        //    List<ItemModelado> itensModeladosQueJaForamIncluidosEmItemDiagrama = new List<ItemModelado>();


        //    var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM_TESTE", "ItensModelados");
        //    var repositorioItemDiagramasPlant3d = new BaseMDBRepositorio<ItemPQPlant3d>("BIM_TESTE", "ItemDiagramasPlant3d");
        //    var repositorioItemPQPlant3d = new BaseMDBRepositorio<ItemPQPlant3d>("BIM_TESTE", "ItemPQPlant3d");

        //    //var databaseModelosNexa= "_bdb1922_Piping";
        //    //var databaseModelosVale = "_bdb190101_Piping";


        //    string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";
        //    //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

        //    string siglaProjetoNexa = "BdB1922";
        //    //string siglaProjetoVale = "BdB190101";

        //    var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
        //    var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
        //           Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));



        //    var listaItensModelados = repositorioItemModelado.Encontrar(
        //           Builders<ItemModelado>.Filter.Eq(x => x.GuidProjeto, guidProjetoNexa));

        //    var itemPipePlant3dRepositorio = new BaseMDBRepositorio<ItemPQPlant3d>("BIM_TESTE", "ItemDiagramasPlant3d");

        //    listaItensDiagrama = itemPipePlant3dRepositorio.Encontrar(
        //           Builders<ItemPQPlant3d>.Filter.Eq(x => x.GuidProjeto, guidProjetoNexa));


        //    var tipoConsultaBanco = "Volumetrica";


        //    //Adicona quantidades só pipe

        //    foreach (var areaPlanejada in areasPlanejadasProjeto)
        //    {

        //        var listaItensDiagramaArea = listaItensDiagrama.Where(x =>
        //        x.ItemTag.AreaDesenho.Area == areaPlanejada.Area
        //        && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea
        //        ).ToList();

        //        foreach (var itemDiagramaParaProcessar in listaItensDiagramaArea)
        //        {

        //            var tipoItemDiag = itemDiagramaParaProcessar.SpecPart.Split(',').First().Split('.').First().Trim();

        //            if (tipoItemDiag == "TUBO" || tipoItemDiag == "PIPE")
        //            {

        //                string descricao = itemDiagramaParaProcessar.SpecPart;

        //                var itensModeladosEncontradosDescricaoConformeItemDiagrama =
        //                    listaItensModelados
        //                    .Where(x => x.DescricaoLongaDimensionada == descricao).ToList();

        //                if (itensModeladosEncontradosDescricaoConformeItemDiagrama.Count() > 0)
        //                {

        //                    foreach (var modeladoEncontrouDescricaoItemDiagrama in itensModeladosEncontradosDescricaoConformeItemDiagrama)
        //                    {

        //                        itensModeladosQueJaForamIncluidosEmItemDiagrama.Add(modeladoEncontrouDescricaoItemDiagrama);

        //                        itemDiagramaParaProcessar.AdicionaItemModelado(modeladoEncontrouDescricaoItemDiagrama);

        //                    }

        //                    repositorioItemPQPlant3d.Inserir(itemDiagramaParaProcessar);

        //                }
        //                else
        //                {
        //                    repositorioItemPQPlant3d.Inserir(itemDiagramaParaProcessar);
        //                }

        //            }
        //            else if (tipoItemDiag == "")
        //            {
        //                string tagItemDiagrama = itemDiagramaParaProcessar.ItemTag.TagCompleto;
        //            }
        //            else
        //            {
        //                string tagItemDiagrama = itemDiagramaParaProcessar.ItemTag.TagCompleto;
        //            }

        //        }

        //    }


        //    //Trabalha itens não contidos em diagrama




        //    var itensModeladosNaoIncluidosEmItemDiagrama = new List<ItemModelado>();

        //    foreach (var item in listaItensModelados)
        //    {
        //        var itemEncontrado = itensModeladosQueJaForamIncluidosEmItemDiagrama
        //             .FirstOrDefault(x => x.GUID == item.GUID);

        //        if (itemEncontrado == null)
        //        {
        //            var tipoItemModelado = item.DescricaoLongaDimensionada.Split(',').First().Split('.').First().Trim();

        //            if (tipoItemModelado == "TUBO")
        //            {
        //                itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
        //            }
        //            else if (tipoItemModelado == "PIPE")
        //            {
        //                itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
        //            }
        //            else
        //            {
        //                string tg = "";
        //            }

        //        }
        //    }

        //    var repoAreasModelos3d = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasModelos3d");

        //    List<AreaTag> areasDesenhosModelos3d = new List<AreaTag>();

        //    AreaTag areaDesenhoModelos3d = null;

        //    List<ItemModelado> listaItensModeladosAindaNaoAnalizados = new List<ItemModelado>();


        //    itensModeladosNaoIncluidosEmItemDiagrama
        //    .ForEach(x => listaItensModeladosAindaNaoAnalizados.Add(x));



        //    foreach (var areaPlanejada in areasPlanejadasProjeto)
        //    {


        //        foreach (var itemModelado in itensModeladosNaoIncluidosEmItemDiagrama)
        //        {



        //            var itemParaAnalize = listaItensModeladosAindaNaoAnalizados.FirstOrDefault(x => x.GUID == itemModelado.GUID);

        //            if (itemParaAnalize != null)
        //            {

        //                var tagSeperado = itemParaAnalize.Tag.Split('-');

        //                foreach (var parteTitulo in tagSeperado)
        //                {
        //                    var areaSubArea = parteTitulo.Trim();



        //                    if (areaSubArea.Length == 4 || areaSubArea.Length == 6)
        //                    {



        //                        if (areaSubArea.Substring(0, 2) == areaPlanejada.Area && areaSubArea.Substring(2, 2) == areaPlanejada.SubArea)
        //                        {


        //                            areaDesenhoModelos3d = areasDesenhosModelos3d.FirstOrDefault(x =>
        //                            x.Area == areaSubArea.Substring(0, 2)
        //                            && x.SubArea == areaSubArea.Substring(2, 2));

        //                            if (areaDesenhoModelos3d == null)
        //                            {
        //                                areaDesenhoModelos3d = new AreaTag(
        //                                     siglaProjetoNexa,
        //                                     areaSubArea.Substring(0, 2),
        //                                     areaSubArea.Substring(2, 2),
        //                                     ""
        //                                   );

        //                                areasDesenhosModelos3d.Add(areaDesenhoModelos3d);

        //                                repoAreasModelos3d.Inserir(areaDesenhoModelos3d);
        //                            }

        //                            break;
        //                        }


        //                    }




        //                }





        //                ItemTag itemTag =
        //                    new ItemTag(guidProjetoNexa, areaDesenhoModelos3d, "Volumetrica", itemParaAnalize.Tag, "");



        //                ItemPQPlant3d itemPQPlant3D =
        //                    new ItemPQPlant3d(guidProjetoNexa, itemTag, itemParaAnalize.PnPID,
        //                    itemParaAnalize.DescricaoLongaDimensionada);

        //                var itensDescricaoIgual = listaItensModeladosAindaNaoAnalizados
        //                  .Where(x => x.DescricaoLongaDimensionada == itemParaAnalize.DescricaoLongaDimensionada).ToList();

        //                foreach (var itemDescricaoIgual in itensDescricaoIgual)
        //                {
        //                    tagSeperado = itemParaAnalize.Tag.Split('-');

        //                    foreach (var parteTitulo in tagSeperado)
        //                    {
        //                        var areaSubArea = parteTitulo.Trim();



        //                        if (areaSubArea.Length == 4 || areaSubArea.Length == 6)
        //                        {



        //                            if (areaSubArea.Substring(0, 2) == areaPlanejada.Area && areaSubArea.Substring(2, 2) == areaPlanejada.SubArea)
        //                            {

        //                                itemPQPlant3D.AdicionaItemModelado(itemDescricaoIgual);


        //                                listaItensModeladosAindaNaoAnalizados.Remove(itemDescricaoIgual);

        //                            }

        //                        }


        //                    }

        //                }


        //                repositorioItemPQPlant3d.Inserir(itemPQPlant3D);


        //            }

        //        }
        //    }




        //}



        private static bool PertenceAareaPlanejada(AreaPlanejada areaPlanejada, string areaSubArea)
        {
            return (areaSubArea.Length == 6 || areaSubArea.Length == 4)
                                            && (areaSubArea.Substring(0, 2) == areaPlanejada.Area && areaSubArea.Substring(2, 2) == areaPlanejada.SubArea);
        }



        [TestMethod]
        public void X_J_Tags_Assertivo()
        {
            //var databaseVale = "_bdb190101_PnId";
            //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var databaseNexa = "_bdb1922_PnId";
            var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";






            var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemDiagramasPlant3d");
            var repoAreasDesenhos = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasDiagrama");
            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

            var repoItemPipe = new RepoItemPipe();


            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));

            List<AreaTag> areasDesenhosDiagrama = new List<AreaTag>();

            AreaTag areaDesenhoDiagrama = null;

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {
                var collection = LinhasPipeSQL.GetItensArea(databaseNexa, areaPlanejada.Area + areaPlanejada.SubArea);



                foreach (var item in collection)
                {




                    string area = item["AREA"] == null ? "" : item["AREA"].ToString();
                    string tag = item["Tag"] == null ? "" : item["Tag"].ToString();

                    string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();
                    string specPart = item["Spec Part"] == null ? "" : item["Spec Part"].ToString();



                    var tagSeperado = tag.Split('-');

                    foreach (var parteTitulo in tagSeperado)
                    {
                        var textoExtraidoDoTag = parteTitulo.Trim();

                        if (PertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
                        {
                            areaDesenhoDiagrama = areasDesenhosDiagrama.FirstOrDefault(x =>
                            x.Area == textoExtraidoDoTag.Substring(0, 2)
                            && x.SubArea == textoExtraidoDoTag.Substring(2, 2));



                            areaDesenhoDiagrama = AreaTag.Criar(areaPlanejada, tag);

                            areasDesenhosDiagrama.Add(areaDesenhoDiagrama);


                            break;
                        }







                    }

                    //if (areaDesenhoDiagrama != null && areaDesenhoDiagrama.Area == areaPlanejada.Area && areaDesenhoDiagrama.SubArea == areaPlanejada.SubArea)
                    //{
                    //    ItemTag itemTag = new ItemTag(guidProjetoNexa, areaDesenhoDiagrama, "Diagrama", tag, "");

                    //    var itemPipe = repoItemPipe.Obter(specPart, "");


                    //    var itemPQPlant3d = new ItemPQ(guidProjetoNexa, "RRP", itemTag, pnPID, specPart, itemPipe);


                    //    repositorioItemPipePlant3d.Inserir(itemPQPlant3d);
                    //}

                }
            }

        }

        [TestMethod]
        public void X_L_Carga_ItemModeladoTageado_Plant3d_Assertivo()
        {

            RepoItemModelado repoItemModelado = new RepoItemModelado();

            var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM_TESTE", "ItensModelados");
            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
            var repoAreasModelo = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasModelados");

            //var databaseVale = "_bdb190101_Piping";
            //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            var databaseNexa = "_bdb1922_Piping";
            var guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";


            ItemModelado itemModel = null;


            List<string> tiposViews = new List<string>()
                {
                    "Pipe","Valve"
                };



            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));

            List<AreaTag> areasModelo3d = new List<AreaTag>();

            AreaTag areaModelo = null;

            var tubos = TotaisSQL.GetView(databaseNexa, "Pipe");
            var valvulas = TotaisSQL.GetView(databaseNexa, "Valve");

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {

                foreach (var tipo in tiposViews)
                {

                    switch (tipo)
                    {
                        case "Pipe":
                            {


                                foreach (var tubo in tubos)
                                {
                                    string tag = tubo["LineNumberTag"] == null ? "" : tubo["LineNumberTag"].ToString();

                                    if (tag != "")
                                    {
                                        var tagSeperado = tag.Split('-');

                                        foreach (var parteTitulo in tagSeperado)
                                        {
                                            var textoExtraidoDoTag = parteTitulo.Trim();

                                            if (PertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
                                            {
                                                areaModelo = areasModelo3d.FirstOrDefault(x =>
                                                x.Area == textoExtraidoDoTag.Substring(0, 2)
                                                && x.SubArea == textoExtraidoDoTag.Substring(2, 2));


                                                areaModelo = AreaTag.Criar(areaPlanejada, tag);

                                                areasModelo3d.Add(areaModelo);

                                                break;
                                            }







                                        }


                                        //if (areaModelo != null && areaModelo.Area == areaPlanejada.Area && areaModelo.SubArea == areaPlanejada.SubArea)
                                        //{
                                        //    string pnPID = tubo["PnPID"] == null ? "" : tubo["PnPID"].ToString();
                                        //    double comprimento = tubo["Length"] == null ? 0.0 : double.Parse(tubo["Length"].ToString());
                                        //    string descricaoLonga = tubo["PartFamilyLongDesc"] == null ? "" : tubo["PartFamilyLongDesc"].ToString();
                                        //    string descricaoLongaDimensionada = tubo["PartSizeLongDesc"] == null ? "" : tubo["PartSizeLongDesc"].ToString();

                                        //    var areaTag = AreaTag.Criar(areaPlanejada, tag);

                                        //    ItemTag itemTag = new ItemTag(guidProjetoNexa, areaTag, "3D", tag, "");

                                        //    itemModel = new ItemModelado(itemTag, guidProjetoNexa, pnPID, descricaoLonga,
                                        //        descricaoLongaDimensionada, "QtdLinear", 0, comprimento, 0, 0);
                                        //    itemModel.Comprimento = comprimento;

                                        //    repositorioItemModelado.Inserir(itemModel);
                                        //}


                                    }

                                }



                            }
                            break;

                        case "Valve":
                            {


                                foreach (var valvula in valvulas)
                                {
                                    string tag = valvula["LineNumberTag"] == null ? "" : valvula["LineNumberTag"].ToString();

                                    if (tag != "")
                                    {
                                        var tagSeperado = tag.Split('-');

                                        foreach (var parteTitulo in tagSeperado)
                                        {
                                            var textoExtraidoDoTag = parteTitulo.Trim();

                                            if (PertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
                                            {

                                                areaModelo = AreaTag.Criar(areaPlanejada, tag);

                                                areasModelo3d.Add(areaModelo);

                                                break;
                                            }
                                        }


                                        //if (areaModelo != null && areaModelo.Area == areaPlanejada.Area && areaModelo.SubArea == areaPlanejada.SubArea)
                                        //{
                                        //    string pnPID = valvula["PnPID"] == null ? "" : valvula["PnPID"].ToString();

                                        //    string descricaoLonga = valvula["PartFamilyLongDesc"] == null ? "" : valvula["PartFamilyLongDesc"].ToString();
                                        //    string descricaoLongaDimensionada = valvula["PartSizeLongDesc"] == null ? "" : valvula["PartSizeLongDesc"].ToString();


                                        //    var areaTag = AreaTag.Criar(areaPlanejada, tag);

                                        //    ItemTag itemTag = new ItemTag(guidProjetoNexa, areaTag, "3D", tag, "");

                                        //    itemModel = new ItemModelado(itemTag, guidProjetoNexa, pnPID, descricaoLonga,
                                        //        descricaoLongaDimensionada, "Unidade", 1, 0, 0, 0);


                                        //    repositorioItemModelado.Inserir(itemModel);
                                        //}



                                    }

                                }

                            }
                            break;


                    }




                }

                //}

            }

        }

        [TestMethod]
        public void X_O_Atualizacao_ItensPlant3d_Assertivo()
        {

            var repoItemPipe = new RepoItemPipe();

            List<ItemPQ> listaItensDiagrama = new List<ItemPQ>();
            List<Quantidade> listaQuantidadesPipe = new List<Quantidade>();

            List<ItemModelado> itensModeladosQueJaForamIncluidosEmItemDiagrama = new List<ItemModelado>();


            var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM_TESTE", "ItensModelados");

            var repositorioItemPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");
            var repositorioItensDiagramas = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemDiagramasPlant3d");


            var repositorioAtividade = new BaseMDBRepositorio<Atividade>("MontagemPQ", "Atividade");


            //var databaseModelosNexa= "_bdb1922_Piping";
            //var databaseModelosVale = "_bdb190101_Piping";


            string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";
            //var guidProjetoVale = "a050dc55-009d-4f19-b867-4bdbe0ee3523";

            string siglaProjetoNexa = "BdB1922";
            //string siglaProjetoVale = "BdB190101";

            var repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
            var areasPlanejadasProjeto = repoAreasPlanejadas.Encontrar(
                   Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));



            var listaDeItensModelados = repositorioItemModelado.Encontrar(
                   Builders<ItemModelado>.Filter.Eq(x => x.GuidProjeto, guidProjetoNexa));



            listaItensDiagrama = repositorioItensDiagramas.Encontrar(
                   Builders<ItemPQ>.Filter.Eq(x => x.GuidProjeto, guidProjetoNexa));


            var tipoConsultaBanco = "Volumetrica";


            List<ItemPQ> itensPQIncluidos = new List<ItemPQ>();

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {


                var listaItensExistentesDiagramaParaArea = listaItensDiagrama.Where(x =>
            x.ItemTag.AreaDesenho.Area == areaPlanejada.Area
            && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea
            ).ToList();

                string tagItemDiagrama;

                foreach (var itemDiagramaParaProcessar in listaItensExistentesDiagramaParaArea)
                {

                    var tipoItemDiag = itemDiagramaParaProcessar.SpecPart.Split(',').First().Split('.').First().Split(' ').First().Trim();


                    if (tipoItemDiag == "TUBO" || tipoItemDiag == "PIPE" || tipoItemDiag == "VÁLVULA")
                    {

                        //switch (tipoItemDiag)
                        //{
                        //    case "TUBO":
                        //        {


                        //            var descricao = itemDiagramaParaProcessar.SpecPart + " - INCLUSIVE CONEXÕES E VÁLVULAS";

                        //            var atividades = repositorioAtividade.Encontrar(
                        //                Builders<Atividade>.Filter.Eq(x => x.Descricao, descricao));



                        //            var atividade = atividades.Where(x => x.Descricao == "MONTAGEM DE TUBO, CC, AC");
                        //        }
                        //        break;
                        //}


                        DefineItemDiagrama(itensModeladosQueJaForamIncluidosEmItemDiagrama,
                                    repositorioItemPQPlant3d,
                                    listaDeItensModelados,
                                    itensPQIncluidos,
                                    areaPlanejada,
                                    itemDiagramaParaProcessar);
                    }
                    else if (tipoItemDiag == "")
                    {
                        tagItemDiagrama = itemDiagramaParaProcessar.ItemTag.TagCompleto;
                    }
                    else
                    {
                        tagItemDiagrama = itemDiagramaParaProcessar.ItemTag.TagCompleto;
                    }

                }



            }



            var itensModeladosNaoIncluidosEmItemDiagrama = new List<ItemModelado>();

            foreach (var item in listaDeItensModelados)
            {
                var itemEncontrado = itensModeladosQueJaForamIncluidosEmItemDiagrama
                     .FirstOrDefault(x => x.GUID == item.GUID);

                if (itemEncontrado == null)
                {
                    var tipoItemModelado = item.DescricaoLongaDimensionada.Split(',').First().Split('.').First().Split(' ').First().Trim();

                    switch (tipoItemModelado)
                    {
                        case "TUBO":
                            itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                            break;
                        case "PIPE":
                            itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                            break;
                        case "VÁLVULA":
                            itensModeladosNaoIncluidosEmItemDiagrama.Add(item);
                            break;
                        default:
                            string tg = "";
                            break;
                    }

                }
            }

            var repoAreasModelos3d = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasModelos3d");

            List<AreaTag> areasDesenhosModelos3d = new List<AreaTag>();



            List<ItemModelado> listaItensModeladosAindaNaoAnalizados = new List<ItemModelado>();


            itensModeladosNaoIncluidosEmItemDiagrama
            .ForEach(x => listaItensModeladosAindaNaoAnalizados.Add(x));



            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {


                var itensModeladosNaoIncluidosEmItemDiagramaParaArea = itensModeladosNaoIncluidosEmItemDiagrama
                .Where(x => x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea).ToList();

                foreach (var itemModelado in itensModeladosNaoIncluidosEmItemDiagramaParaArea)
                {



                    var itemParaAnalize = listaItensModeladosAindaNaoAnalizados.FirstOrDefault(x => x.GUID == itemModelado.GUID);

                    //if (itemParaAnalize != null)
                    //{


                    //    var areaDesenhoModelos3d = AreaTag.Criar(guidProjetoNexa, areaPlanejada, itemParaAnalize.ItemTag.AreaDesenho.Area, itemParaAnalize.ItemTag.AreaDesenho.SubArea);

                    //    ItemTag itemTag =
                    //        new ItemTag(guidProjetoNexa, areaDesenhoModelos3d, "3D", itemParaAnalize.ItemTag.TagCompleto, "");

                    //    var itemPipe = repoItemPipe.Obter(itemParaAnalize.DescricaoLongaDimensionada, "");

                    //    ItemPQ itemPQPlant3D =
                    //        new ItemPQ(guidProjetoNexa, "RRP", itemTag, itemParaAnalize.PnPID,
                    //        itemParaAnalize.DescricaoLongaDimensionada, itemPipe);

                    //    var itensDescricaoIgual = listaItensModeladosAindaNaoAnalizados
                    //      .Where(x =>
                    //      (x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea) &&
                    //      x.DescricaoLongaDimensionada == itemParaAnalize.DescricaoLongaDimensionada).ToList();

                    //    foreach (var itemDescricaoIgual in itensDescricaoIgual)
                    //    {


                    //        itemPQPlant3D.AdicionaItemModelado(itemDescricaoIgual);


                    //        listaItensModeladosAindaNaoAnalizados.Remove(itemDescricaoIgual);


                    //    }

                    //    itemPQPlant3D.CorAvanco = "red";
                    //    repositorioItemPQPlant3d.Inserir(itemPQPlant3D);

                    //}

                }



            }




        }

        private static void DefineItemDiagrama(List<ItemModelado> itensModeladosQueJaForamIncluidosEmItemDiagrama, BaseMDBRepositorio<ItemPQ> repositorioItemPQPlant3d, List<ItemModelado> listaItensModelados, List<ItemPQ> itensPQIncluidos, AreaPlanejada areaPlanejada, ItemPQ itemDiagramaParaProcessar)
        {
            string descricao = itemDiagramaParaProcessar.SpecPart;




            var itemPQIncluido = itensPQIncluidos.FirstOrDefault(x =>
                (x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea)
                && x.SpecPart == descricao
                );

            if (itemPQIncluido == null)
            {

                var itensModeladosEncontradosDescricaoConformeItemDiagrama =
              listaItensModelados
              .Where(x =>
              (x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea) &&
              x.DescricaoLongaDimensionada == descricao).ToList();



                if (itensModeladosEncontradosDescricaoConformeItemDiagrama.Count() > 0)
                {



                    foreach (var modeladoEncontrouDescricaoItemDiagrama in itensModeladosEncontradosDescricaoConformeItemDiagrama)
                    {

                        itensModeladosQueJaForamIncluidosEmItemDiagrama.Add(modeladoEncontrouDescricaoItemDiagrama);

                        itemDiagramaParaProcessar.AdicionaItemModelado(modeladoEncontrouDescricaoItemDiagrama);

                    }

                    itemDiagramaParaProcessar.CorAvanco = "green";
                    repositorioItemPQPlant3d.Inserir(itemDiagramaParaProcessar);
                    itensPQIncluidos.Add(itemDiagramaParaProcessar);

                }
                else
                {
                    itemDiagramaParaProcessar.CorAvanco = "yellow";
                    repositorioItemPQPlant3d.Inserir(itemDiagramaParaProcessar);
                    itensPQIncluidos.Add(itemDiagramaParaProcessar);
                }
            }
            else
            {
                var itensModeladosEncontradosDescricaoConformeItemDiagrama =
              listaItensModelados
              .Where(x =>
              (x.ItemTag.AreaDesenho.Area == areaPlanejada.Area && x.ItemTag.AreaDesenho.SubArea == areaPlanejada.SubArea) &&
              x.DescricaoLongaDimensionada == descricao).ToList();



                if (itensModeladosEncontradosDescricaoConformeItemDiagrama.Count() > 0)
                {

                    foreach (var modeladoEncontrouDescricaoItemDiagrama in itensModeladosEncontradosDescricaoConformeItemDiagrama)
                    {

                        itensModeladosQueJaForamIncluidosEmItemDiagrama.Add(modeladoEncontrouDescricaoItemDiagrama);

                        itemDiagramaParaProcessar.AdicionaItemModelado(modeladoEncontrouDescricaoItemDiagrama);

                    }

                    repositorioItemPQPlant3d.Atualizar(itemDiagramaParaProcessar);

                }
                else
                {
                    repositorioItemPQPlant3d.Atualizar(itemDiagramaParaProcessar);

                }
            }
        }

        [TestMethod]
        public void X_Q_Analize_ItensPlant3d_Assertivo()
        {
            var repositorioItemPQPlant3d = new BaseMDBRepositorio<ItemPQ>("BIM_TESTE", "ItemPQPlant3d");

            var itensArea = repositorioItemPQPlant3d.Encontrar(
                   Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.Area, "04")
                   & Builders<ItemPQ>.Filter.Eq(x => x.ItemTag.AreaDesenho.SubArea, "01"));

            var analise = itensArea.OrderBy(x => x.SpecPart).ToList();

            var item1 = itensArea[2];
            var item2 = itensArea[3];

            Assert.IsTrue(item1.SpecPart.Equals(item1.SpecPart));


        }


        [TestMethod]
        public void Z_Carga_Hub_Assertivo()
        {

            Usuario usuario = new Usuario("Ricardo", "RRP", "Tubulacao");

            var repositorioProjetos = new BaseMDBRepositorio<Projeto>("BIM", "Projetos");

            var repositorioHubs = new BaseMDBRepositorio<Hub>("BIM", "Hubs");

            Hub hub = new Hub(usuario);

            var projetos = repositorioProjetos.Obter();

            foreach (var projeto in projetos.OrderBy(x => x.Sigla))
            {
                var sigla = projeto.Sigla.Split('_').Last();

                var encontrado = hub.Projetos.FirstOrDefault(x => x.Sigla == projeto.Sigla);
                if (encontrado == null)
                {
                    hub.AdicionaProjeto(projeto);
                }

            }

            repositorioHubs.Inserir(hub);



        }

        //[TestMethod]
        //public void ZZ_CorrigeItemPipe()
        //{
        //    var repositorioItemPipe = new BaseMDBRepositorio<ItemPipe>("Catalogo", "ItemPipe");

        //    var itens = repositorioItemPipe.Obter();
        //    var itens_Com_GuidAtividade = itens.Where(x => x.GUID_ATIVIDADE != null).ToList();
        //    var itens_Sem_GuidAtividade = itens.Where(x => x.GUID_ATIVIDADE == null).ToList();

        //    foreach (var item in itens_Sem_GuidAtividade)
        //    {
        //        item.GUID_ATIVIDADE = "";
        //        repositorioItemPipe.Atualizar(item);
        //    }
        //}

        //[TestMethod]
        //public void M_Atualizacao_ItensPlant3d_Assertivo()
        //{
        //    List<ItemPQPlant3d> itensDiagramaParaDarUpdate = new List<ItemPQPlant3d>();


        //    List<ItemPQPlant3d> listaItensDiagrama = new List<ItemPQPlant3d>();
        //    List<Quantidade> listaQuantidadesPipe = new List<Quantidade>();
        //    //List<ItemModelado> listaItensModelados = new List<ItemModelado>();

        //    List<ItemModelado> itensModeladosQueJaForamIncluidosEmItemDiagrama = new List<ItemModelado>();


        //    var repositorioItemModelado = new BaseMDBRepositorio<ItemModelado>("BIM", "ItensModelados");
        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPQPlant3d>("BIM", "ItemPipePlant3d");

        //    //var databaseDiagramasVale = "_bdb190101_PnId";

        //    var databaseModelosVale = "_bdb190101_Piping";

        //    var guidProjeto = "a050dc55-009d-4f19-b867-4bdbe0ee3523";


        //    var listaItensModelados = repositorioItemModelado.Encontrar(
        //           Builders<ItemModelado>.Filter.Eq(x => x.GuidProjeto, guidProjeto));

        //    var itemPipePlant3dRepositorio = new BaseMDBRepositorio<ItemPQPlant3d>("BIM", "ItemDiagramasPlant3d");

        //    listaItensDiagrama = itemPipePlant3dRepositorio.Encontrar(
        //           Builders<ItemPQPlant3d>.Filter.Eq(x => x.GuidProjeto, guidProjeto));





        //    //var quantidadesPipe = Totais.GetTabela(databaseModelosVale, "Pipe");




        //    //Adicona quantidades só pipe
        //    foreach (var itemDiagramaBuscadoBancoDados in listaItensDiagrama)
        //    {

        //        string tipoItem = itemDiagramaBuscadoBancoDados.SpecPart.Split(',')[0].Split(' ')[0].Trim();

        //        var itensModeladosEncontraramDescricaoConformeDiagrama = listaItensModelados.Where(x => x.DescricaoLongaDimensionada == itemDiagramaBuscadoBancoDados.SpecPart).ToList();




        //        foreach (var modeladoEncontrouDescricaoItemDiagrama in itensModeladosEncontraramDescricaoConformeDiagrama)
        //        {

        //            var itemModelado_Ja_Foi_Incluido_ItemDiagrama = itensModeladosQueJaForamIncluidosEmItemDiagrama.FirstOrDefault(x => x.PnPID == modeladoEncontrouDescricaoItemDiagrama.PnPID);

        //            if (itemModelado_Ja_Foi_Incluido_ItemDiagrama == null)
        //            {
        //                //switch (tipoItem)
        //                //{
        //                //    case "TUBO":
        //                //        {

        //                //            var qtds = quantidadesPipe.Where(x => x["PnPID"].ToString() == modeladoEncontrouDescricaoItemDiagrama.PnPID).ToList();

        //                //            foreach (var qtd in qtds)
        //                //            {
        //                //                //string pnPID = qtd["PnPID"] == null ? "" : qtd["PnPID"].ToString();
        //                //                //double comprimentoCortado = qtd["CutLength"] == null ? 0.0 : double.Parse(qtd["CutLength"].ToString());
        //                //                double comprimento = qtd["Length"] == null ? 0.0 : double.Parse(qtd["Length"].ToString());
        //                //                //double pesoLinear = qtd["LinearWeight"] == null ? 0.0 : double.Parse(qtd["LinearWeight"].ToString());
        //                //                //string unidadePesoLinear = qtd["LinearWeightUnit"] == null ? "" : qtd["LinearWeightUnit"].ToString();
        //                //                //double comprimentoMinimoCorte = qtd["CutLength"] == null ? 0.0 : double.Parse(qtd["CutLength"].ToString());
        //                //                //bool usaComprimentoFixo = qtd["CutLength"].ToString() == "False" ? false : true;

        //                //                //QtdLinear qtdLinear =
        //                //                //    new QtdLinear(pnPID, comprimentoCortado, comprimento, pesoLinear,
        //                //                //    unidadePesoLinear, comprimentoMinimoCorte, usaComprimentoFixo);

        //                //                QtdLinear qtdLinear = new QtdLinear(comprimento);

        //                //                modeladoEncontrouDescricaoItemDiagrama.Quantidade = qtdLinear;


        //                //            }








        //                //        }
        //                //        break;

        //                //}

        //                itensModeladosQueJaForamIncluidosEmItemDiagrama.Add(modeladoEncontrouDescricaoItemDiagrama);

        //                itemDiagramaBuscadoBancoDados.AdicionaItemModelado(modeladoEncontrouDescricaoItemDiagrama);

        //            }

        //        }

        //        itensDiagramaParaDarUpdate.Add(itemDiagramaBuscadoBancoDados);



        //    }

        //    //var comModelo1 = itensDiagramaParaDarUpdate.Where(x => x.ItensModelados.Count() > 0).ToList();

        //    //var comModelo2 = listaItensDiagrama.Where(x => x.ItensModelados.Count() > 0).ToList();

        //    //string siglaProjetoNexa = "BdB1922";
        //    string siglaProjetoVale = "BdB190101";

        //    var pnPDrawingsModelo3D = GetPnPDrawings.GetItens(siglaProjetoVale, "Volumetrica");
        //    var linksItensDrawingModelos3D = GetPnPDataLinks.GetItens(siglaProjetoVale, "Volumetrica");


        //    foreach (var itemModeladoNaoFiltrado in listaItensModelados)
        //    {
        //        var itemIncluido = itensModeladosQueJaForamIncluidosEmItemDiagrama
        //             .FirstOrDefault(x => x.GUID == itemModeladoNaoFiltrado.GUID);

        //        if (itemIncluido == null)
        //        {
        //            var ligacoes = linksItensDrawingModelos3D.Where(x => x["PnPID"].ToString() == itemModeladoNaoFiltrado.PnPID).ToList();

        //            if (ligacoes.Count() > 0)
        //            {
        //                var ver = "x";
        //            }


        //            //


        //            //        ItemPQPlant3d itemPQPlant3D = new ItemPQPlant3d(
        //            //        guidProjeto,
        //            //        area: "",

        //            //        );
        //        }
        //    }



        //    //    //var itemModeladoConverterItemDiagrama = 
        //    //}




        //    //foreach (var item in itensDiagramaParaDarUpdate)
        //    //{
        //    //    repositorioItemPipePlant3d.Atualizar(item);
        //    //}

        //}





        //[TestMethod]
        //public void F_Carga_Item_Model_Plant3d_Assertivo()
        //{

        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPipePlant3d>("BIM", "ItemModelPlant3d");

        //    var database = "_bdb190101_PnId";


        //    var collection = LinhasPipe.GetTubosSQLServer(database);

        //    foreach (var item in collection)
        //    {

        //        var listaValores = item.Values.ToList();

        //        var itemPipe = new ItemPipePlant3d(
        //               listaValores.ElementAt(0).ToString(),
        //               listaValores.ElementAt(1).ToString(),
        //               listaValores.ElementAt(2).ToString(),
        //               listaValores.ElementAt(3).ToString(),
        //               listaValores.ElementAt(4).ToString());

        //        repositorioItemPipePlant3d.Inserir(itemPipe);

        //    }

        //}

        //[TestMethod]
        //public void G_Carga_ItemPipeModelado_Plant3d_Assertivo()
        //{

        //    var repositorioItemPipePlant3d = new BaseMDBRepositorio<ItemPipePlant3d>("BIM", "ItemModelPipePlant3d");

        //    var database = "_bdb190101_Piping";
        //    //_bdb190101_Piping

        //    var collection = ModelPipe.GetTubos3dSQLServer(database);

        //    foreach (var item in collection)
        //    {

        //        var listaValores = item.Values.ToList();

        //        var itemPipe = new ItemPipePlant3d(
        //               listaValores.ElementAt(0).ToString(),
        //               listaValores.ElementAt(1).ToString(),
        //               listaValores.ElementAt(2).ToString(),
        //               listaValores.ElementAt(3).ToString(),
        //               listaValores.ElementAt(4).ToString());

        //        repositorioItemPipePlant3d.Inserir(itemPipe);

        //    }

        //}


        //[TestMethod]
        //public void D_Carga_EAPTubulacao_Assertivo()
        //{

        //    var conexao = "Plant3d_Diagramas";
        //    var caminho = new List<string>();
        //    EAP eap = null;
        //    //var dwgs = new List<DwgFile>();
        //    var listaAreas = new List<Area>();

        //    //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 
        //    var repoAreaPlanejada = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

        //    string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var areasPlanejadasProjeto = repoAreaPlanejada.Encontrar(
        //           Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));



        //    var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacao");

        //    using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao))
        //    {
        //        var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);

        //        //var paths = pnPDrawings.First().Path.Split('\\');
        //        eap = new EAP("BdB1922");

        //        foreach (var pnPDrawing in pnPDrawings)
        //        {
        //            var paths = pnPDrawing.Path.Split('\\');


        //            var nomePastaSuperior = paths.Reverse().ElementAt(1);

        //            var novaArea = new Area(paths.Last(), "Volumetrica");

        //            if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
        //            {
        //                var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
        //                areaSuperior.AdicionaArea(novaArea);
        //            }
        //            else
        //            {
        //                eap.AdicionaArea(novaArea);
        //            }

        //            listaAreas.Add(novaArea);
        //            //}






        //        }



        //    }



        //    repoEAP.Inserir(eap);



        //    //Projeto disciplina = new Projeto("Tubulação");

        //    //repoDisciplina.Inserir(disciplina);
        //}



        //[TestMethod]
        //public void D_CargaEAP_Model3d_Assertivo()
        //{

        //    var conexao = "Plant3d_Model3D";
        //    var caminho = new List<string>();
        //    EAP eap = null;
        //    //var dwgs = new List<DwgFile>();
        //    var listaAreas = new List<Area>();

        //    //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 
        //    var repoAreaPlanejada = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");

        //    string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

        //    var areasPlanejadasProjeto = repoAreaPlanejada.Encontrar(
        //           Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjetoNexa));



        //    var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPMecanica");

        //    using (var repositorioPnPDrawings = new RepositorioBIM<PnPDrawings>(conexao))
        //    {
        //        var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);

        //        //var paths = pnPDrawings.First().Path.Split('\\');
        //        eap = new EAP("BdB1922");

        //        foreach (var pnPDrawing in pnPDrawings)
        //        {
        //            var paths = pnPDrawing.Path.Split('\\');


        //            var nomePastaSuperior = paths.Reverse().ElementAt(1);

        //            var novaArea = new Area(paths.Last(), "Volumetrica");

        //            if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
        //            {
        //                var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
        //                areaSuperior.AdicionaArea(novaArea);
        //            }
        //            else
        //            {
        //                eap.AdicionaArea(novaArea);
        //            }

        //            listaAreas.Add(novaArea);
        //            //}






        //        }



        //    }



        //    repoEAP.Inserir(eap);



        //    //Projeto disciplina = new Projeto("Tubulação");

        //    //repoDisciplina.Inserir(disciplina);
        //}






        //[TestMethod]
        //public void E_CargaEAP_Diagramas_Assertivo()
        //{

        //    var conexao = "Plant3d_Diagramas";
        //    var caminho = new List<string>();
        //    //EAP eap = null;
        //    //var dwgs = new List<DwgFile>();
        //    var listaAreas = new List<Area>();

        //    //var repoDWGs = new BaseMDBRepositorio<DwgFile>("BIM", "DWGs"); 
        //    var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPs");

        //    var eaps = repoEAP.Encontrar(
        //           Builders<EAP>.Filter.Eq(x => x.GUID_PROJETO, "BdB1922"));

        //    if (eaps.Count() > 0)
        //    {

        //        var eapFinded = eaps.First();

        //        using (var repositorioPnPDrawings = new RepoPID<Plant3dDiagramas.RepoSQLServerEF.PnPDrawings>(conexao))
        //        {
        //            var pnPDrawings = repositorioPnPDrawings.Query().ToList();//..Find(x => x.NOME == nomeCatalogo);

        //            //var paths = pnPDrawings.First().Path.Split('\\');
        //            //eap = new EAP("BdB1922");

        //            foreach (var pnPDrawing in pnPDrawings)
        //            {
        //                var paths = pnPDrawing.Path.Split('\\');

        //                //if (paths.Last().Split('.').Last() == "dwg")
        //                //{
        //                //    var nomePastaSuperior = paths.Reverse().ElementAt(1);
        //                //    var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
        //                //    var dwg = new DwgFile(pnPDrawing.Path, areaSuperior.GUID);
        //                //    dwgs.Add(dwg);

        //                //    repoDWGs.Inserir(dwg);
        //                //}
        //                //else
        //                //{
        //                var nomePastaSuperior = paths.Reverse().ElementAt(1);

        //                var novaArea = new Area(paths.Last(), "Processo");

        //                if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
        //                {
        //                    var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
        //                    areaSuperior.AdicionaArea(novaArea);
        //                }
        //                else
        //                {
        //                    eapFinded.AdicionaArea(novaArea);
        //                }

        //                listaAreas.Add(novaArea);
        //                //}






        //            }



        //        }

        //        repoEAP.Atualizar(eapFinded);

        //    }





        //    //Projeto disciplina = new Projeto("Tubulação");

        //    //repoDisciplina.Inserir(disciplina);
        //}






        //readonly IRequestIO _repositorioIO;
        //public CriaProjetosRequest(IRequestIO repositorioIO)
        //{
        //    _repositorioIO = repositorioIO;
        //}

        //public Hub GetProjetos(string hubVPN)
        //{
        //    var lista = _repositorioIO.GetPastas(hubVPN);

        //    var hub = new Hub();

        //    foreach (var nm in lista)
        //    {
        //        var nmProj = nm.Split('\\').Last();
        //        hub.AdicionaProjeto(nmProj);
        //    }

        //    return hub;
        //}



    }
}
