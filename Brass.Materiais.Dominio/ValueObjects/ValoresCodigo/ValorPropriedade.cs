using Brass.Materiais.Dominio.ValueObjects.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class ValorPropriedade
    {
        public ValorPropriedade(string valor, PropriedadeTipo tipo)
        {
            Tipo = tipo;
            Valor = valor;
        }

        public string Valor { get; set; }
        public PropriedadeTipo Tipo { get; set; }
    }
}
