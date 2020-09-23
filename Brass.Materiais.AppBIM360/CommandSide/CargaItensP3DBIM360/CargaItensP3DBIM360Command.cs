using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class CargaItensP3DBIM360Command : Notifiable, IRequest
    {
        public CargaItensP3DBIM360Command(IdentidadeEstado identidadeEstado)//string dataBaseProjeto, string guidProjeto)
        {

            RepoProjetos repoProjetos = new RepoProjetos();

            var projeto = repoProjetos.ObterProjeto(IdentidadeEstado.GuidProjeto);

            // var areasPlanejadasProjeto = new RepoAreasPlanejadas().EncontrarAreasPlanejadasPorProjeto(request.GuidProjeto);

            //var databaseNexa = "_bdb1922_PnId";
            //var databaseNexa = "_bdb1922_Piping";



            IdentidadeEstado = identidadeEstado;

            Endereco = projeto.Endereco;
            //var arquivoPnId = $"{idResumoCorrente.Endereco}\\ProcessPower.dcf";
            //var arquivoPiping = $"{idResumoCorrente.Endereco}\\Piping.dcf";
            ColecaoBIM360ItensDiagrama = new ColecaoBIM360ItensDiagrama(projeto.Endereco, IdentidadeEstado.GuidProjeto);
            ColecaoBIM360ItensModelados = new ColecaoBIM360ItensModelados(projeto.Endereco, IdentidadeEstado.GuidProjeto);

           





        }

        
        


        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string Endereco { get; set; }

        public ColecaoBIM360ItensDiagrama ColecaoBIM360ItensDiagrama { get; set; }
        public ColecaoBIM360ItensModelados ColecaoBIM360ItensModelados { get; set; }
    }
}
