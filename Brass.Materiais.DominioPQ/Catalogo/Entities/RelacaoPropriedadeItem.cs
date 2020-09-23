using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class RelacaoPropriedadeItem : Entidade
    {
        public RelacaoPropriedadeItem(string gUID_PROPRIEDADE, string gUID_ITEM_ENG)
        {
            GUID_PROPRIEDADE = gUID_PROPRIEDADE;
            GUID_ITEM_ENG = gUID_ITEM_ENG;
        }

        public string GUID_PROPRIEDADE { get; set; }
        public string GUID_ITEM_ENG { get; set; }


    }
}
