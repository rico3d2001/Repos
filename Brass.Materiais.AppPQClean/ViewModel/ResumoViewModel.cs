using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.AppPQClean.ViewModel
{
    public class ResumoViewModel
    {

        public ResumoViewModel()
        {
            Itens = new List<ItemResumo>();
        }

        public IdentidadePQ IdentidadePQ { get; set; }

        public List<ItemResumo> Itens { get; set; }

        public Versao Versao { get; set; }
        public bool EstaAtivo { get; set; }
        public bool PQEstaEmitida { get; set; }

        public void AdicionaItem(ItemPQ itemPQ)
        {
            ItemResumo itemResumo = new ItemResumo();
            //itemResumo.GuidProjeto = itemPQ.GuidProjeto;
            itemResumo.PnPID = itemPQ.PnPID;
            itemResumo.SpecPart = itemPQ.SpecPart;
            itemResumo.SomaValorQuatidade = itemPQ.SomaValorQuatidade;
            itemResumo.CorAvanco = itemPQ.CorAvanco;
            itemResumo.Guid = itemPQ.GUID;
            itemResumo.Unidade = itemPQ.Unidade;
            itemResumo.Catalogado = itemPQ.ItemPipe != null ? true : false;
            //itemResumo.Area = itemPQ.ItemTag.AreaDesenho.Area;
            //itemResumo.SubArea = itemPQ.ItemTag.AreaDesenho.SubArea;
            itemResumo.NumeroAtivo = itemPQ.ItemTag.NumeroAtivo;
            itemResumo.SiglaPrimeiraAtividade = "M";

            Itens.Add(itemResumo);

        }

    }
}
