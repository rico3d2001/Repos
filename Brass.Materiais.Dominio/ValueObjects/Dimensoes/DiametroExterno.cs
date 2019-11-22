using Brass.Materiais.Dominio.ValueObjects.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Dimensoes
{
    public class DiametroExterno:ValueObject
    {
        public DiametroExterno(double valor, UnidadeDimensao unidadeDimensao)
        {
            Valor = valor;
            UnidadeDimensao = unidadeDimensao;
        }

        public double Valor { get; set; }
        public UnidadeDimensao UnidadeDimensao { get; set; }
    }
}
