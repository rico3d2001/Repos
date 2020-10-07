using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class CargaItensP3DBIM360CommandHandler : Notifiable, IRequestHandler<CargaItensP3DBIM360Command>
    {


        public async Task<Unit> Handle(CargaItensP3DBIM360Command request, CancellationToken cancellationToken)
        {
            var areasPlanejadasProjeto = new RepoNumerosAtivos().EncontrarAreasPlanejadasPorProjeto(request.IdentidadeEstado.Projeto.GUID);

            ColetarItensPorArea(request, areasPlanejadasProjeto);

            CadastrarItensPorArea(request, areasPlanejadasProjeto);

            return Unit.Value;
        }


     

        private static void ColetarItensPorArea(CargaItensP3DBIM360Command request, List<AreaTag> areasPlanejadasProjeto)
        {
            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {
               var filePiping = $"{request.IdentidadeEstado.Projeto.Endereco}\\ProcessPower.dcf";
                request.ColecaoBIM360ItensDiagrama.ColetarItens(areaPlanejada, filePiping);
                
                request.ColecaoBIM360ItensModelados.ColetarItens(request.IdentidadeEstado.Projeto,areaPlanejada);
            }
        }

        

        private void CadastrarItensPorArea(CargaItensP3DBIM360Command request, List<AreaTag> areasPlanejadasProjeto)
        {

            var cadastroItensDiagramasBIM360 = new CadastroItensDiagramasBIM360(request.IdentidadeEstado.Projeto.GUID);

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {

                cadastroItensDiagramasBIM360.CadastrarItens(areaPlanejada);

                var cadastroItensSomenteModelados =
                    new CadastroItensSomenteModeladosBIM360(cadastroItensDiagramasBIM360.ObtemItensModeladosNaoIncluidosEmItemDiagrama(), request.IdentidadeEstado.Projeto.GUID);

                cadastroItensSomenteModelados.CadastrarItens(areaPlanejada);

            }
        }
    }
}
