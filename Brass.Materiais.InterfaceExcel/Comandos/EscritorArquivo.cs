using Brass.Materiais.InterfaceExcel.Interface;
using OfficeOpenXml;
using System.IO;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public class EscritorArquivo<T,U>
    {
        IEscritoraPlanilha<T,U> _escritoraPlanilha;

        public EscritorArquivo(IEscritoraPlanilha<T,U> escritoraPlanilha)
        {
            _escritoraPlanilha = escritoraPlanilha;
        }

        public void Escrever(string nomeArquivo, string nomePlanilha)
        {
          

            FileInfo fileInfo = new FileInfo(nomeArquivo);




            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                var wsPlanilha = excelPackage.Workbook.Worksheets.Add(nomePlanilha);

                _escritoraPlanilha.Escrever(wsPlanilha);


            }


   


            //var excelApp = new Application();
            //excelApp.Visible = true;

            //var workBook = excelApp.Workbooks.Open(nomeArquivo);

            //var wsPlanilhas = workBook.Worksheets;

            //Worksheet wsPlanilha = wsPlanilhas[nomePlanilha];




            //_escritoraPlanilha.Escrever(wsPlanilha);





            //workBook.Close(false);



            //wsPlanilha = null;



            //excelApp.Quit();

            




        }

    }
}
