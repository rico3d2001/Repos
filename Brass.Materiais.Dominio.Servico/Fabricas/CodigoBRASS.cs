using Brass.Materiais.DominioPQ.Catalogo.Interfaces;
using Brass.Materiais.DominioPQ.Catalogo.ValueObjects;
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
