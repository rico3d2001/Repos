using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
{
    public class Celula
    {
        Worksheet _wsPlanilha;
        public Celula(Worksheet wsPlanilha)
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
            string cell = getCelula(linha, coluna);
            return _wsPlanilha.get_Range(cell, cell).Text;
        }

        public int GetInt(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            string str = _wsPlanilha.get_Range(cell, cell).Text;
            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        public double GetDouble(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            string str = _wsPlanilha.get_Range(cell, cell).Text;
            str = str.Contains(',') ? str.Replace(',', '.') : str;
            double result = 0.0;
            double.TryParse(str, out result);
            return result;
        }


        public bool IsStrikethrough(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            return _wsPlanilha.get_Range(cell, cell).Font.Strikethrough;

        }

        public double GetColorNumber(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            return _wsPlanilha.get_Range(cell, cell).Interior.Color;
            //return int.Parse(ver);
        }

        public void SetValor(int linha, int coluna, string novoValor)
        {

            novoValor = novoValor.TrimEnd();
            novoValor = novoValor.TrimEnd('-');
            novoValor = novoValor.TrimEnd();



            string cell = getCelula(linha, coluna);
            _wsPlanilha.get_Range(cell, cell).Value2 = novoValor;
        }

        public void FormatoConteudo(int linha, int coluna, string opcao)
        {
            string cell = getCelula(linha, coluna);
            switch (opcao)
            {
                case "Texto":
                    _wsPlanilha.get_Range(cell, cell).NumberFormat = "@";
                    break;
                default:
                    _wsPlanilha.get_Range(cell, cell).NumberFormat = "@";
                    break;
            }

        }



        public void AlinhamentoHorizontal(int linha, int coluna, string opcao)
        {
            //,"Texto","Direita"
            string cell = getCelula(linha, coluna);
            switch (opcao)
            {
                case "Esquerda":
                    _wsPlanilha.get_Range(cell, cell).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    break;
                case "Direita":
                    _wsPlanilha.get_Range(cell, cell).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    break;
                case "Centro":
                    _wsPlanilha.get_Range(cell, cell).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    break;
                default:
                    _wsPlanilha.get_Range(cell, cell).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    break;
            }

        }

        public void AlinhamentoVertical(int linha, int coluna, string opcao)
        {
            //,"Texto","Direita"
            string cell = getCelula(linha, coluna);
            switch (opcao)
            {
                case "Acima":
                    _wsPlanilha.get_Range(cell, cell).VerticalAlignment = XlVAlign.xlVAlignTop;
                    break;
                case "Abaixo":
                    _wsPlanilha.get_Range(cell, cell).VerticalAlignment = XlVAlign.xlVAlignBottom;
                    break;
                case "Centro":
                    _wsPlanilha.get_Range(cell, cell).VerticalAlignment = XlVAlign.xlVAlignCenter;
                    break;
                default:
                    _wsPlanilha.get_Range(cell, cell).VerticalAlignment = XlVAlign.xlVAlignCenter;
                    break;
            }

        }

        public void BordaAoRedor(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            _wsPlanilha.get_Range(cell, cell).BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin);
            _wsPlanilha.get_Range(cell, cell).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlDash;
            _wsPlanilha.get_Range(cell, cell).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDash;
        }

        public void EnvolveTexto(int linha, int coluna, bool envolve)
        {
            string cell = getCelula(linha, coluna);
            _wsPlanilha.get_Range(cell, cell).WrapText = envolve;
        }

        public void FormataTexto(int linha, int coluna, string fonte, int altura, bool negrito)
        {
            string cell = getCelula(linha, coluna);
            _wsPlanilha.get_Range(cell, cell).Font.Name = fonte;
            _wsPlanilha.get_Range(cell, cell).Font.Size = altura;
            _wsPlanilha.get_Range(cell, cell).Font.Bold = negrito;
        }

        public void SetMarcaMudanca(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);
            _wsPlanilha.get_Range(cell, cell).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }

        public dynamic GetCor(int linha, int coluna)
        {
            string cell = getCelula(linha, coluna);

            var teste = _wsPlanilha.get_Range(cell, cell).Interior.Color;

            return teste;
        }


        public void SetCor(int linha, int coluna, int numeroCor)
        {
            string cell = getCelula(linha, coluna);

            _wsPlanilha.get_Range(cell, cell).Interior.Color = numeroCor;
        }

    }
}
