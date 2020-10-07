using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class NumeroAtivo : Entidade
    {
        public NumeroAtivo(AreaTag areaTag, TipoAtivo tipoAtivo)
        {
            AreaTag = areaTag;
            Sigla = tipoAtivo.Name;
        }


       



        public AreaTag AreaTag { get; set; }
        public string Sigla { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                NumeroAtivo argumento = obj as NumeroAtivo;
                return (this.AreaTag.Equals(argumento.AreaTag)
                    && this.Sigla == argumento.Sigla) ? true : false;
            }
        }
    }
}
