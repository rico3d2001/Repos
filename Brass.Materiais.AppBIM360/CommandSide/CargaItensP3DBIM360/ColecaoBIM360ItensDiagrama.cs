using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.TabelasPlant;
using Brass.Materiais.RepoComumPlantEF.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using System.Linq;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class ColecaoBIM360ItensDiagrama
    {

      
        RepoItemDiagramasPlant3d _repoItemPQ;
        RepoFamilia _repoFamilia;
        RepoItemPipe _repoItemPipe;
   



        public ColecaoBIM360ItensDiagrama(string filename, string guidProjeto)
        {
            Filename = filename;
            GuidProjeto = guidProjeto;
            _repoItemPQ = new RepoItemDiagramasPlant3d();
            _repoFamilia = new RepoFamilia();
            _repoItemPipe = new RepoItemPipe();
        }

        public string Filename { get; set; }
        public string GuidProjeto { get; set; }

        public void ColetarItens(AreaPlanejada areaPlanejada, string filename)
        {
           
            var areaDeBusca = areaPlanejada.Area + areaPlanejada.SubArea;

            BIM360DataContext recordContext = new BIM360DataContext(filename, "BIM360","");
            var pipeLineRecordRepositorio = new PipeLineRecordRepositorio(recordContext);

            var pipelines = pipeLineRecordRepositorio.GetAll();

            var pipeLinesFiltradasPorArea =pipelines.Where(x => x.Tag.Contains(areaDeBusca)).ToList();

          
            foreach (var pipeline in pipeLinesFiltradasPorArea)
            {
                if (itemPQNaoEstaCadastradoNestaArea(obterItemPQ(areaPlanejada, pipeline)))
                {
                    var itemPipe = pipeline.SpecPart == "" ? null : new RepoItemPipe().ObterPorDescricaoComplexa(pipeline.SpecPart, "");

                   

                    var itemPQ = ItemPQ.ConstruirItemPQDoDiagrama(areaPlanejada, itemPipe, pipeline.Tag, pipeline.PnPID.ToString(), pipeline.SpecPart);
                    new RepoItemDiagramasPlant3d().InserirItemDiagramaPlant3d(itemPQ);
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

        private ItemPQ obterItemPQ(AreaPlanejada areaPlanejada, PipeLine pipeLine)
        {
            return _repoItemPQ.ObterItemPQ(areaPlanejada.Area, areaPlanejada.SubArea, pipeLine.SpecPart);
        }

        private bool itemPQNaoEstaCadastradoNestaArea(ItemPQ itemPQ)
        {
            return itemPQ == null;
        }

       
    }
}
