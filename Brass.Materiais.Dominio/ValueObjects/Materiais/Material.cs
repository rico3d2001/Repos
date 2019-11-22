using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Materiais
{
    public class Material:ValueObject
    {
        public Material(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
