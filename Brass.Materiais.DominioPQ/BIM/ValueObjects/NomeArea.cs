using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.DominioPQ.BIM.ValueObjects
{
    public class NomeArea : ObjetoValor
    {
        public NomeArea(string texto)
        {
            Texto = texto;

            //AddNotifications(new Contract()
            //   .HasMinLen(Texto, 1,
            //    $"O texto do nome da area", $"Deve ter no mínimo 1 caracter"));
        }

        public string Texto { get; private set; }


    }
}
