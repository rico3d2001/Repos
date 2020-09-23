using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.RepoDapperSQLServer.Models
{
    public class PropriedadesItemDTO
    {
        //public string ITEM { get; set; }
        //public string CATALOGO { get; set; }
        public string PROPRIEDADE { get; set; }
        public string VALOR_PROPRIEDADE { get; set; }
        public string GUID_ITEM_PROPRIEDADE { get; set; }

        public string GUID_ITEM { get; set; }

        public string PnPID { get; set; }

    }
}
