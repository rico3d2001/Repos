using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Models
{
    public class CelulaVale : EnumeracaoViewModel
    {
        public static readonly CelulaVale Item = new CelulaVale(1, "Item");
        public static readonly CelulaVale Area = new CelulaVale(2, "Area");
        public static readonly CelulaVale SubArea = new CelulaVale(3, "SubArea");
        public static readonly CelulaVale NumeroAtivo = new CelulaVale(4, "NumeroAtivoNumeroAtivo");
        public static readonly CelulaVale K = new CelulaVale(5, "K");
        public static readonly CelulaVale TT = new CelulaVale(6, "TT");
        public static readonly CelulaVale UU = new CelulaVale(7, "UU");
        public static readonly CelulaVale VVV = new CelulaVale(8, "VVV");
        public static readonly CelulaVale WWW = new CelulaVale(9, "WWW");
        public static readonly CelulaVale DescricaoAtividade = new CelulaVale(10, "DescricaoAtividade");
        public static readonly CelulaVale Unidade = new CelulaVale(11, "Unidade");
        public static readonly CelulaVale CMS = new CelulaVale(12, "CMS");
        public static readonly CelulaVale CM_K = new CelulaVale(13, "CM_K");
        public static readonly CelulaVale CM_TT = new CelulaVale(14, "CM_TT");
        public static readonly CelulaVale CM_UU = new CelulaVale(15, "CM_UU");
        public static readonly CelulaVale Sequencial = new CelulaVale(16, "Sequencial");
        public static readonly CelulaVale Quantidade = new CelulaVale(17, "Quantidade");
        public static readonly CelulaVale ProvisaoEng = new CelulaVale(18, "ProvisaoEng");
        public static readonly CelulaVale NCM_TEC = new CelulaVale(19, "NCM_TEC");
        public static readonly CelulaVale PrecoUnitario = new CelulaVale(20, "PrecoUnitario");
        public static readonly CelulaVale PrecoTotal = new CelulaVale(21, "PrecoTotal");

        public CelulaVale(int id, string name)
        : base(id, name)
        {
        }





    }
}
