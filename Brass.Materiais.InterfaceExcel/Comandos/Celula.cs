using OfficeOpenXml;
using System;
using System.Drawing;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public class Celula
    {

         

        ExcelWorksheet _wsPlanilha;
        public Celula(ExcelWorksheet wsPlanilha)
        {
            _wsPlanilha = wsPlanilha;
        }

        private string getCelula(int iLin, int iCol)
        {
            String[] letras = new String[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            if (iCol >= 703)
            {
                int iCol1 = 0;
                int iCol2 = 0;
                int iCol3 = 0;

                iCol2 = iCol / 26;
                if (iCol % 26 == 0)
                {
                    iCol2 -= 1;
                    iCol3 = 26;
                }
                else
                {
                    iCol3 = iCol % 26;
                }

                iCol1 = iCol2 / 26;
                iCol2 = iCol2 % 26;

                return letras[iCol1] + letras[iCol2] + letras[iCol3] + iLin.ToString();
            }
            else
            {
                int iCol1 = 0;
                int iCol2 = 0;

                iCol1 = iCol / 26;
                if (iCol % 26 == 0)
                {
                    iCol1 -= 1;
                    iCol2 = 26;
                }
                else
                {
                    iCol2 = iCol % 26;
                }

                return letras[iCol1] + letras[iCol2] + iLin.ToString();
            }
        }


        public string GetString(int linha, int coluna)
        {
            //string cell = getCelula(linha, coluna);
            //return _wsPlanilha.get_Range(cell, cell).Text;
            var teste = _wsPlanilha.Cells[linha, coluna].Value;

            return teste == null ? "" : _wsPlanilha.Cells[linha, coluna].Value.ToString();
        }

        public int GetInt(int linha, int coluna)
        {
            //string cell = getCelula(linha, coluna);
            //string str = _wsPlanilha.get_Range(cell, cell).Text;
            string str = _wsPlanilha.Cells[linha, coluna].Value.ToString();
            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        public double GetDouble(int linha, int coluna)
        {
            //string cell = getCelula(linha, coluna);
            //string str = _wsPlanilha.get_Range(cell, cell).Text;
            string str = _wsPlanilha.Cells[linha, coluna].Value.ToString();
            str = str.Contains(',') ? str.Replace(',', '.') : str;
            double result = 0.0;
            double.TryParse(str, out result);
            return result;
        }


        public bool IsStrikethrough(int linha, int coluna)
        {
            //string cell = getCelula(linha, coluna);
            //return _wsPlanilha.get_Range(cell, cell).Font.Strikethrough;

            return _wsPlanilha.Cells[linha, coluna].Style.Font.Strike;

        }

        public double GetColorNumber(int linha, int coluna)
        {
            //string cell = getCelula(linha, coluna);
            //return _wsPlanilha.get_Range(cell, cell).Interior.Color;

            return _wsPlanilha.Cells[linha, coluna].Style.Fill.BackgroundColor.Indexed;
        }

        public void SetValor(int linha, int coluna, string novoValor)
        {

            novoValor = novoValor.TrimEnd();
            novoValor = novoValor.TrimEnd('-');
            novoValor = novoValor.TrimEnd();

           

            string cell = getCelula(linha, coluna);
            _wsPlanilha.Cells[cell].Value = novoValor;
            //_wsPlanilha.get_Range(cell, cell).Value2 = novoValor;

        }

        public void SetMarcaMudanca(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            _wsPlanilha.Cells[cell].Style.Font.Color.SetColor(Color.Red);
            //_wsPlanilha.get_Range(cell, cell).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }


    }
}
