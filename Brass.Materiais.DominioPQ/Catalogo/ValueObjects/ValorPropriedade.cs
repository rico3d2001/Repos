using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class ValorPropriedade:ObjetoValor
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
