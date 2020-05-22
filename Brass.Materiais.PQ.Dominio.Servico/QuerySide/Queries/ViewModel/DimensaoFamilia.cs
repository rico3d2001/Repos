using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Dominio.Servico.QuerySide.Queries.ViewModel
{
    public class DimensaoFamilia
    {
        public DimensaoFamilia(string descricao, string guidItem)
        {
            Descricao = descricao;
            GuidItem = guidItem;
        }

        public string Descricao { get; set; }
        public string GuidItem { get; set; }
    }

 


}
