using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Formatacao
{
    public class FormataCaracteres:IFormatacao
    {
        public string Formatar(string sigla, int numeroCaracteres)
        {
            if (sigla.Length != numeroCaracteres)
            {
                throw new ArgumentException($"Comprimento menor diferente de {numeroCaracteres} caracteres");
            }

            return sigla;
        }

        
    }
}
