using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Brass.Materiais.ServicoDominio.Fabrica
{
    public class ConstrutorComponente<T>
    {
        T _classe;

        public ConstrutorComponente(T classe)
        {
            _classe = classe;
        }

        public T Inicia(dynamic rdr)
        {
            List<string> propriedades = ExtraiPropriedades();

            foreach (var item in rdr)
            {
                if (propriedades.Contains(item.Key.ToString()))
                {
                    setaValor(_classe, item.Key.ToString(), item.Value);
                }

            }

            return _classe;


        }

        protected void setaValor(Object obj, string propriedade, Object valor)
        {

            PropertyInfo prop = obj.GetType().GetProperty(propriedade, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, valor, null);
            }

        }

        private List<string> ExtraiPropriedades()
        {
            var propriedades = new List<string>();

            foreach (PropertyInfo prp in typeof(T).GetProperties())
            {
                propriedades.Add(prp.Name);
            }

            return propriedades;
        }


    }
}
