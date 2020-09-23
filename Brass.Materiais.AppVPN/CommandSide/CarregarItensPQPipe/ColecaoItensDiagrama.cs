using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public abstract class ColecaoItensDiagrama
    {
        protected RepoItemDiagramasPlant3d _repoItemPQ;
        protected RepoFamilia _repoFamilia;
        protected RepoItemPipe _repoItemPipe;
        public ColecaoItensDiagrama(string dataBaseProjeto, string guidProjeto)
        {
            DataBaseProjeto = dataBaseProjeto;
            GuidProjeto = guidProjeto;
            _repoItemPQ = new RepoItemDiagramasPlant3d();
            _repoFamilia = new RepoFamilia();
            _repoItemPipe = new RepoItemPipe();

        }

        public string DataBaseProjeto { get; set; }
        public string GuidProjeto { get; set; }

        public abstract void ColetarItens(AreaPlanejada areaPlanejada);

    }
}
