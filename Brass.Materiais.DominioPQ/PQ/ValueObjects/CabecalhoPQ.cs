using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.ValueObjects
{
    public class CabecalhoPQ:ObjetoValor
    {
        public CabecalhoPQ(string numeroBrass, string numeroCliente, string classificacao, int revisao, string siglaRevisao, string titulo1, string titulo2, string titulo3)
        {
            NumeroBrass = numeroBrass;
            NumeroCliente = numeroCliente;
            Classificacao = classificacao;
            Revisao = revisao;
            SiglaRevisao = siglaRevisao;
            Titulo1 = titulo1;
            Titulo2 = titulo2;
            Titulo3 = titulo3;
        }

        public string NumeroBrass { get; set; }
        public string NumeroCliente { get; set; }
        public string Classificacao { get; set; }
        public int Revisao { get; set; }
        public string SiglaRevisao { get; set; }
        public string Titulo1 { get; set; }
        public string Titulo2 { get; set; }
        public string Titulo3 { get; set; }
    }
}
