using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Models
{
    public abstract class PlanilhaPQ<T>
    {
        public PlanilhaPQ()
        {
            Linhas = new List<T>();
        }
        public abstract List<T> Linhas { get; set; }

        public abstract void AddLinha(T linha);
    }
}
