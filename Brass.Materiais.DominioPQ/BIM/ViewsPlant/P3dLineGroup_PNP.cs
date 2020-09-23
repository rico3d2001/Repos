using System.ComponentModel.DataAnnotations.Schema;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public class P3dLineGroup_PNP
    {
        public long PnPID { get; set; }
        public string? PnPClassName { get; set; }
        public int? PnPStatus { get; set; }
        public int? PnPRevision { get; set; }
        public string? PnPGuid { get; set; }
        public int? PnPTimestamp { get; set; }

        public string? AcquisitionProperties { get; set; }
        public string? Tag { get; set; }
        public string? InsulationSpec { get; set; }
        public string? TracingSpec { get; set; }
        public string? Number { get; set; }
        public string? NominalSpec { get; set; }
        public string? NominalSize { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
        public string? Service { get; set; }
        public string? InsulationThickness { get; set; }
        public string? InsulationType { get; set; }
        public string? TracingType { get; set; }
        public int? Locked { get; set; }

        public string? LockedBy { get; set; }
        public int? LockedTimestamp { get; set; }

        [Column("COG X")]
        public double? COGX { get; set; }

        [Column("COG Y")]
        public double? COGY { get; set; }

        [Column("COG Z")]
        public double? COGZ { get; set; }

        public double? Weight { get; set; }

        public string? WeightUnit { get; set; }
    }
}


