using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using SQLiteWithCSharp.Utility;

namespace Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe
{
    public class PnPTablesService : RepositorioService<PnPTables>
    {
       

        public PnPTablesService() : base(Storage.ConnectionString)
        {

        }

    }
}
