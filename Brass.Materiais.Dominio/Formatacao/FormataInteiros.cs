using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Formatacao
{
    public class FormataInteiros : IFormatacao
    {
        public string Formatar(string sigla, int numeroCaracteres)
        {
            if (sigla.Length != numeroCaracteres)
            {
                throw new ArgumentException($"Comprimento da sigla menor diferente de {numeroCaracteres} caracteres");
            }
            else if (possuiLetra(sigla))
            {
                throw new ArgumentException("Letra inserida indevidamente");
            }

            return sigla;
        }

        private bool possuiLetra(string escrito)
        {
            int num = 0;
            foreach (var caracter in escrito)
            {
                if (!int.TryParse(caracter.ToString(), out num))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
