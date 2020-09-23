using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class Idioma : Entidade
    {
        public Idioma(string iDIOMA, string pAIS)
        {
            IDIOMA = iDIOMA;
            PAIS = pAIS;
        }

        public string IDIOMA { get; set; }
        public string PAIS { get; set; }

    }
}
