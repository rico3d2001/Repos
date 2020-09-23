using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
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
