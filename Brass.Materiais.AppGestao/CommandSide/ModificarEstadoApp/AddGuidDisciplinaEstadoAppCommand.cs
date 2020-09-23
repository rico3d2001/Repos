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
    public class AddGuidDisciplinaEstadoAppCommand : Notifiable, IRequest
    {
        public AddGuidDisciplinaEstadoAppCommand(IdentidadeEstado identidadeEstado)
        {
            IdentidadeEstado = identidadeEstado;
        }

        public IdentidadeEstado IdentidadeEstado { get; set; }
    }
}
