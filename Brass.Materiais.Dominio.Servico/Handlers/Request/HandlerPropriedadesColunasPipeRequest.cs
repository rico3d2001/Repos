using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.Dominio.ValueObjects.Propriedades;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Handlers.Request
{
    public class HandlerPropriedadesColunasPipeRequest : Notifiable, IHandler<RecuperaClientesRequest, Codigo>
    {
        public IComandoResult<Codigo> Handle(RecuperaClientesRequest command)
        {
            throw new NotImplementedException();
        }
    }
}
