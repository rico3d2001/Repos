using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppVPN.CommandSide.CarregarItensPQPipe
{
    public class CarregarItensPQPipeCommand : Notifiable, IRequest
    {


        public CarregarItensPQPipeCommand(IdentidadeEstado identidadeEstado)//string dataBaseProjeto, string guidProjeto)
        {

            IdentidadeEstado = identidadeEstado;

            RepoProjetos repoProjetos = new RepoProjetos();
            
            var projeto = repoProjetos.ObterProjeto(IdentidadeEstado.GuidProjeto);

            // var areasPlanejadasProjeto = new RepoAreasPlanejadas().EncontrarAreasPlanejadasPorProjeto(request.GuidProjeto);

            //var databaseNexa = "_bdb1922_PnId";
            //var databaseNexa = "_bdb1922_Piping";



            
            var dataBaseProjetoPnId = $"_{projeto.Sigla.ToLower()}_PnId";
            var dataBaseProjetoPiping = $"_{projeto.Sigla.ToLower()}_Piping";
            ColecaoItensDiagrama = new ColecaoVPNItensDiagrama(dataBaseProjetoPnId, IdentidadeEstado.GuidProjeto);
            ColecaoItensModelados = new ColecaoVPNItensModelados(dataBaseProjetoPiping, IdentidadeEstado.GuidProjeto);

            //switch (IdResumoCorrente.Origem)
            //{
            //    case "VPN":
            //        {
            //            var dataBaseProjetoPnId = $"_{projeto.Sigla.ToLower()}_PnId";
            //            var dataBaseProjetoPiping = $"_{projeto.Sigla.ToLower()}_Piping";
            //            ColecaoItensDiagrama = new ColecaoVPNItensDiagrama(dataBaseProjetoPnId, IdResumoCorrente.GuidProjeto);
            //            ColecaoItensModelados = new ColecaoVPNItensModelados(dataBaseProjetoPiping, IdResumoCorrente.GuidProjeto);
            //        }
            //        break;

            //    case "BIM360":
            //        {
            //            var dataBaseProjetoPnId = @"C:\Users\rpinto\Documents\Project PQ1\ProcessPower.dcf";
            //            var dataBaseProjetoPiping = @"C:\Users\rpinto\Documents\Project PQ1\Piping.dcf"; //$"_{projeto.Sigla.ToLower()}_Piping";
            //            ColecaoItensDiagrama = new ColecaoBIM360ItensDiagrama(dataBaseProjetoPnId, IdResumoCorrente.GuidProjeto);
            //            ColecaoItensModelados = new ColecaoBIM360ItensModelados(dataBaseProjetoPiping, IdResumoCorrente.GuidProjeto);
            //        }
            //        break;
            //}





        }

        //public string DataBaseProjetoPnId { get; set; }
        //public string DataBaseProjetoPiping { get; set; }
        public IdentidadeEstado IdentidadeEstado { get; set; }

        public ColecaoVPNItensDiagrama ColecaoItensDiagrama { get; set; }
        public ColecaoVPNItensModelados ColecaoItensModelados { get; set; }


    }
}
