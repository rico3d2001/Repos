using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System.Linq;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class ItemTag:Entidade
    {
       

        public ItemTag(NumeroAtivo numeroAtivo, string tagCompleto)
        {
            NumeroAtivo = numeroAtivo;
            TagCompleto = tagCompleto == null ? "" : tagCompleto; 
 
        }



        //public static ItemTag ConstroiSemTag(Projeto projeto, TipoAtivo tipoAtivo)
        //{
        //    switch (tipoAtivo)
        //    {
        //        case TipoAtivo.TUBULACAO:
        //            var numeroAtivo = NumeroAtivo.CriarDoTag(projeto, tipoAtivo);
        //            break;
        //        default:
        //            break;
        //    }

            
        //    return new ItemTag(numeroAtivo, "000000");
        //}


        //public static ItemTag ConstroiDoTextoDoTag(Projeto projeto, string tagCompleto)
        //{
        //    var numeroAtivo = NumeroAtivo.CriarDoTag(projeto, tagCompleto);
        //    return new ItemTag(numeroAtivo, tagCompleto);
        //}

        //public static NumeroAtivo CriarDoTag(AreaTag areaTag, string sigla)
        //{
        //    //var areaTag = AreaTag.Criar(projeto, tagCompleto);

        //    //string sigla = "";

        //    //var parteReferenciaAtivo = tagCompleto.Split('-').First();

        //    //if (parteReferenciaAtivo.Length == 6 && areaTag.Area != "00")
        //    //{

        //    //    switch (parteReferenciaAtivo.Substring(4, 2))
        //    //    {
        //    //        case "PI":
        //    //            sigla = "YY-01";
        //    //            break;

        //    //    }
        //    //}

        //    return new NumeroAtivo(areaTag, sigla);

        //}

        //public string GuidProjeto { get; set; }
        //public AreaTag AreaDesenho { get; set; }
        public NumeroAtivo NumeroAtivo { get; set; }
        //public string Tipo { get; set; }
        public string TagCompleto { get; set; }
        public string Nome { get; set; }
       
       
    }
}
