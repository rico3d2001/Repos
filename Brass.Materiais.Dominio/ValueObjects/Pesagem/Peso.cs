using Brass.Materiais.Dominio.ValueObjects.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Pesagem
{
    public class Peso
    {
        public Peso(string nome, UnidadePeso unidadePeso)
        {
            Nome = nome;
            UnidadePeso = unidadePeso;
        }

        public string Nome { get; set; }
        public UnidadePeso UnidadePeso { get; set; }
    }
}
