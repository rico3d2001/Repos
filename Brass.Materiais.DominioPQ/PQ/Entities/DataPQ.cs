using Brass.Materiais.Dominio.Utils;
using Brass.Materiais.DominioPQ.BIM.Entities;
using Brass.Materiais.DominioPQ.PQ.ValueObjects;
using Brass.Materiais.Nucleo.ValueObjects;
using System;
using System.Collections.Generic;

namespace Brass.Materiais.DominioPQ.PQ.Entities
{
    public class DataPQ : Entidade
    {
        public DataPQ(IdentidadePQ identidadePQ, Versao versao, CabecalhoPQ cabecalhoPQ)
        {
            IdentidadePQ = identidadePQ;
            Versao = versao;
            CabecalhoPQ = cabecalhoPQ;
            EstaAtiva = true;
            EstaEmitida = false;
            ListaDataPQ = new List<LinhaDataPQ>();
        }

        public IdentidadePQ IdentidadePQ { get; set; }

        public Versao Versao { get; set; }

        public CabecalhoPQ CabecalhoPQ { get; set; }

        public List<LinhaDataPQ> ListaDataPQ { get; private set; }

        public bool EstaAtiva { get; set; } //

        public bool EstaEmitida { get; set; }
       

        public void AddItem(LinhaDataPQ item)
        {
            if (ListaDataPQ == null)
            {
                ListaDataPQ = new List<LinhaDataPQ>();
            }

            ListaDataPQ.Add(item);
        }

        public void ResetLinhas()
        {
            ListaDataPQ = new List<LinhaDataPQ>();
        }

        


    }
}
