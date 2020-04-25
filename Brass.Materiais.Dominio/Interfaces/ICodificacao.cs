using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Interfaces
{
    public interface ICodificacao
    {
        CodigoItem Codificar(List<Propriedade> listaPropiedades);
    }
}
