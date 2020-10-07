using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoEAP : RepositorioAbstratoGeral
    {
        BaseMDBRepositorio<EAP> _repoEAP;

        public RepoEAP(string conectionString) : base(conectionString)
        {
            _repoEAP = new BaseMDBRepositorio<EAP>(new ConexaoMongoDb("BIM", conectionString), "EAPGeral");
        }

        public void CadastrarEAPAreaUnica(NumeroAtivo ativo, Projeto projeto)
        {

            


      

            var eap = new EAP(projeto.GUID, projeto.NomeProjeto);

            //NumeroAtivo numeroAtivo = 
                //new NumeroAtivo(areaPlanejadaUnica.NumeroAtivo.Area, areaPlanejadaUnica.NumeroAtivo.SubArea, areaPlanejadaUnica.NumeroAtivo.Sigla);
            var novaArea = new Area(projeto.GUID, "", "Processo", ativo.AreaTag.Area, ativo.AreaTag.SubArea, ativo.Sigla, "");

  
            eap.AdicionaArea(novaArea);

            _repoEAP.Inserir(eap);

        }
    }
}
