using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.RepoDapperSQLServer.Service;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Services.CommandSide;
using Flunt.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class CarregarItensPQPipeCommandHandler : Notifiable, IRequestHandler<CarregarItensPQPipeCommand>
    {

        RepoLinhas _repoLinhas;
        RepoItemPQ _repoItemPQ;

      
      

        public async Task<Unit> Handle(CarregarItensPQPipeCommand request, CancellationToken cancellationToken)
        {
            _repoLinhas = new RepoLinhas(request.TextoConexao);
            _repoItemPQ = new RepoItemPQ(request.TextoConexao);

            if (_repoItemPQ.NuncaFoiCadastrado(request.IdentidadeEstado.GuidProjeto))
            {
                var colecaoItensDiagrama = new ColecaoItensDiagrama(request.IdentidadeEstado.GuidProjeto, request.TextoConexao);
                var colecaoItensModelados = new ColecaoItensModelados(request.DataBaseProjetoPiping, request.IdentidadeEstado.GuidProjeto, request.TextoConexao);

                var areas = new RepoNumerosAtivos(request.TextoConexao).EncontrarAreasPlanejadasPorProjeto(request.IdentidadeEstado.GuidProjeto);

                ColetarItensPorArea(colecaoItensDiagrama, colecaoItensModelados, areas, request.TextoConexao);

                CadastrarItensPorArea(request, areas,request.TextoConexao);
            }
         

            return Unit.Value;
        }

        private static void ColetarItensPorArea(ColecaoItensDiagrama colecaoItensDiagrama, ColecaoItensModelados colecaoItensModelados, List<NumeroAtivo> ativos, string conexao)//CarregarItensPQPipeCommand request, List<NumeroAtivo> ativos)
        {


            var coletadosDoProjeto = colecaoItensModelados.ObterColetadosDaArea(ativos.First().AreaTag.GUID_PROJETO,conexao);




            foreach (var ativo in ativos)
            {


                colecaoItensDiagrama.ColetarItensDiagrama(ativo, conexao);

               

                //List<Coletado> coletadosArea = filtrarColetadosPorArea(ativo, coletadosProjeto);

                colecaoItensModelados.ColetarItens(ativo, coletadosDoProjeto);
            }
        }

        private static List<Coletado> filtrarColetadosPorArea(NumeroAtivo ativo, List<Coletado> coletadosProjeto)
        {
            List<Coletado> coletadosArea = new List<Coletado>();
            foreach (var coletado in coletadosProjeto)
            {
                if (coletado.ComponentePlant.LineNumberTag == null || coletado.ComponentePlant.LineNumberTag.Split('-').First().Length < 6)
                {
                    if (ativo.AreaTag.Area == "00")
                    {
                        coletadosArea.Add(coletado);
                    }
                }
                else
                {
                    string area = coletado.ComponentePlant.LineNumberTag.Split('-').First().Substring(0, 2);
                    string subArea = coletado.ComponentePlant.LineNumberTag.Split('-').First().Substring(2, 2);

                    if (ativo.AreaTag.Area == area && ativo.AreaTag.SubArea == subArea)
                    {
                        coletadosArea.Add(coletado);
                    }
                }


            }

            return coletadosArea;
        }

        private void CadastrarItensPorArea(CarregarItensPQPipeCommand request, List<NumeroAtivo> areasPlanejadasProjeto, string conexao)
        {
   
            var cadastroItensDiagramas = new CadastroItensDiagramas(request.IdentidadeEstado.GuidProjeto, conexao);

            foreach (var areaPlanejada in areasPlanejadasProjeto)
            {
              
                cadastroItensDiagramas.CadastrarItens(areaPlanejada);

                var cadastroItensSomenteModelados = 
                    new CadastroItensSomenteModelados(cadastroItensDiagramas.ObtemItensModeladosNaoIncluidosEmItemDiagrama(), request.IdentidadeEstado.GuidProjeto, conexao);

                cadastroItensSomenteModelados.CadastrarItens(areaPlanejada, conexao);

            }
        }





















    }
}
