using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using System.Collections.Generic;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public abstract class ColecaoItensModelados
    {
        protected RepoItemModelado _repoItemModelado;
        protected List<List<Dictionary<object, object>>> _viewsBanco;

        public ColecaoItensModelados(string dataBaseProjeto, string guidProjeto)
        {
            DataBaseProjeto = dataBaseProjeto;
            GuidProjeto = guidProjeto;

            _repoItemModelado = new RepoItemModelado();


        }

        public string DataBaseProjeto { get; set; }
        public string GuidProjeto { get; set; }

        public abstract void ColetarItens(AreaPlanejada areaPlanejada);

    }
}
