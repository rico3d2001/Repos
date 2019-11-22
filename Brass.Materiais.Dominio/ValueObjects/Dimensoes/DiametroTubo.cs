using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Dimensoes
{
    public class DiametroTubo
    {
        public DiametroTubo(DiametroNominal diametroNominal, NormaDimensional normaDimensional, DiametroExterno diametroExterno, Espessura espessura)
        {
            DiametroNominal = diametroNominal;
            NormaDimensional = normaDimensional;
            DiametroExterno = diametroExterno;
            Espessura = espessura;
        }

        public DiametroNominal DiametroNominal { get; set; }
        public NormaDimensional NormaDimensional { get; set; }
        public DiametroExterno DiametroExterno { get; set; }
        public Espessura Espessura { get; set; }

    }
}
