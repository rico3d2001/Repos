using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class ItemEngenharia
    {
        public string Guid { get; set; }
        public string GuidTipoItem { get; set; }
        public string GuidCatalogo { get; set; }
        public string GuidItemPai { get; set; }
        public int? PnPid { get; set; }
    }
}
