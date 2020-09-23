using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class SPEBook:Entidade
    {
        public SPEBook(string nome, string guidCliente, Versao versao)
        {
            Nome = nome;
            GuidCliente = guidCliente;
            Versao = versao;
        }

        public string Nome { get; set; }
        public string GuidCliente { get; set; }
        public Versao Versao { get; set; }
    }
}
