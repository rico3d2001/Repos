using Brass.Materiais.Dominio.Service.Utils;
using Flunt.Notifications;
using Flunt.Validations;

namespace Brass.Materiais.Dominio.Servico.Commnads
{
    public class CreateClienteCommand : Notifiable, IComando
    {
        public CreateClienteCommand(string siglaCliente, string nomeCliente, int numeroCaracteresSigla, 
            int numeroMinimoCaracteresNome, int numeroMaximoCaracteresNome)
        {
            SiglaCliente = siglaCliente;
            NomeCliente = nomeCliente;
            NumeroCaracteresSigla = numeroCaracteresSigla;
            NumeroMinimoCaracteresNome = numeroMinimoCaracteresNome;
            NumeroMaximoCaracteresNome = numeroMaximoCaracteresNome;
        }

        public string SiglaCliente { get; private set; }
        public string NomeCliente { get; private set; }
        public int NumeroCaracteresSigla { get; set; }
        public int NumeroMinimoCaracteresNome { get; set; }
        public int NumeroMaximoCaracteresNome { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract()
              .HasLen(SiglaCliente, NumeroCaracteresSigla,
               "O texto da sigla do cliente", $"A sigla do cliente deve ter {NumeroCaracteresSigla} caracteres"));

            AddNotifications(new Contract()
             .HasMinLen(NomeCliente, NumeroMinimoCaracteresNome,
              $"NomeCliente", $"O nome do cliente deve ter no mínimo {NumeroMinimoCaracteresNome} caracteres")
             .HasMaxLen("NomeCliente", NumeroMaximoCaracteresNome,
              $"NomeCliente", $"O nome do cliente deve ter no máximo {NumeroMaximoCaracteresNome} caracteres"));

        }
    }
}
