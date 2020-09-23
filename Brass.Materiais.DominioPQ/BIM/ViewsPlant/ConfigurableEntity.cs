using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public class ConfigurableEntity
    {
        public long PnPID { get; set; }
        public string? PnPClassName { get; set; }
        public string? ItemCode { get; set; }
        public string? PartSizeLongDesc { get; set; }
        public string? LineNumberTag { get; set; }
        public string? PartFamilyLongDesc { get; set; }
    }
}
