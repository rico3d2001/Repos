using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Enumerations;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Projeto : Entidade
    {

        public Projeto()
        {

        }
        public Projeto(string gUID_CLIENTE, string nomeProjeto, string sigla, string origem, string guidIdioma)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            NomeProjeto = nomeProjeto;
            Sigla = sigla;
            Origem = origem;
            GUID_IDIOMA = guidIdioma;
        }

        public string GUID_CLIENTE { get; set; }
        public string NomeProjeto { get; set; }
        public string Sigla { get; set; }
        public string PastaPlant3d { get; set; }
        public string GUID_EAP { get; set; }
        public string GUID_EAP_PLANEJADA { get; set; }
        public int TipoProjeto { get; set; }
        public string Origem { get; set; }
        public string Endereco { get; set; }
        public string GUID_IDIOMA { get; set; }

    }
}
