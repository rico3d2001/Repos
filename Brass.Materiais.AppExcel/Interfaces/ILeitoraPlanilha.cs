using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Interfaces
{
    public interface ILeitoraPlanilha<T>
    {
        List<T> Ler(Worksheet wsPlanilha);


    }
}
