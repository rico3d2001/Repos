using Brass.Materiais.RepoSQLServerDapper.Service;

namespace Brass.Materiais.GestaoCatalogo.Service
{
    public class TabelaService
    {

        public string ObterColunas(string guidCategoria, string guidTipoItem)
        {
            string contextmessage = "[";

            PropriedadesItemService propriedadesItemService = new PropriedadesItemService();

            var lista = propriedadesItemService.ObterColunas(guidCategoria, guidTipoItem); //.///ObterPorCategoria(guidCatalogo, guidCategoria, guidTipoItem);

            foreach (var item in lista)
            {
                contextmessage = contextmessage + "'" + item + "',";
            }

            contextmessage = contextmessage.Substring(0, contextmessage.Length - 1) + "]";

            return contextmessage;
        }
    }
}
