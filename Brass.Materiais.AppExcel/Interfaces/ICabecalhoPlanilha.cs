using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Interfaces
{
    public interface ICabecalhoPlanilha<T>
    {
        T LerCabecalho(Worksheet wsPlanilha);

        string NomeArquivo { get; set; }
    }
}
