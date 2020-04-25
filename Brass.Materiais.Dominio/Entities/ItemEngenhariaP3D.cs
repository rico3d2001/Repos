using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class ItemEngenhariaP3D
    {

        public string GUID { get; set; }
        public string CODIGO { get; set; }
        public string FABRICACAO { get; set; }
        public long PnPID { get; set; }
        public Guid PartFamilyId { get; set; }
        public Guid CatalogPartFamilyId { get; set; }
        public string PartFamilyLongDesc { get; set; }
        public int PartStatus { get; set; }
        public string CompatibleStandard { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public string MaterialCode { get; set; }
        public string PartSizeLongDesc { get; set; }
        public string ShortDescription { get; set; }
        public string ItemCode { get; set; }
        public string DesignStd { get; set; }
        public string DesignPressureFactor { get; set; }
        public double Weight { get; set; }
        public string WeightUnit { get; set; }
        public int ConnectionPortCount { get; set; }
        public Guid SizeRecordId { get; set; }
        public string PortName { get; set; }
        public double NominalDiameter { get; set; }
        public string NominalUnit { get; set; }
        public double MatchingPipeOd { get; set; }
        public string EndType { get; set; }
        public string FlangeStd { get; set; }
        public string GasketStd { get; set; }
        public string Facing { get; set; }
        public double FlangeThickness { get; set; }
        public string PressureClass { get; set; }
        public string Schedule { get; set; }
        public double WallThickness { get; set; }
        public double EngagementLength { get; set; }
        public string LengthUnit { get; set; }
        public string ComponentDesignation { get; set; }
        public string PartCategory { get; set; }
        public string ContentDomain { get; set; }
        public string ContentGeometryParamDefinition { get; set; }
        public string ContentIsoSymbolDefinition { get; set; }
        public string ContentGeometryTemplate { get; set; }
        public string PartVersion { get; set; }
        public string Status { get; set; }
        public string Descricao_curta { get; set; }
        public string Descricao_LML { get; set; }


    }
}
