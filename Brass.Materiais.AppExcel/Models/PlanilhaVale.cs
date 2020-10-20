using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Models
{
    public abstract class PlanilhaVale : PlanilhaPQ<LinhaVale>
    {
        public override List<LinhaVale> Linhas { get; set; }

        public override void AddLinha(LinhaVale linha)
        {
            //Linhas.Last().LinhasFilhas.Last().LinhasFilhas.Last().LinhasFilhas.Add(linha);
            Linhas.Add(linha);
        }

    }
}
