using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using System.Linq;

namespace Brass.Materiais.Dominio.Servico.Handlers.Queries
{
    public class HandlerClientesRequest : Notifiable, IHandlerCommand<RecuperaClientesRequest, Cliente>
    {

        BaseMDBRepositorio<Cliente> _clientesRepositorio;

        public HandlerClientesRequest(BaseMDBRepositorio<Cliente> clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio; 
        }

        public IComandoResult<Cliente> Handle(RecuperaClientesRequest command)
        {
            var clientes = _clientesRepositorio.Obter();

            //Validação rápida para velocidade
            command.Validate();

            if (!(clientes.Count() > 0))
            {
                return new CommandResult<Cliente>(false, "Não há clientes cadastrados.", null);
            }


            if (command.Invalid)
            {
                return new CommandResult<Cliente>(false, "Não foi possível requisitar clientes.", null);
            }


            

            return new CommandResult<Cliente>(true, "Clientes requisitados com sucesso.", clientes);

        }
    }
}
