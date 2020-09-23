using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class SiglaCodigo : Sigla
    {
        public SiglaCodigo(string texto, int numeroCaracteres, bool permiteLetras, bool permiteNumeros, string definicao)
            : base(texto, numeroCaracteres, permiteLetras, permiteNumeros)
        {
            Texto = texto;
            NumeroCaracteres = numeroCaracteres;
            PermiteLetras = permiteLetras;
            PermiteNumeros = permiteNumeros;
            Definicao = definicao;
        }

        public string Definicao { get; set; }
    }
}
