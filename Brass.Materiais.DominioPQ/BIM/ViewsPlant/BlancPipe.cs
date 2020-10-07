using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public class BlancPipe : BaseComponentesPlant
    {

        public BlancPipe()
        {
            _indicadorAtivo = 1;
        }
        
        public string? LengthUnit { get; set; }

        public double? Length { get; set; }

       
    }
}
