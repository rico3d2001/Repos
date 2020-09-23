using Brass.Materiais.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.DominioPQ.BIM.Entities
{
    public class EAP : Entidade
    {
        public EAP(string gUID_PROJETO, string nomeProjeto)
        {
            GUID_PROJETO = gUID_PROJETO;
            NomeProjeto = nomeProjeto;
        }

        //List<Area> _areas;


        public string GUID_PROJETO { get; set; }
        public string NomeProjeto { get; set; }
        public List<Area> Areas { get; set; }
        //public   { get => _areas;  }

        public void AdicionaArea(Area area)
        {
            if(Areas == null)
            {
                Areas = new List<Area>();
            }
           
            //if (area.NomeArea.Valid)
            //{
            Areas.Add(area);
            //}

        }


    }
}
