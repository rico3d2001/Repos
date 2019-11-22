using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class CodigoEspecificacao: ValueObject
    {
        public CodigoEspecificacao(SiglaTipoPeca siglaTipoPeca, SiglaMaterial siglaMaterial, SiglaEspessura siglaEspessura, SiglaFabricacao siglaFabricacao,
            SiglaExtremidade siglaExtremidade, SiglaDiametro siglaDiametro, SiglaRevestimento siglaRevestimento)
        {
            SiglaTipoPeca = siglaTipoPeca;
            SiglaMaterial = siglaMaterial;
            SiglaEspessura = siglaEspessura;
            SiglaFabricacao = siglaFabricacao;
            SiglaExtremidade = siglaExtremidade;
            SiglaDiametro = siglaDiametro;
            SiglaRevestimento = siglaRevestimento;
        }

        public SiglaTipoPeca SiglaTipoPeca { get; private set; }
        public SiglaMaterial SiglaMaterial { get; private set; }
        public SiglaEspessura SiglaEspessura { get; private set; }
        public SiglaFabricacao SiglaFabricacao { get; private set; }
        public SiglaExtremidade SiglaExtremidade { get; private set; }
        public SiglaDiametro SiglaDiametro { get; set; }
        public SiglaRevestimento SiglaRevestimento { get; set; }


    }
}
