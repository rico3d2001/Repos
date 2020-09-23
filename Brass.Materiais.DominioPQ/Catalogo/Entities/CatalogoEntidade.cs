using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class CatalogoEntidade : Entidade
    {
        public CatalogoEntidade(string gUID_IDIOMA, string nOME, string gUID_DISCIPLINA)
        {
            GUID_IDIOMA = gUID_IDIOMA;
            NOME = nOME;
            GUID_DISCIPLINA = gUID_DISCIPLINA;
        }

        public string GUID_IDIOMA { get; set; }
        public string NOME { get; set; }
        public string GUID_DISCIPLINA { get; set; }


    }
}
