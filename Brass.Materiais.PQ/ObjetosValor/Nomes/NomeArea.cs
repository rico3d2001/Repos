using Brass.Materiais.Dominio.Utils;
using Flunt.Validations;

namespace Brass.Materiais.PQ.ObjetosValor.Nomes
{
    public class NomeArea : ObjetoValor
    {
        public NomeArea(string texto)
        {
            Texto = texto;

            AddNotifications(new Contract()
               .HasMinLen(Texto, 5,
                $"O texto do nome da area", $"Deve ter no mínimo 5 caracteres")
               .Contains(Texto, "A", $"O texto do nome da area", $"Deve iniciar com A"));
        }

        public string Texto { get; private set; }

       
    }
}
