﻿using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.PQ.Entities.Montagens
{
    public class Atividade : Entidade
    {
        public Atividade(string nivelAtividade, string gUID_PAI, string gUID_CLIENTE, string gUID_DISCIPLINA, 
            string gUID_IDIOMA, Versao versao, string codigo, string descricao)
        {
            NivelAtividade = nivelAtividade;
            GUID_CLIENTE = gUID_CLIENTE;
            GUID_PAI = gUID_PAI;
            GUID_DISCIPLINA = gUID_DISCIPLINA;
            GUID_IDIOMA = gUID_IDIOMA;
            Versao = versao;
            Codigo = codigo;
            Descricao = descricao;
        }

        public string NivelAtividade { get; set; }
        public string GUID_CLIENTE { get; set; }
        public string GUID_PAI { get; set; }
        public string GUID_DISCIPLINA { get; set; }
        public string GUID_IDIOMA { get; set; }
        public Versao Versao { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

    }
}