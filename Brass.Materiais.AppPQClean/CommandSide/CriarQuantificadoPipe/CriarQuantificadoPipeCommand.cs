using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQClean.CommandSide.CriarQuantificadoPipe
{
    public class CriarQuantificadoPipeCommand : Notifiable, IRequest
    {
        public CriarQuantificadoPipeCommand(string guidItemPQ)
        {
            GuidItemPQ = guidItemPQ;
        }

        public string GuidItemPQ { get; set; }

        public void Validate()
        {

        }
    }
}
