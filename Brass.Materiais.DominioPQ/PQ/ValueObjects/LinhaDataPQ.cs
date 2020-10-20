using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class LinhaDataPQ: ObjetoValor
    {
    

        public LinhaDataPQ(string item, string area, string subArea, string numeroAtivo, string k, string tT,
           string uU, string vVV, string wWW, string descricaoAtividade, string unidade,
           string cMS, string cM_K, string cM_TT, string cM_UU, string sequencial,
           string quantidade, string provisaoEng, string nCM_TEC, string precoUnitario, string precoTotal, string classe,
           string guidAtividade, string guidAtividadePai)
        {
            Item = item;
            Area = area;
            SubArea = subArea;
            NumeroAtivo = numeroAtivo;
            K = k;
            TT = tT;
            UU = uU;
            VVV = vVV;
            WWW = wWW;
            DescricaoAtividade = descricaoAtividade;
            Unidade = unidade;
            CMS = cMS;
            CM_K = cM_K;
            CM_TT = cM_TT;
            CM_UU = cM_UU;
            Sequencial = sequencial;
            Quantidade = quantidade;
            ProvisaoEng = provisaoEng;
            NCM_TEC = nCM_TEC;
            PrecoUnitario = precoUnitario;
            PrecoTotal = precoTotal;
            Classe = classe;
            GuidAtividade = guidAtividade;
            GuidAtividadePai = guidAtividadePai;
        }


        public string Item { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string NumeroAtivo { get; set; }
        public string K { get; set; }
        public string TT { get; set; }
        public string UU { get; set; }
        public string VVV { get; set; }
        public string WWW { get; set; }
        public string DescricaoAtividade { get; set; }
        public string Unidade { get; set; }
        public string CMS { get; set; }
        public string CM_K { get; set; }
        public string CM_TT { get; set; }
        public string CM_UU { get; set; }
        public string Sequencial { get; set; }
        public string Quantidade { get; set; }
        public string ProvisaoEng { get; set; }
        public string NCM_TEC { get; set; }
        public string PrecoUnitario { get; set; }
        public string PrecoTotal { get; set; }
        public string Classe { get; set; }
        public string GuidAtividade { get; set; }
        public string GuidAtividadePai { get; set; }
        



    }
}
