using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ObtemArvoreCatalogo;
using Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.Testes.AppPQ.QuerySide.Queries
{
    [TestClass]
    public class ArvoreCatalogo_Testes
    {

        [TestMethod]
        public void A_ObtemArvoreCatalogo_Assertivo()
        {

            //ObtemArvoreCatalogoQuery criaArvoreCatalogo = new ObtemArvoreCatalogoQuery();
            //List<RamalEstoque> lista = criaArvoreCatalogo.ExtraiArvoreEstoque();

            //BaseMDBRepositorio<Catalogo> catalogoRepositorio = new BaseMDBRepositorio<Catalogo>("Catalogo", "Catalogo");
            //BaseMDBRepositorio<Familia> familiasRepositorio = new BaseMDBRepositorio<Familia>("Catalogo", "Familias");
            var ramalEstoqueRepositorio = new BaseMDBRepositorio<RamalArvoreCatalogo>("Catalogo", "RamalEstoque");

            var obtemArvoreCatalogoQuery = new ObtemArvoreCatalogoQuery();
            var handler = new ObtemArvoreCatalogoQueryHandler(ramalEstoqueRepositorio);
            var result = (CommandResult<RamalArvoreCatalogo>)handler.Handle(obtemArvoreCatalogoQuery);

            Assert.IsTrue(result.Result.Count > 0);
        }

    }
}