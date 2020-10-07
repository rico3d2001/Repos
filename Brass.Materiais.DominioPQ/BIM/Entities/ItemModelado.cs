using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
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
        public ItemModelado(ItemTag itemTag, string guidProjeto, string pnPID, 
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

        //public static ItemModelado ConstroiItemModeladoDoTubo(Projeto projeto,  BlancPipe blanc, string tag) //, AreaTag areaTag)
        //{

        //    ItemTag itemTag = ItemTag.ConstroiDoTextoDoTag(projeto,tag,TipoAtivo.TUBULACAO);//( new ItemTag(areaTag, "3D", tag, "");

        //    var itemModel = new ItemModelado(itemTag, projeto.GUID, blanc.PnPID.ToString(), blanc.PartFamilyLongDesc,
        //        blanc.PartSizeLongDesc, "QtdLinear", 0, (double)blanc.Length, 0, 0);
        //    itemModel.Comprimento = (double)blanc.Length;
        //    return itemModel;
        //}

        //public static ItemModelado ConstroiItemModeladoDeValvula(Projeto projeto, UnidadePipe unidade, string tag) //, AreaTag areaTag)
        //{

        //    ItemTag itemTag = ItemTag.ConstroiDoTextoDoTag(projeto,tag, TipoAtivo.TUBULACAO);  //(areaTag, "3D", tag, "");

        //    var itemModel = new ItemModelado(itemTag, projeto.GUID, unidade.PnPID.ToString(), unidade.PartFamilyLongDesc,
        //        unidade.PartSizeLongDesc, "QtdUnitaria", 1, 0, 0, 0);
        //    itemModel.Unidades = 1;
        //    return itemModel;
        //}



    }
}
