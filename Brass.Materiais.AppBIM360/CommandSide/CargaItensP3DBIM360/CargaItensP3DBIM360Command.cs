using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Brass.Materiais.ServicoDominio.Services.CommandSide;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppBIM360.CommandSide.CargaItensP3DBIM360
{
    public class CargaItensP3DBIM360Command : Notifiable, IRequest
    {
        public CargaItensP3DBIM360Command(IdentidadeEstado identidadeEstado)//string dataBaseProjeto, string guidProjeto)
        {

            //RepoProjetos repoProjetos = new RepoProjetos();

            //var projeto = repoProjetos.ObterProjeto(IdentidadeEstado.Projeto.GUID);

            // var areasPlanejadasProjeto = new RepoAreasPlanejadas().EncontrarAreasPlanejadasPorProjeto(request.GuidProjeto);

            //var databaseNexa = "_bdb1922_PnId";
            //var databaseNexa = "_bdb1922_Piping";



            IdentidadeEstado = identidadeEstado;

            //Endereco = projeto.Endereco;
            //var arquivoPnId = $"{idResumoCorrente.Endereco}\\ProcessPower.dcf";
            //var arquivoPiping = $"{idResumoCorrente.Endereco}\\Piping.dcf";
            ColecaoBIM360ItensDiagrama = new ColecaoBIM360ItensDiagrama(identidadeEstado.Projeto.Endereco, IdentidadeEstado.Projeto.GUID);

            ListaCategorias listaCategorias = new ListaCategorias(identidadeEstado.Projeto.Endereco, IdentidadeEstado.Projeto.GUID);
            listaCategorias.ListarBlancs();
            listaCategorias.ListarUnidades();

            ColecaoItensModelados = new ColecaoItensModelados(identidadeEstado.Projeto.Endereco, IdentidadeEstado.Projeto.GUID);

           





        }

        
        


        public IdentidadeEstado IdentidadeEstado { get; set; }
        //public string Endereco { get; set; }

        public ColecaoBIM360ItensDiagrama ColecaoBIM360ItensDiagrama { get; set; }
        public ColecaoItensModelados ColecaoItensModelados { get; set; }
    }
}
