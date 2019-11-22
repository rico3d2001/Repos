using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.ValoresCodigo
{
    public class CodigoItem:ValueObject
    {
        public CodigoItem(CodigoEspecificacao codigoMaterial, SiglaDiametro sequencialTubo)
        {
            CodigoMaterial = codigoMaterial;
            SequencialTubo = sequencialTubo;
        }

        public CodigoEspecificacao CodigoMaterial { get; set; }
        public SiglaDiametro SequencialTubo { get; set; }
    }
}
