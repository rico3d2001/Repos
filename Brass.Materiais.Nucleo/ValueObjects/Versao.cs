using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Nucleo.ValueObjects
{
    public class Versao: ObjetoValor
    {
        public Versao(int numero, string origem, string descricao, DateTime dataInsercao)
        {
            Numero = numero;
            Origem = origem;
            Descricao = descricao;
            DataInsercao = dataInsercao;
        }

        public int Numero { get; set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInsercao { get; set; }

        public override bool Equals(Object obj)
        {

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var argumento = obj as Versao;

                return argumento.Numero == this.Numero ? true : false; 
            }
        }
    }
}
