using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.UTCargaAtlas
{
    [TestClass]
    public class UTAtlas
    {
        [TestMethod]
        public void Transfere_ItensPipe1()
        {


            RepoItemPipe repoItemPipeLocal = new RepoItemPipe("local");

            var itensLocais = repoItemPipeLocal.ObterTodos();


            RepoItemPipe repoItemPipeAtlas = new RepoItemPipe("testeAtlas");


            foreach (var item in itensLocais)
            {
                repoItemPipeAtlas.CadastrarItemPipe(item);
            }

            var teste = repoItemPipeAtlas.ObterTodos();

            Assert.IsTrue(teste.Count > 0);
        }



        [TestMethod]
        public void Transfere_Clientes()
        {
          

            RepoClientes repoClientesLocal = new RepoClientes("local");

            var clientesLocais = repoClientesLocal.ObterTodos();

        
            RepoClientes repoClientesAtlas = new RepoClientes("testeAtlas");

           
            foreach (var cliente in clientesLocais)
            {
                repoClientesAtlas.Cadastar(cliente);
            }

            var teste = repoClientesAtlas.ObterTodos();

            Assert.IsTrue(teste.Count > 0);
        }
    }
}
