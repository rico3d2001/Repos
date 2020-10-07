using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class Linha : Entidade
    {

        public Linha(string guidProjeto, string tag, string descricao, string pnPID)
        {
            TagOrigem = tag;
            Descricao = descricao;
            PnPID = pnPID;

            AreaTag areaTag = AreaTag.ObterDoTag(guidProjeto, tag);
            NumeroAtivo = new NumeroAtivo(areaTag, TipoAtivo.TUBULACAO);
        }

        public NumeroAtivo NumeroAtivo { get; set; }
        public string Descricao { get; set; }
        public string PnPID { get; set; }
        public string TagOrigem { get; set; }
    }
}
