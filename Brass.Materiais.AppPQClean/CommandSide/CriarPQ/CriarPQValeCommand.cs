using Brass.Materiais.DominioPQ.PQ.Entities;
using Flunt.Notifications;
using MediatR;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarPQ
{
    public class CriarPQValeCommand : Notifiable, IRequest
    {
  
        public CriarPQValeCommand(DataPQ dataPQ, string conectionString)//string cliente, string disciplina, List<ItemPQPlant3d> itens)
        {
            TextoConexao = conectionString;
            DataPQ = dataPQ;
        }

        public DataPQ DataPQ { get; set; }

        public string TextoConexao { get; set; }


    }
}
