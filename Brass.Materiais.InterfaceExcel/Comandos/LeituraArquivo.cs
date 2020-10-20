using Brass.Materiais.InterfaceExcel.Interface;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public class LeituraArquivo<T>
    {
        private ILeitoraPlanilha<T> _leitoraPlanilha;


        public LeituraArquivo(ILeitoraPlanilha<T> leitoraPlanilha)
        {
            _leitoraPlanilha = leitoraPlanilha;
        }

        //LeitoraPlanilha leitoraPlanilha = new LeitoraPlanilha();




        public List<T> Ler(string nomeArquivo, string nomePlanilha)
        {
            List<T> lista = new List<T>();

            FileInfo fileInfo = new FileInfo(nomeArquivo);




            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                var wsPlanilha = excelPackage.Workbook.Worksheets[nomePlanilha];

                lista = _leitoraPlanilha.Ler(wsPlanilha);
            }


            return lista;

            //var excelApp = new Application();
            //excelApp.Visible = false;

            //var workBook = excelApp.Workbooks.Open(nomeArquivo);

            //var wsPlanilhas = workBook.Worksheets;

            //Worksheet wsPlanilha = wsPlanilhas[nomePlanilha];


            //var lista = _leitoraPlanilha.Ler(wsPlanilha);





            //workBook.Close(false);



            //wsPlanilha = null;



            //excelApp.Quit();

            //return lista;




        }






    }
}
