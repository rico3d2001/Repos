using System.Collections.Generic;

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