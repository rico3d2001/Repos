using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Spec.Entities
{
    public class CodigoMaterial: Entidade
    {
        public CodigoMaterial(string gUID_CLIENTE, string sigla, string gUID_IDIOMA, string descricao)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Sigla = sigla;
            GUID_IDIOMA = gUID_IDIOMA;
            Descricao = descricao;
            Versao = 0;
            DataVersao = DateTime.Now;
        }

        public string GUID_CLIENTE { get; set; }
        public string Sigla { get; set; }
        public string GUID_IDIOMA { get; set; }
        public string Descricao { get; set; }
        public int Versao { get; set; }
        public DateTime DataVersao { get; set; }

    }
}
