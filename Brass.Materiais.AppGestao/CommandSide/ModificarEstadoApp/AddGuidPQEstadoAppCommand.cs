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
    public class AddGuidPQEstadoAppCommand : Notifiable, IRequest
    {
        public AddGuidPQEstadoAppCommand(IdentidadePQ identidadePQ, string conectionString)
        {
            TextoConexao = conectionString;
            IdentidadePQ = identidadePQ;
          
        }

        public IdentidadePQ IdentidadePQ { get; set; }
        public string TextoConexao { get; set; }

    }
}
