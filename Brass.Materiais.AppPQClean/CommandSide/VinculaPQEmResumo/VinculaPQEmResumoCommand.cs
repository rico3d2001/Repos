using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.VinculaPQEmResumo
{
    public class VinculaPQEmResumoCommand : Notifiable, IRequest
    {
        public VinculaPQEmResumoCommand(string guidResumo, string guidPQ, string conexao)
        {
            GuidResumo = guidResumo;
            GuidPQ = guidPQ;
            Conexao = conexao;
        }

        public string GuidResumo { get; set; }
        public string GuidPQ { get; set; }
        public string Conexao { get; set; }
    }
}
