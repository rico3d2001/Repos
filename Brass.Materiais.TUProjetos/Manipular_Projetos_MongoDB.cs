using Brass.Materiais.RepoMongoDBCatalogo.Services.Catalogo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brass.Materiais.TUProjetos
{
    [TestClass]
    public class Manipular_Projetos_MongoDB
    {
        [TestMethod]
        public void Modificar_GuidCliente_Projetos()
        {
            var guidClienteVale = "8e346a61-2623-448b-b4bd-62232b9f55da";

            RepoProjetos repoProjetos = new RepoProjetos();

            foreach (var projeto in repoProjetos.ObterTodos())
            {
                projeto.GUID_CLIENTE = guidClienteVale;

                repoProjetos.Modificar(projeto);
            }

        }

        //

        [TestMethod]
        public void Modificar_GuidDisciplina_Atividades()
        {
            var guidDisciplinaTubulacao = "f8858d95-5eba-4d21-8606-4b813efa568b";

            RepoAtividade repoAtividade = new RepoAtividade();

            foreach (var atividade in repoAtividade.ObterTodas())
            {
                atividade.GUID_DISCIPLINA = guidDisciplinaTubulacao;

                repoAtividade.Modificar(atividade);
            }

        }

        [TestMethod]
        public void Modificar_GuidCliente_Atividades()
        {
            var guidClienteVale = "8e346a61-2623-448b-b4bd-62232b9f55da";

            RepoAtividade repoAtividade = new RepoAtividade();

            foreach (var atividade in repoAtividade.ObterTodas())
            {
                atividade.GUID_CLIENTE = guidClienteVale;

                repoAtividade.Modificar(atividade);
            }

        }


    }
}
