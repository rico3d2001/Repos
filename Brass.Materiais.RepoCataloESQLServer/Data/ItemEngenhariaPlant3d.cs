using System;
using System.Collections.Generic;

namespace Brass.Materiais.RepoCataloESQLServer.Data
{
    public partial class ItemEngenhariaPlant3d
    {
        public string Guid { get; set; }
        public int? PnPid { get; set; }
        public string PartFamilyId { get; set; }
        public string PartFamilyLongDesc { get; set; }
        public int? PartStatus { get; set; }
        public string CompatibleStandard { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public string MaterialCode { get; set; }
        public string PartSizeLongDesc { get; set; }
        public string ShortDescription { get; set; }
        public string ItemCode { get; set; }
        public string DesignStd { get; set; }
        public string DesignPressureFactor { get; set; }
        public double? Weight { get; set; }
        public string WeightUnit { get; set; }
        public int? ConnectionPortCount { get; set; }
        public string SizeRecordId { get; set; }
        public string PortName { get; set; }
        public double? NominalDiameter { get; set; }
        public string NominalUnit { get; set; }
        public double? MatchingPipeOd { get; set; }
        public string EndType { get; set; }
        public string FlangeStd { get; set; }
        public string GasketStd { get; set; }
        public string Facing { get; set; }
        public double? FlangeThickness { get; set; }
        public string PressureClass { get; set; }
        public string Schedule { get; set; }
        public double? WallThickness { get; set; }
        public double? EngagementLength { get; set; }
        public string LengthUnit { get; set; }
        public string ComponentDesignation { get; set; }
        public string PartCategory { get; set; }
        public string ContentDomain { get; set; }
        public string ContentGeometryParamDefinition { get; set; }
        public string ContentIsoSymbolDefinition { get; set; }
        public string ContentGeometryTemplate { get; set; }
        public string PartVersion { get; set; }
        public string Status { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLml { get; set; }
        public string CatalogPartFamilyId { get; set; }
        public string Codigo { get; set; }
        public string Idioma { get; set; }
    }
}
