using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.PQ.AppNetCoreSQLite.CommandSide.CargaItensP3DBIM360;
using Brass.Materiais.PQ.AppNetCoreSQLite.QuerySide.ObterAreasTagsQueryBIM360;
using Brass.Materiais.PQ.Dominio.Servico.CommandSide.Commands.CargaItensPQDiagramas.BIM360;
using Brass.Materiais.RepositorioAppEFSQLite.Model;
using Brass.Materiais.RepositorioAppEFSQLite.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MaisNovosTestes
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Obter_Arreas_Por_Tag_No_BIM360()
        {
            var guidProjeto = "e20c0031-e1f7-4995-9c9d-a411e4da719e";
            var query = new ObterAreasTagsQueryBIM360Query(guidProjeto);
            var handler = new ObterAreasTagsQueryBIM360QueryHandler();

             var lista =   handler.Handle(query, CancellationToken.None);
        }



        [TestMethod]
        public void EntityFramework_SQLiteTeste()
        {
            //string filename = "C:\\Users\\rpinto\\Documents\\Project PQ1\\Piping.dcf";
            //string pastaProjeto = "C:\\Users\\rpinto\\Documents\\Project PQ1";
            //string guidProjeto = "e20c0031-e1f7-4995-9c9d-a411e4da719e";

            IdResumoCorrente idResumoCorrente = new IdResumoCorrente();
            idResumoCorrente.GuidProjeto = "e20c0031-e1f7-4995-9c9d-a411e4da719e";
            idResumoCorrente.Endereco = "C:\\Users\\rpinto\\Documents\\Project PQ1";

            //PipeRecordContext pipeRecordContext = new PipeRecordContext(filename);
            //IPipeRecordRepositorio pipeRecordRepositorio = new PipeRecordRepositorio(pipeRecordContext);

            //var lista = pipeRecordRepositorio.GetAll();

            var command = new CargaItensP3DBIM360Command(idResumoCorrente);

            var  handle = new CargaItensP3DBIM360CommandHandler();

            var resultado = handle.Handle(command, CancellationToken.None);



        }
    }
}
