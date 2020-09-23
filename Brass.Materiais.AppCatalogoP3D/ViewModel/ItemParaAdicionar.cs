using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.AppCatalogoP3D.ViewModel
{
    public class ItemParaAdicionar
    {
        public ItemParaAdicionar(string guidItemPipe, string descricaoItem)
        {
            GuidItemPipe = guidItemPipe;
            DescricaoItem = descricaoItem;
        }

        public string GuidItemPipe { get; set; }
        public string DescricaoItem { get; set; }

        public string Area { get; set; }
        public string SubArea { get; set; }

    }
}
