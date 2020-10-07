using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public abstract class BaseComponentesPlant
    {

       


        protected int _indicadorAtivo;


        public long PnPID { get; set; }
        public string? PnPClassName { get; set; }
        public string? ItemCode { get; set; }

        public string? PartFamilyLongDesc { get; set; }
        public string? PartSizeLongDesc { get; set; }
        public string? LineNumberTag { get; set; }
        public int IndicadorAtivo { get => _indicadorAtivo; set => _indicadorAtivo = value; }

        

        

    }
}
