using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Models;
using SQLiteWithCSharp.Utility;

namespace Brass.Materiais.RepositorioSQLitePlant.Service
{
    public class BleedRingService: RepositorioService<BleedRing>
    {
        public BleedRingService() : base(Storage.ConnectionString)
        {

        }

        // you can write extended methods here
    }
}
