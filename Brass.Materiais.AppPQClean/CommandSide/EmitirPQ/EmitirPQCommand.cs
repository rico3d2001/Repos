using Brass.Materiais.DominioPQ.PQ.Entities;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppPQClean.CommandSide.EmitirPQ
{
    public class EmitirPQCommand : Notifiable, IRequest
    {
        public EmitirPQCommand(DataPQ dataPQ, string conectionString)
        {
            TextoConexao = conectionString;
            DataPQ = dataPQ;
        }

        public DataPQ DataPQ { get; set; }
        public string TextoConexao { get; set; }
    }
}
