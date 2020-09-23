using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class ItemTag:Entidade
    {
        public ItemTag(AreaTag areaTag,  string tipo,
            string tagCompleto, string nome)
        {
            GuidProjeto = areaTag != null ? areaTag.GUID_PROJETO : "";
            AreaDesenho = areaTag;
            Tipo = tipo;
            TagCompleto = tagCompleto;
            Nome = nome;
            
        }

        public ItemTag(AreaTag areaTag, string tipo,
           ItemModelado itemModelado, string nome)
        {
            GuidProjeto = areaTag != null ? areaTag.GUID_PROJETO : "";
            AreaDesenho = areaTag;
            Tipo = tipo;
            TagCompleto = itemModelado.ItemTag.TagCompleto;
            Nome = nome;

        }

        public string GuidProjeto { get; set; }
        public AreaTag AreaDesenho { get; set; }
        public string Tipo { get; set; }
        public string TagCompleto { get; set; }
        public string Nome { get; set; }
       
       
    }
}
