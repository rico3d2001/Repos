using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class CtPnPtables
    {
        public string Guid { get; set; }
        public string TableName { get; set; }
        public string BaseTable { get; set; }
        public string Abstract { get; set; }
        public string PhysicalName { get; set; }
        public int? Revision { get; set; }
        public int? SyncTimestamp { get; set; }
        public string SiglaBrass { get; set; }
    }
}
