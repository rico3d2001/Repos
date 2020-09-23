using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models
{
    public class EngineeringItems
    {
        [DbColumn(IsIdentity = true, IsPrimary = true)]
        public long PnPID { get; set; }

        [DbColumn]
        public Guid PartFamilyId { get; set; }

        [DbColumn]
        public Guid CatalogPartFamilyId { get; set; }

        [DbColumn]
        public string PartFamilyLongDesc { get; set; }

        [DbColumn]
        public int PartStatus { get; set; }

        [DbColumn]
        public string CompatibleStandard { get; set; }

        [DbColumn]
        public string Manufacturer { get; set; }

        [DbColumn]
        public string Material { get; set; }

        [DbColumn]
        public string MaterialCode { get; set; }

        [DbColumn]
        public string PartSizeLongDesc { get; set; }

        [DbColumn]
        public string ShortDescription { get; set; }

        [DbColumn]
        public string ItemCode { get; set; }

        [DbColumn]
        public string DesignStd { get; set; }

        [DbColumn]
        public string DesignPressureFactor { get; set; }

        [DbColumn]
        public double Weight { get; set; }

        [DbColumn]
        public string WeightUnit { get; set; }

        [DbColumn]
        public int ConnectionPortCount { get; set; }

        [DbColumn]
        public Guid SizeRecordId { get; set; }

        [DbColumn]
        public string PortName { get; set; }

        [DbColumn]
        public double NominalDiameter { get; set; }

        [DbColumn]
        public string NominalUnit { get; set; }

        [DbColumn]
        public double MatchingPipeOd { get; set; }

        [DbColumn]
        public string EndType { get; set; }

        [DbColumn]
        public string FlangeStd { get; set; }

        [DbColumn]
        public string GasketStd { get; set; }

        [DbColumn]
        public string Facing { get; set; }

        [DbColumn]
        public double FlangeThickness { get; set; }

        [DbColumn]
        public string PressureClass { get; set; }

        [DbColumn]
        public string Schedule { get; set; }

        [DbColumn]
        public double WallThickness { get; set; }

        [DbColumn]
        public double EngagementLength { get; set; }

        [DbColumn]
        public string LengthUnit { get; set; }

        [DbColumn]
        public string ComponentDesignation { get; set; }

        [DbColumn]
        public string PartCategory { get; set; }

        [DbColumn]
        public string ContentDomain { get; set; }

        [DbColumn]
        public string ContentGeometryParamDefinition { get; set; }

        [DbColumn]
        public string ContentIsoSymbolDefinition { get; set; }

        [DbColumn]
        public string ContentGeometryTemplate { get; set; }

        [DbColumn]
        public string PartVersion { get; set; }

        [DbColumn]
        public string Status { get; set; }

        //[DbColumn]
        //public string Descricao_curta { get; set; }

        //[DbColumn]
        //public string Descricao_LML { get; set; }

        //[DbColumn]
        //public string GUID_ITEM { get; set; }

        //[DbColumn]
        //public string CODIGO { get; set; }

        //[DbColumn]
        //public string FABRICACAO { get; set; }

    }
}
