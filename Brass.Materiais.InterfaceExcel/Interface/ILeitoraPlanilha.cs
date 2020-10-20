using OfficeOpenXml;
using System.Collections.Generic;

namespace Brass.Materiais.InterfaceExcel.Interface
{
    public interface ILeitoraPlanilha<T>
    {
        List<T> Ler(ExcelWorksheet wsPlanilha);
       

    }
}
