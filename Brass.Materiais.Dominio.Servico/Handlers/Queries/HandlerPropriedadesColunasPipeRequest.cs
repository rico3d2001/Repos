using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Flunt.Notifications;
using System;

namespace Brass.Materiais.Dominio.Servico.Handlers.Queries
{
    public class HandlerPropriedadesColunasPipeRequest : Notifiable, IHandlerCommand<RecuperaClientesRequest, Codigo>
    {
        public IComandoResult<Codigo> Handle(RecuperaClientesRequest command)
        {
            throw new NotImplementedException();
        }
    }
}
