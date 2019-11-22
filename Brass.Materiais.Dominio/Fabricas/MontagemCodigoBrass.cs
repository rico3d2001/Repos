using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Fabricas
{
    
    public class MontagemCodigoBrass: MontagemCodigo
    {
       
        public override CodigoEspecificacao MontarCodigo(string siglaPeca, string siglaMaterial, string siglaFabricacao, string siglaExtremidade, 
            string siglaRevestimento, string siglaEspesura, string siglaDiametro)
        {
            
                return new CodigoEspecificacao(
                new SiglaTipoPeca(siglaPeca),
                new SiglaMaterial(siglaMaterial),
                new SiglaEspessura(siglaEspesura),
                new SiglaFabricacao(siglaFabricacao),
                new SiglaExtremidade(siglaExtremidade),
                new SiglaDiametro(siglaDiametro),
                new SiglaRevestimento(siglaRevestimento));
        }
    }
}
