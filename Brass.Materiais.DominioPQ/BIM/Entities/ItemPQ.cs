using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.Catalogo.Entities;
using Brass.Materiais.DominioPQ.PQ.Entities;
using System.Collections.Generic;
using Brass.Materiais.DominioPQ.BIM.ValueObjects;
using System.Linq;
using Brass.Materiais.DominioPQ.BIM.Enumerations;
using System;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class ItemPQ : Entidade
    {
        List<ItemModelado> _itensModelados;

        public ItemPQ()
        {

        }

        public ItemPQ(ItemTag itemTag, string pnPID, string specPart, ItemPipe itemPipe, string siglaPrimeiraAtividade, Atividade atividade)
        {
            if (itemPipe != null)
            {
                NominalDiameter = itemPipe.NominalDiameter;
                PesoUnidade = itemPipe.Weigth;
            }
            else
            {
                NominalDiameter = 0.0;
                PesoUnidade = 0.0;
            }



            SiglaPrimeiraAtividade = siglaPrimeiraAtividade;

            Atividade = atividade;

            Catalogado = defineSeCatalogado(itemPipe);
            ItemTag = itemTag;
            PnPID = pnPID;
            SpecPart = specPart;
            _itensModelados = new List<ItemModelado>();
            ItemPipe = itemPipe;

            defineUnidadePorItemPipe();

            defineQuantidadeInicial(Unidade);


        }

     

        public ItemPQ(ItemTag itemTag, ItemModelado itemParaAnalize, string specPart, ItemPipe itemPipe,string siglaPrimeiraAtividade, Atividade atividade)
        {

            if (itemPipe != null)
            {
                NominalDiameter = itemPipe.NominalDiameter;
                PesoUnidade = itemPipe.Weigth;
            }
            else
            {
                NominalDiameter = 0.0;
                PesoUnidade = 0.0;
            }

            SiglaPrimeiraAtividade = siglaPrimeiraAtividade;

            Atividade = atividade;

            Catalogado = defineSeCatalogado(itemPipe);

            //GuidProjeto = guidProjeto;
            //SiglaUsuario = siglaUsuario;
            ItemTag = itemTag;
            PnPID = itemParaAnalize.PnPID;
            SpecPart = specPart;
            _itensModelados = new List<ItemModelado>();
            ItemPipe = itemPipe;
            //NumeroAtivo = "YY01";

            defineUnidadePorItemParaAnalize(itemParaAnalize);

            defineQuantidadeInicial(Unidade);
        }



        private void defineQuantidadeInicial(string unidade)
        {

            switch (unidade)
            {
                case "mm":
                    SomaValorQuatidade = 0;
                    break;
                case "unid.":
                    SomaValorQuatidade = 1;
                    break;
                default:
                    break;
            }

        }




        private void defineUnidadePorItemParaAnalize(ItemModelado itemParaAnalize)
        {
            if (itemParaAnalize.TipoQuantidade == "QtdLinear")
            {
                Unidade = "mm";
            }
            else
            {
                Unidade = "unid.";
            }
        }

        private bool defineSeCatalogado(ItemPipe itemPipe)
        {

            return itemPipe != null ? true : false;
        }




        

        





        private void defineUnidadePorItemPipe()
        {

            if (ItemPipe == null)
            {
                string tipoItem = SpecPart.Split(',').First().Split(' ')[0].Trim();
                if (tipoItem == "PIPE" || tipoItem == "TUBO")
                {
                    Unidade = "mm";
                }
                else
                {
                    Unidade = "unid.";
                }
            }




        }



        public void AdicionaItemModelado(ItemModelado itemModelado)
        {
            _itensModelados.Add(itemModelado);
            ////
            //if(itemModelado.Quantidade != null)
            //{
            var tipo = itemModelado.TipoQuantidade;

            switch (tipo)
            {
                case "QtdLinear":
                    {
                        //PropertyInfo info = tipo.GetProperty("Comprimento");
                        //var valor = (double)info.GetValue(itemModelado.Quantidade, null);
                        SomaValorQuatidade = SomaValorQuatidade + (int)itemModelado.Comprimento;
                    }
                    break;
                case "QtdUnitaria":
                    {
                        //PropertyInfo info = tipo.GetProperty("Comprimento");
                        //var valor = (double)info.GetValue(itemModelado.Quantidade, null);
                        SomaValorQuatidade = _itensModelados.Count;
                    }
                    break;
                default:
                    SomaValorQuatidade = 0;
                    break;
            }
            //}


        }


        public double NominalDiameter { get; set; }
        public double PesoUnidade { get; set; }
        public Atividade Atividade { get; set; }
        public ItemPipe ItemPipe { get; set; }

        public ItemTag ItemTag { get; set; }
        public string PnPID { get; set; }
        public string SpecPart { get; set; }

        public int SomaValorQuatidade { get; set; }

        public string CorAvanco { get; set; }

        public string Unidade { get; set; }
        public bool Catalogado { get; set; }
        public string SiglaPrimeiraAtividade { get; set; }

        public List<ItemModelado> ItensModelados { get => _itensModelados; set => _itensModelados = value; }

       



       


    }
}
