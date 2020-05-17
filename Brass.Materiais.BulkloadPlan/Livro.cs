using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brass.Materiais.BulkloadPlan
{
    public class Livro
    {

        public static void Carrega(string nome)
        {
            int indice = 0;

            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            try
            {
                System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


                _Workbook _oWB = oXL.Workbooks._Open(nome,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);


                //Livro oLivro = new Livro(_oWB);
                //oLivro.
                LerPlans(_oWB);

                System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;

            }
            catch (Exception ed)
            {
                MessageBox.Show(ed.Message + " Indice: " + indice);
            }
            finally
            {
                oXL.Quit();
                oXL = null;
            }
        }


        private static void LerPlans(_Workbook _oWB)
        {

            //cntrDbCFG.ListaMetaTabelas();


            Sheets sheets = _oWB.Worksheets;
            for (int i = 1; i <= sheets.Count; i++)
            {
                //var model = new AttributeMappingSource().GetModel(typeof(DataClasses1DataContext));

                Worksheet tabela = (Worksheet)sheets[i];
                if (tabela.Name != "Index")
                {
                    //                IClassMetadata mt =  ConnectionFactory.getMetaTabela(tabela.Name);

                    string tipoPlan = TipoPlan(tabela);

                    switch (tipoPlan)
                    {
                        case "PipeComponentClass":
                            {

                                //                            mt = ConnectionFactory.getMetaTabela("ComumComponente");
                                //Planilha aPlan = new Planilha(tabela, mt);
                                //                             Planilha.TrataLinhasPlan(mt, tabela, "PipeComponentClass");
                            }
                            break;
                        default:
                            {
                                //IClassMetadata mt = ConnectionFactory.getMetaTabela(tipoPlan);
                                //                           Planilha.TrataLinhasPlan(mt, tabela,"Undefined");
                            }
                            break;
                    }




                }

            }

        }

        private static string TipoPlan(Worksheet tabela)
        {
            if ((string)tabela.get_Range(tabela.Cells[4, 2], tabela.Cells[4, 2]).Text == "PipeComponentClass")
                return "PipeComponentClass";
            else if ((string)tabela.get_Range(tabela.Cells[4, 2], tabela.Cells[4, 2]).Text == "PipingCommodityFilter")
                return "PipeComponentClass";
            else
                return "Undefined";

        }
        /*

        private static string NomeiaTabela(string MetaTableName, string nomePlantabela)
        {
            if (MetaTableName.Left(5).Right(1) == "[" && MetaTableName.Right(1) == "]")
                nomePlantabela = "dbo." + "[" + nomePlantabela + "]";
            else
                nomePlantabela = "dbo." + nomePlantabela;
            return nomePlantabela;
        }
         */

    }
}
