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
        public Cliente(Sigla sigla, Nome nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

     
        public Sigla Sigla { get; set; }
        public Nome Nome { get; set; }

        
    }
}
