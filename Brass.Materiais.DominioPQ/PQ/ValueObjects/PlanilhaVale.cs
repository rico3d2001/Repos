using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public abstract class PlanilhaVale: PlanilhaPQ<LinhaVale>
    {
        public override List<LinhaVale> Linhas { get; set; }

        public override void AddLinha(LinhaVale linha)
        {
            //Linhas.Last().LinhasFilhas.Last().LinhasFilhas.Last().LinhasFilhas.Add(linha);
            Linhas.Add(linha);
        }

    }
}
