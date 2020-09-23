using SQLiteWithCSharp.Utility;

namespace Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models
{
    public class BleedRing
    {
        [DbColumn(IsIdentity = true, IsPrimary = true)]
        public long PnPID { get; set; }

    }
}
