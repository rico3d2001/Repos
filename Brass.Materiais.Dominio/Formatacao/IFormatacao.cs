using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Formatacao
{
    public interface IFormatacao
    {
        string Formatar(string sigla, int numeroCaracteres);
    }
}
