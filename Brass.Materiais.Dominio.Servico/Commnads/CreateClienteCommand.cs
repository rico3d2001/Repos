using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.Service.Utils;
using Brass.Materiais.Dominio.ValueObjects.Nomes;
using Brass.Materiais.Dominio.ValueObjects.Siglas;
using Brass.Materiais.RepoMongoDBCatalogo.Services;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class CreateClienteCommand : Notifiable, IComando
    {
        public CreateClienteCommand(string siglaCliente, string nomeCliente)
        {

            SiglaCliente = new Sigla(siglaCliente,4, true, true);
            NomeCliente = new Nome(nomeCliente,4,100,true,true);
        }

        public Sigla SiglaCliente { get; private set; }
        public Nome NomeCliente { get; private set; }
       

        public void Validate()
        {
            AddNotifications(new Contract()
              .HasLen(SiglaCliente.Texto, SiglaCliente.NumeroCaracteres,
               $"O texto da sigla do cliente", $"A sigla do cliente deve ter {SiglaCliente.NumeroCaracteres} caracteres"));

            AddNotifications(new Contract()
             .HasMinLen(NomeCliente.Texto, NomeCliente.MinimoCaracteres,
              $"NomeCliente", $"O nome do cliente deve ter no mínimo {NomeCliente.MinimoCaracteres} caracteres")
             .HasMaxLen("NomeCliente", NomeCliente.MaximoCaracteres,
              $"NomeCliente", $"O nome do cliente deve ter no máximo {NomeCliente.MaximoCaracteres} caracteres"));

        }
    }
}
