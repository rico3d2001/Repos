using Brass.Materiais.AppExcel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
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


            //FileInfo file = new FileInfo(nomeArquivo);
            var excelApp = new Application();
            excelApp.Visible = true;
            //if (file.Extension == ".xls" || file.Extension == ".XLS" || file.Extension == ".xlsx" || file.Extension == ".XLSX")
            //{
            var workBook = excelApp.Workbooks.Open(nomeArquivo);//, 0, true, 5,
                                                                //"", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true); ;
            var wsPlanilhas = workBook.Worksheets;

            Worksheet wsPlanilha = wsPlanilhas[nomePlanilha];//["LEM"];


            var lista = _leitoraPlanilha.Ler(wsPlanilha);





            workBook.Close(false);



            wsPlanilha = null;



            excelApp.Quit();

            return lista;




        }






    }
}
