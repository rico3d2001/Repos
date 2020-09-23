using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class ItemModelado: Entidade
    {
        private ItemModelado(ItemTag itemTag, string guidProjeto, string pnPID, 
            string descricaoLonga, string descricaoLongaDimensionada, string tipoQuantidade, int unidades, 
            double comprimento, double area, double volume)
        {
            ItemTag = itemTag;
            GuidProjeto = guidProjeto;
            PnPID = pnPID;
            DescricaoLonga = descricaoLonga;
            DescricaoLongaDimensionada = descricaoLongaDimensionada;
            TipoQuantidade = tipoQuantidade;
            Unidades = unidades;
            Comprimento = comprimento;
            Area = area;
            Volume = volume;
        }

        public ItemTag ItemTag { get; set; }
        public string GuidProjeto { get; set; }
        public string PnPID { get; set; }
        public string DescricaoLonga { get; set; }
        public string DescricaoLongaDimensionada { get; set; }
        public string TipoQuantidade { get; set; }

        public int Unidades { get; set; }
        public double Comprimento { get; set; }
        public double Area { get; set; }
        public double Volume { get; set; }

        public static ItemModelado ConstroiItemModeladoDoTubo(BlancPipe blanc, string tag, AreaTag areaTag)
        {

            ItemTag itemTag = new ItemTag(areaTag, "3D", tag, "");

            var itemModel = new ItemModelado(itemTag, areaTag.GUID_PROJETO, blanc.PnPID.ToString(), blanc.PartFamilyLongDesc,
                blanc.PartSizeLongDesc, "QtdLinear", 0, (double)blanc.Length, 0, 0);
            itemModel.Comprimento = (double)blanc.Length;
            return itemModel;
        }

        public static ItemModelado ConstroiItemModeladoDeValvula(UnidadePipe unidade, string tag, AreaTag areaTag)
        {

            ItemTag itemTag = new ItemTag(areaTag, "3D", tag, "");

            var itemModel = new ItemModelado(itemTag, areaTag.GUID_PROJETO, unidade.PnPID.ToString(), unidade.PartFamilyLongDesc,
                unidade.PartSizeLongDesc, "QtdUnitaria", 0, 1.0, 0, 0);
            itemModel.Comprimento = 1.0;
            return itemModel;
        }



    }
}
