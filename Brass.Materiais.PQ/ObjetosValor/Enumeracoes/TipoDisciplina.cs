using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brass.Materiais.Dominio.Utils;

namespace Brass.Materiais.PQ.ObjetosValor.Enumeracoes
{
    public class TipoDisciplina : Enumeracao
    {
        public static readonly TipoDisciplina E_ELE = new TipoDisciplina(1, "Eletrica");
        public static readonly TipoDisciplina I_INS = new TipoDisciplina(1, "Instrumentação");
        public static readonly TipoDisciplina L_TUB = new TipoDisciplina(1, "Tubulação");
        public static readonly TipoDisciplina M_MEC = new TipoDisciplina(1, "Mecanica");

        public TipoDisciplina(int id, string name)
        : base(id, name)
        {
        }
    }
}
