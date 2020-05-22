using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo;

namespace Brass.Materiais.Dominio.Spec.Entidades
{
    public class ClassePressao:Entidade
    {
        public ClassePressao(string gUID_CLIENTE, string sigla, string definicao, Versao versao)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Sigla = sigla;
            Definicao = definicao;
            Versao = versao;
        }

        public string GUID_CLIENTE { get; set; }
        public string Sigla { get; set; }
        public string Definicao { get; set; }
        public Versao Versao { get; set; }
        
    }
}
