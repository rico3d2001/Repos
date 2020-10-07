﻿using Brass.Materiais.DominioPQ.BIM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppPQClean.ViewModel
{
    public class ItemResumo
    {
        public string GuidProjeto { get; set; }

        public string PnPID { get; set; }
        public string SpecPart { get; set; }
        public int SomaValorQuatidade { get; set; }
        public string CorAvanco { get; set; }
        public string Guid { get; set; }
        public string Unidade { get; set; }
        public bool Catalogado { get; set; }

        public NumeroAtivo NumeroAtivo { get; set; }
        public string SiglaPrimeiraAtividade { get; set; }


    }
}