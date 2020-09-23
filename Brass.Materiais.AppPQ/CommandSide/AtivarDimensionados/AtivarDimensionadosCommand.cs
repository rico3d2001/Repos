using Brass.Materiais.AppPQ.CommandSide.AtivarDimensionados.ViewModel;
using Flunt.Notifications;
using MediatR;
using System.Collections.Generic;

namespace Brass.Materiais.AppPQ.CommandSide.AtivarDimensionados
{
    public class AtivarDimensionadosCommand : Notifiable, IRequest
    {
        public AtivarDimensionadosCommand(List<Dimensionado> dimensionados)
        {
            Dimensionados = dimensionados;
        }

        public List<Dimensionado> Dimensionados { get; set; }
    }
}
