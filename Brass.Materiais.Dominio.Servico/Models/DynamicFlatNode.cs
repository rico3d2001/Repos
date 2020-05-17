using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Servico.Models
{
    public class DynamicFlatNode
    {
        public DynamicFlatNode(string item, int level, bool expandable)
        {
            this.item = item;
            this.level = level;
            this.expandable = expandable;
        }

        public string item { get; set; }
        public int level { get; set; }
        public bool expandable { get; set; }

        /*
         constructor(public item: string, public level: number = 1, public expandable: boolean = false,
        public isLoading: boolean = false) {}
         */
    }
}
