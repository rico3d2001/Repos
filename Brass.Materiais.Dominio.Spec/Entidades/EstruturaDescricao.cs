using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo;

namespace Brass.Materiais.Dominio.Spec.Entidades
{
    public class EstruturaDescricao:Entidade
    {
        public EstruturaDescricao(string gUID_CLIENTE, Versao versao, string nome, string coluna, string descricao, string gUID_NOME_PROPRIEDADE)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Versao = versao;
            Nome = nome;
            Coluna = coluna;
            Descricao = descricao;
            GUID_NOME_PROPRIEDADE = gUID_NOME_PROPRIEDADE;
        }

        public string GUID_CLIENTE { get; set; }
        public Versao Versao { get; set; }
        public string Nome{ get; set; }
        public string Coluna { get; set; }
        public string Descricao { get; set; }
        public string GUID_NOME_PROPRIEDADE { get; set; }

    }
}
