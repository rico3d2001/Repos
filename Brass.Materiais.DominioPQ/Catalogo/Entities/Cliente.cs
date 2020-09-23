using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class Cliente : Entidade
    {
        public Cliente(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }


        public string Sigla { get; set; }
        public string Nome { get; set; }


    }
}
