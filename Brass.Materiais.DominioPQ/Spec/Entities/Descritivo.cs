using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;

namespace Brass.Materiais.DominioPQ.Spec.Entities
{
    public class Descritivo:Entidade
    {
        public Descritivo(string gUID_CLIENTE, Versao versao, string gUID_IDIOMA, string gUID_DESCRITIVO_PTBR_VALE, string siglaPTBR, string descricaoPTBR, string sigla, string descricao)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Versao = versao;
            GUID_IDIOMA = gUID_IDIOMA;
            GUID_DESCRITIVO_PTBR_VALE = gUID_DESCRITIVO_PTBR_VALE;
            SiglaPTBR = siglaPTBR;
            DescricaoPTBR = descricaoPTBR;
            Sigla = sigla;
            Descricao = descricao;
        }

        public string GUID_CLIENTE { get; set; }
        public Versao Versao { get; set; }
        public string GUID_IDIOMA { get; set; }
        public string GUID_DESCRITIVO_PTBR_VALE { get; set; }
        public string SiglaPTBR { get; set; }
        public string DescricaoPTBR { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}
