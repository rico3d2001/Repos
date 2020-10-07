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
    public class RepoAreasDiagramas: RepositorioAbstratoGeral
    {

        BaseMDBRepositorio<AreaTag> _repoAreasDiagramas;



        public RepoAreasDiagramas(string conectionString) : base(conectionString)
        {
            _repoAreasDiagramas = new BaseMDBRepositorio<AreaTag>(new ConexaoMongoDb("BIM_TESTE", conectionString), "AreasDiagrama");
        }



      

       



        public List<AreaTag> ObterAreasDosDiagramasDoProjeto(string guidProjeto)
        {
            return _repoAreasDiagramas.Encontrar(Builders<AreaTag>.Filter.Eq(x => x.GUID_PROJETO, guidProjeto));
        }





    }
}
