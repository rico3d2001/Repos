using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Dimensoes
{
    public class DimensaoFamilia : ObjetoValor
    {
        public DimensaoFamilia(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        //public DimensaoFamilia(string diametroNominal)
        //{
        //    double d;
        //    if (double.TryParse(diametroNominal, out d))
        //    {
        //        DiametroNominal = d;
        //    }
        //    else
        //    {
        //        DiametroNominal = 0;
        //    }

        //}

        //public double DiametroNominal { get; set; }

        
    }
}
