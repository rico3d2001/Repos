using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using Brass.Materiais.Nucleo.ValueObjects;
using Brass.Materiais.RepoComumPlantEF.Services;
using Brass.Materiais.RepoDapperSQLServer.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class ColecaoVPNItensModelados
    {
        RepoItemModelado _repoItemModelado;
        //List<Coletados> _viewsBanco;
        RepoAreasPlanejadas _repoAreasPlanejadas;
        RepoColetadosPipe _repoColetados;

        public ColecaoVPNItensModelados(string dataBaseProjeto, string guidProjeto)
        {
            DataBaseProjeto = dataBaseProjeto;
            GuidProjeto = guidProjeto;

            _repoItemModelado = new RepoItemModelado();
            _repoAreasPlanejadas = new RepoAreasPlanejadas();
            _repoColetados = new RepoColetadosPipe();
            TotaisSQL.GetViewPipe(dataBaseProjeto, guidProjeto);
            //ListaCategorias(DataBaseProjeto);
        }

        public string DataBaseProjeto { get; set; }
        public string GuidProjeto { get; set; }


        public void ColetarItens(AreaPlanejada areaPlanejada)
        {

            var coletados = _repoColetados.ObterUltimaColeta(areaPlanejada.GUID_PROJETO,0);

            var areaZero = _repoAreasPlanejadas.ObterAreaZero(areaPlanejada.GUID_PROJETO);

            foreach (var coletado in coletados)
            {
                string tag = coletado.ComponentePlant.LineNumberTag;
                if (tag != "" && tag != null)
                {
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

            }
        }

            //var unidades = _repoColetados.ObterComponentes(areaPlanejada.GUID_PROJETO, 0);

            //foreach (var unidade in unidades)
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

        

        //private ItemModelado ConstroiItemModelado(AreaPlanejada areaPlanejada, Dictionary<string, string> propriedadesDoItemViewBanco, string tag, AreaTag areaTag)
        //{
        //    string pnPID = propriedadesDoItemViewBanco["PnPID"] == null ? "" : propriedadesDoItemViewBanco["PnPID"].ToString();
        //    double comprimento = propriedadesDoItemViewBanco["Length"] == null ? 0.0 : double.Parse(propriedadesDoItemViewBanco["Length"].ToString());
        //    string descricaoLonga = propriedadesDoItemViewBanco["PartFamilyLongDesc"] == null ? "" : propriedadesDoItemViewBanco["PartFamilyLongDesc"].ToString();
        //    string descricaoLongaDimensionada = propriedadesDoItemViewBanco["PartSizeLongDesc"] == null ? "" : propriedadesDoItemViewBanco["PartSizeLongDesc"].ToString();
        //    string partCategory = propriedadesDoItemViewBanco["PartCategory"] == null ? "" : propriedadesDoItemViewBanco["PartCategory"].ToString();
        //    //var areaTag = AreaTag.Criar(GuidProjeto, areaPlanejada, tag);

        //    string tipoQuantidade = "";
        //    switch (partCategory)
        //    {
        //        case "Pipe":
        //            tipoQuantidade = "QtdLinear";
        //            break;
        //        default:
        //            tipoQuantidade = "";
        //            break;
        //    }

        //    ItemTag itemTag = new ItemTag(areaTag, "3D", tag, "");

        //    var itemModel = new ItemModelado(itemTag, GuidProjeto, pnPID, descricaoLonga,
        //        descricaoLongaDimensionada, tipoQuantidade, 0, comprimento, 0, 0);
        //    itemModel.Comprimento = comprimento;
        //    return itemModel;
        //}

        private static bool AreaDoModeloEstaDeAcordoComAreaPlanejada(AreaPlanejada areaPlanejada, AreaTag areaModelo)
        {
            return areaModelo != null && areaModelo.Area == areaPlanejada.Area && areaModelo.SubArea == areaPlanejada.SubArea;
        }

        private static string extraiTagViewDoBanco(Dictionary<string, string> itemViewBanco)
        {
            return itemViewBanco["LineNumberTag"] == null ? "" : itemViewBanco["LineNumberTag"].ToString();
        }

       




    }
}
