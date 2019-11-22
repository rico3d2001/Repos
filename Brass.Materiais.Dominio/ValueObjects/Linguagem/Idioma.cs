using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Linguagem
{
    public class Idioma:ValueObject
    {
        public Idioma(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
