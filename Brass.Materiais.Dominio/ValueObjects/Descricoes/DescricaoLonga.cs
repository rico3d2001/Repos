using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Descricoes
{
    public class DescricaoLonga : ValueObject
    {
        public DescricaoLonga(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
