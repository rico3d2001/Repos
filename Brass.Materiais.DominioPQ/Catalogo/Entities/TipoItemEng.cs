using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.PQ.Entities;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public partial class TipoItemEng : Entidade
    {
        public TipoItemEng(string nOME)
        {
            NOME = nOME;
        }

        public string NOME { get; set; }

        public Atividade AtividadeVVV { get; set; }


    }
}
