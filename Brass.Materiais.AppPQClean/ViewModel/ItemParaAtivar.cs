using Brass.Materiais.DominioPQ.PQ.Entities;

namespace Brass.Materiais.AppPQClean.ViewModel
{
    public class ItemParaAtivar
    {
        //public ItemParaAtivar(string guidItem, string guidAtividade, string guidAtividadePai, 
        //    string codigoAtividadePai, string decricaoAtividade, string area, string subArea, 
        //    string corAvanco, string codigoAtividade, string guidProjeto, string guidDisciplina)
        //{
        //    GuidItem = guidItem;
        //    GuidAtividade = guidAtividade;
        //    GuidAtividadePai = guidAtividadePai;
        //    CodigoAtividadePai = codigoAtividadePai;
        //    DecricaoAtividade = decricaoAtividade;
        //    Area = area;
        //    SubArea = subArea;
        //    CorAvanco = corAvanco;
        //    CodigoAtividade = codigoAtividade;
        //    GuidProjeto = guidProjeto;
        //    GuidDisciplina = guidDisciplina;
        //}

        public ItemParaAtivar(string guidItem,Atividade atividade, string decricaoAtividade)
        {
                GuidItem = guidItem;
                GuidAtividade = atividade == null ? string.Empty : atividade.GUID;
                GuidAtividadePai = atividade == null ? string.Empty : atividade.GUID_PAI;
                CodigoAtividadePai = "";
                DecricaoAtividade = decricaoAtividade;
                Area = "";
                SubArea = "";
                CorAvanco = "";
                CodigoAtividade = atividade == null ? string.Empty : atividade.Codigo;
                GuidProjeto = "";
                GuidDisciplina = "";
                Ativado = false;
        }

       

        public string GuidItem { get; set; }
        public string GuidAtividade { get; set; }
        public string GuidAtividadePai { get; set; }
        public string CodigoAtividadePai { get; set; }
        public string DecricaoAtividade { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string CorAvanco { get; set; }
        public string CodigoAtividade { get; set; }
        public string GuidProjeto { get; set; }
        public string GuidDisciplina { get; set; }
        public string SPE_Descricao { get; set; }
        public string SPE_Codigo_WWW { get; set; }
        public bool Ativado { get; set; }


    }
}
