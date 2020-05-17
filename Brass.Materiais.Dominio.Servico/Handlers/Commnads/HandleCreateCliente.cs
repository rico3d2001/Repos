using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.Servico.Commnads;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Handlers.Commnads
{
    public class HandleCreateCliente : Notifiable, IHandler<CreateClienteCommand, Cliente>
    {
        BaseMDBRepositorio<Cliente> _clientesRepositorio;

        public HandleCreateCliente(BaseMDBRepositorio<Cliente> clientesRepositorio)
        {
            _clientesRepositorio = clientesRepositorio;
        }



        public IComandoResult<Cliente> Handle(CreateClienteCommand command)
        {

             command.Validate();

            if (command.Invalid)
            {
                return new CommandResult<Cliente>(false, command.Notifications.First().Message, null);
            }


            var cliente = _clientesRepositorio
                .Encontrar(Builders<Cliente>.Filter.Eq(x => x.Nome.Texto, command.NomeCliente.Texto)).FirstOrDefault();
            if (cliente != null)
            {
                return new CommandResult<Cliente>(false, "Não foi possível requisitar clientes.", null);
            }



            cliente = _clientesRepositorio
                .Encontrar(Builders<Cliente>.Filter.Eq(x => x.Sigla.Texto, command.SiglaCliente.Texto)).FirstOrDefault();
            if (cliente != null)
            {
                return new CommandResult<Cliente>(false, "Não foi possível requisitar clientes.", null);
            }

            cliente = new Cliente(command.SiglaCliente, command.NomeCliente);

            _clientesRepositorio.Inserir(cliente);

            return new CommandResult<Cliente>(true, "Clientes criado com sucesso.", new List<Cliente>{ cliente });

        }
    }
}
