using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class AreaTag : Entidade
    {

        public AreaTag()
        {

        }

        private AreaTag(string guidProjeto, string area, string subArea, string nome)
        {
            GUID_PROJETO = guidProjeto;
            Area = area;
            SubArea = subArea;
            Nome = nome;
        }



        //public static AreaTag Improvisar(Projeto projeto)
        //{
        //    return new AreaTag(projeto.GUID, "00", "00", "Base");
        //}


        //public static AreaTag Criar(Projeto projeto, string area, string subArea)
        //{
        //        return new AreaTag(projeto.GUID, area, subArea,"Indefinida");
        //}

        public static AreaTag ObterDoTag(string guidProjeto, string tag)
        {
            if (tag != null)
            {
                var numeroAtivo = tag.Split('-').First();
                if (numeroAtivo.Length == 6)
                {
                    var area = numeroAtivo.Substring(0, 2);
                    var subArea = numeroAtivo.Substring(2, 2);
                    return new AreaTag(guidProjeto, area, subArea, "");
                }
                else
                {
                    var area = "00";
                    var subArea = "00";
                    return new AreaTag(guidProjeto, area, subArea, "");
                }


            }
            else
            {

                var area = "00";
                var subArea = "00";
                return new AreaTag(guidProjeto, area, subArea, "");
            }

        }

        public string GUID_PROJETO { get; set; }
        public string Area { get; private set; }
        public string SubArea { get; private set; }


        public string Nome { get; set; }

        public override bool Equals(Object obj)
        {

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                AreaTag argumento = obj as AreaTag;
                return (this.GUID_PROJETO == argumento.GUID_PROJETO
                    && this.Area == argumento.Area
                    && this.SubArea == argumento.SubArea) ? true : false;
            }
        }


    }
}
