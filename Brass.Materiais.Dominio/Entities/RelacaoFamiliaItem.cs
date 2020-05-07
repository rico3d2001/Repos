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
        public string GUID_FAMILIA { get; set; }
        public string GUID_ITEM { get; set; }
        public string GUID_CATEGORIA { get; set; }
    }
}
