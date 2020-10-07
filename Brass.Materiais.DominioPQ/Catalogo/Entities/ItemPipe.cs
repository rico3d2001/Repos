﻿using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.Catalogo.Entities
{
    public class ItemPipe : Entidade
    {
        public ItemPipe(string gUID_TIPO_ITEM, string gUID_CATALOGO, string gUID_ITEM_PAI, int pnPID)
        {
            GUID_TIPO_ITEM = gUID_TIPO_ITEM;
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_ITEM_PAI = gUID_ITEM_PAI;
            PnPID = pnPID;
        }

        public ItemPipe(string gUID_TIPO_ITEM, string gUID_CATALOGO, string gUID_ITEM_PAI, int pnPID, string guidFamilia)
        {
            GUID_TIPO_ITEM = gUID_TIPO_ITEM;
            GUID_CATALOGO = gUID_CATALOGO;
            GUID_ITEM_PAI = gUID_ITEM_PAI;
            PnPID = pnPID;
            GUID_FAMILIA = guidFamilia;
        }

        //public string GUID { get; set; }
        public string GUID_TIPO_ITEM { get; set; }
        public string GUID_CATALOGO { get; set; }
        public string GUID_ITEM_PAI { get; set; }
        public int PnPID { get; set; }

        public string GUID_ATIVIDADE { get; set; }
        public string GUID_FAMILIA { get; set; }
        public string PartFamilyId { get; set; }

    }
}