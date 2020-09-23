using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class CarregarItensPQPipeCommandHandler : Notifiable, IRequestHandler<CarregarItensPQPipeCommand>
    {
    

        public async Task<Unit> Handle(CarregarItensPQPipeCommand request, CancellationToken cancellationToken)
        {
  
            var areasPlanejadasProjeto = new RepoAreasPlanejadas().EncontrarAreasPlanejadasPorProjeto(request.IdentidadeEstado.GuidProjeto);

            ColetarItensPorArea(request, areasPlanejadasProjeto);

            CadastrarItensPorArea(request, areasPlanejadasProjeto);

            return Unit.Value;
        }

        private static void ColetarItensPorArea(CarregarItensPQPipeCommand request, List<AreaPlanejada> areasPlanejadasProjeto)
        {
            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {
                request.ColecaoItensDiagrama.ColetarItens(areaPlanejada);
                request.ColecaoItensModelados.ColetarItens(areaPlanejada);
            }
        }

        private void CadastrarItensPorArea(CarregarItensPQPipeCommand request, List<AreaPlanejada> areasPlanejadasProjeto)
        {
   
            var cadastroItensDiagramas = new CadastroItensDiagramas(request.IdentidadeEstado.GuidProjeto);

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {
              
                cadastroItensDiagramas.CadastrarItens(areaPlanejada);

                var cadastroItensSomenteModelados = 
                    new CadastroItensSomenteModelados(cadastroItensDiagramas.ObtemItensModeladosNaoIncluidosEmItemDiagrama(), request.IdentidadeEstado.GuidProjeto);

                cadastroItensSomenteModelados.CadastrarItens(areaPlanejada);

            }
        }





















    }
}
