using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Models
{
    public class ItemTubulacaoEstoque
    {
        public ItemTubulacaoEstoque(int pnPID, string gUID_CATALOGO, string gUID_ITEM, string gUID_CATEGORIA, string gUID_TIPO_ITEM)
        {
            PnPID = pnPID;
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_ITEM = gUID_ITEM;
            GUID_CATEGORIA = gUID_CATEGORIA;
            GUID_TIPO_ITEM = gUID_TIPO_ITEM;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; private set; }
        public int PnPID { get; set; }
        public string GUID_CATALOGO { get; set; }
        public string GUID_ITEM { get; set; }
        public string GUID_CATEGORIA { get; set; }
        public string GUID_TIPO_ITEM { get; set; }
        public string ShortDescription { get; set; }
        public string PartCategory { get; set; }
        public string DesignStd { get; set; } 
        public string CatalogPartFamilyId { get; set; } 
        public string EngagementLength { get; set; } 
        public string DesignPressureFactor { get; set; } 
        public string Descricao_curta { get; set; } 
        public string ComponentDesignation { get; set; } 
        public string Weight { get; set; } 
        public string ItemCode { get; set; } 
        public string WallThickness { get; set; } 
        public string Status { get; set; } 
        public string FlangeThickness { get; set; } 
        public string GasketStd { get; set; }
        public string ContentIsoSymbolDefinition { get; set; }
        public string MatchingPipeOd { get; set; }
        public string WeightUnit { get; set; }
        public string NominalDiameter { get; set; }
        public string MaterialCode { get; set; }
        public string LengthUnit { get; set; }
        public string CompatibleStandard { get; set; }
        public string PartFamilyId { get; set; }
        public string Facing { get; set; }
        public string PortName { get; set; }
        public string EndType { get; set; }
        public string PartStatus { get; set; }
        public string PartVersion { get; set; }
        public string ContentGeometryParamDefinition { get; set; }
        public string ContentDomain { get; set; }
        public string PartSizeLongDesc { get; set; } 
        public string Manufacturer { get; set; }
        public string SizeRecordId { get; set; }
        public string PartFamilyLongDesc { get; set; }
        public string Material { get; set; }
        public string NominalUnit { get; set; }
        public string Schedule { get; set; }
        public string ContentGeometryTemplate { get; set; }
        public string ConnectionPortCount { get; set; }
        public string FlangeStd { get; set; }
        public string PressureClass { get; set; }
    }
}
