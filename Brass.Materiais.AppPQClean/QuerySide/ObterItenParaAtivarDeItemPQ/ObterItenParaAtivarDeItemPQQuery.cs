using Brass.Materiais.AppPQClean.ViewModel;
using MediatR;

namespace Brass.Materiais.AppPQClean.QuerySide.ObterItenParaAtivarDeItemPQ
{
    public class ObterItenParaAtivarDeItemPQQuery : IRequest<ItemParaAtivar[]>
    {
        public ObterItenParaAtivarDeItemPQQuery(string guidItem, string guidAtividadePai)
        {
            GuidItem = guidItem;
            GuidAtividadePai = guidAtividadePai;
        }

        public string GuidItem { get; set; }
        public string GuidAtividadePai { get; set; }
    }
}
