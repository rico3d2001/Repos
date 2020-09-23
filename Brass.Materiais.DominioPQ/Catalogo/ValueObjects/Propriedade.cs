using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class Propriedade:ObjetoValor
    {
        public Propriedade(NomePropriedade nome, ValorPropriedade valorPropriedade)
        {
            Nome = nome;
            ValorPropriedade = valorPropriedade;
        }

        public NomePropriedade Nome { get; set; }
        public ValorPropriedade ValorPropriedade { get; set; }
    }
}
