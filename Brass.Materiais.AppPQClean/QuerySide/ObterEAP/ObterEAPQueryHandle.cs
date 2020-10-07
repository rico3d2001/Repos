using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
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
        RepoNumerosAtivos _repoNumerosAtivos;
        //BaseMDBRepositorio<NumeroAtivo> _repoAreasPlanejadas;
        RepoProjetos _repoProjetos;

        public ObterEAPQueryHandle()
        {
            //_repoAreasPlanejadas = new BaseMDBRepositorio<NumeroAtivo>("BIM", "AreasPlanejadas");
            
        }
        public Task<EAP> Handle(ObterEAPQuery request, CancellationToken cancellationToken)
        {
            _repoProjetos = new RepoProjetos(request.TextoConexao);

            var projeto = _repoProjetos.ObterProjeto(request.GuidProjeto);

            _repoNumerosAtivos = new RepoNumerosAtivos(request.TextoConexao);

            

            var eap = cargaEAP(projeto);

            return Task.FromResult(eap);
        }

        private EAP cargaEAP(Projeto projeto)
        {

            
            var eap = new EAP(projeto.Sigla, projeto.NomeProjeto);

            var areas = _repoNumerosAtivos.EncontrarAreasPlanejadasPorProjeto(projeto.GUID);


            foreach (var area in areas)
            {
                var novaArea = new Area(projeto.GUID,"", "Processo", area.AreaTag.Area, area.AreaTag.SubArea,area.Sigla, area.AreaTag.Area);
                eap.AdicionaArea(novaArea);

                var subAreas = _repoNumerosAtivos.EncontrarSubAreas(area);
                foreach (var subArea in subAreas)
                {
                    var novaSubArea = new Area(projeto.GUID,"", "Processo", subArea.AreaTag.Area, subArea.AreaTag.SubArea, subArea.Sigla, subArea.AreaTag.SubArea);
                    novaArea.AdicionaArea(novaSubArea);

                    var ativos = _repoNumerosAtivos.EncontrarAtivos(area);
                    foreach (var ativo in ativos)
                    {

                        var novoAtivo = new Area(projeto.GUID,"", "Processo", ativo.AreaTag.Area, ativo.AreaTag.SubArea, ativo.Sigla, ativo.Sigla);
                        novaSubArea.AdicionaArea(novoAtivo);

                    }
                }
            }


            return eap;

        }






    }
}
