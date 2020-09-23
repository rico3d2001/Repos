using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class PropriedadeTipo:ObjetoValor
    {
        public PropriedadeTipo(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
