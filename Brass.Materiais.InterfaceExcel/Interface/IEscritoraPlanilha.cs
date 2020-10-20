using OfficeOpenXml;

namespace Brass.Materiais.InterfaceExcel.Interface
{
    public interface IEscritoraPlanilha<T, U>
    {
        void Escrever(ExcelWorksheet wsPlanilha);
    }
}
