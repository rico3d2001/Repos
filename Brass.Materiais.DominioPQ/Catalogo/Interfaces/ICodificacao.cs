using Brass.Materiais.DominioPQ.Catalogo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Interfaces
{
    public interface ICodificacao
    {
        CodigoItem Codificar(List<Propriedade> listaPropiedades);
    }
}
