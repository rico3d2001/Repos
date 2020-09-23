﻿using Brass.Materiais.AppPQClean.ViewModel;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQClean.CommandSide.AtivarItens
{
    public class AtivarItensCommand : Notifiable, IRequest
    {
        public AtivarItensCommand(List<ItemParaAtivar> itensParaAtivar)
        {
            ItensParaAtivar = itensParaAtivar;
        }

        public List<ItemParaAtivar> ItensParaAtivar { get; set; }

        
        
    }
}
