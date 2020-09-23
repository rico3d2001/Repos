using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.ValueObjects
{
    public class Sigla:ObjetoValor
    {
        public Sigla(string texto, int numeroCaracteres, bool permiteLetras, bool permiteNumeros)
        {

            Texto = texto;
            NumeroCaracteres = numeroCaracteres;
            PermiteLetras = permiteLetras;
            PermiteNumeros = permiteNumeros;

        }


        public string Texto { get; set; }
        public int NumeroCaracteres { get; set; }
        public bool PermiteLetras { get; set; }
        public bool PermiteNumeros { get; set; }






    }
}
