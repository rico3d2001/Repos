using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterEAP
{
    public class ObterEAPQueryHandle : Notifiable, IRequestHandler<ObterEAPQuery, EAP>
    {
        BaseMDBRepositorio<AreaPlanejada> _repoAreasPlanejadas;

        public ObterEAPQueryHandle()
        {
            _repoAreasPlanejadas = new BaseMDBRepositorio<AreaPlanejada>("BIM", "AreasPlanejadas");
        }
        public Task<EAP> Handle(ObterEAPQuery request, CancellationToken cancellationToken)
        {
        

            var areasPlanejadasProjeto = _repoAreasPlanejadas.Encontrar(
                  Builders<AreaPlanejada>.Filter.Eq(x => x.GUID_PROJETO, request.GuidProjeto));

            var eap = cargaEAP(areasPlanejadasProjeto);

            return Task.FromResult(eap);
        }

        private EAP cargaEAP(List<AreaPlanejada> areasPlanejadasProjeto)
        {

            var conexao = "Plant3d_Diagramas";
            var caminho = new List<string>();
            EAP eap = null;
   
            var listaAreas = new List<Area>();

            

            

            string guidProjetoNexa = "48e9eb46-5a26-4b9c-9a53-163d448336fb";

           

            string siglaProjeto = "BdB1922";

            string nomeProjeto = "NEXA_BONSUCESSO";

       
            var tipo = "Processo";

            //var repoEAP = new BaseMDBRepositorio<EAP>("BIM", "EAPTubulacao");

            //var pnPDrawings = GetPnPDrawings.GetItens(siglaProjeto, tipo);

  
            Area novaArea = null;

            eap = new EAP(siglaProjeto, nomeProjeto);




            var grupos = areasPlanejadasProjeto.GroupBy(x => x.Area).OrderBy(x => x.Key).ToList();


            //areasPlanejadasProjeto.OrderBy(x => x.Area);



            foreach (var subAreas in grupos)
            {

                foreach (var subArea in subAreas)
                {



                    //var numeroArea = areaPlanejada//numero.Substring(0, 2);
                ///var numeroSubArea = numero.Substring(2, 2);

                    //var nomePastaSuperior = paths.Reverse().ElementAt(1);

                    //var areaPlanejada = areasPlanejadasProjeto
                        //.FirstOrDefault(x => x.Area == numeroArea && x.SubArea == numeroSubArea);

                    //if (areaPlanejada != null)
                    //{
                        novaArea = new Area("", "Processo", subArea.Area, subArea.SubArea, subArea.Nome);

              

                    //    if (listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior) != null)
                    //    {
                    //        var areaSuperior = listaAreas.FirstOrDefault(x => x.NomeArea == nomePastaSuperior);
                    //        areaSuperior.AdicionaArea(novaArea);
                    //    }
                    //    else
                    //    {
                          eap.AdicionaArea(novaArea);
                    //    }


                    //}
                }

            }

            //listaAreas.Add(novaArea);













            //repoEAP.Inserir(eap);

            return eap;



            
        }






    }
}
