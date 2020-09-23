using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoComumPlantEF.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class ColecaoBIM360ItensModelados
    {

        RepoItemModelado _repoItemModelado;
        RepoAreasPlanejadas _repoAreasPlanejadas;
        RepoColetadosPipe _repoColetados;
        //List<List<Dictionary<object, object>>> _viewsBanco;
        //Coletados _viewsBanco;


        public ColecaoBIM360ItensModelados(string filename, string guidProjeto)
        {
            Filename = filename;
            GuidProjeto = guidProjeto;

            _repoItemModelado = new RepoItemModelado();
            _repoAreasPlanejadas = new RepoAreasPlanejadas();
            _repoColetados = new RepoColetadosPipe();
           ListaCategorias(Filename, guidProjeto);
        }

        public string Filename { get; set; }
        public string GuidProjeto { get; set; }

        public void ColetarItens(AreaPlanejada areaPlanejada)
        {
            var coletados = _repoColetados.ObterUltimaColeta(areaPlanejada.GUID_PROJETO, 0);

            var areaZero = _repoAreasPlanejadas.ObterAreaZero(areaPlanejada.GUID_PROJETO);


            foreach (var coletado in coletados)
            {
                string tag = coletado.ComponentePlant.LineNumberTag;
                //if (tag != "" && tag != null)
                //{
                    var areaTagModelo = AreaTag.Criar(areaPlanejada, tag);
                    if (AreaDoModeloEstaDeAcordoComAreaPlanejada(areaPlanejada, areaTagModelo))
                    {
                        _repoItemModelado.CadastraColetado(areaPlanejada, coletado, tag, areaTagModelo);

                    }
                    else
                    {
                        if (areaZero == null)
                        {
                            areaZero = CriaAreaZero(areaPlanejada);
                        }
                        var areaTagModeloImprovisada = AreaTag.Improvisar(areaPlanejada.GUID_PROJETO);
                        _repoItemModelado.CadastraColetado(areaPlanejada, coletado, tag, areaTagModeloImprovisada);
                    }

                //}
            }

            //foreach (var blanc in _viewsBanco.Blancs)
            //{
            //    string tag = blanc.LineNumberTag; 
            //    if (tag != "" && tag != null)
            //    {
            //        var areaTagModelo = AreaTag.Criar(areaPlanejada, tag);
            //        if (AreaDoModeloEstaDeAcordoComAreaPlanejada(areaPlanejada, areaTagModelo))
            //        {
            //            var itemModelado = ConstroiItemModeladoDoTubo(areaPlanejada, blanc, tag, areaTagModelo);
            //            _repoItemModelado.InserirItemModelado(itemModelado);
            //        }
            //        else
            //        {
            //            if(areaZero == null)
            //            {
            //                areaZero = CriaAreaZero(areaPlanejada);
            //            }
            //            var areaTagModeloImprovisada = AreaTag.Improvisar(areaPlanejada.GUID_PROJETO);
            //            var itemModelado = ConstroiItemModeladoDoTubo(areaPlanejada, blanc, tag, areaTagModeloImprovisada);
            //            _repoItemModelado.InserirItemModelado(itemModelado);
            //        }

            //    }

            //}

            //foreach (var unidade in _viewsBanco.Unidades)
            //{
            //    string tag = unidade.LineNumberTag; 
            //    if (tag != "" && tag != null)
            //    {
            //        var areaTagModelo = AreaTag.Criar(areaPlanejada, tag);
            //        if (AreaDoModeloEstaDeAcordoComAreaPlanejada(areaPlanejada, areaTagModelo))
            //        {
            //            var itemModelado = ConstroiItemModeladoDeValvula(areaPlanejada, unidade, tag, areaTagModelo);
            //            _repoItemModelado.InserirItemModelado(itemModelado);
            //        }
            //        else
            //        {
            //            if (areaZero == null)
            //            {
            //                areaZero = CriaAreaZero(areaPlanejada);
            //            }
            //            var areaTagModeloImprovisada = AreaTag.Improvisar(areaPlanejada.GUID_PROJETO);
            //            var itemModelado = ConstroiItemModeladoDeValvula(areaPlanejada, unidade, tag, areaTagModeloImprovisada);
            //            _repoItemModelado.InserirItemModelado(itemModelado);
            //        }

            //    }
            //}

        }

        private AreaPlanejada CriaAreaZero(AreaPlanejada areaPlanejada)
        {
            AreaPlanejada areaZero = new AreaPlanejada(areaPlanejada.GUID_PROJETO, "00", "00",
                                            areaPlanejada.SiglaProjeto, "Base", new Versao(0, "Processamento", "Improviso", DateTime.Now));
            _repoAreasPlanejadas.Cadastrar(areaZero);
            return areaZero;
        }

        private void ListaCategorias(string filename, string guidProjeto)
        {
            string filenamePiping = $"{filename}\\Piping.dcf";
            //var lista = new List<List<Dictionary<object, object>>>();

            var listaViews = new List<string>();

            

            List<string> excessoes = new List<string> { "Port_PNP","P3dConnector_PNP", "P3dLineGroup_PNP",
                "P3dPartConnection_PNP", "P3dDrawingLineGroupRelationship_PNP", "PnPTagRegistry_PNP", "PnPBase_PNP",
                "PnPTagRegistries_PNP", "PnPDrawings_PNP", "PnPTagEnlistedColumns_PNP", "PnPProjectCategories_PNP",
                "PnPProject_PNP", "PnPDrawingCategories_PNP","PnPPicklists_PNP","PnPPicklistValues_PNP","PnPProjectVariables_PNP",
                "PnPTagFormat_PNP","EngineeringItems_PNP","ColorSettings_PNP",
                "Equipment_PNP",
                "LayerColorGlobalSettings_PNP","LayerColorSchemeAssignment_PNP","PipeRunComponent_PNP","Support_PNP",
                "PnPWorkHistory_PNP","AssetOwnership_PNP","PnPDataLinks_PNP","PartPort_PNP",
                "SteelStructure_PNP","StructureMember_PNP","StructureRailing_PNP","StructureStair_PNP","BoltSet_PNP",
                "StructureLadder_PNP","P3dLineGroupPartRelationship_PNP","_PNP","Pipe_PNP","HeatExchanger_PNP","Nozzle_PNP","Buttweld_PNP",
                "Pump_PNP","Compressor_PNP","ESPESSADOR_PNP","Tank_PNP","GlobalEquipment_PNP","Blower_PNP","Vessel_PNP"
            };

            BIM360DataContext recordContext = new BIM360DataContext(filenamePiping, "BIM360", "Pipe_PNP");



           

            using (var command = recordContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'view'";
                recordContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    int indice = 0;

                    while (result.Read())
                    {



                        listaViews.Add(result.GetFieldValue<string>(0));

                        indice++;


                    }


                }
            }

            Versao versao = new Versao(0, "Plant3d", "Incio do Projeto", DateTime.Now);


            var pipePNPRecordRepositorio = new BlancPipeRecordRepositorio(recordContext);
            var blancsPipe = pipePNPRecordRepositorio.GetAll();

            foreach (var blanc in blancsPipe)
            {
                Coletados coleta = new Coletados(guidProjeto, versao, (BlancPipe)blanc);
                _repoColetados.CadastrarColetado(coleta);
            }



            foreach (var nomeView in listaViews)
            {


                if (!(excessoes.Contains(nomeView)))
                {
                    recordContext = new BIM360DataContext(filenamePiping, "BIM360", nomeView);
                    var valvePNPRecordRepositorio = new UnidadePipeRecordRepositorio(recordContext);
                    var unitarios = valvePNPRecordRepositorio.GetAll();

                    foreach (var unitario in unitarios)
                    {
                        Coletados coleta = new Coletados(guidProjeto, versao, (UnidadePipe)unitario);
                        _repoColetados.CadastrarColetado(coleta);
                    }
                }
                
            }




            //var coletados = repoColetadosPipe.ObterUltimaColeta(guidProjeto);


            //return coletados;

            //return null;
        }

        //private ItemModelado ConstroiItemModeladoDoTubo(AreaPlanejada areaPlanejada, BlancPipe blanc, string tag, AreaTag areaTag)
        //{

        //    ItemTag itemTag = new ItemTag(areaTag, "3D", tag, "");

        //    var itemModel = new ItemModelado(itemTag, GuidProjeto, blanc.PnPID.ToString(), blanc.PartFamilyLongDesc,
        //        blanc.PartSizeLongDesc, "QtdLinear", 0, (double)blanc.Length, 0, 0);
        //    itemModel.Comprimento = (double)blanc.Length;
        //    return itemModel;
        //}

        //private ItemModelado ConstroiItemModeladoDeValvula(AreaPlanejada areaPlanejada, UnidadePipe unidade, string tag, AreaTag areaTag)
        //{

        //    ItemTag itemTag = new ItemTag(areaTag, "3D", tag, "");

        //    var itemModel = new ItemModelado(itemTag, GuidProjeto, unidade.PnPID.ToString(), unidade.PartFamilyLongDesc,
        //        unidade.PartSizeLongDesc, "QtdUnitaria", 1, 0, 0, 0);
        //    itemModel.Comprimento = 1.0;
        //    return itemModel;
        //}

        private static bool AreaDoModeloEstaDeAcordoComAreaPlanejada(AreaPlanejada areaPlanejada, AreaTag areaModelo)
        {
            return areaModelo != null && areaModelo.Area == areaPlanejada.Area && areaModelo.SubArea == areaPlanejada.SubArea;
        }

        //private static string extraiTagViewDoBanco(Dictionary<object, object> itemViewBanco)
        //{
        //    return itemViewBanco["LineNumberTag"] == null ? "" : itemViewBanco["LineNumberTag"].ToString();
        //}

        //private List<List<Dictionary<object, object>>> ListaCategorias(string database)
        //{
        //    var lista = new List<List<Dictionary<object, object>>>();
        //    lista.Add(TotaisSQL.GetView(database, "Pipe"));
        //    lista.Add(TotaisSQL.GetView(database, "Valve"));

        //    return lista;
        //}



    }
}
