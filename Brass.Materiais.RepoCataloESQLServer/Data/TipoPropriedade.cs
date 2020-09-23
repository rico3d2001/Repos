using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class TipoPropriedade
    {
        public string Guid { get; set; }
        public string Nome { get; set; }
        public string GuidPai { get; set; }
    }
}
