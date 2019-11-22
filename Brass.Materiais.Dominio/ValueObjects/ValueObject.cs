using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects
{
    public abstract class ValueObject
    {

        protected string getCaracteres(string sigla, int numeroCaracteres)
        {

            if (sigla.Length != numeroCaracteres)
            {
                throw new ArgumentException($"Comprimento menor diferente de {numeroCaracteres} caracteres");
            }

            return sigla;

        }

        protected string getLetras(string sigla, int numeroLetras)
        {

            if (sigla.Length != numeroLetras)
            {
                throw new ArgumentException($"Comprimento da sigla menor diferente de {numeroLetras} caracteres");
            }
            else if (possuiNumero(sigla))
            {
                throw new ArgumentException("Caracter numerico inserido indevidamente");
            }

            return sigla;

        }

        protected string getInteiros(string sigla, int qtdInteiros)
        {

            if (sigla.Length != qtdInteiros)
            {
                throw new ArgumentException($"Comprimento da sigla menor diferente de {qtdInteiros} caracteres");
            }
            else if (possuiLetra(sigla))
            {
                throw new ArgumentException("Letra inserida indevidamente");
            }

            return sigla;

        }


        private bool possuiNumero(string escrito)
        {
            int num = 0;
            foreach (var caracter in escrito)
            {
                if (int.TryParse(caracter.ToString(),out num))
                {
                    return true;
                }
            }

            return false;
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
