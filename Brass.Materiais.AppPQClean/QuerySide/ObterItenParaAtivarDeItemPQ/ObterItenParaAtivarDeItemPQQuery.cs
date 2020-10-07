using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ
{
    public class ObterItenParaAtivarDeItemPQQuery : IRequest<ItemParaAtivar[]>
    {
        public ObterItenParaAtivarDeItemPQQuery(string guidItem, string guidAtividadePai, string conectionString)
        {
            TextoConexao = conectionString;
            GuidItem = guidItem;
            GuidAtividadePai = guidAtividadePai;
        }

        public string GuidItem { get; set; }
        public string GuidAtividadePai { get; set; }
        public string TextoConexao { get; set; }
    }
}
