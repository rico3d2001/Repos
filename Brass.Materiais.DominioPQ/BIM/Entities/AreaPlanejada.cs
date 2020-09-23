using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class AreaPlanejada : AreaPlanejadaAbstrata
    {
        public AreaPlanejada(string gUID_PROJETO, string area, string subArea, string siglaProjeto, string nome, Versao versao)
            :base(gUID_PROJETO, area, subArea, siglaProjeto, nome, versao)
        {

        }
    }
}
