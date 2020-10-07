using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.UnitTestAtividades
{
    [TestClass]
    public class InsercoesMongo
    {
        [TestMethod]
        public void Inserir_AtividadeNo_Nivel_K()
        {
            var repoAtividade = new RepoAtividade("mongodb://localhost");

            //Atividade atividade = new Atividade()
        }
    }
}
