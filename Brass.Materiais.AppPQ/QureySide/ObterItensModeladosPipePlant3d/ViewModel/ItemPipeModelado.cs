using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppPQ.QureySide.ObterItensModeladosPipePlant3d.ViewModel
{
    public class ItemPipeModelado
    {
        public ItemPipeModelado(int specPart)
        {
            SpecPart = specPart;
        }

        public int SpecPart { get; set; }
    }
}
