using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brass.Materiais.AppPQClean.ViewModel
{
    public class SequencialItem
    {
        List<int> _sequenciais;
        int _indiceSoma;
        int _limite;
        //int _sequencialBase;
        string _escrita;

        public SequencialItem(int limite)
        {
            //_sequencialBase = 0;
            _limite = limite;
            _indiceSoma = -1;
            _sequenciais = new List<int>(); // { 0, 0, 0, 0, 0 };
        }

        public string Escrita { get => _escrita; private set => _escrita = value; }

        public void Avanca()
        {
           _sequenciais.Add(0);
            _indiceSoma++;
            Soma();
            //comporNumero();
        }

        public void Recua(int indiceParametro)
        {
            //int recuo = _indiceSoma - indiceParametro;
            //int indice = _indiceSoma - (recuo - (indiceParametro - _indiceSoma));
            //_sequenciais.RemoveRange(indice, recuo);
            _sequenciais.RemoveRange(indiceParametro, _limite - indiceParametro + 1);
            _indiceSoma--;
            Soma();
        }

        public bool EstaAvancado(int indiceParametro)
        {
            return _indiceSoma + 1 > indiceParametro ? true : false;
        }

        public bool EstaEmReinicio()
        {
            return _indiceSoma ==  _limite ? true : false;
        }

        public void Reincia()
        {
            _sequenciais[0] = _sequenciais[0] + 1;
            _sequenciais.RemoveRange(1, _limite);
            _indiceSoma = 0;
            comporNumero();
        }

            //public void RetomaNumeracao()
            //{

            //    _sequenciais.RemoveRange(0, _indiceSoma - 1);
            //    _indiceSoma = 0;
            //    Soma();
            //    comporNumero();
            //}

         

        public void IniciaSequencia()
        {
            _sequenciais.Add(0);
            _indiceSoma++;
        }

        public void Soma()
        {
            _sequenciais[_indiceSoma] = _sequenciais.Last() + 1;
            comporNumero();
        }

       
        private string comporNumero()
        {
            _escrita = _sequenciais.First().ToString();

            for (int i = 1; i < _sequenciais.Count; i++)
            {
                _escrita = _escrita + "." + _sequenciais[i];
            }

            return _escrita;
        }
    }
}
