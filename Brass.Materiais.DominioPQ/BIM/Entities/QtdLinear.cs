using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class QtdLinear : Quantidade
    {
        public QtdLinear(double comprimento) 
        {
            Comprimento = comprimento;
        }



        //public QtdLinear(string pnPID, double comprimentoCortado, double comprimento, double pesoLinear, 
        //    string unidadePesoLinear, double comprimentoMinimoCorte, bool usaComprimentoFixo): base(pnPID)
        //{

        //    ComprimentoCortado = comprimentoCortado;
        //    Comprimento = comprimento;
        //    PesoLinear = pesoLinear;
        //    UnidadePesoLinear = unidadePesoLinear;
        //    ComprimentoMinimoCorte = comprimentoMinimoCorte;
        //    UsaComprimentoFixo = usaComprimentoFixo;
        //}


        //public double ComprimentoCortado { get; set; }
        public double Comprimento { get; set; }
        //public double PesoLinear { get; set; }
        //public string UnidadePesoLinear { get; set; }
        //public double ComprimentoMinimoCorte { get; set; }
        //public bool UsaComprimentoFixo { get; set; }
        
    }
}
