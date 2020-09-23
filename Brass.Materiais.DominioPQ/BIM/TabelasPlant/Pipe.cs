using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Brass.Materiais.DominioPQ.BIM.TabelasPlant
{

    [Table("Pipe")]
    public class Pipe
    {
        public long PnPID { get; set; }
        public double? Length { get; set; }
        public bool? UseFixedLength { get; set; }
        public double? CutLength { get; set; }
        public double? MinCutLength { get; set; }
        public double? LinearWeight { get; set; }
        public string? LinearWeightUnit { get; set; }


    }
}
