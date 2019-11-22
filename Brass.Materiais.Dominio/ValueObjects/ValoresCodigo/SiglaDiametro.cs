using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class SiglaDiametro : ValueObject
    {
        public SiglaDiametro(string sigla)
        {
            Sigla = getCaracteres(sigla,4);
        }

        public string Sigla { get; private set; }

        //public int ValorNumerico { get; set; }

    }
}
