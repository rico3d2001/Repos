using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Spec.Entities
{
    public class ValorSPEC:Entidade
    {
        public ValorSPEC(string gUID_VALOR, string gUID_DESCRITIVO, string valorValor, string specValor)
        {
            GUID_VALOR = gUID_VALOR;
            GUID_DESCRITIVO = gUID_DESCRITIVO;
            ValorValor = valorValor;
            SpecValor = specValor;
        }

        public string GUID_VALOR { get; set; }
        public string GUID_DESCRITIVO { get; set; }
        public string ValorValor { get; set; }
        public string SpecValor { get; set; }

    }
}
