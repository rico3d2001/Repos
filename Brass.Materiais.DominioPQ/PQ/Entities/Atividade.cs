using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using System.Collections.Generic;

namespace Brass.Materiais.DominioPQ.PQ.Entities
{
    public class Atividade : Entidade
    {
   

        public Atividade(IdentidadeAtividade identidadeAtividade,  string nivelAtividade, string gUID_PAI, Versao versao, string codigo, string descricao, string unidade)
        {
            NivelAtividade = nivelAtividade;
            GUID_CLIENTE = identidadeAtividade == null ? "" : identidadeAtividade.GUID_CLIENTE;
            GUID_DISCIPLINA = identidadeAtividade == null ? "" : identidadeAtividade.GUID_DISCIPLINA;
            GUID_IDIOMA = identidadeAtividade == null ? "" : identidadeAtividade.GUID_IDIOMA;
            GUID_PAI = gUID_PAI;
          
            Versao = versao;
            Codigo = codigo;
            Descricao = descricao;

            Unidade = unidade;
        }

        public string NivelAtividade { get; set; }
        public string GUID_CLIENTE { get; set; }
        public string GUID_PAI { get; set; }
        public string GUID_DISCIPLINA { get; set; }
        public string GUID_IDIOMA { get; set; }
        public Versao Versao { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }





    }
}
