using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class ItemSPE: Entidade
    {
        public ItemSPE(string nivel_K, string nivel_TT, string nivel_UU, string nivel_VVV, string nivel_WWW, string descricao, string unidade, string cMS, string cMS_K, string cMS_TT, string cMS_UU, string sequencial, SPEBook sPEBook)
        {
            Nivel_K = nivel_K;
            Nivel_TT = nivel_TT;
            Nivel_UU = nivel_UU;
            Nivel_VVV = nivel_VVV;
            Nivel_WWW = nivel_WWW;
            Descricao = descricao;
            Unidade = unidade;
            CMS = cMS;
            CMS_K = cMS_K;
            CMS_TT = cMS_TT;
            CMS_UU = cMS_UU;
            Sequencial = sequencial;
            SPEBook = sPEBook;
        }

        public string Nivel_K { get; set; }
        public string Nivel_TT { get; set; }
        public string Nivel_UU { get; set; }
        public string Nivel_VVV { get; set; }
        public string Nivel_WWW { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string CMS { get; set; }
        public string CMS_K { get; set; }
        public string CMS_TT { get; set; }
        public string CMS_UU { get; set; }
        public string Sequencial { get; set; }
        public SPEBook SPEBook { get; set; }

    }
}
