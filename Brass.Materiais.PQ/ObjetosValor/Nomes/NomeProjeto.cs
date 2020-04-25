using Brass.Materiais.Dominio.Utils;
using Flunt.Validations;

namespace Brass.Materiais.PQ.ObjetosValor.Nomes
{
    public class NomeProjeto : ObjetoValor
    {
        public NomeProjeto(string texto)
        {
            Texto = texto;
        }

        public string Texto { get; private set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .HasMinLen(Texto, 16,
                $"O texto do nome do projeto", $"Deve ter no mínimo 16 caracteres")
               .Contains(Texto, "Bdb",
               $"O texto do nome do projeto", $"Não contém Bdb no início"));
        }
    }
}
