using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class PropriedadeItem : Entidade
    {
        public PropriedadeItem(string gUID_VALOR, string gUID_TIPO)
        {
            GUID_VALOR = gUID_VALOR;
            GUID_TIPO = gUID_TIPO;
        }

        public string GUID_VALOR { get; set; }
        public string GUID_TIPO { get; set; }


    }
}
