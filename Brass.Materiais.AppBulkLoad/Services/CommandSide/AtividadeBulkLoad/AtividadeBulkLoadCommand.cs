using Flunt.Notifications;
using MediatR;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppBulkLoad.Services.CommandSide.AtividadeBulkLoad
{
    public class AtividadeBulkLoadCommand : Notifiable, IRequest
    {
        public AtividadeBulkLoadCommand(string arquivo, string aba, string conectStringMongo)
        {
            Arquivo = arquivo;
            Aba = aba;
            ConectStringMongo = conectStringMongo;
        }

        public string Arquivo { get; set; }
        public string Aba { get; set; }
        public string ConectStringMongo { get; set; }
    }
}
