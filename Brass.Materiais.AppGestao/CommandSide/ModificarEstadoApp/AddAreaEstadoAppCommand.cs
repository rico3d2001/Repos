using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp
{
    public class AddAreaEstadoAppCommand : Notifiable, IRequest
    {
        public AddAreaEstadoAppCommand(string area, string subArea, IdentidadeEstado identidadeEstado)
        {
            IdentidadeEstado = identidadeEstado;
            Area = area;
            SubArea = subArea;
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
    }
}
