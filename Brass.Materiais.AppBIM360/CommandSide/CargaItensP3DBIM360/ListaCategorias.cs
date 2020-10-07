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
    public class ListaCategorias
    {

        string _filename;
        string _guidProjeto;

        public ListaCategorias(string filename, string guidProjeto)
        {

        }


        public List<Coletado> ListarBlancs()
        {

            List<Coletado> coletados = new List<Coletado>();

            string filenamePiping = $"{_filename}\\Piping.dcf";


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
                "Pump_PNP","Compressor_PNP","ESPESSADOR_PNP","Tank_PNP","GlobalEquipment_PNP","Blower_PNP","Vessel_PNP", "PipeBendGroup_PNP",
                "PipeBendGroupRelationship_PNP"
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
                Coletado coleta = new Coletado(_guidProjeto, versao, (BlancPipe)blanc);
                //_repoColetados.CadastrarColetado(coleta);
                coletados.Add(coleta);
            }

            return coletados;

            

        }


        public List<Coletado> ListarUnidades()
        {

            List<Coletado> coletados = new List<Coletado>();

            string filenamePiping = $"{_filename}\\Piping.dcf";


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
                "Pump_PNP","Compressor_PNP","ESPESSADOR_PNP","Tank_PNP","GlobalEquipment_PNP","Blower_PNP","Vessel_PNP", "PipeBendGroup_PNP",
                "PipeBendGroupRelationship_PNP"
            };

            BIM360DataContext recordContext = new BIM360DataContext(filenamePiping, "BIM360", "Pipe_PNP");





            //using (var command = recordContext.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'view'";
            //    recordContext.Database.OpenConnection();
            //    using (var result = command.ExecuteReader())
            //    {
            //        int indice = 0;

            //        while (result.Read())
            //        {



            //            listaViews.Add(result.GetFieldValue<string>(0));

            //            indice++;


            //        }


            //    }
            //}

            Versao versao = new Versao(0, "Plant3d", "Incio do Projeto", DateTime.Now);


            //var pipePNPRecordRepositorio = new BlancPipeRecordRepositorio(recordContext);
            //var blancsPipe = pipePNPRecordRepositorio.GetAll();

            //foreach (var blanc in blancsPipe)
            //{
            //    Coletado coleta = new Coletado(guidProjeto, versao, (BlancPipe)blanc);
            //    _repoColetados.CadastrarColetado(coleta);
            //}



            foreach (var nomeView in listaViews)
            {


                if (!(excessoes.Contains(nomeView)))
                {
                    recordContext = new BIM360DataContext(filenamePiping, "BIM360", nomeView);
                    var valvePNPRecordRepositorio = new UnidadePipeRecordRepositorio(recordContext);
                    var unitarios = valvePNPRecordRepositorio.GetAll();

                    foreach (var unitario in unitarios)
                    {
                        Coletado coleta = new Coletado(_guidProjeto, versao, (UnidadePipe)unitario);
                        // _repoColetados.CadastrarColetado(coleta);
                        coletados.Add(coleta);
                    }
                }

            }

            return coletados;

        }
    }
}
