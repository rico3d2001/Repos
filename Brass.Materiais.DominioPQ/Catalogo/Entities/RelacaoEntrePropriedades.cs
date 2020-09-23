using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class RelacaoEntrePropriedades : Entidade
    {

        public string GUID_PROPIEDADE { get; set; }
        public string GUID_PNPTABLE { get; set; }

    }
}
