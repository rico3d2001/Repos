using OfficeOpenXml;

namespace Brass.Materiais.InterfaceExcel.Interface
{
    public interface ICabecalhoPlanilha<T>
    {
        T LerCabecalho(ExcelWorksheet wsPlanilha);

        string NomeArquivo { get; set; }
    }
}
