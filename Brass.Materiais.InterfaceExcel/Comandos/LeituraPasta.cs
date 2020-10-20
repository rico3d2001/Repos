using Brass.Materiais.InterfaceExcel.Interface;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public class LeituraPasta<T>
    {
        private ICabecalhoPlanilha<T> _leitoraPlanilha;

        public LeituraPasta(ICabecalhoPlanilha<T> leitoraPlanilha)
        {
            _leitoraPlanilha = leitoraPlanilha;
        }

        public List<T> Ler(string nomePastaPlanilhas)//List<string> listaArquivos)
        {
            ArquivosExcel arquivosExcel = new ArquivosExcel();

            var listaArquivos = arquivosExcel.ObtemArquivos(nomePastaPlanilhas).OrderBy(x => x);

            List<T> listaResult = new List<T>();

            //var excelApp = new Application();
            //excelApp.Visible = true;









            for (int i = 0; i < listaArquivos.Count(); i++)
            {
                string nomeArquivo = listaArquivos.ElementAt(i);

                FileInfo fileInfo = new FileInfo(nomeArquivo);




                using (var excelPackage = new ExcelPackage(fileInfo))
                {
                    var wsPlanilha = excelPackage.Workbook.Worksheets[i];

                    var titulo = _leitoraPlanilha.LerCabecalho(wsPlanilha);

                    if (titulo != null)
                    {
                        listaResult.Add(titulo);
                    }
                }



                //var wsPlanilhas = workBook.Worksheets;

                //_leitoraPlanilha.NomeArquivo = nomeArquivo;

                //List<T> lista = new List<T>();





                //    if (titulo != null)
                //    {

                //        listaResult.Add(titulo);

                //    }



                //    workBook.Close(false);




                //}

                //excelApp.Quit();

                


            }

            return listaResult;
        }

    }
}
