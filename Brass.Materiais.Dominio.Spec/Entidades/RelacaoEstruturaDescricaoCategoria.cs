using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Spec.Entidades
{
    public class RelacaoEstruturaDescricaoCategoria:Entidade
    {
        public RelacaoEstruturaDescricaoCategoria(string gUID_CATEGORIA, string gUID_ESTRUTURA)
        {
            GUID_CATEGORIA = gUID_CATEGORIA;
            GUID_ESTRUTURA = gUID_ESTRUTURA;
        }

        public string GUID_CATEGORIA { get; set; }
        public string GUID_ESTRUTURA { get; set; }
    }
}
