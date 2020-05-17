using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class RelacaoFamiliaItem : Entidade
    {
        public RelacaoFamiliaItem(string gUID_FAMILIA, string gUID_ITEM, string gUID_CATEGORIA)
        {
            GUID_FAMILIA = gUID_FAMILIA;
            GUID_ITEM = gUID_ITEM;
            GUID_CATEGORIA = gUID_CATEGORIA;
        }

        public string GUID_FAMILIA { get; set; }
        public string GUID_ITEM { get; set; }
        public string GUID_CATEGORIA { get; set; }

       
    }
}
