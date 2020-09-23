using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoDapperSQLServer.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System.Collections.Generic;
using System.Linq;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class ColecaoVPNItensDiagrama 
    {

         RepoItemDiagramasPlant3d _repoItemPQ;
         RepoFamilia _repoFamilia;
         RepoItemPipe _repoItemPipe;
      


        public ColecaoVPNItensDiagrama(string dataBaseProjeto, string guidProjeto)
        {
            DataBaseProjeto = dataBaseProjeto;
            GuidProjeto = guidProjeto;
            _repoItemPQ = new RepoItemDiagramasPlant3d();
            _repoFamilia = new RepoFamilia();
            _repoItemPipe = new RepoItemPipe();
        }

        public string DataBaseProjeto { get; set; }
        public string GuidProjeto { get; set; }


        public void ColetarItens(AreaPlanejada areaPlanejada)
        {
            var collection = LinhasPipeSQL.GetItensArea(DataBaseProjeto, areaPlanejada.Area + areaPlanejada.SubArea);

            foreach (var item in collection)
            {

                if (itemPQNaoEstaCadastradoNestaArea(obterItemPQ(areaPlanejada, item)))
                {
                    string specPart = item["Spec Part"] == null ? "" : item["Spec Part"].ToString();

                    if(specPart != "")
                    {
                        string tag = item["Tag"].ToString();
                        string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();



                        var itemPipe = specPart == "" ? null : new RepoItemPipe().ObterPorDescricaoComplexa(specPart, "");

                     
                        var itemPQ = ItemPQ.ConstruirItemPQDoDiagrama(areaPlanejada, itemPipe, tag, pnPID, specPart);
                        new RepoItemDiagramasPlant3d().InserirItemDiagramaPlant3d(itemPQ);
                    }
                   




                }

            }
        }

        private string TransformaEmDescricaoDeFamilia(string specPart)
        {
            var array = specPart.Split('-');

            var dimensao = array.Last();

            var resposta = specPart.TrimEnd(dimensao.ToCharArray());

            return resposta.TrimEnd('-').Trim();

        }

        private ItemPQ obterItemPQ(AreaPlanejada areaPlanejada, Dictionary<object, object> item)
        {
            return _repoItemPQ.ObterItemPQ(areaPlanejada.Area, areaPlanejada.SubArea, item["Spec Part"].ToString());
        }

        private bool itemPQNaoEstaCadastradoNestaArea(ItemPQ itemPQ)
        {
            return itemPQ == null;
        }

        //private ItemPQ cadastrarItemPQ(AreaTag areaDesenhoDiagrama, dynamic item, AreaPlanejada areaPlanejada)
        //{
        //    if (areaDesenhoDiagrama != null && areaDesenhoDiagrama.Area == areaPlanejada.Area && areaDesenhoDiagrama.SubArea == areaPlanejada.SubArea)
        //    {


        //        //string area = item["AREA"] == null ? "" : item["AREA"].ToString();
        //        string tag = item["Tag"] == null ? "" : item["Tag"].ToString();

        //        string pnPID = item["PnPID"] == null ? "" : item["PnPID"].ToString();
        //        string specPart = item["Spec Part"] == null ? "" : item["Spec Part"].ToString();


        //        ItemTag itemTag = new ItemTag(GuidProjeto, areaDesenhoDiagrama, "Diagrama", tag, "");

        //        var itemPipe = new RepoItemPipe().Obter(specPart, "");

        //        return new ItemPQ(GuidProjeto, "RRP", itemTag, pnPID, specPart, itemPipe);




        //    }

        //    return null;

        //}



    }
}
