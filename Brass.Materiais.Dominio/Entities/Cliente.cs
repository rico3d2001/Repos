using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Dominio.ValueObjects.Nomes;
using Brass.Materiais.Dominio.ValueObjects.Siglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class Cliente:Entidade
    {
        public Cliente(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

     
        public string Sigla { get; set; }
        public string Nome { get; set; }

        
    }
}
