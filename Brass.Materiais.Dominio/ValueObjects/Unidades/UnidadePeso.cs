﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Unidades
{
    public class UnidadePeso: Unidade
    {
        public UnidadePeso(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
      
    }
}
