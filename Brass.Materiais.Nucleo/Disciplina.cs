using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Nucleo
{
    public class Disciplina: Entidade
    {
        public Disciplina(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
