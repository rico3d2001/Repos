using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class Tubo
    {
        public string Guid { get; set; }
        public string GuidMaterial { get; set; }
        public string GuidSchedule { get; set; }
        public string GuidFabricacao { get; set; }
        public string GuidExtremidade { get; set; }
        public string GuidDiametro { get; set; }
    }
}
