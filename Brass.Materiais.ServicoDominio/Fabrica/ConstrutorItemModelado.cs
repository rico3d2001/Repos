using Brass.Materiais.DominioPQ.BIM.Coleta;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using Brass.Materiais.DominioPQ.BIM.ViewsPlant;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Brass.Materiais.ServicoDominio.Fabrica
{
    public class ConstrutorItemModelado
    {
        Projeto _projeto;
        string _tag;
      
        public ConstrutorItemModelado(Projeto projeto, string tag)
        {
            _projeto = projeto;
            _tag = tag;
            
        }

        public ItemModelado Construir(Coletado coletado, ItemPQ itemPQ)
        {
           
                if (coletado.ComponentePlant.PnPClassName == "Pipe")
                {
                    var blanc = (BlancPipe)coletado.ComponentePlant;

                    return new ItemModelado(itemPQ.ItemTag, _projeto.GUID, blanc.PnPID.ToString(), blanc.PartFamilyLongDesc,
                        blanc.PartSizeLongDesc, "QtdLinear", 0, (double)blanc.Length, 0, 0,(double)blanc.Weigth);

                }
                else
                {
                    var unidade = (UnidadePipe)coletado.ComponentePlant;

                    TipoAtivo tipoAtivo = TipoAtivo.ObterDoComponente(coletado.ComponentePlant);
                    AreaTag areaTag = AreaTag.ObterDoTag(_projeto.GUID, unidade.LineNumberTag);
                    NumeroAtivo numeroAtivo = new NumeroAtivo(areaTag, tipoAtivo);

                    ItemTag itemTag = new ItemTag(numeroAtivo, unidade.LineNumberTag);

                    return new ItemModelado(itemTag, _projeto.GUID, unidade.PnPID.ToString(), unidade.PartFamilyLongDesc,
                        unidade.PartSizeLongDesc, "QtdUnitaria", 1, 0, 0, 0,(double)unidade.Weigth);

                }
            

            
         
        }

        public ItemModelado Construir(Coletado coletado)
        {
            
            
                if (coletado.ComponentePlant.PnPClassName == "Pipe")
                {
                    var blanc = (BlancPipe)coletado.ComponentePlant;

                    TipoAtivo tipoAtivo = TipoAtivo.ObterDoComponente(coletado.ComponentePlant);


                    AreaTag areaTag = AreaTag.ObterDoTag(_projeto.GUID, blanc.LineNumberTag);
                    NumeroAtivo numeroAtivo = new NumeroAtivo(areaTag, tipoAtivo);

                    ItemTag itemTag = new ItemTag(numeroAtivo, blanc.LineNumberTag);

                    return new ItemModelado(itemTag, _projeto.GUID, blanc.PnPID.ToString(), blanc.PartFamilyLongDesc,
                        blanc.PartSizeLongDesc, "QtdLinear", 0, (double)blanc.Length, 0, 0, (double)blanc.Weigth);

                }
                else
                {
                    var unidade = (UnidadePipe)coletado.ComponentePlant;

                    TipoAtivo tipoAtivo = TipoAtivo.ObterDoComponente(coletado.ComponentePlant);


                    AreaTag areaTag = AreaTag.ObterDoTag(_projeto.GUID, unidade.LineNumberTag);

                    NumeroAtivo numeroAtivo = new NumeroAtivo(areaTag, tipoAtivo);

                    ItemTag itemTag = new ItemTag(numeroAtivo, unidade.LineNumberTag);

                    return new ItemModelado(itemTag, _projeto.GUID, unidade.PnPID.ToString(), unidade.PartFamilyLongDesc,
                        unidade.PartSizeLongDesc, "QtdUnitaria", 1, 0, 0, 0,(double)unidade.Weigth);

                }

               
            

             
        }
    }
}
