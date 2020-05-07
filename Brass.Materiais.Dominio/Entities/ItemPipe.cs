using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.Dominio.Entities
{
    public class ItemPipe: Entidade
    {
  
        //public string GUID { get; set; }
        public string GUID_TIPO_ITEM { get; set; }
        public string GUID_CATALOGO { get; set; }
        public string GUID_ITEM_PAI { get; set; }
        public int PnPID { get; set; }

    }
}
