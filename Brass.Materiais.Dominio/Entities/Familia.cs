using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Familia:Entidade
    {
       

        public Familia(string gUID_CATALOGO, string gUID_CATEGORIA)
        {
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_CATEGORIA = gUID_CATEGORIA;
        }

        public string GUID_CATALOGO { get; set; }
        public string GUID_CATEGORIA { get; set; }
        public string PartFamilyLongDesc { get; set; }


    }
}
