using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.PQ.Entities
{
    public class TabelaAtividades : Entidade
    {
        public TabelaAtividades(string guidCliente, string siglaUsuario, Versao versao, CabecalhoTabelaAtividades cabecalho)
        {
            GuidCliente = guidCliente;
            SiglaUsuario = siglaUsuario;
            Versao = versao;
            Cabecalho = cabecalho;
        }

        public string GuidCliente { get; set; }

        public string SiglaUsuario { get; set; }

        public Versao Versao { get; set; }

        public CabecalhoTabelaAtividades Cabecalho { get; set; }

        public List<LinhaDataPQ> ListaDataPQ { get; private set; }

        public void AddItem(LinhaDataPQ item)
        {
            if (ListaDataPQ == null)
            {
                ListaDataPQ = new List<LinhaDataPQ>();
            }

            ListaDataPQ.Add(item);
        }
    }
}
