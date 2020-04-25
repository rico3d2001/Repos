using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class Propriedade
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
