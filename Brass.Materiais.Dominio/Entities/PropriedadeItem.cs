﻿using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Entities
{
    public class PropriedadeItem: Entidade
    {
        public string GUID_VALOR { get; set; }
        public string GUID_TIPO { get; set; }
    }
}
