using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class NomeTipoPropriedade : Entidade
    {
        public NomeTipoPropriedade(string nOME)
        {
            NOME = nOME;
        }

        public string NOME { get; set; }
        public string GUID_PAI { get; set; }
        public bool CODIFICAVEL { get; set; }

    }
}
