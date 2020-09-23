using Brass.Materiais.DominioPQ.BIM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo
{
    public class RepoEAP
    {
        BaseMDBRepositorio<EAP> _repoEAP;

        public RepoEAP()
        {
            _repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPGeral");
        }

        public void CadastrarEAPAreaUnica(AreaPlanejada areaPlanejadaUnica, Projeto projeto)
        {

            


      

            var eap = new EAP(projeto.GUID, projeto.NomeProjeto);

            var novaArea = new Area("", "Processo", areaPlanejadaUnica.Area, areaPlanejadaUnica.SubArea, areaPlanejadaUnica.Nome);

  
            eap.AdicionaArea(novaArea);

            _repoEAP.Inserir(eap);

        }
    }
}
