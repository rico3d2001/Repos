using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.ValueObjects
{
    public class AreaTag
    {

        public AreaTag()
        {

        }
        public static AreaTag Criar(AreaPlanejada areaPlanejada, string tag)
        {
            var tagSeperado = tag.Split('-');

            foreach (var parteTitulo in tagSeperado)
            {
                var textoExtraidoDoTag = parteTitulo.Trim();

                if (pertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
                {
                    return new AreaTag(
                              areaPlanejada.GUID_PROJETO,
                              areaPlanejada.Area,
                              areaPlanejada.SubArea,
                              areaPlanejada.Nome
                            );
                }

            }

            

            return null;

        }

        public static AreaTag Improvisar(string guidProjeto)
        {
            return new AreaTag(
                       guidProjeto,
                       "00",
                       "00",
                       "Base"
                     );
        }
    

        public static AreaTag Criar(AreaPlanejada areaPlanejada, string area, string subarea)
        {
            var textoExtraidoDoTag = area + subarea;


                if (pertenceAareaPlanejada(areaPlanejada, textoExtraidoDoTag))
                {
                    return new AreaTag(
                              areaPlanejada.GUID_PROJETO,
                              areaPlanejada.Area,
                              areaPlanejada.SubArea,
                              areaPlanejada.Nome
                            );
                }
            else
            {
                return new AreaTag(
                              "00000",
                              area,
                              subarea,
                              "Indefinida"
                            );
            }

            

     

        }

        private static bool pertenceAareaPlanejada(AreaPlanejada areaPlanejada, string areaSubArea)
        {
            return (areaSubArea.Length == 6 || areaSubArea.Length == 4)
                                            && (areaSubArea.Substring(0, 2) == areaPlanejada.Area && areaSubArea.Substring(2, 2) == areaPlanejada.SubArea);
        }



        private AreaTag(string gUID_PROJETO, string area, string subArea, string nome)
        {
            GUID_PROJETO = gUID_PROJETO;
            Area = area;
            SubArea = subArea;
            Nome = nome;
        }

        public string GUID_PROJETO { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string Nome { get; set; }
    
        
    }
}
