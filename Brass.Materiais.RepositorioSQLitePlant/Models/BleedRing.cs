using SQLiteWithCSharp.Utility;

namespace Brass.Materiais.RepositorioSQLitePlant.Models
{
    public class BleedRing
    {
        [DbColumn(IsIdentity = true, IsPrimary = true)]
        public long PnPID { get; set; }

    }
}
