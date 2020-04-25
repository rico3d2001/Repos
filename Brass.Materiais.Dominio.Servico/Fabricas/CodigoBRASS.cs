using Brass.Materiais.Dominio.Interfaces;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System.Collections.Generic;

namespace Brass.Materiais.Dominio.Servico.Fabricas
{
    public class CodigoBRASS : ICodificacao
    {
        //public abstract CodigoEspecificacao MontarItem(string siglaPeca, string siglaMaterial, string siglaFabricacao, string siglaExtremidade,
        //    string siglaRevestimento, string siglaEspesura, string siglaDiametro);
        public CodigoItem Codificar(List<Propriedade> listaPropiedades)
        {
            throw new System.NotImplementedException();
        }
    }
}
