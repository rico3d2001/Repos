using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public abstract class AreaPlanejadaAbstrata : Entidade
    {
        public AreaPlanejadaAbstrata(string gUID_PROJETO, string area, string subArea, string siglaProjeto, string nome, Versao versao)
        {
            GUID_PROJETO = gUID_PROJETO;
            Area = area;
            SubArea = subArea;
            SiglaProjeto = siglaProjeto;
            Nome = nome;
            Versao = versao;
        }

        public string GUID_PROJETO { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string SiglaProjeto { get; set; }
        public string Nome { get; set; }
        public Versao Versao { get; set; }
    }
}
