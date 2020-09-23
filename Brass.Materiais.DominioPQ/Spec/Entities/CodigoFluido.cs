using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;

namespace Brass.Materiais.DominioPQ.Spec.Entities
{
    public class CodigoFluido: Entidade
    {
        public CodigoFluido(string gUID_CLIENTE, string sigla, string fluido, string caracterizacao, Versao versao)
        {
            GUID_CLIENTE = gUID_CLIENTE;
            Sigla = sigla;
            Fluido = fluido;
            Caracterizacao = caracterizacao;
            Versao = versao;
        }

        public string GUID_CLIENTE { get; set; }
        public string Sigla { get; set; }
        public string Fluido { get; set; }
        public string Caracterizacao { get; set; }
        public Versao Versao { get; set; }
      
    }
}
