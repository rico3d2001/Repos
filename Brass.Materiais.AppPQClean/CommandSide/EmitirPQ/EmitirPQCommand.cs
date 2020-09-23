using Brass.Materiais.DominioPQ.PQ.Entities;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppPQClean.CommandSide.EmitirPQ
{
    public class EmitirPQCommand : Notifiable, IRequest
    {
        public EmitirPQCommand(DataPQ dataPQ)
        {
            DataPQ = dataPQ;
        }

        public DataPQ DataPQ { get; set; }
    }
}
