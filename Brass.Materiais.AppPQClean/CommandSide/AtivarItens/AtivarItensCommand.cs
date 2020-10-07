using Brass.Materiais.AppPQClean.ViewModel;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.CommandSide.AtivarItens
{
    public class AtivarItensCommand : Notifiable, IRequest
    {
        public AtivarItensCommand(List<ItemParaAtivar> itensParaAtivar, string conectionString)
        {
            ItensParaAtivar = itensParaAtivar;
            TextoConexao = conectionString;
        }

        public List<ItemParaAtivar> ItensParaAtivar { get; set; }
        public string TextoConexao { get; set; }


    }
}
