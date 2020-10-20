using Brass.Materiais.AppExcel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
{
    public class EscritorArquivo<T>
    {
        IEscritoraPlanilha _escritoraPlanilha;

        public EscritorArquivo(IEscritoraPlanilha escritoraPlanilha)
        {
            _escritoraPlanilha = escritoraPlanilha;
        }

        public void Escrever(string nomeArquivo, string nomePlanilha)
        {



            var excelApp = new Application();
            excelApp.Visible = true;

            var workBook = excelApp.Workbooks.Open(nomeArquivo);

            var wsPlanilhas = workBook.Worksheets;

            Worksheet wsPlanilha = wsPlanilhas[nomePlanilha];


            _escritoraPlanilha.Escrever(wsPlanilha);


            workBook.SaveAs(@"C:\Trabalho\Templates\Teste.xlsx");


            workBook.Close(false);



            wsPlanilha = null;



            excelApp.Quit();






        }

    }
}
