using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Descricoes
{
    public class DescricaoFamilia : ValueObject
    {
        public DescricaoFamilia(string nome)
        {
            Nome = nome;
        }

        //public DescricaoFamilia(string nome)
        //{
        //    Nome = nome;
        //}

        //public string Nome { get; set; }


        public string Nome { get; private set; }



    }
}
