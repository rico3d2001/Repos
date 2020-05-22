using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Nucleo
{
    public class Versao
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
    }
}
