using System.ComponentModel.DataAnnotations.Schema;

namespace Brass.Materiais.DominioPQ.BIM.ViewsPlant
{
    public class Pipe_PNP
    {
        public long PnPID { get; set; }
        public string? PnPClassName { get; set; }
        public int? PnPStatus { get; set; }
        public int? PnPRevision { get; set; }
        public string? PnPGuid { get; set; }
        public int? PnPTimestamp { get; set; }
        public string? PartFamilyId { get; set; }
        public string? PartFamilyLongDesc { get; set; }
        public string? CompatibleStandard { get; set; }
        public string? Manufacturer { get; set; }
        public string? Material { get; set; }
        public string? MaterialCode { get; set; }
        public string? PartSizeLongDesc { get; set; }
        public string? ShortDescription { get; set; }
        public string? Spec { get; set; }
        public string? ItemCode { get; set; }
        public string? DesignStd { get; set; }
        public string? DesignPressureFactor { get; set; }
        public double? Weight { get; set; }
        public string? WeightUnit { get; set; }
        public int? ConnectionPortCount { get; set; }
        public string? SizeRecordId { get; set; }
        public string? PortName { get; set; }
        public double? NominalDiameter { get; set; }
        public string? NominalUnit { get; set; }
        public double? MatchingPipeOd { get; set; }
        public string? EndType { get; set; }
        public string? FlangeStd { get; set; }
        public string? GasketStd { get; set; }
        public string? Facing { get; set; }
        public double? FlangeThickness { get; set; }
        public string? PressureClass { get; set; }
        public string? Schedule { get; set; }
        public double? WallThickness { get; set; }
        public double? EngagementLength { get; set; }
      
        public string? ComponentDesignation { get; set; }
        public string? PartCategory { get; set; }
        public string? ContentIsoSymbolDefinition { get; set; }

        [Column("Position X")]
        public double? PositionX { get; set; }

        [Column("Position Y")]
        public double? PositionY { get; set; }

        [Column("Position Z")]
        public double? PositionZ { get; set; }

        public string? Status { get; set; }

        public string? AcquisitionProperties { get; set; }

        [Column("COG X")]
        public double? COGX { get; set; }

        [Column("COG Y")]
        public double? COGY { get; set; }

        [Column("COG Z")]
        public double? COGZ { get; set; }

        [Column("Required Spec")]
        public string? RequiredSpec { get; set; }

        public int? SpecRecordId { get; set; }

        public string? InsulationThickness { get; set; }
        public string? TracingType { get; set; }
        public string? InsulationType { get; set; }
        public string? Service { get; set; }
        public string? TracingSpec { get; set; }
        public string? InsulationSpec { get; set; }
        public string? Tag { get; set; }
        public string? TieInNumber { get; set; }
        public string? SpoolNumber { get; set; }
        public string? Unit { get; set; }
        public string? LineNumberTag { get; set; }
        public string? Shop_Field { get; set; }
   
        public int? UseFixedLength { get; set; }
        public double? CutLength { get; set; }
        public double? MinCutLength { get; set; }
        public double? LinearWeight { get; set; }
        public string? LinearWeightUnit { get; set; }
    }
}
