using Brass.Materiais.Dominio.ValueObjects;
using Brass.Materiais.Dominio.ValueObjects.Descricoes;
using Brass.Materiais.Dominio.ValueObjects.Dimensoes;
using Brass.Materiais.Dominio.ValueObjects.Pesagem;
using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class TuboItem
    {
        public CodigoItem CodigoItem { get; set; }
        public GrupoDescricoes GrupoDescricoes { get; set; }
        public DiametroTubo MyProperty { get; set; }
        public Peso Peso { get; set; }

    }
}
