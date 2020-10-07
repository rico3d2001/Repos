using Brass.Materiais.DominioPQ.BIM.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoNumerosAtivos : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<NumeroAtivo> _repoAreasPlanejadas;
        public RepoNumerosAtivos(string conectionString) : base(conectionString)
        {
            _repoAreasPlanejadas = new BaseMDBRepositorio<NumeroAtivo>(new ConexaoMongoDb("BIM", conectionString), "AreasPlanejadas");
        }

        public List<NumeroAtivo> EncontrarAreasPlanejadasPorProjeto(string guidProjeto)
        {
            return _repoAreasPlanejadas.Encontrar(
                  Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.GUID_PROJETO, guidProjeto));
        }

        public void Cadastrar(NumeroAtivo areaUnica)
        {
            var areas = _repoAreasPlanejadas.Encontrar(
                  Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.GUID_PROJETO, areaUnica.AreaTag.GUID_PROJETO)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.Area, areaUnica.AreaTag.Area)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.SubArea, areaUnica.AreaTag.SubArea)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.Sigla, areaUnica.Sigla));

            if(!(areas.Count > 0)) _repoAreasPlanejadas.Inserir(areaUnica);
        }

        public NumeroAtivo ObterAreaZero(string guidProjeto)
        {
            var areas = _repoAreasPlanejadas.Encontrar(
                  Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.GUID_PROJETO, guidProjeto)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.Area, "00")
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.SubArea, "00")
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.Sigla, "00"));

            return areas.FirstOrDefault();
        }

        public List<NumeroAtivo> EncontrarSubAreas(NumeroAtivo area)
        {
            return _repoAreasPlanejadas.Encontrar(
                  Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.GUID_PROJETO, area.AreaTag.GUID_PROJETO)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.SubArea, area.AreaTag.SubArea));
        }

        public List<NumeroAtivo> EncontrarAtivos(NumeroAtivo area)
        {
            return _repoAreasPlanejadas.Encontrar(
                  Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.GUID_PROJETO, area.AreaTag.GUID_PROJETO)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.AreaTag.SubArea, area.AreaTag.SubArea)
                  & Builders<NumeroAtivo>.Filter.Eq(x => x.Sigla, area.Sigla));
        }
    }
}
