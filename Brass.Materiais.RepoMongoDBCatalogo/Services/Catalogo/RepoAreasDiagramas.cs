using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoAreasDiagramas
    {

        BaseMDBRepositorio<AreaTag> _repoAreasDiagramas;



        public RepoAreasDiagramas()
        {
            _repoAreasDiagramas = new BaseMDBRepositorio<AreaTag>("BIM_TESTE", "AreasDiagrama");
        }



        //public AreaTag CadastrarAreaDeDesenhoDiagrama(string guidProjeto, AreaPlanejada areaPlanejada, string[] tagSeperado)
        //{
        //    foreach (var parteTitulo in tagSeperado)
        //    {
        //        var textoExtraidoDoTag = parteTitulo.Trim();

        //        if (PertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
        //        {
        //            return new AreaTag(
        //                      guidProjeto,
        //                      areaPlanejada.Area,
        //                      areaPlanejada.SubArea,
        //                      areaPlanejada.Nome
        //                    );
        //        }

        //    }

        //    return null;

        //}

        //private bool PertenceAareaPlanejada(AreaPlanejada areaPlanejada, string areaSubArea)
        //{
        //    return (areaSubArea.Length == 6 || areaSubArea.Length == 4)
        //                                    && (areaSubArea.Substring(0, 2) == areaPlanejada.Area && areaSubArea.Substring(2, 2) == areaPlanejada.SubArea);
        //}

       



        public List<AreaTag> ObterAreasDosDiagramasDoProjeto(string guidProjeto)
        {
            return _repoAreasDiagramas.Encontrar(Builders<AreaTag>.Filter.Eq(x => x.GUID_PROJETO, guidProjeto));
        }





    }
}
