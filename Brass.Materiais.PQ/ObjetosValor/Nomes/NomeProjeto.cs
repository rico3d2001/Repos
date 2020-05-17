using Brass.Materiais.Dominio.Utils;
using Flunt.Validations;

namespace Brass.Materiais.PQ.ObjetosValor.Nomes
{
    public class NomeProjeto : ObjetoValor
    {
        public NomeProjeto(string texto)
        {
            Texto = texto;

            AddNotifications(new Contract()
               .HasMinLen(Texto, 10,
                $"O texto do nome do projeto", $"Deve ter no mínimo 10 caracteres")
               .Contains(Texto, "Bdb",
               $"O texto do nome do projeto", $"Não contém Bdb no início"));
        }

        public string Texto { get; private set; }

      
    }
}
