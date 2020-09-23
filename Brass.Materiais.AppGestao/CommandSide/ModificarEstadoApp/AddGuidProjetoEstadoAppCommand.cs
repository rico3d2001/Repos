using Brass.Materiais.DominioPQ.PQ.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppGestao.CommandSide.ModificarEstadoApp
{
    public class AddGuidProjetoEstadoAppCommand : Notifiable, IRequest
    {
        public AddGuidProjetoEstadoAppCommand(EstadoApp estadoApp)
        {
            EstadoApp = estadoApp;
        }

        public EstadoApp EstadoApp { get; set; }
    }
}
