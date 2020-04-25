using Brass.Materiais.Dominio.Entities;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class CodigoEspecificacao : ValueObject
    {
        private List<Sigla> _siglasCodigo;


        public CodigoEspecificacao(List<Sigla> lista)
        {
            _siglasCodigo = lista;
        }


        //public void AdicionaSigla(Sigla sigla)
        //{
        //    _siglasCodigo.Add(sigla);
        //}

        //public Sigla Obter(string nome)
        //{
        //   return  _siglasCodigo.FirstOrDefault(x => x.Nome == nome);
        //}

        //public Sigla Obter(double dimensaoMilimetro)
        //{
        //    return _siglasCodigo.FirstOrDefault(x => x.DimensaoMilimetro == dimensaoMilimetro);
        //}


        //public CodigoEspecificacao(SiglaTipoPeca siglaTipoPeca, SiglaMaterial siglaMaterial, SiglaEspessura siglaEspessura, SiglaFabricacao siglaFabricacao,
        //    SiglaExtremidade siglaExtremidade, SiglaDiametro siglaDiametro, SiglaRevestimento siglaRevestimento)
        //{
        //    SiglaTipoPeca = siglaTipoPeca;
        //    SiglaMaterial = siglaMaterial;
        //    SiglaEspessura = siglaEspessura;
        //    SiglaFabricacao = siglaFabricacao;
        //    SiglaExtremidade = siglaExtremidade;
        //    SiglaDiametro = siglaDiametro;
        //    SiglaRevestimento = siglaRevestimento;
        //}

        //public SiglaTipoPeca SiglaTipoPeca { get; private set; }
        //public SiglaMaterial SiglaMaterial { get; private set; }
        //public SiglaEspessura SiglaEspessura { get; private set; }
        //public SiglaFabricacao SiglaFabricacao { get; private set; }
        //public SiglaExtremidade SiglaExtremidade { get; private set; }
        //public SiglaDiametro SiglaDiametro { get; set; }
        //public SiglaRevestimento SiglaRevestimento { get; set; }


    }
}
