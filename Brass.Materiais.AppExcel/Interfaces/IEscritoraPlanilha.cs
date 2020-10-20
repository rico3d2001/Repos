using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Interfaces
{
    public interface IEscritoraPlanilha
    {
        void Escrever(Worksheet wsPlanilha);
    }
}
