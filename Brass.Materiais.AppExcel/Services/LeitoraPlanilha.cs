using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppExcel.Services
{
    public abstract class LeitoraPlanilha<T>
    {
        protected List<T> _lista;
        protected int _numeroLinha;
        protected int vazias;

        protected List<int> _numeroColunasUteis;

        public LeitoraPlanilha(int numeroLinha)
        {
            _numeroLinha = numeroLinha;
            vazias = 0;
            _lista = new List<T>();
        }


        public virtual List<T> Ler(Worksheet wsPlanilha)
        {
            var celula = new Celula(wsPlanilha);

            do
            {
                LerPorLinha(celula);
                _numeroLinha++;

            } while (!Fim(celula));

            return _lista;

        }

        protected abstract void LerPorLinha(Celula celula);



        protected bool Fim(Celula celula)
        {
            vazias = 0;
            for (int i = 0; i < 3; i++)
            {
                if (naoTemItem(celula, _numeroLinha + vazias))
                {
                    vazias++;
                }
            }

            return (vazias < 2) ? false : true;
        }

        protected static bool naoTemItem(Celula celula, int numeroLinha)
        {
            var ver = celula.GetString(numeroLinha, 1);
            return celula.GetString(numeroLinha, 1) == "";
        }



    }
}
