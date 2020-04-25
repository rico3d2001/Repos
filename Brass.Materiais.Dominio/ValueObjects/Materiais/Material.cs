using Brass.Materiais.Dominio.ValueObjects.ValoresCodigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Materiais
{
    public class Material:ValueObjectDB
    {
        public Material(string nome)
        {
            NOME = nome;
        }

        public string NOME { get; set; }
    }
}
