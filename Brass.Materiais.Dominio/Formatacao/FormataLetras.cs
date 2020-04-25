using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Formatacao
{
    public class FormataLetras : IFormatacao
    {
        public string Formatar(string sigla, int numeroCaracteres)
        {
            if (sigla.Length != numeroCaracteres)
            {
                throw new ArgumentException($"Comprimento da sigla menor diferente de {numeroCaracteres} caracteres");
            }
            else if (possuiNumero(sigla))
            {
                throw new ArgumentException("Caracter numerico inserido indevidamente");
            }

            return sigla;
        }

        private bool possuiNumero(string escrito)
        {
            int num = 0;
            foreach (var caracter in escrito)
            {
                if (int.TryParse(caracter.ToString(), out num))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
