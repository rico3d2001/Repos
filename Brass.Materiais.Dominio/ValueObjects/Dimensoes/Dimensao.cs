using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Dimensoes
{
    public class Dimensao
    {
        public Dimensao(double valor)
        {
            Valor = valor;
        }

        public double Valor { get; set; }
    }
}
