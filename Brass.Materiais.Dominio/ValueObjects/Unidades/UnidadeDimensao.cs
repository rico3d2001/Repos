﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.ValueObjects.Unidades
{
    public class UnidadeDimensao : Unidade
    {
        public UnidadeDimensao(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
