using Brass.Materiais.AppExcel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
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

            var excelApp = new Application();
            excelApp.Visible = true;



            //BancoDados banco = new BancoDados();





            for (int i = 0; i < listaArquivos.Count(); i++)
            {
                string nomeArquivo = listaArquivos.ElementAt(i);



                var workBook = excelApp.Workbooks.Open(nomeArquivo, false, true);

                var wsPlanilhas = workBook.Worksheets;

                _leitoraPlanilha.NomeArquivo = nomeArquivo;

                List<T> lista = new List<T>();



                Worksheet wsPlanilha = wsPlanilhas[1];

                var titulo = _leitoraPlanilha.LerCabecalho(wsPlanilha);



                if (titulo != null)
                {

                    listaResult.Add(titulo);
                    //Titulo_Vale ti = titulo as Titulo_Vale;
                    //banco.Inserir(@"C:\temp\TitulosVale_Planilha.yap", ti);
                }



                workBook.Close(false);




            }

            excelApp.Quit();

            return listaResult;


        }


    }
}
