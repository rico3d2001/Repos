using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class Categoria : Entidade
    {
        public Categoria(string gUID_CATALOGO, string gUID_TIPO)
        {
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_TIPO = gUID_TIPO;
        }

        public string GUID_CATALOGO { get; set; }
        public string GUID_TIPO { get; set; }


    }
}
