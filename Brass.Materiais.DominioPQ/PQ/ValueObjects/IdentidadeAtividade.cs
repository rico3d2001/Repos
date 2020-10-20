using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class IdentidadeAtividade
    {
        public IdentidadeAtividade(string gUID_CLIENTE, string gUID_DISCIPLINA, string gUID_IDIOMA)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            GUID_DISCIPLINA = gUID_DISCIPLINA;
            GUID_IDIOMA = gUID_IDIOMA;
        }

        public string GUID_CLIENTE { get; set; }
        public string GUID_DISCIPLINA { get; set; }
        public string GUID_IDIOMA { get; set; }

       



    }
}
