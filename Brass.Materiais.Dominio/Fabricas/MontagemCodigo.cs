using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Fabricas
{
    public abstract class MontagemCodigo
    {
        public abstract CodigoEspecificacao MontarCodigo(string siglaPeca, string siglaMaterial, string siglaFabricacao, string siglaExtremidade,
            string siglaRevestimento, string siglaEspesura, string siglaDiametro);
    }
}
