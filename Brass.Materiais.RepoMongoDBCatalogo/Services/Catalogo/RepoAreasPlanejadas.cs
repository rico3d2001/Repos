using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoAreasPlanejadas
    {
        BaseMDBRepositorio<AreaPlanejada> _repoAreasPlanejadas;
        public RepoAreasPlanejadas()
        {
            _repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
        }

        public List<AreaPlanejada> EncontrarAreasPlanejadasPorProjeto(string guidProjeto)
        {
            return _repoAreasPlanejadas.Encontrar(
                  Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjeto));
        }

        public void Cadastrar(AreaPlanejada areaUnica)
        {
            _repoAreasPlanejadas.Inserir(areaUnica);
        }

        public AreaPlanejada ObterAreaZero(string guidProjeto)
        {
            var areas = _repoAreasPlanejadas.Encontrar(
                  Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, guidProjeto)
                  & Builders<AreaPlanejada>.Filter.Eq(x => x.Area, "00")
                  & Builders<AreaPlanejada>.Filter.Eq(x => x.SubArea, "00"));

            return areas.FirstOrDefault();
        }
    }
}
