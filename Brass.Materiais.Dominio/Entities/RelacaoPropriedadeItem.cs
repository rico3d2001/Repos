using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class RelacaoPropriedadeItem: Entidade
    {
        public string GUID_PROPRIEDADE { get; set; }
        public string GUID_ITEM_ENG { get; set; }
    }
}

