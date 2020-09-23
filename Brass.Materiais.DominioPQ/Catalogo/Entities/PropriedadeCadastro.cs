using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class PropriedadeCadastro:Entidade
    {
        public bool Cadastrado { get; set; }
        public Codigo Codigo { get; set; }

    }
}
