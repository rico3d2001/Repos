using Brass.Materiais.Dominio.ValueObjects.Materiais;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Fabricas
{
    public class MontagemItemTubo
    {
        private string _peca;
        private string _material;
        private string _schedule;
        private string _fabricacao;
        private string _extremidade;
        private string _revestimento;
        private string _espesura;
        private double _diametroExterno;
        private string _diametroNominal;
        private double _peso;
        private string _normaDimensoes;
        private MontagemCodigo _montadorCodigo;
        private CodigoEspecificacao _codigoEspecificacao;

        public MontagemItemTubo()
        {
            _montadorCodigo = new MontagemCodigoBrass();
        }



        public void Montar(string peca, string material, string schedule, string fabricacao, string extremidade, string revestimento, 
            string espesura, double diametroExterno, string diametroNominal, double peso, string normaDimensoes)
        {
            
            _peca = peca;
            _material = material;
            _schedule = schedule;
            _fabricacao = fabricacao;
            _extremidade = extremidade;
            _revestimento = revestimento;
            _espesura = espesura;
            _diametroExterno = diametroExterno;
            _diametroNominal = diametroNominal;
            _peso = peso;
            _normaDimensoes = normaDimensoes;

            Dictionary<double, string> listaDiametros = new Dictionary<double, string>();
            listaDiametros.Add(21.3, "P102");
            listaDiametros.Add(27.6, "P304");
            listaDiametros.Add(33.4, "P001");

            var siglaDiametro = listaDiametros.First(x => x.Key == diametroExterno).Value;


            _codigoEspecificacao = _montadorCodigo.MontarCodigo(peca, material, fabricacao, extremidade, revestimento, espesura, siglaDiametro);



        }

        //string PECA = "TUB";
        //string ACO = "053";
        //string SCH = "005";
        //string FAB = "SC";
        //string EXT = "PL";
        //string REVEST = "SR";
        //double ESP = 1.65;
        //double ØEXT = 21.3;
        //string DN = "1/2";
        //double PESO = 0.8;
        //string DIMENSOES = "ASME B36.10";




    }
}
