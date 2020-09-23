using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ValueObjects
{
    public class Usuario: ObjetoValor
    {
        public Usuario(string nome, string sigla, string disciplina)
        {
            Nome = nome;
            Sigla = sigla;
            Disciplina = disciplina;
        }

        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Disciplina { get; set; }
    }
}
