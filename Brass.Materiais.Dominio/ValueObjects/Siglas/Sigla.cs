using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.Dominio.ValueObjects.Siglas
{
    public class Sigla 
    {
        public Sigla(string texto, int numeroCaracteres, bool permiteLetras, bool permiteNumeros)
        {
           
            Texto = texto;
            NumeroCaracteres = numeroCaracteres;
            PermiteLetras = permiteLetras;
            PermiteNumeros = permiteNumeros;
            
        }

       
        public string Texto { get; set; }
        public int NumeroCaracteres { get; set; }
        public bool PermiteLetras { get; set; }
        public bool PermiteNumeros { get; set; }
        





    }
}
