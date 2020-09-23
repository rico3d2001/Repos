using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class ValorTabelado : Entidade
    {
        public ValorTabelado(string vALOR, string sigla_BRASS)
        {
            VALOR = vALOR;
            Sigla_BRASS = sigla_BRASS;
        }

        public string VALOR { get; set; }
        public string Sigla_BRASS { get; set; }


    }
}
