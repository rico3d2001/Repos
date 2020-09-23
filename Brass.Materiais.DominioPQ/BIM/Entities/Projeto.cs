using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Enumerations;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Projeto : Entidade
    {
        public Projeto(string gUID_CLIENTE, string nomeProjeto, string sigla, string origem)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            NomeProjeto = nomeProjeto;
            Sigla = sigla;
            Origem = origem;
        }

        public string GUID_CLIENTE { get; set; }
        public string NomeProjeto { get; private set; }
        public string Sigla { get; private set; }
        public string PastaPlant3d { get; set; }
        public string GUID_EAP { get; set; }
        public string GUID_EAP_PLANEJADA { get; set; }
        public int TipoProjeto { get; set; }
        public string Origem { get; set; }
        public string Endereco { get; set; }

    }
}
