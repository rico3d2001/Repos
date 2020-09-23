using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class CelulaPQ:ObjetoValor
    {
        public CelulaPQ(CelulaVale tipoCelulaPQ, string valorCelula, string formatoConteudo, bool envolveTexto, string alinhamentoHorizontal, string alinhamentoVertical, string fonte, int alturaTexto)
        {
            TipoCelulaPQ = tipoCelulaPQ;
            ValorCelula = valorCelula;
            FormatoConteudo = formatoConteudo;
            EnvolveTexto = envolveTexto;
            AlinhamentoHorizontal = alinhamentoHorizontal;
            AlinhamentoVertical = alinhamentoVertical;
            Fonte = fonte;
            AlturaTexto = alturaTexto;
          
        }

        public CelulaVale TipoCelulaPQ { get; set; }
        public string ValorCelula { get; set; }
        public string FormatoConteudo { get; set; }
        public bool EnvolveTexto { get; set; }
        public string AlinhamentoHorizontal { get; set; }
        public string AlinhamentoVertical { get; set; }
        public string Fonte { get; set; }
        public int AlturaTexto { get; set; }

    }
}
