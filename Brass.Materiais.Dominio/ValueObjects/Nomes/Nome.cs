using Brass.Materiais.Dominio.Utils;
using Flunt.Validations;

namespace Brass.Materiais.Dominio.ValueObjects.Nomes
{
    public class Nome
    {
        public Nome(string texto, int minimoCaracteres, int maximoCaracteres, bool permiteLetras, bool permiteNumeros)
        {
            Texto = texto;
            MinimoCaracteres = minimoCaracteres;
            MaximoCaracteres = maximoCaracteres;
            PermiteLetras = permiteLetras;
            PermiteNumeros = permiteNumeros;
        }

        public string Texto { get; set; }
        public int MinimoCaracteres { get; set; }
        public int MaximoCaracteres { get; set; }
        public bool PermiteLetras { get; set; }
        public bool PermiteNumeros { get; set; }

    }
}
