using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLitePlant.Models
{
    public class PnPTables
    {
        [DbColumn(IsIdentity = true, IsPrimary = true)]
        public string TableName { get; set; }

        [DbColumn]
        public string BaseTable { get; set; }

        [DbColumn]
        public string Abstract { get; set; }

        [DbColumn]
        public string PhysicalName { get; set; }

        [DbColumn]
        public int Revision { get; set; }

        [DbColumn]
        public int SyncTimestamp { get; set; }
    }
}
