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
        public Peso(double valor, UnidadePeso unidadePeso)
        {
            Valor = valor;
            UnidadePeso = unidadePeso;
        }

        public double Valor { get; set; }
        public UnidadePeso UnidadePeso { get; set; }
    }
}
