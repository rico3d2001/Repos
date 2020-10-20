using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.InterfaceExcel.Comandos
{
    public abstract class EscritorPlanilha<T,U>
    {
   
        protected List<T> _listaIdentidade;
        protected List<U> _listaPreenchimento;

        public EscritorPlanilha(List<T> listaIdentidade, List<U> listaPreenchimento)
        {
            _listaIdentidade = listaIdentidade;
            _listaPreenchimento = listaPreenchimento;


        }

    }
}
