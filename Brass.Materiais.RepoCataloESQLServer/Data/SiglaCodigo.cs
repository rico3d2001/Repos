using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class SiglaCodigo
    {
        public string Guid { get; set; }
        public string Sigla { get; set; }
        public double? DimensaoMm { get; set; }
        public string SiglaPai { get; set; }
        public string GuidNorma { get; set; }
    }
}
